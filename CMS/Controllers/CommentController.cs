using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMS.Controllers
{
    public class CommentController : Controller
    {
        #region comment
        public ActionResult ShowComments(int id)
        {
            var commentService = new Bussiness.Portal.CommentServices();
            var comments = commentService.Get(id);
            return Json(comments, JsonRequestBehavior.AllowGet);
        }

        //public ActionResult AddComment()
        //{

        //}

        //[HttpPost]
        //public ActionResult AddComment(AddCommentViewModel comment)
        //{
        //    if (!HttpContext.User.Identity.IsAuthenticated)
        //    {
        //        RedirectToAction("Login", "Home");
        //    }
        //    bool success = false;
        //    var message = "Recorded unsuccessfully";
        //    var checkMessage = "";
        //    if (ModelState.IsValid && comment != null)
        //    {
        //        try
        //        {
        //            var articleServices = new Bussiness.Security.ArticleServices();
        //            var currentUser = HttpContext.User.Identity.Name;
        //            comment.UserId = articleServices.GetUserIdWithUserName(currentUser);
        //            var commentServices = new CommentServices();
        //            bool result = commentServices.Add(comment, out checkMessage);
        //            if (result == true)
        //            {
        //                success = true;
        //                message = "Saved Successfully";
        //            }
        //            else if (result == false)
        //            {
        //                message = checkMessage;
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            while (ex.InnerException != null)
        //            {
        //                ex = ex.InnerException;
        //            }
        //            message = "Recorded unsuccessfully : " + ex.Message;
        //        }
        //    }
        //    else
        //    {
        //        message = "Data is not valid";
        //    }

        //    return Json(new { success = success, message = message, JsonRequestBehavior.AllowGet });
        //}
        #endregion

    }
}