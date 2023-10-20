using System.ComponentModel.DataAnnotations;

namespace CryptoCurrencyViewer.Models.MainPagesModels
{
    public class SubscriberModel
    {
         public int Id { get; set; }


        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public bool IsSubscribed { get; set; }
    }
}
