using CryptoCurrencyViewer.Models;

namespace CryptoCurrencyViewer;

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<CryptoModel> CryptoList { get; set; }
        public DbSet<SearchHistoryModel> HistoryList { get; set; }
        public DbSet<UserModel> UsersList { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Установка уникального индекса для Email
        modelBuilder.Entity<UserModel>().HasIndex(u => u.Email).IsUnique();
    }

}

