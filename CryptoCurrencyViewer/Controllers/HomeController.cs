using CryptoCurrencyViewer.Interfaces;
using CryptoCurrencyViewer.Models;
using CryptoCurrencyViewer.Models.Crypto;
using CryptoCurrencyViewer.Models.MainPagesModels;
using CryptoCurrencyViewer.Services;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace CryptoCurrencyViewer.Controllers;

public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IApiService _apiService;
        private readonly IDbService _dbService;
        public HomeController(ILogger<HomeController> logger, IDbService dbService, IApiService apiService)
        {
            _logger = logger;
            _dbService = dbService;
            _apiService = apiService;
        }

    public async Task<IActionResult> Index()
    {
       
      var favorites=  (await _dbService.GetAllItemsAsync<DefaultCryptoModel>()).Where(i=>i.IsFavorite).ToList();

        return View(favorites);

    }


  


    /// нужно попробывать вынести реализации в services    и бдшки  и апишки   так  как с рассылкой сделано
    /// </summary>
    /// <param name="selectedCrypto"></param>
    /// <returns></returns>
    [HttpPost]
    [Authorize]
    public async Task<JsonResult> UpdateSelectedCrypto([FromBody] string selectedCrypto)
        {
   
       var updatedCrypto = await _apiService.GetDefaultCryptoInfoByNameAsync(selectedCrypto);

        ///может рил стоит   обєденить методы в сервисе
        var crypto = await _dbService.GetItemByNameAsync<DefaultCryptoModel>(selectedCrypto);

        crypto.CurrentPrice = updatedCrypto.CurrentPrice;
        crypto.MarketCap = updatedCrypto.MarketCap;

        await _dbService.UpdateItemAsync(crypto);

        return Json(new { currentPrice= crypto.CurrentPrice, marketCap= crypto.MarketCap} );
        }


    ///нужно попробывать вынести реализации в services    и бдшки  и апишки   так  как с рассылкой сделано
    [Authorize]
    [HttpPost]
        public async Task<JsonResult> DeleteSelectedCrypto([FromBody]string cryptoName)
        {

        string message = string.Empty;

        try
        {
                var selectedCrypto =await _dbService.GetItemByNameAsync<DefaultCryptoModel>(cryptoName);
                selectedCrypto.IsFavorite = false;
                await _dbService.UpdateItemAsync(selectedCrypto);
        }
        catch(DbUpdateException ex)
        {
            message = ex.Message;
        }
        catch (Exception ex)
        {
            message = ex.Message;
        }


            return Json(new { message = message });
        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
