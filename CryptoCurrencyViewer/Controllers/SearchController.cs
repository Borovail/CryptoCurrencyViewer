using CryptoCurrencyViewer.Interfaces;
using CryptoCurrencyViewer.Models.Crypto;
using CryptoCurrencyViewer.Models.MainPagesModels;
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


        

       
        [HttpPost]
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
        public async Task SaveSearchHistory([FromBody] CryptoModel crypto)
        {

        var btc = await _apiService.GetFullCryptoInfoByNameAsync("bitcoin");

        var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);

        int userId = int.Parse(userIdClaim.Value);

        btc.DefaultCryptoModel.UserId = userId;



        //await _dbService.AddItemAsync(crypto);
        }


    [Authorize]
        [HttpGet]
        /////for initialization history
        public async Task<List<CryptoModel>> GetSearchHistory()
        {
            //return await _dbService.GetAllItemsAsync<CryptoModel>();

        return null;
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
        var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);

        int userId = int.Parse(userIdClaim.Value);

        crypto.DefaultCryptoModel.UserId=userId;

        crypto.DefaultCryptoModel.IsFavorite=true;

        await   _dbService.AddCryptoAsync(crypto);

        }


}

