using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;

namespace language_learning_tracker.Language_Data
{
    public class LanguageList
    {
        [Key]
        public int LanguageID { get; set; }

        [Required]
        public string LanguageName { get; set; }

        public LanguageList()
        {

        }
        public LanguageList(string langName)
        {
            LanguageName = langName;
        }

        public virtual ICollection<LanguageActivity> LanguageActivities { get; private set; }
        = new ObservableCollection<LanguageActivity>();
    }
}
