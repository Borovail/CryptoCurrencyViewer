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
     .HasForeignKey<DefaultCryptoModel>(d => d.CryptoModelName)
    .OnDelete(DeleteBehavior.Cascade); // Настройка каскадного удаления


        modelBuilder.Entity<CryptoModel>()
            .HasOne(c => c.ExtendedCryptoModel)
            .WithOne(e => e.CryptoModel)
            .HasForeignKey<ExtendedCryptoModel>(e => e.CryptoModelName)
    .OnDelete(DeleteBehavior.Cascade); // Настройка каскадного удаления


        modelBuilder.Entity<CryptoModel>()
    .HasIndex(c => c.Name) // предполагая, что Name должно быть уникальным
    .IsUnique();

        modelBuilder.Entity<CryptoModel>()
    .HasMany(c => c.TickerCryptoModels)
    .WithOne(t => t.CryptoModel) // Указываем, что у TickerCryptoModel есть один CryptoModel
    .OnDelete(DeleteBehavior.Cascade); // Настройка каскадного удаления



        // Конфигурация связи между UserModel и SearchHistoryModel
        modelBuilder.Entity<UserModel>()
            .HasMany(u => u.SearchHistory) // Указываем, что у UserModel может быть много SearchHistoryModels
.WithOne(sh => sh.User) // Используйте WithRequired для EF 6.x или WithOne для EF Core
.HasForeignKey(sh => sh.UserId)// Устанавливаем UserId как FK
.OnDelete(DeleteBehavior.Restrict); // Настройка каскадного удаления


        modelBuilder.Entity<UserModel>()
         .HasMany(u => u.ExchangeHistory) // Указываем, что у UserModel может быть много SearchHistoryModels
         .WithOne(sh => sh.User) // Используйте WithRequired для EF 6.x или WithOne для EF Core
         .HasForeignKey(sh => sh.UserId)// Устанавливаем UserId как FK
    .OnDelete(DeleteBehavior.Restrict); // Настройка каскадного удаления






        // Для ConvertedLastInfo и ConvertedVolumeInfo каскадное удаление может быть настроено так:
        modelBuilder.Entity<TickerCryptoModel>()
            .HasOne(t => t.ConvertedLast) // Связь один к одному с ConvertedLastInfo
            .WithOne() // Не указываем обратную связь, если она не нужна
            .HasForeignKey<TickerCryptoModel>(t => t.ConvertedLastInfoId)
            .OnDelete(DeleteBehavior.Cascade); // Каскадное удаление ConvertedLastInfo при удалении TickerCryptoModel

        modelBuilder.Entity<TickerCryptoModel>()
            .HasOne(t => t.ConvertedVolume) // Связь один к одному с ConvertedVolumeInfo
            .WithOne() // Не указываем обратную связь, если она не нужна
            .HasForeignKey<TickerCryptoModel>(t => t.ConvertedVolumeInfoId)
            .OnDelete(DeleteBehavior.Cascade); // Каскадное удаление ConvertedVolumeInfo при удалении TickerCryptoModel

        // В предположении, что у MarketCryptoModel есть связь с TickerCryptoModel
        modelBuilder.Entity<TickerCryptoModel>()
            .HasOne(m => m.Market) // Связь один ко многим с TickerCryptoModel
            .WithOne() // Обратная связь с MarketCryptoModel
            .HasForeignKey<TickerCryptoModel>(t => t.MarketCryptoModelId)
            .OnDelete(DeleteBehavior.Cascade); // Каскадное удаление TickerCryptoModel

    }

}

