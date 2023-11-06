using System.ComponentModel.DataAnnotations;

namespace Book_Management.Resources
{
    public class SaveCategoryResource
    {
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
    }
}
