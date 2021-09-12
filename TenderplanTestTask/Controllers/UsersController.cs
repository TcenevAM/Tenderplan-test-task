using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TenderplanTestTask.Data;
using TenderplanTestTask.Dtos;
using TenderplanTestTask.Model;

namespace TenderplanTestTask.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;
        private int UserId => int.Parse(User.Claims.Single(c => c.Type == ClaimTypes.NameIdentifier).Value);

        public UsersController(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [Authorize]
        [HttpPost("{userId:int}/books/add")]
        public ActionResult AddBookToUser(int bookId)
        {
            try
            {
                _repository.AddBookToUser(UserId, bookId);
                _repository.SaveChanges();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        [HttpGet("{userId:int}/books")]
        public ActionResult GetUserBooks(int userId)
        {
            var books = _repository.GetUserBooks(userId);
            if (books != null)
            {
                var q = _mapper.Map<BookReadDto>(books.ToList()[0]);
                return Ok(_mapper.Map<List<BookReadDto>>(books));
            }
            return BadRequest();
        }

        [HttpPost("register")]
        public ActionResult AddNewUser(UserCreateDto newUser)
        {
            try
            {
                _repository.RegisterNewUser(_mapper.Map<User>(newUser));
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