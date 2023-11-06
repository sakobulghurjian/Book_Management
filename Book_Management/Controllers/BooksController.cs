using AutoMapper;
using Book_Management.Extensions;
using Book_Management.Models.ViewModels;
using Book_Management.Resources;
using Book_Management.Services;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;
using iText.Kernel.Pdf.Canvas.Parser.Listener;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Reflection.PortableExecutable;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace Book_Management.Controllers
{
    [Route("/api/[controller]")]
    public class BooksController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IMapper _mapper;

        public BooksController(IBookService bookService, IMapper mapper)
        {
            _bookService = bookService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<Book>> GetAllAsync([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var books = await _bookService.ListAsync();
            books.Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToList();

            return books;
        }


        [HttpPost]
        [RequestSizeLimit(5_000_000)]
        public async Task<IActionResult> PostAsync([FromForm] SaveBookResource resource)
        {
            if (!ModelState.IsValid || resource.PdfFile.Length == 0)
                return BadRequest(ModelState.GetErrorMessages());

            var book = _mapper.Map<SaveBookResource, Book>(resource);

            var content = new StringBuilder();

            using (var stream = resource.PdfFile.OpenReadStream())
            {
                using (var pdfDocument = new PdfDocument(new PdfReader(stream)))
                {
                    for (int pageNum = 1; pageNum <= pdfDocument.GetNumberOfPages(); pageNum++)
                    {
                        var page = pdfDocument.GetPage(pageNum);
                        var strategy = new SimpleTextExtractionStrategy();
                        var currentText = PdfTextExtractor.GetTextFromPage(page, strategy);
                        content.AppendLine(currentText);
                    }
                }
            }

            book.Content = content.ToString();
            var result = await _bookService.SaveAsync(book);

            if (!result.Success)
                return BadRequest(result.Message);

            var bookResource = _mapper.Map<Book, BookResource>(result.Book);
            return Ok(bookResource);
        }
    }
}