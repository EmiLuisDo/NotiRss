using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Toolkit.Parsers.Rss;
using NotiRss.Services.Other;
using NotiRss.Models;
using NotiRss.ViewModels;
using NotiRss.Services.LocalDataAccess;

namespace NotiRss.Services.NetworkDataAccess.Impl
{
    public class NewsServiceM : INewsService
    {
        private IMNewDB newDB;

        public string Path { get; set; }

        public NewsServiceM(string path)
        {
            this.Path = path;
        }

        public NewsServiceM(string path, IMNewDB newDB)
        {
            this.Path = path;
            this.newDB = newDB;
        }

        public async Task<List<VMNew>> getNewsAsync()
        {
            List<VMNew> noticias = new List<VMNew>();
            IEnumerable<RssSchema> parse = await getRssAsync();
            foreach (var item in parse)
            {
                VMNew noticia = RssSchemaToVMNew.ConvertRssSchemaToVMNew(item);
                noticias.Add(noticia);
            }
            return noticias;
        }

        private async Task<IEnumerable<RssSchema>> getRssAsync()
        {
            string feed = null;
            IEnumerable<RssSchema> parse = null;
            try
            {
                using (var client = new HttpClient())
                {
                    feed = await client.GetStringAsync(Path);
                }
                if (feed != null) 
                {
                    RssParser parser = new RssParser();
                    parse = parser.Parse(feed);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("__Exception");
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
            return parse;
        }
    }
}
