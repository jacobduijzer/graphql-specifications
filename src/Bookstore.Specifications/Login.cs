using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Reqnroll;
using StrawberryShake;

namespace Bookstore.Specifications;

[Binding]
public class Login(CustomWebApplicationFactory factory, ScenarioContext scenarioContext)
    : CustomWebApplicationFactory
{
    private const string LoginData = "login-data";
    
    private readonly IBookstoreClient _client = factory.CreateBookstoreClient();
    
    [Given(@"a store owner")]
    [Given(@"a customer")]
    public void GivenAStoreOwner()
    {
        // DO NOTHING
    }

    [When(@"the store owner logs in with the username ""(.*)"" and password ""(.*)""")]
    [When(@"the customer logs in with the username ""(.*)"" and password ""(.*)""")]
    public async Task WhenTheStoreOwnerLogsInWithTheUsernameAndPassword(string username, string password)
    {
        var result = await _client.Login.ExecuteAsync(username, password);
        scenarioContext.Add(LoginData, result);
    }

    [Then(@"the store owner is logged in with the correct ""(.*)"" claim")]
    [Then(@"the customer is logged in with the correct ""(.*)"" claim")]
    public void ThenTheStoreOwnerIsLoggedInWithTheCorrectClaim(string claim)
    {
        var result = scenarioContext.Get<IOperationResult<ILoginResult>>(LoginData);
        Assert.NotNull(result.Data);
        
        var jwtToken = new JwtSecurityTokenHandler().ReadJwtToken(result.Data.Login.Token);
        Assert.Equal(claim, jwtToken.Claims.FirstOrDefault(x => x.Type == "role")!.Value);
    }
}