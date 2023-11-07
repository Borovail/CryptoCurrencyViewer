﻿

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
        var crypto=  (await _apiService.GetFullCryptoInfoByNameAsync("bitcoin"));

            return View(crypto);
        }
    }
}
