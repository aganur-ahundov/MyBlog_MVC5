using System;
using System.Linq;
using System.Web.Mvc;
using System.Collections.Generic;
using EpamBlog.Models.Repository;
using EpamBlog.Models.QuizModels;
using EpamBlog.SiteLogic;
using EpamBlog.Models;



namespace EpamBlog.Controllers
{
    public class HomeController : Controller
    {
        private Repository repository = new Repository();

        private short MAX_COUNT_SIMILAR_ARTICLES = 5;


        public ActionResult Index()
        {
            ViewBag.Title = "MyBlog";
            
            ViewBag.Radiobutton = GetRandomRadiobutton();
            return View( repository.GetArticles() );
        }
        

        public ActionResult ReadArticle( int id )
        {   
            Article newArticle = repository.GetArticleWithTagsAndComments( id );

            ViewBag.SimilarArticles = repository.GetSimilarArticles( newArticle, MAX_COUNT_SIMILAR_ARTICLES );
            return View( "Article",  newArticle );
        }


        [HttpPost]
        public ActionResult GetAnswer( MultipleChoiceAnswer _answer )
        {
            var st = new StatisticManager();

            repository.AddAnswer( _answer ); 
            ViewBag.Statistic = st.GetQuestionStatistic( repository.GetMultipleQuestion( _answer.QuestionId ) );

            return View( "Index", repository.GetArticles() ); 
        }


        public ActionResult AddReply( Reply _reply )
        {
            _reply.Published = DateTime.UtcNow;
            repository.AddReply( _reply );
            return RedirectToAction( "ReadArticle", new { id = _reply.ArticleId } );
        }


        private MultipleChoiceQuestion GetRandomRadiobutton()
        {
            MultipleChoiceQuestion[] radiobuttons = repository.MultipleQuestions.Where(q => q.Type == MultipleQuestionType.Radio).ToArray();
            int rbCount = radiobuttons.Count();
            int randomID = new Random().Next(0, rbCount);
            var selectedRadio = radiobuttons[randomID];

            return repository.GetMultipleQuestion(selectedRadio.Id);
        }

    }
}