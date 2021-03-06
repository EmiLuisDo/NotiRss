
using Microsoft.EntityFrameworkCore;
using NotiRss.Services.LocalDataAccess;
using NotiRss.Services.NetworkDataAccess;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace NotiRss.ViewModels
{
    public class VMNews : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<VMNew> news = new ObservableCollection<VMNew>();
        private INewsService _newsService;
        public INewsService _NewsService {
            get { return _newsService; }
            set { this._newsService = value; }
        }

        public ObservableCollection<VMNew> News 
        {
            get { return news; }
            set { news = value; OnPropertyChanged(nameof(News)); }
        }

        private IMBodyNewDB _bodysNewsDB;
        public IMBodyNewDB _BodysNewsDB { get => this._bodysNewsDB; set => this._bodysNewsDB = value; }
        private IMNewDB _newsDB;
        public IMNewDB _NewsDB { get => this._newsDB; set => this._newsDB = value; }

        private bool _isRefreshing = false;
        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set
            {
                _isRefreshing = value;
                OnPropertyChanged(nameof(IsRefreshing));
            }
        }

        public ICommand RefreshCommand
        {
            get
            {
                return new Command(async () =>
                {
                    IsRefreshing = true;
                    this.News.Clear();
                    this.News = new ObservableCollection<VMNew>(await _NewsService.getNewsAsync());
                    IsRefreshing = false;
                });
            }
        }

        void OnPropertyChanged(string prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop) );
        }

        public async Task InicializarAsync() 
        {
            List<VMNew> lnews = await this._NewsService.getNewsAsync();
            this.News = new ObservableCollection<VMNew>(lnews);
        }

        public VMNews(INewsService newsService)
        {
            this._NewsService = newsService;
            InicializarAsync();
        }
        public VMNews(INewsService newsService, IMNewDB newsDB, IMBodyNewDB bodysDB)
        {
            this._BodysNewsDB = bodysDB;
            this._NewsDB = newsDB;
            this._NewsService = newsService;
            InicializarAsync();
        }


    }
}
