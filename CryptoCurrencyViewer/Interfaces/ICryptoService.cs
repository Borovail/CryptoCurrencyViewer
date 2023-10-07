using CryptoCurrencyViewer.Models;

namespace CryptoCurrencyViewer.Interfaces
{
    public interface ICryptoService
    {
       Task<CryptoModel> AddCryptoAsync(string cryptoName);
       void RefreshCryptoAsync(List<CryptoModel> cryptoName);

    }
}
