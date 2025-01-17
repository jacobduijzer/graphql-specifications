using System.Security.Cryptography;

namespace Bookstore.Api.Stock;

public class StockService : IStockService
{
    public int ForBook(Guid bookId)
    {
        // Fake stock calculation
        var hash = MD5.HashData(bookId.ToByteArray());
        return Math.Abs(BitConverter.ToInt32(hash, 0) % 10);
    }
}