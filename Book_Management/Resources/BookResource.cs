using System.ComponentModel.DataAnnotations;

namespace Book_Management.Resources
{
    public class BookResource
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int CategoryId { get; set; }
    }
}
