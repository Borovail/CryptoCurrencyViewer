using CryptoCurrencyViewer.Interfaces;
using CryptoCurrencyViewer.Models;
using Microsoft.AspNetCore.Mvc;

namespace CryptoCurrencyViewer.Controllers
{
    public class SearchController : Controller
    {
        private readonly ICryptoService _cryptoService;

        public SearchController(ICryptoService cryptoService)
        {
            _cryptoService = cryptoService;
        }

        public async Task< IActionResult> Search()
        {
            var btc = await _cryptoService.GetCryptoInfoAsync();
            btc.AddRange( await _cryptoService.GetCryptoInfoAsync());

            return View(btc);
        }
    }
}
