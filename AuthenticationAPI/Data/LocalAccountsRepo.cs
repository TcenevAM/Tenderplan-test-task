using System.Collections.Generic;
using System.Linq;
using AuthenticationAPI.Models;

namespace AuthenticationAPI.Data
{
    public class LocalAccountsRepo : IRepository
    {
        private List<Account> _accounts = new List<Account>()
        {
            new Account()
            {
                Id = 0,
                Nickname = "Qwerty",
                Password = "Qwerty123",
                RefreshToken = ""
            },
            new Account()
            {
                Id = 1,
                Nickname = "ytrewq",
                Password = "123321",
                RefreshToken = ""
            }
        };

        public Account AuthenticateUser(string nickname, string password)
        {
            return _accounts.SingleOrDefault(u => u.Nickname == nickname && u.Password == password);
        }
        
        public Account AuthenticateUser(string refreshToken)
        {
            return _accounts.SingleOrDefault(u => u.RefreshToken == refreshToken);
        }

        public void SetRefreshToken(int id, string refreshToken)
        {
            var acc = _accounts.Find(u => u.Id == id);
            if (acc != null)
            {
                acc.RefreshToken = refreshToken;
            }
        }
    }
}