using System;
using System.Collections.Generic;
using System.Text;


namespace NotiRss.ViewModels
{
    public class VMNew
    {
        public string Title { get; set;}
        public string Img { get; set;}
        public string Author { get; set;}
        public DateTime PubDate { get; set;}
        public string Link { get; set; }

        public string Detail {
            set { }
            get {
                return "Por " + this.Author + ", Publicado: " + this.PubDate;
            } 
        }
    }
}
