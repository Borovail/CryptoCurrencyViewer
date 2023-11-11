using CryptoCurrencyViewer;
using CryptoCurrencyViewer.Interfaces;
using CryptoCurrencyViewer.Models.Crypto;
using CryptoCurrencyViewer.Services;
using Microsoft.EntityFrameworkCore;
using MimeKit;

namespace UnitTestForDbModel
{
    
    public class UnitTest1
    {
        [Fact]
        public async  void Test1()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "AddItemTest") // Уникальное имя для каждого теста
                .Options;

            // Создайте экземпляр контекста и сервиса для тестирования
            using (var context = new AppDbContext(options))
            {
                IDbService dbService = new DbService(context);
                IApiService apiService = new ApiService();

                var crypto=  await apiService.GetFullCryptoInfoByNameAsync("bitcoin");

                // Act
                await dbService.AddItemAsync(crypto);

                // Assert
                var itemInDb = await context.Set<CryptoModel>().FirstOrDefaultAsync(item => item.Name == "bitcoint");
                Assert.NotNull(itemInDb);
              
            }
        }
    }
}