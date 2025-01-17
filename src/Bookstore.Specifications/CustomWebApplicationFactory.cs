using System.Diagnostics.CodeAnalysis;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;

namespace Bookstore.Specifications;

public class CustomWebApplicationFactory : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
        });
    }

    public IBookstoreClient CreateBookstoreClient(string bearerToken = "")
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection
            .AddBookstoreClient()
            .ConfigureHttpClient(client =>
                {
                    client.BaseAddress = new Uri(Server.BaseAddress, "graphql");
                    if(!string.IsNullOrEmpty(bearerToken))
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);
                },
                c =>
                {
                    c.ConfigurePrimaryHttpMessageHandler(() => Server.CreateHandler());
                });

        return serviceCollection
            .BuildServiceProvider()
            .GetRequiredService<IBookstoreClient>();
    }
}