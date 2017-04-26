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
            ViewBag.IsHome = true;
            return View( repository.GetArticles() );
        }
        

        public ActionResult ReadArticle( int id )
        {   
            Article newArticle = repository.GetArticleWithTagsAndComments( id );

            ViewBag.SimilarArticles = repository.GetSimilarArticles( newArticle, MAX_COUNT_SIMILAR_ARTICLES );
            return View( "Article",  newArticle );
        }

        
        [HttpPost]
        public ActionResult GetQuizResult( MultipleChoiceAnswer _answer )
        {
            if( string.IsNullOrEmpty( _answer.Answer ) )
            {
                ModelState.AddModelError("", "You need to choose answer");
                ViewBag.Radiobutton = GetRandomRadiobutton();
                return PartialView( "StatisticPartialView", new StatisticViewModel() );
            }

            var sm = new StatisticManager();

            repository.AddAnswer( _answer );
            StatisticViewModel statisticView = sm.GetQuestionStatistic( repository.GetMultipleQuestion( _answer.QuestionId ) );

            return PartialView( "StatisticPartialView", statisticView );
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