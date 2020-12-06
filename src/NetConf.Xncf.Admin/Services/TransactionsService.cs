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
    public class TransactionsService : ServiceBase<Transactions>
    {
        public TransactionsService(IRepositoryBase<Transactions> repo, IServiceProvider serviceProvider) : base(repo, serviceProvider)
        {
        }

        //TODO: 更多业务方法可以写到这里
        public async Task<IEnumerable<TransactionsDto>> GetTransactionsList(int PageIndex, int PageSize)
        {
            List<TransactionsDto> selectListItems = null;
            List<Transactions> transactions = (await GetFullListAsync(_ => true).ConfigureAwait(false)).OrderByDescending(_ => _.AddTime).ToList();
            selectListItems = this.Mapper.Map<List<TransactionsDto>>(transactions);
            return selectListItems;
        }

        public async Task CreateOrUpdateAsync(TransactionsDto dto)
        {
            Transactions transactions;
            if (String.IsNullOrEmpty(dto.Id))
            {
                transactions = new Transactions(dto);
            }
            else
            {
                transactions = await GetObjectAsync(_ => _.Id == dto.Id);
                transactions.Update(dto);
            }
            await SaveObjectAsync(transactions);
        }

        #region 接口
        public async Task<object> ApiGetListAsync(string userId,int pageIndex,int pageSize)
        {
            var seh = new SenparcExpressionHelper<Models.DatabaseModel.Transactions>();
            seh.ValueCompare.AndAlso(!string.IsNullOrEmpty(userId), _ => _.UserId.Equals(userId));
            var where = seh.BuildWhereExpression();
            var transList = await GetObjectListAsync(pageIndex, pageSize, where, "AddTime Desc");
            var response = transList.Select(_ => new
            {
                _.Id,
                _.OrderNum,
                _.Status,
                _.Quota,
                _.Method
            });
            return response;
        }
        #endregion

    }

}
