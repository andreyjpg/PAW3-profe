using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using PAW3.Data.Models;
using PAW3.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAW3.Core.BusinessLogic;

public interface IUserRoleBusiness
{
    /// <summary>
    /// Deletes the UserRole associated with the UserRole id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<bool> DeleteUserRoleAsync(int id);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<IEnumerable<UserRole>> GetUserRoles(int? id);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="UserRole"></param>
    /// <returns></returns>
    Task<bool> SaveUserRoleAsync(UserRole UserRole);
}

public class UserRoleBusiness(IRepositoryUserRole repositoryUserRole) : IUserRoleBusiness
{
    /// </inheritdoc>
    public async Task<bool> SaveUserRoleAsync(UserRole UserRole)
    {
        // que tengan mas de 5 quantity
        // sabado o domingo solo puedo salvar de 8 a 12
        return await repositoryUserRole.UpdateAsync(UserRole);
    }

    /// </inheritdoc>
    public async Task<bool> DeleteUserRoleAsync(int id)
    {
        var UserRole = await repositoryUserRole.FindAsync(id);
        return await repositoryUserRole.DeleteAsync(UserRole);
    }

    /// </inheritdoc>
    public async Task<IEnumerable<UserRole>> GetUserRoles(int? id)
    {
        return id == null
            ? await repositoryUserRole.ReadAsync()
            : [await repositoryUserRole.FindAsync((int)id)];
    }
}

