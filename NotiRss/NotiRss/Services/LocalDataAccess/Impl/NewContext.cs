using Microsoft.EntityFrameworkCore;
using NotiRss.Models.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace NotiRss.Services.LocalDataAccess.Impl
{
    public class NewContext : DbContext
    {
        private string dbpath;
        public DbSet<MNew> News { get; set; }
        public DbSet<MBodyNew> Bodys { get; set; }

        public NewContext(string path) 
        {
            this.dbpath = path;
            SQLitePCL.Batteries_V2.Init();
            this.Database.EnsureCreated();
        }
        public NewContext()
        {
            SQLitePCL.Batteries_V2.Init();
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, this.dbpath);
            optionsBuilder
                .UseSqlite($"Filename={dbPath}");
        }
    }
}
