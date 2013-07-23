<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Frame.aspx.cs" Inherits="Frame" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">

<script type="text/javascript">

    var Controls = {
        rfvAddLeft: '<%=rfvAddLeft.ClientID%>',
        rfvAddRight: '<%=rfvAddRight.ClientID%>',
        ddlSphLeft: '<%=ddlSphLeft.ClientID%>',
        ddlSphRight: '<%=ddlSphRight.ClientID%>',
        btnContinue: '<%=btnContinue.ClientID%>',
        btnCart: '<%=btnAddToCart.ClientID%>',
        btnGoBack: '<%=btnGoBack.ClientID%>',
        vsPrescription: '<%=vsPrescription.ClientID%>',
        rb150Index: '<%=rb150Index.ClientID%>',
        rb159Index: '<%=rb159Index.ClientID%>',
        rb161Index: '<%=rb161Index.ClientID%>',
        rb167Index: '<%=rb167Index.ClientID%>',
        rb150Trans: '<%=rb150Trans.ClientID%>',
        rb159Trans: '<%=rb159Trans.ClientID%>',
        rb160Trans: '<%=rb160Trans.ClientID%>'
    };

    $(document).ready(function () {
        var a = function (self) {
            self.anchor.fancybox({
                'overlayShow': false,
                'transitionIn': 'elastic',
                'transitionOut': 'elastic'
            });
        };
        $("#pikame").PikaChoose({ buildFinished: a });
    });
    $(document).ready(function () {
        $("a[name^='question-']").each(function () {
            $(this).click(function () {
                if ($("#" + this.name).is(':hidden')) {
                    $("#" + this.name).slideToggle('fast');
                } else {
                    $("#" + this.name).slideToggle('fast');
                }
                return false;
            });
        });
    });
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
        <Scripts>
            <asp:ScriptReference Path="~/js/frameOptions.js" />
        </Scripts>
    </asp:ScriptManager>
    <asp:FormView ID="fvSpecificFrame" runat="server" DataKeyNames="glassesID"
        DataSourceID="sdsSpecificFrame" Width="100%">
        <EmptyDataTemplate>
            <table class="fullSize" runat="server">
                <tr>
                    <td>Sorry, there is currently no more of these frame.</td>
                </tr>
            </table>
        </EmptyDataTemplate>
        <ItemTemplate>
            <table class="fullSize">
                <tr>
                    <td class="tdSpecificCatalog" runat="server">
                        <ul id="pikame">
                            <li><a href='<%# Page.ResolveUrl("~") + "Images/Frames/" + Eval("image1") %>'><img src='<%# Page.ResolveUrl("~") + "Images/Frames/" + Eval("image1") %>' alt=""/></a></li>
                            <li><a href='<%# Page.ResolveUrl("~") + "Images/Frames/" + Eval("image2") %>'><img src='<%# Page.ResolveUrl("~") + "Images/Frames/" + Eval("image2") %>' alt=""/></a></li>
                            <li><a href='<%# Page.ResolveUrl("~") + "Images/Frames/" + Eval("image3") %>'><img src='<%# Page.ResolveUrl("~") + "Images/Frames/" + Eval("image3") %>' alt=""/></a></li>
                        </ul>
                        <p style="text-align: center;">Click to change view or click the large image to zoom.</p>
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
                                                <span class="bold">Gender:&nbsp;</span>
                                            </td>
                                            <td class="tdSpecificCatalogFrameSizeText">
                                                <asp:Label ID="lblGender" runat="server" Text='<%# Eval("gender") %>' />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="tdSpecificCatalogFrameSizeText">
                                                <span class="bold">Material:&nbsp;</span>
                                            </td>
                                            <td class="tdSpecificCatalogFrameSizeText">
                                                <asp:Label ID="lblMaterial" runat="server" Text='<%# Eval("material") %>' />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="tdSpecificCatalogFrameSizeText">
                                                <span class="bold">Shape:&nbsp;</span>
                                            </td>
                                            <td class="tdSpecificCatalogFrameSizeText">
                                                <asp:Label ID="lblShape" runat="server" Text='<%# Eval("shape") %>' />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="tdSpecificCatalogFrameSizeText">
                                                <span class="bold">Color:&nbsp;</span>
                                            </td>
                                            <td class="tdSpecificCatalogFrameSizeText">
                                                <asp:Label ID="lblColor" runat="server" Text='<%# Eval("color") %>' />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table><br />
            <table class="fullSize">
                <tr>
                    <th class="tdSpecificCatalogFrameSize" colspan="5" style="text-align:left">
                        <span>FRAME SIZING</span>
                    </th>
                </tr>
                <tr>
                    <td class="tdSpecificCatalogFrameSizeDetails">
                        <img src="<%= Page.ResolveUrl("~") %>Images/Frame Measurements/lensLength.png" alt="Lens-Width: " />&nbsp;
                        <asp:Label ID="lblLensDiameter" runat="server" Text='<%# Eval("lensDiameter") %>' />
                        <span>mm</span>
                    </td>
                    <td class="tdSpecificCatalogFrameSizeDetails">
                        <img src="<%= Page.ResolveUrl("~") %>Images/Frame Measurements/lensHeight.png" alt="Lens-Height: " />&nbsp;
                        <asp:Label ID="lblFrameDepth" runat="server" Text='<%# Eval("frameDepth") %>' />
                        <span>mm</span>
                    </td>
                    <td class="tdSpecificCatalogFrameSizeDetails">
                        <img src="<%= Page.ResolveUrl("~") %>Images/Frame Measurements/bridgeLength.png" alt="Bridge: " />&nbsp;
                        <asp:Label ID="lblBridge" runat="server" Text='<%# Eval("bridgeWidth") %>' />
                        <span>mm</span>
                    </td>
                    <td class="tdSpecificCatalogFrameSizeDetails">
                        <img src="<%= Page.ResolveUrl("~") %>Images/Frame Measurements/templeArmLength.png" alt="Temple-Length: " />&nbsp;
                        <asp:Label ID="lblTempleLength" runat="server" Text='<%# Eval("templeLength") %>' />
                        <span>mm</span>
                    </td>
                    <td class="tdSpecificCatalogFrameSizeDetails">
                        <img src="<%= Page.ResolveUrl("~") %>Images/Frame Measurements/frameLength.png" alt="Frame-Width: " />&nbsp;
                        <asp:Label ID="lblFrameWidth" runat="server" Text='<%# Eval("frameWidth") %>' />
                        <span>mm</span>
                    </td>
                    <td class="tdSpecificCatalogFrameSizeDetails">
                        <img src="<%= Page.ResolveUrl("~") %>Images/Frame Measurements/distanceBetweenTemple.png" alt="DBT: " />&nbsp;
                        <asp:Label ID="lblDBT" runat="server" Text='<%# Eval("distanceBtwTemples") %>' />
                        <span>mm</span>
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:FormView>
    <br />
    <asp:SqlDataSource ID="sdsSpecificFrame" runat="server" 
        ConnectionString="<%$ ConnectionStrings:eyewearDBConnectionString %>" 
        SelectCommand="SELECT * FROM [Glasses] WHERE ([glassesID] = @glassesID)">
        <SelectParameters>
            <asp:QueryStringParameter Name="glassesID" QueryStringField="id"  Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    <table class="fullSize">
        <tr>
            <td class="alignLeftFullSize" colspan="3">
                <span class="bold">HOW WILL YOU USE YOUR GLASSES</span>
            </td>
        </tr>
        <tr>
            <td class="tdUseGlassesAnswer">
                <asp:RadioButton ID="radioSingle" Checked="true" GroupName="Usage" runat="server" Text="Single Vision (Everyday Use)" onclick="progressive_unselected()" />
            </td>
            <td class="tdUseGlassesAnswer">
                <asp:RadioButton ID="radioBifocal" GroupName="Usage" runat="server" Text="Progressives & Bifocals" onclick="progressive_selected()" />
            </td>
            <td class="tdUseGlassesAnswer">
                <asp:RadioButton ID="radioReading" GroupName="Usage" runat="server" Text="Reading" onclick="progressive_selected()" />
            </td>
        </tr>
    </table>
    <br />
    <table class="fullSize" style="border-collapse:collapse">
        <tr>
            <td id="prescriptionHeader" class="alignLeftFullSize" style="background-color: #e0e0e0; color: #696969; border: 1px solid black; border-bottom:none;padding:10px">
                <a href="javascript:selectOptionsOff()"><span class="bold">PRESCRIPTION -</span>
                <br />
                Provide prescription information that you have received from your doctor.</a>
            </td>
            <td id="optionsHeader" class="alignLeftFullSize" style="padding:10px;border-bottom: 1px solid black;">
                <a href="javascript:selectOptionsOn()" runat="server"><span class="bold">OPTIONS -</span>
                <br />
                Please select lens options that you would like for your frames.</a>
            </td>
        </tr>
        <tr>
            <td id="prescription" class="fullSize" colspan="2" style="border: 1px solid black;border-top:none; padding:10px">
                <table class="fullSize" >
                    <tr>
                        <td class="tdPrescriptionMeasurement" />
                        <td class="tdPrescriptionMeasurement">
                            <a href="../Glossary.aspx#sph">SPH</a>
                        </td>
                        <td class="tdPrescriptionMeasurement">
                            <a href="../Glossary.aspx#cyl">CYL</a>
                        </td>
                        <td class="tdPrescriptionMeasurement">
                            <a href="../Glossary.aspx#axis">AXIS</a>
                        </td>
                        <td id="addTd" class="tdPrescriptionMeasurement" style="display: none;">
                            <a href="../Glossary.aspx#add">ADD</a>
                        </td>
                        <td class="tdPrescriptionMeasurement">
                            <a href="../Glossary.aspx#mpd">MPD</a>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdPrescriptionMeasurement">
                            <span>LEFT:</span> <br />
                            <span>RIGHT:</span>
                        </td>
                        <td class="tdPrescriptionMeasurement">
                            <asp:DropDownList ID="ddlSphLeft" runat="server">
                                <asp:ListItem Value=""></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvSphLeft" CssClass="vldRedColor" runat="server" 
                                ControlToValidate="ddlSphLeft" InitialValue="" 
                                ErrorMessage="You must select a left eye SPH prescription." Display="Dynamic">*
                            </asp:RequiredFieldValidator>
                            <br />
                            <asp:DropDownList ID="ddlSphRight" runat="server">
                                <asp:ListItem Value=""></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvSphRight" CssClass="vldRedColor" runat="server" 
                                ControlToValidate="ddlSphRight" InitialValue="" 
                                ErrorMessage="You must select a right eye SPH prescription." Display="Dynamic">*
                            </asp:RequiredFieldValidator>
                        </td>
                        <td class="tdPrescriptionMeasurement">
                            <asp:DropDownList ID="ddlCylLeft" runat="server">
                                <asp:ListItem>None</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvCylLeft" CssClass="vldRedColor" runat="server" 
                                ControlToValidate="ddlCylLeft" InitialValue="" 
                                ErrorMessage="You must select a left eye CYL prescription." Display="Dynamic">*
                            </asp:RequiredFieldValidator>
                            <br />
                            <asp:DropDownList ID="ddlCylRight" runat="server">
                                <asp:ListItem>None</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvCylRight" CssClass="vldRedColor" runat="server" 
                                ControlToValidate="ddlCylRight" InitialValue="" 
                                ErrorMessage="You must select a right eye CYL prescription." Display="Dynamic">*
                            </asp:RequiredFieldValidator>
                        </td>
                        <td class="tdPrescriptionMeasurement">
                            <asp:DropDownList ID="ddlAxisLeft" runat="server">
                                <asp:ListItem>None</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvAxisLeft" CssClass="vldRedColor" runat="server" 
                                ControlToValidate="ddlAxisLeft" InitialValue="" 
                                ErrorMessage="You must select a left eye AXIS prescription." Display="Dynamic">*
                            </asp:RequiredFieldValidator>    
                            <br />
                            <asp:DropDownList ID="ddlAxisRight" runat="server">
                                <asp:ListItem>None</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvAxisRight" CssClass="vldRedColor" runat="server" 
                                ControlToValidate="ddlAxisLeft" InitialValue="" 
                                ErrorMessage="You must select a right eye AXIS prescription." Display="Dynamic">*
                            </asp:RequiredFieldValidator>  
                        </td>
                        <td id="addTd2" class="tdPrescriptionMeasurement" style="display:none">
                            <asp:DropDownList ID="ddlAddLeft" runat="server">
                                <asp:ListItem Value=""></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvAddLeft" CssClass="vldRedColor" runat="server" 
                                ControlToValidate="ddlAddLeft" InitialValue="" Enabled="false" 
                                ErrorMessage="You must select a left eye ADD prescription." Display="None">*
                            </asp:RequiredFieldValidator>    
                            <br />
                            <asp:DropDownList ID="ddlAddRight" runat="server">
                                <asp:ListItem Value=""></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvAddRight" CssClass="vldRedColor" runat="server" 
                                ControlToValidate="ddlAddRight" InitialValue="" Enabled="false" 
                                ErrorMessage="You must select a right eye ADD prescription." Display="None">*
                            </asp:RequiredFieldValidator>  
                        </td>
                        <td class="tdPrescriptionMeasurement">
                            <asp:DropDownList ID="ddlMonoPdLeft" runat="server">
                                <asp:ListItem Value=""></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvMonoPdLeft" CssClass="vldRedColor" runat="server" 
                                ControlToValidate="ddlMonoPdLeft" InitialValue="" 
                                ErrorMessage="You must select a left eye MPD prescription." Display="Dynamic">*
                            </asp:RequiredFieldValidator>
                            <br />
                            <asp:DropDownList ID="ddlMonoPdRight" runat="server">
                                <asp:ListItem Value=""></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvMonoPdRight" CssClass="vldRedColor" runat="server" 
                                ControlToValidate="ddlMonoPdRight" InitialValue="" 
                                ErrorMessage="You must select a right eye MPD prescription." Display="Dynamic">*
                            </asp:RequiredFieldValidator>
                        </td>
