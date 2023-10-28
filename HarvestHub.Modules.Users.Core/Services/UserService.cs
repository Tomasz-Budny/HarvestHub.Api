using EmailValidation;
using HarvestHub.Modules.Users.Core.Dtos;
using HarvestHub.Modules.Users.Core.Exceptions;
using HarvestHub.Modules.Users.Core.Mappers;
using HarvestHub.Modules.Users.Dal.Authentication;
using HarvestHub.Modules.Users.Dal.Authentication.Options;
using HarvestHub.Modules.Users.Dal.Entity;
using HarvestHub.Modules.Users.Dal.Persistance;
using HarvestHub.Modules.Users.Shared.Events;
using HarvestHub.Shared.Messaging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace HarvestHub.Modules.Users.Core.Services
{
    internal sealed class UserService : IUserService
    {
        private readonly UsersDbContext _dbContext;
        private readonly IMessageBroker _messageBroker;
        private readonly IHashingService _hashingService;
        private readonly IJwtTokenGenerator _jwt;
        private readonly UsersOptions _usersOptions;
        public UserService(UsersDbContext dbContext, IHashingService hashingService, IJwtTokenGenerator jwt, 
            IMessageBroker messageBroker, IOptions<UsersOptions> usersOptions)
        {
            _dbContext = dbContext;
            _hashingService = hashingService;
            _jwt = jwt;
            _messageBroker = messageBroker;
            _usersOptions = usersOptions.Value;
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

        public async Task ForgetPassword(string email)
        {
            if (!EmailValidator.Validate(email))
            {
                throw new UserEmailInvalidException(email);
            }

            var user = await _dbContext.Users.SingleOrDefaultAsync(user => user.Email == email);

            if (user is null)
            {
                throw new UserNotFoundException();
            }

            var passwordResetToken = Guid.NewGuid();
            user.PasswordResetToken = passwordResetToken;
            user.ResetTokenExpires = DateTime.Now.Add(_usersOptions.PasswordResetTokenExpiry);

            await _dbContext.SaveChangesAsync();
            await _messageBroker.PublishAsync(new ForgetPassword(user.Email, user.FirstName, passwordResetToken));
        }

        public async Task ChangePassword(ChangePasswordDto dto)
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

            if(user.PasswordResetToken != dto.ResetPasswordToken)
            {
                throw new UserPasswordResetTokenInvalidException();
            }

            if(DateTime.Now > user.ResetTokenExpires)
            {
                throw new UserPasswordResetTokenExpiresException();
            }

            if(_hashingService.ValidatePassword(dto.NewPassword, user.PasswordHash, user.PasswordSalt))
            {
                throw new NewPasswordSameAsOldException();
            }

            (var passwordhash, var passwordSalt) = _hashingService.CreatePasswordHash(dto.NewPassword);

            user.PasswordHash = passwordhash;
            user.PasswordSalt = passwordSalt;

            user.PasswordResetToken = null;
            user.ResetTokenExpires = null;
            await _dbContext.SaveChangesAsync();
        }
    }
}
