using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Text;

public partial class Product_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] == null)
        {
            Response.Redirect("~/Accessories.aspx");
        }

        // Gets the name of the product and put it as the title
        string title = Frames.GetItemName(Request.QueryString["id"]) + " @ OnSiteEyewear.ca";
        HtmlMeta metaTitle = new HtmlMeta();
        metaTitle.Name = title;
        metaTitle.Content = title;
        Page.Header.Controls.Add(metaTitle);
        Page.Title = metaTitle.Content;
    }

    // Control validator only validates if the quantity is between 1-15
    protected void qtyValidate(object source, ServerValidateEventArgs args)
    {
        TextBox txtQuantity = (TextBox)fvSpecificAccessory.FindControl("txtQuantity");
        args.IsValid = Convert.ToInt16(txtQuantity.Text) > 0 && Convert.ToInt16(txtQuantity.Text) <= 15;
    }

    //Add the merchandise to the cart
    protected void btnAddToCart_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            Session["token"] = "";
            Session["payerId"] = "";
            TextBox txtQuantity = (TextBox)fvSpecificAccessory.FindControl("txtQuantity");
            string id = Request.QueryString["id"];
            string name = Frames.GetItemName(Convert.ToString(id));
            int qty = Convert.ToInt16(txtQuantity.Text);
            double price = Convert.ToDouble(Frames.GetItemPrice(id));
            string image1 = Frames.GetItemImage(id);

            Items accessory = new Items.Accessories(id, name, qty, price, image1);

            if (Session["shoppingCart"] != null)
            {
                List<Items> shoppingList = (List<Items>)Session["shoppingCart"];
                shoppingList.Add(accessory);
                Session["shoppingCart"] = shoppingList;
            }
            else
            {
                List<Items> shoppingList = new List<Items>();
                shoppingList.Add(accessory);
                Session["shoppingCart"] = shoppingList;
            }
            Response.Redirect("~/View-Cart.aspx");
        }
    }
}