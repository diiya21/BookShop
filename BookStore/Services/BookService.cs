using BookStore.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace BookStore.Services
{
    public class BookService
    {
        private readonly HttpClient _httpClient;

        public BookService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Book[]> GetBooksAsync(string query)
        {
            var apiUrl = $"https://www.googleapis.com/books/v1/volumes?q={query}&maxResults=40"; // API URL
            var response = await _httpClient.GetStringAsync(apiUrl); // Get data from API
            var booksResponse = JsonConvert.DeserializeObject<GoogleBooksResponse>(response); // Deserialize JSON response

            return booksResponse.Items; // Return list of books
        }
    }

    public class GoogleBooksResponse
    {
        public Book[] Items { get; set; }
    }
}
