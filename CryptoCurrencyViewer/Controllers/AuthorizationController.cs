﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CryptoCurrencyViewer.Controllers
{
    public class AuthorizationController : Controller
    {
        // GET: AuthorizationController
        public ActionResult Register()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Logout()
        {
            return View();
        }

        // GET: AuthorizationController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AuthorizationController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AuthorizationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AuthorizationController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AuthorizationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AuthorizationController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AuthorizationController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
