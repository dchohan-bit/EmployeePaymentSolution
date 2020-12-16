using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication3
{
    public partial class view_boards : System.Web.UI.Page
    {
        string payeeID = null;
       
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["user"] == null)
            {
                Response.Redirect("login.aspx");
            }
            if (!string.IsNullOrEmpty(Request.QueryString["payeeID"]))
            {
                payeeID = Request.QueryString["payeeID"];
                Session["currentItem"] = payeeID;
            }
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            if (txtAmount.Text.Length == 0 || verifyInt(txtAmount.Text) == false)
            {
                Response.Write("<script>alert('Enter the amount')</script>");
            }
            else
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString2"].ConnectionString);
                con.Open();
                String insert = "insert into payment (payer,payee,amount,paymentDate) values (@payer,@payee,@amount,@paymentDate)";
                SqlCommand cmd = new SqlCommand(insert, con);
                cmd.Parameters.AddWithValue("@payer", Session["user"]);
                cmd.Parameters.AddWithValue("@payee", payeeID);
                cmd.Parameters.AddWithValue("@amount", txtAmount.Text);
                cmd.Parameters.AddWithValue("@paymentDate", DateTime.Now);
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Payee paid Successfully')</script>");
            }
        }
        private Boolean verifyInt(String input)
        {
            try
            {
                int.Parse(input);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
    }
}