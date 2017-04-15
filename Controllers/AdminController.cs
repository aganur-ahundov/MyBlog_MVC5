using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
            repository.AddArticle( manager.createArticle( _article ) );
            return View( "Index", manager.GetMostPopularTags() );
        }
    }
}