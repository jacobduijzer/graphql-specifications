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

    public IBookstoreClient CreateBookstoreClient()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection
            .AddBookstoreClient()
            .ConfigureHttpClient(c =>
                {
                    c.BaseAddress = new Uri(Server.BaseAddress, "graphql");
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