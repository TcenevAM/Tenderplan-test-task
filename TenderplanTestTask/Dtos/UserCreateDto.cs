using System.ComponentModel.DataAnnotations;

namespace TenderplanTestTask.Dtos
{
    public class UserCreateDto
    {
        [Required]
        public string Nickname { get; set; }
        [Required]
        public string Password { get; set; }
    }
}