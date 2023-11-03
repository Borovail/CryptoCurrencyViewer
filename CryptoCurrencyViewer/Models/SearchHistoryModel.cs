using CryptoCurrencyViewer.Interfaces;

namespace CryptoCurrencyViewer.Models;

    public class SearchHistoryModel :ICryptoModel
    {
        [Key]
        public string Name { get; set; }
        public string Symbol { get; set; }
        public double? CurrentPrice { get; set; }
        public string ImageUrl { get; set; }
        public double? MarketCap { get; set; }
        public double? PriceChangePercentage24h { get; set; }
        public double? Volume24h { get; set; }
        public double? High24h { get; set; }
        public double? Low24h { get; set; }
        public double? PriceChangePercentage7d { get; set; }
        public double? TotalSupply { get; set; }
        public double?  MaxSupply { get; set; }

        public SearchHistoryModel(string name, string symbol, double currentPrice, string imageUrl, double marketCap,
        double priceChangePercentage24h, double volume24h, double high24h,
        double low24h, double priceChangePercentage7d, double totalSupply, double maxSupply)
        {
            Name = name;
            Symbol = symbol;
            CurrentPrice = currentPrice;
            ImageUrl = imageUrl;
            MarketCap = marketCap;
            PriceChangePercentage24h = priceChangePercentage24h;
            Volume24h = volume24h;
            High24h = high24h;
            Low24h = low24h;
            PriceChangePercentage7d = priceChangePercentage7d;
            TotalSupply = totalSupply;
            MaxSupply = maxSupply;
        }

        public SearchHistoryModel(ICryptoModel cryptoModel)
        {
            Name = cryptoModel.Name;
            Symbol = cryptoModel.Symbol;
            CurrentPrice = cryptoModel.CurrentPrice;
            ImageUrl = cryptoModel.ImageUrl;
            MarketCap = cryptoModel.MarketCap;
            PriceChangePercentage24h = cryptoModel.PriceChangePercentage24h;
            Volume24h = cryptoModel.Volume24h;
            High24h = cryptoModel.High24h;
            Low24h = cryptoModel.Low24h;
            PriceChangePercentage7d = cryptoModel.PriceChangePercentage7d;
            TotalSupply = cryptoModel.TotalSupply;
            MaxSupply = cryptoModel.MaxSupply;
        }
        public SearchHistoryModel() { }
    }

