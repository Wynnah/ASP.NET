using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

public partial class ViewCart : System.Web.UI.Page
{
    private String tableBuilder = "<table ID=\"groupPlaceholderContainer\" class=\"fullSize\" runat=\"server\">";
    private List<Items> shoppingList;
    private double subtotal;
    private double shipping;
    //private double tax;
    //private double total;

    protected void Page_Load(object sender, EventArgs e)
    {
        shoppingList = (List<Items>)Session["shoppingCart"];

        if (!IsPostBack && Request.QueryString["del"] != null && Session["shoppingCart"] != null)
        {
            int index = Convert.ToInt16(Request.QueryString["del"]);
            shoppingList.RemoveAt(index);
            Session["token"] = "";
            Session["payerId"] = "";
            Session.Remove("error");
            // If the session shoppingcart has no values in there, clear the tablebuilder
            checkShoppingListIndex();
            Response.Redirect("View-Cart.aspx");
        }

        if (Session["shoppingCart"] != null)
        {
            string payPalLink = "https://www.paypal.com/en_US/i/btn/btn_xpressCheckout.gif";
            
            foreach (Items item in shoppingList)
            {
                string index = shoppingList.IndexOf(item).ToString();
                string itemType = item.GetType().ToString();

                if(item.GetType().ToString() == "Frames")
                {
                    string glassesID = ((Frames)item).glassesID;
                    string name = ((Frames)item).name;
                    string rightSph = ((Frames)item).rightSph;
                    string rightCyl = ((Frames)item).rightCyl;
                    string rightAxis = ((Frames)item).rightAxis;
                    string rightPd = ((Frames)item).rightPd;
                    string leftSph = ((Frames)item).leftSph;
                    string leftCyl = ((Frames)item).leftCyl;
                    string leftAxis = ((Frames)item).leftAxis;
                    string leftPd = ((Frames)item).leftPd;
                    string lensIndex = ((Frames)item).lensIndex;
                    double price = ((Frames)item).price;
                    string image1 = ((Frames)item).image1;
                    subtotal += price;

                    tableBuilder += "<tr><td class=\"tdCartHeader\" colspan=\"8\">" +
                     "<table class=\"fullSize\"><tr><td class=\"tdCartHeaderItemName\" runat=\"server\" />" +
                    "<a href=\"Product/Frame.aspx?id=" + glassesID + "\">" + name +
                     "</td><td class=\"tdCartHeaderItemName\" runat=\"server\" colspan=\"5\" /></td>" +
                     "<td class=\"tdCartHeaderItemName\" runat=\"server\" /><a style=\"float: right; padding-right: 63px\" href=\"View-Cart.aspx?del=" + index + "\">Remove</a></td>" +
                     "</tr></table></td></tr>" +
                    "<tr><td class=\"tdCartItemText\" runat=\"server\"><img width=\"150px\" height=\"75px\" src=\"Images/Frames/" + image1 + "\" /></td>" +
                    "<td class=\"tdCartItemText\"><br /><span class=\"description\">LEFT:</span><br /><span class=\"description\">RIGHT:</span></td>" +
                    "<td class=\"tdCartItemText\"><span class=\"description\">SPH</span><br />" + leftSph + "<br />" + rightSph + "</td>" +
                    "<td class=\"tdCartItemText\"><span class=\"description\">CYL</span><br />" + leftCyl + "<br />" + rightCyl + "</td>" +
                    "<td class=\"tdCartItemText\"><span class=\"description\">AXIS</span><br />" + leftAxis + "<br />" + rightAxis + "</td>" +
                    "<td class=\"tdCartItemText\"><span class=\"description\">PD</span><br />" + leftPd + "<br />" + rightPd + "</td>" +
                    "<td class=\"tdCartItemText\"><span class=\"description\"><br /></td>" +
                    "<td class=\"tdCartItemText\"><span class=\"description\">Total</span><br />" + String.Format("{0:C}", price) + "</td></tr>" +
                    "<tr><td class=\"fullsize\" colspan=\"1\"></td><td class=\"fullsize\" colspan=\"1\"><span class=\"description\">LENS OPTION: </span><td class=\"fullsize\" colspan=\"6\">" + lensIndex + "</td></tr>";
                }

                else if (item.GetType().ToString().Contains("ReadyReaders"))
                {
                    string id = item.id;
                    string name = item.name;
                    string power = item.power;
                    string image1 = item.image1;
                    int qty = item.qty;
                    double price = Convert.ToDouble(item.price);
                    double totalPrice = Convert.ToDouble(price * item.qty);
                    subtotal += totalPrice;

                    tableBuilder += "<tr><td class=\"tdCartHeader\" colspan=\"8\">" +
                     "<table class=\"fullSize\"><tr><td class=\"tdCartHeaderItemName\" runat=\"server\" />" +
                    "<a href=\"Product/ReadyReader.aspx?id=" + id + "\">" + name +
                     "</td><td class=\"tdCartHeaderItemName\" runat=\"server\" colspan=\"5\" /></td>" +
                     "<td class=\"tdCartHeaderItemName\" runat=\"server\" /><a style=\"float: right; padding-right: 63px\" href=\"View-Cart.aspx?del=" + index + "\">Remove</a></td>" +
                     "</tr></table></td></tr>" +
                    "<tr><td class=\"tdCartItemText\" runat=\"server\"><img width=\"150px\" height=\"75px\" src=\"Images/ReadyReaders/" + image1 + "\" /></td>" +
                    "<td class=\"tdCartItemText\" colspan=\"3\"></td>" +
                    "<td class=\"tdCartItemText\"><span class=\"description\">QTY</span></span><br />" + qty + "</td>" +
                    "<td class=\"tdCartItemText\"><span class=\"description\">Power</span></span><br />" + power + "</td>" +
                    "<td class=\"tdCartItemText\"><span class=\"description\">Price</span><br />" + String.Format("{0:C}", price) + "</td>" +
                    "<td class=\"tdCartItemText\"><span class=\"description\">Total</span><br />" + String.Format("{0:C}", totalPrice) + "</td></tr>";
                }

                else if (item.GetType().ToString().Contains("Sunglasses"))
                {
                    string id = item.id;
                    string name = item.name;
                    string image1 = item.image1;
                    int qty = item.qty;
                    double price = Convert.ToDouble(item.price);
                    double totalPrice = Convert.ToDouble(price * item.qty);
                    subtotal += totalPrice;

                    tableBuilder += "<tr><td class=\"tdCartHeader\" colspan=\"8\">" +
                     "<table class=\"fullSize\"><tr><td class=\"tdCartHeaderItemName\" runat=\"server\" />" +
                    "<a href=\"Product/Sunglass.aspx?id=" + id + "\">" + name +
                     "</td><td class=\"tdCartHeaderItemName\" runat=\"server\" colspan=\"5\" /></td>" +
                     "<td class=\"tdCartHeaderItemName\" runat=\"server\" /><a style=\"float: right; padding-right: 63px\" href=\"View-Cart.aspx?del=" + index + "\">Remove</a></td>" + 
                     "</tr></table></td></tr>" +
                    "<tr><td class=\"tdCartItemText\" runat=\"server\"><img width=\"150px\" height=\"75px\" src=\"Images/Sunglasses/" + image1 + "\" /></td>" +
                    "<td class=\"tdCartItemText\" colspan=\"4\"></td>" +
                    "<td class=\"tdCartItemText\"><span class=\"description\">QTY</span></span><br />" + qty + "</td>" +
                    "<td class=\"tdCartItemText\"><span class=\"description\">Price</span><br />" + String.Format("{0:C}", price) + "</td>" +
                    "<td class=\"tdCartItemText\"><span class=\"description\">Total</span><br />" + String.Format("{0:C}", totalPrice) + "</td></tr>";
                }
                else if (item.GetType().ToString().Contains("Solutions"))
                {
                    string id = item.id;
                    string name = item.name;
                    string image1 = item.image1;
                    int qty = item.qty;
                    double price = Convert.ToDouble(item.price);
                    double totalPrice = Convert.ToDouble(price * item.qty);
                    subtotal += totalPrice;

                    tableBuilder += "<tr><td class=\"tdCartHeader\" colspan=\"8\">" +
                     "<table class=\"fullSize\"><tr><td class=\"tdCartHeaderItemName\" runat=\"server\" />" +
                    "<a href=\"Product/Solution.aspx?id=" + id + "\">" + name +
                     "</td><td class=\"tdCartHeaderItemName\" runat=\"server\" colspan=\"5\" /></td>" +
                     "<td class=\"tdCartHeaderItemName\" runat=\"server\" /><a style=\"float: right; padding-right: 63px\"href=\"View-Cart.aspx?del=" + index + "\">Remove</a></td>" +
                     "</tr></table></td></tr>" +
                    "<tr><td class=\"tdCartItemText\" runat=\"server\"><img src=\"Images/Solutions/" + image1 + "\" /></td>" +
                    "<td class=\"tdCartItemText\" colspan=\"4\"></td>" +
                    "<td class=\"tdCartItemText\"><span class=\"description\">QTY</span></span><br />" + qty + "</td>" +
                    "<td class=\"tdCartItemText\"><span class=\"description\">Price</span><br />" + String.Format("{0:C}", price) + "</td>" +
                    "<td class=\"tdCartItemText\"><span class=\"description\">Total</span><br />" + String.Format("{0:C}", totalPrice) + "</td></tr>";
                }
                else if (item.GetType().ToString().Contains("Accessories"))
                {
                    string id = item.id;
                    string name = item.name;
                    string image1 = item.image1;
                    int qty = item.qty;
                    double price = Convert.ToDouble(item.price);
                    double totalPrice = Convert.ToDouble(price * item.qty);
                    subtotal += totalPrice;

                    tableBuilder += "<tr><td class=\"tdCartHeader\" colspan=\"8\">" +
                     "<table class=\"fullSize\"><tr><td class=\"tdCartHeaderItemName\" runat=\"server\" />" +
                    "<a href=\"Product/Accessory.aspx?id=" + id + "\">" + name +
                     "</td><td class=\"tdCartHeaderItemName\" runat=\"server\" colspan=\"5\" /></td>" +
                     "<td class=\"tdCartHeaderItemName\" runat=\"server\" /><a style=\"float: right; padding-right: 63px\"href=\"View-Cart.aspx?del=" + index + "\">Remove</a></td>" +
                     "</tr></table></td></tr>" +
                    "<tr><td class=\"tdCartItemText\" runat=\"server\"><img src=\"Images/Accessories/" + image1 + "\" /></td>" +
                    "<td class=\"tdCartItemText\" colspan=\"4\"></td>" +
                    "<td class=\"tdCartItemText\"><span class=\"description\">QTY</span></span><br />" + qty + "</td>" +
                    "<td class=\"tdCartItemText\"><span class=\"description\">Price</span><br />" + String.Format("{0:C}", price) + "</td>" +
                    "<td class=\"tdCartItemText\"><span class=\"description\">Total</span><br />" + String.Format("{0:C}", totalPrice) + "</td></tr>";
                }
                else if (item.GetType().ToString() == "Contacts")
                {
                    string id = ((Contacts)item).id;
                    string name = ((Contacts)item).name;
                    int leftQty = ((Contacts)item).leftQty;
                    string leftPower = ((Contacts)item).leftPower;
                    string leftBaseCurve = ((Contacts)item).leftBaseCurve;
                    string leftDiameter = ((Contacts)item).leftDiameter;
                    string rightPower = ((Contacts)item).rightPower;
                    int rightQty = ((Contacts)item).rightQty;
                    string rightBaseCurve = ((Contacts)item).rightBaseCurve;
                    string rightDiameter = ((Contacts)item).rightDiameter;
                    double price = ((Contacts)item).price;
                    string image = ((Contacts)item).image;
                    double leftPrice = Convert.ToDouble(leftQty * price);
                    double rightPrice = Convert.ToDouble(rightQty * price);
                    double totalPrice =  leftPrice + rightPrice;
                    subtotal += totalPrice;

                    tableBuilder += "<tr><td class=\"tdCartHeader\" colspan=\"8\">" +
                     "<table class=\"fullSize\"><tr><td class=\"tdCartHeaderItemName\" runat=\"server\" />" +
                    "<a href=\"Product/ContactLens.aspx?id=" + id + "\">" + name +
                     "</td><td class=\"tdCartHeaderItemName\" runat=\"server\" colspan=\"5\" /></td>" +
                     "<td class=\"tdCartHeaderItemName\" runat=\"server\" /><a style=\"float: right; padding-right: 63px\"href=\"View-Cart.aspx?del=" + index + "\">Remove</a></td>" +
                     "</tr></table></td></tr>" +
                    "<tr><td class=\"tdCartItemText\" runat=\"server\"><img src=\"Images/Contacts/" + image + "\" /></td>" +
                    "<td class=\"tdCartItemText\"><br /><span class=\"description\">LEFT:</span><br /><span class=\"description\">RIGHT:</span></td>" +
                    "<td class=\"tdCartItemText\"><span class=\"description\">QTY</span><br />" + leftQty + "<br />" + rightQty + "</td>" +
                    "<td class=\"tdCartItemText\"><span class=\"description\">POWER</span><br />" + leftPower + "<br />" + rightPower + "</td>" +
                    "<td class=\"tdCartItemText\"><span class=\"description\">Base Curve</span><br />" + leftBaseCurve + "<br />" + rightBaseCurve + "</td>" +
                    "<td class=\"tdCartItemText\"><span class=\"description\">Diameter</span><br />" + leftDiameter + "<br />" + rightDiameter + "</td>" +
                    "<td class=\"tdCartItemText\"><span class=\"description\">Price</span><br />" + String.Format("{0:C}", price) + "<br />" + String.Format("{0:C}", price) + "</td>" +
                    "<td class=\"tdCartItemText\"><span class=\"description\">Total</span><br />" + String.Format("{0:C}", leftPrice) + "<br />" + String.Format("{0:C}", rightPrice) + "</td></tr>";
                }
            }

            if (subtotal >= 119.00)
            {
                shipping = 0.00;
            }
            else
            {
                
            }
           // tax = subtotal * 0.12;
           // total = tax + subtotal;

            tableBuilder += "<tr runat=\"server\"><td class=\"tdCartFooter\" runat=\"server\" colspan=\"8\"><table class=\"fullSize\">" +
            "<tr><td class=\"tdCartFooterLeft\"/><td class=\"tdCartFooterCenter\">Merchandise Subtotal:</td><td class=\"tdCartFooterRight\">$<span id=\"subtotal\">" + String.Format("{0:0.00}", subtotal) + "</span> CAD</td><td class=\"tdCartFooterExtraRight\"/></tr></table>" +
           // "<tr><td class=\"tdCartFooterLeft\"/><td class=\"tdCartFooterCenter\">HST:</td><td class=\"tdCartFooterRight\">" + String.Format("{0:C}", tax) + " CAD</td><td class=\"tdCartFooterExtraRight\"/></tr>" +
           // "<tr><td class=\"tdCartFooterLeft\"/><td class=\"tdCartFooterTotal\" colspan=\"2\"></td><td class=\"tdCartFooterExtraRight\"/></tr>" +
           // "<tr><td class=\"tdCartFooterLeft\"/><td class=\"tdCartFooterCenter\">Estimated Order Total:</td><td class=\"tdCartFooterRight\">" + String.Format("{0:C}", total) + " CAD</td><td class=\"tdCartFooterExtraRight\"/></tr></table>" +
           "<tr runat=\"server\"><td class=\"fullSize\" runat=\"server\" colspan=\"8\"></td></tr>" +
            "<tr runat=\"server\"><td runat=\"server\" colspan=\"8\"><span class=\"bold\"><br />CHOOSE A SHIPPING METHOD</span></td></tr>" +
            "<tr runat=\"server\"><td class=\"tdShipping\" runat=\"server\" colspan=\"4\" valign=\"top\"><input id=\"rbFedex\" runat=\"server\" checked=\"true\" type=\"radio\" name=\"group1\" value=\"fedEx\" onClick=\"shipping('fedex')\">FedEx [Express] - $9.95 [Canada only]<br /><br />Delivery in 1-2 Business Days (after assembly). Our fastest shipping method!</td>" +
            "<td class=\"tdShipping\" runat=\"server\" colspan=\"4\" valign=\"top\"><input id=\"rbInternational\" type=\"radio\" name=\"group1\" value=\"international\" onClick=\"shipping('international')\">International - $14.95<br /><br />Delivery in 8-9 Business Days (after assembly).</td></tr>" +
            "<tr runat=\"server\"><td class=\"tdCartFooter\" colspan=\"8\"><table class=\"fullSize\">" +
            "<tr><td class=\"tdCartFooterLeft\"/><td class=\"tdCartFooterCenter\">Shipping:</td><td class=\"tdCartFooterRight\">$<span id=\"shipping\">0.00</span> CAD</td><td class=\"tdCartFooterExtraRight\"/></tr>" +
            "<tr><td class=\"tdCartFooterLeft\"/><td class=\"tdCartFooterCenter\">Total:</td><td class=\"tdCartFooterRight\">$<span id=\"total\">" + String.Format("{0:0.00}", subtotal) + "</span> CAD</td><td class=\"tdCartFooterExtraRight\"/></tr></table>" +
            "<tr runat=\"server\"><td class=\"fullSize\" runat=\"server\" style=\"padding-top: 20px\" colspan=\"8\">" +
            "<div class=\"divCartHeaderDelete\" runat=\"server\"><a id=\"checkoutLink\" href=\"expresscheckout.aspx?shipping=9.95\">" +
            "<img src=\""+ payPalLink +"\" border=\"0\" alt=\"Check out with Paypal\" /></a></div></td></tr></table>";

            tableLbl.Text = tableBuilder;
            // If the session shoppingcart has no values in there, clear the tablebuilder
            checkShoppingListIndex();
            Session["payment_amt"] = subtotal;
        }
    }

    private void checkShoppingListIndex()
    {
        if (shoppingList.Count.Equals(0))
        {
            tableBuilder = "There are no items in the shopping cart.";
            tableLbl.Text = tableBuilder;
        }
    }
}