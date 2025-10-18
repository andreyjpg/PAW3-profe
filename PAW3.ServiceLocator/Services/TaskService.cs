using PAW3.Architecture;
using PAW3.Architecture.Providers;
using PAW3.Models.DTOs;
using PAW3.ServiceLocator.Services.Base;

namespace PAW3.ServiceLocator.Services;

public class TaskService : BaseService<TaskDTO>
{
    public TaskService(IConfiguration configuration)
        : base(configuration, "Task") { }
}
