using AmbucsProject.Classes;
using AmbucsProject.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace AmbucsProject.Services
{
    public class AdminService : DatabaseService
    {

        public List<User> GetAllUsers()
        {
            return this.DB.Users.OrderBy(x => x.username).ToList();
        }
        public User GetUser(int id)
        {
            return this.DB.Users.FirstOrDefault(x => x.id == id);
        }
        public void AddUser(string username, int utype)
        {
            var defaultPassword = "test";
            
            var User = new User()
            {
                username = username,
                password =  defaultPassword,
                user_role = utype,
                reset_needed = true
            };

            DB.Users.Add(User);
            DB.SaveChanges();
            var createdUser = this.DB.Users.Where(x => x.username == username).FirstOrDefault();
            createdUser.password = Utils.sha256(defaultPassword + createdUser.id + ConfigurationManager.AppSettings["salt"]);
            DB.SaveChanges();
        }
        public void EditUser(int id,string username, int utype)
        {
            var user = this.DB.Users.FirstOrDefault(x => x.id == id);
            user.username = username;
            user.user_role = utype;
            DB.SaveChanges();
        }
        public List<UserRole> GetAllRoles()
        {
            return this.DB.UserRoles.ToList();
        }
        public void DeleteUser(int id)
        {
            var user = this.DB.Users.First(x => x.id == id);
            this.DB.Users.Remove(user);
            this.DB.SaveChanges();
        }
    }
}