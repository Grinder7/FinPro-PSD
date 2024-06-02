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
    public class MakeupTypeHandler
    {
        public static int GenerateIDMakeupType()
        {
            MakeupType makeup = MakeupTypeRepository.GetLastMakeupType();

            if (makeup == null)
            {
                return 1;
            }
            return makeup.MakeupTypeID + 1;
        }

        public static Response<List<MakeupType>> GetAllMakeupTypes()
        {
            List<MakeupType> makeups = MakeupTypeRepository.GetAllMakeupTypes();
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
            MakeupType makeup = MakeupTypeRepository.GetMakeupTypeById(id);
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
            MakeupType makeup = MakeupTypeFactory.CreateMakeupType(GenerateIDMakeupType(), name);

            if (MakeupTypeRepository.InsertMakeupType(makeup) == 0)
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

        public static Response<MakeupType> UpdateMakeupType(int id, string name)
        {
            MakeupType makeupType = MakeupTypeFactory.CreateMakeupType(id, name);
            MakeupType updatedMakeupType = MakeupTypeRepository.UpdateMakeupType(makeupType);
            if (updatedMakeupType == null)
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
                Payload = makeupType
            };
        }

        public static Response<MakeupType> RemoveMakeupType(int makeupTypeId)
        {
            MakeupType makeupType = MakeupTypeRepository.GetMakeupTypeById(makeupTypeId);
            List<Makeup> makeups = MakeupRepository.GetMakeupsByMakeupTypeId(makeupTypeId);
            if (makeups.Count > 0)
            {
                foreach (Makeup makeup in makeups)
                {
                    if (MakeupRepository.DeleteMakeup(makeup.MakeupID) == null)
                    {
                        return new Response<MakeupType>
                        {
                            Message = "Failed to remove makeup id:" + makeup.MakeupID,
                            IsSuccess = false,
                            Payload = null
                        };
                    }
                }
            }
            if (MakeupTypeRepository.DeleteMakeupTypeById(makeupTypeId) == 0)
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
                Payload = makeupType
            };
        }
    }
}