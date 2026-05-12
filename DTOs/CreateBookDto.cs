using System.ComponentModel.DataAnnotations;

namespace pr11.DTOs
{
    public class CreateBookDto
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public int AuthorId { get; set; }
    }
}