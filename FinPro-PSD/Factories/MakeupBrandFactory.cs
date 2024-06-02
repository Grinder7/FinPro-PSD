using FinPro_PSD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinPro_PSD.Factories
{
    public class MakeupBrandFactory
    {
        public static MakeupBrand CreateMakeupBrand(int id, string name, int rating)
        {
            return new MakeupBrand
            {
                MakeupBrandID = id,
                MakeupBrandName = name,
                MakeupBrandRating = rating
            };
        }
    }
}