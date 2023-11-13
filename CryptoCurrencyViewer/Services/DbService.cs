using CryptoCurrencyViewer.Interfaces;
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

        async Task<List<T>> IDbService.GetAllItemsAsync<T>() where T : class => await _context.Set<T>().ToListAsync();
        
        async Task IDbService.AddCryptoAsync<T>(T crypto)
        {
        crypto.DefaultCryptoModel.CryptoModelName = crypto.Name;
        crypto.ExtendedCryptoModel.CryptoModelName = crypto.Name;

        foreach (var tickerData in crypto.TickerCryptoModels)
        {
            tickerData.CryptoModelName = crypto.Name;
        }

        await _context.Set<T>().AddAsync(crypto);

            await _context.SaveChangesAsync();
        }

    async Task IDbService.AddItemAsync<T>(T model)
    {
        await _context.Set<T>().AddAsync(model);

        await _context.SaveChangesAsync();
    }

    async Task<CryptoModel> IDbService.GetCryptoWithDetailsAsync(string cryptoName)
    {
#pragma warning disable CS8603 // Возможно, возврат ссылки, допускающей значение NULL.
        return await _context.CryptoList
            .Include(c => c.DefaultCryptoModel)
            .Include(c => c.ExtendedCryptoModel)
            .Include(c => c.TickerCryptoModels) 
            .ThenInclude(c=>c.ConvertedLast)
            .Include(c => c.TickerCryptoModels) 
            .ThenInclude(c => c.Market)
            .Include(c => c.TickerCryptoModels)
            .ThenInclude(c => c.ConvertedVolume)
            .FirstOrDefaultAsync(c => c.Name == cryptoName);
#pragma warning restore CS8603 // Возможно, возврат ссылки, допускающей значение NULL.
    }

    async Task<T> IDbService.GetItemByEmailAsync<T>(string email)
    {
        return await _context.Set<T>().FirstOrDefaultAsync(u => u.Email == email);
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

