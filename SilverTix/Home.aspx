<%@ Page Language="C#" MasterPageFile="~/SilverTixHome.master" AutoEventWireup="true"
    CodeFile="Home.aspx.cs" Inherits="_Home" Title="SilverTix's Home Page" %>

<asp:Content ID="cphHomeHead" ContentPlaceHolderID="cphHead" runat="Server">
<script type="text/javascript" src="<%= Page.ResolveUrl("~") %>Scripts/jquery-1.5.1.min.js"></script>
<script type="text/javascript" src="<%= Page.ResolveUrl("~") %>Scripts/jquery.cycle.all.js"></script>
<script type="text/javascript">
    $(document).ready(function () {
        $('.slideshow').cycle({
            fx: 'uncover', // choose your transition type, ex: fade, scrollUp, shuffle, etc...
            sync: 0,
            timeout: 5000
        });
    });
</script>
</asp:Content>
<asp:Content ID="cphHomeMain" ContentPlaceHolderID="cphMain" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div id="homeMovies">
        <h1>
            Featured Films
        </h1>
        <asp:ListView ID="lvFeatures" runat="server" DataKeyNames="MovieID" DataSourceID="sqlFeatureMovies">
            <ItemTemplate>
                <a href='<%= Page.ResolveUrl("~")%><%#Eval("Title", "Movies/MovieDetails.aspx?title={0}") %>'>
		            <img src="<%#Eval("Link", "Movies/MovieBanners/{0}") %>" alt='<%#Eval("Title", "{0}") %>' class="homeFeatured" />
                </a>
            </ItemTemplate>
            <LayoutTemplate>
                <div class="slideshow">
                    <div id="itemPlaceholder" runat="server">
                    </div>
                </div>
            </LayoutTemplate>
        </asp:ListView>
        <asp:SqlDataSource ID="sqlFeatureMovies" runat="server" ConnectionString="<%$ ConnectionStrings:SilverTixConnectionString %>"
            SelectCommand="SELECT f.MovieID as 'MovieID', m.ImageName as 'Title', m.BannerLink as 'Link' FROM (Features f INNER JOIN Movies m ON f.movieID=m.MovieID) ">
        </asp:SqlDataSource>
        <div>
            <h1>
                Now Playing & Coming Soon
            </h1>
            <asp:ListView ID="lvMovies" runat="server" DataKeyNames="MovieID" DataSourceID="sqlGetMovies">
                <ItemTemplate>
                    <td runat="server" class="homeNowAndSoonMovies" style="padding-right: 26px" >
                        <asp:HyperLink ID="hlImgMovie" runat="server" ImageUrl='<%# Eval("MovieID", "Home.aspx?img={0}")%>' NavigateUrl='<%# Eval("ImageName", "~/Movies/MovieDetails.aspx?title={0}")%>'><%# Eval("Title") %>></asp:HyperLink>
                        <br />
                        <asp:HyperLink ID="hlMovieWebsite" runat="server" SkinID="skinHyperLinkMovie" NavigateUrl='<%# Eval("ImageName", "~/Movies/MovieDetails.aspx?title={0}")%>'><%# Eval("Title") %></asp:HyperLink>
                        <br />
                        <asp:HyperLink ID="hlReleaseDate" runat="server" CssClass="noTextDec" NavigateUrl='<%# Eval("ImageName", "~/Movies/MovieDetails.aspx?title={0}")%>'>Opens: <%# Eval("ReleaseDate", "{0:d}")%></asp:HyperLink>
                        <br />
                    </td>
                </ItemTemplate>
                <LayoutTemplate>
                    <asp:UpdatePanel ID="updatePanel1" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <table runat="server" style="margin-left: -3px" cellpadding="3">
                                <tr id="itemPlaceholder" runat="server">
                                </tr>
                            </table>
                            <div class="textAlignCenter">
                                <asp:DataPager ID="dpNextPrevious" runat="server" PagedControlID="lvMovies" PageSize="6">
                                    <Fields>
                                        <asp:NextPreviousPagerField ButtonType="Button" ShowNextPageButton="false" ShowPreviousPageButton="true" />
                                        <asp:NumericPagerField />
                                        <asp:NextPreviousPagerField ButtonType="Button" ShowNextPageButton="true" ShowPreviousPageButton="false" />
                                    </Fields>
                                </asp:DataPager>
                            </div>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="dpNextPrevious" />        
                        </Triggers>
                    </asp:UpdatePanel>
                </LayoutTemplate>
            </asp:ListView>
            <asp:SqlDataSource ID="sqlGetMovies" runat="server" ConnectionString="<%$ ConnectionStrings:SilverTixConnectionString %>"
                SelectCommand="SELECT [MovieID], [Title], [ReleaseDate], [ImageName] FROM [Movies] ORDER BY [ReleaseDate] DESC">
            </asp:SqlDataSource>
        </div>
    </div>
</asp:Content>
