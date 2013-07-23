using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;

public partial class SilverTixHome : System.Web.UI.MasterPage
{
    private Boolean boolCheck;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.User.Identity.IsAuthenticated)
        {
            MembershipUser authUser = Membership.GetUser(HttpContext.Current.User.Identity.Name);
            string getUserNameNow = authUser.UserName;
            System.DateTime lastActivyDate = authUser.LastActivityDate;
            Label currentUserName = (Label)lvLogin.FindControl("lblLoggedUser");
            Label lastActivity = (Label)lvLogin.FindControl("lblLastActive");
            currentUserName.Text = getUserNameNow;
            lastActivity.Text = lastActivyDate.ToString("MMM-dd-yyyy HH:mm tt");
            if (!Page.IsPostBack)
            {
                if (HttpContext.Current.User.Identity.IsAuthenticated && !string.IsNullOrEmpty(Request.QueryString["ReturnUrl"]))
                {
                    Response.Redirect(Request.RawUrl);
                }
            }
        }
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Login.aspx?ReturnUrl=" + Request.UrlReferrer.ToString());
    }
    
    protected void btnSignOut_Click(object sender, EventArgs e)
    {
        FormsAuthentication.SignOut();
        Response.Redirect(Request.RawUrl);
    }
}
