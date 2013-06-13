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

public partial class _MovieDetails : System.Web.UI.Page
{
    private Ticket selectedTicket;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["title"] == null)
        {
            Response.Redirect("~/Movies.aspx");
        }

        // Gets the name of the product and put it as the title
        Label lblTitle = ((Label)fvMovieDetails.FindControl("lblTitle"));

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

        SqlConnection connection = new SqlConnection(ConfigurationSettings.AppSettings["DSN"].ToString());
        SqlCommand command = new SqlCommand(sqlText, connection);

        //open the database and get a datareader
        connection.Open();
        SqlDataReader dr = command.ExecuteReader();
        if (dr.Read()) //yup we found our image
        {
            Response.ContentType = dr["ImageType"].ToString();
            Response.BinaryWrite((byte[])dr["ImageData"]);
        }
        connection.Close();

        if (!IsPostBack)
            ddlPrices.DataBind();
        selectedTicket = this.GetSelectedTicket();
        lblCash.Text = selectedTicket.Price.ToString("c");
    }

    //Get Selected Movie
    private Ticket GetSelectedTicket()
    {
        DataView pricesTable = (DataView)
            SqlMovieSource.Select(DataSourceSelectArguments.Empty);
        pricesTable.RowFilter = "Age = '" + ddlPrices.SelectedItem.Text + "'";
        DataRowView row = (DataRowView)pricesTable[0];

        Ticket t = new Ticket();
        t.MovieID = (int)row["MovieID"];
        t.PriceID = (int)row["PriceID"];
        t.Price = (decimal)row["Price"];
        t.Title = row["Title"].ToString();
        t.Age = row["Age"].ToString();
        return t;
    }
    //Add Price to Cart
    protected void btnAddToCart_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            CartItem item = new CartItem();
            item.Ticket = selectedTicket;
            item.Quantity = Convert.ToInt32(txtQuantity.Text);
            this.AddToCart(item);
            Response.Redirect("~/Promo/Cart.aspx");
        }
    }
    //Add to Cart method
    private void AddToCart(CartItem item)
    {
        SortedList array_cart = this.GetCart();
        string ticketID = selectedTicket.Title;
        if (array_cart.ContainsKey(ticketID))
        {
            CartItem existingItem = (CartItem)array_cart[ticketID];
            existingItem.Quantity += item.Quantity;
        }
        else
            array_cart.Add(ticketID, item);
    }
    //Sorted List
    private SortedList GetCart()
    {
        if (Session["Cart"] == null)
        {
            Session.Add("Cart", new SortedList());
        }
        return (SortedList)Session["Cart"];
    }
}
