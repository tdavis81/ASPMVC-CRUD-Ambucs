using AmbucsProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static AmbucsProject.Classes.UserMethods;

namespace AmbucsProject.Controllers
{
    public class AdminController : Controller
    {
        AdminService adminService = new AdminService();
        
        [VerifyAdmin]
        public ActionResult Index()
        {
            ViewBag.Users = adminService.GetAllUsers();
            return View();
        }
        [VerifyAdmin]
        public ActionResult AddUser()
        {
            ViewBag.Roles = adminService.GetAllRoles();
            return View();
        }
        [VerifyAdmin]
        public ActionResult EditUser(int id)
        {
            ViewBag.Roles = adminService.GetAllRoles();
            ViewBag.User = adminService.GetUser(id);
            return View();
        }
        [VerifyLogin]
        [HttpPost]
        public ActionResult AddUserToDB(string username, int utype)
        {
            adminService.AddUser(username, utype);
            return RedirectToAction("Index", "Admin");
        }
        [VerifyLogin]
        [HttpPost]
        public ActionResult UpdateUserInDB(int id, string username, int utype)
        {
            adminService.EditUser(id,username, utype);
            return RedirectToAction("Index", "Admin");
        }
        [VerifyLogin]
        [HttpGet]
        public ActionResult DeleteUserInDB(int id)
        {
            adminService.DeleteUser(id);
            return RedirectToAction("Index", "Admin");
        }
    }
}