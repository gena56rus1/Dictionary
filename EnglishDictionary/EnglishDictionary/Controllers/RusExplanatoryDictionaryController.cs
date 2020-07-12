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

            if (Word != null)
            {
                model = await db.RusExplanatoryDictionaries.FirstOrDefaultAsync(Rus => Rus.Word == Word);
                return RedirectToAction("ResultOfSearch", "RusExplanatoryDictionary", model);
            }
            return RedirectToAction("Index", "Home");

        }

        [HttpGet]
        [Route("~/Dictionary/RusExplanatoryDictionary/ResultOfSearch/")]
        public IActionResult ResultOfSearch(RusExplanatoryDictionaryModel model)
        {
            return View(model);
        }

    }
}
