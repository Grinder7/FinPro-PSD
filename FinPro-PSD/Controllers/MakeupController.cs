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
        public static Response<MakeupType> GetMakeupTypeById(int id)
        {
            return MakeupHandler.GetMakeupTypeById(id);
        }
        public static Response<List<MakeupType>> GetAllMakeupTypes()
        {
            return MakeupHandler.GetAllMakeupTypes();
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
            return MakeupHandler.InsertMakeupType(name);
        }
        public static Response<MakeupBrand> GetMakeupBrandById(int id)
        {
            return MakeupHandler.GetMakeupBrandById(id);
        }
        public static Response<List<MakeupBrand>> GetAllMakeupBrands()
        {
            return MakeupHandler.GetAllMakeupBrands();
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
            return MakeupHandler.InsertMakeupBrand(name, Convert.ToInt32(rating));
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
            return MakeupHandler.RemoveMakeupBrandById(Convert.ToInt32(id));
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
            return MakeupHandler.UpdateMakeupType(Convert.ToInt32(id), name);
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
            return MakeupHandler.RemoveMakeupType(Convert.ToInt32(id));
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
            try
            {
                int? priceInt = Convert.ToInt32(price);
                if (!priceInt.HasValue)
                {
                    errors.Add("Price is null");
                }
                else
                {
                    if (priceInt <= 0)
                    {
                        errors.Add("Price must be greater than or equals than 1");
                    }
                }
            }
            catch (Exception)
            {
                errors.Add("Price must be a number");
            }
        }
        private static void WeightValidate(string weight, List<string> errors)
        {
            try
            {
                int? weightInt = Convert.ToInt32(weight);

                if (!weightInt.HasValue)
                {
                    errors.Add("Weight is null");
                }
                else
                {
                    if (weightInt <= 0)
                    {
                        errors.Add("Weight cannot be greater than 1500 since it is in grams");
                    }
                }
            }
            catch (Exception)
            {
                errors.Add("Weight must be a number");

            }
        }
        private static void TypeIDValidate(string typeid, List<string> errors)
        {
            try
            {
                if(typeid == null || typeid == "")
                {
                    errors.Add("Type ID is null");
                    return;
                }
                int typeidInt = Convert.ToInt32(typeid);
                if(MakeupRepository.GetMakeupTypeById(typeidInt) == null)
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
                if (MakeupRepository.GetMakeupBrandById(brandidInt) == null)
                {
                    errors.Add("Brand ID cannot be found");
                }
            }
            catch (Exception)
            {
                errors.Add("Brand Id must be a number");

            }
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
            try
            {
                int? ratingInt = Convert.ToInt32(rating);
                if (!ratingInt.HasValue)
                {
                    errors.Add("Rating is null");
                }
                else
                {
                    if (ratingInt < 0 || ratingInt > 99)
                    {
                        errors.Add("Price must be between 1 - 99 characters");
                    }
                }
            }
            catch (Exception)
            {
                errors.Add("Rating must be a number");
            }
        }
        public static Response<MakeupBrand> UpdateMakeupBrand(string id, string brandName, string brandRating)
        {
            Response<string> response = UpdateMakeupBrandValidate(id, brandName, brandRating);
            if(!response.IsSuccess)
            {
                return new Response<MakeupBrand>
                {
                    Message = response.Payload,
                    IsSuccess = false,
                    Payload = null
                };
            }

            return MakeupHandler.UpdateMakeupBrand(Convert.ToInt32(id), brandName, Convert.ToInt32(brandRating));
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
    }
}