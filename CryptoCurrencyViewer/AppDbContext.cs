using CryptoCurrencyViewer.Models;
using Microsoft.EntityFrameworkCore;

namespace CryptoCurrencyViewer
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<CryptoModel> CryptoList { get; set; }
        public DbSet<SearchHistoryModel> SearchHistoryList { get; set; }

    }
}
