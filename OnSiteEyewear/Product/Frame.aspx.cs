using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Collections;
using System.Configuration;

public partial class Frame : System.Web.UI.Page
{
    private double ddlAddInt = 0.75;
    private double ddlAddNum = 0;
    private double ddlSphInt = -12.25;
    private double ddlSphNum = 0;
    private double ddlCylInt = -4;
    private double ddlCylNum = 0;
    private int ddlAxisInt = 0;
    private int ddlAxisNum = 0;
    private double ddlMonoPdInt = 22.5;
    private int ddlMonoPdNum = 0;
    //private double ddlPdInt = 45.5;
    //private int ddlPdNum = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] == null)
        {
            Response.Redirect("~/Frames.aspx?gender=all");
        }
       
        // Gets the name of the product and put it as the title
        string title = Frames.GetName(Request.QueryString["id"]) + " @ OnSiteEyewear.ca";
        HtmlMeta metaTitle = new HtmlMeta();
        metaTitle.Name = title;
        metaTitle.Content = title;
        Page.Header.Controls.Add(metaTitle);
        Page.Title = metaTitle.Content;

        // Set javascript
        //btnContinue.Attributes.Add("onclick", "setScroll()");
        //btnContinue.Attributes.Add("onclientclick", "selectOptionsOn(); return false");
        

        #region Adding text values into the drop down list
        //Create the drop down list text values for sph
        while (ddlSphInt < 6)
		{
            ddlSphInt = ddlSphInt + 0.25;

            if (ddlSphInt <= 0)
            {
                ddlSphLeft.Items.Add(new ListItem(String.Format("{0:0.00}", ddlSphInt), ddlSphInt.ToString()));
                ddlSphRight.Items.Add(new ListItem(String.Format("{0:0.00}", ddlSphInt), ddlSphInt.ToString()));
            }
            else
            {
                ddlSphLeft.Items.Add(new ListItem(String.Format("{0:+0.00}", ddlSphInt), ddlSphInt.ToString()));
                ddlSphRight.Items.Add(new ListItem(String.Format("{0:+0.00}", ddlSphInt, ddlSphInt.ToString())));
            }
            ddlSphNum++;
		}

        //Create the drop down list text values for cyl
        while (ddlCylInt < 3.75)
        {
            ddlCylInt = ddlCylInt + 0.25;

            if (ddlCylInt <= 0)
            {
                ddlCylLeft.Items.Add(new ListItem(String.Format("{0:0.00}", ddlCylInt), ddlCylInt.ToString()));
                ddlCylRight.Items.Add(new ListItem(String.Format("{0:0.00}", ddlCylInt), ddlCylInt.ToString()));
            }
            else
            {
                ddlCylLeft.Items.Add(new ListItem(String.Format("{0:+0.00}", ddlCylInt), ddlCylInt.ToString()));
                ddlCylRight.Items.Add(new ListItem(String.Format("{0:+0.00}", ddlCylInt), ddlCylInt.ToString()));
            }
            ddlCylNum++;
        }

        //Create the drop down list text values for axis
        while (ddlAxisInt < 180)
        {
            ddlAxisInt = ddlAxisInt + 1;

            ddlAxisLeft.Items.Add(new ListItem(Convert.ToString((ddlAxisInt)), ddlAxisInt.ToString()));
            ddlAxisRight.Items.Add(new ListItem(Convert.ToString((ddlAxisInt)), ddlAxisInt.ToString()));

            ddlAxisNum++;
        }

        //Create the drop down list text values for add
        while (ddlAddInt < 3.51)
        {
            ddlAddLeft.Items.Add(new ListItem(String.Format("{0:+0.00}", ddlAddInt), ddlAddInt.ToString()));
            ddlAddRight.Items.Add(new ListItem(String.Format("{0:+0.00}", ddlAddInt), ddlAddInt.ToString()));

            ddlAddInt = ddlAddInt + 0.25;
            ddlAddNum++;
        }

        //Create the drop down list text values for mono-pd
        while (ddlMonoPdInt < 37.5)
        {
            ddlMonoPdInt = ddlMonoPdInt + 0.5;

            ddlMonoPdLeft.Items.Add(new ListItem(String.Format("{0:0.0}", ddlMonoPdInt), ddlMonoPdInt.ToString()));
            ddlMonoPdRight.Items.Add(new ListItem(String.Format("{0:0.0}", ddlMonoPdInt), ddlMonoPdInt.ToString()));
            ddlMonoPdNum++;
        }

