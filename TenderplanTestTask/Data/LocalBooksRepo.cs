using System.Collections.Generic;
using System.Linq;
using TenderplanTestTask.Model;

namespace TenderplanTestTask.Data
{
    public class LocalRepo : IRepository
    {
        private readonly List<Book> _books = new List<Book>()
        {
            new Book()
            {
                Author = "r",
                Genres = new List<string>()
                {
                    "q"
                },
                Id = 0,
                Title = "qwe",
                TotalPages = 159,
                Description = ""
            },
            new Book()
            {
                Author = "t",
                Genres = new List<string>()
                {
                    "w"
                },
                Id = 1,
                Title = "qwer",
                TotalPages = 159,
                Description = ""
            },
            new Book()
            {
                Author = "y",
                Genres = new List<string>()
                {
                    "e"
                },
                Id = 2,
                Title = "qwert",
                TotalPages = 159,
                Description = ""
            }
        };

        public void CreateOrUpdate(Book newBook)
        {
            if (_books.Exists(book => book.Id == newBook.Id))
            {
                var oldBookIndex = _books.IndexOf(_books.Find(book => book.Id == newBook.Id));
                _books[oldBookIndex] = newBook;
                return;
            }
            _books.Add(newBook);
        }

        public Book GetInfo(int id)
        {
            return _books.Find(book => book.Id == id);
        }

        public bool DeleteBook(int id)
        {
            return _books.Remove(_books.Find(book => book.Id == id));
        }

        public IEnumerable<Book> GetBooksByGenre(string genre)
        {
            return _books.Where(book => book.Genres.Contains(genre));
        }
    }
}