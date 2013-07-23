<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Accessory.aspx.cs" 
    Inherits="Product_Default" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
   <asp:HiddenField ID="hfScrollPosition" runat="server" Value="0" />
   <asp:FormView ID="fvSpecificAccessory" runat="server" DataKeyNames="itemID"
        DataSourceID="sdsSpecificAccessory" Width="100%">
        <EmptyDataTemplate>
            <table class="fullSize" runat="server">
                <tr>
                    <td>Sorry, there is currently no more of these accessory.</td>
                </tr>
            </table>
        </EmptyDataTemplate>
        <ItemTemplate>
            <table id="test" class="fullSize">
                <tr>
                    <td class="tdSpecificCatalog" runat="server">
                        <table class="fullSize">
                            <tr>
                                <td class="tdSpecificCatalogMainPicture" colspan="3"><br />
                                    <img src='<%# Page.ResolveUrl("~") + "Images/Accessories/" + Eval("image") %>' alt="" />
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td class="tdSpecificCatalog" runat="server">
                        <table class="fullSize">
                            <tr>
                                <td class="tdSpecificCatalogDetails">
                                    <span style="font-size:15px"><asp:Label ID="lblName" runat="server" Text='<%# Eval("name") %>' SkinID="skinLabelCatalogItemHeader" /></span> 
                                    <br />
                                    <span style="color:Green"><asp:Label ID="lblPrice" runat="server" Text='<%# Eval("price", "{0:c}") %>' SkinID="skinLabelCatalogItemHeader" /></span>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdSpecificCatalogDetails">
                                Description:&nbsp;<asp:Label ID="lblDescription" runat="server" Text='<%# Eval("description") %>' />
                                </td>
                            </tr>
                            <tr>
                                <td class="fullSize">
                                    <table class="fullSize">
                                        <tr>
                                            <th class="alignLeftFullSize" style="padding-top: 15px">
                                                <span>ENTER YOUR QUANITY:</span>
                                            </th>
                                        </tr>
                                        <tr>
                                            <td class="fullSize">
                                                <span>Quantity:&nbsp;</span>
                                                <asp:TextBox ID="txtQuantity" runat="server" Width="30px" MaxLength="2"></asp:TextBox>
                                                <asp:CustomValidator ID="cvQuantity" runat="server" ControlToValidate="txtQuantity"
                                                    CssClass="vldRedColor" ErrorMessage="You must enter a quantity between 1 to 15." Display="Dynamic">*</asp:CustomValidator>
                                                <asp:RequiredFieldValidator ID="rfvTxtQuantity" CssClass="vldRedColor" runat="server" 
                                                    ControlToValidate="txtQuantity" ErrorMessage="You must enter a quantity." 
                                                    Display="Dynamic">*
                                                </asp:RequiredFieldValidator>
                                            </td>   
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:FormView>
    <asp:SqlDataSource ID="sdsSpecificAccessory" runat="server" 
        ConnectionString="<%$ ConnectionStrings:eyewearDBConnectionString %>" 
        SelectCommand="SELECT * FROM [Items] WHERE ([itemID] = @itemID)">
        <SelectParameters>
            <asp:QueryStringParameter Name="itemID" QueryStringField="id"  Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
        <table class="fullSize">
            <tr>
                <td class="tdSpecificCatalog" />
                <td class="tdSpecificCatalog">
                    <asp:ValidationSummary ID="vsQuantity" CssClass="vldRedColor" runat="server"
                        HeaderText="Please correct the following errors:" />
                </td>
            </tr>
            <tr>
                <td class="fullSize" style="text-align: center" colspan="2">
                    <asp:Button ID="btnAddToCart" runat="server" Text="ADD TO CART"   Width="125" height="30"
                        OnClick="btnAddToCart_Click" OnClientClick="window.scrollTo = function(x,y) { return true; };"/>
                </td>
            </tr>
        </table>
</asp:Content>

