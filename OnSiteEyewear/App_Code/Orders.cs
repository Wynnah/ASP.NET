using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for Orders
/// </summary>
public class Orders
{
    #region Properties
    private static SqlConnection con = null;
    private static string dbConnStr = "eyewearDBConnectionString";
    private static SqlCommand cmd = null;
    private static string query = "";

    public string orderID { get; set; }
    public string date { get; set; }
    public string status { get; set; }
    public string userID { get; set; }
    public string shippingAddressID { get; set; }
    public string shippingID { get; set; }
    public string subTotal { get; set; }
    public string shippingTotal { get; set; }
    public string taxTotal { get; set; }
    public string grandTotal { get; set; }
    #endregion


    public Orders()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public static void Insert(string userID, string shippingAddressID, string shippingID, string subTotal, string shippingTotal, string taxTotal, string grandTotal)
    {
        con = new SqlConnection(ConfigurationManager.ConnectionStrings[dbConnStr].ConnectionString);
        con.Open();
        query = "INSERT INTO Orders(userID, shippingAddressID, shippingID, subTotal, shippingTotal, taxTotal, grandTotal)" +
        " VALUES(@userID, @shippingAddressID, @shippingID, @subTotal, @shippingTotal, @taxTotal, @grandTotal)";
        cmd = new SqlCommand(query, con);
        cmd.Parameters.AddWithValue("@userID", userID);
        cmd.Parameters.AddWithValue("@shippingAddressID", shippingAddressID);
        cmd.Parameters.AddWithValue("@shippingID", shippingID);
        cmd.Parameters.AddWithValue("@subTotal", subTotal);
        cmd.Parameters.AddWithValue("@shippingTotal", shippingTotal);
        cmd.Parameters.AddWithValue("@taxTotal", taxTotal);
        cmd.Parameters.AddWithValue("@grandTotal", grandTotal);
        cmd.ExecuteNonQuery();
        con.Close();
    }
}