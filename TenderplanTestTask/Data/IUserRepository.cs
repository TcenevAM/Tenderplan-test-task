using System.Collections.Generic;
using TenderplanTestTask.Model;

namespace TenderplanTestTask.Data
{
    public interface IUserRepository
    {
        void AddBookToUser(int userId, int bookId);
        IEnumerable<Book> GetUserBooks(int userId);
        void RegisterNewUser(User newUser);
        void SaveChanges();
    }
}