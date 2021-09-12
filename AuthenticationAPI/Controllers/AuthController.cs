using System;
using AuthenticationAPI.Data;
using AuthenticationAPI.Helper;
using AuthenticationAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationAPI.Controllers
{
    public class AuthController : Controller
    {
        private readonly IRepository _repository;
        private readonly ITokenHelper _tokenHelper;
        
        public AuthController(IRepository repository, ITokenHelper tokenHelper)
        {
            _repository = repository;
            _tokenHelper = tokenHelper;
        }
        
        [HttpPost("authenticate")]
        public ActionResult Login([FromBody]Login user)
        {
            var account = _repository.AuthenticateUser(user.Nickname, user.Password);
            if (account == null) return Unauthorized();
            var jwt = _tokenHelper.GenerateJwt(account);
            var rt = _tokenHelper.GenerateRefreshToken();
            _repository.SetRefreshToken(account.Id, rt);
            _repository.SaveChanges();
            return Ok(new
            {
                access_token = jwt,
                refresh_token = rt
            });

        }
        
        [HttpPost("refresh")]
        public ActionResult Refresh(string refreshToken)
        {
            var account = _repository.AuthenticateUser(refreshToken);
            if (account == null) return Unauthorized();
            var jwt = _tokenHelper.GenerateJwt(account);
            var rt = _tokenHelper.GenerateRefreshToken();
            _repository.SetRefreshToken(account.Id, rt);
            _repository.SaveChanges();
            return Ok(new
            {
                access_token = jwt,
                refresh_token = rt
            });
        }
    }
}