using NotiRSS.ViewModels;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using NotiRSS.Models;
using System.Xml.Serialization;
using System.IO;

namespace NotiRSS.Services
{
    public class NewsService
    {
        public string Path { get; set; }
        public HttpClient _HttpClient { get; set; }

        public ItemToNVModelService _itemToNVModelService;

        public async Task<List<VMNew>> getNewsAsync() 
        {
            List< VMNew > noticias= new List<VMNew>();
            MRss rss = await getRssAsync();
            foreach (MItem item in rss.Channel.Items)
            {
                noticias.Add(_itemToNVModelService.ItemToNVModel(item));
            }
            return noticias;
        }

        public async Task<MRss> getRssAsync() {
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
                Console.WriteLine("Excepcion");
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
            return rss;
        }

        public NewsService(HttpClient HttpClient, string path, ItemToNVModelService itemToNVModelService)
        {
            this._itemToNVModelService = itemToNVModelService;
            this._HttpClient = HttpClient;
            this.Path = path;
        }

    }
}
