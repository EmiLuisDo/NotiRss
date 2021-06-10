using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace NotiRss.Models.Data
{
    public class MBodyNew
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Body { get; set; }

    }
}
