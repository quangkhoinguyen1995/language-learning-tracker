using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace language_learning_tracker.Language_Data
{
    public class LanguageList
    {
        public int LanguageID { get; set; }
        public string LanguageName { get; set; }
        public LanguageList(string langName)
        {
            LanguageName = langName;
        }
    }
}
