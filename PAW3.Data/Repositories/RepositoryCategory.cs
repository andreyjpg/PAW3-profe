using PAW3.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace PAW3.Data.Repositories;

public interface IRepositoryCategory
{
    Task<bool> UpsertAsync(Category entity, bool isUpdating);
    Task<bool> CreateAsync(Category entity);
    Task<bool> DeleteAsync(Category entity);
    Task<IEnumerable<Category>> ReadAsync();
    Task<Category> FindAsync(int id);
    Task<bool> UpdateAsync(Category entity);
    Task<bool> UpdateManyAsync(IEnumerable<Category> entities);
    Task<bool> ExistsAsync(Category entity);
    Task<bool> CheckBeforeSavingAsync(Category entity);

}

public class RepositoryCategory : RepositoryBase<Category>, IRepositoryCategory
{
    public async Task<bool> CheckBeforeSavingAsync(Category entity)
    {
        var exists = await ExistsAsync(entity);
        return await UpsertAsync(entity, exists);
    }

    public async new Task<bool> ExistsAsync(Category entity)
    {
        return await DbContext.Categories.AnyAsync(x => x.CategoryId == entity.CategoryId);
    }
}
