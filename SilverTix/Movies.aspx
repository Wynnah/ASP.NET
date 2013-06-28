﻿<%@ Page Language="C#" MasterPageFile="~/SilverTixHome.master" AutoEventWireup="true"
<<<<<<< HEAD
    CodeFile="Movies.aspx.cs" Inherits="_Movies" Title="Movies" Culture="en-CA" %>
=======
    CodeFile="Movies.aspx.cs" Inherits="_Movies" Title="Movies" %>
>>>>>>> 20f298e21303c6c9856bd96520d678b2c4443aab

<asp:Content ID="cphHeadMovies" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>
<asp:Content ID="cphMainMovies" ContentPlaceHolderID="cphMain" runat="Server">
<<<<<<< HEAD
    <div>
        <h1>
            Find A Movie:
            <asp:Label ID="lblMovieHeader" runat="server" Text="Now Playing"></asp:Label>
        </h1>
    </div>
    <div>
        <asp:RadioButtonList ID="rblMovieDateSelection" runat="server" OnPreRender="rblMovieDateSelection_CheckChanged" OnSelectedIndexChanged="rblMovieDateSelection_CheckChanged" AutoPostBack="True" RepeatDirection="Horizontal">
            <asp:ListItem Value="Now" Text="Now Playing" Selected="True"></asp:ListItem>
            <asp:ListItem Value="Soon" Text="Coming Soon"></asp:ListItem>
            <asp:ListItem Value="All" Text="All"></asp:ListItem>
        </asp:RadioButtonList>
        <asp:Label ID="lblMovieMsg" runat="server" Visible="false"></asp:Label>
        <asp:ListView ID="lvMovies" runat="server"  DataKeyNames="MovieID">
            <ItemTemplate>
                <div class="movieContentWrapper">
                    <div class="movieImage">
                        <asp:HyperLink ID="hlImgMovie" runat="server" NavigateUrl='<%#Eval("ImageName", "~/Movies/MovieDetails.aspx?title={0}") %>' ImageUrl='<%# Eval("MovieID", "~/Home.aspx?img={0}")%>' ></asp:HyperLink>
                    </div>
                    <div class="movieInfo">
                        <asp:HyperLink ID="hlMovieNowPlaying" runat="server" SkinID="skinHyperLinkMovie"
                            NavigateUrl='<%#Eval("ImageName", "~/Movies/MovieDetails.aspx?title={0}") %>'><%#Eval("Title") %></asp:HyperLink>
                        <br />
                        <br />
                        <b>Opens:</b>
                        <asp:Label ID="lblReleaseDateNowPlaying" runat="server" Text='<%# Eval("ReleaseDate", "{0:d}") %>' />
                        <br />
                        <b>Genre:</b>
                        <asp:Label ID="lblGenreNowPlaying" runat="server" Text='<%# Eval("Genre") %>' />
                        <br />
                        <b>Running Time:</b>
                        <asp:Label ID="lblRunningTimeNowPlaying" runat="server" Text='<%# Eval("RunningTime") %>' />
                        <br />
                        <b>Rated:</b>
                        <asp:Label ID="lblRatingPlaying" runat="server" Text='<%# Eval("Rating") %>' />
                    </div>
                </div>
            </ItemTemplate>
            <AlternatingItemTemplate>
                <div class="movieContentAltWrapper">
                    <div class="movieImage">
                        <asp:HyperLink ID="hlImgMovie" runat="server" NavigateUrl='<%#Eval("ImageName", "~/Movies/MovieDetails.aspx?title={0}") %>' ImageUrl='<%# Eval("MovieID", "~/Home.aspx?img={0}")%>' ></asp:HyperLink>
                    </div>
                    <div class="movieInfo">
                        <asp:HyperLink ID="hlMovieNowPlaying" runat="server" SkinID="skinHyperLinkMovie"
                            NavigateUrl='<%#Eval("ImageName", "~/Movies/MovieDetails.aspx?title={0}") %>'><%#Eval("Title") %></asp:HyperLink>
                        <br />
                        <br />
                        <b>Opens:</b>
                        <asp:Label ID="lblReleaseDateNowPlaying" runat="server" Text='<%# Eval("ReleaseDate", "{0:d}") %>' />
                        <br />
                        <b>Genre:</b>
                        <asp:Label ID="lblGenreNowPlaying" runat="server" Text='<%# Eval("Genre") %>' />
                        <br />
                        <b>Running Time:</b>
                        <asp:Label ID="lblRunningTimeNowPlaying" runat="server" Text='<%# Eval("RunningTime") %>' />
                        <br />
                        <b>Rated:</b>
                        <asp:Label ID="lblRatingPlaying" runat="server" Text='<%# Eval("Rating") %>' />
                    </div>
                </div>
            </AlternatingItemTemplate>
            <LayoutTemplate>
                <div id="itemPlaceholder" runat="server">
                </div>
                <div class="textAlignCenter" style="width: 900px;">
                    <asp:DataPager ID="dpNextPrevious" runat="server" PagedControlID="lvMovies" PageSize="4">
                        <Fields>
                            <asp:NextPreviousPagerField ButtonType="Button" ShowNextPageButton="false" ShowPreviousPageButton="true" />
                            <asp:NumericPagerField />
                            <asp:NextPreviousPagerField ButtonType="Button" ShowNextPageButton="true" ShowPreviousPageButton="false" />
                        </Fields>
                    </asp:DataPager>
                </div>
            </LayoutTemplate>
        </asp:ListView>
    </div>
