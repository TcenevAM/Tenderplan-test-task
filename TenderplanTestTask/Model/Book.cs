using System.Collections.Generic;

namespace TenderplanTestTask.Model
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public List<string> Genres { get; set; }
        public string Description { get; set; }
        public int TotalPages { get; set; }
    }
}