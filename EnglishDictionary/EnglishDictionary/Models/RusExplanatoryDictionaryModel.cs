using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnglishDictionary.Models
{
    public class RusExplanatoryDictionaryModel
    {
        public int Id { get; set; }
        public string Word { get; set; }
        public string Interpretation { get; set; }
        public int UserId { get; set; }
    }
}
