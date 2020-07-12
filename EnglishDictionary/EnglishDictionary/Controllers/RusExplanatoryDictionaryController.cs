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
    [Route("~/Dictionary/RusExplanatoryDictionary/")]
    public class RusExplanatoryDictionaryController : Controller
    {
        private MyDbContext db;
        public RusExplanatoryDictionaryController(MyDbContext context)
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
            RusExplanatoryDictionaryModel model = new RusExplanatoryDictionaryModel();
            model = await db.RusExplanatoryDictionaries.FirstOrDefaultAsync(Rus => Rus.Word == Word);
            if (model != null)
            {
                return RedirectToAction("ResultOfSearch", "RusExplanatoryDictionary", model);
            }
            return Content($"{Word} is not found");

        }

        [HttpGet]
        [Route("~/Dictionary/RusExplanatoryDictionary/ResultOfSearch/")]
        public IActionResult ResultOfSearch(RusExplanatoryDictionaryModel model)
        {
            return View(model);
        }

    }
}
