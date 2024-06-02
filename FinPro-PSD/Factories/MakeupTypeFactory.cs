using FinPro_PSD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinPro_PSD.Factories
{
    public class MakeupTypeFactory
    {
        public static MakeupType CreateMakeupType(int id, string name)
        {
            return new MakeupType
            {
                MakeupTypeID = id,
                MakeupTypeName = name
            };
        }
    }
}