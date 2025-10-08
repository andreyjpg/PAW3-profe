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
    /// Deletes the Inventory associated with the Inventory id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<bool> DeleteInventoryAsync(int id);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<IEnumerable<Inventory>> GetInventorys(int? id);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="Inventory"></param>
    /// <returns></returns>
    Task<bool> SaveInventoryAsync(Inventory Inventory);
}

public class InventoryBusiness(IRepositoryInventory repositoryInventory) : IInventoryBusiness
{
    /// </inheritdoc>
    public async Task<bool> SaveInventoryAsync(Inventory Inventory)
    {
        // que tengan mas de 5 quantity
        // sabado o domingo solo puedo salvar de 8 a 12
        return await repositoryInventory.UpdateAsync(Inventory);
    }

    /// </inheritdoc>
    public async Task<bool> DeleteInventoryAsync(int id)
    {
        var Inventory = await repositoryInventory.FindAsync(id);
        return await repositoryInventory.DeleteAsync(Inventory);
    }

    /// </inheritdoc>
    public async Task<IEnumerable<Inventory>> GetInventorys(int? id)
    {
        return id == null
            ? await repositoryInventory.ReadAsync()
            : [await repositoryInventory.FindAsync((int)id)];
    }
}

