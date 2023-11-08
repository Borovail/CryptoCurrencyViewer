using System.ComponentModel.DataAnnotations.Schema;

namespace CryptoCurrencyViewer.Models.Crypto
{
    public class ExchangeHistoryModel
    {
        [Key]
        public int Id { get; set; } // Уникальный идентификатор для истории поиска
        public int UserId { get; set; } // ID пользователя для связи с таблицей пользователей
        public string CryptoModelName { get; set; } // Название криптовалюты для связи с CryptoModel
        public DateTime SearchTime { get; set; } // Время поиска

        // Связи с другими моделями
        [ForeignKey("UserId")]
        public virtual UserModel User { get; set; }

        [ForeignKey("CryptoModelName")]
        public virtual CryptoModel Crypto { get; set; }



        public ExchangeHistoryModel()
        {
            SearchTime = DateTime.Now;
        }

    }
}
