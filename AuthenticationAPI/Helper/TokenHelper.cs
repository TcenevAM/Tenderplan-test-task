using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using AuthenticationAPI.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace AuthenticationAPI.Helper
{
    public class TokenHelper : ITokenHelper
    {
        private IOptions<AuthOptions> _authOptions;

        public TokenHelper(IOptions<AuthOptions> authOptions)
        {
            _authOptions = authOptions;
        }
        public string GenerateJwt(Account user)
        {
            var authParams = _authOptions.Value;
            var securityKey = authParams.GetSymmetricSecurityKey();
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, user.Nickname),
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString())
            };

            var token = new JwtSecurityToken(claims: claims,
                expires: DateTime.Now.AddMinutes(authParams.SecurityKeyLifeTime),
                signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string GenerateRefreshToken()
        {
            var authParams = _authOptions.Value;
            var securityKey = authParams.GetSymmetricRefreshKey();
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            
            var token = new JwtSecurityToken(expires: DateTime.Now.AddDays(authParams.RefreshKeyLifeTime),
                signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}