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

public partial class _Movies : System.Web.UI.Page
{
    private DateTime todayDate;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.GetDate();
        }

        //get the image id from the url
        string ImageId = Request.QueryString["img"];

        //build our query statement
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
    }
    protected void rbNowPlaying_CheckedChanged(object sender, EventArgs e)
    {
        if (rbNowPlaying.Checked)
        {
            lblMovieTime.Text = "Now Playing";
            lvAll.Visible = false;
            lvComingSoon.Visible = false;
            lvNowPlaying.Visible = true;
        }
    }
    protected void rbComingSoon_CheckedChanged(object sender, EventArgs e)
    {
        if (rbComingSoon.Checked)
        {
            lblMovieTime.Text = "Coming Soon";
            lvAll.Visible = false;
            lvComingSoon.Visible = true;
            lvNowPlaying.Visible = false;
        }
    }
    protected void rbAll_CheckedChanged(object sender, EventArgs e)
    {
        if (rbAll.Checked)
        {
            lblMovieTime.Text = "All";
            lvAll.Visible = true;
            lvComingSoon.Visible = false;
            lvNowPlaying.Visible = false;
        }
    }

    private void GetDate()
    {
        if (Session["CalenderToday"] == null)
        {
            Session.Add("CalenderToday", todayDate);
        }
        Session["CalenderToday"] = System.DateTime.Today;
        todayDate = (DateTime)Session["CalenderToday"];
    }
}