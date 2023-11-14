using System.ComponentModel.DataAnnotations.Schema;

namespace CryptoCurrencyViewer.Models.Crypto
{
    public class ExchangeHistoryModel
    {
        [Key]
        public int Id { get; set; } // Уникальный идентификатор для истории поиска

        [ForeignKey("UserId")]
        public int UserId { get; set; } // Уникальный идентификатор для истории поиска
        [ForeignKey("CryptoModelName")]
        public string CryptoModelName { get; set; } // Название криптовалюты для связи с CryptoModel
        public DateTime SearchTime { get; set; } // Время поиска


        public virtual UserModel User { get; set; }

        public virtual CryptoModel Crypto { get; set; }



        public ExchangeHistoryModel()
        {
            SearchTime = DateTime.Now;
        }

    }
}
