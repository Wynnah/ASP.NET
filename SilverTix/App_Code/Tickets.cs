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


public class Tickets
{
    public int movieID { get; set; }
    public string title { get; set; }
    public int priceID { get; set; }
    public decimal price { get; set; }
    public string age { get; set; }
    public int quantity { get; set; }

    public class Ticket : Tickets
    {
        public Ticket(int movieID, string title, int priceID, decimal price, string age, int quantity)
        {
            base.SetInfo(movieID, title, priceID, price, age, quantity);
        }
    }

    private void SetInfo(int movieID, string title, int priceID, decimal price,
                            string age, int quantity)
    {
        this.movieID = movieID;
        this.title = title;
        this.priceID = priceID;
        this.price = price;
        this.age = age;
        this.quantity = quantity;
    }
}
