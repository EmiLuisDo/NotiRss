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
using Xamarin.Essentials;

namespace NotiRSS.Views
{
    public partial class MainPage : ContentPage
    {
        public IList<VMNew> News { get; private set; }

        public NewsService _newsService { get; private set; }

        string Nombre { get; set; }
        public MainPage(NewsService newsService)
        {
            InitializeComponent();
            this._newsService = newsService;

            //News =  _newsService.getNewsAsync();
            News = new List<VMNew>() ;
            News.Add(new VMNew 
                { 
                Title = "Primer Noticia",
                Author = "Autor1",
                //Img = "https://cdn.dribbble.com/users/679356/screenshots/2380410/shop-small-icon_1x.jpg"
            });
            News.Add(new VMNew
                {
                Title = "Segunda Noticia",
                Author = "Autor2",
                //Img = "https://freepngimg.com/thumb/pokemon/20250-9-pokeball-photo.png"
            });
            News.Add(new VMNew
            {
                Title = "Tercera Noticia",
                Author = "Autor3"
            });
            News.Add(new VMNew
            {
                Title = "Cuarta Noticia",
                Author = "Autor4"
            });
            News.Add(new VMNew
            {
                Title = "Quinta Noticia",
                Author = "Autor5",
                Link= "https://es.investing.com/news/technology-news/rusia-multa-a-google-y-facebook-por-no-eliminar-contenido-prohibido-2120638"
            });
            foreach (VMNew nw in News) {
                Console.WriteLine(nw.Title);
            }

            BindingContext = this;
        }

        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            VMNew noticiaSeleccionada = e.Item as VMNew;
            Console.WriteLine(noticiaSeleccionada.Link);
            await Xamarin.Essentials.Browser.OpenAsync(noticiaSeleccionada.Link);
        }
    }
}
