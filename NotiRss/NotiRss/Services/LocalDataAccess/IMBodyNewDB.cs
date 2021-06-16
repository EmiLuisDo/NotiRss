using NotiRss.Models.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NotiRss.Services.LocalDataAccess
{
    public interface IMBodyNewDB
    {
        Task Init();
        Task Add(MBodyNew mBodyNew);
        Task Remove(MBodyNew bodyNew);
        Task<MBodyNew> Get(int id);
        Task<List<MBodyNew>> GetAll();
    }
}
