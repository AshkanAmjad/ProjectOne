using Bussiness.Security;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModels.Models.User;

namespace CMS.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var articleSevices = new ArticleSevices();
            var articles = articleSevices.GetArticles();
            return View(articles);
        }
    }
}