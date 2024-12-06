using Microsoft.AspNetCore.Mvc;
using BookStore.Models;
using BookStore.Services;
using System.Threading.Tasks;
using System.Linq;

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
        public IActionResult Details(string id)
        {
            var books = _bookService.GetBooksAsync("fiction").Result; // Fetch books asynchronously
            var book = books.FirstOrDefault(b => b.Id == id); // Find the book by ID

            if (book == null)
            {
                return NotFound(); // Return 404 if no book is found with the given ID
            }

            return View(book); // Return single book view
        }
    }
}
