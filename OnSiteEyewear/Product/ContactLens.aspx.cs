using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Collections;
using System.Configuration;

public partial class ContactLense : System.Web.UI.Page
{
    private string contactLensID;
    private string name;
    private string price;
    private string baseCurves;
    private int i = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        contactLensID = Request.QueryString["id"];
        name = Contacts.GetContactName(contactLensID);
        price = Contacts.GetContactPrice(contactLensID);
        
        string title = Contacts.GetContactName(contactLensID) + " @ OnSiteEyewear.ca";
        HtmlMeta metaTitle = new HtmlMeta();
        metaTitle.Name = title;
        metaTitle.Content = title;
        Page.Header.Controls.Add(metaTitle);
        Page.Title = metaTitle.Content;

        double powerMin = Convert.ToDouble(Contacts.GetPowerMin(contactLensID));
        double powerMax = Convert.ToDouble(Contacts.GetPowerMax(contactLensID));

        while (powerMin <= powerMax)
        {
            if (powerMin <= 0)
            {
                ddlPowerLeft.Items.Add(new ListItem(String.Format("{0:0.00}", powerMin), i.ToString()));
                ddlPowerRight.Items.Add(new ListItem(String.Format("{0:0.00}", powerMin), i.ToString()));
                i++;
            }
            else
            {
                ddlPowerLeft.Items.Add(new ListItem(String.Format("{0:+0.00}", powerMin), i.ToString()));
                ddlPowerRight.Items.Add(new ListItem(String.Format("{0:+0.00}", powerMin), i.ToString()));
                i++;
            }
            if (powerMin < -6 || powerMin > 6)
            {
                powerMin += 0.5;
            }
            else
            {
                powerMin += 0.25;
            }
        }

        baseCurves = Contacts.GetBaseCurves(contactLensID);
        if (baseCurves.Contains(","))
        {
            string[] baseCurvesArray = baseCurves.Split(',');
            foreach (string b in baseCurvesArray)
            {
                ddlBcLeft.Items.Add(b);
                ddlBcRight.Items.Add(b);
            }
        }
        else
        {
            ddlBcLeft.Visible = false;
            ddlBcRight.Visible = false;

            rfvBcLeft.Enabled = false;
            rfvBcRight.Enabled = false;

            lblBcLeft.Visible = true;
            lblBcRight.Visible = true;

            lblBcLeft.Text = baseCurves;
            lblBcRight.Text = baseCurves;
        }
    }

    //Add the merchandise to the cart
    protected void btnAddToCart_Click(object sender, EventArgs e)
    {
        string leftBaseCurve = "";

        if (Page.IsValid)
        {
            Session["token"] = "";
            Session["payerId"] = "";
            string id = Request.QueryString["id"];
            string name = Contacts.GetContactName(Convert.ToString(id));
            int leftQty = Convert.ToInt16(txtQuantityLeft.Text);
            string leftPower = ddlPowerLeft.SelectedItem.Text;

            if (baseCurves.Contains(","))
            {
                leftBaseCurve = ddlBcLeft.SelectedItem.Text;
            }
            else
            {
                leftBaseCurve = lblBcLeft.Text;
            }

            string leftDiameter = Contacts.GetContactDiameter(id);
            int rightQty = Convert.ToInt16(txtQuantityRight.Text);
            string rightPower = ddlPowerRight.SelectedItem.Text;
            string rightBaseCurve = ddlBcRight.SelectedItem.Text;
            string rightDiameter = leftDiameter;
            double price = Convert.ToDouble(Contacts.GetContactPrice(id));
            string image = Contacts.GetContactImage(id);

            Items contacts = new Contacts(id, name, leftQty, leftPower, leftBaseCurve,
            leftDiameter, rightQty, rightPower, rightBaseCurve, rightDiameter, 
            price, image);

            if (Session["shoppingCart"] != null)
            {
                List<Items> shoppingList = (List<Items>)Session["shoppingCart"];
                shoppingList.Add(contacts);
                Session["shoppingCart"] = shoppingList;
            }
            else
            {
                List<Items> shoppingList = new List<Items>();
                shoppingList.Add(contacts);
                Session["shoppingCart"] = shoppingList;
            }
            Response.Redirect("~/View-Cart.aspx");
        }
    }
}