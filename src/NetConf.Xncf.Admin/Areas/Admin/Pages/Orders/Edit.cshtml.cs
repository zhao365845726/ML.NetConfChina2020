using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Senparc.Ncf.Service;
using Senparc.CO2NET.Trace;
using Senparc.CO2NET.Extensions;
using NetConf.Xncf.Admin.Models.DatabaseModel.Dto;
using NetConf.Xncf.Admin.Services;

namespace NetConf.Xncf.Admin.Areas.Admin.Pages.Orders
{
    public class EditModel : Senparc.Ncf.AreaBase.Admin.AdminXncfModulePageModelBase
    {
        private readonly OrdersService _ordersService;
        public EditModel(OrdersService ordersService,Lazy<XncfModuleService> xncfModuleService) : base(xncfModuleService)
        {
            CurrentMenu = "Orders";
            _ordersService = ordersService;
        }

        [BindProperty(SupportsGet = true)]
        public string Id { get; set; }
        public OrdersDto OrdersDto { get; set; }

        /// <summary>
        /// Handler=Save
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> OnPostSaveAsync([FromBody] OrdersDto ordersDto)
        {
            if (ordersDto == null)
            {
                return Ok(false);
            }
            await _ordersService.CreateOrUpdateAsync(ordersDto);
            return Ok(true);
        }

        public async Task<IActionResult> OnPostDeleteAsync([FromBody] string[] ids)
        {
            var entity = await _ordersService.GetFullListAsync(_ => ids.Contains(_.Id));
            await _ordersService.DeleteAllAsync(entity);
            IEnumerable<string> unDeleteIds = ids.Except(entity.Select(_ => _.Id));
            return Ok(unDeleteIds);
        }
    }
}
