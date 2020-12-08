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
    public class ProductsService : ServiceBase<Products>
    {
        public ProductsService(IRepositoryBase<Products> repo, IServiceProvider serviceProvider) : base(repo, serviceProvider)
        {
        }

        //TODO: 更多业务方法可以写到这里
        public async Task<IEnumerable<ProductsDto>> GetProductsList(int PageIndex, int PageSize)
        {
            List<ProductsDto> selectListItems = null;
            List<Products> products = (await GetFullListAsync(_ => true).ConfigureAwait(false)).OrderByDescending(_ => _.AddTime).ToList();
            selectListItems = this.Mapper.Map<List<ProductsDto>>(products);
            return selectListItems;
        }

        public async Task CreateOrUpdateAsync(ProductsDto dto)
        {
            Products products;
            if (String.IsNullOrEmpty(dto.Id))
            {
                products = new Products(dto);
            }
            else
            {
                products = await GetObjectAsync(_ => _.Id == dto.Id);
                products.Update(dto);
            }
            await SaveObjectAsync(products);
        }

        #region 接口
        public async Task<object> ApiGetListAsync(string categoryId,int pageIndex, int pageSize)
        {
            var seh = new SenparcExpressionHelper<Models.DatabaseModel.Products>();
            seh.ValueCompare.AndAlso(!string.IsNullOrEmpty(categoryId), _ => _.CategoryId.Equals(categoryId));
            var where = seh.BuildWhereExpression();
            List<Products> products = (await base.GetObjectListAsync(pageIndex, pageSize, where, "AddTime Desc")).ToList();
            return products.Select(_ => new
            {
                _.Id,
                _.Name,
                _.Cover,
                _.AddTime,
                _.Price
            });
        }

        public async Task<object> ApiGetDetailAsync(string id)
        {
            var seh = new SenparcExpressionHelper<Models.DatabaseModel.Products>();
            seh.ValueCompare.AndAlso(!string.IsNullOrEmpty(id), _ => _.Id.Equals(id));
            var where = seh.BuildWhereExpression();
            var products = await GetObjectAsync(where);
            return new { 
                products.Id,
                products.Name,
                products.Cover,
                products.Video,
                products.Content,
                products.AddTime,
                products.Price
            };
        }
        #endregion
    }

}
