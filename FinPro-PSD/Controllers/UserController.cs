using FinPro_PSD.Factories;
using FinPro_PSD.Handlers;
using FinPro_PSD.Helpers;
using FinPro_PSD.Models;
using FinPro_PSD.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinPro_PSD.Controllers
{
    public class UserController
    {
        public static Response<User> GetUserById(int id)
        {
            return UserHandler.GetUserById(id);
        }

        public static Response<List<User>> GetAllUsers()
        {
            return UserHandler.GetAllUsers();
        }
        public static Response<User> Login(string username, string password)
        {
            Response<string> response = LoginRequestValidate(username, password);
            if (!response.IsSuccess)
            {
                return new Response<User>
                {
                    Message = response.Payload,
                    IsSuccess = false,
                    Payload = null
                };
            }
            return UserHandler.Login(username, password);
        }

        public static Response<User> Register(string username, string email, DateTime dob, string gender, string password, string confirmPassword)
        {
            Response<string> response = RegisterRequestValidate(username, email, dob, gender, password, confirmPassword);

            if (!response.IsSuccess)
            {
                return new Response<User>
                {
                    Message = response.Payload,
                    IsSuccess = false,
                    Payload = null
                };
            }

            return UserHandler.Register(username, email, dob, gender, password);

        }
        private static Response<string> RegisterRequestValidate(string username, string email, DateTime dob, string gender, string password, string confirmPassword)
        {
            List<string> errors = new List<string>();
            UsernameValidate(username, errors);
            EmailValidate(email, errors);
            DOBValidate(dob, errors);
            GenderValidate(gender, errors);
            PasswordValidate(password, errors);
            ConfirmPasswordValidate(password, confirmPassword, errors);
            if (errors.Count > 0)
            {
                string message = "";
                foreach (var error in errors)
                {
                    message += error + "|";
                }

                return new Response<string>
                {
                    Message = "Validate Error",
                    IsSuccess = false,
                    Payload = message
                };
            }

            return new Response<string>
            {
                Message = "Success",
                IsSuccess = true,
                Payload = null
            };
        }

        private static Response<string> LoginRequestValidate(string username, string password)
        {
            List<string> errors = new List<string>();
            UsernameValidate(username, errors);
            PasswordValidate(password, errors);

            if (errors.Count > 0)
            {
                string message = "";
                foreach (var error in errors)
                {
                    message += error + "|";
                }

                return new Response<string>
                {
                    Message = "Validate Error",
                    IsSuccess = false,
                    Payload = message
                };
            }

            return new Response<string>
            {
                Message = "Success",
                IsSuccess = true,
                Payload = null
            };
        }

        private static void PasswordValidate(string password, List<string> errors)
        {
            if (string.IsNullOrEmpty(password))
            {
                errors.Add("Password is empty");
            }
            else
            {
                if (!password.All(char.IsLetterOrDigit))
                {
                    errors.Add("Password can only consist of alfanumeric character");
                }
            }
        }

        private static void UsernameValidate(string username, List<string> errors)
        {
            if (string.IsNullOrEmpty(username))
            {
                errors.Add("Username is empty");
            }
            else
            {
                if (username.Length < 5 || username.Length > 15)
                {
                    errors.Add("Username length must be between 5 and 15");
                }
            }
        }

        private static void GenderValidate(string gender, List<string> errors)
        {
            if (string.IsNullOrEmpty(gender)) { errors.Add("Gender is empty"); }
        }

        private static void DOBValidate(DateTime dob, List<string> errors)
        {
            if (dob == null) { errors.Add("DOB is empty"); }
        }

        private static void EmailValidate(string email, List<string> errors)
        {
            if (string.IsNullOrEmpty(email))
            {
                errors.Add("Email is empty");
            }
            else
            {
                if (!email.EndsWith(".com"))
                {
                    errors.Add("Email must ends with .com");
                }
            }
        }

        private static void ConfirmPasswordValidate(string password, string confirmPassword, List<string> errors)
        {
            if (string.IsNullOrEmpty(confirmPassword))
            {
                errors.Add("Confirm password must be filled");
            }
            else
            {
                if (password != confirmPassword)
                {
                    errors.Add("Password must be the same");
                }
            }
        }
    }
}
