using Microsoft.AspNetCore.Mvc;
using BookStore.Models;
using System.Linq;

namespace BookStore.Controllers
{
    public class CartController : Controller
    {
        private readonly BookShopDBContext _context;

        public CartController(BookShopDBContext context)
        {
            _context = context;
        }

        // POST: Add book to cart
        [HttpPost]
        public IActionResult AddToCart(string bookId, int quantity)
        {
            var book = _context.Books.FirstOrDefault(b => b.Id == bookId); // Fetch book by ID
            if (book == null) return NotFound(); // Return 404 if the book is not found

            var cartItem = new CartItem
            {
                Book = book,
                Quantity = quantity
            };

            _context.CartItems.Add(cartItem); // Add to cart
            _context.SaveChanges(); // Save changes

            return RedirectToAction("Index", "Cart"); // Redirect to cart
        }
    }
}
