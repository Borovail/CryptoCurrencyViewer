using CryptoCurrencyViewer.Interfaces;
using CryptoCurrencyViewer.Models;
using Newtonsoft.Json.Linq;

namespace CryptoCurrencyViewer.Services
{
    public class ApiService : IApiService
    {
        private const string BaseUrl = "https://api.coingecko.com/api/v3/";
        public async Task<CryptoModel> GetCryptoInfoByNameAsync(string cryptoName)
        {

            using HttpClient client = new HttpClient();
            string url = BaseUrl + "coins/"+ cryptoName + "?localization=false&tickers=false&market_data=true&community_data=false&developer_data=false&sparkline=false";

            using HttpResponseMessage response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string responseData = await response.Content.ReadAsStringAsync();
                JObject cryptoData = JObject.Parse(responseData);

                string name = cryptoData["name"]?.ToString();
                string symbol = cryptoData?["symbol"]?.ToString().ToUpper();
                double currentPrice = Convert.ToDouble(cryptoData["market_data"]["current_price"]["usd"]);
                string imageUrl = cryptoData["image"]["large"].ToString();
                double marketCap = Convert.ToDouble(cryptoData["market_data"]["market_cap"]["usd"]);   
                double priceChangePercentage24h = Convert.ToDouble(cryptoData["market_data"]["price_change_percentage_24h"]);
                double volume24h = Convert.ToDouble(cryptoData["market_data"]["total_volume"]["usd"]);
                double high24h = Convert.ToDouble(cryptoData["market_data"]["high_24h"]["usd"]);
                double low24h = Convert.ToDouble(cryptoData["market_data"]["low_24h"]["usd"]);
                double priceChangePercentage7d = Convert.ToDouble(cryptoData["market_data"]["price_change_percentage_7d"]);
                double totalSupply = Convert.ToDouble(cryptoData["market_data"]["total_supply"]);
                double maxSupply = Convert.ToDouble(cryptoData["market_data"]["max_supply"]);

                return new CryptoModel(
                    name, 
                    symbol, 
                    currentPrice,
                    imageUrl,
                    marketCap,
                    priceChangePercentage24h,
                    volume24h,
                    high24h,
                    low24h,
                    priceChangePercentage7d,
                    totalSupply,
                    maxSupply);
            }

            return new CryptoModel();
        }
    }
}
