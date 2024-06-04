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
    public class TransactionHeaderHandler
    {
        public static object TransactionDetailFactory { get; private set; }

        public static Response<TransactionHeader> CheckoutCart(List<Cart> carts)
        {
            TransactionHeader transactionHeader = TransactionHeaderFactory.CreateTransactionHeader(GenerateTransactionID(), carts[0].UserID, DateTime.Now, "unhandled");
            if(TransactionHeaderRepository.InsertTransactionHeader(transactionHeader) == 0)
            {
                return new Response<TransactionHeader>
                {
                    Message = "Failed to checkout",
                    IsSuccess = false,
                    Payload = null
                };
            }

            foreach (Cart cart in carts)
            {
                Response<TransactionDetail> response = TransactionDetailHandler.InsertTransactionDetail(transactionHeader.TransactionID, cart.MakeupID, cart.Quantity);
                if (!response.IsSuccess)
                {
                    RemoveTransactionDetails(transactionHeader);
                    return new Response<TransactionHeader>
                    {
                        Message = "Failed to checkout",
                        IsSuccess = false,
                        Payload = null
                    };
                }
            }

            return new Response<TransactionHeader>
            {
                Message = "Success",
                IsSuccess = true,
                Payload = transactionHeader
            };
        }

        private static int GenerateTransactionID()
        {
            TransactionHeader transactionHeader = TransactionHeaderRepository.GetLastTransactionHeader();
            if (transactionHeader == null)
            {
                return 1;
            }
            return transactionHeader.TransactionID + 1;
        }

        private static Response<TransactionHeader> RemoveTransactionDetails(TransactionHeader transactionHeader)
        {
            TransactionDetailHandler.DeleteTransactionDetails(transactionHeader.TransactionID);
            if(TransactionHeaderRepository.DeleteTransactionHeader(transactionHeader.TransactionID) == 0)
            {
                return new Response<TransactionHeader>
                {
                    Message = "Failed to remove transaction details",
                    IsSuccess = false,
                    Payload = null
                };
            }
            return new Response<TransactionHeader>
            {
                Message = "Remove transaction details success",
                IsSuccess = true,
                Payload = null
            };
        }
            

    }
}