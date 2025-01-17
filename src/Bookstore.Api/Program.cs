using Bookstore.Api;

var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddSingleton<BookCatalogService>()
    .AddSingleton<IdentityService>();

builder.Services.ConfigureAuthentication();
builder.Services.ConfigureAuthorization();

builder.AddGraphQL()
    .AddQueryType<Queries>()
    .AddAuthorization()
    .AddMutationType<Mutations>();

var app = builder.Build();
app.UseAuthentication();
app.UseAuthorization();
app.MapGraphQL();
app.Run();

public partial class Program
{
}