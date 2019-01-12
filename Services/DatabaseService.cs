using AmbucsProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AmbucsProject.Services
{
    public class DatabaseService
    {
        protected AmbucsEntities DB;

        public DatabaseService()
        {
            this.DB = new AmbucsEntities();
        }

        public void RecycleDB()
        {
            this.DB.Dispose();
            this.DB = new AmbucsEntities();
        }

        public User GetUser(String username)
        {
            return this.DB.Users.Where(r => r.username == username ).FirstOrDefault();
        }


    }
}