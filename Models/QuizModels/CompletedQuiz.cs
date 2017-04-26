using System;
using System.Collections.Generic;
using System.Web.Mvc;
using EpamBlog.ValidationAttributes;

namespace EpamBlog.Models.QuizModels
{
    public class CompletedQuiz
    {
        public int Id { get; set; }

        [MultipleQuestionValidation]
        public ICollection< MultipleChoiceAnswer > MultipleAnswers { get; set; }

        public ICollection<TextboxAnswer> QuizTextboxes { get; set; }


        public int QuizId { get; set; }
        
    }

}