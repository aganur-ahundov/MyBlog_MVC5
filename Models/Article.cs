using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace EpamBlog.Models
{
    public class Article
    {
        public int Id { get; set; }

        [Required( ErrorMessage = "Please, enter the title" )]
        public string Title { get; set; }

        public DateTime Published { get; set; }

        [Required( ErrorMessage = "This field cannot be empty" )]
        public string Text { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }

        public virtual ICollection<Reply> Comments { get; set; }
    }
    
}


