using FarmerAPI.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace FarmerAPI.Service
{
    public interface ITokenService
    {
        Task<string> GenerateToken(User user);
        string GenerateRefreshToken();
        Task GenerateToken(IdentityUser user);
    }
}
