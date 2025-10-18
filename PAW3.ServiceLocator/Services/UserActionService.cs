using PAW3.Architecture;
using PAW3.Architecture.Providers;
using PAW3.Models.DTOs;
using PAW3.ServiceLocator.Services.Base;

namespace PAW3.ServiceLocator.Services;

public class UserActionService : BaseService<UserActionDTO>
{
    public UserActionService(IConfiguration configuration)
        : base(configuration, "UserAction") { }
}
