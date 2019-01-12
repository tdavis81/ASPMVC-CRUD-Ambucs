using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AmbucsProject.Classes;
using AmbucsProject.Models;
using AmbucsProject.Services;
using static AmbucsProject.Classes.UserMethods;

namespace AmbucsProject.Controllers
{
    public class LoginController : Controller
    {
        AccountsService accountService = new AccountsService();

        [VerifyLoggedIn]
        public ActionResult Index(String error = "")
        {
            ViewBag.error = error;
            return View();
        }

        [VerifyLoggedIn]
        [HttpPost]
        public ActionResult AccountLogin(String username, String password)
        {
            var result = accountService.ValidateLogin(username, password);

            if (result == "Success")
            {
                return RedirectToAction("Index", "Home");
            } else
            {
                return RedirectToAction("Index", "Login", new { error = result });
            }

        }
        
        public ActionResult LogoutAction(String username, String password)
        {
            if (Response.Cookies["userCookies"] != null)
            {
                Response.SetCookie(UserSession.DeleteUserCookie());
            }

            return RedirectToAction("Index", "Login");
        }

        public ActionResult Settings()
        {
            ViewBag.User = UserSession.User;
            return View();
        }

        [HttpPost]
        public ActionResult UpdateUser(string username, string password)
        {
            accountService.UpdateUser(username,password);
            return RedirectToAction("Index", "Home");
        }

    }
}
