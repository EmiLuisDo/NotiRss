using Microsoft.Toolkit.Parsers.Rss;
using NotiRss.Models.Data;
using NotiRss.Models.Rss;
using NotiRss.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotiRss.Services.Other
{
    public static class NotiConvert
    {
        public static VMNew ToVMNew(MItem item)
        {
            VMNew newVModel = new VMNew();
            newVModel.Title = item.Title;
            newVModel.PubDate = Convert.ToDateTime(item.PubDate);
            newVModel.Img = item.Enclosure.Url;
            newVModel.Link = item.Link;
            newVModel.Author = item.Author;
            return newVModel;
        }

        public static VMNew ToVMNew(RssSchema item)
        {
            VMNew newVModel = new VMNew();
            newVModel.Title = item.Title;
            newVModel.PubDate = item.PublishDate;
            newVModel.Img = item.ImageUrl;
            newVModel.Link = item.FeedUrl;
            newVModel.Author = item.Author;
            return newVModel;
        }

        public static MNew ToMNew( VMNew nw )
        {
            MNew mnew = new MNew();
            mnew.Title = nw.Title;
            mnew.Author = nw.Author;
            mnew.Img = nw.Img;
            mnew.Link = nw.Link;
            return mnew;
        }
    }
}
