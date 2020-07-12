using EnglishDictionary.Data;
using EnglishDictionary.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace EnglishDictionary.Controllers
{
    [Route("~/Dictionary/RusEngDictionary/")]
    public class RusEngDictionaryController : Controller
    {
        private MyDbContext db;
        public RusEngDictionaryController(MyDbContext context)
        {
            db = context;
        }

        [HttpGet]
        public IActionResult SearchWord()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SearchWord(string Word)
        {
            RusEngDictionaryModel model = new RusEngDictionaryModel();

            if (Word != null)
            {
                model = await db.RusEngDictionary.FirstOrDefaultAsync(Rus => Rus.Word == Word); ;
                return RedirectToAction("ResultOfSearch", "RusEngDictionary", model);
            }
            return RedirectToAction("Index", "Home");

        }

        [HttpGet]
        [Route("~/Dictionary/RusEngDictionary/ResultOfSearch/")]
        public IActionResult ResultOfSearch(RusEngDictionaryModel model)
        {
            return View(model);
        }

    }
}
