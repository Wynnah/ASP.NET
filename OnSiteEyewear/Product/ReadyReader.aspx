<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ReadyReader.aspx.cs" Inherits="ReadyReader" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:FormView ID="fvSpecificReadyReader" runat="server" DataKeyNames="glassesID"
        DataSourceID="sdsSpecificReadyReader" Width="100%">
        <EmptyDataTemplate>
            <table class="fullSize" runat="server">
                <tr>
                    <td>Sorry, there is currently no more of these frame.</td>
                </tr>
            </table>
        </EmptyDataTemplate>
        <ItemTemplate>
            <table class="fullSize" style="padding-left: 30px;">
                <tr>
                    <td class="tdSpecificCatalog" runat="server">
                    <table class="fullSize">
                            <tr>
                                <td class="tdSpecificCatalogMainPicture" colspan="3"><br />
                                    <img src='<%# Page.ResolveUrl("~") + "Images/ReadyReaders/" + Eval("image1") %>' alt="" />
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
                                <td>
                                    <table class="fullSize">
                                        <tr>
                                            <td class="tdSpecificCatalogFrameSizeText" colspan="2">
                                                <span class="bold">Gender:&nbsp;</span>
                                            </td>
                                            <td class="tdSpecificCatalogFrameSizeText" colspan="2">
                                                <asp:Label ID="lblGender" runat="server" Text='<%# Eval("gender") %>' />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="tdSpecificCatalogFrameSizeText" colspan="2">
                                                <span class="bold">Size:&nbsp;</span>
                                            </td>
                                            <td class="tdSpecificCatalogFrameSizeText" colspan="2">
                                                <asp:Label ID="lblLensDiameter" runat="server" Text='<%# Eval("lensDiameter")%>' />mm -
                                                <asp:Label ID="lblBridgeWidth" runat="server" Text='<%# Eval("bridgeWidth")%>' />mm -
                                                <asp:Label ID="lblTempleLength" runat="server" Text='<%# Eval("templeLength")%>' />mm
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="tdSpecificCatalogFrameSizeText2">
                                                <br />
                                                <span>Quantity</span>
                                            </td>
                                            <td class="tdSpecificCatalogFrameSizeText2">
                                                <br />
                                                <span>Power</span>
                                            </td>
                                            <td class="tdSpecificCatalogFrameSizeText2"/>
                                            </td>
                                            <td class="tdSpecificCatalogFrameSizeText2"/>
                                        </tr>
                                        <tr>
                                            <td class="tdSpecificCatalogFrameSizeText2">
                                                <asp:TextBox ID="txtQuantity" runat="server" Width="30px" MaxLength="2"></asp:TextBox>
                                                <asp:CustomValidator ID="cvQuantity" runat="server" OnServerValidate="qtyValidate" ControlToValidate="txtQuantity"
                                                    CssClass="vldRedColor" ErrorMessage="You must enter a quantity between 1 to 15." Display="Dynamic">*</asp:CustomValidator>
                                                <asp:RequiredFieldValidator ID="rfvTxtQuantity" CssClass="vldRedColor" runat="server" 
                                                    ControlToValidate="txtQuantity"
                                                    ErrorMessage="You must enter a quantity." Display="Dynamic">*
                                                </asp:RequiredFieldValidator>
                                            </td>
                                            <td class="tdSpecificCatalogFrameSizeText2">
                                                <asp:DropDownList ID="ddlPower" runat="server">
                                                    <asp:ListItem Value=""></asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="rfvDdlPower" CssClass="vldRedColor" runat="server" 
                                                    ControlToValidate="ddlPower"
                                                    ErrorMessage="You must select a power." Display="Dynamic">*
                                                </asp:RequiredFieldValidator>
                                            </td>
                                            <td class="tdSpecificCatalogFrameSizeText2"/>
                                            <td class="tdSpecificCatalogFrameSizeText2"/>
                                                 
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
    <asp:SqlDataSource ID="sdsSpecificReadyReader" runat="server" 
        ConnectionString="<%$ ConnectionStrings:eyewearDBConnectionString %>" 
        SelectCommand="SELECT * FROM [Glasses] WHERE ([glassesID] = @glassesID)">
        <SelectParameters>
            <asp:QueryStringParameter Name="glassesID" QueryStringField="id"  Type="Int32" />
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
                    CausesValidation="true" OnClick="btnAddToCart_Click" OnClientClick="window.scrollTo = function(x,y) { return true; };"/>
            </td>
        </tr>
    </table>
</asp:Content>

