<%@ Page Language="C#" MasterPageFile="~/SilverTixHome.master" AutoEventWireup="true" CodeFile="ForgottenPassword.aspx.cs" Inherits="_ForgottenPassword" Title="Recovering Password" %>

<asp:Content ID="cphHeadForgottenPassword" ContentPlaceHolderID="cphHead" Runat="Server">
</asp:Content>
<asp:Content ID="cphMainForgottenPassword" ContentPlaceHolderID="cphMain" Runat="Server">
    <div class="authenticateWrapper">
        <h1>
            Recover Password
        </h1>
        <div class="authenticateContent">
            <asp:PasswordRecovery ID="prUser" runat="server">
            </asp:PasswordRecovery>
        </div>
    </div>
</asp:Content>

