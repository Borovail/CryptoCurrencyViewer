using CryptoCurrencyViewer.Interfaces.DataInterfaces;
using CryptoCurrencyViewer.Models.Crypto;
using Microsoft.EntityFrameworkCore;

namespace CryptoCurrencyViewer.Interfaces;

public interface IDbService
{
    Task<List<T>> GetAllItemsAsync<T>() where T : class;
    Task AddCryptoAsync<T>(T crypto) where T : CryptoModel;
    Task AddItemAsync<T>(T model) where T : class;

    Task DeleteItemAsync<T>(T crypto) where T : class;
    Task UpdateItemAsync<T>(T crypto) where T : class;
    Task<T> GetItemByEmailAsync<T>(string email) where T : class, IHasEmail;

    Task<CryptoModel> GetCryptoWithDetailsAsync(string cryptoName);

    string HashPassword(string password);

}

