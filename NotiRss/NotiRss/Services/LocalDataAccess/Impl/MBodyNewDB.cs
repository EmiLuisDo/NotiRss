using NotiRss.Models.Data;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace NotiRss.Services.LocalDataAccess.Impl
{
    public class MBodyNewDB : IMBodyNewDB
    {
        public SQLiteAsyncConnection DBcon { get; set; }
        public String DBpath { get; set; }

        public MBodyNewDB(string databasepath) 
        {
            DBpath = databasepath;        
        }
        public async Task Init()
        {
            if (DBcon != null) return;

            DBcon = new SQLiteAsyncConnection(DBpath);

            await DBcon.CreateTableAsync<MBodyNew>();
        }
        public async Task Add(MBodyNew mBodyNew)
        {
            await Init();

            Task<int> id = DBcon.InsertAsync(mBodyNew);
        }

        public async Task Get(int id)
        {
            await Init();

            MBodyNew bodyNew = await DBcon.GetAsync<MBodyNew>(id);

        }
        public async Task Remove(MBodyNew bodyNew)
        {
            await Init();
            await DBcon.DeleteAsync(bodyNew);
        }
        public async Task<IEnumerable<MBodyNew>> GetAll()
        {
            await Init();
            List<MBodyNew> mbodynews = await DBcon.Table<MBodyNew>().ToListAsync();
            return mbodynews;
        }
    }
}
