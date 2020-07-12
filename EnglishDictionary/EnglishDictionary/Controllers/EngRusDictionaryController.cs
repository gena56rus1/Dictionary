using EnglishDictionary.Data;
using EnglishDictionary.Models;

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EnglishDictionary.Controllers
{
    //англо-русский словарь
    [Route("~/Dictionary/EngRusDictionary/")]
    public class EngRusDictionaryController : Controller
    {
        
        private MyDbContext db;
        public EngRusDictionaryController(MyDbContext context)
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
            EngRusDictionaryModel model = new EngRusDictionaryModel();
        
            if(Word != null)
            {
                model = await db.EngRusDictionary.FirstOrDefaultAsync(Eng => Eng.Word == Word); ;
                return RedirectToAction("ResultOfSearch", "EngRusDictionary", model);
            }
            return RedirectToAction("Index", "Home");

        }

        [HttpGet]
        [Route("~/Dictionary/EngRusDictionary/ResultOfSearch/")]
        public IActionResult ResultOfSearch(EngRusDictionaryModel model)
        {
            return View(model);
        }
    }
}
