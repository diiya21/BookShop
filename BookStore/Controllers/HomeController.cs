using BookStore.Services;
using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
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

        public async Task<IActionResult> Index(string query = "fiction")
        {
            var books = await _bookService.GetBooksAsync(query);
            ViewData["SearchQuery"] = query;
            return View(books);
        }

        public async Task<IActionResult> Details(string id)
        {
            var books = await _bookService.GetBooksAsync("fiction");
            var book = books.FirstOrDefault(b => b.Id == id);

            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }
    }
}

