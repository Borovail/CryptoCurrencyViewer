using CryptoCurrencyViewer.Models;

namespace CryptoCurrencyViewer.Interfaces
{
    public interface ICryptoService
    {
        Task<List<CryptoModel>> GetCryptoAsync();
        //void RefreshCryptoAsync(List<CryptoModel> cryptoName);
        Task<List<SearchCryptoModel>> GetCryptoInfoAsync();

    }
}
