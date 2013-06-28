<%@ Page Language="C#" MasterPageFile="~/SilverTixHome.master" AutoEventWireup="true"
    CodeFile="MovieDetails.aspx.cs" Inherits="_MovieDetails" %>

<asp:Content ID="cphHeadMovieDetails" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>
<asp:Content ID="cphMainMovieDetails" ContentPlaceHolderID="cphMain" runat="Server">
<<<<<<< HEAD
<<<<<<< HEAD
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="movieDetailsWrapper">
        <asp:FormView ID="fvMovieDetails" runat="server" DataKeyNames="MovieID" DataSourceID="sdsMovieDetails">
            <ItemTemplate>
                <div class="movieDetailsInformation">
                    <asp:Label ID="lblTitle" runat="server" SkinID="skinLabelMovie" Text='<%# Eval("Title") %>' />
                    <br />
                    <br />
                    <b>Release Date:</b>
                    <asp:Label ID="lblReleaseDate" runat="server" Text='<%# Eval("ReleaseDate", "{0:d}") %>' />
                    <br />

                    <b>Running Time:</b>
                    <asp:Label ID="lblRunningTime" runat="server" Text='<%# Eval("RunningTime") %>' />
                    <br />

                    <b>Genre:</b>
                    <asp:Label ID="lblGenre" runat="server" Text='<%# Eval("Genre") %>' />
                    <br />

                    <b>Cast:</b>
                    <asp:Label ID="lblCast" runat="server" Text='<%# Eval("Cast") %>' />
                    <br />

                    <b>Rated:</b>
                    <asp:Label ID="lblRating" runat="server" Text='<%# Eval("Rating") %>' />
                    <br />
                </div>
                <div class="movieDetailsImage">
                    <asp:Image ID="imgMovie" runat="server" ImageUrl='<%# Eval("MovieID", "~/Home.aspx?img={0}")%>' />
                </div>
                <div class="movieDetailsFullWidth">
                    <b>Synopsis:</b>
                    <br />
                    <asp:Label ID="lblSynopsis" runat="server" Text='<%# Eval("Synopsis") %>' />
                    <br />
                    <br />
                    <object type="application/x-shockwave-flash" style="width: 100%; height: 450px;"
                        data=' <%# Eval("VideoUrl") %>'>
                    <param name="movie" value=' <%# Eval("VideoUrl") %>' />
                    </object>
                </div>
            </ItemTemplate>
        </asp:FormView>
    </div>
    <asp:SqlDataSource ID="sdsMovieDetails" runat="server" ConnectionString="<%$ ConnectionStrings:SilverTixConnectionString %>"
        SelectCommand="SELECT [MovieID], [Title], [ReleaseDate], [RunningTime], [Genre], [Synopsis], [Cast], [Rating], [VideoUrl] FROM [Movies] WHERE ([ImageName] = @Title)">
        <SelectParameters>
            <asp:QueryStringParameter Name="Title" QueryStringField="title"  Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
<%--    <div class="movieDetailsFullWidth">
        <h1>
            Select Theatre
        </h1>
        City:
        <asp:DropDownList ID="ddlLocation" runat="server" DataSourceID="sqlLocations"  DataTextField="City"
                DataValueField="LocationID">
        </asp:DropDownList>
        <asp:SqlDataSource ID="sqlLocations" runat="server" ConnectionString="<%$ ConnectionStrings:SilverTixConnectionString %>"
            SelectCommand="SELECT LocationID, City FROM Locations">
        </asp:SqlDataSource>
        <br />
        <br />
        Showtimes:
        <div class="movieDetailsShowTimes">
            
        </div>
    </div>--%>
    <h1>
        Purchase Ticket
    </h1>
    <asp:UpdatePanel ID="updatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            Select an age range:
            <asp:DropDownList ID="ddlPrices" runat="server" DataSourceID="SqlMovieSource" DataTextField="Age"
                DataValueField="Price" AutoPostBack="True">
            </asp:DropDownList>&nbsp; Priced at:&nbsp;<asp:Label ID="lblCash" runat="server"></asp:Label>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="ddlPrices" />        
        </Triggers>
    </asp:UpdatePanel>
    <asp:SqlDataSource ID="SqlMovieSource" runat="server" ConnectionString="<%$ ConnectionStrings:SilverTixConnectionString %>"
        SelectCommand="SELECT Movies.MovieID, Movies.Title, Tickets.PriceID, Tickets.Price, Tickets.Age FROM Tickets CROSS JOIN Movies WHERE (Movies.MovieID = 4)">
    </asp:SqlDataSource>
    Quantity:
    <asp:TextBox ID="txtQuantity" runat="server" Height="21px" Width="63px"></asp:TextBox>
    <asp:Button ID="btnAddToCart" runat="server" Text="Add To Cart" Width="129px" OnClick="btnAddToCart_Click" />
    &nbsp;<asp:Button ID="btnGoToCart" runat="server" CausesValidation="false" PostBackUrl="~/Promo/Cart.aspx"
        Text="Go To Cart" Width="129px" />
    <asp:RequiredFieldValidator ID="rfvCart" runat="server" ErrorMessage="Quantity is a required field."
        ControlToValidate="txtQuantity" Display="Dynamic"></asp:RequiredFieldValidator>
    <asp:RangeValidator ID="rvCart" runat="server" ErrorMessage="Quantity must range from 1 to 200."
        ControlToValidate="txtQuantity" Display="Dynamic" MaximumValue="150" MinimumValue="1"
        Type="Integer">
    </asp:RangeValidator>
