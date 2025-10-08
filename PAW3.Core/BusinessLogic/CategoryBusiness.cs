using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using PAW3.Data.Models;
using PAW3.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAW3.Core.BusinessLogic;

public interface ICategoryBusiness
{
    /// <summary>
    /// Deletes the Category associated with the Category id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<bool> DeleteCategoryAsync(int id);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<IEnumerable<Category>> GetCategorys(int? id);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="Category"></param>
    /// <returns></returns>
    Task<bool> SaveCategoryAsync(Category Category);
}

public class CategoryBusiness(IRepositoryCategory repositoryCategory) : ICategoryBusiness
{
    /// </inheritdoc>
    public async Task<bool> SaveCategoryAsync(Category Category)
    {
        // que tengan mas de 5 quantity
        // sabado o domingo solo puedo salvar de 8 a 12
        return await repositoryCategory.UpdateAsync(Category);
    }

    /// </inheritdoc>
    public async Task<bool> DeleteCategoryAsync(int id)
    {
        var Category = await repositoryCategory.FindAsync(id);
        return await repositoryCategory.DeleteAsync(Category);
    }

    /// </inheritdoc>
    public async Task<IEnumerable<Category>> GetCategorys(int? id)
    {
        return id == null
            ? await repositoryCategory.ReadAsync()
            : [await repositoryCategory.FindAsync((int)id)];
    }
}

