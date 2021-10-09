using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace language_learning_tracker.Language_Data
{
    public class LanguageActivity
    {
        [Key]
        public int ActivityID { get; set; }
        public DateTime ActivityDate { get; set; }
        public string ActivityType { get; set; }
        public TimeSpan TimeTaken { get; set; }

        public int LanguageID { get; set; }
        public virtual LanguageList Language { get; set; }

        public int MediaID { get; set; }
        public virtual ICollection<ImmersionMedia> ImmersionMediaDB { get; private set; }
        = new ObservableCollection<ImmersionMedia>();
    }
}
