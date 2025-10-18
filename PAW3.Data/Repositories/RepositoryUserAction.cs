using Microsoft.EntityFrameworkCore;
using PAW3.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAW3.Data.Repositories;

public interface IRepositoryUserAction
{
    Task<bool> UpsertAsync(UserAction entity, bool isUpdating);
    Task<bool> CreateAsync(UserAction entity);
    Task<bool> DeleteAsync(UserAction entity);
    Task<IEnumerable<UserAction>> ReadAsync();
    Task<UserAction> FindAsync(int id);
    Task<bool> UpdateAsync(UserAction entity);
    Task<bool> UpdateManyAsync(IEnumerable<UserAction> entities);
    Task<bool> ExistsAsync(UserAction entity);
    Task<bool> CheckBeforeSavingAsync(UserAction entity);

}

public class RepositoryUserAction : RepositoryBase<UserAction>, IRepositoryUserAction
{
    public async Task<bool> CheckBeforeSavingAsync(UserAction entity)
    {
        var exists = await ExistsAsync(entity);
        return await UpsertAsync(entity, exists);
    }

    public async new Task<bool> ExistsAsync(UserAction entity)
    {
        return await DbContext.UserActions.AnyAsync(x => x.Id == entity.Id);
    }
}