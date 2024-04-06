using Bussiness.Portal;
using Bussiness.Security;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using ViewModels.Models.Article;
using System.Linq;
using Domain.Data.Context;
using CMS.Models.Authorization;

namespace CMS.Controllers
{
    public class ArticleController : Controller
    {
        [CustomAuthorize(Roles = "Role 3")]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult FillArticleGrid(DataSourceRequest request)
        {
            var articleSevices = new ArticleSevices();
            var articles = articleSevices.GetArticles();
            return Json(articles.ToDataSourceResult(request));
        }

        public ActionResult DisplayDetails(int id)
        {
            var articleSevices = new ArticleSevices();
            var article = articleSevices.GetArticle(id);
            return View(article);
        }

        public ActionResult Add()
        {
            using (CMSContext context = new CMSContext())
            {
                var categories = context.Categories.Select(s => new SelectListItem
                {
                    Text = s.Title,
                    Value = s.CategoryId.ToString()
                }).ToList();

                ViewBag.categories = categories;
            }

            //AddAritcleViewModel model = new AddAritcleViewModel();
            //model.AuthorId = Guid.Parse("5ca717ac-7ccf-454b-90dd-17cbaf732464");

            return View();
        }

        [HttpPost]
        public ActionResult Add(AddAritcleViewModel article)
        {
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                RedirectToAction("Login","Home");
            }
            bool success = false;
            var message = "Recorded unsuccessfully";
            var checkMessage = "";

            if (ModelState.IsValid && article != null)
            {
                try {
                    var articleServices = new ArticleSevices();
                    var currentUser = HttpContext.User.Identity.Name;
                    article.AuthorId = articleServices.GetUserIdWithUserName(currentUser);
                    bool result = articleServices.Add(article, out checkMessage);
                    if (result == true)
                    {
                        success = true;
                        message = "Saved Successfully";
                    }
                    else if (result == false)
                    {
                        message = checkMessage;
                    }
                }
                catch (Exception ex)
                {
                    while (ex.InnerException != null)
                    {
                        ex = ex.InnerException;
                    }
                    message = "Recorded unsuccessfully : " + ex.Message;
                }
            }
            else
            {
                message = "Data is not valid";
            }

            return Json(new { success = success, message = message, JsonRequestBehavior.AllowGet });
        }

        public ActionResult Edit(int articleId)
        {
            using (CMSContext context = new CMSContext())
            {
                var categories = context.Categories.Select(s => new SelectListItem
                {
                    Text = s.Title,
                    Value = s.CategoryId.ToString()
                }).ToList();
                ViewBag.categories = categories;
            }
            if(articleId == null)
            {
                return HttpNotFound();
            }
            var articleServices = new ArticleSevices();
            var article = articleServices.GetArticleByIdForEdit(articleId);
            return View(article);
        }

        [HttpPost]
        public ActionResult Edit(EditArticleViewModel article)
        {
            bool success = false;
            var message = "Updated unsuccessfully";
            var checkMessage = "";
            if (ModelState.IsValid && article != null)
            {
                try
                {
                    var articleServices = new ArticleSevices();
                    bool result = articleServices.Edit(article, out checkMessage);
                    if (result == true)
                    {
                        success = true;
                        message = "Updated Successfully";
                    }
                    else
                    {
                        message = checkMessage;
                    }
                }
                catch (Exception ex)
                {
                    while (ex.InnerException != null)
                    {
                        ex = ex.InnerException;
                    }
                    message = "Updated Unsuccessfully : " + ex.Message;
                }
            }
            else
            {
                message = "Data is not valid";
            }
            return Json(new { success = success, message = message, JsonRequestBehavior.AllowGet });
        }

        [HttpPost]
        public ActionResult Delete(DataSourceRequest request, ArticleViewModel article)
        {
            if (article != null)
            {
                var articleServices = new ArticleSevices();
                bool result = articleServices.Delete(article);
            }
            return Json(new[] { article }.ToDataSourceResult(request, ModelState));
        }
    }
}