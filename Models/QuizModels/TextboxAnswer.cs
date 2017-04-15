using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EpamBlog.Models.QuizModels
{
    public class TextboxAnswer
    {
        public int Id { get; set; }

        public string QuestionText { get; set; }

        public string Answer { get; set; }
    }
}