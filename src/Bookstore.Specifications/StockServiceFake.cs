using Bookstore.Api.Stock;

namespace Bookstore.Specifications;

public class StockServiceFake : IStockService
{
    public int ForBook(Guid bookId) => 1;
}