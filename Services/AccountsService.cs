using AmbucsProject.Classes;
using AmbucsProject.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace AmbucsProject.Services
{
    public class AccountsService : DatabaseService
    {

        public String ValidateLogin(String username, String password)
        {
            var user = GetUser(username);
            if(user == null)
            {
                return "Username doesn't exist";
            } else
            {
                var passHash = Utils.sha256(password + user.id + ConfigurationManager.AppSettings["salt"]);
                if (passHash != user.password)
                {
                    // Invalid Password
                    return "Invalid Password";
                }

                this.DB.SaveChanges();
                HttpContext.Current.Response.SetCookie(UserSession.CreateUserCookie(user));

                // Success
                return "Success";

            }

        }

        public void UpdateUser(string username, string password)
        {
            var user = this.DB.Users.First(u => u.username == username);
            var hashPass = Utils.sha256(password + user.id + ConfigurationManager.AppSettings["salt"]);
            user.password = hashPass;
            this.DB.SaveChanges();
        }
    }
}