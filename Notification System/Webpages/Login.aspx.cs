using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Webpages_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Label3.Visible = false;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection("data source=.; database=Notification_System; Integrated Security=SSPI");
        SqlCommand cmd = new SqlCommand("Select * from Login where UserName=@A and Password=@B", con);
        cmd.Parameters.AddWithValue("@A",TextBox1.Text);
        cmd.Parameters.AddWithValue("@B",TextBox2.Text);
        con.Open();
        SqlDataReader rd = cmd.ExecuteReader();

        if(rd.HasRows)
        {
            FormsAuthentication.RedirectFromLoginPage(TextBox1.Text, CheckBox1.Checked);
            Response.Redirect("~/Webpages/Notification.aspx");
        }
        else
        {
            Label3.Visible = true;
            Label3.Text = "Please Enter Valid Username and Password";
        }
        con.Close();
    }
}