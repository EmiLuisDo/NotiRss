using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Net.Http;
using NotiRss.ViewModels;
using Xamarin.Essentials;
using NotiRss.Models.Data;
using NotiRss.Services.Other;
using NotiRss.Services.LocalDataAccess;

namespace NotiRss.Views
{
    public partial class VNews : ContentPage
    {

        public VMNews _VMNews{get; set;}

        string Nombre { get; set; }
        public VNews(VMNews vmnews)
        {
            InitializeComponent();
            this._VMNews= vmnews;
            BindingContext = vmnews;
        }

        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            VMNew noticiaSeleccionada = e.Item as VMNew;
            await Xamarin.Essentials.Browser.OpenAsync(noticiaSeleccionada.Link);
        }

        private void FavouriteButton_Clicked(object sender, EventArgs e)
        {
            ImageButton img_btn = sender as ImageButton;
            VMNew vmnew = img_btn.BindingContext as VMNew;
            MNew mnew = NotiConvert.ToMNew(vmnew);
            Task t = this._VMNews._NewsDB.Add(mnew);
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            List<MNew> mnews= await this._VMNews._NewsDB.GetAll();
            int c = mnews.Count();
            Console.WriteLine( "Contador Oficial: "+ c);
        }

        private void ToolbarItemPokeballs_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new VFavoritos());
        }
    }
}
