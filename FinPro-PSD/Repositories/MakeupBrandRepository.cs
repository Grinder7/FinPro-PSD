using FinPro_PSD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinPro_PSD.Repositories
{
    public class MakeupBrandRepository
    {
        private static readonly Database1Entities db = new Database1Entities();
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