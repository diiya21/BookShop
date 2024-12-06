namespace BookStore.Models
{
    public class Book
    {
        public string Id { get; set; } // Unique book ID
        public VolumeInfo VolumeInfo { get; set; } // Book details
        public SaleInfo SaleInfo { get; set; } // Sale details (e.g., price)
    }

    public class SaleInfo
    {
        public ListPrice ListPrice { get; set; } // Price details
    }

    public class ListPrice
    {
        public decimal Amount { get; set; } // Price amount
        public string CurrencyCode { get; set; } // Currency code
    }
    public class VolumeInfo
    {
        public string Title { get; set; } // Title of the book
        public string Subtitle { get; set; } // Subtitle of the book
        public string[] Authors { get; set; } // List of authors
        public string PublishedDate { get; set; } // Publication date
        public string Description { get; set; } // Book description
        public ImageLinks ImageLinks { get; set; } // Images related to the book

        public decimal Price { get; set; } // Book description
    }

    public class ImageLinks
    {
        public string Thumbnail { get; set; } // URL of the thumbnail image
    }

}
