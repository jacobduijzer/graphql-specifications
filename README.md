# GraphQL Specifications with Reqnroll

Welcome to the `graphql-specifications` repository! This project demonstrates how to test a GraphQL service built with [HotChocolate](https://chillicream.com/docs/hotchocolate) using specifications and behavior-driven approaches with [Reqnroll](https://github.com/reqnroll/reqnroll).

## Why Specifications?

Specifications provide a structured, human-readable way to define and verify your GraphQL API’s behavior. By aligning tests with clear specifications, you can:

- Ensure consistent and reliable API behavior.
- Make tests easy to understand for both technical and non-technical stakeholders.
- Promote collaboration and a shared understanding of the API’s functionality.

## Repository Features

- **GraphQL Service**: Built using HotChocolate, showcasing a sample domain.
- **Specifications**: Written in plain language to describe API behavior.
- **Reqnroll Integration**: Testing GraphQL queries and mutations against the specifications.

## Getting Started

Follow these steps to explore and use this repository:

### Prerequisites

Ensure you have the following installed:

- [.NET 9](https://dotnet.microsoft.com/)

### Setup

1. Clone the repository:
   ```bash
   git clone https://github.com/jacobduijzer/graphql-specifications.git
   cd graphql-specifications
   ```
2. Install dependencies:
   ```bash
   dotnet restore
   ```
3. Run the application:
   ```bash
    dotnet run --project ./src/Bookstore.Specifications --no-restore
    ```
   
### Running Tests

1. Run the tests:
   ```bash
   dotnet test
   ```

### Custom WebApplicationFactory

The `CustomWebApplicationFactory` class is used to create a custom `WebApplicationFactory` for integration tests. This class is used to configure the test server with the required services and settings. It is also used to override registered services, in this case the `StockService`.

https://github.com/jacobduijzer/graphql-specifications/blob/04cf32d2b920167eef2f8944e7f9f623c0255411/src/Bookstore.Specifications/CustomWebApplicationFactory.cs#L10-L40

### Specifications

## Links

- [HotChocolate Documentation](https://chillicream.com/docs/hotchocolate)
- [Strawberry Shake Documentation](https://chillicream.com/docs/strawberryshake)
- [Reqnroll Documentation](https://docs.reqnroll.net/)
- [Writing integration tests in .NET](https://learn.microsoft.com/en-us/aspnet/core/test/integration-tests?view=aspnetcore-9.0)

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

---

For more insights, check out my blog post on using specifications with Reqnroll to test GraphQL services. (Coming soon!)

Happy Testing! 🚀

