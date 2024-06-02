using FinPro_PSD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinPro_PSD.Repositories
{
    public class MakeupTypeRepository
    {
        private static readonly Database1Entities db = new Database1Entities();
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
        public static MakeupType UpdateMakeupType(MakeupType makeup)
        {
            MakeupType updatedMakeupType = db.MakeupTypes.Find(makeup.MakeupTypeID);
            updatedMakeupType.MakeupTypeName = makeup.MakeupTypeName;
            db.SaveChanges();
            return makeup;
        }
        public static int DeleteMakeupTypeById(int id)
        {
            MakeupType deletedMakeupType = db.MakeupTypes.Find(id);
            if (deletedMakeupType != null)
            {
                db.MakeupTypes.Remove(deletedMakeupType);
            }
            return db.SaveChanges();
        }
    }
}