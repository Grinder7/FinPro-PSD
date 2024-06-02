using FinPro_PSD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinPro_PSD.Factories
{
    public class MakeupFactory
    {
        public static Makeup CreateMakeup(int id, string name, int price, int weight, int typeid, int brandid)
        {
            return new Makeup
            {
                MakeupID = id,
                MakeupName = name,
                MakeupPrice = price,
                MakeupWeight = weight,
                MakeupTypeID = typeid,
                MakeupBrandID = brandid
            };
        }
    }
}