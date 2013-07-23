using System;
using System.Collections;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Text;
using System.Data;
using System.Configuration;
using System.Web;
using System.Collections.Generic;

/// <summary>
/// Summary description for NVPAPICaller
/// </summary>
public class NVPAPICaller
{
    //private static readonly ILog log = LogManager.GetLogger(typeof(NVPAPICaller));
	
    private string pendpointurl = "https://api-3t.paypal.com/nvp";
    private const string CVV2 = "CVV2";

    //Flag that determines the PayPal environment (live or sandbox)
    private const bool bSandbox = true;

    private const string SIGNATURE = "SIGNATURE";
    private const string PWD = "PWD";
    private const string ACCT = "ACCT";

    //Replace <API_USERNAME> with your API Username
    //Replace <API_PASSWORD> with your API Password
    //Replace <API_SIGNATURE> with your Signature
    public string APIUsername = "ontest_1304718436_biz_api1.hotmail.com";
    private string APIPassword = "6P5YW72ETW3UNRUN";
    private string APISignature = "AmJTFiRF72TbvOC-fYalhtr3RBLmA3glbIJCq0vKR1X2zNjuHhtL0U2D";
    private string Subject = "";
	private string BNCode = "PP-ECWizard";

    //HttpWebRequest Timeout specified in milliseconds 
    private const int Timeout = 86400000;
    private static readonly string[] SECURED_NVPS = new string[] { ACCT, CVV2, SIGNATURE, PWD };


    /// <summary>
    /// Sets the API Credentials
    /// </summary>
    /// <param name="Userid"></param>
    /// <param name="Pwd"></param>
    /// <param name="Signature"></param>
    /// <returns></returns>
    public void SetCredentials(string Userid, string Pwd, string Signature)
    {
        APIUsername = Userid;
        APIPassword = Pwd;
        APISignature = Signature;
    }

    /// <summary>
    /// ShortcutExpressCheckout: The method that calls SetExpressCheckout API
    /// </summary>
    /// <param name="amt"></param>
    /// <param ref name="token"></param>
    /// <param ref name="retMsg"></param>
    /// <returns></returns>
    public bool ShortcutExpressCheckout(List<Items> items, string amt, string baseUrl, 
                    ref string token, ref string retMsg, string shipping)
    {
		string host = "www.paypal.com";
		if (bSandbox)
		{
			pendpointurl = "https://api-3t.sandbox.paypal.com/nvp";
			host = "www.sandbox.paypal.com";
		}

        string returnURL = baseUrl + "OrderReview.aspx";
        string cancelURL = baseUrl + "View-Cart.aspx";

        NVPCodec encoder = new NVPCodec();
        encoder["METHOD"] = "SetExpressCheckout";
        encoder["LOCALECODE"] = "CA";
        encoder["RETURNURL"] = returnURL;
        encoder["CANCELURL"] = cancelURL;
        encoder["SOLUTIONTYPE"] = "Sole";
        encoder["LANDINGPAGE"] = "Billing";
        
        int count = 0;
        foreach (Items item in items)
        {
            if (item.GetType().ToString() == "Frames")
            {
                encoder["L_PAYMENTREQUEST_0_NAME" + count] = ((Frames)item).name;
                encoder["L_PAYMENTREQUEST_0_QTY" + count] = ((Frames)item).qty.ToString();
                encoder["L_PAYMENTREQUEST_0_AMT" + count] = ((Frames)item).price.ToString(); // Cost of an item
                count++;
            }

            else if (item.GetType().ToString() == "Contacts")
            {
                encoder["L_PAYMENTREQUEST_0_NAME" + count] = ((Contacts)item).name;
                int totalQty = ((Contacts)item).leftQty + ((Contacts)item).rightQty;
                encoder["L_PAYMENTREQUEST_0_QTY" + count] = totalQty.ToString();
                encoder["L_PAYMENTREQUEST_0_AMT" + count] = ((Contacts)item).price.ToString(); // Cost of an item
                count++;
            }
            else if (item.GetType().ToString().Contains("ReadyReaders"))
            {
                encoder["L_PAYMENTREQUEST_0_NAME" + count] = item.name;
                encoder["L_PAYMENTREQUEST_0_QTY" + count] = item.qty.ToString();
                encoder["L_PAYMENTREQUEST_0_AMT" + count] = item.price.ToString(); // Cost of an item
                count++;
            }
            else if (item.GetType().ToString().Contains("Sunglasses"))
            {
                encoder["L_PAYMENTREQUEST_0_NAME" + count] = item.name;
                encoder["L_PAYMENTREQUEST_0_QTY" + count] = item.qty.ToString();
                encoder["L_PAYMENTREQUEST_0_AMT" + count] = item.price.ToString(); // Cost of an item
                count++;
            }
            else if (item.GetType().ToString().Contains("Solutions"))
            {
                encoder["L_PAYMENTREQUEST_0_NAME" + count] = item.name;
                encoder["L_PAYMENTREQUEST_0_QTY" + count] = item.qty.ToString();
                encoder["L_PAYMENTREQUEST_0_AMT" + count] = item.price.ToString(); // Cost of an item
                count++;
            }
            else if (item.GetType().ToString().Contains("Accessories"))
            {
                encoder["L_PAYMENTREQUEST_0_NAME" + count] = item.name;
                encoder["L_PAYMENTREQUEST_0_QTY" + count] = item.qty.ToString();
                encoder["L_PAYMENTREQUEST_0_AMT" + count] = item.price.ToString(); // Cost of an item
                count++;
            }
        }

        double finalAmount = Convert.ToDouble(amt) + Convert.ToDouble(shipping);
        // encoder["PAYMENTREQUEST_0_TAXAMT"] = tax.ToString(); // Sum of tax for all items.
        encoder["PAYMENTREQUEST_0_SHIPPINGAMT"] = shipping.ToString(); // Sum of shipping for all items.
        encoder["PAYMENTREQUEST_0_ITEMAMT"] = amt.ToString(); // Sum of cost of all items.
        encoder["PAYMENTREQUEST_0_AMT"] = String.Format("{0:0.00}", finalAmount); // The total cost of the transaction to the customer.
        encoder["PAYMENTREQUEST_0_PAYMENTACTION"] = "Sale";
        encoder["PAYMENTREQUEST_0_CURRENCYCODE"] = "CAD";

        string pStrrequestforNvp = encoder.Encode();
        string pStresponsenvp = HttpCall(pStrrequestforNvp);

        NVPCodec decoder = new NVPCodec();
        decoder.Decode(pStresponsenvp);

        string strAck = decoder["ACK"].ToLower();
        if (strAck != null && (strAck == "success" || strAck == "successwithwarning"))
        {
            token = decoder["TOKEN"];

            string ECURL = "https://" + host + "/cgi-bin/webscr?cmd=_express-checkout" + "&token=" + token;

            retMsg = ECURL;
            return true;
        }
        else
        {
            retMsg = "ErrorCode=" + decoder["L_ERRORCODE0"] + "&" +
                "Desc=" + decoder["L_SHORTMESSAGE0"] + "&" +
                "Desc2=" + decoder["L_LONGMESSAGE0"];

            return false;
        }
    }

