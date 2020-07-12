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
    [Route("~/Dictionary/EngExplanatoryDictionary/")]
    public class EngExplanatoryDictionaryController : Controller
    {
        private MyDbContext db;
        public EngExplanatoryDictionaryController(MyDbContext context)
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
            EngExplanatoryDictionaryModel model = new EngExplanatoryDictionaryModel();

            if (Word != null)
            {
                model = await db.EngExplanatoryDictionaries.FirstOrDefaultAsync(Eng => Eng.Word == Word);
                return RedirectToAction("ResultOfSearch", "EngExplanatoryDictionary", model);
            }
            return RedirectToAction("Index", "Home");

        }

        [HttpGet]
        [Route("~/Dictionary/EngExplanatoryDictionary/ResultOfSearch/")]
        public IActionResult ResultOfSearch(EngExplanatoryDictionaryModel model)
        {
            return View(model);
        }
    }
}
