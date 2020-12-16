using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Reflection;

namespace WebApplication3
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("login.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Length == 0 || txtEmail.Text.Length==0)
            {
                Response.Write("All fields are required");
            }
            else
            {
                try
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString2"].ConnectionString);
                    con.Open();
                    
                    String getUserID = "select id from users where username=@username";
                    SqlCommand command = new SqlCommand(getUserID, con);
                    SqlDataReader sReader;
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@username", Session["User"]);
                    sReader = command.ExecuteReader();
                    String userid=null;
                    while (sReader.Read())
                    {
                        
                        userid = sReader["ID"].ToString();
                    }
                    sReader.Close();
                    String insert = "insert into payee (name,email) values (@name,@email)";
                    SqlCommand cmd = new SqlCommand(insert, con);
                    cmd.Parameters.AddWithValue("@name", txtName.Text.ToString());
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text.ToString());
                    cmd.ExecuteNonQuery();
                    string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"data.txt");
                    File.AppendAllText(path, "New Employee added to the database");
                    Response.Redirect("Default.aspx");
                    con.Close();
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
                Console.WriteLine(e);
                return false;
            }
        }
    }
}