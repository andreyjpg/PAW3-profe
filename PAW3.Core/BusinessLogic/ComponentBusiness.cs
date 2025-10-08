using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using PAW3.Data.Models;
using PAW3.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAW3.Core.BusinessLogic;

public interface IComponentBusiness
{
    /// <summary>
    /// Deletes the Component associated with the Component id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<bool> DeleteComponentAsync(int id);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<IEnumerable<Component>> GetComponents(int? id);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="Component"></param>
    /// <returns></returns>
    Task<bool> SaveComponentAsync(Component Component);
}

public class ComponentBusiness(IRepositoryComponent repositoryComponent) : IComponentBusiness
{
    /// </inheritdoc>
    public async Task<bool> SaveComponentAsync(Component Component)
    {
        // que tengan mas de 5 quantity
        // sabado o domingo solo puedo salvar de 8 a 12
        return await repositoryComponent.UpdateAsync(Component);
    }

    /// </inheritdoc>
    public async Task<bool> DeleteComponentAsync(int id)
    {
        var Component = await repositoryComponent.FindAsync(id);
        return await repositoryComponent.DeleteAsync(Component);
    }

    /// </inheritdoc>
    public async Task<IEnumerable<Component>> GetComponents(int? id)
    {
        return id == null
            ? await repositoryComponent.ReadAsync()
            : [await repositoryComponent.FindAsync((int)id)];
    }
}

