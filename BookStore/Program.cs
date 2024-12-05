// Ensure these using statements are at the top of your file
using Microsoft.EntityFrameworkCore;
using BookStore.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using BookStore.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Register the BookService to fetch books from Google Books API
builder.Services.AddHttpClient<BookService>(); // Add BookService for API calls

// Add session support
builder.Services.AddSession();

// Add Swagger services (optional)
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();

    // Enable Swagger for development
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BookStore API v1"));
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseStaticFiles();  // For serving static files (like images, CSS)
app.UseSession();      // Enables session support
app.UseRouting();      // Enables routing for your app

app.UseAuthorization(); // Handles authorization if necessary

// Define the default route for the application
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
