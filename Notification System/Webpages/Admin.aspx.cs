using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Security;


public partial class Webpages_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        p1.Visible = false;
        p2.Visible = false;
        P3.Visible = false;
        p4.Visible = false;
        
        Label12.Visible = false;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        p1.Visible = true;
        Label14.Visible = false;
        GridView3.Visible = false;
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        p2.Visible = true;
        SqlConnection con = new SqlConnection("data source=.; database=Notification_System; Integrated Security=SSPI");
        SqlCommand cmd = new SqlCommand("Select * from Emp_Cus",con);
        con.Open();
        SqlDataReader rd = cmd.ExecuteReader();
        GridView1.DataSource = rd;
        GridView1.DataBind();
        con.Close();
        Label14.Visible = false;
        GridView3.Visible = false;
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        P3.Visible = true;
        SqlConnection con = new SqlConnection("data source=.; database=Notification_System; Integrated Security=SSPI");
        SqlCommand cmd = new SqlCommand("Select * from Emp_Cus", con);
        con.Open();
        SqlDataReader rd = cmd.ExecuteReader();
        GridView2.DataSource = rd;
        GridView2.DataBind();
        con.Close();

        TextBox4.Enabled = true;
        Label14.Visible = false;
        GridView3.Visible = false;
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        String date = DateTime.Now.ToString("ddMMyyHHmmss");
        
        
        SqlConnection con = new SqlConnection("data source=.; database=Notification_System; Integrated Security=SSPI");
        SqlCommand cmd = new SqlCommand("Insert into Emp_Cus(ID,Name,Type,Email,MNum) values(@ID,@A,@B,@C,@D)", con);
       
        con.Open();
        cmd.Parameters.AddWithValue("@ID",date);
        cmd.Parameters.AddWithValue("@A",TextBox1.Text);
        cmd.Parameters.AddWithValue("@B",DropDownList1.SelectedItem.ToString());
        cmd.Parameters.AddWithValue("@C",TextBox2.Text);
        cmd.Parameters.AddWithValue("@D",TextBox3.Text);
        cmd.ExecuteNonQuery();
        
        Label14.Visible = true;
        Label14.Text = "Record Added Succcessfully";
        
        GridView3.Visible = true;
        SqlCommand cmd1 = new SqlCommand("Select * from Emp_Cus", con);
        SqlDataReader rd = cmd1.ExecuteReader();
        GridView3.DataSource = rd;
        GridView3.DataBind();

        con.Close();

    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection("data source=.; database=Notification_System; Integrated Security=SSPI");
        SqlCommand cmd = new SqlCommand("Delete from Emp_Cus where ID="+txtid.Text,con);
        con.Open();
        cmd.ExecuteNonQuery();

        p2.Visible = true;
        SqlCommand cmd1 = new SqlCommand("Select * from Emp_Cus", con);
        SqlDataReader rd = cmd1.ExecuteReader();
        GridView1.DataSource = rd;
        GridView1.DataBind();
        con.Close();
        Label14.Visible = true;
        Label14.Text = "Record Deleted Succcessfully";

    }
    protected void Button6_Click(object sender, EventArgs e)
    {
        P3.Visible = true;
        TextBox4.Enabled = false;
        SqlConnection con = new SqlConnection("data source=.; database=Notification_System; Integrated Security=SSPI");
        SqlCommand cmd = new SqlCommand("Select * from Emp_Cus where ID="+TextBox4.Text, con);
        con.Open();
        SqlDataReader rd = cmd.ExecuteReader();
        if(rd.HasRows)
        {
            rd.Read();
            p4.Visible = true;
            TextBox5.Text = rd["Name"].ToString();
            TextBox6.Text = rd["Email"].ToString();
            TextBox7.Text = rd["MNum"].ToString();
            
        }
        else
        {
            Label12.Text = "Please Enter Valid ID";
            TextBox4.Enabled = true;
            Label12.Visible = true;
        }
        rd.Close();
        con.Close();
        //cmd.Parameters.AddWithValue("@name",TextBox5.Text);
        //cmd.ExecuteNonQuery();
        //P3.Visible = true;
        //SqlCommand cmd1 = new SqlCommand("Select * from Emp_Cus", con);
        //SqlDataReader rd = cmd1.ExecuteReader();
        //GridView2.DataSource = rd;
        //GridView2.DataBind();
        //con.Close();
    }
    protected void Button7_Click(object sender, EventArgs e)
    {
        P3.Visible = true;
        
        SqlConnection con = new SqlConnection("data source=.; database=Notification_System; Integrated Security=SSPI");
        SqlCommand cmd = new SqlCommand("Update Emp_Cus set Name=@A,Type=@B,Email=@C,MNum=@D where ID=" + TextBox4.Text, con);
        cmd.Parameters.AddWithValue("@A",TextBox5.Text);
        cmd.Parameters.AddWithValue("@B", DropDownList2.SelectedItem.ToString());
        cmd.Parameters.AddWithValue("@C", TextBox6.Text);
        cmd.Parameters.AddWithValue("@D", TextBox7.Text);
        con.Open();
        cmd.ExecuteNonQuery();

        SqlCommand cmd1 = new SqlCommand("Select * from Emp_Cus", con);
        SqlDataReader rd = cmd1.ExecuteReader();
        GridView2.DataSource = rd;
        GridView2.DataBind();
        con.Close();
        Label14.Visible = true;
        Label14.Text = "Record updated Succcessfully";
    
    }
    protected void Button8_Click(object sender, EventArgs e)
    {
        FormsAuthentication.SignOut();
        Response.Redirect("~/Webpages/Login.aspx");
    }
}