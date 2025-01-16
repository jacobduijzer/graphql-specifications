namespace Bookstore.Api;

public class Queries(BookCatalogService books)
{
    public IEnumerable<Book> Books() => books.Books();
}