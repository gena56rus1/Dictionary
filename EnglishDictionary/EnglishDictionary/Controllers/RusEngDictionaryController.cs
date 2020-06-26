using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnglishDictionary.Controllers
{
    [Route("~/Dictionary/RusEngDictionary/")]
    public class RusEngDictionaryController : Controller
    {
        [HttpGet]
        public IActionResult e()
        {
            return View();
        }
    }
}
