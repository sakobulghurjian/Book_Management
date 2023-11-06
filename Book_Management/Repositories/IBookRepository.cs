using Book_Management.Models.ViewModels;

namespace Book_Management.Repositories
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> ListAsync();
        Task AddAsync(Book book);

    }
}