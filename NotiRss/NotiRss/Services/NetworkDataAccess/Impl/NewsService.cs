using NotiRss.ViewModels;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using NotiRss.Models.Rss;
using System.Xml.Serialization;
using System.IO;
using NotiRss.Services.NetworkDataAccess;
using NotiRss.Services.Other;

namespace NotiRss.Services.NetworkDataAccess.Impl
{
    public class NewsService : INewsService
    {
        public string Path { get; set; }
        public HttpClient _HttpClient { get; set; }
        public NewsService(HttpClient HttpClient, string path)
        {
            this._HttpClient = HttpClient;
            this.Path = path;
        }

        public async Task<List<VMNew>> getNewsAsync() 
        {
            List< VMNew > noticias= new List<VMNew>();
            MRss rss = await getRssAsync();
            foreach (MItem item in rss.Channel.Items)
            {
                noticias.Add(NotiConvert.ToVMNew(item));
            }
            return noticias;
        }

        private async Task<MRss> getRssAsync() {
            MRss rss = null;
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(MRss));
                string stringNews = await _HttpClient.GetStringAsync(Path);
                StringReader stringReader = new StringReader(stringNews);
                await Task.Run(() => rss = (MRss)serializer.Deserialize(stringReader));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
            return rss;
        }


    }
}
