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

public partial class _Login : System.Web.UI.Page
{
    private Boolean boolCheck;

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void cuwSignUp_CreatedUser(object sender, EventArgs e)
    {
        Roles.AddUserToRole(cuwSignUp.UserName, "Customer");
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
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

            // Get the previous page url
            string url = Request.QueryString["ReturnUrl"];

            Response.Redirect(url);
        }
    }

    protected void btnSignOut_Click(object sender, EventArgs e)
    {
        FormsAuthentication.SignOut();
        Response.Redirect(Request.RawUrl);
    }

    protected Boolean GetCheck()
    {
        CheckBox boolPermCookie = ckRememberMe;
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
}
