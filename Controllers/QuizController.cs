using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EpamBlog.Helpers;
using EpamBlog.Models.QuizModels;
using EpamBlog.Models.Repository;
using EpamBlog.SiteLogic;



namespace EpamBlog.Controllers
{
    public class QuizController : Controller
    {
        private Repository repository = new Repository();

        // GET: Questionnaire
        public ActionResult Index( int id = 1 )
        {
            QuizConstructor.ResetIndexator();

            return View( "Index", repository.GetQuizById( id ) );
        }



        [HttpPost]
        public ActionResult GetResult( CompletedQuiz _quiz )
        {
            repository.SaveComplitedQuiz(_quiz);
        
            return View( "Statistic", GetStatistic(_quiz.QuizId) );
        }
        

        private IEnumerable<StatisticViewModel> GetStatistic(int _quizId)
        {
            StatisticManager st = new StatisticManager();
            List<StatisticViewModel> statistic = new List<StatisticViewModel>();
            var Questions = repository.GetMultipleQuestionsByQuizId(_quizId);

            
            foreach ( MultipleChoiceQuestion question in Questions )
            {
                statistic.Add( st.GetQuestionStatistic(question) );
            }

            return statistic;
        }
    }

}