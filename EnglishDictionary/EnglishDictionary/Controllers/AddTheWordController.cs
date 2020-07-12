using EnglishDictionary.Data;
using EnglishDictionary.ViewModels;
using EnglishDictionary.Models;

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnglishDictionary.Controllers
{
    public class AddTheWordController : Controller
    {
        public MyDbContext db;
        public AddTheWordController(MyDbContext context)
        {
            db = context;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddEngExplanatoryDictionary(EngExplanatoryDictionaryModel model)
        {
            EngExplanatoryDictionaryModel eng = db.EngExplanatoryDictionaries.FirstOrDefault(dictionary => dictionary.Word == model.Word);
            if(eng == null)
            {
                model.UserId = db.Users.FirstOrDefault(u => u.Login == User.Identity.Name).Id; 
                db.EngExplanatoryDictionaries.Add(model);
                await db.SaveChangesAsync();
                return RedirectToAction("Add", "AddTheWord");
            }
            return Content($"this {model.Word} is available"); 
        }
        
        [HttpPost]
        public async Task<IActionResult> AddEngRusDictionary(EngRusDictionaryModel model)
        {
            EngRusDictionaryModel eng = db.EngRusDictionary.FirstOrDefault(dictionary => dictionary.Word == model.Word);
            if (eng == null)
            {
                model.UserId = db.Users.FirstOrDefault(u => u.Login == User.Identity.Name).Id;
                db.EngRusDictionary.Add(model);
                await db.SaveChangesAsync();
                return RedirectToAction("Add", "AddTheWord");
            }
            return Content($"this {model.Word} is available");
        }

        [HttpPost]
        public async Task<IActionResult> AddRusExplanatoryDictionary(RusExplanatoryDictionaryModel model)
        {
            RusExplanatoryDictionaryModel rus = db.RusExplanatoryDictionaries.FirstOrDefault(dictionary => dictionary.Word == model.Word);
            if (rus == null)
            {
                model.UserId = db.Users.FirstOrDefault(u => u.Login == User.Identity.Name).Id;
                db.RusExplanatoryDictionaries.Add(model);
                await db.SaveChangesAsync();
                return RedirectToAction("Add", "AddTheWord");
            }
            return Content($"this {model.Word} is available");
        }

        [HttpPost]
        public async Task<IActionResult> AddRusEngDictionary(RusEngDictionaryModel model)
        {
            RusEngDictionaryModel rus = db.RusEngDictionary.FirstOrDefault(dictionary => dictionary.Word == model.Word);
            if (rus == null)
            {
                model.UserId = db.Users.FirstOrDefault(u => u.Login == User.Identity.Name).Id;
                db.RusEngDictionary.Add(model);
                await db.SaveChangesAsync();
                return RedirectToAction("Add", "AddTheWord");
            }
            return Content($"this {model.Word} is available");
        }
    }
}
