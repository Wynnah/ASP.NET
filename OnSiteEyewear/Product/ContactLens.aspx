<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ContactLens.aspx.cs" Inherits="ContactLense" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

<asp:FormView ID="fvSpecificContactLens" runat="server" DataKeyNames="contactLensID"
        DataSourceID="sdsSpecificContactLens" Width="100%">
        <EmptyDataTemplate>
            <table class="fullSize" runat="server">
                <tr>
                    <td>Sorry, there is currently no more of these contact lens.</td>
                </tr>
            </table>
        </EmptyDataTemplate>
        <ItemTemplate>
            <table class="fullSize">
                <tr>
                    <td class="tdSpecificCatalog" runat="server">
                    <table class="fullSize">
                            <tr>
                                <td class="tdSpecificCatalogMainPicture"><br />
                                    <img src='<%# Page.ResolveUrl("~") + "Images/Contacts/" + Eval("image") %>' alt="" />
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
                                                <span class="bold">Diameter:&nbsp;</span>
                                            </td>
                                            <td class="tdSpecificCatalogFrameSizeText">
                                                <script type="text/javascript">
                                                    var diameter = '<%# Eval("diameter") %>';
                                                </script>
                                                <asp:Label ID="lblDiameter" runat="server" Text='<%# Eval("diameter") %>' />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="tdSpecificCatalogFrameSizeText">
                                                <span class="bold">Packaging:&nbsp;</span>
                                            </td>
                                            <td class="tdSpecificCatalogFrameSizeText">
                                                <asp:Label ID="lblPackaging" runat="server" Text='<%# Eval("packaging") %>' />
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
    <asp:SqlDataSource ID="sdsSpecificContactLens" runat="server" 
        ConnectionString="<%$ ConnectionStrings:eyewearDBConnectionString %>" 
        SelectCommand="SELECT * FROM [ContactLenses] WHERE ([contactLensID] = @contactLensID)">
        <SelectParameters>
            <asp:QueryStringParameter Name="contactLensID" QueryStringField="id"  Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    <table class="fullSize">
        <tr>
            <td class="fullSize">
                <table class="fullSize">
                    <tr>
                        <td class="tdPrescriptionMeasurement" />
                        <td class="tdPrescriptionMeasurement">
                            Quantity
                        </td>
                        <td class="tdPrescriptionMeasurement">
                            <a href="../Glossary.aspx#power">Power</a>
                        </td>
                        <td class="tdPrescriptionMeasurement">
                            <a href="../Glossary.aspx#baseCurve">BC</a>
                        </td>
                        <td class="tdPrescriptionMeasurement">
                            <a href="../Glossary.aspx#diameter">Diameter</a>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdPrescriptionMeasurement">
                            <span>LEFT:</span> <br />
                            <span>RIGHT:</span>
                        </td>
                        <td class="tdPrescriptionMeasurement">
                            <asp:TextBox ID="txtQuantityLeft" runat="server" Width="30px" MaxLength="2"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvTxtQuantityLeft" CssClass="vldRedColor" runat="server" 
                                ControlToValidate="txtQuantityLeft"
                                ErrorMessage="You must enter a quantity for your left." Display="Dynamic">*
                            </asp:RequiredFieldValidator>
                            <br />
                            <asp:TextBox ID="txtQuantityRight" runat="server" Width="30px" MaxLength="2"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvTxtQuantityRight" CssClass="vldRedColor" runat="server" 
                                ControlToValidate="txtQuantityRight"
                                ErrorMessage="You must enter a quantity for your right." Display="Dynamic">*
                            </asp:RequiredFieldValidator>
                            <br />
                        </td>
                        <td class="tdPrescriptionMeasurement">
                            <asp:DropDownList ID="ddlPowerLeft" runat="server">
                                <asp:ListItem Value=""></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvPowerLeft" CssClass="vldRedColor" runat="server" 
                                ControlToValidate="ddlPowerLeft" InitialValue="" 
                                ErrorMessage="You must select a power prescription for your left eye." Display="Dynamic">*
                            </asp:RequiredFieldValidator>
                            <br />
                            <asp:DropDownList ID="ddlPowerRight" runat="server">
                                <asp:ListItem Value=""></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvPowerRight" CssClass="vldRedColor" runat="server" 
                                ControlToValidate="ddlPowerRight" InitialValue="" 
                                ErrorMessage="You must select a power prescription for your right eye." Display="Dynamic">*
                            </asp:RequiredFieldValidator>
                        </td>
                        <td class="tdPrescriptionMeasurement">
                            <asp:Label ID="lblBcLeft" runat="server" Text="Label" Visible="false"></asp:Label>
                            <asp:DropDownList ID="ddlBcLeft" runat="server">
                                <asp:ListItem Value=""></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvBcLeft" CssClass="vldRedColor" runat="server" 
                                ControlToValidate="ddlBcLeft" InitialValue="" 
                                ErrorMessage="You must select an BC prescription for your left eye." Display="Dynamic">*
                            </asp:RequiredFieldValidator>    
                            <br />
                            <asp:Label ID="lblBcRight" runat="server" Text="Label" Visible="false"></asp:Label>
                            <asp:DropDownList ID="ddlBcRight" runat="server">
                                <asp:ListItem Value=""></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvBcRight" CssClass="vldRedColor" runat="server" 
                                ControlToValidate="ddlBcRight" InitialValue="" 
                                ErrorMessage="You must select an BC prescription for your right eye." Display="Dynamic">*
                            </asp:RequiredFieldValidator>  
                        </td>
                        <td class="tdPrescriptionMeasurement">
                            <script type="text/javascript">
                                document.write(diameter + "<br />" + diameter);
                            </script>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="fullSize" style="text-align:center"><br />
                <asp:Button ID="btnAddToCart" runat="server" Text="ADD TO CART"   
                    Width="125" height="30" OnClick="btnAddToCart_Click" 
                    OnClientClick="window.scrollTo = function(x,y) { return true; };"/>
            </td>
        </tr>
        <tr>
            <td class="fullSize">
                <asp:ValidationSummary ID="vsPrescription" CssClass="vldRedColor" runat="server" 
                    HeaderText="Please correct the following errors:" />
            </td>
        </tr>
    </table>
</asp:Content>

