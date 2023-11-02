using CryptoCurrencyViewer.Models;

namespace CryptoCurrencyViewer.Interfaces
{
    public interface IApiService
    {
        public Task<ICryptoModel> GetCryptoInfoByNameAsync(string cryptoName);

    }
}
