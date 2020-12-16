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
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Write("<script>alert('You need to login first')</script>");
                Response.Redirect("login.aspx");
            }
            if (Session["user"] != null)
            {
                sessionLabel.Text = "WELCOME "+Session["user"].ToString().ToUpper();
            }

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
                Response.Redirect("add.aspx");
            
        }

       

        protected void Button2_Click(object sender, EventArgs e)
        {

            if (GridView1.SelectedRow==null)
            {
                Response.Write("<script>alert('select an payee to view')</script>");
            }
            else
            {
                string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"data.txt");
                File.AppendAllText(path, "Employee selected and redirecting to the viewing page");
                String id = GridView1.SelectedRow.Cells[1].Text;
                Response.Redirect("view_payee.aspx?payeeID="+id);
                
            }
        }
    }
   
}