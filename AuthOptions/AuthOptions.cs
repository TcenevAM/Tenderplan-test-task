using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace AuthOptions
{
    public class AuthenticateOptions
    {
        public string SecurityKey { get; set; }
        public string RefreshKey { get; set; }
        public int SecurityKeyLifeTime { get; set; }
        public int RefreshKeyLifeTime { get; set; }
        public SymmetricSecurityKey GetSymmetricSecurityKey(string secretKey)
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey));
        }
    }
}