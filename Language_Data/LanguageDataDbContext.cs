using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace language_learning_tracker.Language_Data
{
    public class LanguageDataDbContext : DbContext
    {
        public DbSet<LanguageList> language { get; set; }
        public DbSet<LanguageActivity> languageActivities { get; set; }
        public DbSet<ImmersionMedia> immersionMedia { get; set; }

        public string DbPath { get; private set; }

        public LanguageDataDbContext()
        {
            DbPath = @"./Language_Data/Language_Data.db";
        }
    }
}
