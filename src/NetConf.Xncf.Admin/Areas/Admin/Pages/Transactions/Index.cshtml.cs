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

namespace NetConf.Xncf.Admin.Areas.Admin.Pages.Transactions
{
    public class IndexModel : Senparc.Ncf.AreaBase.Admin.AdminXncfModulePageModelBase
    {
        private readonly TransactionsService _transactionsService;
        private readonly IServiceProvider _serviceProvider;
        public TransactionsDto transactionsDto { get; set; }
        public string Token { get; set; }
        public string UpFileUrl { get; set; }
        public string BaseUrl { get; set; }

        public IndexModel(Lazy<XncfModuleService> xncfModuleService, TransactionsService transactionsService, IServiceProvider serviceProvider) : base(xncfModuleService)
        {
            CurrentMenu = "Transactions";
            this._transactionsService = transactionsService;
            this._serviceProvider = serviceProvider;
        }

        [BindProperty(SupportsGet = true)]
        public int PageIndex { get; set; } = 1;
        public PagedList<Models.DatabaseModel.Transactions> Transactions { get; set; }

        public Task OnGetAsync()
        {
            BaseUrl = $"{Request.Scheme}://{Request.Host.Value}";
            UpFileUrl = $"{BaseUrl}/api/v1/common/upload";
            return Task.CompletedTask;
        }

        public async Task<IActionResult> OnGetTransactionsAsync(string name, string orderField, int pageIndex, int pageSize)
        {
            var seh = new SenparcExpressionHelper<Models.DatabaseModel.Transactions>();
            seh.ValueCompare.AndAlso(!string.IsNullOrEmpty(name), _ => _.OrderNum.Contains(name));
            var where = seh.BuildWhereExpression();
            var response = await _transactionsService.GetObjectListAsync(pageIndex, pageSize, where, orderField);
            return Ok(new
                    {
                        response.TotalCount,
                        response.PageIndex,
                        List = response.Select(_ => new {
                            _.Id,
                            _.LastUpdateTime,
                            _.Remark,
                            _.OrderNum,
                            _.Status,
                            _.UserId,
                            _.Quota,
                            _.Method,
                            _.AddTime
                        })
                    });
        }
    }
}
