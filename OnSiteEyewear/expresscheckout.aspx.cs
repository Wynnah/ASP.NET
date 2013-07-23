using System;
using System.Web;
using System.Collections.Generic;

public partial class PayPalEC : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        NVPAPICaller PayPalCaller = new NVPAPICaller();
        string retMsg = "";
        string token = "";
        string baseUrl = "";

        if (HttpContext.Current.Request.IsLocal)
        {
            baseUrl = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) +
                            HttpContext.Current.Request.ApplicationPath + "/";
        }

        if (Session["payment_amt"] != null)
        {
           // string tax = String.Format("{0:0.00}", Session["payment_tax"]);
           // string itemAmt = String.Format("{0:0.00}", Session["payment_subtotal"]);
            string amt = String.Format("{0:0.00}", Session["payment_amt"]);
            List<Items> itemList = (List<Items>)Session["shoppingCart"];
            string shipping = "";
            if(Request.QueryString["shipping"] != null)
            {
                shipping = Request.QueryString["shipping"];
                Session["shipping"] = shipping;
            }
            bool ret = PayPalCaller.ShortcutExpressCheckout(itemList, amt, baseUrl, 
                            ref token, ref retMsg, shipping);
            if (ret)
            {
				Session["token"] = token;
                Response.Redirect( retMsg );
            }
            else
            {
                Response.Redirect("APIError.aspx?" + retMsg);
            }
        }
        else
        {
            Response.Redirect( "APIError.aspx?ErrorCode=AmtMissing" );
        }
    }
}