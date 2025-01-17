using Bookstore.Api.Books;
using HotChocolate.Authorization;

namespace Bookstore.Api;


[Authorize(Roles = ["BookstoreOwner"])]
public class Mutations(BookCatalogService books)
{
    public Book AddBook(BookInput bookInput)
    {
        var book = books.AddBook(bookInput);
        return book;
    }
    
   
}