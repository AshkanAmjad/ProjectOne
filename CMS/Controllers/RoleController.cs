using Bussiness.Security;
using Domain.Data.Context;
using Domain.Entities.Security.Model;
using System;
using System.Linq;
using System.Web.Mvc;

namespace CMS.Controllers
{
    public class RoleController : Controller
    {
        public ActionResult Index()
        {
            var roleServices = new RoleServices();
            var roles = roleServices.GetRoles();
            if (roles.Count < 0)
            {
                ViewBag.roleExistMessage = false;
                return View();
            }
            else
            {
                ViewBag.roleExistMessage = true;
                return View(roles);
            };
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Role role, string title)
        {
            if (!ModelState.IsValid || role.Title == null)
            {
                return HttpNotFound();
            }
            var roleServices = new RoleServices();
            bool result = roleServices.Add(role);
            if (result == true)
            {
                return Json(new { success = true, message = "Saved Successfully", JsonRequestBehavior.AllowGet });
            }
            return HttpNotFound();

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
            if (!ModelState.IsValid)
            {
                return HttpNotFound();
            }
            var roleServices = new RoleServices();
            bool result = roleServices.Edit(roleId, title);
            if (result == true)
            {
                return Json(new { success = true, message = "Updated Successfully", JsonRequestBehavior.AllowGet });
            }
            return HttpNotFound();
        }

        public ActionResult Delete(Guid roleId)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var roleServices = new RoleServices();
            bool result = roleServices.Delete(roleId);
            if (result == true)
            {
                return RedirectToAction("Index");
            }
            return HttpNotFound();
        }
    }
}