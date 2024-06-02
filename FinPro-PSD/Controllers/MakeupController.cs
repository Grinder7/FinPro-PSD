using FinPro_PSD.Handlers;
using FinPro_PSD.Helpers;
using FinPro_PSD.Models;
using FinPro_PSD.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace FinPro_PSD.Controllers
{
    public class MakeupController
    {
        public static Response<Makeup> GetMakeupById(int id)
        {
            return MakeupHandler.GetMakeupById(id);
        }
        public static Response<List<Makeup>> GetAllMakeups()
        {
            return MakeupHandler.GetAllMakeups();
        }
        public static Response<Makeup> InsertMakeup(string name, string price, string weight, string typeid, string brandid)
        {
            Response<string> response = InsertMakeupRequestValidate(name, price, weight, typeid, brandid);

            if (!response.IsSuccess)
            {
                return new Response<Makeup>
                {
                    Message = response.Payload,
                    IsSuccess = false,
                    Payload = null
                };
            }

            return MakeupHandler.InsertMakeup(name, Convert.ToInt32(price), Convert.ToInt32(weight), Convert.ToInt32(typeid), Convert.ToInt32(brandid));

        }
        public static Response<Makeup> Update(string id, string name, string price, string weight, string typeid, string brandid)
        {
            Response<string> response = UpdateRequestValidate(id, name, price, weight, typeid, brandid);

            if (!response.IsSuccess)
            {
                return new Response<Makeup>
                {
                    Message = response.Payload,
                    IsSuccess = false,
                    Payload = null
                };
            }

            return MakeupHandler.UpdateMakeup(Convert.ToInt32(id), name, Convert.ToInt32(price), Convert.ToInt32(weight), Convert.ToInt32(typeid), Convert.ToInt32(brandid));

        }
        public static Response<Makeup> DeleteMakeup(int id)
        {
            List<string> errors = new List<string>();
            IdValidate(id.ToString(), errors);
            if (errors.Count > 0)
            {
                string message = "";
                foreach (var error in errors)
                {
                    message += error + "|";
                }

                return new Response<Makeup>
                {
                    Message = "Validate Error",
                    IsSuccess = false,
                    Payload = null
                };
            }
            return MakeupHandler.DeleteMakeup(id);
        }

        private static Response<string> InsertMakeupRequestValidate(string name, string price, string weight, string typeid, string brandid)
        {
            List<string> errors = new List<string>();
            NameValidate(name, errors);
            PriceValidate(price, errors);
            WeightValidate(weight, errors);
            TypeIDValidate(typeid, errors);
            BrandIDValidate(brandid, errors);
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
        private static Response<string> UpdateRequestValidate(string id, string name, string price, string weight, string typeid, string brandid)
        {
            List<string> errors = new List<string>();
            IdValidate(id, errors);
            NameValidate(name, errors);
            PriceValidate(price, errors);
            WeightValidate(weight, errors);
            TypeIDValidate(typeid, errors);
            BrandIDValidate(brandid, errors);
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
        private static void PriceValidate(string price, List<string> errors)
        {
            if (string.IsNullOrEmpty(price))
            {
                errors.Add("Price cannot be empty or null");
                return;
            }

            if (int.TryParse(price, out int priceInt))
            {
                if (priceInt <= 0)
                {
                    errors.Add("Price must be greater than or equal to 1");
                }
            }
            else
            {
                errors.Add("Price must be a number");
            }
        }
        private static void WeightValidate(string weight, List<string> errors)
        {
            if (string.IsNullOrEmpty(weight))
            {
                errors.Add("Weight cannot be empty or null");
                return;
            }

            if (int.TryParse(weight, out int weightInt))
            {
                if (weightInt > 1500)
                {
                    errors.Add("Weight cannot be greater than 1500");
                }
            }
            else
            {
                errors.Add("Weight must be a number");
            }
        }
        private static void TypeIDValidate(string typeid, List<string> errors)
        {
            try
            {
                if (typeid == null || typeid == "")
                {
                    errors.Add("Type ID is null");
                    return;
                }
                int typeidInt = Convert.ToInt32(typeid);
                if (MakeupTypeRepository.GetMakeupTypeById(typeidInt) == null)
                {
                    errors.Add("Type ID cannot be found");
                }
            }
            catch (Exception)
            {
                errors.Add("Type Id must be a number");

            }
        }
        private static void BrandIDValidate(string brandid, List<string> errors)
        {
            try
            {
                if (brandid == null || brandid == "")
                {
                    errors.Add("Brand ID is null");
                    return;
                }
                int brandidInt = Convert.ToInt32(brandid);
                if (MakeupBrandRepository.GetMakeupBrandById(brandidInt) == null)
                {
                    errors.Add("Brand ID cannot be found");
                }
            }
            catch (Exception)
            {
                errors.Add("Brand Id must be a number");

            }
        }
    }
}