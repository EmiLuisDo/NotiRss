using Microsoft.EntityFrameworkCore;
using NotiRss.Models.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotiRss.Services.LocalDataAccess.Impl
{
    public class MBodyNewDB : IMBodyNewDB
    {
        private string dbpath;
        public MBodyNewDB(string path) 
        {
            this.dbpath = path;
        }
        public async Task Init()
        {
            throw new NotImplementedException();
        }
        public async Task Add(MBodyNew mBodyNew)
        {
            using (NewContext nwc = new NewContext(this.dbpath))
            {
                nwc.Add(mBodyNew);
                await nwc.SaveChangesAsync();
            }
        }

        public async Task<MBodyNew> Get(int id)
        {
            List<MBodyNew> bodys;
            using (NewContext nwc = new NewContext(this.dbpath))
            {
                bodys = nwc.Bodys
                 .Where(p => p.Id == id)
                 .ToList();
            }
                return bodys[0];
        }
        public async Task Remove(MBodyNew bodyNew)
        {
            using (NewContext nwc = new NewContext(this.dbpath))
            {
                nwc.Bodys.Remove(bodyNew);
                Task t = nwc.SaveChangesAsync();
            }
        }
        public async Task<List<MBodyNew>> GetAll()
        {
            List<MBodyNew> bodys;
            using (NewContext nwc = new NewContext(this.dbpath))
            {
                bodys = await nwc.Bodys.ToListAsync();
            }
            return bodys;
        }
    }
}
