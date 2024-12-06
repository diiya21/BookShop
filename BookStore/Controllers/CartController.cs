using Microsoft.AspNetCore.Mvc;
using BookStore.Models;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Controllers
{
    public class CartController : Controller
    {
        private static List<CartItem> CartItems = new List<CartItem>(); // In-memory cart storage

        // Display the Cart Page
        public IActionResult Index()
        {
            // Calculate the total price of the cart
            decimal totalPrice = CartItems.Sum(item => (item.Book.SaleInfo?.ListPrice?.Amount ?? 0) * item.Quantity);

            // Pass total price and items to the view
            ViewBag.TotalPrice = totalPrice.ToString("F2");
            ViewBag.CartItems = CartItems; // Pass CartItems explicitly if needed
            return View(CartItems);
        }

        // Add a Book to the Cart or Update Quantity
        [HttpPost]
        public IActionResult AddToCart(string bookId, string title, decimal? price)
        {
            if (string.IsNullOrEmpty(bookId) || string.IsNullOrEmpty(title))
                return RedirectToAction("Index", "Home");

            var cartItem = CartItems.FirstOrDefault(item => item.Book.Id == bookId);

            if (cartItem != null)
            {
                // Increment quantity if the book already exists
                cartItem.Quantity++;
            }
            else
            {
                // Add a new book to the cart
                CartItems.Add(new CartItem
                {
                    Book = new Book
                    {
                        Id = bookId,
                        VolumeInfo = new VolumeInfo { Title = title },
                        SaleInfo = new SaleInfo
                        {
                            ListPrice = price.HasValue ? new ListPrice { Amount = price.Value } : null
                        }
                    },
                    Quantity = 1
                });
            }

            return RedirectToAction("Index");
        }

        // Increment Quantity
        [HttpPost]
        public IActionResult IncrementQuantity(string bookId)
        {
            // Find the book in the cart
            var cartItem = CartItems.FirstOrDefault(item => item.Book.Id == bookId);
            if (cartItem != null)
            {
                // Increment the quantity
                cartItem.Quantity++;
            }
            return RedirectToAction("Index");
        }

        // Decrement Quantity
        [HttpPost]
        public IActionResult DecrementQuantity(string bookId)
        {
            // Find the book in the cart
            var cartItem = CartItems.FirstOrDefault(item => item.Book.Id == bookId);
            if (cartItem != null)
            {
                // Decrement the quantity
                cartItem.Quantity--;
                // Remove the item if quantity is 0
                if (cartItem.Quantity <= 0)
                {
                    CartItems.Remove(cartItem);
                }
            }
            return RedirectToAction("Index");
        }

        // Checkout and Clear the Cart
        [HttpPost]
        public IActionResult Checkout()
        {
            // Clear the cart
            CartItems.Clear();
            TempData["Message"] = "Thank you for your purchase!";

            // Return to Index (Cart page)
            return RedirectToAction("Index");
        }

        // Reset the Cart (optional method for debugging or development)
        public IActionResult ResetCart()
        {
            CartItems.Clear();
            TempData["Message"] = "Cart has been reset.";
            return RedirectToAction("Index");
        }
    }
}

