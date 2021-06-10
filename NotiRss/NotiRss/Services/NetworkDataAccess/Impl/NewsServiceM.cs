using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Toolkit.Parsers.Rss;
using NotiRss.Services.Other;
using NotiRss.Models;
using NotiRss.ViewModels;

namespace NotiRss.Services.NetworkDataAccess.Impl
{
    public class NewsServiceM : INewsService
    {
        public string Path { get; set; }
        public HttpClient _HttpClient { get; set; }

        public NewsServiceM(HttpClient HttpClient, string path)
        {
            this._HttpClient = HttpClient;
            this.Path = path;
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
                feed = await _HttpClient.GetStringAsync(Path);
                if (feed != null) 
                {
                    RssParser parser = new RssParser();
                    parse = parser.Parse(feed);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
            return parse;
        }
    }
}
