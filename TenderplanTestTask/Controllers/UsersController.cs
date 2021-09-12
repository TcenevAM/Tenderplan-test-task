using System;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TenderplanTestTask.Data;
using TenderplanTestTask.Model;

namespace TenderplanTestTask.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly IUserRepository _repository;
        private int UserId => int.Parse(User.Claims.Single(c => c.Type == ClaimTypes.NameIdentifier).Value);

        public UsersController(IUserRepository repository)
        {
            _repository = repository;
        }

        [Route("{userId:int}/books/add")]
        [Authorize]
        [HttpPost]
        public ActionResult AddBookToUser(int userId, int bookId)
        {
            if (userId != UserId) return Unauthorized();
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
        public ActionResult GetUserBooks()
        {
            var books = _repository.GetUserBooks(UserId);
            if (books != null)
            {
                return Ok(_repository.GetUserBooks(UserId));   
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