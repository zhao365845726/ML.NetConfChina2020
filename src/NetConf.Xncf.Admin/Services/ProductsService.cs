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

    }

}
