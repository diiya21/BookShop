using Microsoft.AspNetCore.Mvc;
using BookStore.Models;
using System.Linq;

namespace BookStore.Controllers
{
    public class CartController : Controller
    {
        private readonly BookShopDBContext _context;

        // Inject BookShopDBContext into the controller
        public CartController(BookShopDBContext context)
        {
            _context = context;
        }

        // GET: Cart
        public IActionResult Index()
        {
            var cartItems = _context.CartItems.ToList();  // Get cart items from the database
            return View(cartItems);  // Pass cart items to the view
        }

        // POST: Add book to cart
        [HttpPost]
        public IActionResult AddToCart(string bookId)  // Change bookId to string
        {
            var book = _context.Books.FirstOrDefault(b => b.Id == bookId);  // Fetch book from the database
            if (book == null) return NotFound();  // Return 404 if the book is not found

            var cartItem = new CartItem
            {
                Book = book, // Set the book to the cart item
                Quantity = 1  // Default quantity
            };

            _context.CartItems.Add(cartItem);  // Add cart item to the database
            _context.SaveChanges();  // Save changes to the database

            return RedirectToAction("Index", "Cart");  // Redirect to the cart view
        }
    }
}
