using CryptoCurrencyViewer.Interfaces;

namespace CryptoCurrencyViewer.Models.Crypto;

public class SearchHistoryModel 
{
    [Key]
    public string Name { get; set; }
    public string Symbol { get; set; }
    public string ImageUrl { get; set; }

    public SearchHistoryModel(string name, string symbol, string imageUrl)
    {
        Name = name;
        Symbol = symbol;
        ImageUrl = imageUrl;
    }

    public SearchHistoryModel() { }
}

