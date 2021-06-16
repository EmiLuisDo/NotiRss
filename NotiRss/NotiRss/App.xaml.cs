using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NotiRss.Views;
using System.Net.Http;
using NotiRss.ViewModels;
using NotiRss.Services.NetworkDataAccess;
using NotiRss.Services.NetworkDataAccess.Impl;
using NotiRss.Services.Other;
using NotiRss.Services.LocalDataAccess;
using System.IO;
using Xamarin.Essentials;
using Microsoft.EntityFrameworkCore;
using NotiRss.Services.LocalDataAccess.Impl;

namespace NotiRss
{
    public partial class App : Application
    {

        private static IMBodyNewDB bodyDB;
        private static IMNewDB newDB;

        // Create the database connection as a singleton.
        public static IMBodyNewDB BodyDB
        {
            get
            {
                if (bodyDB == null)
                {
                    bodyDB = new MBodyNewDB(Path.Combine(Xamarin.Essentials.FileSystem.AppDataDirectory, "NEWS.db3"));
                }
                return bodyDB;
            }
        }
        public static IMNewDB NewDB
        {
            get
            {
                if (newDB == null)
                {
                    newDB = new MNewDB(Path.Combine(FileSystem.AppDataDirectory, "NEWS.db3"));
                }
                return newDB;
            }
        }
        public App()
        {
            InitializeComponent();
            INewsService ns = new NewsServiceM("https://es.investing.com/rss/news_288.rss");

            VMNews vmnews = new VMNews(ns, App.NewDB, App.BodyDB);
            MainPage = new NavigationPage (new VNews(vmnews));
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
