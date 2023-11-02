using System.ComponentModel.DataAnnotations;

namespace CryptoCurrencyViewer.Interfaces
{
    public interface ICryptoModel
    {
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
        public double? MaxSupply { get; set; }
    }
}
