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
    public class MakeupTypeController
    {
        public static Response<MakeupType> GetMakeupTypeById(int id)
        {
            return MakeupTypeHandler.GetMakeupTypeById(id);
        }
        public static Response<List<MakeupType>> GetAllMakeupTypes()
        {
            return MakeupTypeHandler.GetAllMakeupTypes();
        }
        public static Response<MakeupType> InsertMakeupType(string name)
        {
            Response<string> response = MakeupTypeRequestValidate(name);
            if (!response.IsSuccess)
            {
                return new Response<MakeupType>
                {
                    Message = response.Payload,
                    IsSuccess = false,
                    Payload = null
                };
            }
            return MakeupTypeHandler.InsertMakeupType(name);
        }

        public static Response<MakeupType> UpdateMakeupType(string id, string name)
        {
            Response<string> response = UpdateMakeupTypeRequestValidate(id, name);
            if (!response.IsSuccess)
            {
                return new Response<MakeupType>
                {
                    Message = response.Payload,
                    IsSuccess = false,
                    Payload = null
                };
            }
            return MakeupTypeHandler.UpdateMakeupType(Convert.ToInt32(id), name);
        }
        public static Response<MakeupType> RemoveMakeupType(string id)
        {
            List<string> errors = new List<string>();
            IdValidate(id, errors);
            if (errors.Count > 0)
            {
                string message = "";
                foreach (var error in errors)
                {
                    message += error + "|";
                }

                return new Response<MakeupType>
                {
                    Message = "Validate Error",
                    IsSuccess = false,
                    Payload = null
                };
            }
            return MakeupTypeHandler.RemoveMakeupType(Convert.ToInt32(id));
        }
        private static Response<string> MakeupTypeRequestValidate(string name)
        {
            List<string> errors = new List<string>();
            NameValidate(name, errors);
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
        private static Response<string> UpdateMakeupTypeRequestValidate(string id, string name)
        {
            List<string> errors = new List<string>();
            IdValidate(id, errors);
            NameValidate(name, errors);
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
        private static void IdValidate(string id, List<string> errors)
        {
            try
            {
                int? idInt = Convert.ToInt32(id);
                if (!idInt.HasValue)
                {
                    errors.Add("Id is null");
                }
            }
            catch (Exception)
            {
                errors.Add("Id must be a number");
            }
        }
        private static void NameValidate(string name, List<string> errors)
        {
            if (string.IsNullOrEmpty(name))
            {
                errors.Add("Name is empty");
            }
            else
            {
                if (name.Length < 1 || name.Length > 99)
                {
                    errors.Add("Name length must be between 1 and 99");
                }
            }
        }

    }
}