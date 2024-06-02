using FinPro_PSD.Factories;
using FinPro_PSD.Helpers;
using FinPro_PSD.Models;
using FinPro_PSD.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinPro_PSD.Handlers
{
    public class MakeupBrandHandler
    {
        public static int GenerateIDMakeupBrand()
        {
            MakeupBrand makeup = MakeupBrandRepository.GetLastMakeupBrand();

            if (makeup == null)
            {
                return 1;
            }
            return makeup.MakeupBrandID + 1;
        }

        public static Response<List<MakeupBrand>> GetAllMakeupBrands()
        {
            List<MakeupBrand> makeups = MakeupBrandRepository.GetAllMakeupBrands();
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
            MakeupBrand makeup = MakeupBrandRepository.GetMakeupBrandById(id);
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
            MakeupBrand makeup = MakeupBrandFactory.CreateMakeupBrand(GenerateIDMakeupBrand(), name, rating);

            if (MakeupBrandRepository.InsertMakeupBrand(makeup) == 0)
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
            MakeupBrand makeupBrand = MakeupBrandFactory.CreateMakeupBrand(id, brandName, rating);
            MakeupBrand updatedMakeupBrand = MakeupBrandRepository.UpdateMakeupBrand(makeupBrand);
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
            MakeupBrand makeupBrand = MakeupBrandRepository.GetMakeupBrandById(brandId);
            List<Makeup> makeups = MakeupRepository.GetMakeupsByBrandId(brandId);
            if (makeups.Count > 0)
            {
                foreach (Makeup makeup in makeups)
                {
                    if (MakeupRepository.DeleteMakeup(makeup.MakeupID) == null)
                    {
                        return new Response<MakeupBrand>
                        {
                            Message = "Failed to remove makeup id:" + makeup.MakeupID,
                            IsSuccess = false,
                            Payload = null
                        };
                    }
                }
            }
            if (MakeupBrandRepository.DeleteMakeupBrandById(brandId) == 0)
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
    }
}