using FinPro_PSD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinPro_PSD.Repositories
{
    public class UserRepository
    {
        private static readonly Database1Entities db = new Database1Entities();

        public static User GetLastUser()
        {
            return db.Users.ToList().LastOrDefault();
        }

        public static List<User> GetAllUsers()
        {
            return db.Users.ToList();
        }

        public static User GetUserById(int id)
        {
            return db.Users.Find(id);
        }

        public static User GetUserByUsername(string username)
        {
            return db.Users.Where(u => u.Username == username).FirstOrDefault();
        }

        public static int InsertUser(User user)
        {
            db.Users.Add(user);
            return db.SaveChanges();
        }
    }
}