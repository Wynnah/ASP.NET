<%@ Page Language="C#" MasterPageFile="~/SilverTixHome.master" AutoEventWireup="true"
    CodeFile="Location.aspx.cs" Inherits="_Location" Title="Where is SilverTix?" %>

<asp:Content ID="cphHeadLocation" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>
<asp:Content ID="cphMainLocation" ContentPlaceHolderID="cphMain" runat="Server">
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
</asp:Content>
