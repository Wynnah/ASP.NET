<%@ Page Language="C#" MasterPageFile="~/SilverTixHome.master" AutoEventWireup="true"
    CodeFile="Movies.aspx.cs" Inherits="_Movies" Title="Movies" Culture="en-CA" %>

<asp:Content ID="cphHeadMovies" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>
<asp:Content ID="cphMainMovies" ContentPlaceHolderID="cphMain" runat="Server">
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
</asp:Content>
