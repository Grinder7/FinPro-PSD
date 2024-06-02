using FinPro_PSD.Factories;
using FinPro_PSD.Helpers;
using FinPro_PSD.Models;
using FinPro_PSD.Repositories;
using FinPro_PSD.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinPro_PSD.Handlers
{
    public class MakeupHandler
    {
        public static int GenerateIDMakeup()
        {
            Makeup makeup = MakeupRepository.GetLastMakeup();

            if (makeup == null)
            {
                return 1;
            }
            return makeup.MakeupID + 1;
        }

        public static Response<List<Makeup>> GetAllMakeups()
        {
            List<Makeup> makeups = MakeupRepository.GetAllMakeups();
            if (makeups.Count > 0)
            {
                return new Response<List<Makeup>>
                {
                    Message = "Success",
                    IsSuccess = true,
                    Payload = makeups
                };
            }
            return new Response<List<Makeup>>
            {
                Message = "No makeups found",
                IsSuccess = false,
                Payload = null
            };
        }

        public static Response<Makeup> GetMakeupById(int id)
        {
            Makeup makeup = MakeupRepository.GetMakeupById(id);
            if (makeup != null)
            {
                return new Response<Makeup>
                {
                    Message = "Success",
                    IsSuccess = true,
                    Payload = makeup
                };
            }
            return new Response<Makeup>
            {
                Message = "Makeup not found",
                IsSuccess = false,
                Payload = null
            };
        }
        public static Response<Makeup> InsertMakeup(string name, int price, int weight, int typeid, int brandid)
        {
            Makeup makeup = MakeupFactory.CreateMakeup(GenerateIDMakeup(), name, price, weight, typeid, brandid);

            if (MakeupRepository.InsertMakeup(makeup) == 0)
            {
                return new Response<Makeup>
                {
                    Message = "Something went wrong",
                    IsSuccess = false,
                    Payload = null
                };
            }

            return new Response<Makeup>
            {
                Message = "Success",
                IsSuccess = true,
                Payload = makeup
            };
        }

        public static Response<Makeup> UpdateMakeup(int id, string name, int price, int weight, int typeid, int brandid)
        {
            Makeup makeup = MakeupFactory.CreateMakeup(id, name, price, weight, typeid, brandid);
            Makeup updatedMakeup = MakeupRepository.UpdateMakeup(makeup);

            if (updatedMakeup == null)
            {
                return new Response<Makeup>
                {
                    Message = "Something went wrong",
                    IsSuccess = false,
                    Payload = null
                };
            }

            return new Response<Makeup>
            {
                Message = "Success",
                IsSuccess = true,
                Payload = makeup
            };
        }

        public static int GenerateIDMakeupType()
        {
            MakeupType makeup = MakeupRepository.GetLastMakeupType();

            if (makeup == null)
            {
                return 1;
            }
            return makeup.MakeupTypeID + 1;
        }

        public static Response<List<MakeupType>> GetAllMakeupTypes()
        {
            List<MakeupType> makeups = MakeupRepository.GetAllMakeupTypes();
            if (makeups.Count > 0)
            {
                return new Response<List<MakeupType>>
                {
                    Message = "Success",
                    IsSuccess = true,
                    Payload = makeups
                };
            }
            return new Response<List<MakeupType>>
            {
                Message = "No makeups found",
                IsSuccess = false,
                Payload = null
            };
        }

        public static Response<MakeupType> GetMakeupTypeById(int id)
        {
            MakeupType makeup = MakeupRepository.GetMakeupTypeById(id);
            if (makeup != null)
            {
                return new Response<MakeupType>
                {
                    Message = "Success",
                    IsSuccess = true,
                    Payload = makeup
                };
            }
            return new Response<MakeupType>
            {
                Message = "Makeup not found",
                IsSuccess = false,
                Payload = null
            };
        }
        public static Response<MakeupType> InsertMakeupType(string name)
        {
            MakeupType makeup = MakeupFactory.CreateMakeupType(GenerateIDMakeupType(), name);

            if (MakeupRepository.InsertMakeupType(makeup) == 0)
            {
                return new Response<MakeupType>
                {
                    Message = "Something went wrong",
                    IsSuccess = false,
                    Payload = null
                };
            }

            return new Response<MakeupType>
            {
                Message = "Success",
                IsSuccess = true,
                Payload = makeup
            };
        }

        public static int GenerateIDMakeupBrand()
        {
            MakeupBrand makeup = MakeupRepository.GetLastMakeupBrand();

            if (makeup == null)
            {
                return 1;
            }
            return makeup.MakeupBrandID + 1;
        }

        public static Response<List<MakeupBrand>> GetAllMakeupBrands()
        {
            List<MakeupBrand> makeups = MakeupRepository.GetAllMakeupBrands();
            if (makeups.Count > 0)
            {
                return new Response<List<MakeupBrand>>
                {
                    Message = "Success",
                    IsSuccess = true,
                    Payload = makeups
                };
            }
            return new Response<List<MakeupBrand>>
            {
                Message = "No makeups found",
                IsSuccess = false,
                Payload = null
            };
        }

        public static Response<MakeupBrand> GetMakeupBrandById(int id)
        {
            MakeupBrand makeup = MakeupRepository.GetMakeupBrandById(id);
            if (makeup != null)
            {
                return new Response<MakeupBrand>
                {
                    Message = "Success",
                    IsSuccess = true,
                    Payload = makeup
                };
            }
            return new Response<MakeupBrand>
            {
                Message = "Makeup not found",
                IsSuccess = false,
                Payload = null
            };
        }
        public static Response<MakeupBrand> InsertMakeupBrand(string name, int rating)
        {
            MakeupBrand makeup = MakeupFactory.CreateMakeupBrand(GenerateIDMakeupBrand(), name, rating);

            if (MakeupRepository.InsertMakeupBrand(makeup) == 0)
            {
                return new Response<MakeupBrand>
                {
                    Message = "Something went wrong",
                    IsSuccess = false,
                    Payload = null
                };
            }

            return new Response<MakeupBrand>
            {
                Message = "Success",
                IsSuccess = true,
                Payload = makeup
            };
        }

        public static Response<MakeupBrand> UpdateMakeupBrand(int id, string brandName, int rating)
        {
            MakeupBrand makeupBrand = MakeupFactory.CreateMakeupBrand(id, brandName, rating);
            MakeupBrand updatedMakeupBrand = MakeupRepository.UpdateMakeupBrand(makeupBrand);
            if (updatedMakeupBrand == null)
            {
                return new Response<MakeupBrand>
                {
                    Message = "Something went wrong",
                    IsSuccess = false,
                    Payload = null
                };
            }

            return new Response<MakeupBrand>
            {
                Message = "Success",
                IsSuccess = true,
                Payload = makeupBrand
            };

        }

        public static Response<MakeupBrand> RemoveMakeupBrandById(int brandId)
        {
            try
            {
                MakeupBrand makeupBrand = MakeupRepository.GetMakeupBrandById(brandId); 
                List<Makeup> makeups = MakeupRepository.GetMakeupsByBrandId(brandId);
                if (makeups.Count > 0)
                {
                    foreach (Makeup makeup in makeups)
                    {
                        MakeupRepository.DeleteMakeup(makeup.MakeupID);
                    }
                }
                if(MakeupRepository.DeleteMakeupBrandById(brandId) == 0)
                {
                    return new Response<MakeupBrand>
                    {
                        Message = "Something went wrong",
                        IsSuccess = false,
                        Payload = null
                    };
                }
                return new Response<MakeupBrand>
                {
                    Message = "Success",
                    IsSuccess = true,
                    Payload = makeupBrand
                };
            }
            catch (Exception e)
            {
                return new Response<MakeupBrand>
                {
                    Message = e.Message,
                    IsSuccess = false,
                    Payload = null
                };
            }

        }
    }
}