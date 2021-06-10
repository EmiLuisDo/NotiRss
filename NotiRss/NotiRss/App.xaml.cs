using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NotiRss.Views;
using NotiRSS.Services;
using System.Net.Http;
using NotiRss.ViewModels;
using NotiRss.Services.NetworkDataAccess;
using NotiRss.Services.NetworkDataAccess.Impl;
using NotiRss.Services.Other;

namespace NotiRss
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            INewsService ns = new NewsServiceM(new HttpClient(), "https://es.investing.com/rss/news_288.rss");
            VMNews vmnews = new VMNews(ns);
            MainPage = new NavigationPage(new VNews(vmnews));
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
