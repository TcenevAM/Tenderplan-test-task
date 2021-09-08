using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace AuthenticationAPI
{
    public class AuthOptions
    {
        public string SecurityKey { get; set; }
        public string RefreshKey { get; set; }
        public int SecurityKeyLifeTime { get; set; }
        public int RefreshKeyLifeTime { get; set; }
        public SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SecurityKey));
        }
        public SymmetricSecurityKey GetSymmetricRefreshKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(RefreshKey));
        }
    }
}