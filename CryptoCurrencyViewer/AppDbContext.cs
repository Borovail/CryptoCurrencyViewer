using CryptoCurrencyViewer.Models;

namespace CryptoCurrencyViewer;

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<CryptoModel> CryptoList { get; set; }
        public DbSet<SearchHistoryModel> HistoryList { get; set; }
    }