        ////Create the drop down list text values for pd
        //while (ddlPdInt < 75.0)
        //{
        //    ddlPdInt = ddlPdInt + 0.5;

        //    ddlPd.Items.Add(new ListItem(String.Format("{0:0.0}", ddlPdInt), ddlPdNum.ToString()));
        //    ddlPdNum++;
        //}
        #endregion
    }

    //// Control validator only validates if the MPD has selected values and pd doesn't
    //protected void mpdValidate(object source, ServerValidateEventArgs args)
    //{
    //    DropDownList ddlMonoPdLeft = (DropDownList)fvSpecificFrame.FindControl("ddlMonoPdLeft");
    //    DropDownList ddlMonoPdRight = (DropDownList)fvSpecificFrame.FindControl("ddlMonoPdRight");
    //    DropDownList ddlPd = (DropDownList)fvSpecificFrame.FindControl("ddlPd");

    //    args.IsValid = ddlMonoPdLeft.SelectedIndex >= 1 && ddlMonoPdRight.SelectedIndex >= 1 && ddlPd.SelectedIndex < 0;

    //}

    //// Control validator only validates if the MPD has selected values and pd doesn't
    //protected void pdValidate(object source, ServerValidateEventArgs args)
    //{
    //    DropDownList ddlMonoPdLeft = (DropDownList)fvSpecificFrame.FindControl("ddlMonoPdLeft");
    //    DropDownList ddlMonoPdRight = (DropDownList)fvSpecificFrame.FindControl("ddlMonoPdRight");
    //    DropDownList ddlPd = (DropDownList)fvSpecificFrame.FindControl("ddlPd");

    //    args.IsValid = ddlMonoPdLeft.SelectedIndex < 0 && ddlMonoPdRight.SelectedIndex < 0 && ddlPd.SelectedIndex >= 1;

    //}

    //Add the merchandise to the cart
    protected void btnAddToCart_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            Session["token"] = "";
            Session["payerId"] = "";
            string glassesID = Request.QueryString["id"];
            string name = Frames.GetName(Convert.ToString(glassesID));
            string rightSph = ddlSphRight.SelectedItem.Text;
            string rightCyl = ddlCylRight.SelectedItem.Text;
            string rightAxis = ddlAxisRight.SelectedItem.Text;
            string rightPd = ddlMonoPdRight.SelectedItem.Text;
            string leftSph = ddlSphLeft.SelectedItem.Text;
            string leftCyl = ddlCylLeft.SelectedItem.Text;
            string leftAxis = ddlAxisLeft.SelectedItem.Text;
            string leftPd = ddlMonoPdLeft.SelectedItem.Text;
            string lensIndex = "";
            double price = Convert.ToDouble(Frames.GetPrice(glassesID));
            string image1 = Frames.GetImage1(glassesID);

            if (rb150Index.Checked == true) {
                lensIndex = rb150Index.Text;
            }

            else if (rb159Index.Checked == true)
            {
                lensIndex = rb159Index.Text;
                price += 29.95;
            }

            else if (rb161Index.Checked == true)
            {
                lensIndex = rb161Index.Text;
                price += 34.95;
            }

            else if (rb167Index.Checked == true)
            {
                lensIndex = rb167Index.Text;
                price += 69.95;
            }

            else if (rb150Trans.Checked == true)
            {
                lensIndex = rb150Trans.Text;
                price += 99.00;
            }

            else if (rb159Trans.Checked == true)
            {
                lensIndex = rb159Trans.Text;
                price += 109.00;
            }

            else if (rb160Trans.Checked == true)
            {
                lensIndex = rb160Trans.Text;
                price += 119.00;
            }

            Items frame = new Frames(glassesID, name, rightSph, rightCyl,
            rightAxis, rightPd, leftSph, leftCyl, leftAxis, leftPd, lensIndex, price,
            image1);

            if (Session["shoppingCart"] != null)
            {
                List<Items> shoppingList = (List<Items>)Session["shoppingCart"];
                shoppingList.Add(frame);
                Session["shoppingCart"] = shoppingList;
            }
            else
            {
                List<Items> shoppingList = new List<Items>();
                shoppingList.Add(frame);
                Session["shoppingCart"] = shoppingList;
            }
            Response.Redirect("~/View-Cart.aspx");
        }
    }
}