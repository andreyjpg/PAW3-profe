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
    /// get list of Categorys 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<IEnumerable<Category>> GetCategorys(int? id);
    /// <summary>
    /// update and edit a Category information
    /// </summary>
    /// <param name="category"></param>
    /// <returns></returns>
    Task<bool> UpsertCategoryAsync(Category category);
}

public class CategoryBusiness(IRepositoryCategory repositoryCategory) : ICategoryBusiness
{
    /// </inheritdoc>
    public async Task<bool> UpsertCategoryAsync(Category category)
    {
        return await repositoryCategory.CheckBeforeSavingAsync(category);
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

