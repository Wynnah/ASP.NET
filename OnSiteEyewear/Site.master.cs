using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

public partial class SiteMaster : System.Web.UI.MasterPage
{
    private List<Items> shoppingList;
    private string index;

    protected void Page_Load(object sender, EventArgs e)
    {
        // Evaluates all the databinding expression(s) (Ex. <%# ... %>)
        Page.Header.DataBind();

        Page.MaintainScrollPositionOnPostBack = true;

        if (Session["shoppingCart"] != null)
        {
            shoppingList = (List<Items>)Session["shoppingCart"];
            index = shoppingList.Count.ToString();
            lblCartItem.Text = index;
        }
    }
}
