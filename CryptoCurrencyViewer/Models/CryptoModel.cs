using System.ComponentModel.DataAnnotations;

namespace CryptoCurrencyViewer.Models
{
    public class CryptoModel
    {
        [Key]
        public string Name { get; set; }
        public string Symbol { get; set; }
        public double CurrentPrice { get; set; }
        public string ImageUrl { get; set; }
        public double MarketCap { get; set; }

        public CryptoModel(string name, string symbol, double currentPrice, string imageUrl, double marketCap)
        {
            Name = name;
            Symbol = symbol;
            CurrentPrice = currentPrice;
            ImageUrl = imageUrl;
            MarketCap = marketCap;
        }

        public CryptoModel() { }
    }
}
