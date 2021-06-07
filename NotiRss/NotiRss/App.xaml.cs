using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NotiRSS.Views;
using NotiRSS.Services;
using System.Net.Http;

namespace NotiRss
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage( new MainPage( new NewsService(new HttpClient(), "https://es.investing.com/rss/news_288.rss", new ItemToNVModelService()) ));
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
