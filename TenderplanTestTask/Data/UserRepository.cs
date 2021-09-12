using System;
using System.Collections.Generic;
using System.Linq;
using TenderplanTestTask.Model;

namespace TenderplanTestTask.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly Context _context;
        public UserRepository(Context context)
        {
            _context = context;
        }
        public void AddBookToUser(int userId, int bookId)
        {
            var book = _context.Books.Find(bookId);
            var user = _context.Users.Find(userId);
            
            if (book == null)
                throw new ArgumentException("Книги с таким Id не существует", nameof(bookId));
            if (user == null)
                throw new ArgumentException("Пользователя с таким Id не существует", nameof(userId));
            if (user.Books.Contains(book))
                throw new ArgumentException("У пользователя уже есть такая книга", nameof(bookId));

            user.Books.Add(book);
        }

        public IEnumerable<Book> GetUserBooks(int userId)
        {
            var user = _context.Users.Find(userId);
            if (user == null)
                throw new ArgumentException("Пользователя с таким Id не существует", "userId");
            
            _context.Entry(user).Collection(u => u.Books).Load();

            return user.Books;
        }

        public void RegisterNewUser(User newUser)
        {
            if (_context.Users.FirstOrDefault(u => u.Nickname == newUser.Nickname) != null)
            {
                throw new ArgumentException("Пользователь с таким nickname-ом уже существует", "newUser");
            }
            _context.Users.Add(newUser);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}