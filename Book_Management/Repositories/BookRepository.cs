using Book_Management.Models.Database;
using Book_Management.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Book_Management.Repositories
{
    public class BookRepository : BaseRepository, IBookRepository
    {
        public BookRepository(AppDBContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Book>> ListAsync()
        {
            List<BookDB> books = await _context.Books.ToListAsync();
            List<Book> bookVM = new List<Book>();

            foreach (var book in books)
            {
                bookVM.Add(new Book
                {
                    Id = book.Id,
                    Author = book.Author,
                    Content = book.Content,
                    Title = book.Title,
                    CategoryId = book.CategoryId
                });
            }
            return bookVM;
        }
        public async Task AddAsync(Book book)
        {
            BookDB bookDB = new BookDB
            {
                Title = book.Title,
                Author = book.Author,
                Content = book.Content,
                CategoryId = book.CategoryId
            };
            await _context.Books.AddAsync(bookDB);
            _context.SaveChanges();
        }
    }
}