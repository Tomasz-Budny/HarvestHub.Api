using HarvestHub.Modules.Users.Core.Dtos;

namespace HarvestHub.Modules.Users.Core.Services
{
    public interface IUserService
    {
        Task<Guid> CreateAsync(CreateUserDto dto);
        Task<UserDto> GetByEmail(string email);
        Task Verify(Guid verificationToken);
        Task<string> Login(LoginUserDto dto);
        Task ForgetPassword(string email);

    }
}
