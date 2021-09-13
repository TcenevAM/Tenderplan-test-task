using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using AuthenticationAPI.Models;
using AuthOptions;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace AuthenticationAPI.Helper
{
    public class TokenHelper : ITokenHelper
    {
        private IOptions<AuthenticateOptions> _authOptions;

        public TokenHelper(IOptions<AuthenticateOptions> authOptions)
        {
            _authOptions = authOptions;
        }
        public string GenerateJwt(Account user)
        {
            var authParams = _authOptions.Value;
            var securityKey = authParams.GetSymmetricSecurityKey(authParams.SecurityKey);
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
            var securityKey = authParams.GetSymmetricSecurityKey(authParams.RefreshKey);
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            
            var token = new JwtSecurityToken(expires: DateTime.Now.AddDays(authParams.RefreshKeyLifeTime),
                signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public bool IsRefreshTokenValid(string refreshToken)
        {
            try
            {
                var authParams = _authOptions.Value;
                var tokenHandler = new JwtSecurityTokenHandler();
                var validationParameters = new TokenValidationParameters()
                {
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    ValidateLifetime = true,
                    IssuerSigningKey = authParams.GetSymmetricSecurityKey(authParams.RefreshKey)
                };

                tokenHandler.ValidateToken(refreshToken, validationParameters, out _);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}