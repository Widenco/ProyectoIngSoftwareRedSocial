using AppRedSocial.Models;

namespace AppRedSocial.Services
{
    public interface ITokenService
    {
        string GenerateAccessToken(User user);
        string GenerateRefreshToken();
        string GeneratePasswordResetToken();
    }
}

