using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EnglishDictionary.ViewModels
{
    public class AddWordDictionaryModel
    {
        public AddDictionary dictionary { get; set; }  
    }
    public enum AddDictionary
    {
        [Display(Name = "EngRusDictionary")]
        EngRusDictionary,
        [Display(Name = "RusEngDictionary")]
        RusEngDictionary,
        [Display(Name = "EngExplanatoryDictionary")]
        EngExplanatoryDictionary,
        [Display(Name = "RusExplanatoryDictionary")]
        RusExplanatoryDictionary
    }
}
