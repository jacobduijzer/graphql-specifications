namespace Bookstore.Api.Stock;

public interface IStockService
{
    int ForBook(Guid bookId);
}