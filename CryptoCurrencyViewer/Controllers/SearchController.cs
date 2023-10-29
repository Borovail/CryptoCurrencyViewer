using CryptoCurrencyViewer.Interfaces;
using CryptoCurrencyViewer.Models;
using Microsoft.AspNetCore.Mvc;

namespace CryptoCurrencyViewer.Controllers
{
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
    }
}
