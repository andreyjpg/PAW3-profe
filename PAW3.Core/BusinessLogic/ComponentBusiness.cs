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
    /// Deletes the product associated with the product id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<bool> DeleteComponentAsync(int id);
    /// <summary>
    /// get list of products 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<IEnumerable<Component>> GetComponents(int? id);
    /// <summary>
    /// update a product information
    /// </summary>
    /// <param name="product"></param>
    /// <returns></returns>
    Task<bool> UpsertComponentAsync(Component product);
}

public class ComponentBusiness(IRepositoryComponent repositoryComponent) : IComponentBusiness
{
    /// </inheritdoc>
    public async Task<bool> UpsertComponentAsync(Component product)
    {
        return await repositoryComponent.CheckBeforeSavingAsync(product);
    }

    /// </inheritdoc>
    public async Task<bool> DeleteComponentAsync(int id)
    {
        var product = await repositoryComponent.FindAsync(id);
        return await repositoryComponent.DeleteAsync(product);
    }

    /// </inheritdoc>
    public async Task<IEnumerable<Component>> GetComponents(int? id)
    {
        return id == null
            ? await repositoryComponent.ReadAsync()
            : [await repositoryComponent.FindAsync((int)id)];
    }
}

