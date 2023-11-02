using CryptoCurrencyViewer.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CryptoCurrencyViewer.Services
{
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
          var temp=  await   _context.Set<T>().AddAsync(crypto);

            await _context.SaveChangesAsync();
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
    }
}
