using NotiRss.Models.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NotiRss.Services.LocalDataAccess
{
    public interface IBodyNewDB
    {
        Task Init();
        Task Add(MBodyNew mBodyNew );
        Task Remove(int id);
        Task Get(int id);
        Task GetAll();
    }
}
