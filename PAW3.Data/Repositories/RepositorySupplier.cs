using Microsoft.EntityFrameworkCore;
using PAW3.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAW3.Data.Repositories;

public interface IRepositorySupplier
{
    Task<bool> UpsertAsync(Supplier entity, bool isUpdating);
    Task<bool> CreateAsync(Supplier entity);
    Task<bool> DeleteAsync(Supplier entity);
    Task<IEnumerable<Supplier>> ReadAsync();
    Task<Supplier> FindAsync(int id);
    Task<bool> UpdateAsync(Supplier entity);
    Task<bool> UpdateManyAsync(IEnumerable<Supplier> entities);
    Task<bool> ExistsAsync(Supplier entity);
    Task<bool> CheckBeforeSavingAsync(Supplier entity);

}

public class RepositorySupplier : RepositoryBase<Supplier>, IRepositorySupplier
{
    public async Task<bool> CheckBeforeSavingAsync(Supplier entity)
    {
        var exists = await ExistsAsync(entity);
        return await UpsertAsync(entity, exists);
    }

    public async new Task<bool> ExistsAsync(Supplier entity)
    {
        return await DbContext.Suppliers.AnyAsync(x => x.SupplierId == entity.SupplierId);
    }
}