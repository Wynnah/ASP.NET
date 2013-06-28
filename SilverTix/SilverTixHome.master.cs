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
<<<<<<< HEAD
            
=======
>>>>>>> 20f298e21303c6c9856bd96520d678b2c4443aab
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
<<<<<<< HEAD

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Login.aspx?ReturnUrl=" + Request.UrlReferrer.ToString());
    }
    
=======
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        TextBox txtUserName = (TextBox)lvLogin.FindControl("txtUserName");
        TextBox txtPassword = (TextBox)lvLogin.FindControl("txtPassword");
        CheckBox ckRememberMe = (CheckBox)lvLogin.FindControl("ckRememberMe");
        CustomValidator cvInvalidLogin = (CustomValidator)lvLogin.FindControl("cvInvalidLogin");
        bool validUser;
        validUser = Membership.ValidateUser(txtUserName.Text, txtPassword.Text);
        if (validUser == false)
        {
            cvInvalidLogin.IsValid = false;
        }
        else
        {
            // Creates Authenticated Ticket and determine if chkRememberMe is true or false
            createAuthenticatedTicket();
            Response.Redirect(Request.RawUrl);
        }
    }

>>>>>>> 20f298e21303c6c9856bd96520d678b2c4443aab
    protected void btnSignOut_Click(object sender, EventArgs e)
    {
        FormsAuthentication.SignOut();
        Response.Redirect(Request.RawUrl);
    }
<<<<<<< HEAD
=======

    protected void btnRegister_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Register.aspx");
    }

    protected Boolean GetCheck()
    {
        CheckBox boolPermCookie = (CheckBox)lvLogin.FindControl("ckRememberMe");
        if (Session["RememberMe"] == null)
        {
            Session.Add("RememberMe", boolCheck);
            boolCheck = new Boolean();
            boolCheck = boolPermCookie.Checked;
            Session["RememberMe"] = boolCheck;
        }
        return (Boolean)Session["RememberMe"];
    }

    protected void createAuthenticatedTicket()
    {
        TextBox txtUserName = (TextBox)lvLogin.FindControl("txtUserName");
        TextBox txtPassword = (TextBox)lvLogin.FindControl("txtPassword");
        bool isAuthenticated = IsAuthenticated(txtUserName.Text, txtPassword.Text);
        if (isAuthenticated == true)
        {
            string roles = GetRoles(txtUserName.Text);
            FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket
                (1,                          //  version
                 txtUserName.Text,           // user name
                 DateTime.Now,               // creation
                 DateTime.Now.AddMinutes(60),// Expiration
                 true,                       // Persistent
                 roles);                     // User data
            // Now encrypt the ticket.
            string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
            // Create a cookie and add the encrypted ticket to the cookie as data.
            HttpCookie AuthCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
            // Add the cookie to the outgoing cookies collection.
            Response.Cookies.Add(AuthCookie);
            FormsAuthentication.SetAuthCookie(txtUserName.Text, this.GetCheck());
        }
    }

    protected bool IsAuthenticated(string username, string password)
    {
        // Lookup code omitted for clarity
        // This code would typically validate the user name and password
        // combination against a SQL database or Active Directory
        // Simulate an authenticated user
        return true;
    }

    protected string GetRoles(string username)
    {
        // Lookup code omitted for clarity
        // This code would typically look up the role list from a database
        // table.
        // If the user was being authenticated against Active Directory,
        // the Security groups and/or distribution lists that the user
        // belongs to may be used instead

        // This GetRoles method returns a pipe delimited string containing
        // roles rather than returning an array, because the string format
        // is convenient for storing in the authentication ticket /
        // cookie, as user data
        return "Admin|Moderator|Customer";
    }
>>>>>>> 20f298e21303c6c9856bd96520d678b2c4443aab
}
