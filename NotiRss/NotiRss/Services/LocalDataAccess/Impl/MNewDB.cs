using NotiRss.Models.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Xamarin.Essentials;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace NotiRss.Services.LocalDataAccess.Impl
{
    public class MNewDB : IMNewDB
    {
        private string dbpath;
        public MNewDB(string path) 
        {
            this.dbpath = path;
        }
        public async Task Init()
        {
            throw new NotImplementedException();
        }
        public async Task Add(MNew mNew)
        {
            using (NewContext nwc = new NewContext(this.dbpath))
            {
                nwc.Add(mNew);
                await nwc.SaveChangesAsync();
            }
        }

        public async Task<MNew> Get(int id)
        {
            List<MNew> nws;
            using (NewContext nwc = new NewContext(this.dbpath))
            {
                nws = nwc.News
                   .Where(p => p.Id == id)
                   .ToList();
            }
            return nws.FirstOrDefault();
        }
        public async Task Remove(MNew mnew)
        {
            using (NewContext nwc = new NewContext(this.dbpath))
            {
                nwc.News.Remove(mnew);
                Task t = nwc.SaveChangesAsync();
            }
        }
        public async Task<List<MNew>> GetAll()
        {
            List<MNew> news;
            using (NewContext nwc = new NewContext(this.dbpath))
            {
                news = await nwc.News.ToListAsync();
            }
            return news;
        }
    }
}
