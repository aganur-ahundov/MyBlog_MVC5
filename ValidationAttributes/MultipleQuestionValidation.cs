using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using EpamBlog.Models.QuizModels;

namespace EpamBlog.ValidationAttributes
{
    public class MultipleQuestionValidation : ValidationAttribute
    {
        public override bool IsValid( object value )
        {
            var quiz = value as ICollection<MultipleChoiceAnswer>;

            int maxID = quiz.Last().QuestionId;

            for( int i = 1; i <= maxID; i++ )
            {
                if ( quiz.Where( q => q.QuestionId == i ).All( q => q.Answer == null ) )
                    return false;
            }

            return true;
        }
    }
}