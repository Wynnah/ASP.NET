using System;
using System.Collections;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections.Generic;

public partial class _MovieDetails : System.Web.UI.Page
{
<<<<<<< HEAD
<<<<<<< HEAD
    private static SqlConnection con = null;
    private static string dbConnStr = "SilverTixConnectionString";
    private static SqlCommand cmd = null;

    //Make a Sorted List
    private List<CartItems> cartItems;
=======
    //Make a Sorted List
    private List<CartItems> cartItems;
    private Tickets selectedTicket;
>>>>>>> 20f298e21303c6c9856bd96520d678b2c4443aab
=======
    //Make a Sorted List
    private List<CartItems> cartItems;
    private Tickets selectedTicket;
>>>>>>> 20f298e21303c6c9856bd96520d678b2c4443aab
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["title"] == null)
        {
            Response.Redirect("~/Movies.aspx");
        }

        // Gets the name of the product and put it as the title
        Label lblTitle = ((Label)fvMovieDetails.FindControl("lblTitle"));

        // Set page title
        string title = lblTitle.Text;
        HtmlMeta metaTitle = new HtmlMeta();
        metaTitle.Name = title;
        metaTitle.Content = title;
        Page.Header.Controls.Add(metaTitle);
        Page.Title = metaTitle.Content;

        //Get the image id from the url
        string ImageId = Request.QueryString["img"];

        //Build our query statement
        string sqlText = "SELECT ImageData, ImageType FROM Movies WHERE MovieID = '" + ImageId + "'";

<<<<<<< HEAD
<<<<<<< HEAD
        con = new SqlConnection(ConfigurationManager.ConnectionStrings[dbConnStr].ConnectionString);
        cmd = new SqlCommand(sqlText, con);

        //Open the database and get a datareader
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
=======
=======
>>>>>>> 20f298e21303c6c9856bd96520d678b2c4443aab
        SqlConnection connection = new SqlConnection(ConfigurationSettings.AppSettings["DSN"].ToString());
        SqlCommand command = new SqlCommand(sqlText, connection);

        //Open the database and get a datareader
        connection.Open();
        SqlDataReader dr = command.ExecuteReader();
<<<<<<< HEAD
>>>>>>> 20f298e21303c6c9856bd96520d678b2c4443aab
=======
>>>>>>> 20f298e21303c6c9856bd96520d678b2c4443aab
        if (dr.Read()) //yup we found our image
        {
            Response.ContentType = dr["ImageType"].ToString();
            Response.BinaryWrite((byte[])dr["ImageData"]);
        }
<<<<<<< HEAD
<<<<<<< HEAD
        con.Close();
=======
        connection.Close();
>>>>>>> 20f298e21303c6c9856bd96520d678b2c4443aab
=======
        connection.Close();
>>>>>>> 20f298e21303c6c9856bd96520d678b2c4443aab

        if (!IsPostBack)
            ddlPrices.DataBind();
        lblCash.Text = getPrice().ToString("c");
<<<<<<< HEAD
<<<<<<< HEAD

        rfvCart.Enabled = false;
        rvCart.Enabled = false;
=======
>>>>>>> 20f298e21303c6c9856bd96520d678b2c4443aab
=======
>>>>>>> 20f298e21303c6c9856bd96520d678b2c4443aab
    }

    //Get price
    private decimal getPrice()
    {
        DataView pricesTable = (DataView)SqlMovieSource.Select(DataSourceSelectArguments.Empty);
        pricesTable.RowFilter = "Age = '" + ddlPrices.SelectedItem.Text + "'";
        DataRowView row = (DataRowView)pricesTable[0];

        decimal price = (decimal)row["Price"];

        return price;
    }

    //Get Selected Movie
    private CartItems GetSelectedTicket()
    {
        DataView pricesTable = (DataView)SqlMovieSource.Select(DataSourceSelectArguments.Empty);
        pricesTable.RowFilter = "Age = '" + ddlPrices.SelectedItem.Text + "'";
        DataRowView row = (DataRowView)pricesTable[0];

        Label lblTitle = (Label)fvMovieDetails.FindControl("lblTitle");

        int movieID = (int)row["MovieID"];
        string title = lblTitle.Text;
        int priceID = (int)row["PriceID"];
        decimal price = (decimal)row["Price"];
        string age = row["Age"].ToString();
        int quantity = 0;

        if (txtQuantity.Text.Trim().Length > 0)
            quantity = Convert.ToInt16(txtQuantity.Text);

<<<<<<< HEAD
<<<<<<< HEAD
        CartItems c = new CartItems(movieID, title, priceID, price, age, quantity);
=======
        CartItems c = new CartItems.Item(movieID, title, priceID, price, age, quantity);
>>>>>>> 20f298e21303c6c9856bd96520d678b2c4443aab
=======
        CartItems c = new CartItems.Item(movieID, title, priceID, price, age, quantity);
>>>>>>> 20f298e21303c6c9856bd96520d678b2c4443aab

        return c;
    }

    //Add Price to Cart
    protected void btnAddToCart_Click(object sender, EventArgs e)
    {
<<<<<<< HEAD
<<<<<<< HEAD
        rfvCart.Enabled = true;
        rvCart.Enabled = true;

=======
>>>>>>> 20f298e21303c6c9856bd96520d678b2c4443aab
=======
>>>>>>> 20f298e21303c6c9856bd96520d678b2c4443aab
        bool foundTicket = false;

        if (Page.IsValid)
        {
            // Grabs the current cart session
            cartItems = GetCartSession();

            // Grabs the ticket info
            CartItems ticketID = GetSelectedTicket();

            foreach (CartItems i in cartItems)
            {
                if (i.title == ticketID.title)
                {
                    if (i.age == ticketID.age)
                    {
                        i.quantity = i.quantity + ticketID.quantity;
                        foundTicket = true;
                        break;
                    }
                }
            }

            if (foundTicket == false)
            {
                cartItems.Add(ticketID);
            }

            Response.Redirect("~/Promo/Cart.aspx");
        }
    }
    //Get Cart Session
    private List<CartItems> GetCartSession()
    {
        if (Session["Cart"] == null)
        {
            Session.Add("Cart", new List<CartItems>());
        }
        return (List<CartItems>)Session["Cart"];
    }
<<<<<<< HEAD
<<<<<<< HEAD
}
=======
}
>>>>>>> 20f298e21303c6c9856bd96520d678b2c4443aab
=======
}
>>>>>>> 20f298e21303c6c9856bd96520d678b2c4443aab
