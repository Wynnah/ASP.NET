using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

/// <summary>
/// Summary description for CartItem
/// </summary>
public class CartItem
{
    public Ticket Ticket;
    public int Quantity;

    public string Display()
    {
        string displayString =
            Ticket.Title + " (" + Quantity.ToString()
                + " " +  Ticket.Age + " ticket(s) " + " at " + Ticket.Price.ToString("c") + " each)";
        return displayString;
    }
}
