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
    /// 
    /// </summary>
    /// <param name="Role"></param>
    /// <returns></returns>
    Task<bool> SaveRoleAsync(Role Role);
}

public class RoleBusiness(IRepositoryRole repositoryRole) : IRoleBusiness
{
    /// </inheritdoc>
    public async Task<bool> SaveRoleAsync(Role Role)
    {
        // que tengan mas de 5 quantity
        // sabado o domingo solo puedo salvar de 8 a 12
        return await repositoryRole.UpdateAsync(Role);
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

