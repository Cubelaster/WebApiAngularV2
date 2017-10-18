using DAL.Models.IdentityClasses;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BL.Security.SecurityContracts
{
    public interface IJwtFactory
    {
        Task<string> GenerateEncodedToken(List<Claim> userClaims);
        ClaimsIdentity GenerateClaimsIdentity(ApplicationUser user);

        Task<List<Claim>> GetJWTClaims(ApplicationUser user);
    }
}
