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
using System.Data.SqlClient;
using System.Collections.Generic;


/** 
* The Frames class 
* 
* This is just to simulate some way of accessing data about our frames 
*/  
public class Frames : Items
{
    #region Private Variables
    private static SqlConnection con = null;
    private static string dbConnStr = "eyewearDBConnectionString";
    private static SqlCommand cmd = null;
    private static SqlDataReader readRow = null;
    private static string query;
    #endregion

    #region Get/set variables
    public string glassesID { get; set; }
    public string name { get; set; }
    public string rightSph { get; set; }
    public string rightCyl { get; set; }
    public string rightAxis { get; set; }
    public string rightPd { get; set; }
    public string rightAdd { get; set; }
    public string leftSph { get; set; }
    public string leftCyl { get; set; }
    public string leftAxis { get; set; }
    public string leftPd { get; set; }
    public string leftAdd { get; set; }
    public string lensIndex { get; set; }
    public double price { get; set; }
    public string image1 { get; set; }
    #endregion

    #region Constructor

    public Frames(string glassesID, string name, string rightSph, string rightCyl,
        string rightAxis, string rightPd, string leftSph, string leftCyl,
        string leftAxis, string leftPd, string lensIndex, double price, string image1)
    {
        this.glassesID = glassesID;
        this.name = name;
        this.rightSph = rightSph;
        this.rightCyl = rightCyl;
        this.rightAxis = rightAxis;
        this.rightPd = rightPd;
        this.leftSph = leftSph;
        this.leftCyl = leftCyl;
        this.leftAxis = leftAxis;
        this.leftPd = leftPd;
        this.lensIndex = lensIndex;
        this.price = price;
        this.image1 = image1;
    }
    #endregion

    #region Get frame SQL statements
    // Get the name of the current frame
    public static string GetName(string glassesID)
    {
        con = new SqlConnection(ConfigurationManager.ConnectionStrings[dbConnStr].ConnectionString);
        cmd = new SqlCommand();
        cmd.Parameters.AddWithValue("@glassesID", glassesID);
        cmd.CommandText = "SELECT name FROM Glasses WHERE glassesID = @glassesID";
        cmd.Connection = con;
        con.Open();
        readRow = cmd.ExecuteReader(CommandBehavior.Default);
        string output = "";
        while (readRow.Read())
        {
            output = readRow["name"].ToString();
        }
        readRow.Close();
        con.Close();
        return output;
    }

    // Get the price of the current frame
    public static string GetPrice(string glassesID)
    {
        con = new SqlConnection(ConfigurationManager.ConnectionStrings[dbConnStr].ConnectionString);
        cmd = new SqlCommand();
        cmd.Parameters.AddWithValue("@glassesID", glassesID);
        cmd.CommandText = "SELECT price FROM Glasses WHERE glassesID = @glassesID";
        cmd.Connection = con;
        con.Open();
        readRow = cmd.ExecuteReader(CommandBehavior.Default);
        string output = "";
        while (readRow.Read())
        {
            output = readRow["price"].ToString();
        }
        readRow.Close();
        con.Close();
        return output;
    }

    // Get the image of the current frame
    public static string GetImage1(string glassesID)
    {
        con = new SqlConnection(ConfigurationManager.ConnectionStrings[dbConnStr].ConnectionString);
        cmd = new SqlCommand();
        cmd.Parameters.AddWithValue("@glassesID", glassesID);
        cmd.CommandText = "SELECT image1 FROM Glasses WHERE glassesID = @glassesID";
        cmd.Connection = con;
        con.Open();
        readRow = cmd.ExecuteReader(CommandBehavior.Default);
        string output = "";
        while (readRow.Read())
        {
            output = readRow["image1"].ToString();
        }
        readRow.Close();
        con.Close();
        return output;
    }

    // Get all colours in the database that are frames
    public static List<string> GetAllColour()
    {
        con = new SqlConnection(ConfigurationManager.ConnectionStrings[dbConnStr].ConnectionString);
        cmd = new SqlCommand();
        cmd.CommandText = "SELECT DISTINCT color FROM Glasses WHERE color IS NOT NULL AND isASunglass = 'n' AND isAReadyReader = 'n'";
        cmd.Connection = con;
        con.Open();
        readRow = cmd.ExecuteReader(CommandBehavior.Default);
        List<string> output = new List<string>();
        while (readRow.Read())
        {
            output.Add(readRow["color"].ToString());
        }
        readRow.Close();
        con.Close();
        return output;
    }

    // Get all materials in the database that are frames
    public static List<string> GetAllMaterial()
    {
        con = new SqlConnection(ConfigurationManager.ConnectionStrings[dbConnStr].ConnectionString);
        cmd = new SqlCommand();
        cmd.CommandText = "SELECT DISTINCT material FROM Glasses WHERE material IS NOT NULL AND isASunglass = 'n' AND isAReadyReader = 'n'";
        cmd.Connection = con;
        con.Open();
        readRow = cmd.ExecuteReader(CommandBehavior.Default);
        List<string> output = new List<string>();
        while (readRow.Read())
        {
            output.Add(readRow["material"].ToString());
        }
        readRow.Close();
        con.Close();
        return output;
    }

