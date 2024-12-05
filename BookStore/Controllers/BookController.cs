using BookStore.Services; // Add this namespace to resolve the BookService class
using BookStore.Models;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class BookController : Controller
    {
        private readonly BookService _bookService;

        public BookController(BookService bookService)
        {
            _bookService = bookService;
        }

        public IActionResult Index()
        {
            var books = _bookService.GetBooksAsync("fiction").Result; // Call the service to get books
            return View(books); // Pass books to the view
        }

        public IActionResult Details(int id)
        {
            // Assuming you get the book using the id (you might fetch this from the API or database)
            var book = new Book
            {
                VolumeInfo = new VolumeInfo
                {
                    Title = "Sample Book",
                    Authors = new[] { "Sample Author" },
                    Description = "Sample book description.",
                    Language = "English",
                    Price = "19.99",
                    PublishedDate = "2024-01-01",
                    ImageLinks = new ImageLinks
                    {
                        Thumbnail = "https://example.com/sample-image.jpg"
                    }
                }
            };
            return View(book);
        }
    }
}
