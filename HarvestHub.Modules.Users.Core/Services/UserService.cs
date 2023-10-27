using HarvestHub.Modules.Users.Core.Dtos;
using HarvestHub.Modules.Users.Dal.Persistance;

namespace HarvestHub.Modules.Users.Core.Services
{
    internal sealed class UserService : IUserService
    {
        private readonly UsersDbContext _dbContext;
        public UserService(UsersDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task CreateAsync(CreateUserDto dto)
        {
           throw new NotImplementedException();
        }

        public Task<UserDto> GetByEmail(string Email)
        {
            throw new NotImplementedException();
        }
    }
}
