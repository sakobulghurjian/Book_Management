using System.ComponentModel.DataAnnotations;

namespace Book_Management.Models.Database
{
    public class BookDB
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string Title { get; set; }
        [Required]
        [MaxLength(20)]
        public string Author { get; set; }
        public string Content { get; set; }
        public int CategoryId { get; set; }
    }
}
