<%@ Page Language="C#" MasterPageFile="~/SilverTixHome.master" AutoEventWireup="true"
    CodeFile="Home.aspx.cs" Inherits="_Home" Title="SilverTix's Home Page" %>

<asp:Content ID="cphHomeHead" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>
<asp:Content ID="cphHomeMain" ContentPlaceHolderID="cphMain" runat="Server">
    <table>
        <tr>
            <td>
                <h1>
                    Featured Film
                </h1>
            </td>
        </tr>
        <tr>
            <td>
                <object type="application/x-shockwave-flash" style="width: 100%; height: 450px;"
                    data="http://vimeo.com/moogaloop.swf?clip_id=7492481&amp;server=vimeo.com&amp;show_title=1&amp;show_byline=0&amp;show_portrait=0&amp;color=a20004&amp;fullscreen=1">
                    <param name="movie" value="http://vimeo.com/moogaloop.swf?clip_id=7492481&amp;server=vimeo.com&amp;show_title=1&amp;show_byline=0&amp;show_portrait=0&amp;color=a20004&amp;fullscreen=1" />
                </object>
            </td>
        </tr>
        <tr>
            <td>
                <div class="divHeader">
                    <asp:HyperLink ID="hlmovieTronLegacy" CssClass="Movie" runat="server" NavigateUrl="~/Movies/Tron-Legacy.aspx">TRON: Legacy</asp:HyperLink>
                </div>
                <br />
            </td>
        </tr>
        <tr>
            <td>
                <div>
                    Tron: Legacy is a 2010 science fiction film. It is a sequel to the 1982 Academy
                    Award-nominated film Tron. Joseph Kosinski makes his feature film directorial debut
                    with Tron: Legacy, while the previous film director, Steven Lisberger, returns as
                    a producer. Jeff Bridges reprises his role as Kevin Flynn, and Bruce Boxleitner
                    his roles as Alan Bradley and Tron, while Garrett Hedlund portrays Flynns now-adult
                    son, Sam.The other cast members include Olivia Wilde, Beau Garrett, Michael Sheen
                    and John Hurt.
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <h1>
                    Now Playing & Coming Soon
                </h1>
                <asp:ListView ID="lvMovies" runat="server" DataKeyNames="MovieID" DataSourceID="sqlGetMovies">
                    <ItemTemplate>
                        <td runat="server">
                            <asp:Image ID="imgMovie" runat="server" ImageUrl='<%# Eval("MovieID", "Home.aspx?img={0}")%>' />
                            <br />
                            <asp:HyperLink ID="hlMovieWebsite" runat="server" SkinID="skinHyperLinkMovie" NavigateUrl='<%# Eval("ImageName", "~/Movies/MovieDetails.aspx?title={0}")%>'><%# Eval("Title") %></asp:HyperLink>
                            <br />
                            Opens:
                            <asp:Label ID="lblReleaseDate" runat="server" Text='<%# Eval("ReleaseDate", "{0:d}") %>' />
                            <br />
                        </td>
                    </ItemTemplate>
                    <LayoutTemplate>
                        <table runat="server" cellpadding="4">
                            <tr id="itemPlaceholder" runat="server">
                            </tr>
                            <tr>
                                <td class="tdListViewBottom" colspan="4">
                                    <asp:DataPager ID="dpNextPrevious" runat="server" PagedControlID="lvMovies" PageSize="4">
                                        <Fields>
                                            <asp:NextPreviousPagerField ButtonType="Button" ShowNextPageButton="false" ShowPreviousPageButton="true" />
                                            <asp:NumericPagerField />
                                            <asp:NextPreviousPagerField ButtonType="Button" ShowNextPageButton="true" ShowPreviousPageButton="false" />
                                        </Fields>
                                    </asp:DataPager>
                                </td>
                            </tr>
                        </table>
                    </LayoutTemplate>
                </asp:ListView>
                <asp:SqlDataSource ID="sqlGetMovies" runat="server" ConnectionString="<%$ ConnectionStrings:SilverTixConnectionString %>"
                    SelectCommand="SELECT [MovieID], [Title], [ReleaseDate], [ImageName] FROM [Movies] ORDER BY [ReleaseDate] DESC">
                </asp:SqlDataSource>
            </td>
        </tr>
    </table>
</asp:Content>
