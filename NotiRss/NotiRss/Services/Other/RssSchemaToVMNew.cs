using Microsoft.Toolkit.Parsers.Rss;
using NotiRss.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotiRss.Services.Other
{
    public class RssSchemaToVMNew
    {
        public VMNew ConvertRssSchemaToVMNew(RssSchema item)
        {
            VMNew newVModel = new VMNew();
            newVModel.Title = item.Title;
            newVModel.PubDate = item.PublishDate;
            newVModel.Img = item.ImageUrl;
            newVModel.Link = item.FeedUrl;
            newVModel.Author = item.Author;
            return newVModel;
        }
    }
}
