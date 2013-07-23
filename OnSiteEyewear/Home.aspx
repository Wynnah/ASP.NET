<%@ Page Title="On-Site Eyewear - Get your perfect fit" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Home.aspx.cs" Inherits="_Home" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">

<script type="text/javascript" src="js/jquery.localscroll.js"></script>
<script type="text/javascript" src="js/jquery.scrollTo.js"></script>
<script type="text/javascript" src="js/scripts.js"></script>

</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">   	
<div class="content" align="center">  
    <div id="slideshow">
	    <ul>
            
		    <li id="fotd1"><a href="<%# Page.ResolveUrl("~") %>ContactLenses.aspx?usage=all"><img src="Images/fotd1.jpg" alt="fotd1"></a></li>
		    <li id="fotd2"><a href="<%# Page.ResolveUrl("~") %>Product/Sunglass.aspx?id=6"><img src="Images/fotd2.jpg" alt="fotd2"></a></li>
		    <li id="fotd3"><a href="<%# Page.ResolveUrl("~") %>Sunglasses.aspx?gender=all"><img src="Images/fotd3.jpg" alt="fotd3"></a></li>
	    </ul>
    </div>
    <div id="slideshow-nav">
	    <ul>
		    <li><a href="#fotd1">Click to see feature of the day - 1</a></li>
		    <li><a href="#fotd2">>Click to see feature of the day - 2</a></li>
		    <li><a href="#fotd3">>Click to see feature of the day - 3</a></li>
	    </ul>
    </div>
</div>
</asp:Content>
