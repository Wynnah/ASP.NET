using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class ContactLensSolution_Default : System.Web.UI.Page
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
    private static List<string> listParameters = new List<string>();
    private static List<string> newListParameters = new List<string>();
    private static List<string> listPackaging = new List<string>();
    private static List<string> newListPackaging = new List<string>();

    protected void Page_Load(object sender, EventArgs e)
    {
        // Find the datapager's and btnViewAll's ID in the ListView
        dpNextPrevious1 = (DataPager)lvSolutions.FindControl("dpNextPrevious1");
        dpNextPrevious2 = (DataPager)lvSolutions.FindControl("dpNextPrevious2");
        btnViewAll1 = (Button)lvSolutions.FindControl("btnViewAll1");
        btnViewAll2 = (Button)lvSolutions.FindControl("btnViewAll2");

        if (!IsPostBack)
        {
            // Set default values
            ViewState["cblParameters"] = "";
            ViewState["cblPackaging"] = "";
            ViewState["sortExpression"] = "itemID";
            ViewState["sortOrder"] = "desc";

            List<string> getParameters = Frames.GetAllItemsParameters();
            foreach (string p in getParameters)
            {
                if (!listParameters.Contains(p))
                    listParameters.Add(p);
            }
            foreach (string p in listParameters)
            {
                cblParameters.Items.Add(new ListItem(p, p));
            }

            List<string> getPackaging = Frames.GetAllItemsPackaging();
            foreach (string p in getPackaging)
            {
                if (!listPackaging.Contains(p))
                    listPackaging.Add(p);
            }
            foreach (string p in listPackaging)
            {
                cblPackaging.Items.Add(new ListItem(p, p));
            }

            // Grab all reporting information from the database
            getReportInfo(parameter, packaging, sortExpression, sortOrder);
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

        lvSolutions.DataSource = dataView;
        lvSolutions.DataBind();

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
    protected void getReportInfo(string parameter, string packaging, string sortExpression, string sortOrder)
    {
        parameter = formatSqlCmdData("parameters", parameter);
        packaging = formatSqlCmdData("packaging", packaging);

        con = new SqlConnection(ConfigurationManager.ConnectionStrings[dbConnStr].ConnectionString);
        cmd = new SqlCommand("SELECT * FROM Items WHERE parameters IS NOT NULL "
                                + "AND " + parameter + " AND " + packaging + " "
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

        lvSolutions.DataSource = dataView;
        lvSolutions.DataBind();
    }

    protected void ddlSortBy_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList ddl = new DropDownList();
        ddl = (DropDownList)sender;

        if (ddl.SelectedIndex == 0)
        {
            ViewState["sortExpression"] = "itemID";
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
        getReportInfo(parameter, packaging, sortExpression, sortOrder);
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
        getReportInfo(parameter, packaging, sortExpression, sortOrder);
    }

    protected string formatSqlCmdData(string column, string value)
    {
        int count = 0;

        if (value.Contains(","))
        {
            string formatData = "";
            string[] listData = value.Split(',');
            foreach (string ld in listData)
            {
                if (count <= 0)
                    formatData += column + " = '" + ld + "'";
                else
                    formatData += " OR " + column + " = '" + ld + "'";
                count++;
            }
            value = "(" + formatData + ")";
            count = 0;
        }
        else if (value.Length <= 0)
        {
            value = "(" + column + " LIKE '%')";
        }
        else
        {
            value = "(" + column + " = '" + value + "')";
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

    // Shape Entity
    public string parameter
    {
        get
        {
            return ViewState["cblParameters"].ToString();
        }
        set
        {
            ViewState["cblParameters"] = value;
        }
    }

    // Color Entity
    public string packaging
    {
        get
        {
            return ViewState["cblPackaging"].ToString();
        }
        set
        {
            ViewState["cblPackaging"] = value;
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