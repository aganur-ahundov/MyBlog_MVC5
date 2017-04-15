using System;
using System.Collections.Generic;

namespace EpamBlog.Models
{
    public class Feedback
    {
        public int Id { get; set; }

        public DateTime Published { get; set; }

        public string Author { get; set; }

        public string Text { get; set; }
        
    }
    
}