<%--                        <td class="tdPrescriptionMeasurement" rowspan="2" style="vertical-align: middle;">
                            <span>OR&nbsp;&nbsp;</span>
                            <asp:DropDownList ID="ddlPd" runat="server">
                                <asp:ListItem Value=""></asp:ListItem>
                            </asp:DropDownList>
                        </td>--%>
                    </tr>
                    <tr>
                        <td class="fullSize" colspan="6">
                            <div class="divMPDQuestion">&nbsp; </div>
                            <div class="divMPDQuestion2">
                                <a href="#" name="question-1">I don't have my MPD, what do I do?</a><br />
                                <div class="answer" id="question-1">Divide your PD evenly by two, and put it into each MPD.<br /><br /></div>
                            </div>
                        </td>
                    </tr>
                </table>
            </td>
            <td id="lensOptions" class="alignLeftFullSize" style="display:none;border: 1px solid black;border-top:none;padding:10px" colspan="2">
                <table class="fullSize">
                    <tr>
                        <td class="tdLensOption" runat="server" colspan="2">
                            Eyeglasses Lens Types
                        </td>
                    </tr>
                    <tr>
                        <td class="fullSize" colspan="2" style="border-top:1px solid #e0e0e0;">
                            <div class="divLensOptionDetail1">
                                <asp:RadioButton ID="rb150Index" GroupName="LensOptions" runat="server" Text="1.50 Index High Quality Standard Lens" />
                            </div>
                            <div class="divLensOptionDetail2">
                                <span>
                                    Recommended for Prescriptions from -2.00 to +2.00
                                    <br />
                                </span>
                                <span class="bold">
                                    Free
                                </span>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td class="fullSize" colspan="2" style="border-top:1px solid #e0e0e0;">
                            <div class="divLensOptionDetail1">
                                <asp:RadioButton ID="rb159Index" GroupName="LensOptions" runat="server" Text="1.59 Index Thin Light Durable Polycarbonate Lens" />
                            </div>
                            <div class="divLensOptionDetail2">
                                <span>
                                    Recommended for Prescriptions from -4.00 to +2.00.
                                    <br />
                                    Recommended for kids.
                                    <br />
                                </span>
                                <span class="bold">
                                    $29.95 
                                </span>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td class="fullSize" colspan="2" style="border-top:1px solid #e0e0e0;">
                            <div class="divLensOptionDetail1">
                                <asp:RadioButton ID="rb161Index" GroupName="LensOptions" runat="server" Text="1.61 Index Thin Light Edidon Lens" />
                            </div>
                            <div class="divLensOptionDetail2">
                                <span>
                                    Recommended for Prescriptions from -4.00 to +2.00
                                    <br />
                                </span>
                                <span class="bold">
                                    $34.95
                                </span>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td class="fullSize" colspan="2" style="border-top:1px solid #e0e0e0;">
                            <div class="divLensOptionDetail1">
                                <asp:RadioButton ID="rb167Index" GroupName="LensOptions" runat="server" Text="1.67 High Index Super Thin Lens" />
                            </div>
                            <div class="divLensOptionDetail2">
                                <span>
                                    Strongly Recommended for Prescriptions from -12.00 to +6.00
                                    <br />
                                </span>
                                <span class="bold">
                                    $69.95
                                </span>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdLensOption" colspan="2">
                            <br />
                            Photochromic and Transitions Lenses
                        </td>
                    </tr>
                    <tr>
                        <td class="fullSize" colspan="2" style="border-top:1px solid #e0e0e0;">
                            <div class="divLensOptionDetail1">
                                <asp:RadioButton ID="rb150Trans" GroupName="LensOptions" runat="server" Text="1.50 Transitions® VI (Grey)" />
                            </div>
                            <div class="divLensOptionDetail2">
                                <span>
                                    Recommended for Prescriptions from -2.00 to +2.00
                                    <br />
                                </span>
                                <span class="bold">
                                    $99.00
                                </span>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td class="fullSize" colspan="2" style="border-top:1px solid #e0e0e0;">
                            <div class="divLensOptionDetail1">
                                <asp:RadioButton ID="rb159Trans" GroupName="LensOptions" runat="server" Text="1.59 Polycarbonate Transitions® VI (Grey)" />
                                <br />
                            </div>
                            <div class="divLensOptionDetail2">
                                <span>
                                    Recommended for Prescriptions from -4.00 to +4.00
                                    <br />
                                </span>
                                <span class="bold">
                                    $109.00
                                </span>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td class="fullSize" colspan="2" style="border-top:1px solid #e0e0e0;">
                            <div class="divLensOptionDetail1">
                                <asp:RadioButton ID="rb160Trans" GroupName="LensOptions" runat="server" Text="1.60 High Index Photochromic Lens (Grey)" />
                            </div>
                            <div class="divLensOptionDetail2">
                                <span>
                                    Recommended for Prescriptions from -8.00 to +4.00 
                                    <br />
                                </span>
                                <span class="bold">
                                    $119.00
                                </span>
                            </div>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="tdPrescriptionFooter1">
                <input id="btnGoBack" style="display: none;" runat="server" causesvalidation="true" ValidationGroup="vgGlasses" 
                    type="button" value="GO BACK" onclick="selectOptionsOff()" />
            </td>
            <td class="tdPrescriptionFooter2">
                <asp:Button ID="btnContinue" runat="server" Text="CONTINUE"
                    OnClientClick="selectOptionsOn(); return false;" />
                <asp:Button ID="btnAddToCart" style="display: none;" runat="server" Text="ADD TO CART"   Width="125" height="30"
                    OnClick="btnAddToCart_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:ValidationSummary ID="vsPrescription" CssClass="vldRedColor" runat="server" 
                    ValidationGroup="vgGlasses" HeaderText="Please correct the following errors:" />
            </td>
        </tr>
    </table>
</asp:Content>

