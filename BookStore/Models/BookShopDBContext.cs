using Microsoft.EntityFrameworkCore;

namespace BookStore.Models
{
    public class BookShopDBContext : DbContext
    {
        public BookShopDBContext(DbContextOptions<BookShopDBContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }
        public DbSet<CartItem> CartItems { get; set; }  // Ensure CartItems is defined
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Optionally define any constraints or additional configurations here
        }
    }
}
