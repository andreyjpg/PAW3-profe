using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using PAW3.Data.Models;
using PAW3.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAW3.Core.BusinessLogic;

public interface ISupplierBusiness
{
    /// <summary>
    /// Deletes the Supplier associated with the Supplier id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<bool> DeleteSupplierAsync(int id);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<IEnumerable<Supplier>> GetSuppliers(int? id);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="Supplier"></param>
    /// <returns></returns>
    Task<bool> SaveSupplierAsync(Supplier Supplier);
}

public class SupplierBusiness(IRepositorySupplier repositorySupplier) : ISupplierBusiness
{
    /// </inheritdoc>
    public async Task<bool> SaveSupplierAsync(Supplier Supplier)
    {
        // que tengan mas de 5 quantity
        // sabado o domingo solo puedo salvar de 8 a 12
        return await repositorySupplier.UpdateAsync(Supplier);
    }

    /// </inheritdoc>
    public async Task<bool> DeleteSupplierAsync(int id)
    {
        var Supplier = await repositorySupplier.FindAsync(id);
        return await repositorySupplier.DeleteAsync(Supplier);
    }

    /// </inheritdoc>
    public async Task<IEnumerable<Supplier>> GetSuppliers(int? id)
    {
        return id == null
            ? await repositorySupplier.ReadAsync()
            : [await repositorySupplier.FindAsync((int)id)];
    }
}

