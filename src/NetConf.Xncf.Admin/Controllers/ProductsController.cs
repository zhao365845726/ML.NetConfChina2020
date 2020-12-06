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
    public class ProductsController : BaseController
    {
        private readonly ProductsService productsService;
        private readonly CategoryService categoryService;

        public ProductsController(ProductsService productsService,CategoryService categoryService)
        {
            this.productsService = productsService;
            this.categoryService = categoryService;
        }

        /// <summary>
        /// 获取商品列表
        /// </summary>
        /// <param name="categoryId">分类Id</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">页大小</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetListAsync(string categoryId,int pageIndex, int pageSize)
        {
            try
            {
                var response = await productsService.ApiGetListAsync(categoryId,pageIndex, pageSize);
                return Success(response);
            }
            catch (Exception ex)
            {
                return Fail(ex.Message);
            }
        }

        /// <summary>
        /// 获取商品详情
        /// </summary>
        /// <param name="id">商品Id</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetDetailAsync(string id)
        {
            try
            {
                var response = await productsService.ApiGetDetailAsync(id);
                return Success(response);
            }
            catch (Exception ex)
            {
                return Fail(ex.Message);
            }
        }
    }
}
