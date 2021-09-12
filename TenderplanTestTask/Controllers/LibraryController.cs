using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TenderplanTestTask.Data;
using TenderplanTestTask.Dtos;
using TenderplanTestTask.Model;

namespace TenderplanTestTask.Controllers
{
    [Route("api/[controller]")]
    public class LibraryController : Controller
    {
        private readonly IBookRepository _repository;
        private readonly IMapper _mapper;

        public LibraryController(IBookRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPost("books/add")]
        public ActionResult<Book> AddBook(BookCreateDto newBook)
        {
            _repository.CreateBook(_mapper.Map<Book>(newBook));
            _repository.SaveChanges();
            return Ok();
        }
        
        [HttpPost("books/{id}/update")]
        public ActionResult<Book> UpdateBook(Book newBook)
        {
            if (!_repository.UpdateBook(newBook)) return BadRequest();
            _repository.SaveChanges();
            return Ok();
        }

        [HttpGet("books/{id:int}")]
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

        [HttpDelete("{id}")]
        public ActionResult DeleteBook(int id)
        {
            if (_repository.DeleteBook(id))
            {
                _repository.SaveChanges();
                return Ok();
            }

            return BadRequest();
        }

        [HttpGet("find/{genre}")]
        public IEnumerable<Book> GetBooksByGenre(string genre)
        {
            return _repository.GetBooksByGenre(genre);
        }
    }
}