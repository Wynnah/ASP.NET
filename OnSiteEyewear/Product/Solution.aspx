<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Solution.aspx.cs" Inherits="Product_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<asp:FormView ID="fvSpecificSolutions" runat="server" DataKeyNames="itemID"
        DataSourceID="sdsSpecificSolutions" Width="100%">
        <EmptyDataTemplate>
            <table class="fullSize" runat="server">
                <tr>
                    <td>Sorry, there is currently no more of these contact lens solution.</td>
                </tr>
            </table>
        </EmptyDataTemplate>
        <ItemTemplate>
            <table class="fullSize">
                <tr>
                    <td class="tdSpecificCatalog" runat="server">
                    <table class="fullSize">
                            <tr>
                                <td class="tdSpecificCatalogMainPicture" colspan="3"><br />
                                    <img src='<%# Page.ResolveUrl("~") + "Images/Solutions/" + Eval("image") %>' alt="" />
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
                                            <td class="tdSpecificCatalogFrameSizeText">
                                                <span class="bold">Parameters:&nbsp;</span>
                                            </td>
                                            <td class="tdSpecificCatalogFrameSizeText">
                                                <asp:Label ID="lblGender" runat="server" Text='<%# Eval("parameters") %>' />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="tdSpecificCatalogFrameSizeText">
                                                <span class="bold">Packaging:&nbsp;</span>
                                            </td>
                                            <td class="tdSpecificCatalogFrameSizeText">
                                                <asp:Label ID="lblMaterial" runat="server" Text='<%# Eval("packaging") %>' />
                                            </td>
                                        </tr>
                                        <tr>
                                            <th class="alignLeftFullSize" style="padding-top: 15px" colspan="2">
                                                <span>ENTER YOUR QUANITY:</span>
                                            </th>
                                        </tr>
                                        <tr>
                                            <td class="fullSize" colspan="2">
                                                <span>Quantity:&nbsp;</span>
                                                <asp:TextBox ID="txtQuantity" runat="server" Width="30px" MaxLength="2"></asp:TextBox>
                                                <asp:CustomValidator ID="cvQuantity" runat="server" OnServerValidate="qtyValidate" ControlToValidate="txtQuantity"
                                                    CssClass="vldRedColor" ErrorMessage="You must enter a quantity between 1 to 15." Display="Dynamic">*</asp:CustomValidator>
                                                <asp:RequiredFieldValidator ID="rfvTxtQuantity" CssClass="vldRedColor" runat="server" 
                                                    ControlToValidate="txtQuantity"
                                                    ErrorMessage="You must enter a quantity." Display="Dynamic">*
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
    <asp:SqlDataSource ID="sdsSpecificSolutions" runat="server" 
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
                    CausesValidation="true" OnClick="btnAddToCart_Click" OnClientClick="window.scrollTo = function(x,y) { return true; };" />
            </td>
        </tr>
    </table>
</asp:Content>

