namespace BookStore.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        public string UserSession { get; set; } = string.Empty;
        public Book Book { get; set; } = new Book();
        public int Quantity { get; set; }
    }
}
