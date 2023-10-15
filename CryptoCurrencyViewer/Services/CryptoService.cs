using CryptoCurrencyViewer.Interfaces;
using CryptoCurrencyViewer.Models;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Newtonsoft.Json.Linq;

namespace CryptoCurrencyViewer.Services
{
    public class CryptoService : ICryptoService
    {
        private const string BaseUrl = "https://api.coingecko.com/api/v3/";
        public async Task<List<CryptoModel>> GetCryptoAsync()
        {
            //using HttpClient client = new HttpClient();
            //string url = BaseUrl + "coins/bitcoin?localization=false&tickers=false&market_data=true&community_data=false&developer_data=false&sparkline=false";

            //using HttpResponseMessage response = await client.GetAsync(url);

            //if (response.IsSuccessStatusCode)
            //{
            //    string responseData = await response.Content.ReadAsStringAsync();
            //    JObject cryptoData = JObject.Parse(responseData);

            //    string name = cryptoData["name"]?.ToString();
            //    string symbol = cryptoData?["symbol"]?.ToString().ToUpper();
            //    double currentPrice = Convert.ToDouble(cryptoData["market_data"]["current_price"]["usd"]);
            //    string imageUrl = cryptoData["image"]["large"].ToString();
            //    double marketCap = Convert.ToDouble(cryptoData["market_data"]["market_cap"]["usd"]);

            //    return new List<CryptoModel> { new CryptoModel(name, symbol, currentPrice, imageUrl, marketCap ) };
            //}

            return new List<CryptoModel>();
        }

        public async Task<List<SearchCryptoModel>> GetCryptoInfoAsync()
        {
            //using HttpClient client = new HttpClient();
            //string url = BaseUrl + "coins/bitcoin?localization=false&tickers=true&market_data=true&community_data=true&developer_data=true&sparkline=false";

            //using HttpResponseMessage response = await client.GetAsync(url);

            //if (response.IsSuccessStatusCode)
            //{
            //    string responseData = await response.Content.ReadAsStringAsync();
            //    JObject cryptoData = JObject.Parse(responseData);

            //    string name = cryptoData["name"]?.ToString();
            //    string symbol = cryptoData?["symbol"]?.ToString().ToUpper();
            //    double currentPrice = Convert.ToDouble(cryptoData["market_data"]["current_price"]["usd"]);
            //    string imageUrl = cryptoData["image"]["large"].ToString();
            //    double marketCap = Convert.ToDouble(cryptoData["market_data"]["market_cap"]["usd"]);
            //    double priceChangePercentage24h = Convert.ToDouble(cryptoData["market_data"]["price_change_percentage_24h"]);
            //    double volume24h = Convert.ToDouble(cryptoData["market_data"]["total_volume"]["usd"]);
            //    double high24h = Convert.ToDouble(cryptoData["market_data"]["high_24h"]["usd"]);
            //    double low24h = Convert.ToDouble(cryptoData["market_data"]["low_24h"]["usd"]);
            //    double priceChangePercentage7d = Convert.ToDouble(cryptoData["market_data"]["price_change_percentage_7d"]);
            //    double totalSupply = Convert.ToDouble(cryptoData["market_data"]["total_supply"]);
            //    double maxSupply = Convert.ToDouble(cryptoData["market_data"]["max_supply"]);

            //    List<string> tradingPairs = cryptoData["tickers"].ToObject<List<Ticker>>().Select(t => t.Pair).ToList();

            //    return new List<SearchHistoryModel>{ new SearchHistoryModel(
            //        name,
            //        symbol,
            //        currentPrice,
            //        imageUrl,
            //        marketCap,
            //        priceChangePercentage24h,
            //        volume24h,
            //        high24h,
            //        low24h,
            //        priceChangePercentage7d,
            //        totalSupply,
            //        maxSupply,
            //        tradingPairs) }   ;
            //}

            return new List<SearchCryptoModel>();

        }
        public class Ticker
        {
            public string Pair { get; set; }
        }

        public async void RefreshCryptoAsync(List<CryptoModel> cryptos)
        {
            for (var i = 0; i < cryptos.Count; i++)
            {
                ////var updatedCrypto = await AddCryptoAsync(cryptos[i].Name);
                //cryptos[i] = updatedCrypto;
            }
        }

    }
}
