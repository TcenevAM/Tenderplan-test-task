using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TenderplanTestTask.Data;
using TenderplanTestTask.Model;

namespace TenderplanTestTask.Controllers
{
    [Route("api/[controller]")]
    public class LibraryController : Controller
    {
        private readonly IBookRepository _repository;

        public LibraryController(IBookRepository repository)
        {
            _repository = repository;
        }

        [Route("books/update")]
        [HttpPost]
        public ActionResult<Book> AddBook(Book newBook)
        {
            _repository.CreateBook(newBook);
            _repository.SaveChanges();
            return Ok();
        }
        
        [Route("books/add")]
        [HttpPost]
        public ActionResult<Book> UpdateBook(Book newBook)
        {
            if (!_repository.UpdateBook(newBook)) return BadRequest();
            _repository.SaveChanges();
            return Ok();
        }

        [Route("books/{id:int}")]
        [HttpGet]
        public ActionResult<Book> GetBookInfo(int id)
        {
            try
            {
                var book = _repository.GetInfo(id);
                return Ok(book);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        public ActionResult DeleteBook(int id)
        {
            if (_repository.DeleteBook(id))
            {
                _repository.SaveChanges();
                return Ok();
            }

            return BadRequest();
        }

        [Route("find/{genre}")]
        [HttpGet]
        public IEnumerable<Book> GetBooksByGenre(string genre)
        {
            return _repository.GetBooksByGenre(genre);
        }
    }
}