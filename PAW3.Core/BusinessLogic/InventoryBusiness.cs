using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using PAW3.Data.Models;
using PAW3.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAW3.Core.BusinessLogic;

public interface IInventoryBusiness
{
    /// <summary>
    /// Deletes the inventories associated with the inventory id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<bool> DeleteInventoryAsync(int id);
    /// <summary>
    /// get list of inventories 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<IEnumerable<Inventory>> GetInventorys(int? id);
    /// <summary>
    /// update a inventory information
    /// </summary>
    /// <param name="product"></param>
    /// <returns></returns>
    Task<bool> UpsertInventoryAsync(Inventory product);
}

public class InventoryBusiness(IRepositoryInventory repositoryInventory) : IInventoryBusiness
{
    /// </inheritdoc>
    public async Task<bool> UpsertInventoryAsync(Inventory inventory)
    {
        return await repositoryInventory.CheckBeforeSavingAsync(inventory);
    }

    /// </inheritdoc>
    public async Task<bool> DeleteInventoryAsync(int id)
    {
        var inventory = await repositoryInventory.FindAsync(id);
        return await repositoryInventory.DeleteAsync(inventory);
    }

    /// </inheritdoc>
    public async Task<IEnumerable<Inventory>> GetInventorys(int? id)
    {
        return id == null
            ? await repositoryInventory.ReadAsync()
            : [await repositoryInventory.FindAsync((int)id)];
    }
}

