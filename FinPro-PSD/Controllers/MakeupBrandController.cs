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
    public class MakeupBrandController
    {
        public static Response<MakeupBrand> GetMakeupBrandById(int id)
        {
            return MakeupBrandHandler.GetMakeupBrandById(id);
        }
        public static Response<List<MakeupBrand>> GetAllMakeupBrands()
        {
            return MakeupBrandHandler.GetAllMakeupBrands();
        }
        public static Response<MakeupBrand> InsertMakeupBrand(string name, string rating)
        {
            Response<string> response = InsertMakeupBrandRequestValidate(name, rating);
            if (!response.IsSuccess)
            {
                return new Response<MakeupBrand>
                {
                    Message = response.Payload,
                    IsSuccess = false,
                    Payload = null
                };
            }
            return MakeupBrandHandler.InsertMakeupBrand(name, Convert.ToInt32(rating));
        }
        public static Response<MakeupBrand> RemoveMakeupBrandById(string id)
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

                return new Response<MakeupBrand>
                {
                    Message = "Validate Error",
                    IsSuccess = false,
                    Payload = null
                };
            }
            return MakeupBrandHandler.RemoveMakeupBrandById(Convert.ToInt32(id));
        }
        private static Response<string> InsertMakeupBrandRequestValidate(string name, string rating)
        {
            List<string> errors = new List<string>();
            NameValidate(name, errors);
            RatingValidate(rating, errors);
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
        private static void RatingValidate(string rating, List<string> errors)
        {
            if (string.IsNullOrEmpty(rating))
            {
                errors.Add("Rating cannot be empty or null");
                return;
            }

            if (int.TryParse(rating, out int ratingInt))
            {
                if (ratingInt < 0 || ratingInt > 100)
                {
                    errors.Add("Rating must be between 0 and 100");
                }
            }
            else
            {
                errors.Add("Rating must be a number");
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
        public static Response<MakeupBrand> UpdateMakeupBrand(string id, string brandName, string brandRating)
        {
            Response<string> response = UpdateMakeupBrandValidate(id, brandName, brandRating);
            if (!response.IsSuccess)
            {
                return new Response<MakeupBrand>
                {
                    Message = response.Payload,
                    IsSuccess = false,
                    Payload = null
                };
            }

            return MakeupBrandHandler.UpdateMakeupBrand(Convert.ToInt32(id), brandName, Convert.ToInt32(brandRating));
        }
        private static Response<string> UpdateMakeupBrandValidate(string id, string brandName, string brandRating)
        {
            List<string> errors = new List<string>();
            BrandIDValidate(id, errors);
            NameValidate(brandName, errors);
            RatingValidate(brandRating, errors);

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