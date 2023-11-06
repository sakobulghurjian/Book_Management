using Book_Management.Models.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace Book_Management.Resources
{
    public class SaveBookResource
    {
        [Required]
        [MaxLength(20)]
        public string Title { get; set; }
        [Required]
        [MaxLength(20)]
        public string Author { get; set; }
        public int CategoryId { get; set; }
        [Required]
        public IFormFile PdfFile { get; set; }
    }
}
