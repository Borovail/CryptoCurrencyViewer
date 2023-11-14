

using CryptoCurrencyViewer.Interfaces;
using CryptoCurrencyViewer.Models.Crypto;

namespace CryptoCurrencyViewer.Controllers
{
  
    public class ExchangesController : Controller
    {
        private readonly IDbService _dbService;
        private readonly IApiService _apiService;
        public ExchangesController(IDbService dbService, IApiService apiService )
        { 
            _dbService = dbService;
            _apiService = apiService;
        }


        public async Task<IActionResult> Exchanges()
        {
        var crypto=  (await _apiService.GetFullCryptoInfoByNameAsync("bitcoin")).TickerCryptoModels;

            return View(crypto);
        }


        [HttpGet]
        public  async Task<IActionResult> ExchangeFrom([FromQuery]string cryptoName)
        { 
            var crypto = await _dbService.GetCryptoWithDetailsAsync(cryptoName);

            return View("Exchanges",crypto.TickerCryptoModels);
        }
    }
}
