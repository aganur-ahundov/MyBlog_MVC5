using System;
using System.Collections.Generic;


namespace EpamBlog.Models.QuizModels
{
    public class Quiz
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public IEnumerable<MultipleChoiceQuestion> MultypleQuestions { get; set; }

        public IEnumerable<Textbox> Textboxes { get; set; }

    }
}