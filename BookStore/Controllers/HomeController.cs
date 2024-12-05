using Microsoft.AspNetCore.Mvc;
using BookStore.Models;
using BookStore.Services;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly BookService _bookService;

        public HomeController(BookService bookService)
        {
            _bookService = bookService;
        }

        // Fetch books based on the search query and display them
        public async Task<IActionResult> Index(string query = "fiction") // Default search query: 'fiction'
        {
            var books = await _bookService.GetBooksAsync(query); // Get books using the service

            return View(books); // Pass books data as IEnumerable<BookStore.Models.Book>
        }

        // Example of a Details action to display individual book info
        public IActionResult Details(int id)
        {
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

            return View(book); // Return single book view
        }
    }
}
