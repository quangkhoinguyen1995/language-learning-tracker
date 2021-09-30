using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace language_learning_tracker.Languages_List
{
    class LanguageList
    {
        public string LanguageName;
        public string DataFilePath;
        public LanguageList(string langName, string langDataFilePath)
        {
            LanguageName = langName;
            DataFilePath = langDataFilePath;
        }
    }
}
