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
/// Summary description for Item
/// </summary>
public class Items
{
    #region Private variables
    private static SqlConnection con = null;
    private static string dbConnStr = "eyewearDBConnectionString";
    private static SqlCommand cmd = null;
    private static SqlDataReader readRow = null;
    private static string query;
    #endregion

    #region Get/set variables
    public string id { get; set; }
    public string name { get; set; }
    public string power { get; set; }
    public int qty { get; set; }
    public double price { get; set; }
    public string image1 { get; set; }
    public double subtotal { get; set; }
    public Frames frame { get; set; }
    public Sunglasses sunglass { get; set; }
    public Solutions solution { get; set; }
    public Accessories accesory { get; set; }
    public Contacts contact { get; set; }
    #endregion

    #region Contructors
    public class ReadyReaders : Items
    {
        public ReadyReaders(string id, string name, int qty, string power, double price, string image1)
        {
            base.SetReadyReaderInfo(id, name, qty, power, price, image1);
        }
    }

    public class Sunglasses : Items
    {
        public Sunglasses(string id, string name, int qty, double price, string image1)
        {
            base.SetInfo(id, name, qty, price, image1);
        }
    }

    public class Solutions : Items
    {
        public Solutions(string id, string name, int qty, double price, string image1)
        {
            base.SetInfo(id, name, qty, price, image1);
        }
    }

    public class Accessories : Items
    {
        public Accessories(string id, string name, int qty, double price, string image1)
        {
            base.SetInfo(id, name, qty, price, image1);
        }
    }

    public Items()
    {
    }

    private void SetInfo(string id, string name, int qty, double price, string image1)
    {
        this.id = id;
        this.name = name;
        this.qty = qty;
        this.price = price;
        this.image1 = image1;
    }

    private void SetReadyReaderInfo(string id, string name, int qty, string power, double price, string image1)
    {
        this.id = id;
        this.name = name;
        this.qty = qty;
        this.power = power;
        this.price = price;
        this.image1 = image1;
    }
    #endregion

    #region Get items SQL statements
    public static string GetItemName(string id)
    {
        con = new SqlConnection(ConfigurationManager.ConnectionStrings[dbConnStr].ConnectionString);
        cmd = new SqlCommand();
        cmd.Parameters.AddWithValue("@itemID", id);
        cmd.CommandText = "SELECT name FROM Items WHERE itemID = @itemID";
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

    // Get the price of the current item
    public static string GetItemPrice(string id)
    {
        con = new SqlConnection(ConfigurationManager.ConnectionStrings[dbConnStr].ConnectionString);
        cmd = new SqlCommand();
        cmd.Parameters.AddWithValue("@itemID", id);
        cmd.CommandText = "SELECT price FROM Items WHERE itemID = @itemID";
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

    // Get the image of the current item
    public static string GetItemImage(string id)
    {
        con = new SqlConnection(ConfigurationManager.ConnectionStrings[dbConnStr].ConnectionString);
        cmd = new SqlCommand();
        cmd.Parameters.AddWithValue("@itemID", id);
        cmd.CommandText = "SELECT image FROM Items WHERE itemID = @itemID";
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

    // Get all manufacturers in the database that are items
    public static List<string> GetAllItemsManufacturer()
    {
        con = new SqlConnection(ConfigurationManager.ConnectionStrings[dbConnStr].ConnectionString);
        cmd = new SqlCommand();
        cmd.CommandText = "SELECT DISTINCT manufacturer FROM Items WHERE manufacturer IS NOT NULL AND parameters IS NULL";
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

    // Get all parameters in the database that are items
    public static List<string> GetAllItemsParameters()
    {
        con = new SqlConnection(ConfigurationManager.ConnectionStrings[dbConnStr].ConnectionString);
        cmd = new SqlCommand();
        cmd.CommandText = "SELECT DISTINCT parameters FROM Items WHERE parameters IS NOT NULL";
        cmd.Connection = con;
        con.Open();
        readRow = cmd.ExecuteReader(CommandBehavior.Default);
        List<string> output = new List<string>();
        while (readRow.Read())
        {
            output.Add(readRow["parameters"].ToString());
        }
        readRow.Close();
        con.Close();
        return output;
    }

    // Get all packaging in the database that are items
    public static List<string> GetAllItemsPackaging()
    {
        con = new SqlConnection(ConfigurationManager.ConnectionStrings[dbConnStr].ConnectionString);
        cmd = new SqlCommand();
        cmd.CommandText = "SELECT DISTINCT packaging FROM Items WHERE parameters IS NOT NULL";
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
    #endregion

    // Decrement the current item inventory by the specified qty
    public void DecrementInventory(string itemID, int qty)
    {
        con = new SqlConnection(ConfigurationManager.ConnectionStrings[dbConnStr].ConnectionString);
        con.Open();
        query = "UPDATE Items SET inventory = inventory - @qty WHERE itemID = @itemID";
        cmd = new SqlCommand(query, con);
        cmd.Parameters.AddWithValue("@itemID", itemID);
        cmd.Parameters.AddWithValue("@qty", qty);
        cmd.ExecuteNonQuery();
        con.Close();
    }

    // Check the current items inventory
    public string CheckQty(string id)
    {
        con = new SqlConnection(ConfigurationManager.ConnectionStrings[dbConnStr].ConnectionString);
        cmd = new SqlCommand();
        cmd.Parameters.AddWithValue("@itemID", id);
        cmd.CommandText = "SELECT inventory FROM Items WHERE itemID = @itemID";
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