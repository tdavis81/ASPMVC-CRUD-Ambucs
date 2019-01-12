using AmbucsProject.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AmbucsProject.Classes
{
    public class UserSession
    {
        public static User User
        {
            get
            {
                var user = new User();
                try
                {
                    var Json = HttpContext.Current.Request.Cookies["userCookies"].Value;
                    user = JsonConvert.DeserializeObject<User>(Json);
                }
                catch
                {
                    return null;
                }
                return user;
            }
        }
        public static HttpCookie CreateUserCookie(User curUser)
        {
            // create user
            var user = new User()
            {
                id = curUser.id,
                username = curUser.username,
                password = curUser.password,
                user_role = curUser.user_role,
                reset_needed = curUser.reset_needed
            };

            HttpCookie userCookies = new HttpCookie("userCookies");
            userCookies.Value = JsonConvert.SerializeObject(user);
            userCookies.Expires = DateTime.Now.AddDays(1);
            return userCookies;
        }
        public static HttpCookie DeleteUserCookie()
        {
            HttpCookie userCookies = new HttpCookie("userCookies");
            userCookies.Expires = DateTime.Now.AddDays(-1);
            return userCookies;
        }

    }
}