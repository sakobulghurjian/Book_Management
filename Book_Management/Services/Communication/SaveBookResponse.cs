using Book_Management.Models.ViewModels;

namespace Book_Management.Services.Communication
{
    public class SaveBookResponse : BaseResponse
    {
        public Book Book { get; private set; }

        private SaveBookResponse(bool success, string message, Book book) : base(success, message)
        {
            Book = book;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="category">Saved category.</param>
        /// <returns>Response.</returns>
        public SaveBookResponse(Book book) : this(true, string.Empty, book)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public SaveBookResponse(string message) : this(false, message, null)
        { }
    }
}
