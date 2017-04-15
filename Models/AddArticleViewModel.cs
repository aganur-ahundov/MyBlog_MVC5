using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EpamBlog.Models
{
    public class AddArticleViewModel
    {
        public string Title { get; set; }

        public string Text { get; set; }

        public string Tags { get; set; }
    }
}