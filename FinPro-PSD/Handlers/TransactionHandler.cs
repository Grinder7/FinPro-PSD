using FinPro_PSD.Models;
using FinPro_PSD.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinPro_PSD.Handlers
{
    public class TransactionHandler
    {
       public static List<TransactionHeader> GetTransactionHeaders()
        {
             return TransactionRepository.GetTransactionHeaders();
        }
    }
}