    /// <summary>
    /// MarkExpressCheckout: The method that calls SetExpressCheckout API, invoked from the 
    /// Billing Page EC placement
    /// </summary>
    /// <param name="amt"></param>
    /// <param ref name="token"></param>
    /// <param ref name="retMsg"></param>
    /// <returns></returns>
    public bool MarkExpressCheckout(string amt, 
                        string shipToName, string shipToStreet, string shipToStreet2,
                        string shipToCity, string shipToState, string shipToZip, 
                        string shipToCountryCode, string baseUrl, ref string token, 
                        ref string retMsg)
    {
        string host = "www.paypal.com";
        if (bSandbox)
        {
            pendpointurl = "https://api-3t.sandbox.paypal.com/nvp";
            host = "www.sandbox.paypal.com";
        }

        string returnURL = baseUrl + "OrderReview.aspx";
        string cancelURL = baseUrl + "View-Cart.aspx";

        NVPCodec encoder = new NVPCodec();
        encoder["METHOD"] = "SetExpressCheckout";
        encoder["RETURNURL"] = returnURL;
        encoder["CANCELURL"] = cancelURL;
        encoder["PAYMENTREQUEST_0_AMT"] = amt;
        encoder["PAYMENTACTION"] = "Sale";
        encoder["CURRENCYCODE"] = "CAD";

        //Optional Shipping Address entered on the merchant site
        encoder["SHIPTONAME"]       = shipToName;
        encoder["SHIPTOSTREET"]     = shipToStreet;
        encoder["SHIPTOSTREET2"]    = shipToStreet2;
        encoder["SHIPTOCITY"]       = shipToCity;
        encoder["SHIPTOSTATE"]      = shipToState;
        encoder["SHIPTOZIP"]        = shipToZip;
        encoder["SHIPTOCOUNTRYCODE"]= shipToCountryCode;


        string pStrrequestforNvp = encoder.Encode();
        string pStresponsenvp = HttpCall(pStrrequestforNvp);

        NVPCodec decoder = new NVPCodec();
        decoder.Decode(pStresponsenvp);

        string strAck = decoder["ACK"].ToLower();
        if (strAck != null && (strAck == "success" || strAck == "successwithwarning"))
        {
            token = decoder["TOKEN"];

            string ECURL = "https://" + host + "/cgi-bin/webscr?cmd=_express-checkout" + "&token=" + token;

            retMsg = ECURL;
            return true;
        }
        else
        {
            retMsg = "ErrorCode=" + decoder["L_ERRORCODE0"] + "&" +
                "Desc=" + decoder["L_SHORTMESSAGE0"] + "&" +
                "Desc2=" + decoder["L_LONGMESSAGE0"];

            return false;
        }
    }



