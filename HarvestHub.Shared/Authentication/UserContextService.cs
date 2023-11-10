using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace HarvestHub.Shared.Authentication
{
    internal class UserContextService : IUserContextService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserContextService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public Guid? GetUserId
        {
            get
            {
                var sub = _httpContextAccessor?.HttpContext?.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
                if (sub == null) return null;
                var isValid = Guid.TryParse(sub.Value, out var subId);
                if (isValid) return subId;
                return null;
            }
        }
    }
}
