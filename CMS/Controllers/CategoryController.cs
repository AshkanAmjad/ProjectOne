using Bussiness.Portal;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModels.Models.Category;

namespace CMS.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult FillCategoryGrid(DataSourceRequest request)
        {
            var categoryServices = new CategoryServices();
            var categories = categoryServices.GetCategories();

            return Json(categories.ToDataSourceResult(request));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult FillCategoryCreate(DataSourceRequest request, CategoryViewModel category)
        {
            var checkMessage = "";
            if (ModelState.IsValid && category != null)
            {
                var categoryServices = new CategoryServices();
                bool result = categoryServices.Add(category, out checkMessage);
            }
            return Json(new[] { category }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult FillCategoryUpdate(DataSourceRequest request, CategoryViewModel category)
        {
            var checkMessage = "";
            if (ModelState.IsValid && category != null)
            {
                var categoryServices = new CategoryServices();
                bool result = categoryServices.Edit(category, out checkMessage);
            }
            return Json(new[] { category }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult FillCategoryDestroy(DataSourceRequest request, CategoryViewModel category)
        {

            if (ModelState.IsValid && category != null)
            {
                var categoryServices = new CategoryServices();
                bool result = categoryServices.Delete(category);
            }
            return Json(new[] { category }.ToDataSourceResult(request, ModelState));
        }
    }
}