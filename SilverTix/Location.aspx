<%@ Page Language="C#" MasterPageFile="~/SilverTixHome.master" AutoEventWireup="true"
    CodeFile="Location.aspx.cs" Inherits="_Location" Title="Where is SilverTix?" %>

<asp:Content ID="cphHeadLocation" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>
<asp:Content ID="cphMainLocation" ContentPlaceHolderID="cphMain" runat="Server">
<<<<<<< HEAD
    <div class="locationWrapper">
            <asp:ListView ID="lvFeatures" runat="server" DataKeyNames="LocationID" DataSourceID="sqlLocations">
                <ItemTemplate>
                    <div class="locationContent">
                        <h2><%#Eval("Name", "{0}") %></h2>
                        <%#Eval("Address", "{0}") %></h2>
                        <br />
                        <%#Eval("City", "{0}") %></h2>
                        <br />
                        <br />
                        <iframe id="imgFrameBurnabyBranch" height="250" src="<%#Eval("MapURL", "{0}") %>'>"
                            width="350"></iframe>
                        <br />
                        <br />
                    </div>
                </ItemTemplate>
                <LayoutTemplate>
                    <div id="itemPlaceholder" runat="server" />
                </LayoutTemplate>
            </asp:ListView>
        <asp:SqlDataSource ID="sqlLocations" runat="server" ConnectionString="<%$ ConnectionStrings:SilverTixConnectionString %>"
                SelectCommand="SELECT [LocationID], [Name], [Address], [City], [MapURL] FROM [Locations] ORDER BY [LocationID] ASC">
        </asp:SqlDataSource>
    </div>
=======
    <table>
        <tr>
            <td>
                <table>
                    <tr>
                        <td class="tdLocation">
                            <h2>
                                Canada MetroTown Center Burnaby Branch</h2>
                            <div style="text-align: left; margin-left: 25px">
                                4800 Kingsway
                                <br />
                                Burnaby, BC
                                <br />
                                <br />
                            </div>
                            <iframe id="imgFrameBurnabyBranch" height="250" src="http://www.dr2ooo.com/tools/maps/maps.php?zoom=17&amp;ll=49.227344,-122.996387&amp;type=normal&amp;cp=true&amp;width=350&amp;height=250&amp;"
                                width="350"></iframe>
                            <br />
                            <br />
                        </td>
                        <td class="tdLocation">
                            <h2>
                                Japan Hanaojacho Branch</h2>
                            <div style="text-align: left; margin-left: 25px">
                                〒101-0021 Metropolis Chiyoda Ward
                                <br />
                                Akihabara, Japan
                                <br />
                                <br />
                            </div>
                            <iframe id="imgFrameHanaojachoBranch" height="250" src="http://www.dr2ooo.com/tools/maps/maps.php?zoom=17&amp;ll=35.699012,139.774766&amp;type=normal&amp;cp=true&amp;width=350&amp;height=250&amp;"
                                width="350"></iframe>
                            <br />
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td class="tdLocation">
                            <h2>
                                Taipei 101 Tower Branch</h2>
                            <div style="text-align: left; margin-left: 25px">
                                No. 8, SōngZhì Rd, Sinyi District
                                <br />
                                Taipei City, Taiwan 110
                                <br />
                                <br />
                            </div>
                            <iframe id="imgFrameTowerBranch" src="http://www.dr2ooo.com/tools/maps/maps.php?
                          zoom=18&ll=25.033394,121.564912&ctrl=true&kml=&type=normal&cp=true&width=350&height=250&"
                                width="350" height="250"></iframe>
                            <br />
                            <br />
                        </td>
                        <td class="tdLocation">
                            <h2>
                                Australia Sydney Opera House Branch</h2>
                            <div style="text-align: left; margin-left: 25px">
                                7-33 Playfair St
                                <br />
                                The Rocks NSW 2000, Australia
                                <br />
                                <br />
                            </div>
                            <iframe id="imgFrameOperaHouseBranch" src="http://www.dr2ooo.com/tools/maps/maps.php?zoom=17&ll=-33.859082,151.208025&type=normal&cp=true&width=350&height=250&"
                                width="350" height="250"></iframe>
                            <br />
                            <br />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
>>>>>>> 20f298e21303c6c9856bd96520d678b2c4443aab
</asp:Content>
