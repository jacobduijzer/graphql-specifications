using Bookstore.Api;
using Reqnroll;
using StrawberryShake;

namespace Bookstore.Specifications;

[Binding]
public class SearchBooks(CustomWebApplicationFactory factory, ScenarioContext scenarioContext)
    : CustomWebApplicationFactory
{
    private const string BookData = "book-data";

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
        scenarioContext.Add(BookData, bookData);
    }

    [Then(@"the customer should find the following books:")]
    public void ThenTheCustomerShouldFindTheFollowingBooks(Table expectedBooksTable)
    {
        var expectedBooks = expectedBooksTable.CreateSet<Book>();
        var bookData = scenarioContext.Get<IOperationResult<IAllBooksResult>>(BookData);

        Assert.NotNull(bookData.Data);
        Assert.Equal(bookData.Data.Books.Count(), expectedBooks.Count());
        
        foreach (var expectedBook in expectedBooks)
        {
            Assert.Contains(bookData.Data.Books, book => 
                book.Title == expectedBook.Title && 
                book.Author == expectedBook.Author);
        }
    }
}