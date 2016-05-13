using System.Linq;
using System.Security.Claims;
using TeamY.Domain;
using TeamY.Infrastructure;

namespace TeamY.Services
{
    public class UserService : IUserService
    {
        private readonly TeamyDbContext _context;

        public UserService(TeamyDbContext context)
        {
            _context = context;
        }

        public User Current(ClaimsPrincipal user)
        {
            return _context.Users.SingleOrDefault(x => x.Initials == user.Identity.Name);
        }

        
    }
}