    /// <summary>
    /// GetShippingDetails: The method that calls SetExpressCheckout API, invoked from the 
    /// Billing Page EC placement
    /// </summary>
    /// <param name="token"></param>
    /// <param ref name="retMsg"></param>
    /// <returns></returns>
    public bool GetShippingDetails(string token, ref string payerID, ref string ShippingAddress, ref string retMsg)
    {
		if (bSandbox)
		{
			pendpointurl = "https://api-3t.sandbox.paypal.com/nvp";
		}
		
        NVPCodec encoder = new NVPCodec();
        encoder["METHOD"] = "GetExpressCheckoutDetails";
        encoder["TOKEN"] = token;

        string pStrrequestforNvp = encoder.Encode();
        string pStresponsenvp = HttpCall(pStrrequestforNvp);

        NVPCodec decoder = new NVPCodec();
        decoder.Decode( pStresponsenvp );

        string strAck = decoder["ACK"].ToLower();
        if (strAck != null && (strAck == "success" || strAck == "successwithwarning"))
        {
            payerID = decoder["PAYERID"];

            ShippingAddress = "<table><tr>";
            ShippingAddress += "<td style='font-weight: bold'>Shipping Address</td></tr>";
            ShippingAddress += "<td><span id=\"spanShippingName\">" + decoder["SHIPTONAME"] + "</span></td></tr>";
            ShippingAddress += "<td><span id=\"spanShippingStreet1\">" + decoder["SHIPTOSTREET"] + "</span></td></tr>";
            ShippingAddress += "<td><span id=\"spanShippingStreet2\">" + decoder["SHIPTOSTREET2"] + "</span></td></tr>";
            ShippingAddress += "<td><span id=\"spanShippingCity\">" + decoder["SHIPTOCITY"] + "</span>" +
                ",&nbsp;<span id=\"spanShippingState\">" + decoder["SHIPTOSTATE"] + "</span>" +
                "&nbsp;<span id=\"spanShippingZip\">" + decoder["SHIPTOZIP"] + "</span></td></tr>";
            ShippingAddress += "<td><span id=\"spanShippingCountry\">" + decoder["SHIPTOCOUNTRYCODE"] + "</span></td></tr>";
            ShippingAddress += "<td></td>";
            ShippingAddress += "</tr></table>";

            return true;
        }
        else
        {
            retMsg = "ErrorCode=" + decoder["L_ERRORCODE0"] + "&" +
                "Desc=" + decoder["L_SHORTMESSAGE0"] + "&" +
                "Desc2=" + decoder["L_LONGMESSAGE0"];

            return false;
        }
    }


    /// <summary>
    /// ConfirmPayment: The method that calls SetExpressCheckout API, invoked from the 
    /// Billing Page EC placement
    /// </summary>
    /// <param name="token"></param>
    /// <param ref name="retMsg"></param>
    /// <returns></returns>
    public bool ConfirmPayment(string finalPaymentAmount, string itemAmt, string shipping, string token, string payerID, ref NVPCodec decoder, ref string retMsg)
    {
		if (bSandbox)
		{
			pendpointurl = "https://api-3t.sandbox.paypal.com/nvp";
		}
		
        NVPCodec encoder = new NVPCodec();
        encoder["METHOD"] = "DoExpressCheckoutPayment";
        encoder["TOKEN"] = token;
        encoder["PAYMENTACTION"] = "Sale";
        encoder["PAYERID"] = payerID;
        encoder["PAYMENTREQUEST_0_CURRENCYCODE"] = "CAD";
        encoder["PAYMENTREQUEST_0_SHIPPINGAMT"] = shipping.ToString(); // Sum of shipping for all items.
        encoder["PAYMENTREQUEST_0_ITEMAMT"] = itemAmt.ToString(); // Sum of cost of all items.
        encoder["PAYMENTREQUEST_0_AMT"] = finalPaymentAmount.ToString();

        string pStrrequestforNvp = encoder.Encode();
        string pStresponsenvp = HttpCall(pStrrequestforNvp);

        decoder = new NVPCodec();
        decoder.Decode(pStresponsenvp);

        string strAck = decoder["ACK"].ToLower();
        if (strAck != null && (strAck == "success" || strAck == "successwithwarning"))
        {
            return true;
        }
        else
        {
            retMsg = "ErrorCode=" + decoder["L_ERRORCODE0"] + "&" +
                "Desc=" + decoder["L_SHORTMESSAGE0"] + "&" +
                "Desc2=" + decoder["L_LONGMESSAGE0"];

            return false;
        }
    }


