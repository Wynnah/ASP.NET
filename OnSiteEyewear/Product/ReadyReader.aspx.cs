using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Collections;
using System.Configuration;

public partial class ReadyReader : System.Web.UI.Page
{
    private double ddlPowerInt = 0.75;
    private int ddlPowerNum = 0;
    private DropDownList ddlPower;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] == null)
        {
            Response.Redirect("~/ReadyReaders.aspx?gender=all");
        }

        // Gets the name of the product and put it as the title
        string title = Frames.GetName(Request.QueryString["id"]) + " @ OnSiteEyewear.ca";
        HtmlMeta metaTitle = new HtmlMeta();
        metaTitle.Name = title;
        metaTitle.Content = title;
        Page.Header.Controls.Add(metaTitle);
        Page.Title = metaTitle.Content;

        // Add values to the ddlPower
        ddlPower = (DropDownList)fvSpecificReadyReader.FindControl("ddlPower");

        while (ddlPowerInt < 3)
        {
            ddlPowerInt = ddlPowerInt + 0.25;

            ddlPower.Items.Add(new ListItem(String.Format("{0:+0.00}", ddlPowerInt), ddlPowerNum.ToString()));
            ddlPowerNum++;
        }
    }

    // Control validator only validates if the quantity is between 1-15
    protected void qtyValidate(object source, ServerValidateEventArgs args)
    {
        TextBox txtQuantity = (TextBox)fvSpecificReadyReader.FindControl("txtQuantity");
        args.IsValid = Convert.ToInt16(txtQuantity.Text) > 0 && Convert.ToInt16(txtQuantity.Text) <= 15;
    }

    //Add the merchandise to the cart
    protected void btnAddToCart_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            Session["token"] = "";
            Session["payerId"] = "";
            TextBox txtQuantity = (TextBox)fvSpecificReadyReader.FindControl("txtQuantity");
            DropDownList ddlPower = (DropDownList)fvSpecificReadyReader.FindControl("ddlPower");

            string id = Request.QueryString["id"];
            string name = Frames.GetName(Convert.ToString(id));
            int qty = Convert.ToInt16(txtQuantity.Text);
            string power = ddlPower.SelectedItem.Text;
            double price = Convert.ToDouble(Frames.GetPrice(id));
            string image1 = Frames.GetImage1(id);

            Items readyReader = new Items.ReadyReaders(id, name, qty, power, price,
            image1);

            if (Session["shoppingCart"] != null)
            {
                List<Items> shoppingList = (List<Items>)Session["shoppingCart"];
                shoppingList.Add(readyReader);
                Session["shoppingCart"] = shoppingList;
            }
            else
            {
                List<Items> shoppingList = new List<Items>();
                shoppingList.Add(readyReader);
                Session["shoppingCart"] = shoppingList;
            }
            Response.Redirect("~/View-Cart.aspx");
        }
    }
}