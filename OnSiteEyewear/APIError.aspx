<%@ Page Title="Error Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="APIError.aspx.cs" Inherits="APIError" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<br />
<table class="api">
    <tr>
	    <td class="field" />
	    <td><asp:Label ID="lblError" runat="server"></asp:Label></td>
    </tr>
    <tr>
	    <td class="field" />
	    <td><asp:Label ID="lblDesc" runat="server"></asp:Label></td>
    </tr>
    <tr>
	    <td class="field" />
	    <td><asp:Label ID="lblDesc2" runat="server"></asp:Label></td>
    </tr>
    <tr>
	    <td class="field" />
	    <td><asp:Label ID="lblStockError" runat="server"></asp:Label></td>
    </tr>
</table>
</asp:Content>
