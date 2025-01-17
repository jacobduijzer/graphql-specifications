using Reqnroll;
using StrawberryShake;

namespace Bookstore.Specifications;

[Binding]
public class AddBooks(CustomWebApplicationFactory factory, ScenarioContext scenarioContext)
    : CustomWebApplicationFactory
{
    private const string BookData = "book-data";
    private const string Title = "title";
    private const string Author = "author";
    private const string Isbn = "isbn";
    private const string BearerToken = "bearer-token";

    [Given(@"a book with the title ""(.*)""")]
    public void GivenABookWithTheTitle(string title)
    {
        scenarioContext.Add(Title, title);
    }

    [Given(@"the author ""(.*)""")]
    public void GivenTheAuthor(string author)
    {
        scenarioContext.Add(Author, author);
    }

    [Given(@"the isbn ""(.*)""")]
    public void GivenTheIsbn(string isbn)
    {
        scenarioContext.Add(Isbn, isbn);
    }

    [When(@"the bookstore owner is logged in with the username ""(.*)"" and password ""(.*)""")]
    public async Task WhenTheBookstoreOwnerIsLoggedInWithTheUsernameAndPassword(string username, string password)
    {
        var data = await factory.CreateBookstoreClient().Login.ExecuteAsync(username, password);
        scenarioContext.Add(BearerToken, data.Data!.Login.Token);
    }

    [When(@"the bookstore owner adds a new book to the catalog")]
    public async Task WhenTheBookstoreOwnerAddsANewBookToTheCatalog()
    {
        var client = scenarioContext.TryGetValue(BearerToken, out string bearerToken) ? 
            factory.CreateBookstoreClient(bearerToken) : factory.CreateBookstoreClient();

        var result = await client.AddBook.ExecuteAsync(
            scenarioContext.Get<string>(Title),
            scenarioContext.Get<string>(Author),
            scenarioContext.Get<string>(Isbn));
        scenarioContext.Add(BookData, result);
    }

    [Then(@"the book is added to the catalog")]
    public void ThenTheBookIsAddedToTheCatalog()
    {
        Assert.NotNull(scenarioContext.Get<IOperationResult<IAddBookResult>>(BookData).Data);
    }

    [Then(@"the newly added book will be returned")]
    public void ThenTheNewlyAddedBookWillBeReturned()
    {
        var result = scenarioContext.Get<IOperationResult<IAddBookResult>>(BookData);
        Assert.Equal(result.Data!.AddBook.Title, scenarioContext.Get<string>(Title));
    }

    [Then(@"the bookstore owner will get an error message")]
    public void ThenTheBookstoreOwnerWillGetAnErrorMessage()
    {
        var result = scenarioContext.Get<IOperationResult<IAddBookResult>>(BookData);
        Assert.True(result.Errors.Any());
        Assert.Contains(result.Errors, e => e.Code!.Equals("AUTH_NOT_AUTHENTICATED"));
    }
}