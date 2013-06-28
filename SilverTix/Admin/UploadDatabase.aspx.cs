using System;
using System.Collections;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.IO;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;


public partial class _UploadDatabase : System.Web.UI.Page
{
<<<<<<< HEAD
    private static SqlConnection con = null;
    private static string dbConnStr = "SilverTixConnectionString";
    private static SqlCommand cmd = null;

=======
>>>>>>> 20f298e21303c6c9856bd96520d678b2c4443aab
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void UploadBtn_Click(object sender, System.EventArgs e)
    {
        if (Page.IsValid) //save the image
        {
            Stream imgStream = UploadFile.PostedFile.InputStream;
            int imgLen = UploadFile.PostedFile.ContentLength;
            string imgContentType = UploadFile.PostedFile.ContentType;
            string movieTitleName = txtMovieTitle.Text;
            DateTime movieRelease = (Convert.ToDateTime(txtMovieRelease.Text));
            string movieRunning = txtMovieRunning.Text;
            string movieGenre = txtMovieGenre.Text;
            string movieSynopsis = txtMovieSynopsis.Text;
            string movieCast = txtMovieCast.Text;
            string movieRating = txtRating.Text;
            string imgName = txtImgName.Text;
            string videoURL = txtVideoUrl.Text;
            byte[] imgBinaryData = new byte[imgLen];
            int n = imgStream.Read(imgBinaryData, 0, imgLen);

            int RowsAffected = SaveToDB(movieTitleName, movieRelease, movieRunning, movieGenre, movieSynopsis, movieCast, movieRating, imgName, videoURL, imgBinaryData, imgContentType);
            if (RowsAffected > 0)
            {
                clearTextBox();
                lblSaveOrNot.Text = "The Image was saved";
            }
            else
            {
                lblSaveOrNot.Text = "An error occurred uploading the image";
            }
        }
    }

    private void clearTextBox()
    {
        txtMovieTitle.Text = "";
        txtMovieRelease.Text = "";
        txtMovieRunning.Text = "";
        txtMovieGenre.Text = "";
        txtMovieSynopsis.Text = "";
        txtMovieCast.Text = "";
        txtRating.Text = "";
        txtImgName.Text = "";
        txtVideoUrl.Text = "";
    }

