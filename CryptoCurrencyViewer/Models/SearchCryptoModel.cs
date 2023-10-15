namespace CryptoCurrencyViewer.Models
{
    public class SearchCryptoModel:CryptoModel
    {
        public double PriceChangePercentage24h { get; set; }
        public double Volume24h { get; set; }
        public double High24h { get; set; }
        public double Low24h { get; set; }
        public double PriceChangePercentage7d { get; set; }
        public double TotalSupply { get; set; }
        public double MaxSupply { get; set; }

        // Конструктор
        public SearchCryptoModel(string name,string symbol,double currentPrice,string imageUrl,double marketCap,
        double priceChangePercentage24h,double volume24h,double high24h,double low24h,double priceChangePercentage7d,double totalSupply,double maxSupply) 
        : base(name,symbol,currentPrice,imageUrl,marketCap)
        {
            PriceChangePercentage24h = priceChangePercentage24h;
            Volume24h = volume24h;
            High24h = high24h;
            Low24h = low24h;
            PriceChangePercentage7d = priceChangePercentage7d;
            TotalSupply = totalSupply;
            MaxSupply = maxSupply;
        }

        public SearchCryptoModel()
        {

        }
    }
}
