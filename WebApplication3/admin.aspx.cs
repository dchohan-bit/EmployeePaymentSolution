using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication3
{
    public partial class admin : System.Web.UI.Page
    {
        string userType = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("login.aspx");
            }
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString2"].ConnectionString);
                con.Open();

                String getUserID = "select userType from users where username=@username";
                SqlCommand command = new SqlCommand(getUserID, con);
                SqlDataReader sReader;
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@username", Session["User"]);
                sReader = command.ExecuteReader();

                while (sReader.Read())
                {

                    userType = sReader["userType"].ToString();
                }
                sReader.Close();
            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }
            if (userType.Equals("Normal"))
            {
                string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"data.txt");
                File.AppendAllText(path, "Normal user has tried to access the admin page");
                Response.Write("You need to be an admin to access this page");
                Response.Redirect("Default.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (GridView1.SelectedRow == null)
            {
                Response.Write("<script>alert('select a row to delete')</script>");
            }
            else
            {
                String id = GridView1.SelectedRow.Cells[1].Text;
                try
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString2"].ConnectionString);
                    con.Open();

                    String insert = "DELETE FROM users where id=@id";
                    SqlCommand cmd = new SqlCommand(insert, con);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                    string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"data.txt");
                    File.AppendAllText(path, "User deleted from the database");
                    Response.Write("<script>alert('User Deleted Successfully')</script>");
                    con.Close();
                }
                catch (Exception ex)
                {
                    Response.Write(ex);
                }

            }
        }
    }
}