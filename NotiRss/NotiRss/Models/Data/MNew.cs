using System;
using System.Collections.Generic;
using System.Text;

namespace NotiRss.Models.Data
{
    public class MNew
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
        public string Author { get; set; }
        public string Img { get; set; }
        public DateTime PubDate { get; set; }
        public MBodyNew Body { get; set; }
    }
}
