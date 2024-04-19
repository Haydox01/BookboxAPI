using Microsoft.AspNetCore.Identity;

namespace Bookbox.Repositories.Interfaces
{
    public interface ITokenRepository
    {
        string CreateJWTToken(IdentityUser user, List<string> roles);
    }
}
