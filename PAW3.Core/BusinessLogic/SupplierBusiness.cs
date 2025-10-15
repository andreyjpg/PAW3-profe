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
    /// update and edit a Supplier information
    /// </summary>
    /// <param name="supplier"></param>
    /// <returns></returns>
    Task<bool> UpsertSupplierAsync(Supplier supplier);
}

public class SupplierBusiness(IRepositorySupplier repositorySupplier) : ISupplierBusiness
{
    /// </inheritdoc>
    public async Task<bool> UpsertSupplierAsync(Supplier supplier)
    {
        return await repositorySupplier.CheckBeforeSavingAsync(supplier);
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

