using CryptoCurrencyViewer.Interfaces;
using CryptoCurrencyViewer.Interfaces.DataInterfaces;
using CryptoCurrencyViewer.Models;
using CryptoCurrencyViewer.Models.Crypto;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace CryptoCurrencyViewer.Services;

    public class DbService : IDbService
    {
        private readonly AppDbContext _context;


        public DbService(AppDbContext context)
        {
            _context = context;
        }


    ///add
    public async Task AddItemAsync<T>(T model) where T : class
    {
        await _context.Set<T>().AddAsync(model);

        await SaveChangesAsync();
    }

   



    ///get
    public async Task<List<T>> GetAllItemsAsync<T>() where T : class => await _context.Set<T>().ToListAsync();
    public async Task<CryptoModel> GetCryptoWithDetailsAsync(string cryptoName)
    {
#pragma warning disable CS8603 // Возможно, возврат ссылки, допускающей значение NULL.
        return await _context.CryptoList
            .Include(c => c.DefaultCryptoModel)
            .Include(c => c.ExtendedCryptoModel)
            .Include(c => c.TickerCryptoModels)
            .ThenInclude(c => c.ConvertedLast)
            .Include(c => c.TickerCryptoModels)
            .ThenInclude(c => c.Market)
            .Include(c => c.TickerCryptoModels)
            .ThenInclude(c => c.ConvertedVolume)
            .FirstOrDefaultAsync(c => c.Name == cryptoName);
#pragma warning restore CS8603 // Возможно, возврат ссылки, допускающей значение NULL.
    }
    public async Task<UserModel> GetUserByIdAsync(int id)
    {
#pragma warning disable CS8603 // Возможно, возврат ссылки, допускающей значение NULL.
        return await _context.UsersList
            .Include(c => c.SearchHistory)
            .ThenInclude(c=>c.Crypto)
            .ThenInclude(c=>c.DefaultCryptoModel)
            .Include(c=>c.ExchangeHistory)
              .ThenInclude(c => c.Crypto)
            .ThenInclude(c => c.DefaultCryptoModel)
            .FirstOrDefaultAsync(c => c.Id == id);
#pragma warning restore CS8603 // Возможно, возврат ссылки, допускающей значение NULL.
    }


    public async Task<T> GetItemByNameAsync<T>(string cryptoName) where T : class, IHasForeignKeyForName
    {
        return await _context.Set<T>().FirstOrDefaultAsync(i => i.CryptoModelName == cryptoName);
    }
    public async Task<T> GetItemByEmailAsync<T>(string email) where T : class, IHasEmail
    {
        return await _context.Set<T>().FirstOrDefaultAsync(u => u.Email == email);
    }







    ///update
    public async Task UpdateItemAsync<T>(T crypto) where T : class
    {
        _context.Set<T>().Update(crypto);

        await SaveChangesAsync();

    }


    ///delete 
    public async Task DeleteItemAsync<T>(T crypto) where T : class
    {
        _context.Set<T>().Remove(crypto);

        await  SaveChangesAsync();
    }




    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    
}

