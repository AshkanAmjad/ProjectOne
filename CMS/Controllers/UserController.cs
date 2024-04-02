using Bussiness.Security;
using CMS.Models.ViewModels.User;
using Domain.Data.Context;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ViewModels.Models.User;

namespace CMS.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        //public ActionResult Get()
        //{
        //    var userServices = new UserServices();
        //    var users = userServices.GetUers();

        //    if (users.Count < 0)
        //    {
        //        ViewBag.userExistMessage = true;
        //        return View();
        //    }
        //    else
        //    {
        //        ViewBag.userExistMessage = false;
        //        return View(users);
        //    }
        //}

        public ActionResult FillUserGrid(DataSourceRequest request)
        {
            var userServices = new UserServices();
            var users = userServices.GetUers();

            return Json(users.ToDataSourceResult(request));
        }

        public ActionResult Add()
        {
            List<SelectListItem> status = new List<SelectListItem>();
            status.Add(new SelectListItem
            {
                Text = "Disable",
                Value = "False"
            });
            status.Add(new SelectListItem
            {
                Text = "Enable",
                Value = "True"
            });
            ViewBag.StatusStates = status;

            using (CMSContext context=new CMSContext())
            {
                var roles = context.Roles.Select(s => new SelectListItem
                {
                    Text = s.Title,
                    Value = s.RoleId.ToString()
                }).ToList();
                ViewBag.roles = roles;
            }

            return View();
        }

        [HttpPost]
        public ActionResult Add(AddUserViewModel user)
        {
            bool success = false;
            var message = "Recorded unsuccessfully";
            var checkMessage = "";
            if (ModelState.IsValid)
            {
                try
                {
                    var userServices = new UserServices();
                    bool result = userServices.Add(user, out checkMessage);
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

        public ActionResult Edit(Guid userId)
        {
            if(userId == Guid.Empty)
            {
                return HttpNotFound();
            }
            var userServices = new UserServices();
            var user = userServices.GetUserByIdForEdit(userId);
            if (user == null)
            {
                return HttpNotFound();
            }

            return View(user);
        }

        [HttpPost]
        public ActionResult Edit(EditViewModel model)
        {
            bool success = false;
            var message = "Updated unsuccessfully";
            var checkMessage = "";
            if (ModelState.IsValid && model != null)
            {
                try
                {
                    var userServices = new UserServices();
                    bool result = userServices.Edit(model, out checkMessage);
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

        //public ActionResult Delete(Guid userId)
        //{
        //    if (userId == Guid.Empty)
        //    {
        //        return HttpNotFound();
        //    }
        //    var userServices = new UserServices();
        //    var user = userServices.GetUserByIdForDelete(userId);
        //    if(user == null)
        //    {
        //        return HttpNotFound();
        //    }

        //    return View(user);
        //}

        //[HttpPost]
        //public ActionResult Delete(DeleteViewModel model)
        //{
        //    bool success = false;
        //    var message = "Deleted unsuccessfully";
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            var userServices = new UserServices();
        //            bool result = userServices.Delete(model);
        //            if (result == true)
        //            {
        //                success = true;
        //                message = "Deleted Successfully";
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            while (ex.InnerException != null)
        //            {
        //                ex = ex.InnerException;
        //            }
        //            message = "Deleted Unsuccessfully" + ex.Message;
        //        }
        //    }
        //    else
        //    {
        //        message = "Data is not valid";
        //    }
        //    return Json(new { success = success, message = message, JsonRequestBehavior.AllowGet });
        //}
        [HttpPost]
        public ActionResult Delete(DataSourceRequest request, UserViewModel user)
        {
            if (user != null)
            {
                var userServices = new UserServices();
                bool result = userServices.Delete(user);
            }
            return Json(new[] { user }.ToDataSourceResult(request, ModelState));
        }

    }
}