namespace BookStore.Models
{
    public class CartItem
    {
        public Book Book { get; set; } // Reference to the book in the cart
        public int Quantity { get; set; } // Quantity of the book in the cart
    }
}