    private int SaveToDB(string movieTitle, DateTime movieDate, string movieRunning, string movieGenre, string movieSymp, string movieCast, string movieRating, string imgName, string videoURL, byte[] imgbin, string imgcontenttype)
    {
        //use the web.config to store the connection string
<<<<<<< HEAD
        con = new SqlConnection(ConfigurationManager.ConnectionStrings[dbConnStr].ConnectionString);
        cmd = new SqlCommand("INSERT INTO [Movies] (Title, ReleaseDate, RunningTime, Genre, Synopsis, Cast, " +
                                "Rating, ImageName, ImageData ,ImageType, VideoURL) VALUES " + 
                                "(@Title, @ReleaseDate, @RunningTime, @Genre, @Synopsis, @Cast, @Rating, " +
                                "@ImageName, @ImageData, @ImageType, @VideoURL )", con);

        SqlParameter param0 = new SqlParameter("@Title", SqlDbType.VarChar, 40);
        param0.Value = movieTitle;
        cmd.Parameters.Add(param0);

        SqlParameter param1 = new SqlParameter("@ReleaseDate", SqlDbType.DateTime);
        param1.Value = movieDate;
        cmd.Parameters.Add(param1);

        SqlParameter param2 = new SqlParameter("@RunningTime", SqlDbType.Char, 5);
        param2.Value = movieRunning;
        cmd.Parameters.Add(param2);

        SqlParameter param3 = new SqlParameter("@Genre", SqlDbType.VarChar, 70);
        param3.Value = movieGenre;
        cmd.Parameters.Add(param3);

        SqlParameter param4 = new SqlParameter("@Synopsis", SqlDbType.VarChar, 8000);
        param4.Value = movieSymp;
        cmd.Parameters.Add(param4);

        SqlParameter param5 = new SqlParameter("@Cast", SqlDbType.VarChar, 8000);
        param5.Value = movieCast;
        cmd.Parameters.Add(param5);

        SqlParameter param6 = new SqlParameter("@Rating", SqlDbType.Char, 10);
        param6.Value = movieRating;
        cmd.Parameters.Add(param6);

        SqlParameter param7 = new SqlParameter("@ImageName", SqlDbType.VarChar, 30);
        param7.Value = imgName;
        cmd.Parameters.Add(param7);

        SqlParameter param8 = new SqlParameter("@ImageData", SqlDbType.Image);
        param8.Value = imgbin;
        cmd.Parameters.Add(param8);

        SqlParameter param9 = new SqlParameter("@ImageType", SqlDbType.VarChar, 30);
        param9.Value = imgcontenttype;
        cmd.Parameters.Add(param9);

        SqlParameter param10 = new SqlParameter("@VideoURL", SqlDbType.Char, 200);
        param10.Value = videoURL;
        cmd.Parameters.Add(param10);

        con.Open();
        int numRowsAffected = cmd.ExecuteNonQuery();
        con.Close();
=======
        SqlConnection connection = new SqlConnection(ConfigurationSettings.AppSettings["DSN"]);
        SqlCommand command = new SqlCommand("INSERT INTO [Movies] (Title, ReleaseDate, RunningTime, Genre, Synopsis, Cast, Rating, ImageName, ImageData ,ImageType, VideoURL) VALUES (@Title, @ReleaseDate, @RunningTime, @Genre, @Synopsis, @Cast, @Rating, @ImageName, @ImageData, @ImageType, @VideoURL )", connection);

        SqlParameter param0 = new SqlParameter("@Title", SqlDbType.VarChar, 40);
        param0.Value = movieTitle;
        command.Parameters.Add(param0);

        SqlParameter param1 = new SqlParameter("@ReleaseDate", SqlDbType.DateTime);
        param1.Value = movieDate;
        command.Parameters.Add(param1);

        SqlParameter param2 = new SqlParameter("@RunningTime", SqlDbType.Char, 5);
        param2.Value = movieRunning;
        command.Parameters.Add(param2);

        SqlParameter param3 = new SqlParameter("@Genre", SqlDbType.VarChar, 70);
        param3.Value = movieGenre;
        command.Parameters.Add(param3);

        SqlParameter param4 = new SqlParameter("@Synopsis", SqlDbType.VarChar, 8000);
        param4.Value = movieSymp;
        command.Parameters.Add(param4);

        SqlParameter param5 = new SqlParameter("@Cast", SqlDbType.VarChar, 8000);
        param5.Value = movieCast;
        command.Parameters.Add(param5);

        SqlParameter param6 = new SqlParameter("@Rating", SqlDbType.Char, 10);
        param6.Value = movieRating;
        command.Parameters.Add(param6);

        SqlParameter param7 = new SqlParameter("@ImageName", SqlDbType.VarChar, 30);
        param7.Value = imgName;
        command.Parameters.Add(param7);

        SqlParameter param8 = new SqlParameter("@ImageData", SqlDbType.Image);
        param8.Value = imgbin;
        command.Parameters.Add(param8);

        SqlParameter param9 = new SqlParameter("@ImageType", SqlDbType.VarChar, 30);
        param9.Value = imgcontenttype;
        command.Parameters.Add(param9);

        SqlParameter param10 = new SqlParameter("@VideoURL", SqlDbType.Char, 200);
        param10.Value = videoURL;
        command.Parameters.Add(param10);

        connection.Open();
        int numRowsAffected = command.ExecuteNonQuery();
        connection.Close();
>>>>>>> 20f298e21303c6c9856bd96520d678b2c4443aab

        return numRowsAffected;
    }

}
