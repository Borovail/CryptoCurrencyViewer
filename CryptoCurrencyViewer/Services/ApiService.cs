using CryptoCurrencyViewer.Interfaces;
using CryptoCurrencyViewer.Models.Crypto;

namespace CryptoCurrencyViewer.Services;

    public class ApiService : IApiService
    {
        private const string BaseUrl = "https://api.coingecko.com/api/v3/";
        public async Task<CryptoModel> GetFullCryptoInfoByNameAsync(string cryptoName)
        {
            cryptoName = cryptoName.ToLower();

            using HttpClient client = new HttpClient();

        string url = BaseUrl + "coins/" + cryptoName + "?localization=false&tickers=true&market_data=true&community_data=false&developer_data=false&sparkline=true";

        using HttpResponseMessage response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string responseData = await response.Content.ReadAsStringAsync();
                JObject cryptoData = JObject.Parse(responseData);

            return Initialize(cryptoData,cryptoName);
            }

        return null;
        }

    public async Task<DefaultCryptoModel> GetDefaultCryptoInfoByNameAsync(string cryptoName)
    {
        cryptoName = cryptoName.ToLower();

        using HttpClient client = new HttpClient();

        string url = BaseUrl + "coins/" + cryptoName + "?localization=false&tickers=false&market_data=true&community_data=false&developer_data=false&sparkline=false";

        using HttpResponseMessage response = await client.GetAsync(url);

        if (response.IsSuccessStatusCode)
        {
            string responseData = await response.Content.ReadAsStringAsync();
            JObject cryptoData = JObject.Parse(responseData);

            string symbol = cryptoData["symbol"]?.ToString().ToUpper();
            string imageUrl = cryptoData["image"]["large"]?.ToString();
            double currentPrice, marketCap;

            double.TryParse(cryptoData["market_data"]["current_price"]["usd"]?.ToString(), out currentPrice);
            double.TryParse(cryptoData["market_data"]["market_cap"]["usd"]?.ToString(), out marketCap);

            var defaultCrypto = new DefaultCryptoModel( symbol, currentPrice, imageUrl, marketCap);

            return defaultCrypto;
        }

        return null;
    }
   













    private CryptoModel Initialize(JObject cryptoData, string cryptoName)
    {
        string symbol = cryptoData["symbol"]?.ToString().ToUpper();
        string imageUrl = cryptoData["image"]["large"]?.ToString();
        double currentPrice, marketCap;

        double.TryParse(cryptoData["market_data"]["current_price"]["usd"]?.ToString(), out currentPrice);
        double.TryParse(cryptoData["market_data"]["market_cap"]["usd"]?.ToString(), out marketCap);

        var defaultCrypto = new DefaultCryptoModel(symbol, currentPrice, imageUrl, marketCap);


        double priceChangePercentage24h, volume24h, high24h, low24h, priceChangePercentage7d, totalSupply, maxSupply;

        double.TryParse(cryptoData["market_data"]["price_change_percentage_24h"]?.ToString(), out priceChangePercentage24h);
        double.TryParse(cryptoData["market_data"]["total_volume"]["usd"]?.ToString(), out volume24h);
        double.TryParse(cryptoData["market_data"]["high_24h"]["usd"]?.ToString(), out high24h);
        double.TryParse(cryptoData["market_data"]["low_24h"]["usd"]?.ToString(), out low24h);
        double.TryParse(cryptoData["market_data"]["price_change_percentage_7d"]?.ToString(), out priceChangePercentage7d);
        double.TryParse(cryptoData["market_data"]["total_supply"]?.ToString(), out totalSupply);
        double.TryParse(cryptoData["market_data"]["max_supply"]?.ToString(), out maxSupply);

        var extendedCrypto = new ExtendedCryptoModel(priceChangePercentage24h, volume24h, high24h, low24h, priceChangePercentage7d, totalSupply, maxSupply);


        List<TickerCryptoModel> tickersInfo = cryptoData["tickers"].Select(t => new TickerCryptoModel(
            t["target"]?.ToString(),(decimal?)t["last"] ?? 0, (decimal?)t["volume"] ?? 0
        )).ToList();


        //var prices7d = cryptoData["market_data"]["sparkline_in_7d"]["price"].Select(p => (decimal)p).ToList();

        //var graphCrypto = new GraphCryptoModel(prices7d);



       string name = cryptoData["name"]?.ToString();





        return new CryptoModel(name, defaultCrypto, extendedCrypto, tickersInfo);

    }
}

