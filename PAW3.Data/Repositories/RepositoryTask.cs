using Microsoft.EntityFrameworkCore;
using PAW3.Data.Models;
using Task = PAW3.Data.Models.Task;


namespace PAW3.Data.Repositories;
public interface IRepositoryTask
{
    Task<bool> UpsertAsync(Task entity, bool isUpdating);
    Task<bool> CreateAsync(Task entity);
    Task<bool> DeleteAsync(Task entity);
    Task<IEnumerable<Task>> ReadAsync();
    Task<Task> FindAsync(int id);
    Task<bool> UpdateAsync(Task entity);
    Task<bool> UpdateManyAsync(IEnumerable<Task> entities);
    Task<bool> ExistsAsync(Task entity);
    Task<bool> CheckBeforeSavingAsync(Task entity);

}

public class RepositoryTask : RepositoryBase<Task>, IRepositoryTask
{
    public async Task<bool> CheckBeforeSavingAsync(Task entity)
    {
        var exists = await ExistsAsync(entity);
        return await UpsertAsync(entity, exists);
    }

    public async new Task<bool> ExistsAsync(Task entity)
    {
        return await DbContext.Tasks.AnyAsync(x => x.Id == entity.Id);
    }
}