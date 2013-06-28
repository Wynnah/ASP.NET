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

public partial class _Home : System.Web.UI.Page
{
    private static SqlConnection con = null;
    private static string dbConnStr = "SilverTixConnectionString";
    private static SqlCommand cmd = null;

    protected void Page_Load(object sender, System.EventArgs e)
    {
        //get the image id from the url
        string ImageId = Request.QueryString["img"];

        //build our query statement
        string sqlText = "SELECT ImageData, ImageType FROM Movies WHERE MovieID = '" + ImageId + "'";

        con = new SqlConnection(ConfigurationManager.ConnectionStrings[dbConnStr].ConnectionString);
        cmd = new SqlCommand(sqlText, con);

        //open the database and get a datareader
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read()) //yup we found our image
        {
            Response.ContentType = dr["ImageType"].ToString();
            Response.BinaryWrite((byte[])dr["ImageData"]);
        }
        con.Close();
    }
}