    // Get all shapes in the database that are frames
    public static List<string> GetAllShape()
    {
        con = new SqlConnection(ConfigurationManager.ConnectionStrings[dbConnStr].ConnectionString);
        cmd = new SqlCommand();
        cmd.CommandText = "SELECT DISTINCT shape FROM Glasses WHERE shape IS NOT NULL AND isASunglass = 'n' AND isAReadyReader = 'n' ";
        cmd.Connection = con;
        con.Open();
        readRow = cmd.ExecuteReader(CommandBehavior.Default);
        List<string> output = new List<string>();
        while (readRow.Read())
        {
            output.Add(readRow["shape"].ToString());
        }
        readRow.Close();
        con.Close();
        return output;
    }
    #endregion

    #region Get readyreaders SQL statements
    // Get all colours in the database that are readyreaders
    public static List<string> GetAllReadersColour()
    {
        con = new SqlConnection(ConfigurationManager.ConnectionStrings[dbConnStr].ConnectionString);
        cmd = new SqlCommand();
        cmd.CommandText = "SELECT DISTINCT color FROM Glasses WHERE color IS NOT NULL AND isASunglass = 'n' AND isAReadyReader = 'y'";
        cmd.Connection = con;
        con.Open();
        readRow = cmd.ExecuteReader(CommandBehavior.Default);
        List<string> output = new List<string>();
        while (readRow.Read())
        {
            output.Add(readRow["color"].ToString());
        }
        readRow.Close();
        con.Close();
        return output;
    }
    #endregion

    #region Get sunglass SQL statements
    // Get all colours in the database that are sunglasses
    public static List<string> GetAllSunglassColour()
    {
        con = new SqlConnection(ConfigurationManager.ConnectionStrings[dbConnStr].ConnectionString);
        cmd = new SqlCommand();
        cmd.CommandText = "SELECT DISTINCT color FROM Glasses WHERE color IS NOT NULL AND isASunglass = 'y' AND isAReadyReader = 'n'";
        cmd.Connection = con;
        con.Open();
        readRow = cmd.ExecuteReader(CommandBehavior.Default);
        List<string> output = new List<string>();
        while (readRow.Read())
        {
            output.Add(readRow["color"].ToString());
        }
        readRow.Close();
        con.Close();
        return output;
    }

    // Get all materials in the database that are sunglasses
    public static List<string> GetAllSunglassMaterial()
    {
        con = new SqlConnection(ConfigurationManager.ConnectionStrings[dbConnStr].ConnectionString);
        cmd = new SqlCommand();
        cmd.CommandText = "SELECT DISTINCT material FROM Glasses WHERE material IS NOT NULL AND isASunglass = 'y' AND isAReadyReader = 'n'";
        cmd.Connection = con;
        con.Open();
        readRow = cmd.ExecuteReader(CommandBehavior.Default);
        List<string> output = new List<string>();
        while (readRow.Read())
        {
            output.Add(readRow["material"].ToString());
        }
        readRow.Close();
        con.Close();
        return output;
    }

    // Get all shapes in the database that are sunglasses
    public static List<string> GetAllSunglassShape()
    {
        con = new SqlConnection(ConfigurationManager.ConnectionStrings[dbConnStr].ConnectionString);
        cmd = new SqlCommand();
        cmd.CommandText = "SELECT DISTINCT shape FROM Glasses WHERE shape IS NOT NULL AND isASunglass = 'y' AND isAReadyReader = 'n' ";
        cmd.Connection = con;
        con.Open();
        readRow = cmd.ExecuteReader(CommandBehavior.Default);
        List<string> output = new List<string>();
        while (readRow.Read())
        {
            output.Add(readRow["shape"].ToString());
        }
        readRow.Close();
        con.Close();
        return output;
    }

    #endregion

    // Decrement the current frame inventory by 1
    public static void DecrementInventory(string glassesID)
    {
        con = new SqlConnection(ConfigurationManager.ConnectionStrings[dbConnStr].ConnectionString);
        con.Open();
        query = "UPDATE Glasses SET inventory = inventory - 1 WHERE glassesID = @glassesID";
        cmd = new SqlCommand(query, con);
        cmd.Parameters.AddWithValue("@glassesID", glassesID);
        cmd.ExecuteNonQuery();
        con.Close();
    }

    // Decrement the current sunglasses inventory by the specified qty
    public static void DecrementGlassesInventory(string glassesID, int qty)
    {
        con = new SqlConnection(ConfigurationManager.ConnectionStrings[dbConnStr].ConnectionString);
        con.Open();
        query = "UPDATE Glasses SET inventory = inventory - @qty WHERE glassesID = @glassesID";
        cmd = new SqlCommand(query, con);
        cmd.Parameters.AddWithValue("@glassesID", glassesID);
        cmd.Parameters.AddWithValue("@qty", qty);
        cmd.ExecuteNonQuery();
        con.Close();
    }

    // Check the current frames inventory
    public static string CheckQty(string glassesID)
    {
        con = new SqlConnection(ConfigurationManager.ConnectionStrings[dbConnStr].ConnectionString);
        cmd = new SqlCommand();
        cmd.Parameters.AddWithValue("@glassesID", glassesID);
        cmd.CommandText = "SELECT inventory FROM Glasses WHERE glassesID = @glassesID";
        cmd.Connection = con;
        con.Open();
        readRow = cmd.ExecuteReader(CommandBehavior.Default);
        string output = "";
        while (readRow.Read())
        {
            output = readRow["inventory"].ToString();
        }
        readRow.Close();
        con.Close();
        return output;
    }
}