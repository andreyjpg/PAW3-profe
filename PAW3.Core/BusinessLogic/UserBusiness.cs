using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using PAW3.Data.Models;
using PAW3.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAW3.Core.BusinessLogic;

public interface IUserBusiness
{
    /// <summary>
    /// Deletes the User associated with the User id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<bool> DeleteUserAsync(int id);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<IEnumerable<User>> GetUsers(int? id);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="User"></param>
    /// <returns></returns>
    Task<bool> SaveUserAsync(User User);
}

public class UserBusiness(IRepositoryUser repositoryUser) : IUserBusiness
{
    /// </inheritdoc>
    public async Task<bool> SaveUserAsync(User User)
    {
        // que tengan mas de 5 quantity
        // sabado o domingo solo puedo salvar de 8 a 12
        return await repositoryUser.UpdateAsync(User);
    }

    /// </inheritdoc>
    public async Task<bool> DeleteUserAsync(int id)
    {
        var User = await repositoryUser.FindAsync(id);
        return await repositoryUser.DeleteAsync(User);
    }

    /// </inheritdoc>
    public async Task<IEnumerable<User>> GetUsers(int? id)
    {
        return id == null
            ? await repositoryUser.ReadAsync()
            : [await repositoryUser.FindAsync((int)id)];
    }
}

