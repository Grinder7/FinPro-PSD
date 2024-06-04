using FinPro_PSD.Controllers;
using FinPro_PSD.Helpers;
using FinPro_PSD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinPro_PSD.Views
{
    public partial class OrderMakeupPage : System.Web.UI.Page
    {
        public List<Cart> Carts
        {
            get
            {
                return (Session["carts"] != null) ? (List<Cart>)Session["carts"] : InitializeSessionCart();
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Session["user"] != null && ((User)Session["user"]).UserRole == "customer"))
            {
                Response.Redirect("~/Views/HomePage.aspx");
            }
            if (Session["carts"] == null)
            {
                InitializeSessionCart();
            }
            if (!IsPostBack)
            {
                Response<List<Makeup>> response = MakeupController.GetAllMakeups();
                if (response.IsSuccess)
                {
                    OrderMakeupGv.DataSource = response.Payload;
                    OrderMakeupGv.DataBind();
                }
            }
        }

        protected void OrderBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Button button = (Button)sender;
                GridViewRow row = (GridViewRow)button.NamingContainer;
                int makeupID = Convert.ToInt32(((HiddenField)row.FindControl("MakeupIDHf")).Value);
                int quantity = Convert.ToInt32(((TextBox)row.FindControl("QuantityTbx")).Text);
                int userId = ((User)Session["user"]).UserID;
                Response<Cart> response = CartController.InsertCart(userId, makeupID, quantity);
                if (response.IsSuccess)
                {
                    ((List<Cart>)Session["carts"]).Add(response.Payload);
                }
                else
                {
                    Response.Write("<script>alert('" + response.Message + "')</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }

        protected void ClearCartBtn_Click(object sender, EventArgs e)
        {
            List<Cart> carts = Carts;
            List<int> cartsId = new List<int>();
            foreach (var cart in carts)
            {
                cartsId.Add(cart.CartID);
            }
            Response<List<Cart>> response = CartController.RemoveCartsById(cartsId);
            if (!response.IsSuccess)
            {
                Response.Write("<script>alert('" + response.Message + "')</script>");
            }
            else
            {
                ((List<Cart>)Session["carts"]).Clear();
            }
            Response.Redirect("~/Views/OrderMakeupPage.aspx");
        }

        protected void CheckoutBtn_Click(object sender, EventArgs e)
        {
            if (((List<Cart>)Session["carts"]).Count < 0)
            {
                Response.Write("<script>alert('Cart is empty')</script>");
            }
            List<Cart> carts = (List<Cart>)Session["carts"];
            Response<TransactionHeader> response = TransactionHeaderController.CheckoutCart(carts);
            if (response.IsSuccess)
            {
                CartController.RemoveCartsById(carts.Select(c => c.CartID).ToList());
                Response.Write("<script>alert('Checkout Success')</script>");
                ((List<Cart>)Session["carts"]).Clear();
                Response.Redirect("~/Views/OrderMakeupPage.aspx");
            }
            else
            {
                Response.Write("<script>alert('" + response.Message + "')</script>");
            }
        }

        private List<Cart> InitializeSessionCart()
        {
            Response<List<Cart>> response = CartController.GetCardByUserId(((User)Session["user"]).UserID);
            if (response.IsSuccess)
            {
                Session["carts"] = response.Payload;
                return response.Payload;
            }
            Session["carts"] = new List<Cart>();
            return (List<Cart>)Session["carts"];
        }
    }
}