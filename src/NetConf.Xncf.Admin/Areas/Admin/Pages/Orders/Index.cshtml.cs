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

namespace NetConf.Xncf.Admin.Areas.Admin.Pages.Orders
{
    public class IndexModel : Senparc.Ncf.AreaBase.Admin.AdminXncfModulePageModelBase
    {
        private readonly OrdersService _ordersService;
        private readonly IServiceProvider _serviceProvider;
        public OrdersDto ordersDto { get; set; }
        public string Token { get; set; }
        public string UpFileUrl { get; set; }
        public string BaseUrl { get; set; }

        public IndexModel(Lazy<XncfModuleService> xncfModuleService, OrdersService ordersService, IServiceProvider serviceProvider) : base(xncfModuleService)
        {
            CurrentMenu = "Orders";
            this._ordersService = ordersService;
            this._serviceProvider = serviceProvider;
        }

        [BindProperty(SupportsGet = true)]
        public int PageIndex { get; set; } = 1;
        public PagedList<Models.DatabaseModel.Orders> Orders { get; set; }

        public Task OnGetAsync()
        {
            BaseUrl = $"{Request.Scheme}://{Request.Host.Value}";
            UpFileUrl = $"{BaseUrl}/api/v1/common/upload";
            return Task.CompletedTask;
        }

        public async Task<IActionResult> OnGetOrdersAsync(string keyword, string orderField, int pageIndex, int pageSize)
        {
            var seh = new SenparcExpressionHelper<Models.DatabaseModel.Orders>();
            seh.ValueCompare.AndAlso(!string.IsNullOrEmpty(keyword), _ => _.OrderNum.Contains(keyword));
            var where = seh.BuildWhereExpression();
            var response = await _ordersService.GetObjectListAsync(pageIndex, pageSize, where, orderField);
            return Ok(new
                    {
                        response.TotalCount,
                        response.PageIndex,
                        List = response.Select(_ => new {
                            _.Id,
                            _.LastUpdateTime,
                            _.Remark,
                            _.OrderNum,
                            _.ProductId,
                            _.UserId,
                            _.Number,
                            _.Amount,
                            _.PaidAmount,
                            _.Status,
                            _.AddTime
                        })
                    });
        }
    }
}
