﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Pathos.Models;
using Pathos.Models.Settings;
using Microsoft.Extensions.Options;

namespace Pathos.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppSettings _settings;
        private readonly AppSecrets _secrets;

        public HomeController(IOptions<AppSettings> settings, IOptions<AppSecrets> secrets)
        {
            this._settings = settings.Value;
            this._secrets = secrets.Value;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = $"Your DB connection string for the {_settings.Environment} environment is {_secrets.PathosConnectionString}.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
