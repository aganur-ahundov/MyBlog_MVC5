using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EpamBlog.Models.QuizModels
{
    public class Textbox
    {
        public int Id { get; set; }

        public string Placeholder { get; set; }


        public int QuizId { get; set; }
    }
}