using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EpamBlog.Models.QuizModels
{
    public class MultipleChoiceAnswer
    {
        public int Id { get; set; }

        public int QuestionId { get; set; }

        public string Answer { get; set; }
    }
}