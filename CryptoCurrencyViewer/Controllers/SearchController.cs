using CryptoCurrencyViewer.Interfaces;
using CryptoCurrencyViewer.Models;
using CryptoCurrencyViewer.Models.MainPagesModels;
using CryptoCurrencyViewer.Services;
using Microsoft.AspNetCore.Mvc;

namespace CryptoCurrencyViewer.Controllers
{
    [Controller]
    public class SearchController : Controller
    {
        private readonly IApiService _apiService;
        private readonly IDbService _dbService;


        public SearchController(IApiService cryptoService, IDbService dbService)
        {
            _apiService = cryptoService;
            _dbService = dbService;
        }



        public async Task<IActionResult> Search()
        {
            var btc = await _apiService.GetCryptoInfoByNameAsync("bitcoin");

            return View(btc);
        }
        public async Task<IActionResult> ExtendedInfo([FromQuery] CryptoRequestModel cryptoName)
        {
            var btc = await _apiService.GetCryptoInfoByNameAsync(cryptoName.selectedCrypto.ToLower());

            return View("Search",btc);
        }

        [HttpPost]
        public async Task<JsonResult> SearchCrypto([FromBody] CryptoRequestModel selectedCrypto)
        {
            var crypto = await _apiService.GetCryptoInfoByNameAsync(selectedCrypto.selectedCrypto);

            return Json(crypto);
        }


        [HttpPost]
        public async Task SaveSearchHistory([FromBody] SearchHistoryModel crypto)
        {
             await _dbService.AddItemAsync(crypto);
        }


        [HttpPost]
        public async Task AddCryptoToMain([FromBody] SearchHistoryModel crypto)
        {

            ////нужно внести под общий интерфейс или клас что бы 
            ////можна было указывать так и передавать не фул инфу а токо модель истории

            //await _dbService.AddItemAsync<CryptoModel>(crypto);
           


            ///сделать миграцию

            
        }

    }
}
