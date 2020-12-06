using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetConf.Xncf.Admin.Services;
using Senparc.Ncf.Utility;
using Senparc.Ncf.Core.Models;
using Senparc.CO2NET.Trace;
using NetConf.Xncf.Admin.Models.DatabaseModel;
using NetConf.Xncf.Admin.Models.DatabaseModel.Dto;
using AutoMapper;

namespace NetConf.Xncf.Admin.Controllers
{
    /// <summary>
    /// 消息接口
    /// </summary>
    [Route("api/v{version:apiVersion}/[controller]/[action]")]
    [ApiController]
    [ApiVersion("1")]
    public class CategoryController : BaseController
    {
        private readonly CategoryService categoryService;

        public CategoryController(CategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        /// <summary>
        /// 获取分类列表
        /// </summary>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">页大小</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetListAsync(int pageIndex, int pageSize)
        {
            try
            {
                var response = await categoryService.ApiGetListAsync(pageIndex, pageSize);
                return Success(response);
            }
            catch (Exception ex)
            {
                return Fail(ex.Message);
            }
        }
    }
}
