using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnglishDictionary.Controllers
{

    [Route("~/Dictionary/EngRusDictionary/")]
    public class EngRusDictionaryController : Controller
    {
        //англо-русский словарь
        [HttpGet]
        public IActionResult EngRusDictionary()
        {
            return View();
        }
    }
}