=======
=======
>>>>>>> 20f298e21303c6c9856bd96520d678b2c4443aab
    <table>
        <tr>
            <td>
                <asp:FormView ID="fvMovieDetails" runat="server" DataKeyNames="MovieID" DataSourceID="sdsMovieDetails">
                    <ItemTemplate>
                        <table cellpadding="4">
                            <tr>
                                <td class="tdDetailMoviesLeft">
                                    <asp:Label ID="lblTitle" runat="server" SkinID="skinLabelMovie" Text='<%# Eval("Title") %>' />
                                </td>
                                <td class="tdDetailMoviesRight" rowspan="4">
                                    <asp:Image ID="imgMovie" runat="server" ImageUrl='<%# Eval("MovieID", "~/Home.aspx?img={0}")%>' />
                                </td>
                            </tr>
                            <tr>
                                <td class="tdDetailMoviesLeft">
                                    <b>Release Date:</b>
                                    <asp:Label ID="ReleaseDateLabel" runat="server" Text='<%# Eval("ReleaseDate", "{0:d}") %>' />
                                </td>
                            </tr>
                            <tr>
                                <td class="tdDetailMoviesLeft">
                                    <b>Running Time:</b>
                                    <asp:Label ID="RunningTimeLabel" runat="server" Text='<%# Eval("RunningTime") %>' />
                                </td>
                            </tr>
                            <tr>
                                <td class="tdDetailMoviesLeft">
                                    <b>Genre:</b>
                                    <asp:Label ID="GenreLabel" runat="server" Text='<%# Eval("Genre") %>' />
                                </td>
                            </tr>
                            <tr>
                                <td class="tdDetailMoviesLeft">
                                    <b>Cast:</b>
                                    <asp:Label ID="CastLabel" runat="server" Text='<%# Eval("Cast") %>' />
                                </td>
                                <td class="tdDetailMoviesRight">
                                    <b>Rated:</b>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("Rating") %>' />
                                </td>
                            </tr>
                            <tr>
                                <td class="tdDetailMoviesCenter" colspan="2">
                                    <br />
                                    <b>Synopsis:</b>
                                    <br />
                                    <asp:Label ID="SynopsisLabel" runat="server" Text='<%# Eval("Synopsis") %>' />
                                </td>
                            </tr>
                        </table>
                        <object type="application/x-shockwave-flash" style="width: 100%; height: 450px;"
                            data=' <%# Eval("VideoUrl") %>'>
                            <param name="movie" value=' <%# Eval("VideoUrl") %>' />
                        </object>
                    </ItemTemplate>
                </asp:FormView>
                <br />
                <asp:SqlDataSource ID="sdsMovieDetails" runat="server" ConnectionString="<%$ ConnectionStrings:SilverTixConnectionString %>"
                    SelectCommand="SELECT [MovieID], [Title], [ReleaseDate], [RunningTime], [Genre], [Synopsis], [Cast], [Rating], [VideoUrl] FROM [Movies] WHERE ([ImageName] = @Title)">
                    <SelectParameters>
                        <asp:QueryStringParameter Name="Title" QueryStringField="title"  Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td>
                <object type="application/x-shockwave-flash" style="width: 100%; height: 450px;"
                    data='<%# Eval("VideoUrl") %>'>
                    <param name="movie" value='<%# Eval("VideoUrl") %>' />
                </object>
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td>
                <h1>
                    Purchase Ticket</h1>
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="2">
                Select an age range:
                <asp:DropDownList ID="ddlPrices" runat="server" DataSourceID="SqlMovieSource" DataTextField="Age"
                    DataValueField="Price" AutoPostBack="True">
                </asp:DropDownList>
                &nbsp; Priced at:&nbsp;<asp:Label ID="lblCash" runat="server"></asp:Label>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:SqlDataSource ID="SqlMovieSource" runat="server" ConnectionString="<%$ ConnectionStrings:SilverTixConnectionString %>"
                    SelectCommand="SELECT Movies.MovieID, Movies.Title, Tickets.PriceID, Tickets.Price, Tickets.Age FROM Tickets CROSS JOIN Movies WHERE (Movies.MovieID = 4)">
                </asp:SqlDataSource>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="2">
                Quantity:
                <asp:TextBox ID="txtQuantity" runat="server" Height="21px" Width="63px"></asp:TextBox>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="btnAddToCart" runat="server" Text="Add To Cart" Width="129px" OnClick="btnAddToCart_Click" />
                &nbsp;<asp:Button ID="btnGoToCart" runat="server" CausesValidation="false" PostBackUrl="~/Promo/Cart.aspx"
                    Text="Go To Cart" Width="129px" />
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:RequiredFieldValidator ID="rfvCart" runat="server" ErrorMessage="Quantity is a required field."
                    ControlToValidate="txtQuantity" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:RangeValidator ID="rvCart" runat="server" ErrorMessage="Quantity must range from 1 to 200."
                    ControlToValidate="txtQuantity" Display="Dynamic" MaximumValue="150" MinimumValue="1"
                    Type="Integer"></asp:RangeValidator>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
<<<<<<< HEAD
>>>>>>> 20f298e21303c6c9856bd96520d678b2c4443aab
=======
>>>>>>> 20f298e21303c6c9856bd96520d678b2c4443aab
</asp:Content>
