using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NotiRSS.Views;
using NotiRSS.Services;
using System.Net.Http;
using NotiRSS.ViewModels;

namespace NotiRss
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            NewsService ns = new NewsService(new HttpClient(), "https://es.investing.com/rss/news_288.rss", new ItemToNVModelService());
            VMNews vmnews = new VMNews(ns);
            MainPage = new NavigationPage( new VNews(vmnews));
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
