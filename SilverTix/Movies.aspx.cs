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
    private static SqlConnection con = null;
    private static string dbConnStr = "SilverTixConnectionString";
    private static SqlCommand cmd = null;
    private static SqlDataAdapter dataAdapter = null;
    private static DataTable dataTable = null;
    private static DataView dataView = null;

    private static string startDate = "";
    private static string endDate = "";
    private static DateTime todaysDate = DateTime.Now;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.GetDate();
        }

        // Get the image id from the url
        string ImageId = Request.QueryString["img"];

        // Build our query statement
        string sqlText = "SELECT ImageData, ImageType FROM Movies WHERE MovieID = '" + ImageId + "'";

        con = new SqlConnection(ConfigurationManager.ConnectionStrings[dbConnStr].ConnectionString);
        cmd = new SqlCommand(sqlText, con);

        // Open the database and get a datareader
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read()) //yup we found our image
        {
            Response.ContentType = dr["ImageType"].ToString();
            Response.BinaryWrite((byte[])dr["ImageData"]);
        }
        con.Close();
    }

    private void GetDate()
    {
        if (Session["CalenderToday"] == null)
        {
            Session.Add("CalenderToday", todaysDate);
        }
        Session["CalenderToday"] = System.DateTime.Today;
        todaysDate = (DateTime)Session["CalenderToday"];
    }

    protected void rblMovieDateSelection_CheckChanged(object sender, EventArgs e)
    {
        // Set the visibility for label movie message to false
        lblMovieMsg.Visible = false;

        con = new SqlConnection(ConfigurationManager.ConnectionStrings[dbConnStr].ConnectionString);
        
        // Format the dates for "Now Playing"
        if (rblMovieDateSelection.SelectedValue == "Now")
        {
            cmd = new SqlCommand("SELECT MovieID, Title, ReleaseDate, RunningTime, "
                                + "Genre, Cast, Rating, ImageName FROM Movies "
                                + "WHERE ([ReleaseDate] <= @ReleaseDate)");
            cmd.Parameters.AddWithValue("@ReleaseDate", todaysDate);
            lblMovieHeader.Text = "Now Playing";
        }
        // Format the dates for "Coming Soon"
        else if (rblMovieDateSelection.SelectedValue == "Soon")
        {
            cmd = new SqlCommand("SELECT MovieID, Title, ReleaseDate, RunningTime, "
                                + "Genre, Cast, Rating, ImageName FROM Movies "
                                + "WHERE ([ReleaseDate] >= @ReleaseDate)");
            cmd.Parameters.AddWithValue("@ReleaseDate", todaysDate);
            lblMovieHeader.Text = "Coming Soon";
        }
        // Format the dates for "All"
        else if (rblMovieDateSelection.SelectedValue == "All")
        {
            cmd = new SqlCommand("SELECT MovieID, Title, ReleaseDate, RunningTime, "
                                + "Genre, Cast, Rating, ImageName FROM Movies");
            lblMovieHeader.Text = "All";
        }

        dataAdapter = new SqlDataAdapter();
        dataTable = new DataTable();

        cmd.CommandType = CommandType.Text;
        cmd.Connection = con;
        dataAdapter.SelectCommand = cmd;

        con.Open();
        dataAdapter.Fill(dataTable);
        dataView = new DataView();

        ViewState["dataTable"] = dataTable;

        dataView = movieTable.DefaultView;
        
        dataView.Sort = string.Format("{0} {1}", "Title", "asc");

        con.Close();

        lvMovies.DataSource = dataView;
        lvMovies.DataBind();

        if (dataTable.Rows.Count <= 0)
        {
            if (rblMovieDateSelection.SelectedValue == "Now")
            {
                lblMovieMsg.Text = "<br />There are currently no movies that are now playing.";
                lblMovieMsg.Visible = true;
            }
            else if (rblMovieDateSelection.SelectedValue == "Soon")
            {
                lblMovieMsg.Text = "<br />There are currently no movies that are coming soon.";
                lblMovieMsg.Visible = true;
            }
        }
    }

    

    // Data Table Entity
    public DataTable movieTable
    {
        get
        {
            return (DataTable)ViewState["dataTable"];
        }
        set
        {
            ViewState["dataTable"] = value;
        }
    }
}