=======
    <table>
        <tr>
            <td>
                <table>
                    <tr>
                        <td>
                            <h1>
                                Find A Movie:
                                <asp:Label ID="lblMovieTime" runat="server" Text="Now Playing"></asp:Label>
                            </h1>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <asp:RadioButton ID="rbNowPlaying" runat="server" Checked="true" GroupName="gnMovieTime"
                    Text="Now Playing" OnCheckedChanged="rbNowPlaying_CheckedChanged" AutoPostBack="True" />
                &nbsp;<asp:RadioButton ID="rbComingSoon" runat="server" GroupName="gnMovieTime" Text="Coming Soon"
                    OnCheckedChanged="rbComingSoon_CheckedChanged" AutoPostBack="True" />
                &nbsp;<asp:RadioButton ID="rbAll" runat="server" GroupName="gnMovieTime" Text="All"
                    OnCheckedChanged="rbAll_CheckedChanged" AutoPostBack="True" />
                <br />
                <asp:ListView ID="lvNowPlaying" runat="server" DataSourceID="sdsNowPlaying" DataKeyNames="MovieID">
                    <ItemTemplate>
                        <table class="tableMovieItem" cellpadding="4">
                            <tr>
                                <td class="tdMoviesLeft" rowspan="6">
                                    <asp:Image ID="imgMovie" runat="server" ImageUrl='<%# Eval("MovieID", "~/Home.aspx?img={0}")%>' />
                                </td>
                            </tr>
                            <tr>
                                <td class="tdMoviesRight">
                                    <asp:HyperLink ID="hlMovieNowPlaying" runat="server" SkinID="skinHyperLinkMovie"
                                        NavigateUrl='<%#Eval("ImageName", "~/Movies/MovieDetails.aspx?title={0}") %>'><%#Eval("Title") %></asp:HyperLink>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdMoviesRight">
                                    <b>Opens:</b>
                                    <asp:Label ID="lblReleaseDateNowPlaying" runat="server" SkinID="skinLabelMovieItem"
                                        Text='<%# Eval("ReleaseDate", "{0:d}") %>' />
                                </td>
                            </tr>
                            <tr>
                                <td class="tdMoviesRight">
                                    <b>Genre:</b>
                                    <asp:Label ID="lblGenreNowPlaying" runat="server" SkinID="skinLabelMovieItem" Text='<%# Eval("Genre") %>' />
                                </td>
                            </tr>
                            <tr>
                                <td class="tdMoviesRight">
                                    <b>Running Time:</b>
                                    <asp:Label ID="lblRunningTimeNowPlaying" runat="server" SkinID="skinLabelMovieItem"
                                        Text='<%# Eval("RunningTime") %>' />
                                </td>
                            </tr>
                            <tr>
                                <td class="tdMoviesRight">
                                    <b>Rated:</b>
                                    <asp:Label ID="lblRatingPlaying" runat="server" SkinID="skinLabelMovieItem" Text='<%# Eval("Rating") %>' />
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                        <table class="tableMovieAltItem" cellpadding="4">
                            <tr>
                                <td class="tdMoviesLeft" rowspan="6">
                                    <asp:Image ID="imgMovie" runat="server" ImageUrl='<%# Eval("MovieID", "~/Home.aspx?img={0}")%>' />
                                </td>
                            </tr>
                            <tr>
                                <td class="tdMoviesRight">
                                    <asp:HyperLink ID="hlMovieNowPlaying" runat="server" SkinID="skinHyperLinkMovie"
                                        NavigateUrl='<%#Eval("ImageName", "~/Movies/MovieDetails.aspx?title={0}") %>'><%#Eval("Title")%></asp:HyperLink>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdMoviesRight">
                                    <b>Opens:</b>
                                    <asp:Label ID="lblReleaseDateNowPlaying" runat="server" SkinID="skinLabelMovieAltItem"
                                        Text='<%# Eval("ReleaseDate", "{0:d}") %>' />
                                </td>
                            </tr>
                            <tr>
                                <td class="tdMoviesRight">
                                    <b>Genre:</b>
                                    <asp:Label ID="lblGenreNowPlaying" runat="server" SkinID="skinLabelMovieAltItem"
                                        Text='<%# Eval("Genre") %>' />
                                </td>
                            </tr>
                            <tr>
                                <td class="tdMoviesRight">
                                    <b>Running Time:</b>
                                    <asp:Label ID="lblRunningTimeNowPlaying" runat="server" SkinID="skinLabelMovieAltItem"
                                        Text='<%# Eval("RunningTime") %>' />
                                </td>
                            </tr>
                            <tr>
                                <td class="tdMoviesRight">
                                    <b>Rated:</b>
                                    <asp:Label ID="lblRatingPlaying" runat="server" SkinID="skinLabelMovieAltItem" Text='<%# Eval("Rating") %>' />
                                </td>
                            </tr>
                        </table>
                    </AlternatingItemTemplate>
                    <LayoutTemplate>
                        <table runat="server">
                            <tr>
                                <td id="itemPlaceholder" runat="server">
                                </td>
                            </tr>
                            <tr class="tableMovieItemBottom">
                                <td class="tdListViewBottom" colspan="2">
                                    <asp:DataPager ID="dpNextPrevious" runat="server" PagedControlID="lvNowPlaying" PageSize="4">
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
                <asp:SqlDataSource ID="sdsNowPlaying" runat="server" ConnectionString="<%$ ConnectionStrings:SilverTixConnectionString %>"
                    SelectCommand="SELECT [MovieID], [Title], [ReleaseDate], [RunningTime], [Genre], [Cast], [Rating], [ImageName] FROM [Movies] WHERE ([ReleaseDate] &lt;= @ReleaseDate) ORDER BY [Title]">
                    <SelectParameters>
                        <asp:SessionParameter Name="ReleaseDate" SessionField="CalenderToday" Type="DateTime" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <asp:ListView ID="lvComingSoon" runat="server" DataSourceID="sdsComingSoon" DataKeyNames="MovieID"
                    Visible="False">
                    <ItemTemplate>
                        <table class="tableMovieItem" cellpadding="4">
                            <tr>
                                <td class="tdMoviesLeft" rowspan="6">
                                    <asp:Image ID="imgMovie" runat="server" ImageUrl='<%# Eval("MovieID", "~/Home.aspx?img={0}")%>' />
                                </td>
                            </tr>
                            <tr>
                                <td class="tdMoviesRight">
                                    <asp:HyperLink ID="hlMovieNowPlaying" runat="server" SkinID="skinHyperLinkMovie"
                                        NavigateUrl='<%#Eval("ImageName", "~/Movies/{0}.aspx") %>'><%#Eval("Title") %></asp:HyperLink>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdMoviesRight">
                                    <b>Opens:</b>
                                    <asp:Label ID="lblReleaseDateNowPlaying" runat="server" SkinID="skinLabelMovieItem"
                                        Text='<%# Eval("ReleaseDate", "{0:d}") %>' />
                                </td>
                            </tr>
                            <tr>
                                <td class="tdMoviesRight">
                                    <b>Genre:</b>
                                    <asp:Label ID="lblGenreNowPlaying" runat="server" SkinID="skinLabelMovieItem" Text='<%# Eval("Genre") %>' />
                                </td>
                            </tr>
                            <tr>
                                <td class="tdMoviesRight">
                                    <b>Running Time:</b>
                                    <asp:Label ID="lblRunningTimeNowPlaying" runat="server" SkinID="skinLabelMovieItem"
                                        Text='<%# Eval("RunningTime") %>' />
                                </td>
                            </tr>
                            <tr>
                                <td class="tdMoviesRight">
                                    <b>Rated:</b>
                                    <asp:Label ID="lblRatingPlaying" runat="server" SkinID="skinLabelMovieItem" Text='<%# Eval("Rating") %>' />
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                        <table class="tableMovieAltItem" cellpadding="4">
                            <tr>
                                <td class="tdMoviesLeft" rowspan="6">
                                    <asp:Image ID="imgMovie" runat="server" ImageUrl='<%# Eval("MovieID", "~/Home.aspx?img={0}")%>' />
                                </td>
                            </tr>
                            <tr>
                                <td class="tdMoviesRight">
                                    <asp:HyperLink ID="hlMovieNowPlaying" runat="server" SkinID="skinHyperLinkMovie"
                                        NavigateUrl='<%#Eval("ImageName", "~/Movies/{0}.aspx") %>'><%#Eval("Title") %></asp:HyperLink>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdMoviesRight">
                                    <b>Opens:</b>
                                    <asp:Label ID="lblReleaseDateNowPlaying" runat="server" SkinID="skinLabelMovieAltItem"
                                        Text='<%# Eval("ReleaseDate", "{0:d}") %>' />
                                </td>
                            </tr>
                            <tr>
                                <td class="tdMoviesRight">
                                    <b>Genre:</b>
                                    <asp:Label ID="lblGenreNowPlaying" runat="server" SkinID="skinLabelMovieAltItem"
                                        Text='<%# Eval("Genre") %>' />
                                </td>
                            </tr>
                            <tr>
                                <td class="tdMoviesRight">
                                    <b>Running Time:</b>
                                    <asp:Label ID="lblRunningTimeNowPlaying" runat="server" SkinID="skinLabelMovieAltItem"
                                        Text='<%# Eval("RunningTime") %>' />
                                </td>
                            </tr>
                            <tr>
                                <td class="tdMoviesRight">
                                    <b>Rated:</b>
                                    <asp:Label ID="lblRatingPlaying" runat="server" SkinID="skinLabelMovieAltItem" Text='<%# Eval("Rating") %>' />
                                </td>
                            </tr>
                        </table>
                    </AlternatingItemTemplate>
                    <LayoutTemplate>
                        <table runat="server">
                            <tr>
                                <td id="itemPlaceholder" runat="server">
                                </td>
                            </tr>
                            <tr class="tableMovieItemBottom">
                                <td class="tdListViewBottom" colspan="2">
                                    <asp:DataPager ID="dpNextPrevious" runat="server" PagedControlID="lvComingSoon" PageSize="4">
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
                <asp:SqlDataSource ID="sdsComingSoon" runat="server" ConnectionString="<%$ ConnectionStrings:SilverTixConnectionString %>"
                    SelectCommand="SELECT [MovieID], [Title], [ReleaseDate], [RunningTime], [Genre], [Cast], [Rating], [ImageName] FROM [Movies] WHERE ([ReleaseDate] &gt;= @ReleaseDate) ORDER BY [Title]">
                    <SelectParameters>
                        <asp:SessionParameter Name="ReleaseDate" SessionField="CalenderToday" Type="DateTime" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <asp:ListView ID="lvAll" runat="server" DataSourceID="sdsAll" DataKeyNames="MovieID"
                    Visible="False">
                    <ItemTemplate>
                        <table class="tableMovieItem" cellpadding="4">
                            <tr>
                                <td class="tdMoviesLeft" rowspan="6">
                                    <asp:Image ID="imgMovie" runat="server" ImageUrl='<%# Eval("MovieID", "~/Home.aspx?img={0}")%>' />
                                </td>
                            </tr>
                            <tr>
                                <td class="tdMoviesRight">
                                    <asp:HyperLink ID="hlMovieNowPlaying" runat="server" SkinID="skinHyperLinkMovie"
                                        NavigateUrl='<%#Eval("ImageName", "~/Movies/{0}.aspx") %>'><%#Eval("Title") %></asp:HyperLink>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdMoviesRight">
                                    <b>Opens:</b>
                                    <asp:Label ID="lblReleaseDateNowPlaying" runat="server" SkinID="skinLabelMovieItem"
                                        Text='<%# Eval("ReleaseDate", "{0:d}") %>' />
                                </td>
                            </tr>
                            <tr>
                                <td class="tdMoviesRight">
                                    <b>Genre:</b>
                                    <asp:Label ID="lblGenreNowPlaying" runat="server" SkinID="skinLabelMovieItem" Text='<%# Eval("Genre") %>' />
                                </td>
                            </tr>
                            <tr>
                                <td class="tdMoviesRight">
                                    <b>Running Time:</b>
                                    <asp:Label ID="lblRunningTimeNowPlaying" runat="server" SkinID="skinLabelMovieItem"
                                        Text='<%# Eval("RunningTime") %>' />
                                </td>
                            </tr>
                            <tr>
                                <td class="tdMoviesRight">
                                    <b>Rated:</b>
                                    <asp:Label ID="lblRatingPlaying" runat="server" SkinID="skinLabelMovieItem" Text='<%# Eval("Rating") %>' />
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                        <table class="tableMovieAltItem" cellpadding="4">
                            <tr>
                                <td class="tdMoviesLeft" rowspan="6">
                                    <asp:Image ID="imgMovie" runat="server" ImageUrl='<%# Eval("MovieID", "~/Home.aspx?img={0}")%>' />
                                </td>
                            </tr>
                            <tr>
                                <td class="tdMoviesRight">
                                    <asp:HyperLink ID="hlMovieNowPlaying" runat="server" SkinID="skinHyperLinkMovie"
                                        NavigateUrl='<%#Eval("ImageName", "~/Movies/{0}.aspx") %>'><%#Eval("Title") %></asp:HyperLink>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdMoviesRight">
                                    <b>Opens:</b>
                                    <asp:Label ID="lblReleaseDateNowPlaying" runat="server" SkinID="skinLabelMovieAltItem"
                                        Text='<%# Eval("ReleaseDate", "{0:d}") %>' />
                                </td>
                            </tr>
                            <tr>
                                <td class="tdMoviesRight">
                                    <b>Genre:</b>
                                    <asp:Label ID="lblGenreNowPlaying" runat="server" SkinID="skinLabelMovieAltItem"
                                        Text='<%# Eval("Genre") %>' />
                                </td>
                            </tr>
                            <tr>
                                <td class="tdMoviesRight">
                                    <b>Running Time:</b>
                                    <asp:Label ID="lblRunningTimeNowPlaying" runat="server" SkinID="skinLabelMovieAltItem"
                                        Text='<%# Eval("RunningTime") %>' />
                                </td>
                            </tr>
                            <tr>
                                <td class="tdMoviesRight">
                                    <b>Rated:</b>
                                    <asp:Label ID="lblRatingPlaying" runat="server" SkinID="skinLabelMovieAltItem" Text='<%# Eval("Rating") %>' />
                                </td>
                            </tr>
                        </table>
                    </AlternatingItemTemplate>
                    <LayoutTemplate>
                        <table runat="server">
                            <tr>
                                <td id="itemPlaceholder" runat="server">
                                </td>
                            </tr>
                            <tr class="tableMovieItemBottom">
                                <td class="tdListViewBottom" colspan="2">
                                    <asp:DataPager ID="dpNextPrevious" runat="server" PagedControlID="lvAll" PageSize="4">
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
                <asp:SqlDataSource ID="sdsAll" runat="server" ConnectionString="<%$ ConnectionStrings:SilverTixConnectionString %>"
                    SelectCommand="SELECT [MovieID], [Title], [ReleaseDate], [RunningTime], [Genre], [Cast], [Rating], [ImageName] FROM [Movies] ORDER BY [Title]">
                </asp:SqlDataSource>
            </td>
        </tr>
    </table>
>>>>>>> 20f298e21303c6c9856bd96520d678b2c4443aab
</asp:Content>
