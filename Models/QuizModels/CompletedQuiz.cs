using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EpamBlog.Models.QuizModels
{
    public class CompletedQuiz
    {
        public int Id { get; set; }

        public ICollection< MultipleChoiceAnswer > MultipleAnswers { get; set; }

        public ICollection<TextboxAnswer> QuizTextboxes { get; set; }


        public int QuizId { get; set; }
        
    }

}