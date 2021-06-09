using NotiRss.Models;
using NotiRss.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NotiRss.Services.NetworkDataAccess
{
    public interface INewsService
    {
        Task<List<VMNew>> getNewsAsync();
    }
}
