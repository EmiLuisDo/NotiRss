using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using NotiRSS.Services;
using System.Net.Http;
using NotiRss.ViewModels;
using Xamarin.Essentials;

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
    }
}
