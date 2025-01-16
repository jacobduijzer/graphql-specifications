﻿namespace Bookstore.Api;

public class BookCatalogService
{
    public IEnumerable<Book> Books() => _books;
    
    private IEnumerable<Book> _books = new List<Book>
    {
        new Book(Guid.NewGuid(), "The Great Gatsby", "9780743273565", "F. Scott Fitzgerald" ),
        new Book(Guid.NewGuid(), "1984", "9780451524935", "George Orwell" ),
        new Book(Guid.NewGuid(), "To Kill a Mockingbird", "9780061120084", "Harper Lee" )
    };
}