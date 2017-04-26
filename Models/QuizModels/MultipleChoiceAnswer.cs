using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace EpamBlog.Models.QuizModels
{
    public class MultipleChoiceAnswer
    {
        public int Id { get; set; }

        public int QuestionId { get; set; }
        
        public string Answer { get; set; }
    }
}