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
    public class CategoryService : ServiceBase<Category>
    {
        public CategoryService(IRepositoryBase<Category> repo, IServiceProvider serviceProvider) : base(repo, serviceProvider)
        {
        }

        //TODO: 更多业务方法可以写到这里
        public async Task<IEnumerable<CategoryDto>> GetCategoryList(int PageIndex, int PageSize)
        {
            List<CategoryDto> selectListItems = null;
            List<Category> category = (await GetFullListAsync(_ => true).ConfigureAwait(false)).OrderByDescending(_ => _.AddTime).ToList();
            selectListItems = this.Mapper.Map<List<CategoryDto>>(category);
            return selectListItems;
        }

        public async Task CreateOrUpdateAsync(CategoryDto dto)
        {
            Category category;
            if (String.IsNullOrEmpty(dto.Id))
            {
                category = new Category(dto);
            }
            else
            {
                category = await GetObjectAsync(_ => _.Id == dto.Id);
                category.Update(dto);
            }
            await SaveObjectAsync(category);
        }

    }

}
