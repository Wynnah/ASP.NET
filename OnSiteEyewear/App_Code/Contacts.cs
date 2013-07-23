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

/// <summary>
/// Summary description for Contacts
/// </summary>
public class Contacts : Items
{
    private static SqlConnection con = null;
    private static string dbConnStr = "eyewearDBConnectionString";
    private static SqlCommand cmd = null;
    private static SqlDataReader readRow = null;
    private static string query;
	
    public string id { get; set; }
    public string name { get; set; }
    public int leftQty { get; set; }
    public string leftPower { get; set; }
    public string leftBaseCurve { get; set; }
    public string leftDiameter { get; set; }
    public int rightQty { get; set; }
    public string rightPower { get; set; }
    public string rightBaseCurve { get; set; }
    public string rightDiameter { get; set; }
    public double price { get; set; }
    public string image { get; set; }

    public Contacts()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public Contacts(string id, string name, int leftQty, string leftPower, string leftBaseCurve,
        string leftDiameter, int rightQty, string rightPower, string rightBaseCurve, 
        string rightDiameter, double price, string image)
    {
        this.id = id;
        this.name = name;
        this.leftQty = leftQty;
        this.leftPower = leftPower;
        this.leftBaseCurve = leftBaseCurve;
        this.leftDiameter = leftDiameter;
        this.rightQty = rightQty;
        this.rightPower = rightPower;
        this.rightBaseCurve = rightBaseCurve;
        this.rightDiameter = rightDiameter;
        this.price = price;
        this.image = image;
    }



    // Get all manufacturers in the database that are items
    public static List<string> GetAllManufacturer()
    {
        con = new SqlConnection(ConfigurationManager.ConnectionStrings[dbConnStr].ConnectionString);
        cmd = new SqlCommand();
        cmd.CommandText = "SELECT DISTINCT manufacturer FROM ContactLenses ORDER BY manufacturer";
        cmd.Connection = con;
        con.Open();
        readRow = cmd.ExecuteReader(CommandBehavior.Default);
        List<string> output = new List<string>();
        while (readRow.Read())
        {
            output.Add(readRow["manufacturer"].ToString());
        }
        readRow.Close();
        con.Close();
        return output;
    }

    // Get all packagings in the database that are contact lenses
    public static List<string> GetAllPackaging()
    {
        con = new SqlConnection(ConfigurationManager.ConnectionStrings[dbConnStr].ConnectionString);
        cmd = new SqlCommand();
        cmd.CommandText = "SELECT DISTINCT packaging FROM ContactLenses";
        cmd.Connection = con;
        con.Open();
        readRow = cmd.ExecuteReader(CommandBehavior.Default);
        List<string> output = new List<string>();
        while (readRow.Read())
        {
            output.Add(readRow["packaging"].ToString());
        }
        readRow.Close();
        con.Close();
        return output;
    }

    // Get the all base curves of the current contact lens
    public static string GetBaseCurves(string id)
    {
        con = new SqlConnection(ConfigurationManager.ConnectionStrings[dbConnStr].ConnectionString);
        cmd = new SqlCommand();
        cmd.Parameters.AddWithValue("@contactLensID", id);
        cmd.CommandText = "SELECT baseCurve FROM ContactLenses WHERE contactLensID = @contactLensID";
        cmd.Connection = con;
        con.Open();
        readRow = cmd.ExecuteReader(CommandBehavior.Default);
        string output = "";
        while (readRow.Read())
        {
            output = readRow["baseCurve"].ToString();
        }
        readRow.Close();
        con.Close();
        return output;
    }

    // Get the diameter of the current contact lens
    public static string GetContactDiameter(string id)
    {
        con = new SqlConnection(ConfigurationManager.ConnectionStrings[dbConnStr].ConnectionString);
        cmd = new SqlCommand();
        cmd.Parameters.AddWithValue("@contactLensID", id);
        cmd.CommandText = "SELECT diameter FROM ContactLenses WHERE contactLensID = @contactLensID";
        cmd.Connection = con;
        con.Open();
        readRow = cmd.ExecuteReader(CommandBehavior.Default);
        string output = "";
        while (readRow.Read())
        {
            output = readRow["diameter"].ToString();
        }
        readRow.Close();
        con.Close();
        return output;
    }

