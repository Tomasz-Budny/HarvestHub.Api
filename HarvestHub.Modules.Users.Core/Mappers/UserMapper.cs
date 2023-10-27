using HarvestHub.Modules.Users.Core.Dtos;
using HarvestHub.Modules.Users.Dal.Entity;

namespace HarvestHub.Modules.Users.Core.Mappers
{
    internal static class UserMapper
    {
        public static UserDto MapToDto(User user)
        {
            return new UserDto(user.Id, user.FirstName, user.LastName, user.Email);
        }
    }
}
