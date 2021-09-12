using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TenderplanTestTask.Dtos
{
    public class BookCreateDto
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public List<string> Genres { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int TotalPages { get; set; }
    }
}