using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnglishDictionary.Controllers
{
    [Route("~/Dictionary/EngExplanatoryDictionary/")]
    public class EngExplanatoryDictionaryController : Controller
    {
        public IActionResult EngExplanatoryDictionary()
        {
            return View();
        }
    }
}
