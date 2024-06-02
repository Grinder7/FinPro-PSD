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
        public static List<Makeup> GetMakeupsByMakeupTypeId(int typeId)
        {
            return db.Makeups.Where(x => x.MakeupTypeID == typeId).ToList();
        }
        public static List<Makeup> GetMakeupsByBrandId(int brandId)
        {
            return db.Makeups.Where(x => x.MakeupBrandID == brandId).ToList();
        }
    }
}