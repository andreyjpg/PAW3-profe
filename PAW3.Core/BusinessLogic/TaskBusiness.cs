using PAW3.Data.Models;

using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using TaskModel = PAW3.Data.Models.Task;
using PAW3.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAW3.Core.BusinessLogic;

public interface ITaskBusiness
{
    /// <summary>
    /// Deletes the Task associated with the Task id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<bool> DeleteTaskAsync(int id);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<IEnumerable<TaskModel>> GetTasks(int? id);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="Task"></param>
    /// <returns></returns>
    Task<bool> SaveTaskAsync(TaskModel Task);
}

public class TaskBusiness(IRepositoryTask repositoryTask) : ITaskBusiness
{
    /// </inheritdoc>
    public async Task<bool> SaveTaskAsync(TaskModel Task)
    {
        // que tengan mas de 5 quantity
        // sabado o domingo solo puedo salvar de 8 a 12
        return await repositoryTask.UpdateAsync(Task);
    }

    /// </inheritdoc>
    public async Task<bool> DeleteTaskAsync(int id)
    {
        var Task = await repositoryTask.FindAsync(id);
        return await repositoryTask.DeleteAsync(Task);
    }

    /// </inheritdoc>
    public async Task<IEnumerable<TaskModel>> GetTasks(int? id)
    {
        return id == null
            ? await repositoryTask.ReadAsync()
            : [await repositoryTask.FindAsync((int)id)];
    }
}

