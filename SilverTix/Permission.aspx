<%@ Page Language="C#" MasterPageFile="~/SilverTixHome.master" AutoEventWireup="true"
    CodeFile="Permission.aspx.cs" Inherits="_Permission" Title="Permission?" %>

<asp:Content ID="cphHeadPermission" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>
<asp:Content ID="cphMainPermission" ContentPlaceHolderID="cphMain" runat="Server">
    <table>
        <tr>
            <td>
                <h1>
                    Permission</h1>
                <div>
                    Sorry, you are not authorized to view that section page.
                    <br />
                    <br />
                    <asp:Button ID="btnGoBack" runat="server" Text="Go Back" Width="72px" />
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
