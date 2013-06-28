using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections.Generic;

public partial class _Cart : System.Web.UI.Page
{
    //Make a Sorted List
    private List<CartItems> array_cart;
    private String tableBuilder;
<<<<<<< HEAD
<<<<<<< HEAD
    private Int16 borderCounter;
=======
>>>>>>> 20f298e21303c6c9856bd96520d678b2c4443aab
=======
>>>>>>> 20f298e21303c6c9856bd96520d678b2c4443aab
    static string prevPage = String.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        // Redirects user back to previous page when btnGoBack is clicked
<<<<<<< HEAD
<<<<<<< HEAD
        this.btnGoBack.OnClientClick = "javascript:window.history.go(-1); return false;";
=======
        //this.btnGoBack.OnClientClick = "javascript:window.history.go(-1); return false;";
>>>>>>> 20f298e21303c6c9856bd96520d678b2c4443aab
=======
        //this.btnGoBack.OnClientClick = "javascript:window.history.go(-1); return false;";
>>>>>>> 20f298e21303c6c9856bd96520d678b2c4443aab
        this.GetCart();
        if (!IsPostBack)
        {
            this.DisplayCart();
<<<<<<< HEAD
<<<<<<< HEAD
            //prevPage = Request.UrlReferrer.ToString();
=======
            prevPage = Request.UrlReferrer.ToString();
>>>>>>> 20f298e21303c6c9856bd96520d678b2c4443aab
=======
            prevPage = Request.UrlReferrer.ToString();
>>>>>>> 20f298e21303c6c9856bd96520d678b2c4443aab
        }
    }

    //Get Cart Session
    protected void GetCart()
    {
        if (Session["Cart"] == null)
            Session.Add("Cart", array_cart);
        array_cart = (List<CartItems>)Session["Cart"];
    }
    //Display Cart Method
    protected void DisplayCart()
    {
        double singlePrice = 0;
        double singleTaxPrice = 0;

        double totalPrice = 0;
        double totalTaxPrice = 0;

        double totalTaxPriceAfterTax = 0;

        if (array_cart != null)
        {
            tableBuilder += "<div class=\"cart\">" +
                                       "<div class=\"cartHeader\">" +
                                           "<div class=\"cartHeaderItemField\">Movie Title</div>" +
                                           "<div class=\"cartHeaderAgeField\">Age</div>" +
                                           "<div class=\"cartHeaderQuantityField\">Quantity</div>" +
                                           "<div class=\"cartHeaderPriceField\">Price</div>" +
                                       "</div><br /><br /><br />";
<<<<<<< HEAD
<<<<<<< HEAD
            borderCounter = 0;
            foreach (CartItems items in array_cart)
            {
                borderCounter++;

=======

            foreach (CartItems items in array_cart)
            {
>>>>>>> 20f298e21303c6c9856bd96520d678b2c4443aab
=======

            foreach (CartItems items in array_cart)
            {
>>>>>>> 20f298e21303c6c9856bd96520d678b2c4443aab
                CartItems ticket = items;
                singlePrice = (ticket.quantity * Convert.ToDouble(ticket.price));
                singleTaxPrice = (singlePrice * 0.05);

<<<<<<< HEAD
<<<<<<< HEAD
                if (borderCounter == 1)
                {
                    tableBuilder += "<div class=\"cartServiceHeader\" style=\"border-top: 1px solid #000000;\">";
                }
                else
                {
                    tableBuilder += "<div class=\"cartServiceHeader\">";
                }

                tableBuilder +=     "<div class=\"cartItemField\">" + ticket.title + "</div>" +
                                    "<div class=\"cartAgeField\">" + ticket.age + "</div>" +
                                    "<div class=\"cartQuantityField\">" + ticket.quantity + "</div>" +
                                    "<div class=\"cartPriceField\">" + singlePrice.ToString("c") + "</div>" +
                                "</div><br />";
=======
=======
>>>>>>> 20f298e21303c6c9856bd96520d678b2c4443aab
                tableBuilder += "<div class=\"serviceHeader\">" +
                                            "<div class=\"cartItemField\">" + ticket.title + "</div>" +
                                            "<div class=\"cartAgeField\">" + ticket.age + "</div>" +
                                            "<div class=\"cartQuantityField\">" + ticket.quantity + "</div>" +
                                            "<div class=\"cartPriceField\">" + singlePrice.ToString("c") + "</div>" +
                                        "</div>" +
                                    "</div>";
<<<<<<< HEAD
>>>>>>> 20f298e21303c6c9856bd96520d678b2c4443aab
=======
>>>>>>> 20f298e21303c6c9856bd96520d678b2c4443aab

                totalPrice += singlePrice;
                totalTaxPrice += singleTaxPrice;
            }
            totalTaxPriceAfterTax = (totalPrice + totalTaxPrice);

<<<<<<< HEAD
<<<<<<< HEAD
            tableBuilder += "<br />&nbsp;<div class=\"cartHeader\">" +
                                "<span class=\"cartSpaceField\" style=\"margin-top: 10px;\"></span>" +
                                "<span class=\"cartInfoItemField\" style=\"margin-top: 10px;\">Net Amount (CAD):</span>" +
                                "<span class=\"cartPriceItemField\" style=\"margin-top: 10px;\">" + totalPrice.ToString("c") + "</span>" +

                                "<span class=\"cartSpaceField\"></span>" +
                                "<span class=\"cartInfoItemField\">Tax:</span>" +
                                "<span class=\"cartPriceItemField\">" + totalTaxPrice.ToString("c") + "</span>" +

                                "<span class=\"cartSpaceField\"></span>" +
                                "<span class=\"cartInfoItemField\">Total Due (CAD):</span>" +
                                "<span class=\"cartPriceItemField\">" + totalTaxPriceAfterTax.ToString("c") + "</span>" +
                            "</div>" +
                        "</div>&nbsp;";
=======
=======
>>>>>>> 20f298e21303c6c9856bd96520d678b2c4443aab
            tableBuilder += "<div class=\"serviceHeader\">" + 
                            "</div><br /><br />" +
                            "<div class=\"cartHeader\">" +
                                "<span id \"lblSpace1\" class=\"cartSpaceField\" style=\"margin-top: 10px;\"></span>" +
                                "<span id \"lblNet\" class=\"cartInfoItemField\" style=\"margin-top: 10px;\">Net Amount (CAD):</span>" +
                                "<span id \"lblNetPrice\" class=\"cartPriceItemField\" style=\"margin-top: 10px;\">" + totalPrice.ToString("c") + "</span>" +

                                "<span id \"lblSpace2\" class=\"cartSpaceField\"></span>" +
                                "<span id \"lblTax\" class=\"cartInfoItemField\">Tax:</span>" +
                                "<span id \"lblTaxPrice\" class=\"cartPriceItemField\">" + totalTaxPrice.ToString("c") + "</span>" +

                                "<span id \"lblSpace3\" class=\"cartSpaceField\"></span>" +
                                "<span id \"lblTotal\" class=\"cartInfoItemField\">Total Due (CAD):</span>" +
                                "<span id \"lblTotalPrice\" class=\"cartPriceItemField\">" + totalTaxPriceAfterTax.ToString("c") + "</span>" +
                            "</div><br /><br />";
<<<<<<< HEAD
>>>>>>> 20f298e21303c6c9856bd96520d678b2c4443aab
=======
>>>>>>> 20f298e21303c6c9856bd96520d678b2c4443aab
            lblCart.Text = tableBuilder;
        }
    }
    // Empty Click Event Handler
    protected void btn_empty_Click(object sender, EventArgs e)
    {
        array_cart.Clear();
    }
    //Transfer to Checkout
    protected void btnCheckout_Click(object sender, EventArgs e)
    {
        if (array_cart.Count > 0)
        {
            Response.Redirect("~/Promo/CheckOut.aspx");
        }
        else
        {
            lblCart.Text = "Sorry, there is nothing to check out from the cart.";
        }
    }
    protected void btnGoBack_Click(object sender, EventArgs e)
    {
<<<<<<< HEAD
<<<<<<< HEAD
        //Response.Redirect(Request.UrlReferrer.ToString());
=======
        Response.Redirect(prevPage);
>>>>>>> 20f298e21303c6c9856bd96520d678b2c4443aab
=======
        Response.Redirect(prevPage);
>>>>>>> 20f298e21303c6c9856bd96520d678b2c4443aab
    }
}
