using System.Data.Entity;
using EpamBlog.Models.QuizModels;


namespace EpamBlog.Models.Context
{

    public class BlogContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }

        public DbSet<Feedback> Feedback { get; set; }

        public DbSet<Quiz> Quiz { get; set; }



        public DbSet<MultipleChoiceQuestion> MultupleQuestion { get; set; }

        public DbSet<Textbox> Textboxes { get; set; }

        public DbSet<Variable> Variables { get; set; }



        public DbSet<CompletedQuiz> CompletedQuizzes { get; set; }

        public DbSet<MultipleChoiceAnswer> MultipleChoiseAnswers { get; set; }

        public DbSet<TextboxAnswer> TextboxAnswers { get; set; }
        

        public DbSet<Tag> Tags { get; set; }

        public DbSet<Reply> Replies { get; set; }

    }
}