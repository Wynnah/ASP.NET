﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class ReadyReaders : System.Web.UI.Page
{
    private bool _run = false;
    private DataPager dpNextPrevious1;
    private DataPager dpNextPrevious2;
    private int MyPageSize = 9;
    private Button btnViewAll1;
    private Button btnViewAll2;

    private static SqlConnection con = null;
    private static string dbConnStr = "eyewearDBConnectionString";
    private static SqlCommand cmd = null;
    private static SqlDataAdapter dataAdapter = null;
    private static DataTable dataTable = null;
    private static DataView dataView = null;
    private static List<string> listColors = new List<string>();
    private static List<string> newListColors = new List<string>();

    protected void Page_Load(object sender, EventArgs e)
    {
        // Find the datapager's and btnViewAll's ID in the ListView
        dpNextPrevious1 = (DataPager)lvReadyReaders.FindControl("dpNextPrevious1");
        dpNextPrevious2 = (DataPager)lvReadyReaders.FindControl("dpNextPrevious2");
        btnViewAll1 = (Button)lvReadyReaders.FindControl("btnViewAll1");
        btnViewAll2 = (Button)lvReadyReaders.FindControl("btnViewAll2");
        if (!IsPostBack)
        {
            ViewState["cblGender"] = "";

            if (Request.QueryString["gender"] == null)
            {
                Response.Redirect("~/ReadyReaders.aspx?gender=all");
            }
            if (Request.QueryString["gender"] == "M")
            {
                ViewState["cblGender"] = "M";
            }
            else if (Request.QueryString["gender"] == "F")
            {
                ViewState["cblGender"] = "F";
            }

            // Set default values
            ViewState["cblColour"] = "";
            ViewState["sortExpression"] = "glassesID";
            ViewState["sortOrder"] = "desc";

            List<string> getColour = Frames.GetAllReadersColour();
            foreach (string c in getColour)
            {
                if (c.Contains("/"))
                {
                    string[] lc = c.Split('/');
                    foreach (string l in lc)
                    {
                        listColors.Add(l);
                    }
                }
                else
                {
                    listColors.Add(c);
                }
            }
            foreach (string c in listColors)
            {
                if (!newListColors.Contains(c))
                {
                    newListColors.Add(c);
                }
            }
            foreach (string c in newListColors)
            {
                cblColour.Items.Add(new ListItem(c, c));
            }

            // Grab all reporting information from the database
            getReportInfo(gender, color, sortExpression, sortOrder);
        }
    }

    protected bool Run
    {
        get { return this._run; }
        set { this._run = value; }
    }

    protected void dpNextPrevious_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
    {
        int startRow = e.StartRowIndex;

        if (this.Run)
        {
            // Reset the start row so all rows are returned.  This is needed when the user
            // clicks on view all records.
            startRow = 0;
        }
        // Re-bind
        dpNextPrevious1.SetPageProperties(startRow, e.MaximumRows, false);
        dpNextPrevious2.SetPageProperties(startRow, e.MaximumRows, false);

        con = new SqlConnection(ConfigurationManager.ConnectionStrings[dbConnStr].ConnectionString);
        con.Open();

        dataView = new DataView();

        dataView = reportTable.DefaultView;
        dataView.Sort = string.Format("{0} {1}", sortExpression, sortOrder);

        con.Close();

        lvReadyReaders.DataSource = dataView;
        lvReadyReaders.DataBind();

        ViewState["dataTable"] = reportTable;
    }

    protected void btnViewAll_Click(object sender, EventArgs e)
    {
        if (dpNextPrevious1.PageSize == MyPageSize & dpNextPrevious2.PageSize == MyPageSize)
        {
            dpNextPrevious1.SetPageProperties(0, dpNextPrevious1.TotalRowCount, true);
            dpNextPrevious2.SetPageProperties(0, dpNextPrevious2.TotalRowCount, true);
            btnViewAll1.Text = "View Pages";
            btnViewAll2.Text = "View Pages";
        }
        else
        {
            dpNextPrevious1.PageSize = MyPageSize;
            dpNextPrevious2.PageSize = MyPageSize;
            btnViewAll1.Text = "View All";
            btnViewAll2.Text = "View All";
        }
    }

    // Grabs the information from the database
    protected void getReportInfo(string gender, string color, string sortExpression, string sortOrder)
    {
        gender = formatSqlCmdData("gender", gender);
        color = formatSqlCmdData("color", color);

        con = new SqlConnection(ConfigurationManager.ConnectionStrings[dbConnStr].ConnectionString);
        cmd = new SqlCommand("SELECT * FROM Glasses WHERE isASunglass = 'n' AND isAReadyReader = 'y' "
                                + "AND gender NOT LIKE '%C%' "
                                + "AND " + gender + " AND " + color + " "
                                + "AND inventory > 0");

        dataAdapter = new SqlDataAdapter();
        dataTable = new DataTable();

        cmd.CommandType = CommandType.Text;
        cmd.Connection = con;
        dataAdapter.SelectCommand = cmd;

        con.Open();
        dataAdapter.Fill(dataTable);
        dataView = new DataView();

        ViewState["dataTable"] = dataTable;

        dataView = reportTable.DefaultView;
        dataView.Sort = string.Format("{0} {1}", sortExpression, sortOrder);

        con.Close();

        lvReadyReaders.DataSource = dataView;
        lvReadyReaders.DataBind();
    }

    protected void ddlSortBy_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList ddl = new DropDownList();
        ddl = (DropDownList)sender;

        if (ddl.SelectedIndex == 0)
        {
            ViewState["sortExpression"] = "glassesID";
            ViewState["sortOrder"] = "desc";
        }
        else if (ddl.SelectedIndex == 1)
        {
            ViewState["sortExpression"] = "name";
            ViewState["sortOrder"] = "asc";
        }
        else if (ddl.SelectedIndex == 2)
        {
            ViewState["sortExpression"] = "name";
            ViewState["sortOrder"] = "desc";
        }
        else if (ddl.SelectedIndex == 3)
        {
            ViewState["sortExpression"] = "price";
            ViewState["sortOrder"] = "desc";
        }
        else if (ddl.SelectedIndex == 4)
        {
            ViewState["sortExpression"] = "price";
            ViewState["sortOrder"] = "asc";
        }

        // Grab all reporting information from the database
        getReportInfo(gender, color, sortExpression, sortOrder);
    }

    protected void cbl_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        int count = 0;
        string newValue = "";

        CheckBoxList cbl = new CheckBoxList();
        cbl = (CheckBoxList)sender;

        // Loop through checkBoxList to grab selected items values
        foreach (ListItem aListItem in cbl.Items)
        {
            if (aListItem.Selected)
            {
                if (count <= 0)
                    newValue += aListItem.Value;
                else
                    newValue += "," + aListItem.Value;

                count++;
            }
        }

        ViewState[cbl.ID] = newValue;

        // Grab all reporting information from the database
        getReportInfo(gender, color, sortExpression, sortOrder);
    }

    protected string formatSqlCmdData(string column, string value)
    {
        int count = 0;

        if (value.Contains(","))
        {
            string formatData = "";
            string[] listData = value.Split(',');
            foreach (string g in listData)
            {
                if (count <= 0)
                    formatData += column + " LIKE '%" + g + "%'";
                else
                    formatData += " OR " + column + " LIKE '%" + g + "%'";
                count++;
            }
            value = "(" + formatData + ")";
            count = 0;
        }
        else if (value.Length <= 0)
        {
            if (column == "gender")
                value = "(gender LIKE '%M%' OR gender LIKE '%F%' OR gender LIKE '%C%')";
            else
                value = "(" + column + " LIKE '%')";
        }
        else
        {
            value = "(" + column + " LIKE '%" + value + "%')";
        }

        return value;
    }

    // Data Table Entity
    public DataTable reportTable
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

    // Gender Entity
    public string gender
    {
        get
        {
            return ViewState["cblGender"].ToString();
        }
        set
        {
            ViewState["cblGender"] = value;
        }
    }

    // Color Entity
    public string color
    {
        get
        {
            return ViewState["cblColour"].ToString();
        }
        set
        {
            ViewState["cblColour"] = value;
        }
    }

    // Sort Expression Entity
    public string sortExpression
    {
        get
        {
            return ViewState["sortExpression"].ToString();
        }
        set
        {
            ViewState["sortExpression"] = value;
        }
    }

    // Sort Order Entity
    public string sortOrder
    {
        get
        {
            return ViewState["sortOrder"].ToString();
        }
        set
        {
            ViewState["sortOrder"] = value;
        }
    }
}