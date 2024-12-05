using System.Net.Http;
using System.Threading.Tasks;
using BookStore.Models;
using Newtonsoft.Json;

namespace BookStore.Services
{
    public class BookService
    {
        private readonly HttpClient _httpClient;

        public BookService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Fetch books from Google Books API using a query
        public async Task<Book[]> GetBooksAsync(string query)
        {
            string apiUrl = $"https://www.googleapis.com/books/v1/volumes?q={query}&maxResults=40"; // API URL

            var response = await _httpClient.GetStringAsync(apiUrl); // Get data from API
            var booksResponse = JsonConvert.DeserializeObject<GoogleBooksResponse>(response); // Deserialize JSON response

            return booksResponse.Items; // Return the books
        }
    }

    public class GoogleBooksResponse
    {
        public Book[] Items { get; set; }
    }
}
