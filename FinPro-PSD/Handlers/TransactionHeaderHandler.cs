using FinPro_PSD.Factories;
using FinPro_PSD.Helpers;
using FinPro_PSD.Models;
using FinPro_PSD.Repositories;
using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.Util;

namespace FinPro_PSD.Handlers
{
    public class TransactionHeaderHandler
    {
        public static object TransactionDetailFactory { get; private set; }



        public static Response<List<TransactionHeader>> GetAllTransactionHeaders()
        {
            List<TransactionHeader> transactions = TransactionHeaderRepository.GetAllTransactionHeaders();
            if (transactions.Count > 0)
            {
                return new Response<List<TransactionHeader>>
                {
                    Message = "Success",
                    IsSuccess = true,
                    Payload = transactions
                };
            }
            return new Response<List<TransactionHeader>>
            {
                Message = "No transaction found",
                IsSuccess = false,
                Payload = null
            };
        }

        public static Response<TransactionHeader> GetTransactionHeaderById(int id)
        {
            TransactionHeader transaction = TransactionHeaderRepository.GetTransactionHeaderById(id);
            if (transaction != null)
            {
                return new Response<TransactionHeader>
                {
                    Message = "Success",
                    IsSuccess = true,
                    Payload = transaction
                };
            }
            return new Response<TransactionHeader>
            {
                Message = "No transaction found",
                IsSuccess = false,
                Payload = null
            };
        }

        public static Response<List<TransactionHeader>> GetTransactionHeaderByUserId(int id)
        {
            List<TransactionHeader> transactions = TransactionHeaderRepository.GetTransactionHeaderByUserId(id);

            if (transactions != null)
            {
                return new Response<List<TransactionHeader>>
                {
                    Message = "Success",
                    IsSuccess = true,
                    Payload = transactions
                };
            }
            return new Response<List<TransactionHeader>>
            {
                Message = "Transaction not found",
                IsSuccess = false,
                Payload = null
            };
      
        }

        public static Response<TransactionHeader> UpdateTransactionHeaderStatus(TransactionHeader transaction)
        {
            TransactionHeader tran = TransactionHeaderRepository.UpdateTransactionHeaderStatus(transaction);
            if (tran != null)
            {
                return new Response<TransactionHeader>
                {
                    Message = "Success",
                    IsSuccess = true,
                    Payload = tran
                };
            }
            return new Response<TransactionHeader>
            {
                Message = "Transaction not found",
                IsSuccess = false,
                Payload = null
            };
        }

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