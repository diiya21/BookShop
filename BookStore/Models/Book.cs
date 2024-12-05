namespace BookStore.Models
{
    public class Book
    {
        public string Id { get; set; } // Change Id to string
        public VolumeInfo VolumeInfo { get; set; }
    }

    public class VolumeInfo
    {
        public string Title { get; set; }
        public string[] Authors { get; set; }
        public string Description { get; set; }
        public string Language { get; set; }
        public string Publisher { get; set; }
        public string PublishedDate { get; set; }
        public string Price { get; set; }
        public ImageLinks ImageLinks { get; set; }
    }

    public class ImageLinks
    {
        public string Thumbnail { get; set; }
    }
}
