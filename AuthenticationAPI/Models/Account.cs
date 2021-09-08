namespace AuthenticationAPI.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string Nickname { get; set; }
        public string Password { get; set; }
        public string RefreshToken { get; set; }
    }
}