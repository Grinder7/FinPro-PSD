using FinPro_PSD.Handlers;
using FinPro_PSD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinPro_PSD.Factories
{
    public class CartFactory
    {
        public static Cart CreateCart(int cardId, int userId, int makeupId, int quantity)
        {
            return new Cart
            {
                CartID = cardId,
                UserID = userId,
                MakeupID = makeupId,
                Quantity = quantity
            };
        }
    }
}