namespace CryptoCurrencyViewer.Interfaces;

    public interface IDbService
    {
        Task<List<T>> GetAllItemsAsync<T>() where T : class;
        Task AddItemAsync<T>(T crypto) where T : class;
        Task DeleteItemAsync<T>(T crypto) where T : class;
        Task UpdateItemAsync<T>(T crypto) where T : class ;
        Task<T> GetItemByNameAsync<T>(string name) where T : class, ICryptoModel;
        Task<T> GetItemByIdAsync<T>(int id) where T : class,IHasId;
        Task<T> GetItemByEmailAsync<T>(string email) where T : class, IHasEmail;

    string HashPassword(string password);
 
}

