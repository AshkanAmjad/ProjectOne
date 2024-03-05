using Bussiness.Security;
using CMS.Models.Validation;
using Domain.Data.Context;
using Domain.Entities.Security.Model;
using FluentValidation.Results;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Web.Mvc;

namespace CMS.Controllers
{
    public class RoleController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Get()
        {
            var roleServices = new RoleServices();
            var roles = roleServices.GetRoles();

            if (roles.Count < 0)
            {
                ViewBag.roleExistMessage = true;
                return View();
            }
            else
            {
                ViewBag.roleExistMessage = false;
                return View(roles);
            };
        }



        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Role role)
        {
            bool success = false;
            var message = "Recorded unsuccessfully";


            if (ModelState.IsValid)
            {
                try
                {
                    var roleServices = new RoleServices();
                    bool result = roleServices.Add(role);
                    if (result == true)
                    {
                        success = true;
                        message = "Saved Successfully";
                    }
                    else if (result == false)
                    {
                        message = "Duplicated Record";
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
            return Json(new { success = success, message = message , JsonRequestBehavior.AllowGet });
        }

        public ActionResult Edit(Guid roleId)
        {
            if (roleId != null)
            {
                var roleServices = new RoleServices();
                return View(roleServices.GetRoleWithId(roleId));
            }
            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult Edit(Guid roleId, string title)
        {
            bool success = false;
            var message = "Updated unsuccessfully";
            if (ModelState.IsValid && title != "")
            {
                try
                {
                    var roleServices = new RoleServices();
                    bool result = roleServices.Edit(roleId, title);
                    if (result == true)
                    {
                        success = true;
                        message = "Updated Successfully";
                    }
                    else
                    {
                        message = "Duplicated Record";
                    }
                }
                catch (Exception ex)
                {
                    while (ex.InnerException != null)
                    {
                        ex = ex.InnerException;
                    }
                    message = "Updated unsuccessfully : " + ex.Message;
                }
            }
            else
            {
                message = "Data is not valid";
            }
            return Json(new { success = success, message = message, JsonRequestBehavior.AllowGet });
        }

        public ActionResult Delete(Guid roleId)
        {
            if (roleId != null)
            {
                var roleServices = new RoleServices();
                return View(roleServices.GetRoleWithId(roleId));
            }
            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult Delete(Guid roleId, int service = 0)
        {
            bool success = false;
            var message = "Deleted unsuccessfully";
            if (ModelState.IsValid)
            {
                try
                {
                    var roleServices = new RoleServices();
                    bool result = roleServices.Delete(roleId);
                    if (result == true)
                    {
                        success = true;
                        message = "Deleted Successfully";
                    }
                }
                catch (Exception ex)
                {
                    while (ex.InnerException != null)
                    {
                        ex = ex.InnerException;
                    }
                    message = "Deleted unsuccessfuly";
                }
            }
            else
            {
                message = "Data is not valid";
            }
            return Json(new { success = success, message = "Deleted Successfully", JsonRequestBehavior.AllowGet });

        }
    }
}