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
            model = await db.EngExplanatoryDictionaries.FirstOrDefaultAsync(Eng => Eng.Word == Word);
            if (model != null)
            {
                return RedirectToAction("ResultOfSearch", "EngExplanatoryDictionary", model);
            }
            return Content($"{Word} is not found");
        }

        [HttpGet]
        [Route("~/Dictionary/EngExplanatoryDictionary/ResultOfSearch/")]
        public IActionResult ResultOfSearch(EngExplanatoryDictionaryModel model)
        {
            return View(model);
        }
    }
}
