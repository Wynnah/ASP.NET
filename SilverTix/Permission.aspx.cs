using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class _Permission : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Redirects user back to previous page when btnGoBack is clicked
        this.btnGoBack.OnClientClick = "javascript:window.history.go(-1);return false;";
    }
}
