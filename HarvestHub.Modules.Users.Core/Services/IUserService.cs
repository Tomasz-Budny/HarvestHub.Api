using HarvestHub.Modules.Users.Core.Dtos;
using HarvestHub.Modules.Users.Dal.Entity;

namespace HarvestHub.Modules.Users.Core.Services
{
    public interface IUserService
    {
        Task CreateAsync(CreateUserDto dto);

        Task<UserDto> GetByEmail(string email);
    }
}
