using CryptoCurrencyViewer.Interfaces.DataInterfaces;
using CryptoCurrencyViewer.Models;
using CryptoCurrencyViewer.Models.Crypto;
using Microsoft.EntityFrameworkCore;

namespace CryptoCurrencyViewer.Interfaces;

public interface IDbService
{
    ///add
    Task AddItemAsync<T>(T model) where T : class;



    ///get
    Task<List<T>> GetAllItemsAsync<T>() where T : class;
    Task<CryptoModel> GetCryptoWithDetailsAsync(string cryptoName);
    Task<UserModel> GetUserByIdAsync(int id);

    Task<T> GetItemByEmailAsync<T>(string email) where T : class, IHasEmail;
    Task<T> GetItemByNameAsync<T>(string cryptoName) where T : class, IHasForeignKeyForName;


    ///update
    Task UpdateItemAsync<T>(T crypto) where T : class;



    ///delete 
    Task DeleteItemAsync<T>(T crypto) where T : class;





}

