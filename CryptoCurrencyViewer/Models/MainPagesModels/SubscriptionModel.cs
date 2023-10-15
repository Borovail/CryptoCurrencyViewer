using System.ComponentModel.DataAnnotations;

namespace CryptoCurrencyViewer.Models.MainPagesModels
{
    public class SubscriptionModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
