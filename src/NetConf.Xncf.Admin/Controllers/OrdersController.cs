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
    public class OrdersController : BaseController
    {
        private readonly CategoryService categoryService;
        private readonly OrdersService ordersService;

        public OrdersController(CategoryService categoryService,OrdersService ordersService)
        {
            this.categoryService = categoryService;
            this.ordersService = ordersService;
        }

        /// <summary>
        /// 添加到购物车
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <param name="productId">商品Id</param>
        /// <param name="amount">价格</param>
        /// <param name="number">数量</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> AddCartAsync(string userId,string productId,decimal amount,int number)
        {
            try
            {
                var response = await ordersService.ApiAddCartAsync(userId, productId, amount, number);
                return Success(response);
            }
            catch (Exception ex)
            {
                return Fail(ex.Message);
            }
        }

        /// <summary>
        /// 确认订单
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <param name="orderId">订单Id</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> ConfirmOrderAsync(string userId,string orderId)
        {
            try
            {
                var response = await ordersService.ApiConfirmOrderAsync(userId, orderId);
                return Success(response);
            }
            catch (Exception ex)
            {
                return Fail(ex.Message);
            }
        }

        /// <summary>
        /// 订单列表/我的订单(1-待支付;2-已支付;3-待评价;4-已完成;5-已取消;99-购物车;)
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <param name="status">订单状态</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">页大小</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> ListAsync(string userId,int status,int pageIndex, int pageSize)
        {
            try
            {
                var response = await ordersService.ApiGetListAsync(userId,status,pageIndex, pageSize);
                return Success(response);
            }
            catch (Exception ex)
            {
                return Fail(ex.Message);
            }
        }

        /// <summary>
        /// 订单详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> DetailAsync(string id)
        {
            try
            {
                var response = await ordersService.ApiGetDetailAsync(id);
                return Success(response);
            }
            catch (Exception ex)
            {
                return Fail(ex.Message);
            }
        }

        /// <summary>
        /// 取消订单
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <param name="orderId">订单Id</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> CancelOrderAsync(string userId,string orderId)
        {
            try
            {
                var response = await ordersService.ApiCancelOrderAsync(userId,orderId);
                return Success(response);
            }
            catch (Exception ex)
            {
                return Fail(ex.Message);
            }
        }

        /// <summary>
        /// 支付
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <param name="orderId">订单Id</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> PaymentAsync(string userId, string orderId)
        {
            try
            {
                var response = await ordersService.ApiPaymentOrderAsync(userId, orderId);
                return Success(response);
            }
            catch (Exception ex)
            {
                return Fail(ex.Message);
            }
        }
    }
}
