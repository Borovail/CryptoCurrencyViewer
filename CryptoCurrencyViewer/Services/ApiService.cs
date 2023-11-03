using CryptoCurrencyViewer.Interfaces;
using CryptoCurrencyViewer.Models;


namespace CryptoCurrencyViewer.Services;

    public class ApiService : IApiService
    {
        private const string BaseUrl = "https://api.coingecko.com/api/v3/";
        public async Task<ICryptoModel> GetCryptoInfoByNameAsync(string cryptoName)
        {
            cryptoName = cryptoName.ToLower();

            using HttpClient client = new HttpClient();
            string url = BaseUrl + "coins/"+ cryptoName + "?localization=false&tickers=false&market_data=true&community_data=false&developer_data=false&sparkline=false";

            using HttpResponseMessage response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string responseData = await response.Content.ReadAsStringAsync();
                JObject cryptoData = JObject.Parse(responseData);

                string name = cryptoData["name"]?.ToString();
                string symbol = cryptoData["symbol"]?.ToString().ToUpper();
                string imageUrl = cryptoData["image"]["large"]?.ToString();

                double currentPrice;
                double.TryParse(cryptoData["market_data"]["current_price"]["usd"]?.ToString(), out currentPrice);

                double marketCap;
                double.TryParse(cryptoData["market_data"]["market_cap"]["usd"]?.ToString(), out marketCap);

                double priceChangePercentage24h;
                double.TryParse(cryptoData["market_data"]["price_change_percentage_24h"]?.ToString(), out priceChangePercentage24h);

                double volume24h;
                double.TryParse(cryptoData["market_data"]["total_volume"]["usd"]?.ToString(), out volume24h);

                double high24h;
                double.TryParse(cryptoData["market_data"]["high_24h"]["usd"]?.ToString(), out high24h);

                double low24h;
                double.TryParse(cryptoData["market_data"]["low_24h"]["usd"]?.ToString(), out low24h);

                double priceChangePercentage7d;
                double.TryParse(cryptoData["market_data"]["price_change_percentage_7d"]?.ToString(), out priceChangePercentage7d);

                double totalSupply;
                double.TryParse(cryptoData["market_data"]["total_supply"]?.ToString(), out totalSupply);

                double maxSupply;
                double.TryParse(cryptoData["market_data"]["max_supply"]?.ToString(), out maxSupply);


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

