using CryptoCurrencyViewer.Models;

namespace CryptoCurrencyViewer.Interfaces
{
    public interface IApiService
    {
        public Task<CryptoModel> GetCryptoInfoByName(string cryptoName);

        public Task<SearchCryptoModel> GetExtendedCryptoInfoByName(string cryptoName);

    }
}
