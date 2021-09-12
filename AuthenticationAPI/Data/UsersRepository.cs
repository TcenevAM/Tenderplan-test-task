using System;
using System.Linq;
using AuthenticationAPI.Helper;
using AuthenticationAPI.Models;

namespace AuthenticationAPI.Data
{
    public class UsersRepository : IRepository
    {
        private readonly Context _context;
        public UsersRepository(Context context)
        {
            _context = context;
        }
        
        public Account AuthenticateUser(string nickname, string password)
        {
            return _context.Users.ToList().SingleOrDefault(u => u.Nickname == nickname && u.Password == password);
        }

        public void SetRefreshToken(int id, string refreshToken)
        {
            var acc = _context.Users.Find(id);
            if (acc != null)
            {
                acc.RefreshToken = refreshToken;
            }
        }

        public Account AuthenticateUser(string refreshToken)
        {
            return _context.Users.ToList().SingleOrDefault(u => u.RefreshToken == refreshToken);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}