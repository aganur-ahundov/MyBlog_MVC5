using System;
using System.Web.Mvc;
using System.Linq;
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
        

        [HttpGet]
        public ActionResult AddFeedback( string message )
        {
            ViewBag.Message = message;
            return View("AddFeedback");
        }


        [HttpPost]
        public ActionResult AddFeedback( Feedback feedback )
        {
            if (!ModelState.IsValid)
            {
                string message = ModelState.Values
                                            .Where(v => v.Errors.Count > 0).First()
                                            .Errors.First().ErrorMessage;

                return RedirectToAction("AddFeedback", new { message = message });
            }


            repository.SaveFeedback( feedback );
            return View( "Index", repository.GetFeedback() );

        }
    }
}