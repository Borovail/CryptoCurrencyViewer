using CryptoCurrencyViewer.Models;
using CryptoCurrencyViewer.Models.Crypto;

namespace CryptoCurrencyViewer;

public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<CryptoModel> CryptoList { get; set; }
    public DbSet<DefaultCryptoModel> DefaultCryptoList { get; set; }
    public DbSet<ExtendedCryptoModel> ExtendedCryptoList { get; set; }
    public DbSet<TickerCryptoModel> TickerCryptoList { get; set; }
    public DbSet<MarketCryptoModel> MarketList { get; set; }
    public DbSet<ConvertedLastInfo> ConvertedLastList { get; set; }
    public DbSet<ConvertedVolumeInfo> ConvertedVolumeList { get; set; }
    public DbSet<UserModel> UsersList { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Установка уникального индекса для Email
        modelBuilder.Entity<UserModel>().HasIndex(u => u.Email).IsUnique();

        modelBuilder.Entity<CryptoModel>()
     .HasOne(c => c.DefaultCryptoModel)
     .WithOne(d => d.CryptoModel)
     .HasForeignKey<DefaultCryptoModel>(d => d.CryptoModelName);

        modelBuilder.Entity<CryptoModel>()
            .HasOne(c => c.ExtendedCryptoModel)
            .WithOne(e => e.CryptoModel)
            .HasForeignKey<ExtendedCryptoModel>(e => e.CryptoModelName);

        modelBuilder.Entity<CryptoModel>()
    .HasIndex(c => c.Name) // предполагая, что Name должно быть уникальным
    .IsUnique();

        modelBuilder.Entity<CryptoModel>()
    .HasMany(c => c.TickerCryptoModels)
    .WithOne(t => t.CryptoModel) // Указываем, что у TickerCryptoModel есть один CryptoModel
    .OnDelete(DeleteBehavior.Cascade); // Настройка каскадного удаления

        modelBuilder.Entity<DefaultCryptoModel>()
    .HasOne(d => d.User) // Используйте HasOptional для EF 6.x или HasOne для EF Core
    .WithMany(u => u.DefaultCryptos) // Указываем, что у UserModel может быть много DefaultCryptoModels
    .HasForeignKey(d => d.UserId); // Устанавливаем UserId как FK

        // Конфигурация связи между UserModel и SearchHistoryModel
        modelBuilder.Entity<UserModel>()
            .HasMany(u => u.SearchHistory) // Указываем, что у UserModel может быть много SearchHistoryModels
            .WithOne(sh => sh.User) // Используйте WithRequired для EF 6.x или WithOne для EF Core
            .HasForeignKey(sh => sh.UserId); // Устанавливаем UserId как FK

        modelBuilder.Entity<UserModel>()
         .HasMany(u => u.ExchangeHistory) // Указываем, что у UserModel может быть много SearchHistoryModels
         .WithOne(sh => sh.User) // Используйте WithRequired для EF 6.x или WithOne для EF Core
         .HasForeignKey(sh => sh.UserId); // Устанавливаем UserId как FK

    }

}

