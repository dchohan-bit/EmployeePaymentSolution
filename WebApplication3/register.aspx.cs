using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApplication3
{
    public partial class register : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text.Length == 0 || txtName.Text.Length == 0 || txtPassword.Text.Length==0)
            {
                Response.Write("All fields are required");
            }
            else
            {
                try
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString2"].ConnectionString);
                    con.Open();
                    String insert = "insert into users (name,username,password,userType) values (@name,@username,@password,@userType)";
                    SqlCommand cmd = new SqlCommand(insert, con);
                    cmd.Parameters.AddWithValue("@name", txtName.Text);
                    cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                    cmd.Parameters.AddWithValue("@password", txtPassword.Text);
                    cmd.Parameters.AddWithValue("@userType", userType.Text);
                    cmd.ExecuteNonQuery();
                    Response.Write("<script>alert('Account created successfully')</script>");
                    Response.Redirect("login.aspx");
                    con.Close();
                }
                catch (Exception ex)
                {
                    Response.Write(ex);
                    //Response.Write("<script>alert('The username is already in use')</script>");
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
                Console.WriteLine(e);
                return false;
            }
        }
    }
}