﻿using CodeHollow.FeedReader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TablePet.Services.Models
{
    public class FeedItemExt
    {
        public FeedItem FeedItem { get; set; }
        public string FeedTitle { get; set; }
        public string Creator { get; set; }
        public FeedItemExt(FeedItem feedItem, string feedTitle, string creator)
        {
            Feed f = new Feed();
            
            FeedItem = feedItem;
            FeedTitle = feedTitle;
            Creator = creator;
        }
    }
}