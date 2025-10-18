using PAW3.Architecture;
using PAW3.Architecture.Providers;
using PAW3.Models.DTOs;
using PAW3.ServiceLocator.Services.Base;

namespace PAW3.ServiceLocator.Services;

public class UserService : BaseService<UserDTO>
{
    public UserService(IConfiguration configuration)
        : base(configuration, "User") { }
}
