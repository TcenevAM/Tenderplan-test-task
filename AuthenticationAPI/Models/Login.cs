using System.ComponentModel.DataAnnotations;

namespace AuthenticationAPI.Models
{
    public class Login
    {
        [Required]
        public string Nickname { get; set; }
        [Required]
        public string Password { get; set; }
    }
}