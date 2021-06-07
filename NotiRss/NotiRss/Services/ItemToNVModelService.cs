using System;
using System.Collections.Generic;
using System.Text;
using NotiRSS.ViewModels;
using NotiRSS.Models;

namespace NotiRSS.Services
{
    public class ItemToNVModelService 
    {
        public VMNew ItemToNVModel(MItem item) {
            VMNew newVModel = new VMNew();
            newVModel.Title = item.Title;
            newVModel.PubDate = Convert.ToDateTime( item.PubDate );
            newVModel.Img = item.Enclosure.Url;
            newVModel.Link = item.Link;
            newVModel.Author = item.Author;
            return newVModel;
        }
    }
}
