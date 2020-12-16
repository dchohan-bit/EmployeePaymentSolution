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
    public partial class profile : System.Web.UI.Page
    {
        String userid=null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["user"]==null){
                Response.Redirect("login.aspx");
            }
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
                    
                    while (sReader.Read())
                    {

                        userid = sReader["ID"].ToString();
                        Session["currentUser"] = userid;
                }
                    sReader.Close();
            }catch(Exception ex){
                Response.Write(ex);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString2"].ConnectionString);
                    con.Open();
                    
                    String insert = "update users set password=@password,name=@name,username=@username where id=@id";
                    SqlCommand cmd = new SqlCommand(insert, con);
                    cmd.Parameters.AddWithValue("@password", txtPassword.Value.ToString());
                    cmd.Parameters.AddWithValue("@name", txtName.Value.ToString());
                    cmd.Parameters.AddWithValue("@username", txtUsername.Value.ToString());
                    cmd.Parameters.AddWithValue("@id", userid);
                    cmd.ExecuteNonQuery();
                    string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"data.txt");
                    File.AppendAllText(path, "Profile updated for "+txtName.Value.ToString());
                    Response.Write("<script>alert('Password changed successfully')</script>");
                    con.Close();
                }
                catch (Exception ex)
                {
                    Response.Write(ex);
                }
            }
        }
    }
