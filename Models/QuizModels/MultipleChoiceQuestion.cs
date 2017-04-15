using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EpamBlog.Models.QuizModels
{

    public enum MultipleQuestionType
    {
        Checkbox,
        Radio
    }

    public class MultipleChoiceQuestion
    {
        public int Id { get; set; }

        public string QuestionText { get; set; }

        public MultipleQuestionType Type { get; set; }

        public IEnumerable<Variable> Variables { get; set; }


        public int QuizId { get; set; }
    }
}