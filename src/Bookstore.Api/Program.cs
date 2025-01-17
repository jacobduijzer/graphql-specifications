using Bookstore.Api;
using Bookstore.Api.Books;
using Bookstore.Api.Stock;

var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddSingleton<BookCatalogService>()
    .AddSingleton<IdentityService>()
    .AddSingleton<IStockService, StockService>();

builder.Services.ConfigureAuthentication();
builder.Services.ConfigureAuthorization();

builder.AddGraphQL()
    .AddType<BookType>()
    .AddQueryType<Queries>()
    .AddAuthorization()
    .AddMutationType<Mutations>()
    .AddFiltering();

var app = builder.Build();
app.UseAuthentication();
app.UseAuthorization();
app.MapGraphQL();
app.Run();

public partial class Program
{
}