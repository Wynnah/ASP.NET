<%@ Page Language="C#" MasterPageFile="~/SilverTixHome.master" AutoEventWireup="true"
    CodeFile="Cart.aspx.cs" Inherits="_Cart" Title="Shopping Cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
    <style type="text/css">
        .style2
        {
            width: 434px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="Server">
    <table>
        <tr>
            <td class="style2">
                <h1>
                    Your Cart:<asp:Label ID="lblTest" runat="server" Text="Label"></asp:Label>
                </h1>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style2">
                <asp:ListBox ID="lbMovieCart" runat="server"></asp:ListBox>
            </td>
            <td>
                <asp:Button ID="btnRemove" runat="server" Text="Remove Item" OnClick="btn_remove_Click"
                    Width="100px" />
                <br />
                <br />
                <asp:Button ID="btnEmpty" runat="server" Text="Empty Cart" OnClick="btn_empty_Click"
                    Width="100px" />
            </td>
        </tr>
        <tr>
            <td class="style2">
                <asp:Button ID="btnGoBack" runat="server" Text="Back to Previous Page" Width="160px"
                    OnClick="btnGoBack_Click" />
            </td>
            <td>
                <asp:Button ID="btnCheckout" runat="server" Text="Check Out" OnClick="btn_checkout_Click"
                    Style="margin-left: 5px" Width="90px" />
            </td>
        </tr>
        <tr>
            <td class="style2">
                <asp:Label ID="lblMessage" runat="server" EnableViewState="False" ForeColor="Red"></asp:Label>
                <asp:Label ID="lblCheckOut" runat="server" EnableViewState="False" ForeColor="Red"></asp:Label>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
