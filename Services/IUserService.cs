using System.Security.Claims;
using TeamY.Domain;

namespace TeamY.Services
{
    public interface IUserService
    {
        User Current(ClaimsPrincipal user);
    }
}