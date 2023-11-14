using CryptoCurrencyViewer.Interfaces;
using CryptoCurrencyViewer.Models.Crypto;
using CryptoCurrencyViewer.Models.MainPagesModels;
using CryptoCurrencyViewer.Services;
using System.Security.Claims;

namespace CryptoCurrencyViewer.Controllers;

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

        var btc = await _apiService.GetFullCryptoInfoByNameAsync("bitcoin");

        return View(btc);

        }


        

       
        [HttpGet]
        ///////function to load this page from main page with selected crypto
        public async Task<IActionResult> ExtendedInfo([FromQuery] CryptoRequestModel cryptoName)
        {
        var btc = await _apiService.GetFullCryptoInfoByNameAsync(cryptoName.selectedCrypto.ToLower());

        return View("Search", btc);
    }


    [Authorize]
        [HttpPost]
        //// func to search crypto by searching field on the search page
        public async Task<JsonResult> SearchCrypto([FromBody] CryptoRequestModel selectedCrypto)
        {
            var crypto = await _apiService.GetFullCryptoInfoByNameAsync(selectedCrypto.selectedCrypto);

            return Json(crypto);
        }


        [HttpPost]
        //////for saving element to db
        public async Task SaveSearchHistory([FromBody] string cryptoName)
        {
       
        SearchHistoryModel history = new SearchHistoryModel();

        history.CryptoModelName = cryptoName;

        await _dbService.AddItemAsync(history);
    }


       [Authorize]
        [HttpGet]
        /////for initialization history
        public async Task<List<SearchHistoryModel>> GetSearchHistory()
        {
  
        var user = await _dbService.GetUserByIdAsync(AppHelper.GetCurrentUserId(User));

        var historyList  = user.SearchHistory.ToList();

        return historyList;

        }


    //[HttpGet]
    ///////func for getting crypto by name from the search history table  // called from js by  restoreCryptoFromHistory
    //public async Task<IHasName> GetCryptoFromHystoryByNameAsync(string cryptoName)
    //{
    //    //return await _dbService.GetItemByNameAsync<IHasName>(cryptoName);
    //}


    [Authorize]
    [HttpPost]
       ///mark as favourite
        public async Task MarkAsFavourite([FromBody] CryptoModel crypto)
        {

        var tempCrypto = await _dbService.GetItemByNameAsync<DefaultCryptoModel>(crypto.Name);

        if(tempCrypto == null)
        {

       AppHelper.MakeCorrectFormat(crypto, AppHelper.GetCurrentUserId(User));

        crypto.DefaultCryptoModel.IsFavorite=true;

          await  _dbService.AddItemAsync(crypto);
        }
        else
        {
            tempCrypto.IsFavorite = true;

            await _dbService.UpdateItemAsync(tempCrypto);
        }



    }


}

