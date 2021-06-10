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
        Task Remove(int id);
        Task Get(int id);
        Task GetAll();
    }
}
