using CryptoCurrencyViewer.Interfaces;
using CryptoCurrencyViewer.Models;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Newtonsoft.Json.Linq;

namespace CryptoCurrencyViewer.Services
{
    public class CryptoService : ICryptoService
    {
        private const string BaseUrl = "https://api.coingecko.com/api/v3/";
        public async Task<CryptoModel> AddCryptoAsync(string cryptoName)
        {
            CryptoModel crypto = new CryptoModel();
            using HttpClient client = new HttpClient();

            string endpoint = "coins/" + cryptoName;  
            string parameters = "?vs_currency=usd"; 

            string url = BaseUrl + endpoint;

           using HttpResponseMessage response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string responseData = await response.Content.ReadAsStringAsync();

                JObject cryptoData = JObject.Parse(responseData);


                string? name = cryptoData["name"]?.ToString();
                string? symbol = cryptoData?["symbol"]?.ToString().ToUpper();
                string currentPrice = cryptoData["market_data"]["current_price"]["usd"].ToString();
                string? imageUrl = cryptoData["image"]["large"].ToString();


                return new CryptoModel(name, symbol, Convert.ToDouble(currentPrice), imageUrl);
            }
            else 
                return null;
        }

        public async void RefreshCryptoAsync(List<CryptoModel> cryptos)
        {
            for (var i = 0; i < cryptos.Count; i++)
            {
                var updatedCrypto = await AddCryptoAsync(cryptos[i].Name);
                cryptos[i] = updatedCrypto;
            }
        }

    }
}
