using Book_Management.Models.ViewModels;
using Book_Management.Services.Communication;

namespace Book_Management.Services
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> ListAsync();
        Task<SaveBookResponse> SaveAsync(Book book);
    }
}
