using Bookstore.Api;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<BookCatalogService>();

builder.AddGraphQL()
    .AddQueryType<Queries>();

var app = builder.Build();
app.MapGraphQL();
app.Run();

public partial class Program { }