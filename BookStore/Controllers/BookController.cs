using BookStore.Services;
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

        // Fetch books based on the search query and display them
        public IActionResult Index(string query = "fiction") // Default search query: 'fiction'
        {
            var books = _bookService.GetBooksAsync(query).Result; // Get books using the service
            ViewData["SearchQuery"] = query; // Save the search query for the search box
            return View(books); // Pass books data as IEnumerable<BookStore.Models.Book>
        }

        // Details page for a specific book
        public IActionResult Details(string id)
        {
            var books = _bookService.GetBooksAsync("fiction").Result;
            var book = books.FirstOrDefault(b => b.Id == id); // Find the book by ID

            if (book == null)
            {
                return NotFound(); // Return 404 if the book is not found
            }

            return View(book); // Return the book details view
        }
    }
}
