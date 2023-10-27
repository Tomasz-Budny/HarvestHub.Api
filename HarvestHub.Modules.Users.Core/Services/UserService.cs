using EmailValidation;
using HarvestHub.Modules.Users.Core.Dtos;
using HarvestHub.Modules.Users.Core.Exceptions;
using HarvestHub.Modules.Users.Core.Mappers;
using HarvestHub.Modules.Users.Dal.Persistance;
using Microsoft.EntityFrameworkCore;

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

        public async Task<UserDto> GetByEmail(string email)
        {
            if (!EmailValidator.Validate(email))
            {
                throw new UserEmailInvalidException(email);
            }

            var user = await _dbContext.Users.SingleOrDefaultAsync(user => user.Email == email);

            if(user == null)
            {
                throw new UserNotFoundException(email);
            }

            return UserMapper.MapToDto(user);
        }
    }
}
