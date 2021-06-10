﻿using System;
using System.Collections.Generic;
using System.Text;
using NotiRss.ViewModels;
using NotiRss.Models.Rss;

namespace NotiRSS.Services.Other
{
    public static class ItemToVMNew 
    {
        public static VMNew ConvertItemToVMNew(MItem item) {
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
