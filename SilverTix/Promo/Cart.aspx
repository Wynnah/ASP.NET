<%@ Page Language="C#" MasterPageFile="~/SilverTixHome.master" AutoEventWireup="true"
    CodeFile="Cart.aspx.cs" Inherits="_Cart" Title="Shopping Cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="Server">
<<<<<<< HEAD
    <div class="cartWrapper">
        <div class="cartContent">
            <h1>
                Your Cart:
            </h1>
            <asp:Label ID="lblCart" runat="server" Text="There are no information regarding your shipping address.<br />"></asp:Label>
            <br />
            <asp:Button ID="btnGoBack" runat="server" Text="Back" OnClick="btnGoBack_Click" Width="90px" />
            <asp:Button ID="btnCheckout" runat="server" Text="Check Out" OnClick="btnCheckout_Click" Width="90px" />
            <asp:Label ID="lblMessage" runat="server" EnableViewState="False" ForeColor="Red"></asp:Label>
        </div>
    </div>
=======
    <table>
        <tr>
            <td>
                <h1 class="fullHeader">
                    <asp:Label ID="lblCartHeader" runat="server" Text="Your Cart:"></asp:Label>
                </h1>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblCart" runat="server" Text="There are no information regarding your shipping address."></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnCheckout" runat="server" Text="Check Out" OnClick="btnCheckout_Click"
                    Style="margin-right: 35px; float: right;" Width="90px" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblMessage" runat="server" EnableViewState="False" ForeColor="Red"></asp:Label>
                <asp:Label ID="lblCheckOut" runat="server" EnableViewState="False" ForeColor="Red"></asp:Label>
            </td>
        </tr>
    </table>
>>>>>>> 20f298e21303c6c9856bd96520d678b2c4443aab
</asp:Content>
