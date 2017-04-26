using System;
using System.Linq;
using System.Web.Mvc;
using EpamBlog.Models;
using EpamBlog.Models.Repository;
using EpamBlog.SiteLogic;


namespace EpamBlog.Controllers
{
    public class AdminController : Controller
    {
        private Repository repository = new Repository();

        private AdminManager manager = new AdminManager();


        // GET: Admin
        public ActionResult Index()
        {
            return View( manager.GetMostPopularTags() );
        }


        [HttpPost]
        public ActionResult AddArticle( AddArticleViewModel _article )
        {   
            if( repository.GetArticles().Any( a => a.Title == _article.Title ) )
            {
                ViewBag.Message = "Error: Article with such name has been added";
            }
            else
            {
                repository.AddArticle( manager.createArticle( _article ) );
            }

            return View( "Index", manager.GetMostPopularTags() );
        }
    }
}