using Senparc.CO2NET.Trace;
using Senparc.Ncf.Core.Enums;
using Senparc.Ncf.Repository;
using Senparc.Ncf.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetConf.Xncf.Admin.Models.DatabaseModel;
using NetConf.Xncf.Admin.Models.DatabaseModel.Dto;
using Senparc.Ncf.Utility;

namespace NetConf.Xncf.Admin.Services
{
    public class OrdersService : ServiceBase<Orders>
    {
        private readonly UserService userService;
        private readonly ProductsService productsService;

        public OrdersService(IRepositoryBase<Orders> repo, IServiceProvider serviceProvider,UserService userService,ProductsService productsService) : base(repo, serviceProvider)
        {
            this.userService = userService;
            this.productsService = productsService;
        }

        //TODO: 更多业务方法可以写到这里
        public async Task<IEnumerable<OrdersDto>> GetOrdersList(int PageIndex, int PageSize)
        {
            List<OrdersDto> selectListItems = null;
            List<Orders> orders = (await GetFullListAsync(_ => true).ConfigureAwait(false)).OrderByDescending(_ => _.AddTime).ToList();
            selectListItems = this.Mapper.Map<List<OrdersDto>>(orders);
            return selectListItems;
        }

        public async Task CreateOrUpdateAsync(OrdersDto dto)
        {
            Orders orders;
            if (String.IsNullOrEmpty(dto.Id))
            {
                orders = new Orders(dto);
            }
            else
            {
                orders = await GetObjectAsync(_ => _.Id == dto.Id);
                orders.Update(dto);
            }
            await SaveObjectAsync(orders);
        }

        #region 接口
        public async Task<object> ApiAddCartAsync(string userId, string productId, decimal amount, int number)
        {
            Random random = new Random();
            int iRan = random.Next(100000, 999999);
            OrdersDto dto = new OrdersDto()
            {
                OrderNum = $"NUMBER{iRan}",
                ProductId = productId,
                UserId = userId,
                Number = number,
                Amount = amount,
                Status = 99
            };
            await CreateOrUpdateAsync(dto);
            return true;
        }

        public async Task<object> ApiConfirmOrderAsync(string userId, string orderId)
        {
            var seh = new SenparcExpressionHelper<Models.DatabaseModel.Orders>();
            seh.ValueCompare.AndAlso(!string.IsNullOrEmpty(userId), _ => _.UserId.Equals(userId));
            seh.ValueCompare.AndAlso(!string.IsNullOrEmpty(orderId), _ => _.Id.Equals(orderId));
            var where = seh.BuildWhereExpression();
            Orders orders = await GetObjectAsync(where);
            orders.Status = 1;
            await SaveObjectAsync(orders);
            return true;
        }

        public async Task<object> ApiGetListAsync(string userId, int pageIndex,int pageSize)
        {
            var seh = new SenparcExpressionHelper<Models.DatabaseModel.Orders>();
            seh.ValueCompare.AndAlso(!string.IsNullOrEmpty(userId), _ => _.UserId.Equals(userId));
            var where = seh.BuildWhereExpression();
            var orderList = await GetObjectListAsync(pageIndex,pageSize,where,"AddTime Desc");
            var userList = await userService.GetObjectListAsync(0, 0, _ => true, "AddTime Desc");
            var productList = await productsService.GetObjectListAsync(0, 0, _ => true, "AddTime Desc");
            var response = (from orderItem in orderList
                            join productItem in productList on orderItem.ProductId equals productItem.Id
                            join userItem in userList on orderItem.UserId equals userItem.Id
                            select new
                            {
                                orderItem.Id,
                                orderItem.OrderNum,
                                orderItem.Number,
                                orderItem.Amount,
                                orderItem.PaidAmount,
                                orderItem.Status,
                                productItem.Name,
                                productItem.Cover,
                                productItem.Price,
                                orderItem.AddTime
                            }).ToList();
            return response;
        }

        public async Task<object> ApiGetDetailAsync(string id)
        {
            var seh = new SenparcExpressionHelper<Models.DatabaseModel.Orders>();
            seh.ValueCompare.AndAlso(!string.IsNullOrEmpty(id), _ => _.Id.Equals(id));
            var where = seh.BuildWhereExpression();
            var orderInfo = await GetObjectAsync(where);
            var userInfo = await userService.GetObjectAsync(_ => _.Id.Equals(orderInfo.UserId));
            var productInfo = await productsService.GetObjectAsync(_ => _.Id.Equals(orderInfo.ProductId));
            var response = new
            {
                orderInfo.Id,
                orderInfo.OrderNum,
                orderInfo.Number,
                orderInfo.Amount,
                orderInfo.PaidAmount,
                orderInfo.Status,
                productInfo.Name,
                productInfo.Cover,
                productInfo.Video,
                productInfo.Content,
                productInfo.Price,
                userInfo.NickName,
                orderInfo.AddTime
            };
            return response;
        }

        public async Task<object> ApiCancelOrderAsync(string userId, string orderId)
        {
            var seh = new SenparcExpressionHelper<Models.DatabaseModel.Orders>();
            seh.ValueCompare.AndAlso(!string.IsNullOrEmpty(userId), _ => _.UserId.Equals(userId));
            seh.ValueCompare.AndAlso(!string.IsNullOrEmpty(orderId), _ => _.Id.Equals(orderId));
            var where = seh.BuildWhereExpression();
            Orders orders = await GetObjectAsync(where);
            orders.Status = 5;
            await SaveObjectAsync(orders);
            return true;
        }

        public async Task<object> ApiPaymentOrderAsync(string userId, string orderId)
        {
            var seh = new SenparcExpressionHelper<Models.DatabaseModel.Orders>();
            seh.ValueCompare.AndAlso(!string.IsNullOrEmpty(userId), _ => _.UserId.Equals(userId));
            seh.ValueCompare.AndAlso(!string.IsNullOrEmpty(orderId), _ => _.Id.Equals(orderId));
            var where = seh.BuildWhereExpression();
            Orders orders = await GetObjectAsync(where);
            orders.Status = 2;
            await SaveObjectAsync(orders);
            return true;
        }
        #endregion

    }

}
