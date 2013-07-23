<%@ Page Title="Shopping Cart @ OnSiteEyewear.ca" Language="C#" MasterPageFile="~/Site.master" 
        AutoEventWireup="true" CodeFile="View-Cart.aspx.cs" Inherits="ViewCart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<script type="text/javascript">
    
    function shipping(method) {

        var total;
        var subtotal = document.getElementById('subtotal').innerHTML;
        if (method == "fedex") {
            document.getElementById('shipping').innerHTML = "9.95";
            document.getElementById('checkoutLink').href = "expresscheckout.aspx?shipping=9.95";
            total = parseFloat(subtotal) + 9.95;
            document.getElementById('total').innerHTML = total.toFixed(2);
        }
        else if (method == "international") {
            document.getElementById('shipping').innerHTML = "14.95";
            document.getElementById('checkoutLink').href = "expresscheckout.aspx?shipping=14.95";
            total = parseFloat(subtotal) + 14.95;
            document.getElementById('total').innerHTML = total.toFixed(2);
        }

        if(parseFloat(subtotal) > 119) {
            document.getElementById('shipping').innerHTML = "0.00";
            document.getElementById('checkoutLink').href = "expresscheckout.aspx?shipping=0.00";
            total = parseFloat(subtotal);
            document.getElementById('total').innerHTML = total.toFixed(2);
        }
    }

    
</script>
    
<h2>Shopping Cart Details</h2>
<asp:Label ID="tableLbl" runat="server" Text="There are no items in the shopping cart."></asp:Label>
<script type="text/javascript">
    shipping("fedex");
</script>
</asp:Content>

