using System;
using System.Linq;
using System.Web.Mvc;
using EpamBlog.Models;
using EpamBlog.Models.Repository;


namespace EpamBlog.Controllers
{
    public class FeedbackController : Controller
    {
        private Repository repository = new Repository();

        // GET: Feedback
        public ActionResult Index()
        {
            ViewBag.Title = "Feedback";
            return View( repository.GetFeedback() );
        }


        [HttpPost]
        public ActionResult AddFeedback( Feedback feedback )
        {
            repository.SaveFeedback( feedback );

            return View( "Index", repository.GetFeedback() );

        }
    }
}