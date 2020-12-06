using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Senparc.Ncf.Service;
using Microsoft.Extensions.DependencyInjection;
using Senparc.Ncf.Core.Models;
using Senparc.CO2NET.Trace;
using Senparc.Ncf.Utility;
using NetConf.Xncf.Admin.Models.DatabaseModel.Dto;
using NetConf.Xncf.Admin.Services;

namespace NetConf.Xncf.Admin.Areas.Admin.Pages.Products
{
    public class IndexModel : Senparc.Ncf.AreaBase.Admin.AdminXncfModulePageModelBase
    {
        private readonly ProductsService _productsService;
        private readonly CategoryService categoryService;
        private readonly IServiceProvider _serviceProvider;
        public ProductsDto productsDto { get; set; }
        public string Token { get; set; }
        public string UpFileUrl { get; set; }
        public string BaseUrl { get; set; }

        public IndexModel(Lazy<XncfModuleService> xncfModuleService, ProductsService productsService,CategoryService categoryService, IServiceProvider serviceProvider) : base(xncfModuleService)
        {
            CurrentMenu = "Products";
            this._productsService = productsService;
            this.categoryService = categoryService;
            this._serviceProvider = serviceProvider;
        }

        [BindProperty(SupportsGet = true)]
        public int PageIndex { get; set; } = 1;
        public PagedList<Models.DatabaseModel.Products> Products { get; set; }

        public Task OnGetAsync()
        {
            BaseUrl = $"{Request.Scheme}://{Request.Host.Value}";
            UpFileUrl = $"{BaseUrl}/api/v1/common/upload";
            return Task.CompletedTask;
        }

        public async Task<IActionResult> OnGetProductsAsync(string keyword, string orderField, int pageIndex, int pageSize)
        {
            var seh = new SenparcExpressionHelper<Models.DatabaseModel.Products>();
            seh.ValueCompare.AndAlso(!string.IsNullOrEmpty(keyword), _ => _.Name.Contains(keyword));
            var where = seh.BuildWhereExpression();
            var response = await _productsService.GetObjectListAsync(pageIndex, pageSize, where, orderField);
            var categoryList = await categoryService.GetObjectListAsync(0, 0, _ => true, "AddTime Desc");
            return Ok(new
                    {
                        response.TotalCount,
                        response.PageIndex,
                        List = response.Select(_ => new {
                            _.Id,
                            _.LastUpdateTime,
                            _.Remark,
                            _.CategoryId,
                            _.Name,
                            _.Cover,
                            _.Video,
                            _.Content,
                            _.AddTime,
                            CategoryName = categoryList.Where(z => z.Id.Equals(_.CategoryId)).Select(z => z.Name)
                        })
                    });
        }
    }
}
