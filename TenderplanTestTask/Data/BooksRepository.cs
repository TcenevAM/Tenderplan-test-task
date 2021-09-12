using System;
using System.Collections.Generic;
using System.Linq;
using TenderplanTestTask.Model;

namespace TenderplanTestTask.Data
{
    public class BooksRepository : IBookRepository
    {
        private readonly Context _context;
        public BooksRepository(Context context)
        {
            _context = context;
        }
        
        public void CreateBook(Book newBook)
        {
            _context.Books.Add(newBook);
        }

        public bool UpdateBook(Book newBook)
        {
            if (!_context.Books.Any()) return false;
            var oldBook = _context.Books.Find(newBook);
            if (oldBook == null) return false;
            oldBook = newBook;
            _context.Books.Update(oldBook);
            return true;
        }

        public Book GetInfo(int bookId)
        {
            var book = _context.Books.Find(bookId);
            if (book == null)
                throw new ArgumentException("Такой книги не существует", "bookId");
            return book;
        }

        public bool DeleteBook(int bookId)
        {
            var bookToDelete = _context.Books.Find(bookId);
            if (bookToDelete == null) return false;
            _context.Books.Remove(bookToDelete);
            return true;
        }

        public IEnumerable<Book> GetBooksByGenre(string genre)
        {
            return _context.Books.Where(book => book.Genres.Contains(genre));
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }


    }
}