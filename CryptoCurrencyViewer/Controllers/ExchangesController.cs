﻿using Microsoft.AspNetCore.Mvc;

namespace CryptoCurrencyViewer.Controllers
{
    public class ExchangesController : Controller
    {
        public IActionResult Exchanges()
        {
            return View();
        }
    }
}