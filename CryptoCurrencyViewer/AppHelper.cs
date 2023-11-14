using CryptoCurrencyViewer.Models.Crypto;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace CryptoCurrencyViewer
{
    public class AppHelper
    {

        public static string HashPassword(string inputString)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(inputString));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public static void MakeCorrectFormat(CryptoModel cryptoModel,int userId)
        {
            cryptoModel.UserId = userId;

            cryptoModel.DefaultCryptoModel.CryptoModelName = cryptoModel.Name;
            cryptoModel.ExtendedCryptoModel.CryptoModelName = cryptoModel.Name;

            foreach (var tickerData in cryptoModel.TickerCryptoModels)
            {
                tickerData.CryptoModelName = cryptoModel.Name;
            }
           
        }

        public static int GetCurrentUserId(ClaimsPrincipal user)
        {
            var userIdClaim = user.FindFirst(ClaimTypes.NameIdentifier);

            int userId = int.Parse(userIdClaim.Value);

            return userId;
        }

    }
}
