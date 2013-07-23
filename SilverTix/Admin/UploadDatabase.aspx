<%@ Page Language="C#" MasterPageFile="~/SilverTixHome.master" AutoEventWireup="true"
    CodeFile="UploadDatabase.aspx.cs" Inherits="_UploadDatabase" Title="Database Configuration" %>

<asp:Content ID="cphHeadUploadDatabase" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>
<asp:Content ID="cphMainUploadDatabase" ContentPlaceHolderID="cphMain" runat="Server">
    <div class="uploadDbInfo">
        <h1>
            Store New Movie
        </h1>
        <table style="margin-left: -6px;">
            <tr>
                <td>
                    <table>
                        <tr>
                            <td class="tdInsertDatabaseLeft">
                                Movie Title:
                            </td>
                            <td class="tdInsertDatabaseRight">
                                <asp:TextBox ID="txtMovieTitle" runat="server" MaxLength="40" Width="200px" />
                                <asp:RequiredFieldValidator ID="rfvMovieTitle" runat="server" ErrorMessage="Movie Title is required."
                                    ControlToValidate="txtMovieTitle" Display="Dynamic" ValidationGroup="vgInsert">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="tdInsertDatabaseLeft">
                                Movie Release Date:
                            </td>
                            <td class="tdInsertDatabaseRight">
                                <asp:TextBox ID="txtMovieRelease" runat="server" MaxLength="10" Width="200px" />
                                <asp:RequiredFieldValidator ID="rfvMovieRelease" runat="server" ErrorMessage="Movie Release Date is required."
                                    ControlToValidate="txtMovieRelease" Display="Dynamic" ValidationGroup="vgInsert">*</asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="cvReleaseDate" runat="server" ErrorMessage="Please use correct Release Date format MM/dd/yyyy"
                                    ControlToValidate="txtMovieRelease" Display="Dynamic" Operator="DataTypeCheck"
                                    Type="Date" ValidationGroup="vgInsert">*</asp:CompareValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="tdInsertDatabaseLeft">
                                Movie Running Time:
                            </td>
                            <td class="tdInsertDatabaseRight">
                                <asp:TextBox ID="txtMovieRunning" runat="server" MaxLength="5" Width="200px" />
                                <asp:RequiredFieldValidator ID="rfvRunningTime" runat="server" ErrorMessage="Movie Running Time is required."
                                    ControlToValidate="txtMovieRunning" Display="Dynamic" ValidationGroup="vgInsert">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="tdInsertDatabaseLeft">
                                Movie Genre:
                            </td>
                            <td class="tdInsertDatabaseRight">
                                <asp:TextBox ID="txtMovieGenre" runat="server" MaxLength="70" Width="200px" />
                                &nbsp;<asp:RequiredFieldValidator ID="rfvGenre" runat="server" ErrorMessage="Move Genre is required."
                                    ControlToValidate="txtMovieGenre" Display="Dynamic" ValidationGroup="vgInsert">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="tdInsertDatabaseLeft">
                                Movie Synopsis:
                            </td>
                            <td class="tdInsertDatabaseRight">
                                <asp:TextBox ID="txtMovieSynopsis" runat="server" MaxLength="80" Rows="5" TextMode="MultiLine"
                                    Width="470px" />
                                <asp:RequiredFieldValidator ID="rfvMovieSynopsis" runat="server" ErrorMessage="Movie Synopsis is required."
                                    ControlToValidate="txtMovieSynopsis" Display="Dynamic" ValidationGroup="vgInsert">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="tdInsertDatabaseLeft">
                                Movie Cast:
                            </td>
                            <td class="tdInsertDatabaseRight">
                                <asp:TextBox ID="txtMovieCast" runat="server" MaxLength="120" Width="200px" />
                                <asp:RequiredFieldValidator ID="rfvMovieCast" runat="server" ErrorMessage="Movie Cast is required."
                                    ControlToValidate="txtMovieCast" Display="Dynamic" ValidationGroup="vgInsert">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="tdInsertDatabaseLeft">
                                Rating:
                            </td>
                            <td class="tdInsertDatabaseRight">
                                <asp:TextBox ID="txtRating" runat="server" MaxLength="120" Width="200px" />
                                <asp:RequiredFieldValidator ID="rfvMovieRating" runat="server" ErrorMessage="Movie Rating is required."
                                    ControlToValidate="txtRating" Display="Dynamic" ValidationGroup="vgInsert">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="tdInsertDatabaseLeft">
                                Enter An Image Name:
                            </td>
                            <td class="tdInsertDatabaseRight">
                                <asp:TextBox ID="txtImgName" runat="server" MaxLength="30" Width="200px" /><asp:RequiredFieldValidator
                                    ID="rfvImgName" runat="server" ErrorMessage="An Image Name is required." ControlToValidate="txtImgName"
                                    Display="Dynamic" ValidationGroup="vgInsert">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="tdInsertDatabaseLeft">
                                Video URL:
                            </td>
                            <td class="tdInsertDatabaseRight">
                                <asp:TextBox ID="txtVideoUrl" runat="server" MaxLength="200" Width="200px" /><asp:RequiredFieldValidator
                                    ID="rfvVideoUrl" runat="server" ErrorMessage="Video URL is required." ControlToValidate="txtVideoUrl"
                                    Display="Dynamic" ValidationGroup="vgInsert">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="tdInsertDatabaseLeft">
                                Select File To Upload:
                            </td>
                            <td class="tdInsertDatabaseRight">
                                <input id="UploadFile" type="file" runat="server" />
                                <asp:RequiredFieldValidator ID="rfvImagePicture" runat="server" ControlToValidate="UploadFile"
                                    Display="Dynamic" ErrorMessage="An Image Picture is required." ValidationGroup="vgInsert">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="tdInsertDatabaseLeft">
                                <asp:Button ID="UploadBtn" Text="Insert" OnClick="UploadBtn_Click" runat="server"
                                    Width="100px" ValidationGroup="vgInsert" CausesValidation="true"></asp:Button>
                            </td>
                            <td class="tdInsertDatabaseRight">
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    <div class="uploadDbValidSum">
        <asp:ValidationSummary ID="vsInsertMovie" runat="server" HeaderText="Please correct the following error:"
            ValidationGroup="vgInsert" />
        <asp:Label ID="lblSaveOrNot" runat="server"></asp:Label>
    </div>
</asp:Content>
