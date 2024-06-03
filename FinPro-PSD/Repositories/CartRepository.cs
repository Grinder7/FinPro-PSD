using FinPro_PSD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinPro_PSD.Repositories
{
    public class CartRepository
    {
        private static Database1Entities db = new Database1Entities();

        public static Cart GetCartById(int cartId)
        {
            return db.Carts.Find(cartId);
        }

        public static List<Cart> GetCartByUserId(int userId)
        {
            return db.Carts.Where(x => x.UserID == userId).ToList();
        }

        public static int InsertCart(Cart cart)
        {
            db.Carts.Add(cart);
            return db.SaveChanges();
        }

        public static int RemoveCartById(int cardId)
        {
            Cart delete = GetCartById(cardId);
            if (delete != null)
            {
                db.Carts.Remove(delete);
                return db.SaveChanges();
            }
            return 0;
        }

        public static Cart GetLastCart()
        {
            return db.Carts.ToList().LastOrDefault();
        }
    }
}