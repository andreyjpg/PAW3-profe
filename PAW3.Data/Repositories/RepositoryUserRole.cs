using Microsoft.EntityFrameworkCore;
using PAW3.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAW3.Data.Repositories;

public interface IRepositoryUserRole
{
    Task<bool> UpsertAsync(UserRole entity, bool isUpdating);
    Task<bool> CreateAsync(UserRole entity);
    Task<bool> DeleteAsync(UserRole entity);
    Task<IEnumerable<UserRole>> ReadAsync();
    Task<UserRole> FindAsync(int id);
    Task<bool> UpdateAsync(UserRole entity);
    Task<bool> UpdateManyAsync(IEnumerable<UserRole> entities);
    Task<bool> ExistsAsync(UserRole entity);
    Task<bool> CheckBeforeSavingAsync(UserRole entity);

}

public class RepositoryUserRole : RepositoryBase<UserRole>, IRepositoryUserRole
{
    public async Task<bool> CheckBeforeSavingAsync(UserRole entity)
    {
        var exists = await ExistsAsync(entity);
        return await UpsertAsync(entity, exists);
    }

    public async new Task<bool> ExistsAsync(UserRole entity)
    {
        return await DbContext.UserRoles.AnyAsync(x => x.Id == entity.Id);
    }
}