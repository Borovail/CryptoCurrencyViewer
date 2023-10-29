using CryptoCurrencyViewer.Interfaces;
using CryptoCurrencyViewer.Models;
using CryptoCurrencyViewer.Models.MainPagesModels;
using Microsoft.AspNetCore.Mvc;

namespace CryptoCurrencyViewer.Controllers
{
    [Controller]
    public class SearchController : Controller
    {
        private readonly IApiService _apiService;

        public SearchController(IApiService cryptoService)
        {
            _apiService = cryptoService;
        }


        
        public async Task< IActionResult> Search()
        {
            var btc = await _apiService.GetCryptoInfoByNameAsync("bitcoin");

            return View(btc);
        }

        [HttpPost]
        public async Task<JsonResult> SearchCrypto([FromBody] CryptoRequestModel selectedCrypto)
        {
            var crypto = await _apiService.GetCryptoInfoByNameAsync(selectedCrypto.selectedCrypto);

            return Json(crypto);
        }
    }
}
