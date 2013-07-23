using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class OrderController : System.Web.UI.Page
{
    private List<Items> shoppingList;
    private string error = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["shoppingCart"] != null && Session["token"] != null && Session["payerId"] != null &&
             Session["payment_amt"] != null && Session["shipping"] != null)
        {
            NVPAPICaller test = new NVPAPICaller();

            string retMsg = "";
            string token = "";
            string payerID = "";
            string shipping = "";
            string itemAmt = "";
            double convertFinalPaymentAmount;
            string finalPaymentAmount = "";
            NVPCodec decoder = new NVPCodec();

            shipping = Session["shipping"].ToString();
            token = Session["token"].ToString();
            payerID = Session["payerId"].ToString();
            itemAmt = String.Format("{0:0.00}", Session["payment_amt"]);
            convertFinalPaymentAmount = Convert.ToDouble(itemAmt) + Convert.ToDouble(shipping);
            finalPaymentAmount = String.Format("{0:0.00}", convertFinalPaymentAmount);

            if (Session["shoppingCart"] != null)
            {
                shoppingList = (List<Items>)Session["shoppingCart"];
                foreach (Items item in shoppingList)
                {
                    if (item.GetType().ToString() == "Frames")
                    {
                        string glassesID = ((Frames)item).glassesID;
                        string glassesName = item.name;
                        int glassQtyInDb = Convert.ToInt16(Frames.CheckQty(glassesID));
                        if (glassQtyInDb <= 0)
                        {
                            error += "Sorry, you have ordered " + glassesName + ", and the quantity you have specified is currently more than our in stock.<br />";
                        }
                    }
                    else if (item.GetType().ToString() == "Contacts")
                    {
                        string contactLensID = ((Contacts)item).id;
                        string contactLensName = ((Contacts)item).name;
                        int leftQty = ((Contacts)item).leftQty;
                        int rightQty = ((Contacts)item).rightQty;
                        int qty = leftQty + rightQty;
                        int contactLensQtyInDb = Convert.ToInt16(Contacts.CheckQty(contactLensID));
                        if (contactLensQtyInDb < qty) {
                            error += "Sorry, you have ordered " + contactLensName + ", and the quantity you have specified is currently more than our in stock.<br />";
                        }
                    }
                    else if (item.GetType().ToString().Contains("Sunglasses") || item.GetType().ToString().Contains("ReadyReaders"))
                    {
                        string glassesID = item.id;
                        string glassesName = item.name;
                        int qty = item.qty;
                        Items newitem = new Items ();
                        int itemGlassQtyInDb = Convert.ToInt16(Frames.CheckQty(glassesID));
                        if (itemGlassQtyInDb < qty)
                        {
                            error += "Sorry, you have ordered " + glassesName + ", and the quantity you have specified is currently more than our in stock.<br />";
                        }
                    }
                    else if (item.GetType().ToString().Contains("Solutions") || item.GetType().ToString().Contains("Accessories"))
                    {
                        string itemID = item.id;
                        string itemName = item.name;
                        int qty = item.qty;
                        Items newitem = new Items();
                        int itemQtyInDb = Convert.ToInt16(newitem.CheckQty(itemID));
                        if (itemQtyInDb < qty)
                        {
                            error += "Sorry, you have ordered " + itemName + ", and the quantity you have specified is currently more than our in stock.<br />";
                        }
                    }
                }
                if (error != "")
                {
                    Session["error"] = error;
                    Response.Redirect("APIError.aspx");
                }
            }

            bool ret = test.ConfirmPayment(finalPaymentAmount, itemAmt, shipping, token, payerID, ref decoder, ref retMsg);
            if (ret)
            {
                // Unique transaction ID of the payment. Note:  If the PaymentAction of the request was Authorization or Order, this value is your AuthorizationID for use with the Authorization & Capture APIs. 
                string transactionId = decoder["TRANSACTIONID"];

                // The type of transaction Possible values: l  cart l  express-checkout 
                string transactionType = decoder["TRANSACTIONTYPE"];

                // Indicates whether the payment is instant or delayed. Possible values: l  none l  echeck l  instant 
                string paymentType = decoder["PAYMENTTYPE"];

                // Time/date stamp of payment
                string orderTime = decoder["ORDERTIME"];

                // The final amount charged, including any shipping and taxes from your Merchant Profile.
                string amt = decoder["AMT"];

                // A three-character currency code for one of the currencies listed in PayPay-Supported Transactional Currencies. Default: USD.    
                string currencyCode = decoder["CURRENCYCODE"];

                // PayPal fee amount charged for the transaction    
                string feeAmt = decoder["FEEAMT"];

                // Amount deposited in your PayPal account after a currency conversion.    
                string settleAmt = decoder["SETTLEAMT"];

                // Tax charged on the transaction.    
                string taxAmt = decoder["TAXAMT"];

                //' Exchange rate if a currency conversion occurred. Relevant only if your are billing in their non-primary currency. If 
                string exchangeRate = decoder["EXCHANGERATE"];

                if (Session["shoppingCart"] != null)
                {
                    shoppingList = (List<Items>)Session["shoppingCart"];
                    foreach (Items item in shoppingList)
                    {
                        string index = shoppingList.IndexOf(item).ToString();
                        string itemType = item.GetType().ToString();

                        if (item.GetType().ToString() == "Frames")
                        {
                            string glassesID = ((Frames)item).glassesID;
                            Frames.DecrementInventory(glassesID);
                        }
                        else if (item.GetType().ToString() == "Contacts")
                        {
                            string contactLensID = ((Contacts)item).id;
                            int leftQty = ((Contacts)item).leftQty;
                            int rightQty = ((Contacts)item).rightQty;
                            int qty = leftQty + rightQty;
                            Contacts.DecrementInventory(contactLensID, qty);
                        }
                        else if (item.GetType().ToString().Contains("Sunglasses") || item.GetType().ToString().Contains("ReadyReaders"))
                        {
                            string glassesID = item.id;
                            int qty = item.qty;
                            Frames.DecrementGlassesInventory(glassesID, qty);
                        }
                        else if (item.GetType().ToString().Contains("Solutions") || item.GetType().ToString().Contains("Accessories"))
                        {
                            string itemID = item.id;
                            int qty = item.qty;
                            Items newitem = new Items();
                            newitem.DecrementInventory(itemID, qty);
                        }
                    }
                }

                Session.RemoveAll();

                Response.Redirect("OrderConfirm.aspx");
            }
            else
            {
                Response.Redirect("APIError.aspx?" + retMsg);
            }
        }
        else
        {
            error = "ErrorCode=Session expired&" +
                "Desc=Your current session has expired.";
            Response.Redirect("APIError.asp?" + error);
        }
    }
}