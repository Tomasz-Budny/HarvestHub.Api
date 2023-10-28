using EmailValidation;
using HarvestHub.Modules.Users.Core.Dtos;
using HarvestHub.Modules.Users.Core.Exceptions;
using HarvestHub.Modules.Users.Core.Mappers;
using HarvestHub.Modules.Users.Dal.Authentication;
using HarvestHub.Modules.Users.Dal.Entity;
using HarvestHub.Modules.Users.Dal.Persistance;
using HarvestHub.Modules.Users.Shared.Events;
using HarvestHub.Shared.Messaging;
using Microsoft.EntityFrameworkCore;

namespace HarvestHub.Modules.Users.Core.Services
{
    internal sealed class UserService : IUserService
    {
        private readonly UsersDbContext _dbContext;
        private readonly IMessageBroker _messageBroker;
        private readonly IHashingService _hashingService;
        private readonly IJwtTokenGenerator _jwt;
        public UserService(UsersDbContext dbContext, IHashingService hashingService, IJwtTokenGenerator jwt, IMessageBroker messageBroker)
        {
            _dbContext = dbContext;
            _hashingService = hashingService;
            _jwt = jwt;
            _messageBroker = messageBroker;
        }

        public async Task<Guid> CreateAsync(CreateUserDto dto)
        {
            if (!EmailValidator.Validate(dto.Email))
            {
                throw new UserEmailInvalidException(dto.Email);
            }

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

            _dbContext.Add(user);
            await _dbContext.SaveChangesAsync();

            await _messageBroker.PublishAsync(new UserCreated(user.Id, user.FirstName, user.LastName, user.Email, user.VerificationToken));

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
                throw new UserNotFoundException();
            }

            return UserMapper.MapToDto(user);
        }

        public async Task Verify(Guid verificationToken)
        {
            var user = await _dbContext.Users.SingleOrDefaultAsync(user => user.VerificationToken == verificationToken);

            if(user == null)
            {
                throw new UserNotFoundException();
            }

            if(user.VerifiedAt is not null)
            {
                throw new UserAlreadyVerifiedException();
            }

            user.VerifiedAt = DateTime.Now;

            await _dbContext.SaveChangesAsync();
        }

        public async Task<string> Login(LoginUserDto dto)
        {
            if (!EmailValidator.Validate(dto.Email))
            {
                throw new UserEmailInvalidException(dto.Email);
            }

            var user = await _dbContext.Users.SingleOrDefaultAsync(user => user.Email == dto.Email);

            if (user is null)
            {
                throw new UserNotFoundException();
            }

            if(user.VerifiedAt is null)
            {
                throw new UserNotVerifiedException();
            }

            var passwordIsValid = _hashingService.ValidatePassword(dto.Password, user.PasswordHash, user.PasswordSalt);
            if(!passwordIsValid) 
            {
                throw new UserPasswordInvalidException();
            }

            var token = _jwt.GenerateToken(user.Id);
            return token;
        }
    }
}
