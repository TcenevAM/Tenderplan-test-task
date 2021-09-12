using System;
using Microsoft.AspNetCore.Mvc;
using TenderplanTestTask.Data;
using TenderplanTestTask.Model;

namespace TenderplanTestTask.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly IUserRepository _repository;

        public UsersController(IUserRepository repository)
        {
            _repository = repository;
        }

        [Route("{userId:int}/books/add")]
        [HttpPost]
        public ActionResult AddBookToUser(int userId, int bookId)
        {
            try
            {
                _repository.AddBookToUser(userId, bookId);
                _repository.SaveChanges();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Route("{userId:int}/books")]
        [HttpGet]
        public ActionResult GetUserBooks(int userId)
        {
            var books = _repository.GetUserBooks(userId);
            if (books != null)
            {
                return Ok(_repository.GetUserBooks(userId));   
            }
            return BadRequest();
        }

        [HttpPost]
        public ActionResult AddNewUser(User newUser)
        {
            try
            {
                _repository.AddUser(newUser);
                _repository.SaveChanges();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}