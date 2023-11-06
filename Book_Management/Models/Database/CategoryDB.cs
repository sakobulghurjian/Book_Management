using System.ComponentModel.DataAnnotations;

namespace Book_Management.Models.Database
{
    public class CategoryDB
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
    }
}
