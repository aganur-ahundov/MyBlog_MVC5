using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EpamBlog.Models.QuizModels
{
    public class Variable
    {
        public int Id { get; set; }

        public int QuestionId { get; set; }

        public string Text { get; set; }
    }
}