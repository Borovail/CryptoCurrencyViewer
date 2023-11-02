namespace CryptoCurrencyViewer.Interfaces
{
    public interface IDbService
    {
        Task<List<T>> GetAllItemsAsync<T>() where T : class, ICryptoModel;
        Task AddItemAsync<T>(T crypto) where T : class, ICryptoModel;
        Task DeleteItemAsync<T>(T crypto) where T : class, ICryptoModel;
        Task UpdateItemAsync<T>(T crypto) where T : class, ICryptoModel;
        Task<T> GetItemByNameAsync<T>(string cryptoName) where T : class, ICryptoModel;


    }
}
