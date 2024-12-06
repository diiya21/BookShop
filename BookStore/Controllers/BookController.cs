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

        public IActionResult Details(string id)
        {
            var books = _bookService.GetBooksAsync("fiction").Result;
            var book = books.FirstOrDefault(b => b.Id == id); // Find the book by ID

            if (book == null)
            {
                return NotFound();
            }

            return View(book); // Pass the book to the view for displaying details
        }
    }
}
