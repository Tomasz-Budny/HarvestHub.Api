using EmailValidation;
using HarvestHub.Modules.Users.Core.Dtos;
using HarvestHub.Modules.Users.Core.Exceptions;
using HarvestHub.Modules.Users.Core.Mappers;
using HarvestHub.Modules.Users.Dal.Entity;
using HarvestHub.Modules.Users.Dal.Persistance;
using Microsoft.EntityFrameworkCore;

namespace HarvestHub.Modules.Users.Core.Services
{
    internal sealed class UserService : IUserService
    {
        private readonly UsersDbContext _dbContext;
        private readonly IHashingService _hashingService;
        public UserService(UsersDbContext dbContext, IHashingService hashingService)
        {
            _dbContext = dbContext;
            _hashingService = hashingService;
        }

        public async Task<Guid> CreateAsync(CreateUserDto dto)
        {
            if (await _dbContext.Users.AnyAsync(user => user.Email == dto.Email))
            {
                throw new UserAlreadyExistsException(dto.Email);
            }

            var userId = Guid.NewGuid();
            (var passwordhash, var passwordSalt) = _hashingService.CreatePasswordHash(dto.Password);
            var user = new User(
                userId,
                dto.FirstName,
                dto.LastName,
                dto.Email,
                DateTime.Now,
                null,
                passwordhash,
                passwordSalt,
                Guid.NewGuid(),
                null,
                null);

            await _dbContext.SaveChangesAsync();

            return userId;
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
