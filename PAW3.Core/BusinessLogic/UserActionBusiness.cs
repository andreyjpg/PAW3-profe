using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using PAW3.Data.Models;
using PAW3.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAW3.Core.BusinessLogic;

public interface IUserActionBusiness
{
    /// <summary>
    /// Deletes the UserAction associated with the UserAction id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<bool> DeleteUserActionAsync(int id);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<IEnumerable<UserAction>> GetUserActions(int? id);
    /// <summary>
    /// update and edit a UserAction information
    /// </summary>
    /// <param name="userAction"></param>
    /// <returns></returns>
    Task<bool> UpsertUserActionAsync(UserAction userAction);
}

public class UserActionBusiness(IRepositoryUserAction repositoryUserAction) : IUserActionBusiness
{
    /// </inheritdoc>
    public async Task<bool> UpsertUserActionAsync(UserAction userAction)
    {
        return await repositoryUserAction.CheckBeforeSavingAsync(userAction);
    }

    /// </inheritdoc>
    public async Task<bool> DeleteUserActionAsync(int id)
    {
        var UserAction = await repositoryUserAction.FindAsync(id);
        return await repositoryUserAction.DeleteAsync(UserAction);
    }

    /// </inheritdoc>
    public async Task<IEnumerable<UserAction>> GetUserActions(int? id)
    {
        return id == null
            ? await repositoryUserAction.ReadAsync()
            : [await repositoryUserAction.FindAsync((int)id)];
    }
}

