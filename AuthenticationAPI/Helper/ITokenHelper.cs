using AuthenticationAPI.Models;

namespace AuthenticationAPI.Helper
{
    public interface ITokenHelper
    {
        string GenerateJwt(Account user);
        string GenerateRefreshToken();
        bool IsRefreshTokenValid(string refreshToken);
    }
}