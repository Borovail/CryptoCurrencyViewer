using CryptoCurrencyViewer.Interfaces;
using CryptoCurrencyViewer.Models.Crypto;
using CryptoCurrencyViewer.Models.MainPagesModels;


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
        //var btc = await _apiService.GetFullCryptoInfoByNameAsync("bitcoin");

        //return View(btc);

        return View();
        }


       
        [HttpPost]
        ///////function to load this page from main page with selected crypto
        public async Task<IActionResult> ExtendedInfo([FromQuery] CryptoRequestModel cryptoName)
        {
            //var btc = await _apiService.GetFullCryptoInfoByNameAsync(cryptoName.selectedCrypto.ToLower());

            //return View("Search", btc);
            return View("Search");
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
             await _dbService.AddItemAsync(crypto);
        }


    [Authorize]
        [HttpGet]
        /////for initialization history
        public async Task<List<CryptoModel>> GetSearchHistory()
        {
            //return await _dbService.GetAllItemsAsync<CryptoModel>();

        return null;
        }


        [HttpGet]
        /////func for getting crypto by name from the search history table  // called from js by  restoreCryptoFromHistory
        public async Task<ICryptoModel> GetCryptoFromHystoryByNameAsync(string cryptoName)
        {
            return await _dbService.GetItemByNameAsync<ICryptoModel>(cryptoName);
        }
       

        [HttpPost]
        //////func  for  save crypto in main table for main page
        public async Task AddCryptoToMain([FromBody] SearchHistoryModel crypto)
        {
            /////need  to save in CryptoList
            await _dbService.AddItemAsync(crypto);
        }

    }

