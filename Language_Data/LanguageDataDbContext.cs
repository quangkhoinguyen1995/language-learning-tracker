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
        public DbSet<LanguageList> Language { get; set; }
        public DbSet<LanguageActivity> LanguageActivities { get; set; }
        public DbSet<ImmersionMedia> ImmersionMediaDB { get; set; }

        public string DbPath { get; private set; }

        public LanguageDataDbContext()
        {
            DbPath = @"./Language_Data/Language_Data.db";
        }

        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source ={DbPath}");
            optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }
    }
}
