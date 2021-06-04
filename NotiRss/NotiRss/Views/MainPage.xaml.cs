using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using NotiRSS.Services;
using System.Net.Http;
using NotiRSS.ViewModels;

namespace NotiRSS.Views
{
    public partial class MainPage : ContentPage
    {
        public IList<VMNew> News { get; private set; }

        public NewsService _newsService;

        string Nombre { get; set; }
        public MainPage()
        {
            Console.WriteLine("Hola");
            InitializeComponent();
            //_newsService = new NewsService(new HttpClient(), "https://es.investing.com/rss/news_288.rss", new ItemToNVModelService());
            //Nombre = "Emi";
            //BindingContext = this;
        }

        private async void Button_ClickedAsync(object sender, EventArgs e)
        {
            News = await _newsService.getNewsAsync();
            foreach (VMNew nw in News) {
                Console.WriteLine(nw.Title);
            }
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {

        }
    }
}
