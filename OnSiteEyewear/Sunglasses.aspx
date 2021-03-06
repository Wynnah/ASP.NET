﻿<%@ Page Title="Sunglasses @ OnSiteEyewear.ca" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Sunglasses.aspx.cs" Inherits="Sunglasses_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<asp:ScriptManager ID="ScriptManager1" runat="server" />
    <div class="catalogSearch">
        <span>Sort&nbsp;By:</span>
        <asp:DropDownList ID="ddlSortBy" runat="server" AutoPostBack="true" 
                OnSelectedIndexChanged="ddlSortBy_OnSelectedIndexChanged">
            <asp:ListItem Value="0" Text="Featured Products"></asp:ListItem>
            <asp:ListItem Value="1" Text="Alphabetical: A-Z"></asp:ListItem>
            <asp:ListItem Value="2" Text="Alphabetical: Z-A"></asp:ListItem>
            <asp:ListItem Value="3" Text="Price: High to Low"></asp:ListItem>
            <asp:ListItem Value="4" Text="Price: Low to High"></asp:ListItem>
        </asp:DropDownList>
        <h2>Search</h2>
        <asp:Label ID="genderLbl" runat="server" Text="Gender"></asp:Label>
        <asp:CheckBoxList ID="cblGender" runat="server" AutoPostBack="true"
                OnSelectedIndexChanged="cbl_OnSelectedIndexChanged">
            <asp:ListItem Value="M" Text="Men"></asp:ListItem>
            <asp:ListItem Value="F" Text="Women"></asp:ListItem>
            <asp:ListItem Value="C" Text="Children"></asp:ListItem>
        </asp:CheckBoxList>
        <br />
        Material
        <br />
        <asp:CheckBoxList ID="cblMaterial" runat="server" AutoPostBack="true" 
                OnSelectedIndexChanged="cbl_OnSelectedIndexChanged" />
        <br />
        Frame Shape
        <br />
        <asp:CheckBoxList ID="cblFrameShape" runat="server" AutoPostBack="true" 
                OnSelectedIndexChanged="cbl_OnSelectedIndexChanged" />
        <br />
        Colour
        <br />
        <asp:CheckBoxList ID="cblColour" runat="server" AutoPostBack="true" 
                OnSelectedIndexChanged="cbl_OnSelectedIndexChanged" /> 
    </div>
    <asp:UpdatePanel ID="Panel1" runat="server">
    <ContentTemplate>
    <asp:ListView ID="lvSunglasses" runat="server" GroupItemCount="3" OnPagePropertiesChanging="dpNextPrevious_PagePropertiesChanging">
        <EmptyDataTemplate>
            <div class="catalog">
                <div class="catalogController" >
                    <div class="catalogBtnViewAll">
                        <asp:Button ID="btnViewAll1" runat="server" Text="View All" OnClick="btnViewAll_Click" />
                    </div>
                    <div class="catalogDataPager">
                       
                    </div>
                </div>
                <div class="fullSize" style="margin: 20px 0px;">
                    There are no frames for this catalog.
                </div>
                <div class="catalogController" style="float: right;">
                    <div class="catalogBtnViewAll">
                        <asp:Button ID="btnViewAll2" runat="server" Text="View All" OnClick="btnViewAll_Click" />
                    </div>
                    <div class="catalogDataPager">
                        
                    </div>
                </div>
            </div>
        </EmptyDataTemplate>
        <GroupTemplate>
            <div ID="itemPlaceholderContainer" runat="server">
                <div ID="itemPlaceholder" runat="server" >
                </div>
            </div>
        </GroupTemplate>
        <ItemTemplate>
            <div class="catalogForEachItemSize">
                <asp:HyperLink ID="hlCatalogItemHeader" runat="server" SkinID="skinHyperLinkCatalogItemHeader" 
                    NavigateUrl='<%#Eval("glassesID", "~/Product/Sunglass.aspx?id={0}")  %>'>
                <div class="catalogItemName">
                    <%#Eval("name") %>
                </div>
                <div class="catalogPicture">
                    <img style="width: 150px; height: 75px" src='<%# Eval("image1", "Images/Sunglasses/{0}") %>' alt=""/>
                </div>
                <div class="catalogDetails">
                    Gender:&nbsp;<asp:Label ID="lblGendar" runat="server" Text='<%# Eval("gender") %>' /><br />
                    Color:&nbsp;<asp:Label ID="lblColor" runat="server" Text='<%# Eval("color") %>' /> <br />
                        Price:&nbsp;<asp:Label ID="lblPrice" runat="server" Text='<%# Eval("price", "{0:c}") %>' />
                    </div>
                <div class="catalogButton">
                    <asp:Button ID="btnDetails" runat="server" Text="Details"  
                                PostBackUrl='<%#Eval("glassesID", "~/Product/Sunglass.aspx?id={0}")  %>'></asp:Button>
                </div>
                </asp:HyperLink>
            </div>
        </ItemTemplate>
        <LayoutTemplate>
            <div id="groupPlaceholderContainer" class="catalog">
                <div class="catalogController" >
                    <div class="catalogBtnViewAll">
                        <asp:Button ID="btnViewAll1" runat="server" Text="View All" OnClick="btnViewAll_Click" />
                    </div>
                    <div class="catalogDataPager">
                        <asp:DataPager ID="dpNextPrevious1" runat="server" PagedControlID="lvSunglasses" PageSize="9">
                            <Fields>
                                <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="true" 
                                    ShowNextPageButton="false" ShowPreviousPageButton="false"
                                    FirstPageText="&lt;&lt;" />
                                <asp:NumericPagerField />
                                <asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="true" 
                                    ShowNextPageButton="false" ShowPreviousPageButton="false"
                                    LastPageText="&gt;&gt;" />
                            </Fields>
                        </asp:DataPager>
                    </div>
                 </div>
                <div id="groupPlaceholder" runat="server">
                </div>
                <div class="catalogController" style="float: right;">
                    <div class="catalogBtnViewAll">
                        <asp:Button ID="btnViewAll2" runat="server" Text="View All" OnClick="btnViewAll_Click" />
                    </div>
                    <div class="catalogDataPager">
                        <asp:DataPager ID="dpNextPrevious2" runat="server" PagedControlID="lvSunglasses" PageSize="9">
                        <Fields>
                            <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="true" 
                                ShowNextPageButton="false" ShowPreviousPageButton="false"
                                FirstPageText="&lt;&lt;" />
                            <asp:NumericPagerField />
                            <asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="true" 
                                ShowNextPageButton="false" ShowPreviousPageButton="false"
                                LastPageText="&gt;&gt;" />
                        </Fields>
                    </asp:DataPager>
                    </div>
                </div>
            </div>
        </LayoutTemplate>
    </asp:ListView>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="ddlSortBy" EventName="SelectedIndexChanged" />
        <asp:AsyncPostBackTrigger ControlID="cblGender" EventName="SelectedIndexChanged" />
        <asp:AsyncPostBackTrigger ControlID="cblMaterial" EventName="SelectedIndexChanged" />
        <asp:AsyncPostBackTrigger ControlID="cblFrameShape" EventName="SelectedIndexChanged" />
        <asp:AsyncPostBackTrigger ControlID="cblColour" EventName="SelectedIndexChanged" />
    </Triggers>
    </asp:UpdatePanel>
    <script type="text/javascript">
        function querySt(ji) {
            hu = window.location.search.substring(1);
            gy = hu.split("&");
            for (i = 0; i < gy.length; i++) {
                ft = gy[i].split("=");
                if (ft[0] == ji) {
                    return ft[1];
                }
            }
        }
        if (querySt("gender") == "M") {
            document.getElementById("ctl00_MainContent_cblGender_0").checked = "checked";
        }
        else if (querySt("gender") == "F") {
            document.getElementById("ctl00_MainContent_cblGender_1").checked = "checked";
        }
        else if (querySt("gender") == "C") {
            document.getElementById("ctl00_MainContent_cblGender_2").checked = "checked";
        }
    </script>
</asp:Content>

