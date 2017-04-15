using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EpamBlog.Models
{
    public class Reply
    {
        public int Id { get; set; }

        public int ArticleId { get; set; }

        public int? ReplyId { get; set; }

        public virtual ICollection<Reply> Replies { get; set; }


        public DateTime Published { get; set; }

        public string Author { get; set; }

        public string Text { get; set; }
    }
}