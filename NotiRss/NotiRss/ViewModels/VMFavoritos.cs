using NotiRss.Models.Data;
using NotiRss.Services.LocalDataAccess;
using NotiRss.Services.NetworkDataAccess;
using NotiRss.Services.Other;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace NotiRss.ViewModels
{
    public class VMFavoritos
    {
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(string prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        private ObservableCollection<VMNew> news = new ObservableCollection<VMNew>();
        public ObservableCollection<VMNew> News
        {
            get { return news; }
            set { news = value; OnPropertyChanged(nameof(News)); }
        }
        private IMNewDB _newsDB=App.NewDB;
        public IMNewDB _NewsDB { get => this._newsDB; set => this._newsDB = value; }

        private async void InicializarAsync() {
            List<MNew> mnews = await this._NewsDB.GetAll();
            foreach (MNew mnew in mnews)
            {
                this.News.Add(NotiConvert.ToVMNew(mnew));
            }
        }
        public VMFavoritos() {
            InicializarAsync();
        }
    }
}
