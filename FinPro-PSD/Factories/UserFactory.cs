using FinPro_PSD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinPro_PSD.Factories
{
    public class UserFactory
    {
        public static User CreateCustomer(int id, string username, string email, DateTime dob, string gender, string password)
        {
            return new User
            {
                UserID = id,
                Username = username,
                UserEmail = email,
                UserDOB = dob,
                UserGender = gender,
                UserRole = "customer",
                UserPassword = password
            };
        }
    }
}