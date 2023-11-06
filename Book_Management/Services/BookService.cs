using Book_Management.Models.ViewModels;
using Book_Management.Repositories;
using Book_Management.Resources;
using Book_Management.Services.Communication;

namespace Book_Management.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            this._bookRepository = bookRepository;
        }

        public async Task<IEnumerable<Book>> ListAsync()
        {
            // Validate

            return await _bookRepository.ListAsync();
        }
        public async Task<SaveBookResponse> SaveAsync(Book book)
        {
            try
            {
                await _bookRepository.AddAsync(book);

                return new SaveBookResponse(book);
            }
            catch (Exception ex)
            {
                return new SaveBookResponse($"An error occurred when saving the category: {ex.Message}");
            }
        }
    }
}
