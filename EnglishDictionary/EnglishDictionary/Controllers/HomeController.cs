using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EnglishDictionary.Models;
using Microsoft.AspNetCore.Authorization;

namespace EnglishDictionary.Controllers
{
    public class HomeController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult _Layout()
        {
            return View();
        }
    }
}
