using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class OrderReview : System.Web.UI.Page
{
    private String tableBuilder;
    private double shippingPrice;
    private double orderTotalPrice;
    private List<Items> shoppingList;
    private double subtotal;
    //private double tax;
    //private double total;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["shoppingCart"] != null && Session["token"] != null && Session["payment_amt"] != null
                && Session["shipping"] != null)
        {
            shoppingList = (List<Items>)Session["shoppingCart"];
            shippingPrice = Convert.ToDouble(Session["shipping"]);

            NVPAPICaller test = new NVPAPICaller();

            string retMsg = "";
            string token = "";
            string payerID = "";
            string shippingAddress = "";

            token = Session["token"].ToString();

            bool ret = test.GetShippingDetails(token, ref payerID, ref shippingAddress, ref retMsg);
            if (ret)
            {
                Session["payerId"] = payerID;

                tableBuilder += shippingAddress;

                tableBuilder += "<br /><table class=\"fullSize\"><tr><td class=\"tdOrderReviewHeader\">" +
                        "<div class=\"divOrderReviewHeaderBiggerDetails\">Product</div>" +
                        "<div class=\"divOrderReviewHeaderBiggerDetails\">Description</div>" +
                        "<div class=\"divOrderReviewHeaderSmallerDetails\">Item Price</div>" +
                        "<div class=\"divOrderReviewHeaderSmallerDetails\">Qty</div>" +
                        "<div style=\"padding-left: 5px\" class=\"divOrderReviewHeaderSmallerDetails\">Item Total</div>" +
                    "</td></tr>";

                foreach (Items item in shoppingList)
                {
                    string index = shoppingList.IndexOf(item).ToString();
                    string itemType = item.GetType().ToString();

                    if (item.GetType().ToString() == "Frames")
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

                        tableBuilder += "<tr><td class=\"tdOrderReviewMain\">" +
                        "<div class=\"divOrderReviewHeaderBiggerDetails\"><a href=\"Product/Frame.aspx?id=" + glassesID + "\">" + name + "</a></div>" +
                        "<div class=\"divOrderReviewHeaderBiggerDetails\">Left eye: (" + leftSph + " SPH) (" + leftCyl + " CYL) (" + leftAxis + " AXIS) <br/> (" + leftPd + " MPD)<br />" +
                            "Right eye: (" + rightSph + " SPH) (" + rightCyl + " CYL) (" + rightAxis + " AXIS) <br/> (" + rightPd + " MPD)<br /> Lens option : " + lensIndex +"</div>" +
                        "<div class=\"divOrderReviewHeaderSmallerDetails\">" + String.Format("{0:C}", price) + "</div>" +
                        "<div class=\"divOrderReviewHeaderSmallerDetails\">1</div>" +
                        "<div style=\"padding-left: 5px\" class=\"divOrderReviewHeaderSmallerDetails\">" + String.Format("{0:C}", price) + "</div>";
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

                        tableBuilder += "<tr><td class=\"tdOrderReviewMain\">" +
                        "<div class=\"divOrderReviewHeaderBiggerDetails\"><a href=\"Product/Sunglass.aspx?id=" + id + "\">" + name + "</a></div>" +
                        "<div class=\"divOrderReviewHeaderBiggerDetails\">&nbsp;</div>" +
                        "<div class=\"divOrderReviewHeaderSmallerDetails\">" + String.Format("{0:C}", price) + "</div>" +
                        "<div class=\"divOrderReviewHeaderSmallerDetails\">" + qty + "</div>" +
                        "<div style=\"padding-left: 5px\" class=\"divOrderReviewHeaderSmallerDetails\">" + String.Format("{0:C}", totalPrice) + "</div>";
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

                        tableBuilder += "<tr><td class=\"tdOrderReviewMain\">" +
                        "<div class=\"divOrderReviewHeaderBiggerDetails\"><a href=\"Product/ReadyReader.aspx?id=" + id + "\">" + name + "</a></div>" +
                        "<div class=\"divOrderReviewHeaderBiggerDetails\">Power: (" + power + ")</div>" +
                        "<div class=\"divOrderReviewHeaderSmallerDetails\">" + String.Format("{0:C}", price) + "</div>" +
                        "<div class=\"divOrderReviewHeaderSmallerDetails\">" + qty + "</div>" +
                        "<div style=\"padding-left: 5px\" class=\"divOrderReviewHeaderSmallerDetails\">" + String.Format("{0:C}", totalPrice) + "</div>";
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

                        tableBuilder += "<tr><td class=\"tdOrderReviewMain\">" +
                        "<div class=\"divOrderReviewHeaderBiggerDetails\"><a href=\"Product/Solution.aspx?id=" + id + "\">" + name + "</a></div>" +
                        "<div class=\"divOrderReviewHeaderBiggerDetails\">&nbsp;</div>" +
                        "<div class=\"divOrderReviewHeaderSmallerDetails\">" + String.Format("{0:C}", price) + "</div>" +
                        "<div class=\"divOrderReviewHeaderSmallerDetails\">" + qty + "</div>" +
                        "<div style=\"padding-left: 5px\" class=\"divOrderReviewHeaderSmallerDetails\">" + String.Format("{0:C}", totalPrice) + "</div>";
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

                        tableBuilder += "<tr><td class=\"tdOrderReviewMain\">" +
                        "<div class=\"divOrderReviewHeaderBiggerDetails\"><a href=\"Product/Accessory.aspx?id=" + id + "\">" + name + "</a></div>" +
                        "<div class=\"divOrderReviewHeaderBiggerDetails\">&nbsp;</div>" +
                        "<div class=\"divOrderReviewHeaderSmallerDetails\">" + String.Format("{0:C}", price) + "</div>" +
                        "<div class=\"divOrderReviewHeaderSmallerDetails\">" + qty + "</div>" +
                        "<div style=\"padding-left: 5px\" class=\"divOrderReviewHeaderSmallerDetails\">" + String.Format("{0:C}", totalPrice) + "</div>";
                    }
                    else if (item.GetType().ToString() == "Contacts")
                    {
                        string id = ((Contacts)item).id;
                        string name = ((Contacts)item).name;
                        int leftQty = ((Contacts)item).leftQty;
                        string leftPower = ((Contacts)item).leftPower;
                        string leftBaseCurve = ((Contacts)item).leftBaseCurve;
                        string leftDiameter = ((Contacts)item).leftDiameter;
                        int rightQty = ((Contacts)item).rightQty;
                        string rightPower = ((Contacts)item).rightPower;
                        string rightBaseCurve = ((Contacts)item).rightBaseCurve;
                        string rightDiameter = ((Contacts)item).rightDiameter;
                        double price = ((Contacts)item).price;
                        string image = ((Contacts)item).image;
                        double leftPrice = Convert.ToDouble(leftQty * price);
                        double rightPrice = Convert.ToDouble(rightQty * price);
                        double totalPrice = leftPrice + rightPrice;
                        subtotal += totalPrice;

                        tableBuilder += "<tr><td class=\"tdOrderReviewMain\">" +
                        "<div class=\"divOrderReviewHeaderBiggerDetails\"><a href=\"Product/ContactLens.aspx?id=" + id + "\">" + name + "</a></div>" +
                        "<div class=\"divOrderReviewHeaderBiggerDetails\">Left eye: (" + leftPower + " Power) | (" + leftBaseCurve + " BC) | (" + leftDiameter + " Diameter)<br />" +
                            "Right eye: (" + rightPower + " Power) | (" + rightBaseCurve + " BC) | (" + rightDiameter + " Diameter)</div>" +
                        "<div class=\"divOrderReviewHeaderSmallerDetails\">" + String.Format("{0:C}", price) + "<br /> " + String.Format("{0:C}", price) + "</div>" +
                        "<div class=\"divOrderReviewHeaderSmallerDetails\">" + leftQty + "<br />" + rightQty + "</div>" +
                        "<div style=\"padding-left: 5px\" class=\"divOrderReviewHeaderSmallerDetails\">" + String.Format("{0:C}", rightPrice) + "<br /> " + String.Format("{0:C}", leftPrice) + "</div>";
                    }
                }

                orderTotalPrice = shippingPrice + subtotal;

                tableBuilder += "<tr><td class=\"tdOrderReviewFooter\">" +
                        "<div class=\"divOrderReviewFooter1\">&nbsp;</div>" +
                        "<div style=\"padding-top: 5px\" class=\"divOrderReviewFooter2\">Merchandise Subtotal:</div>" +
                        "<div style=\"padding-top: 5px\" class=\"divOrderReviewFooter3\">" + String.Format("{0:C}", subtotal) + " CAD</div>" +
                        "<div class=\"divOrderReviewFooter4\">&nbsp;</div>" +
                        "<div class=\"divOrderReviewFooter1\">&nbsp;</div>" +
                        "<div class=\"divOrderReviewFooter2\">Shipping:</div>" +
                        "<div class=\"divOrderReviewFooter3\">" + String.Format("{0:C}", shippingPrice) + " CAD</div>" +
                        "<div class=\"divOrderReviewFooter4\">&nbsp;</div>" +
                        "<div class=\"divOrderReviewFooter1\">&nbsp;</div>" +
                        "<div style=\"padding-bottom: 5px\" class=\"divOrderReviewFooter2\">Total:</div>" +
                        "<div style=\"padding-bottom: 5px\" class=\"divOrderReviewFooter3\">" + String.Format("{0:C}", orderTotalPrice) + " CAD</div>" +
                        "<div class=\"divOrderReviewFooter4\">&nbsp;</div>" +
                        "</td></tr></table>";
                lblShippingAddress.Text = tableBuilder;
            }
            else
            {
                Response.Redirect("APIError.aspx?" + retMsg);
            }
        }
        else
        {
            Response.Redirect("Home.aspx");
        }
    }
    

    protected void btnCheckout_Click(object sender, EventArgs e)
    {
        Server.Transfer("OrderController.aspx");
    }
}