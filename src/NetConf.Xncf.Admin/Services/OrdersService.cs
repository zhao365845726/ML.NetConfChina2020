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
namespace NetConf.Xncf.Admin.Services
{
    public class OrdersService : ServiceBase<Orders>
    {
        public OrdersService(IRepositoryBase<Orders> repo, IServiceProvider serviceProvider) : base(repo, serviceProvider)
        {
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

    }

}
