<%@ Page Language="C#" MasterPageFile="~/SilverTixHome.master" AutoEventWireup="true"
    CodeFile="Authenticate.aspx.cs" Inherits="_Authenticate" Title="Authenticate Yourself" %>

<asp:Content ID="cphHeadAuthorize" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>
<asp:Content ID="cphMainAuthorize" ContentPlaceHolderID="cphMain" runat="Server">
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
</asp:Content>
