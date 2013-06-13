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

public partial class _Cart : System.Web.UI.Page
{
    //Make a Sorted List
    private SortedList array_cart;
    static string prevPage = String.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        // Redirects user back to previous page when btnGoBack is clicked
        //this.btnGoBack.OnClientClick = "javascript:window.history.go(-1); return false;";
        this.GetCart();
        if (!IsPostBack)
        {
            this.DisplayCart();
            prevPage = Request.UrlReferrer.ToString();
        }
    }

    //Get Cart Session
    protected void GetCart()
    {
        if (Session["Cart"] == null)
            Session.Add("Cart", array_cart);
        array_cart = (SortedList)Session["Cart"];
    }
    //Display Cart Method
    protected void DisplayCart()
    {
        lbMovieCart.Items.Clear();
        CartItem item;
        foreach (DictionaryEntry entry in array_cart)
        {
            item = (CartItem)entry.Value;
            lbMovieCart.Items.Add(item.Display());
        }
    }
    // Empty Click Event Handler
    protected void btn_empty_Click(object sender, EventArgs e)
    {
        array_cart.Clear();
        lbMovieCart.Items.Clear();
    }
    // Remove Click Event Handler
    protected void btn_remove_Click(object sender, EventArgs e)
    {
        if (array_cart.Count > 0)
        {
            if (lbMovieCart.SelectedIndex > -1)
            {
                array_cart.RemoveAt(lbMovieCart.SelectedIndex);
                this.DisplayCart();
            }
            else
            {
                lblMessage.Text = "Please select the item you want to remove.";
            }
        }
    }
    //Transfer to Checkout
    protected void btn_checkout_Click(object sender, EventArgs e)
    {
        if (array_cart.Count > 0)
        {
            Response.Redirect("~/CheckOut.aspx");
        }
        else
        {
            lblCheckOut.Text = "Sorry, there is nothing to check out from the cart.";
        }

    }
    protected void btnGoBack_Click(object sender, EventArgs e)
    {
        Response.Redirect(prevPage);
    }
}
