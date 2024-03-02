using Bussiness.Security;
using Domain.Entities.Security.Model;
using System;
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
        public ActionResult Add(Role role)
        {
            role.RoleId = Guid.NewGuid();
            if(!ModelState.IsValid && role.Title == null)
            {
                return HttpNotFound();
            }
            var roleServices = new RoleServices();
            roleServices.Add(role);
            return RedirectToAction("Index");
        }

        //public ActionResult Edit(Guid roleId)
        //{
        //    var roleService = new RoleServices();
        //    var role = roleService.GetRoleWithId(roleId);
        //    return View(role);
        //}

        [HttpPost]
        public ActionResult Edit(Role role)
        {
            if (!ModelState.IsValid)
            {
                return HttpNotFound();
            }
            var roleServices = new RoleServices();
            bool result = roleServices.Edit(role.RoleId, role);
            return Json(new { });
        }

        public ActionResult Delete(Guid roleId)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var roleServices = new RoleServices();
            bool result = roleServices.Delete(roleId);
            return RedirectToAction("Index");
        }
    }
}