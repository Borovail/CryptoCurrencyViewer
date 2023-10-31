using CryptoCurrencyViewer.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace CryptoCurrencyViewer.Models
{
    public class SearchHistoryModel : ICryptoModel
    {
        [Key]
        public string Name {  get; set; }
    }
}
