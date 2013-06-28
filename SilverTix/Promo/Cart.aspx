<%@ Page Language="C#" MasterPageFile="~/SilverTixHome.master" AutoEventWireup="true"
    CodeFile="Cart.aspx.cs" Inherits="_Cart" Title="Shopping Cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="Server">
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
</asp:Content>
