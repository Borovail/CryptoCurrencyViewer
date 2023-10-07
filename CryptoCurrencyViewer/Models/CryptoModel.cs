namespace CryptoCurrencyViewer.Models
{
    public class CryptoModel
    {
        public string? Name { get; set; }
        public string? Abbreviation { get; set; }
        public double? Price { get; set; }
        public string? ImageUrl { get; set; }


        public CryptoModel( string name , string abbreviation, double price, string imageUrl)   
        { 
            Name = name;
            Abbreviation = abbreviation;
            Price = price;
            ImageUrl = imageUrl;
        }
        public CryptoModel() { }
    }
}
