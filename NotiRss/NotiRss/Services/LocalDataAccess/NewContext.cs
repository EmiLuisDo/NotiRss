using Microsoft.EntityFrameworkCore;
using NotiRss.Models.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace NotiRss.Services.LocalDataAccess
{
    public class NewContext : DbContext
    {
        public DbSet<MNew> News { get; set; }
        public DbSet<MBodyNew> Bodys { get; set; }

        public NewContext()
        {
            SQLitePCL.Batteries_V2.Init();
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "NEWS.db3");
            optionsBuilder
                .UseSqlite($"Filename={dbPath}");
        }

        public async Task AddNew(MNew mNew)
        {
            this.Add(mNew);
            await this.SaveChangesAsync();
        }
        public async Task AddBody(MBodyNew mBodyNew)
        {
            this.Add(mBodyNew);
            await this.SaveChangesAsync();
        }

        public async Task<MNew> GetNew(int id)
        {
             List<MNew> nws = this.News
                .Where(p => p.Id == id)
                .ToList();
            return nws[0];
        }
        public async Task<MBodyNew> GetBody(int id)
        {
            List<MBodyNew> bodys = this.Bodys
              .Where(p => p.Id == id)
              .ToList();
            return bodys[0];

        }
        public async Task RemoveNew(MNew nw)
        {
            this.News.Remove(nw);
            Task t = this.SaveChangesAsync();
        }
        public async Task RemoveBody(MBodyNew body)
        {
            this.Bodys.Remove(body);
            Task t = this.SaveChangesAsync();
        }
        public async Task<List<MBodyNew>> GetAllBodys()
        {
            List<MBodyNew> bodys = await this.Bodys.ToListAsync();
            return bodys;
        }
        public async Task<IEnumerable<MNew>> GetAllNews()
        {
            List<MNew> news = await this.News.ToListAsync();
            return news;
        }
    }
}
