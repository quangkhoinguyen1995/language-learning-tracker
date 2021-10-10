using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace language_learning_tracker.Language_Data
{
    public class ImmersionMedia
    {
        [Key]
        public int MediaID { get; set; }

        [Required]
        public string MediaName { get; set; }
        [Required]
        public string MediaType { get; set; }
        public TimeSpan TotalImmersionTimes { get; set; }

        public ImmersionMedia() { }
        public ImmersionMedia(string name)
        {
            MediaName = name;
        }

        public int LanguageID { get; set; }
        public virtual LanguageList Language { get; set; }

        public virtual ICollection<LanguageActivity> LanguageActivities { get; private set; }
        = new ObservableCollection<LanguageActivity>();
    }
}
