using System.Collections.Generic;
using TenderplanTestTask.Model;

namespace TenderplanTestTask.Data
{
    public interface IBookRepository
    {
        void CreateBook(Book newBook);
        bool UpdateBook(Book newBook);
        Book GetInfo(int bookId);
        bool DeleteBook(int bookId);
        IEnumerable<Book> GetBooksByGenre(string genre);
        void SaveChanges();
    }
}