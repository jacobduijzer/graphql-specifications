using Bookstore.Api.Books;

namespace Bookstore.Api;

public class Queries(BookCatalogService books, IdentityService identity)
{
    [UseFiltering]
    public IQueryable<Book> Books() => books.Books();

    public LoginPayload Login(string email, string password)
    {
       var token = identity.Login(email, password);
       return new LoginPayload(token);
    }
}