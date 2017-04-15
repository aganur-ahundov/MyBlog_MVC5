using System;
using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;
using EpamBlog.Models.QuizModels;
using EpamBlog.Models.Context;



namespace EpamBlog.Models.Repository
{
    public class Repository
    {
        private BlogContext context = new BlogContext();


        public IEnumerable<Quiz> Quizzes
        {
            get { return context.Quiz; }
        }

        public IEnumerable<MultipleChoiceQuestion> MultipleQuestions
        {
            get { return context.MultupleQuestion; }
        }

        public IEnumerable<Article> GetArticles()
        {
            return context.Articles;
        }

        public IEnumerable<Article> GetArticlesWithTags()
        {
            return context.Articles.Include(x => x.Tags);
        }

        public IEnumerable<Feedback> GetFeedback()
        {
            return context.Feedback;
        }

    
        public IEnumerable<MultipleChoiceAnswer> MultipleChoiseAnswers
        {
            get { return context.MultipleChoiseAnswers; }
        }


        public Article GetArticleWithTagsAndComments(int _id)
        {
            Article art = context.Articles
                .Where(a => (a.Id == _id))
                .Include(x => x.Tags)
                .First();

            art.Comments = GetReplies().Where(r => r.ArticleId == _id && r.ReplyId == null).ToList();

            return art;
        }

        public IEnumerable<Article> GetSimilarArticles( Article _article, short _count )
        {
            List<Article> similarArticles = new List<Article>();
            foreach ( Tag current in _article.Tags )
            {
                similarArticles.AddRange( current.Articles.Where( t => t.Id != _article.Id ) );
            }

            return similarArticles.Take( _count ).Distinct();
        }


        public IEnumerable<Reply> GetReplies()
        {
            return context.Replies.Include( r => r.Replies );
        }
           
        
        public void AddArticle( Article _article )
        {
            context.Articles.Add(_article);
            context.SaveChanges();
        }

        public void AddReply( Reply _reply )
        {
            context.Replies.Add( _reply );
            context.SaveChanges();
        }


        public MultipleChoiceQuestion GetMultipleQuestion( int _id )
        {
            var multipleQuestion = context.MultupleQuestion.Where( q => q.Id == _id ).First();
            multipleQuestion.Variables = context.Variables.Where( v => v.QuestionId == multipleQuestion.Id ).ToList();

            return multipleQuestion;
        }


        public void AddAnswer( MultipleChoiceAnswer _answer )
        {
            if ( _answer != null )
            {
                context.MultipleChoiseAnswers.Add( _answer );
                context.SaveChanges();
            }
        }


        public void SaveFeedback( Feedback _feedback )
        {
            _feedback.Published = DateTime.UtcNow;
            context.Feedback.Add( _feedback );
            context.SaveChanges();
        }


        public Quiz GetQuizById( int _id )
        {
            Quiz selectedQuiz = context.Quiz.Where(q => q.Id == _id).First();

            if (selectedQuiz == null)
            {
                throw new NullReferenceException();
            }

            selectedQuiz.MultypleQuestions = context.MultupleQuestion.Where(q => q.QuizId == selectedQuiz.Id).ToList();

            foreach (var question in selectedQuiz.MultypleQuestions)
            {
                question.Variables = context.Variables.Where(v => v.QuestionId == question.Id).ToList();
            }

            selectedQuiz.Textboxes = context.Textboxes.Where(t => t.QuizId == selectedQuiz.Id).ToList();

            return selectedQuiz;
        }



        public void SaveComplitedQuiz(CompletedQuiz _quiz)
        {
            _quiz.MultipleAnswers = _quiz.MultipleAnswers.Where(q => q.Answer != null).ToArray();
            _quiz.QuizTextboxes = _quiz.QuizTextboxes?.Where(q => q.Answer != null).ToArray();
            context.CompletedQuizzes.Add(_quiz);

            context.SaveChanges();
        }



        public IEnumerable<MultipleChoiceQuestion> GetMultipleQuestionsByQuizId(int _QuizId)
        {
            var Questions = context.MultupleQuestion.Where(q => q.QuizId == _QuizId).ToArray();

            foreach (MultipleChoiceQuestion question in Questions)
            {
                question.Variables = context.Variables.Where(v => v.QuestionId == question.Id).ToArray();
            }

            return Questions;
        }



        public IEnumerable<Tag> GetTagsWithArticles()
        {
            return context.Tags.Include( x => x.Articles );
        }
    }
}