using FarmerAPI.Domain.Entities;

namespace FarmerAPI.Service
{
    public interface ITokenService
    {
        Task<string> GenerateToken(ApplicationUser user);
        string GenerateRefreshToken();
    }
}
