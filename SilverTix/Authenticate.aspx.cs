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

public partial class _Authenticate : System.Web.UI.Page
{
    // Check if chkRememberMe is true or false
    private Boolean boolCheck;
    protected void Page_Load(object sender, EventArgs e)
    {
        // Redirects user back to previous page when btnGoBack is clicked
<<<<<<< HEAD
        //this.btnGoBack.OnClientClick = "javascript:window.history.go(-1);return false;";
=======
        this.btnGoBack.OnClientClick = "javascript:window.history.go(-1);return false;";
>>>>>>> 20f298e21303c6c9856bd96520d678b2c4443aab
        if (HttpContext.Current.User.Identity.IsAuthenticated)
        {
            MembershipUser authUser = Membership.GetUser(HttpContext.Current.User.Identity.Name);
            string getUserNameNow = authUser.UserName;
            FormsAuthentication.RedirectFromLoginPage(getUserNameNow, this.GetCheck());
        }
    }

    protected Boolean GetCheck()
    {
        boolCheck = (Boolean)Session["RememberMe"];
        return (Boolean)Session["RememberMe"];
    }
}
