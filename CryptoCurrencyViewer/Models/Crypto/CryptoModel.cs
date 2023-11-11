using CryptoCurrencyViewer.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace CryptoCurrencyViewer.Models.Crypto;


public class CryptoModel : IHasName
{
    [Key]
    public string Name { get; set; }

    // Связь "один к одному" с DefaultCryptoModel и ExtendedCryptoModel
    public virtual DefaultCryptoModel DefaultCryptoModel { get; set; }
    public virtual ExtendedCryptoModel ExtendedCryptoModel { get; set; }

    // Связь "один ко многим" с TickerCryptoModel
    public virtual ICollection<TickerCryptoModel> TickerCryptoModels { get; set; }

    public CryptoModel(string name, DefaultCryptoModel? defaultCryptoModel,
        ExtendedCryptoModel? extendedCryptoModel, ICollection<TickerCryptoModel> tickerCryptoModel)
    {
        Name = name;
        DefaultCryptoModel = defaultCryptoModel;
        ExtendedCryptoModel = extendedCryptoModel;
        TickerCryptoModels = tickerCryptoModel;
    }

    public CryptoModel() { }
}

// Обратите внимание, что я удалил атрибут [Key] с DefaultCryptoModel и ExtendedCryptoModel,
// так как они будут связаны с CryptoModel через внешний ключ.
public class DefaultCryptoModel
{

    [Key] // Это PK для DefaultCryptoModel
    public int DefaultCryptoModelId { get; set; } // Используйте уникальный идентификатор для PK

    [ForeignKey("CryptoModel")] // Это FK, связывающий с CryptoModel
    public string CryptoModelName { get; set; }

    [ForeignKey("UserId")]
    public int UserId { get; set; } // ID пользователя, который добавил криптовалюту в избранное


    public string Symbol { get; set; }
    public double? CurrentPrice { get; set; }
    public string ImageUrl { get; set; }
    public double? MarketCap { get; set; }

    public bool IsFavorite { get; set; } // Новое свойство, указывающее на то, является ли запись
                                         
   



    public virtual UserModel User { get; set; }
    public virtual CryptoModel CryptoModel { get; set; }

    public DefaultCryptoModel(string symbol, double? currentPrice, string imageUrl, double? marketCap)
    {
        Symbol = symbol;
        CurrentPrice = currentPrice;
        ImageUrl = imageUrl;
        MarketCap = marketCap;
    }

    public DefaultCryptoModel() { }

}

public class ExtendedCryptoModel
{
    [Key] // Это PK для ExtendedCryptoModel
    public int ExtendedCryptoModelId { get; set; } // Используйте уникальный идентификатор для PK

    [ForeignKey("CryptoModel")] // Это FK, связывающий с CryptoModel
    public string CryptoModelName { get; set; }

    public double? PriceChangePercentage24h { get; set; }
    public double? Volume24h { get; set; }
    public double? High24h { get; set; }
    public double? Low24h { get; set; }
    public double? PriceChangePercentage7d { get; set; }
    public double? TotalSupply { get; set; }
    public double? MaxSupply { get; set; }

    public virtual CryptoModel CryptoModel { get; set; }

    public ExtendedCryptoModel(double? priceChangePercentage24h, double? volume24h, double? high24h,
        double? low24h, double? priceChangePercentage7d, double? totalSupply, double? maxSupply)
    {
        PriceChangePercentage24h = priceChangePercentage24h;
        Volume24h = volume24h;
        High24h = high24h;
        Low24h = low24h;
        PriceChangePercentage7d = priceChangePercentage7d;
        TotalSupply = totalSupply;
        MaxSupply = maxSupply;
    }
}

public class TickerCryptoModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int TickerId { get; set; }
    [ForeignKey("CryptoModel")] // Связь с CryptoModel
    public string CryptoModelName { get; set; }
    [ForeignKey("MarketCryptoModel")] // Связь с MarketCryptoModel
    public int  MarketId { get; set; }

    public string Target { get; set; }
    public decimal? LastPrice { get; set; }
    public decimal? Volume { get; set; }


    // Связи с другими сущностями, которые будут инициализированы через свойства
    public virtual MarketCryptoModel Market { get; set; }
    public virtual ConvertedLastInfo ConvertedLast { get; set; }
    public virtual ConvertedVolumeInfo ConvertedVolume { get; set; }
    public virtual CryptoModel CryptoModel { get; set; }



    // Конструктор для прямого задания полей, которые относятся к столбцам в базе данных
    public TickerCryptoModel(string target, decimal? lastPrice, decimal? volume, MarketCryptoModel marketCryptoModel, ConvertedLastInfo convertedLastInfo  , ConvertedVolumeInfo convertedVolumeInfo)
    {
        Target = target;
        LastPrice = lastPrice;
        Volume = volume;
        Market = marketCryptoModel;
        ConvertedLast = convertedLastInfo;
        ConvertedVolume = convertedVolumeInfo;

    }
    public TickerCryptoModel() { }
}



public class MarketCryptoModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Identifier { get; set; } // Уникальный идентификатор для рынка
    public string Name { get; set; }

    // Связь "один ко многим" с TickerCryptoModel
    public virtual ICollection<TickerCryptoModel> Tickers { get; set; }


}

public class ConvertedLastInfo
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ConvertedLastInfoId { get; set; } // Уникальный идентификатор для ConvertedLastInfo
    public decimal Usd { get; set; }
    // Дополнительные валютные свойства


}

public class ConvertedVolumeInfo
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ConvertedVolumeInfoId { get; set; } // Уникальный идентификатор для ConvertedVolumeInfo
    public decimal Usd { get; set; }
    // Дополнительные валютные свойства


}

