using System.Collections.Generic;

namespace TenderplanTestTask.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Nickname { get; set; }
        public List<Book> Books { get; set; }
    }
}