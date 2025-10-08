using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using PAW3.Data.Models;
using PAW3.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAW3.Core.BusinessLogic;

public interface INotificationBusiness
{
    /// <summary>
    /// Deletes the Notification associated with the Notification id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<bool> DeleteNotificationAsync(int id);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<IEnumerable<Notification>> GetNotifications(int? id);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="Notification"></param>
    /// <returns></returns>
    Task<bool> SaveNotificationAsync(Notification Notification);
}

public class NotificationBusiness(IRepositoryNotification repositoryNotification) : INotificationBusiness
{
    /// </inheritdoc>
    public async Task<bool> SaveNotificationAsync(Notification Notification)
    {
        // que tengan mas de 5 quantity
        // sabado o domingo solo puedo salvar de 8 a 12
        return await repositoryNotification.UpdateAsync(Notification);
    }

    /// </inheritdoc>
    public async Task<bool> DeleteNotificationAsync(int id)
    {
        var Notification = await repositoryNotification.FindAsync(id);
        return await repositoryNotification.DeleteAsync(Notification);
    }

    /// </inheritdoc>
    public async Task<IEnumerable<Notification>> GetNotifications(int? id)
    {
        return id == null
            ? await repositoryNotification.ReadAsync()
            : [await repositoryNotification.FindAsync((int)id)];
    }
}