    /// <summary>
    /// HttpCall: The main method that is used for all API calls
    /// </summary>
    /// <param name="NvpRequest"></param>
    /// <returns></returns>
    public string HttpCall(string NvpRequest) //CallNvpServer
    {
        string url = pendpointurl;

        //To Add the credentials from the profile
        string strPost = NvpRequest + "&" + buildCredentialsNVPString();
		strPost = strPost + "&BUTTONSOURCE=" + HttpContext.Current.Server.UrlEncode( BNCode );

        HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(url);
        objRequest.Timeout = Timeout;
        objRequest.Method = "POST";
        objRequest.ContentLength = strPost.Length;

        try
        {
            using (StreamWriter myWriter = new StreamWriter(objRequest.GetRequestStream()))
            {
                myWriter.Write(strPost);
            }
        }
        catch (Exception e)
        {
            /*
            if (log.IsFatalEnabled)
            {
                log.Fatal(e.Message, this);
            }*/
        }

        //Retrieve the Response returned from the NVP API call to PayPal
        HttpWebResponse objResponse = (HttpWebResponse)objRequest.GetResponse();
        string result;
        using (StreamReader sr = new StreamReader(objResponse.GetResponseStream()))
        {
            result = sr.ReadToEnd();
        }

        //Logging the response of the transaction
        /* if (log.IsInfoEnabled)
         {
             log.Info("Result :" +
                       " Elapsed Time : " + (DateTime.Now - startDate).Milliseconds + " ms" +
                      result);
         }
         */
        return result;
    }

    /// <summary>
    /// Credentials added to the NVP string
    /// </summary>
    /// <param name="profile"></param>
    /// <returns></returns>
    private string buildCredentialsNVPString()
    {
        NVPCodec codec = new NVPCodec();

        if (!IsEmpty(APIUsername))
            codec["USER"] = APIUsername;

        if (!IsEmpty(APIPassword))
            codec[PWD] = APIPassword;

        if (!IsEmpty(APISignature))
            codec[SIGNATURE] = APISignature;

        if (!IsEmpty(Subject))
            codec["SUBJECT"] = Subject;

        codec["VERSION"] = "65.0";

        return codec.Encode();
    }

    /// <summary>
    /// Returns if a string is empty or null
    /// </summary>
    /// <param name="s">the string</param>
    /// <returns>true if the string is not null and is not empty or just whitespace</returns>
    public static bool IsEmpty(string s)
    {
        return s == null || s.Trim() == string.Empty;
    }
}


public sealed class NVPCodec : NameValueCollection
{
    private const string AMPERSAND = "&";
    private const string EQUALS = "=";
    private static readonly char[] AMPERSAND_CHAR_ARRAY = AMPERSAND.ToCharArray();
    private static readonly char[] EQUALS_CHAR_ARRAY = EQUALS.ToCharArray();

    /// <summary>
    /// Returns the built NVP string of all name/value pairs in the Hashtable
    /// </summary>
    /// <returns></returns>
    public string Encode()
    {
        StringBuilder sb = new StringBuilder();
        bool firstPair = true;
        foreach (string kv in AllKeys)
        {
            string name = UrlEncode(kv);
            string value = UrlEncode(this[kv]);
            if (!firstPair)
            {
                sb.Append(AMPERSAND);
            }
            sb.Append(name).Append(EQUALS).Append(value);
            firstPair = false;
        }
        return sb.ToString();
    }

    /// <summary>
    /// Decoding the string
    /// </summary>
    /// <param name="nvpstring"></param>
    public void Decode(string nvpstring)
    {
        Clear();
        foreach (string nvp in nvpstring.Split(AMPERSAND_CHAR_ARRAY))
        {
            string[] tokens = nvp.Split(EQUALS_CHAR_ARRAY);
            if (tokens.Length >= 2)
            {
                string name = UrlDecode(tokens[0]);
                string value = UrlDecode(tokens[1]);
                Add(name, value);
            }
        }
    }

    private static string UrlDecode(string s) { return HttpUtility.UrlDecode(s); }
    private static string UrlEncode(string s) { return HttpUtility.UrlEncode(s); }

    #region Array methods
    public void Add(string name, string value, int index)
    {
        this.Add(GetArrayName(index, name), value);
    }

    public void Remove(string arrayName, int index)
    {
        this.Remove(GetArrayName(index, arrayName));
    }

    /// <summary>
    /// 
    /// </summary>
    public string this[string name, int index]
    {
        get
        {
            return this[GetArrayName(index, name)];
        }
        set
        {
            this[GetArrayName(index, name)] = value;
        }
    }

    private static string GetArrayName(int index, string name)
    {
        if (index < 0)
        {
            throw new ArgumentOutOfRangeException("index", "index can not be negative : " + index);
        }
        return name + index;
    }
    #endregion
}