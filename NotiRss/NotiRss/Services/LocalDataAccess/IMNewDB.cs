using NotiRss.Models.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NotiRss.Services.LocalDataAccess
{
    public interface IMNewDB
    {
        Task Init();
        Task Add(MNew mNew);
        Task<MNew> Get(int id);
        Task Remove(MNew mnew);
        Task<IEnumerable<MNew>> GetAll();
    }
}
