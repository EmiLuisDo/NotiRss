using NotiRss.Models.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using System.IO;
using Xamarin.Essentials;

namespace NotiRss.Services.LocalDataAccess.Impl
{
    public class MNewDB : IMNewDB
    {
        public SQLiteAsyncConnection DBcon{ get; set; }

        public string DBpath { get; set; }

        public MNewDB(string databasePath)
        {
            DBpath = databasePath;
        }
        public async Task Init()
        {
            if (DBcon != null) return;

            DBcon = new SQLiteAsyncConnection(DBpath);

            await DBcon.CreateTableAsync<MNew>();
        }
        public async Task Add(MNew mNew)
        {
            await Init();

            Task<int> id = DBcon.InsertAsync(mNew);
        }

        public async Task<MNew> Get(int id)
        {
            await Init();

            MNew mnew = await DBcon.GetAsync<MNew>(id);

            return mnew;
        }
        public async Task Remove(MNew mnew)
        {
            await Init();

            await DBcon.DeleteAsync(mnew);
        }
        public async Task<IEnumerable<MNew>> GetAll()
        {
            await Init();

            List<MNew> mnews = await DBcon.Table<MNew>().ToListAsync();

            return mnews;
        }
    }
}
