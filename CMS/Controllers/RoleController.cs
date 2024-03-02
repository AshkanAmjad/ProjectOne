using Bussiness.Security;
using Domain.Entities.Security.Model;
using System;
using System.Web.Mvc;

namespace CMS.Controllers
{
    public class RoleController : Controller
    {
        public ActionResult GetRoles()
        {
            var roleServices = new RoleServices();
            var roles = roleServices.GetRoles();
            if (roles.Count == 0)
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

        public ActionResult AddRole(Role role)
        {
            role.RoleId = Guid.NewGuid();
            if (!ModelState.IsValid)
            {
                return View();
            }
            var roleServices = new RoleServices();
            bool result = roleServices.Add(role);
            return View();
        }

        public ActionResult EditRole(Role role)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var roleServices = new RoleServices();
            bool result = roleServices.Edit(role.RoleId, role);
            return View();
        }

        public ActionResult DeleteRole(Role role)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var roleServices = new RoleServices();
            bool result = roleServices.Delete(role.RoleId);
            return View("GetRoles");
        }

    }
}