using AuthenticationAPI.Models;

namespace AuthenticationAPI.Data
{
    public interface IRepository
    {
        Account AuthenticateUser(string nickname, string password);
        void SetRefreshToken(int id, string refreshToken);
        public Account AuthenticateUser(string refreshToken);
    }
}