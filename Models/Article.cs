using System;
using System.Collections.Generic;


namespace EpamBlog.Models
{
    public class Article
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime Published { get; set; }

        public string Text { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }

        public virtual ICollection<Reply> Comments { get; set; }
    }
    
}


