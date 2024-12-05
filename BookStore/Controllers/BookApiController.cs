using Microsoft.AspNetCore.Mvc;
using BookStore.Models;
using System.Collections.Generic;
using System.Linq; // Required for LINQ methods
using System.Threading.Tasks; // For async methods
using BookStore.Services;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookApiController : ControllerBase
    {
        private readonly BookService _bookService;

        public BookApiController(BookService bookService)
        {
            _bookService = bookService;
        }

        // GET api/bookapi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> Get()
        {
            var books = await _bookService.GetBooksAsync("fiction"); // Fetch books asynchronously

            if (books == null || !books.Any())  // Check if the list is null or empty
            {
                return NotFound(); // Return 404 if no books are found
            }

            return Ok(books); // Return 200 OK with the list of books
        }

        // GET api/bookapi/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> Get(string id)  // Change 'id' to string
        {
            var books = await _bookService.GetBooksAsync("fiction"); // Fetch books asynchronously

            // Use LINQ to find the book with the matching ID (now comparing strings)
            var book = books.FirstOrDefault(b => b.Id == id); // Find the book by ID

            if (book == null)
            {
                return NotFound(); // Return 404 if no book is found with the given ID
            }

            return Ok(book); // Return 200 OK with the book details
        }
    }
}
