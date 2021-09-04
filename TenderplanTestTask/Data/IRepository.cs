using System.Collections.Generic;
using TenderplanTestTask.Model;

namespace TenderplanTestTask.Data
{
    public interface IRepository
    {
        void CreateOrUpdate(Book newBook);
        Book GetInfo(int id);
        bool DeleteBook(int id);
        IEnumerable<Book> GetBooksByGenre(string genre);
    }
}