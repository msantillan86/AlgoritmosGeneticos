using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MonkeysAG;
using MonkeysTheoremWeb.Models;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading;
using static MonkeysAG.MonkeyParameters;

namespace MonkeysTheoremWeb.Controllers
{
    public class AboutController : Controller
    {
        private readonly ILogger<AboutController> _logger;

        public AboutController(ILogger<AboutController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
