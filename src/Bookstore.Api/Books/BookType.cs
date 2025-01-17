using Bookstore.Api.Stock;

namespace Bookstore.Api.Books;

public class BookType : ObjectType<Book>
{
    protected override void Configure(IObjectTypeDescriptor<Book> descriptor)
    {
        descriptor
            .Field("stock")
            .Resolve(resolver =>
            {
                var book = resolver.Parent<Book>();
                var stock = resolver.Services.GetRequiredService<IStockService>();
                return stock.ForBook(book.Id);
            });
    }
}