<%@ Page Language="C#" MasterPageFile="~/SilverTixHome.master" AutoEventWireup="true"
<<<<<<< HEAD
    CodeFile="Authenticate.aspx.cs" Inherits="_Authenticate" Title="Authentication" %>
=======
    CodeFile="Authenticate.aspx.cs" Inherits="_Authenticate" Title="Authenticate Yourself" %>
>>>>>>> 20f298e21303c6c9856bd96520d678b2c4443aab

<asp:Content ID="cphHeadAuthorize" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>
<asp:Content ID="cphMainAuthorize" ContentPlaceHolderID="cphMain" runat="Server">
<<<<<<< HEAD
    <div class="authenticateWrapper">
        <h1>
            Authenticating Instructions
        </h1>
        <div class="authenticateContent">
            <span>
                Please log in from the top right of our website page.
                If you do not have an account, you can
            </span>
            <asp:HyperLink ID="hlRegister" runat="server" SkinID="skinHyperLinkAuthorize" NavigateUrl="~/Register.aspx">register</asp:HyperLink>
            <span>
                and become a member.
            </span>
            <br />
            <br />
            <asp:Button ID="btnGoBack" runat="server" Text="Go Back" Width="72px" />
        </div>
    </div>
=======
    <table>
        <tr>
            <td>
                <h1>
                    Authenticating Instructions
                </h1>
                <div>
                    Please log in from the top right of our website page. If you do not have an account,
                    you can
                    <asp:HyperLink ID="hlRegister" runat="server" SkinID="skinHyperLinkAuthorize" NavigateUrl="~/Register.aspx">register</asp:HyperLink>
                    and become a member.
                    <br />
                    <br />
                    <asp:Button ID="btnGoBack" runat="server" 
                        Text="Go Back" Width="72px" />
                </div>
            </td>
        </tr>
    </table>
>>>>>>> 20f298e21303c6c9856bd96520d678b2c4443aab
</asp:Content>
