using CryptoCurrencyViewer.Interfaces;
using CryptoCurrencyViewer.Models.Crypto;
using System.ComponentModel.DataAnnotations.Schema;

namespace CryptoCurrencyViewer.Models
{
    public class UserModel : IHasPassword,IHasId,IHasEmail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Surname is required")]
        [StringLength(50, ErrorMessage = "Surname cannot exceed 50 characters")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(100, ErrorMessage = "Password must be between 6 and 100 characters", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string Role { get; set; }

        public virtual ICollection<DefaultCryptoModel> DefaultCryptos { get; set; } = new List<DefaultCryptoModel>();
        // Связь "один ко многим" с SearchHistoryModel
        public virtual ICollection<SearchHistoryModel> SearchHistory { get; set; } = new List<SearchHistoryModel>();

        public virtual ICollection<ExchangeHistoryModel> ExchangeHistory { get; set; } = new List<ExchangeHistoryModel>();


    }
}
