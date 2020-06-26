using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnglishDictionary.Controllers
{
    [Route("~/Dictionary/RusExplanatoryDictionary/")]
    public class RusExplanatoryDictionaryController : Controller
    {
        public IActionResult RusExplanatoryDictionary()
        {
            return View();
        }
    }
}
