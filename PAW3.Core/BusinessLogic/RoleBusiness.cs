using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using PAW3.Data.Models;
using PAW3.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAW3.Core.BusinessLogic;

public interface IRoleBusiness
{
    /// <summary>
    /// Deletes the Role associated with the Role id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<bool> DeleteRoleAsync(int id);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<IEnumerable<Role>> GetRoles(int? id);
    /// <summary>
    /// update and edit a Role information
    /// </summary>
    /// <param name="role"></param>
    /// <returns></returns>
    Task<bool> UpsertRoleAsync(Role role);
}

public class RoleBusiness(IRepositoryRole repositoryRole) : IRoleBusiness
{
    /// </inheritdoc>
    public async Task<bool> UpsertRoleAsync(Role role)
    {
        return await repositoryRole.CheckBeforeSavingAsync(role);
    }

    /// </inheritdoc>
    public async Task<bool> DeleteRoleAsync(int id)
    {
        var Role = await repositoryRole.FindAsync(id);
        return await repositoryRole.DeleteAsync(Role);
    }

    /// </inheritdoc>
    public async Task<IEnumerable<Role>> GetRoles(int? id)
    {
        return id == null
            ? await repositoryRole.ReadAsync()
            : [await repositoryRole.FindAsync((int)id)];
    }
}

