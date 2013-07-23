<%@ Page Title="Order Review @ OnSiteEyewear.ca" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="OrderReview.aspx.cs" Inherits="OrderReview" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <br />
    <asp:Label ID="lblShippingAddress" runat="server" Text="There are no information regarding your shipping address."></asp:Label>
    <p class="pCheckout">
        <asp:Button ID="btnCheckout" runat="server" Text="CHECKOUT"   Width="125" height="30"
            CausesValidation="true" OnClick="btnCheckout_Click" />
    </p>
    <br />
</asp:Content>

