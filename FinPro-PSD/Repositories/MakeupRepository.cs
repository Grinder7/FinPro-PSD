using FinPro_PSD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinPro_PSD.Repositories
{
    public class MakeupRepository
    {
        private static readonly Database1Entities db = new Database1Entities();
        public static Makeup GetLastMakeup()
        {
            return db.Makeups.ToList().LastOrDefault();
        }
        public static List<Makeup> GetAllMakeups()
        {
            return db.Makeups.ToList();
        }

        public static Makeup GetMakeupById(int id)
        {
            return db.Makeups.Find(id);
        }
        public static int InsertMakeup(Makeup makeup)
        {
            db.Makeups.Add(makeup);
            return db.SaveChanges();
        }

        public static Makeup UpdateMakeup(Makeup makeup)
        {
            Makeup updatedMakeup = db.Makeups.Find(makeup.MakeupID);
            updatedMakeup.MakeupName = makeup.MakeupName;
            updatedMakeup.MakeupPrice = makeup.MakeupPrice;
            updatedMakeup.MakeupWeight = makeup.MakeupWeight;
            updatedMakeup.MakeupTypeID = makeup.MakeupTypeID;
            updatedMakeup.MakeupBrandID = makeup.MakeupBrandID;
            db.SaveChanges();
            return makeup;
        }

        public static Makeup DeleteMakeup(int id)
        {
            Makeup deletedMakeup = db.Makeups.Find(id);
            if (deletedMakeup != null)
            {
                db.Makeups.Remove(deletedMakeup);
                db.SaveChanges();
            }
            return deletedMakeup;
        }


        public static MakeupType GetMakeupTypeById(int id)
        {
            return db.MakeupTypes.Find(id);
        }

        public static MakeupType GetLastMakeupType()
        {
            return db.MakeupTypes.ToList().LastOrDefault();
        }
        public static List<MakeupType> GetAllMakeupTypes()
        {
            return db.MakeupTypes.ToList();
        }
        public static int InsertMakeupType(MakeupType makeup)
        {
            db.MakeupTypes.Add(makeup);
            return db.SaveChanges();
        }

        public static MakeupBrand GetMakeupBrandById(int id)
        {
            return db.MakeupBrands.Find(id);
        }
        public static MakeupBrand GetLastMakeupBrand()
        {
            return db.MakeupBrands.ToList().LastOrDefault();
        }
        public static List<MakeupBrand> GetAllMakeupBrands()
        {
            return db.MakeupBrands.ToList();
        }
        public static int InsertMakeupBrand(MakeupBrand makeup)
        {
            db.MakeupBrands.Add(makeup);
            return db.SaveChanges();
        }

        public static MakeupBrand UpdateMakeupBrand(MakeupBrand makeup)
        {
            MakeupBrand updatedMakeupBrand = db.MakeupBrands.Find(makeup.MakeupBrandID);
            updatedMakeupBrand.MakeupBrandName = makeup.MakeupBrandName;
            updatedMakeupBrand.MakeupBrandRating = makeup.MakeupBrandRating;
            db.SaveChanges();
            return makeup;
        }

        public static List<Makeup> GetMakeupsByBrandId(int brandId)
        {
            return db.Makeups.Where(x => x.MakeupBrandID == brandId).ToList();
        }

        public static int DeleteMakeupBrandById(int id)
        {
            MakeupBrand deletedMakeupBrand = db.MakeupBrands.Find(id);
            if (deletedMakeupBrand != null)
            {
                db.MakeupBrands.Remove(deletedMakeupBrand);
            }
            return db.SaveChanges();
            
        }
    }
}