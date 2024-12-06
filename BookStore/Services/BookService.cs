using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using BookStore.Models;

namespace BookStore.Services
{
    public class BookService
    {
        private readonly HttpClient _httpClient;
        private const string ApiBaseUrl = "https://www.googleapis.com/books/v1/volumes";

        public BookService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Fetch books from Google Books API using a query
        public async Task<IEnumerable<Book>> GetBooksAsync(string query)
        {
            try
            {
                // Construct API URL
                var response = await _httpClient.GetAsync($"{ApiBaseUrl}?q={query}&maxResults=40&key=AIzaSyCaDcaeUQGjJRj7P6_6w8gE1fnNSZ_qGAA");
                response.EnsureSuccessStatusCode();

                // Deserialize JSON response
                var content = await response.Content.ReadAsStringAsync();
                var apiResponse = JsonSerializer.Deserialize<GoogleBooksResponse>(content, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                var books = new List<Book>();

                // Populate books list
                if (apiResponse?.Items != null)
                {
                    foreach (var item in apiResponse.Items)
                    {
                        books.Add(new Book
                        {
                            Id = item.Id,
                            VolumeInfo = new VolumeInfo
                            {
                                Title = item.VolumeInfo.Title,
                                Authors = item.VolumeInfo.Authors ?? Array.Empty<string>(),
                                PublishedDate = item.VolumeInfo.PublishedDate,
                                Description = item.VolumeInfo.Description ?? "No description available.",
                                Price = item.SaleInfo?.ListPrice?.Amount ?? 0m, // Assign decimal price
                                ImageLinks = item.VolumeInfo.ImageLinks
                            },
                            SaleInfo = item.SaleInfo
                        });
                    }
                }

                return books;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching books: {ex.Message}");
                return new List<Book>();
            }
        }
    }

    // Response and Data Models for Google Books API
    public class GoogleBooksResponse
    {
        public List<GoogleBook> Items { get; set; }
    }

    public class GoogleBook
    {
        public string Id { get; set; }
        public VolumeInfo VolumeInfo { get; set; }
        public SaleInfo SaleInfo { get; set; }
    }
}
