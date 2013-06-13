﻿<%@ Page Language="C#" MasterPageFile="~/SilverTixHome.master" AutoEventWireup="true"
    CodeFile="DeleteMovie.aspx.cs" Inherits="_DeleteMovie" Title="Database Configuration" %>

<asp:Content ID="cphHeadDeleteMovie" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>
<asp:Content ID="cphMainDeleteMovie" ContentPlaceHolderID="cphMain" runat="Server">
    <table>
        <tr>
            <td>
                <table>
                    <tr>
                        <td>
                            <asp:GridView ID="gvGetMovies" runat="server" AllowPaging="True" AllowSorting="True"
                                AutoGenerateColumns="False" DataKeyNames="MovieID" DataSourceID="sqlGetMoviesGv"
                                PageSize="8" SelectedIndex="0">
                                <Columns>
                                    <asp:BoundField DataField="MovieID" HeaderText="MovieID" InsertVisible="False" ReadOnly="True"
                                        SortExpression="MovieID" />
                                    <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
                                    <asp:BoundField DataField="ReleaseDate" HeaderText="ReleaseDate" SortExpression="ReleaseDate" />
                                    <asp:BoundField DataField="RunningTime" HeaderText="RunningTime" SortExpression="RunningTime" />
                                    <asp:BoundField DataField="Genre" HeaderText="Genre" SortExpression="Genre" />
                                    <asp:BoundField DataField="Cast" HeaderText="Cast" SortExpression="Cast" />
                                    <asp:BoundField DataField="ImageName" HeaderText="ImageName" SortExpression="ImageName" />
                                    <asp:BoundField DataField="ImageType" HeaderText="ImageType" SortExpression="ImageType" />
                                    <asp:CommandField ButtonType="Button" CancelText="" DeleteText="" EditText="" InsertText=""
                                        NewText="" ShowSelectButton="True" UpdateText="" />
                                </Columns>
                            </asp:GridView>
                        </td>
                        <td>
                            <asp:DetailsView ID="dvMovies" runat="server" Height="50px" Width="125px" AutoGenerateRows="False"
                                DataKeyNames="MovieID" DataSourceID="sqlGetMoviesDv">
                                <Fields>
                                    <asp:BoundField DataField="MovieID" HeaderText="MovieID" InsertVisible="False" ReadOnly="True"
                                        SortExpression="MovieID" />
                                    <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
                                    <asp:BoundField DataField="ReleaseDate" HeaderText="ReleaseDate" 
                                        SortExpression="ReleaseDate" DataFormatString="{0:d}" />
                                    <asp:BoundField DataField="RunningTime" HeaderText="RunningTime" SortExpression="RunningTime" />
                                    <asp:BoundField DataField="Genre" HeaderText="Genre" SortExpression="Genre" />
                                    <asp:BoundField DataField="Cast" HeaderText="Cast" SortExpression="Cast" />
                                    <asp:BoundField DataField="ImageName" HeaderText="ImageName" SortExpression="ImageName" />
                                    <asp:BoundField DataField="ImageType" HeaderText="ImageType" SortExpression="ImageType" />
                                    <asp:CommandField ButtonType="Button" DeleteText="" InsertText="" NewText="" SelectText=""
                                        ShowEditButton="True" />
                                    <asp:CommandField ButtonType="Button" CancelText="" EditText="" InsertText="" NewText=""
                                        SelectText="" ShowCancelButton="False" ShowDeleteButton="True" UpdateText="" />
                                </Fields>
                            </asp:DetailsView>
                        </td>
                    </tr>
                </table>
                <br />
                <asp:SqlDataSource ID="sqlGetMoviesGv" runat="server" ConflictDetection="CompareAllValues"
                    ConnectionString="<%$ ConnectionStrings:SilverTixConnectionString %>" DeleteCommand="DELETE FROM [Movies] WHERE [MovieID] = @original_MovieID AND [Title] = @original_Title AND [ReleaseDate] = @original_ReleaseDate AND [RunningTime] = @original_RunningTime AND [Genre] = @original_Genre AND [Synopsis] = @original_Synopsis AND [Cast] = @original_Cast AND (([ImageName] = @original_ImageName) OR ([ImageName] IS NULL AND @original_ImageName IS NULL)) AND (([ImageData] = @original_ImageData) OR ([ImageData] IS NULL AND @original_ImageData IS NULL)) AND (([ImageType] = @original_ImageType) OR ([ImageType] IS NULL AND @original_ImageType IS NULL))"
                    InsertCommand="INSERT INTO [Movies] ([Title], [ReleaseDate], [RunningTime], [Genre], [Synopsis], [Cast], [ImageName], [ImageData], [ImageType]) VALUES (@Title, @ReleaseDate, @RunningTime, @Genre, @Synopsis, @Cast, @ImageName, @ImageData, @ImageType)"
                    OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT * FROM [Movies] ORDER BY [ReleaseDate] DESC"
                    UpdateCommand="UPDATE [Movies] SET [Title] = @Title, [ReleaseDate] = @ReleaseDate, [RunningTime] = @RunningTime, [Genre] = @Genre, [Synopsis] = @Synopsis, [Cast] = @Cast, [ImageName] = @ImageName, [ImageData] = @ImageData, [ImageType] = @ImageType WHERE [MovieID] = @original_MovieID AND [Title] = @original_Title AND [ReleaseDate] = @original_ReleaseDate AND [RunningTime] = @original_RunningTime AND [Genre] = @original_Genre AND [Synopsis] = @original_Synopsis AND [Cast] = @original_Cast AND (([ImageName] = @original_ImageName) OR ([ImageName] IS NULL AND @original_ImageName IS NULL)) AND (([ImageData] = @original_ImageData) OR ([ImageData] IS NULL AND @original_ImageData IS NULL)) AND (([ImageType] = @original_ImageType) OR ([ImageType] IS NULL AND @original_ImageType IS NULL))">
                    <DeleteParameters>
                        <asp:Parameter Name="original_MovieID" Type="Int32" />
                        <asp:Parameter Name="original_Title" Type="String" />
                        <asp:Parameter DbType="Date" Name="original_ReleaseDate" />
                        <asp:Parameter Name="original_RunningTime" Type="String" />
                        <asp:Parameter Name="original_Genre" Type="String" />
                        <asp:Parameter Name="original_Synopsis" Type="String" />
                        <asp:Parameter Name="original_Cast" Type="String" />
                        <asp:Parameter Name="original_ImageName" Type="String" />
                        <asp:Parameter Name="original_ImageData" Type="Object" />
                        <asp:Parameter Name="original_ImageType" Type="String" />
                    </DeleteParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="Title" Type="String" />
                        <asp:Parameter DbType="Date" Name="ReleaseDate" />
                        <asp:Parameter Name="RunningTime" Type="String" />
                        <asp:Parameter Name="Genre" Type="String" />
                        <asp:Parameter Name="Synopsis" Type="String" />
                        <asp:Parameter Name="Cast" Type="String" />
                        <asp:Parameter Name="ImageName" Type="String" />
                        <asp:Parameter Name="ImageData" Type="Object" />
                        <asp:Parameter Name="ImageType" Type="String" />
                        <asp:Parameter Name="original_MovieID" Type="Int32" />
                        <asp:Parameter Name="original_Title" Type="String" />
                        <asp:Parameter DbType="Date" Name="original_ReleaseDate" />
                        <asp:Parameter Name="original_RunningTime" Type="String" />
                        <asp:Parameter Name="original_Genre" Type="String" />
                        <asp:Parameter Name="original_Synopsis" Type="String" />
                        <asp:Parameter Name="original_Cast" Type="String" />
                        <asp:Parameter Name="original_ImageName" Type="String" />
                        <asp:Parameter Name="original_ImageData" Type="Object" />
                        <asp:Parameter Name="original_ImageType" Type="String" />
                    </UpdateParameters>
                    <InsertParameters>
                        <asp:Parameter Name="Title" Type="String" />
                        <asp:Parameter DbType="Date" Name="ReleaseDate" />
                        <asp:Parameter Name="RunningTime" Type="String" />
                        <asp:Parameter Name="Genre" Type="String" />
                        <asp:Parameter Name="Synopsis" Type="String" />
                        <asp:Parameter Name="Cast" Type="String" />
                        <asp:Parameter Name="ImageName" Type="String" />
                        <asp:Parameter Name="ImageData" Type="Object" />
                        <asp:Parameter Name="ImageType" Type="String" />
                    </InsertParameters>
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="sqlGetMoviesDv" runat="server" ConflictDetection="CompareAllValues"
                    ConnectionString="<%$ ConnectionStrings:SilverTixConnectionString %>" DeleteCommand="DELETE FROM [Movies] WHERE [MovieID] = @original_MovieID AND [Title] = @original_Title AND [ReleaseDate] = @original_ReleaseDate AND [RunningTime] = @original_RunningTime AND [Genre] = @original_Genre AND [Synopsis] = @original_Synopsis AND [Cast] = @original_Cast AND (([ImageName] = @original_ImageName) OR ([ImageName] IS NULL AND @original_ImageName IS NULL)) AND (([ImageData] = @original_ImageData) OR ([ImageData] IS NULL AND @original_ImageData IS NULL)) AND (([ImageType] = @original_ImageType) OR ([ImageType] IS NULL AND @original_ImageType IS NULL))"
                    InsertCommand="INSERT INTO [Movies] ([Title], [ReleaseDate], [RunningTime], [Genre], [Synopsis], [Cast], [ImageName], [ImageData], [ImageType]) VALUES (@Title, @ReleaseDate, @RunningTime, @Genre, @Synopsis, @Cast, @ImageName, @ImageData, @ImageType)"
                    OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT * FROM [Movies] WHERE ([MovieID] = @MovieID)"
                    UpdateCommand="UPDATE [Movies] SET [Title] = @Title, [ReleaseDate] = @ReleaseDate, [RunningTime] = @RunningTime, [Genre] = @Genre, [Synopsis] = @Synopsis, [Cast] = @Cast, [ImageName] = @ImageName, [ImageData] = @ImageData, [ImageType] = @ImageType WHERE [MovieID] = @original_MovieID AND [Title] = @original_Title AND [ReleaseDate] = @original_ReleaseDate AND [RunningTime] = @original_RunningTime AND [Genre] = @original_Genre AND [Synopsis] = @original_Synopsis AND [Cast] = @original_Cast AND (([ImageName] = @original_ImageName) OR ([ImageName] IS NULL AND @original_ImageName IS NULL)) AND (([ImageData] = @original_ImageData) OR ([ImageData] IS NULL AND @original_ImageData IS NULL)) AND (([ImageType] = @original_ImageType) OR ([ImageType] IS NULL AND @original_ImageType IS NULL))">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="gvGetMovies" Name="MovieID" PropertyName="SelectedValue"
                            Type="Int32" />
                    </SelectParameters>
                    <DeleteParameters>
                        <asp:Parameter Name="original_MovieID" Type="Int32" />
                        <asp:Parameter Name="original_Title" Type="String" />
                        <asp:Parameter Name="original_ReleaseDate" DbType="DateTime" />
                        <asp:Parameter Name="original_RunningTime" Type="String" />
                        <asp:Parameter Name="original_Genre" Type="String" />
                        <asp:Parameter Name="original_Synopsis" Type="String" />
                        <asp:Parameter Name="original_Cast" Type="String" />
                        <asp:Parameter Name="original_ImageName" Type="String" />
                        <asp:Parameter Name="original_ImageData" DbType="Binary"  />
                        <asp:Parameter Name="original_ImageType" Type="String" />
                    </DeleteParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="Title" Type="String" />
                        <asp:Parameter Name="ReleaseDate" DbType="DateTime"  />
                        <asp:Parameter Name="RunningTime" Type="String" />
                        <asp:Parameter Name="Genre" Type="String" />
                        <asp:Parameter Name="Synopsis" Type="String" />
                        <asp:Parameter Name="Cast" Type="String" />
                        <asp:Parameter Name="ImageName" Type="String" />
                        <asp:Parameter Name="ImageData" DbType="Binary"  />
                        <asp:Parameter Name="ImageType" Type="String" />
                        <asp:Parameter Name="original_MovieID" Type="Int32" />
                        <asp:Parameter Name="original_Title" Type="String" />
                        <asp:Parameter Name="original_ReleaseDate" DbType="DateTime"  />
                        <asp:Parameter Name="original_RunningTime" Type="String" />
                        <asp:Parameter Name="original_Genre" Type="String" />
                        <asp:Parameter Name="original_Synopsis" Type="String" />
                        <asp:Parameter Name="original_Cast" Type="String" />
                        <asp:Parameter Name="original_ImageName" Type="String" />
                        <asp:Parameter Name="original_ImageData" DbType="Binary"  />
                        <asp:Parameter Name="original_ImageType" Type="String" />
                    </UpdateParameters>
                    <InsertParameters>
                        <asp:Parameter Name="Title" Type="String" />
                        <asp:Parameter Name="ReleaseDate" DbType="DateTime"  />
                        <asp:Parameter Name="RunningTime" Type="String" />
                        <asp:Parameter Name="Genre" Type="String" />
                        <asp:Parameter Name="Synopsis" Type="String" />
                        <asp:Parameter Name="Cast" Type="String" />
                        <asp:Parameter Name="ImageName" Type="String" />
                        <asp:Parameter Name="ImageData" DbType="Binary" />
                        <asp:Parameter Name="ImageType" Type="String" />
                    </InsertParameters>
                </asp:SqlDataSource>
            </td>
        </tr>
    </table>
</asp:Content>
