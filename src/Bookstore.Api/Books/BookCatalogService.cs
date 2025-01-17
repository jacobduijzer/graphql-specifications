namespace Bookstore.Api.Books;

public class BookCatalogService
{
    public IQueryable<Book> Books() => _books.AsQueryable();

    public Book AddBook(BookInput bookInput)
    {
        var book = new Book(Guid.NewGuid(), bookInput.Title, bookInput.Author, bookInput.Isbn);
        _books.Add(book);
        return book;
    }

    private List<Book> _books = new List<Book>
    {
        new Book(Guid.NewGuid(), "The Great Gatsby", "F. Scott Fitzgerald", "9780743273565"),
        new Book(Guid.NewGuid(), "1984", "George Orwell", "9780451524935"),
        new Book(Guid.NewGuid(), "To Kill a Mockingbird", "Harper Lee", "9780061120084")
    };
}