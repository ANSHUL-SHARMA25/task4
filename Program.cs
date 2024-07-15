// Create a builder for configuring the application.
var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllers();
// Build the application.
var app = builder.Build();
// Configure the HTTP request pipeline to use authorization
app.UseAuthorization();
// Map controller endpoints.
app.MapControllers();
// Run the application, listening on port 5500 on all network interfaces.
app.Run("http://localhost:8080");
