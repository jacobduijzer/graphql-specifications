using Bookstore.Api.Books;
using Reqnroll;
using StrawberryShake;

namespace Bookstore.Specifications;

[Binding]
public class SearchBooks(CustomWebApplicationFactory factory, ScenarioContext scenarioContext)
    : CustomWebApplicationFactory
{
    private const string BookData = "book-data";
    private const string Books = "books";

    private readonly IBookstoreClient _client = factory.CreateBookstoreClient();

    [Given(@"a customer, searching for books to buy")]
    public void GivenACustomerSearchingForBooksToBuy()
    {
        // DO NOTHING
    }

    [When(@"the customer request the full list of books")]
    public async Task WhenTheCustomerRequestTheFullListOfBooks()
    {
        var bookData = await _client.AllBooks.ExecuteAsync();
        var books = bookData.Data!.Books.Select(b => new Book(b.Id, b.Title, b.Author, b.Isbn));

        scenarioContext.Add(BookData, bookData);
        scenarioContext.Add(Books, books);
    }

    [When(@"the customer is searching for books that contain ""(.*)""")]
    public async Task WhenTheCustomerIsSearchingForBooksThatContain(string search)
    {
        var bookData = await _client.BooksByTitle.ExecuteAsync(search);
        var books = bookData.Data!.Books.Select(b => new Book(b.Id, b.Title, b.Author, b.Isbn));
        
        scenarioContext.Add(BookData, bookData);
        scenarioContext.Add(Books, books);
    }

    [Then(@"the customer should find the following books:")]
    public void ThenTheCustomerShouldFindTheFollowingBooks(Table expectedBooksTable)
    {
        var expectedBooks = expectedBooksTable.CreateSet<Book>();
        var books = scenarioContext.Get<IEnumerable<Book>>(Books);

        Assert.NotNull(books);
        Assert.Equal(books.Count(), expectedBooks.Count());

        foreach (var expectedBook in expectedBooks)
        {
            Assert.Contains(books, book =>
                book.Title == expectedBook.Title &&
                book.Author == expectedBook.Author);
        }
    }

    [Then(@"the stock for this book should be (.*)")]
    public void ThenTheStockForThisBookShouldBe(int expectedStock)
    {
        var bookData = scenarioContext.Get<IOperationResult<IBooksByTitleResult>>(BookData);
        Assert.Equal(expectedStock, bookData.Data!.Books.First().Stock);
    }
}