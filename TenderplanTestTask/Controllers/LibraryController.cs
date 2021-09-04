using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TenderplanTestTask.Data;
using TenderplanTestTask.Model;

namespace TenderplanTestTask.Controllers
{
    [Route("api/[controller]")]
    public class LibraryController : Controller
    {
        private readonly IRepository _repository;

        public LibraryController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public ActionResult<Book> AddOrUpdateBook(Book newBook)
        {
            _repository.CreateOrUpdate(newBook);
            return Ok();
        }

        [Route("{id}")]
        [HttpGet]
        public Book GetBookInfo(int id)
        {
            return _repository.GetInfo(id);
        }

        [HttpDelete]
        public ActionResult DeleteBook(int id)
        {
            if (_repository.DeleteBook(id))
            {
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