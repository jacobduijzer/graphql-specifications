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
- **Implemented Scenarios**:
   - Getting all books.
   - Searching for books by title, retrieving details, and checking stock.
   - Logging in as an owner or customer, with scope validation in the bearer token.
   - Adding books (restricted to logged-in store owners).

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
    dotnet run --project ./src/Bookstore.Api --no-restore
    ```
4. Open the GraphQL Playground at `https://localhost:5011/graphql` to test the queries and mutations.
   
### Running Tests

1. Run the tests:
   ```bash
   dotnet test
   ```
   
### Query Examples

#### Get all books

https://github.com/jacobduijzer/graphql-specifications/blob/215341344602be22d81ba07adcb75c87a9fa2489/src/Bookstore.Specifications/GraphQL/BookQueries.graphql#L1-L8

#### Search for a book by title

https://github.com/jacobduijzer/graphql-specifications/blob/215341344602be22d81ba07adcb75c87a9fa2489/src/Bookstore.Specifications/GraphQL/BookQueries.graphql#L10-L22

#### Login 

https://github.com/jacobduijzer/graphql-specifications/blob/215341344602be22d81ba07adcb75c87a9fa2489/src/Bookstore.Specifications/GraphQL/Login.graphql#L1-L5

### Custom WebApplicationFactory

The `CustomWebApplicationFactory` class is used to create a custom `WebApplicationFactory` for integration tests. This class is used to configure the test server with the required services and settings. It is also used to override registered services, in this case the `StockService`.

https://github.com/jacobduijzer/graphql-specifications/blob/0c4f80febe83d566fa862920b5eefd2fc09f346a/src/Bookstore.Specifications/CustomWebApplicationFactory.cs#L10-L40

### Specifications

#### Login

https://github.com/jacobduijzer/graphql-specifications/blob/04cf32d2b920167eef2f8944e7f9f623c0255411/src/Bookstore.Specifications/Login.feature#L1-L11

#### Search for books

https://github.com/jacobduijzer/graphql-specifications/blob/04cf32d2b920167eef2f8944e7f9f623c0255411/src/Bookstore.Specifications/SearchBooks.feature#L1-L22

#### Add books

https://github.com/jacobduijzer/graphql-specifications/blob/04cf32d2b920167eef2f8944e7f9f623c0255411/src/Bookstore.Specifications/AddBooks.feature#L1-L21

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

