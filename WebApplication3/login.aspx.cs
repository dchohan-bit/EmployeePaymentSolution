using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.IO;
using System.Reflection;

namespace WebApplication3
{
    public partial class login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (TxtUsername.Text.Length == 0 || TxtPassword.Text.Length==0)
            {
                Response.Write("All fields are required");
            }
            else
            {
                try
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString2"].ConnectionString);
                    
                    String query = "select * from users where username=@username and password=@password";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@username",TxtUsername.Text);
                    cmd.Parameters.AddWithValue("@password",TxtPassword.Text);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    con.Open();
                    if (dt.Rows.Count > 0)
                    {
                        SqlCommand cmd2 = new SqlCommand("update users set lastLogin=@lastlogin where username=@username", con);
                        cmd2.Parameters.AddWithValue("@username", TxtUsername.Text);
                        cmd2.Parameters.AddWithValue("@lastlogin", DateTime.Now);
                        cmd2.ExecuteNonQuery();
                        Session["user"] = TxtUsername.Text;
                        string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"data.txt");
                        File.AppendAllText(path, "Login Successful for "+TxtUsername.Text);
                        Response.Redirect("Default.aspx");
                        Session.RemoveAll();
                        con.Close();
                    }
                    else
                    {
                        Response.Write("<script>alert('Invalid username or password')</script>");
                    }
                }
                catch (Exception ex)
                {
                    Response.Write(ex);
                }
            }
        }
        private Boolean verifyInt(String input)
        {
            try
            {
                int.Parse(input);
                return true;
            }catch(Exception e){
                return false;
            }
        }
    }
}