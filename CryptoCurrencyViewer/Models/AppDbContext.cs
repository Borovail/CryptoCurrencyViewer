using Microsoft.EntityFrameworkCore;

namespace CryptoCurrencyViewer.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<CryptoModel> CryptoList { get; set; }
    }
}
