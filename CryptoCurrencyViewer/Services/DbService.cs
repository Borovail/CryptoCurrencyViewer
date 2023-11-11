using CryptoCurrencyViewer.Interfaces;
using CryptoCurrencyViewer.Models;
using CryptoCurrencyViewer.Models.Crypto;
using Microsoft.AspNetCore.Identity;
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

        async Task<List<T>> IDbService.GetAllItemsAsync<T>() where T : class => await _context.Set<T>().ToListAsync();
        
        async Task IDbService.AddItemAsync<T>(T crypto)
        {
          await   _context.Set<T>().AddAsync(crypto);

            await _context.SaveChangesAsync();
        }

     async Task<CryptoModel> IDbService.GetCryptoWithDetailsAsync(string cryptoName)
    {
        return await _context.CryptoList
            .Include(c => c.DefaultCryptoModel)
            .Include(c => c.ExtendedCryptoModel)
            .Include(c => c.TickerCryptoModels) // Добавьте это, если нужны также данные тикеров
            .FirstOrDefaultAsync(c => c.Name == cryptoName);
    }

    async Task IDbService.DeleteItemAsync<T>(T crypto)
        {
            _context.Set<T>().Update(crypto);

           await _context.SaveChangesAsync();
        }

        async Task IDbService.UpdateItemAsync<T>(T crypto)
        {
            _context.Set<T>().Update(crypto);

            await _context.SaveChangesAsync();

        }

        async Task<T> IDbService.GetItemByNameAsync<T>(string cryptoName) 
        {
           return await  _context.Set<T>().FirstOrDefaultAsync(c => c.Name == cryptoName);
        }

     async Task<T> IDbService.GetItemByIdAsync<T>(int id) 
    {
        return await _context.Set<T>().FirstOrDefaultAsync(u => u.Id == id);
    }

    async Task<T> IDbService.GetItemByEmailAsync<T>(string email)
    {
        return await _context.Set<T>().FirstOrDefaultAsync(u => u.Email == email);
    }


     async Task IDbService.AddRangeAsync<T>(List<T> cryptolist) where T : class
    {
        foreach (var item in cryptolist)
        {
            await _context.Set<T>().AddAsync(item);
        }

        await _context.SaveChangesAsync();
    }

    string IDbService.HashPassword(string inputString)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(inputString));
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }
            return builder.ToString();
        }
    }

}