    // Get the image of the current contact lens
    public static string GetContactImage(string id)
    {
        con = new SqlConnection(ConfigurationManager.ConnectionStrings[dbConnStr].ConnectionString);
        cmd = new SqlCommand();
        cmd.Parameters.AddWithValue("@contactLensID", id);
        cmd.CommandText = "SELECT image FROM ContactLenses WHERE contactLensID = @contactLensID";
        cmd.Connection = con;
        con.Open();
        readRow = cmd.ExecuteReader(CommandBehavior.Default);
        string output = "";
        while (readRow.Read())
        {
            output = readRow["image"].ToString();
        }
        readRow.Close();
        con.Close();
        return output;
    }

    // Get the name of the current contact lens
    public static string GetContactName(string id)
    {
        con = new SqlConnection(ConfigurationManager.ConnectionStrings[dbConnStr].ConnectionString);
        cmd = new SqlCommand();
        cmd.Parameters.AddWithValue("@contactLensID", id);
        cmd.CommandText = "SELECT name FROM ContactLenses WHERE contactLensID = @contactLensID";
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

    // Get the price of the current contact lens
    public static string GetContactPrice(string id)
    {
        con = new SqlConnection(ConfigurationManager.ConnectionStrings[dbConnStr].ConnectionString);
        cmd = new SqlCommand();
        cmd.Parameters.AddWithValue("@contactLensID", id);
        cmd.CommandText = "SELECT price FROM ContactLenses WHERE contactLensID = @contactLensID";
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

    // Get the power max of the current contact lens
    public static string GetPowerMax(string id)
    {
        con = new SqlConnection(ConfigurationManager.ConnectionStrings[dbConnStr].ConnectionString);
        cmd = new SqlCommand();
        cmd.Parameters.AddWithValue("@contactLensID", id);
        cmd.CommandText = "SELECT powerMax FROM ContactLenses WHERE contactLensID = @contactLensID";
        cmd.Connection = con;
        con.Open();
        readRow = cmd.ExecuteReader(CommandBehavior.Default);
        string output = "";
        while (readRow.Read())
        {
            output = readRow["powerMax"].ToString();
        }
        readRow.Close();
        con.Close();
        return output;
    }

    // Get the power min of the current contact lens
    public static string GetPowerMin(string id)
    {
        con = new SqlConnection(ConfigurationManager.ConnectionStrings[dbConnStr].ConnectionString);
        cmd = new SqlCommand();
        cmd.Parameters.AddWithValue("@contactLensID", id);
        cmd.CommandText = "SELECT powerMin FROM ContactLenses WHERE contactLensID = @contactLensID";
        cmd.Connection = con;
        con.Open();
        readRow = cmd.ExecuteReader(CommandBehavior.Default);
        string output = "";
        while (readRow.Read())
        {
            output = readRow["powerMin"].ToString();
        }
        readRow.Close();
        con.Close();
        return output;
    }

    // Decrement the current contact lens inventory by the specified qty
    public static void DecrementInventory(string contactLensID, int qty)
    {
        con = new SqlConnection(ConfigurationManager.ConnectionStrings[dbConnStr].ConnectionString);
        con.Open();
        query = "UPDATE ContactLenses SET stock = stock - @qty WHERE contactLensID = @contactLensID";
        cmd = new SqlCommand(query, con);
        cmd.Parameters.AddWithValue("@contactLensID", contactLensID);
        cmd.Parameters.AddWithValue("@qty", qty);
        cmd.ExecuteNonQuery();
        con.Close();
    }

    // Check the current contact lens inventory
    public static string CheckQty(string contactLensID)
    {
        con = new SqlConnection(ConfigurationManager.ConnectionStrings[dbConnStr].ConnectionString);
        cmd = new SqlCommand();
        cmd.Parameters.AddWithValue("@contactLensID", contactLensID);
        cmd.CommandText = "SELECT stock FROM ContactLenses WHERE contactLensID = @contactLensID";
        cmd.Connection = con;
        con.Open();
        readRow = cmd.ExecuteReader(CommandBehavior.Default);
        string output = "";
        while (readRow.Read())
        {
            output = readRow["stock"].ToString();
        }
        readRow.Close();
        con.Close();
        return output;
    }
}