using System;
using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.UI;
//using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Net;
using System.Collections.Specialized;
using System.Web;
using System.Web.Security;

public partial class Webpages_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
        Label1.Visible = false;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        
        SqlConnection con = new SqlConnection("data source=.; database=Notification_System; Integrated Security=true");
        con.Open();
        SqlCommand cmd;
        int flag;
        if(DropDownList2.SelectedItem.Value =="1" && DropDownList1.SelectedItem.Value=="1")
        {
            cmd = new SqlCommand("Select Email,MNum from Emp_Cus", con);
            flag = 1;
        }
        else if (DropDownList2.SelectedItem.Value == "1" && DropDownList1.SelectedItem.Value == "2")
        {
            cmd = new SqlCommand("Select Email,MNum from Emp_Cus where Type='Employee'", con);
            flag = 1;
        }
        else if (DropDownList2.SelectedItem.Value == "1" && DropDownList1.SelectedItem.Value == "3")
        {
            cmd = new SqlCommand("Select Email,MNum from Emp_Cus where Type='Customer'", con);
            flag = 1;
        }




        else if (DropDownList2.SelectedItem.Value == "2" && DropDownList1.SelectedItem.Value == "1")
        {
            cmd = new SqlCommand("Select MNum from Emp_Cus", con);
            flag = 2;
        }
        else if (DropDownList2.SelectedItem.Value == "2" && DropDownList1.SelectedItem.Value == "2")
        {
            cmd = new SqlCommand("Select MNum from Emp_Cus where Type='Employee'", con);
            flag = 2;
        }
        else if (DropDownList2.SelectedItem.Value == "2" && DropDownList1.SelectedItem.Value == "3")
        {
            cmd = new SqlCommand("Select MNum from Emp_Cus where Type='Customer'", con);
            flag = 2;
        }



        else if (DropDownList2.SelectedItem.Value == "3" && DropDownList1.SelectedItem.Value == "1")
        {
            cmd = new SqlCommand("Select Email from Emp_Cus", con);
            flag = 3;
        }
        else if (DropDownList2.SelectedItem.Value == "3" && DropDownList1.SelectedItem.Value == "2")
        {
            cmd = new SqlCommand("Select Email from Emp_Cus where Type='Employee'", con);
            flag = 3;
        }
        else
        {
            
            cmd = new SqlCommand("Select Email from Emp_Cus where Type='Customer'", con);
            flag = 3;
        }
        SqlDataReader rd = cmd.ExecuteReader();
        

        switch(flag)
        {
            case 1:
                // Flag is 1 , Both (Email, SMS) WIll be send
                string destinationaddr = "",message = TextBox1.Text,message1 = HttpUtility.UrlEncode(message);
               // int i = 0;
                try
                {
                    SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                    client.EnableSsl = true;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential("mohit.singlapup@gmail.com", "mohit@1948869");
                    while (rd.Read())
                    {
                        //Email
                        MailMessage msg = new MailMessage();
                        msg.To.Add(rd["Email"].ToString());
                        msg.From = new MailAddress("mohit.singlapup@gmail.com");
                        msg.Subject = TextBox2.Text;
                        msg.Body = TextBox1.Text;

                        client.Send(msg);
                        destinationaddr = rd["MNum"].ToString();
                        using (var wb = new WebClient())
                        {
                            byte[] response = wb.UploadValues("https://api.textlocal.in/send/", new NameValueCollection()
                        {
                        {"apikey" , "YYuFAJXURjA-IcD7yR2wFP50LFafuv9kXPDrbLOT6H"},
                        {"numbers" , destinationaddr},
                        {"message" , message1},
                        {"sender" , "TXTLCL"}
                        });
                            string result = System.Text.Encoding.UTF8.GetString(response);

                            

                        }
                    }
                    Label1.Text = "Success";
                }
                catch (Exception ex)
                {
                    Label1.Text = "Error= " + ex.Message;
                }   
                break;
           
            
            
            
            
            
            case 2:
                //Flag is 2 , Only SMS will Send
                //Label1.Text="2 Enter";
                string destinationaddr1= "";
                string message3= TextBox1.Text;

                String message4 = HttpUtility.UrlEncode(message3);
                while(rd.Read())
                {
                    destinationaddr1 = rd["MNum"].ToString();
                    using (var wb = new WebClient())
                    {
                        byte[] response = wb.UploadValues("https://api.textlocal.in/send/", new NameValueCollection()
                        {
                        {"apikey" , "YYuFAJXURjA-IcD7yR2wFP50LFafuv9kXPDrbLOT6H"},
                        {"numbers" , destinationaddr1},
                        {"message" , message4},
                        {"sender" , "TXTLCL"}
                        });
                        string result = System.Text.Encoding.UTF8.GetString(response);

                        Label1.Text = "You Have Successfully Sent SMS";

                    }
                }
                
                break;




            case 3:
                // Flag is 3 then only Email will be send
                //Label1.Text = "3 Enter";
                //int j= 0;
                try
                {
                    SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                    client.EnableSsl = true;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential("mohit.singlapup@gmail.com", "mohit@1948869");
                    while(rd.Read())
                    {  
                        MailMessage msg = new MailMessage();
                        msg.To.Add(rd["Email"].ToString());
                        msg.From = new MailAddress("mohit.singlapup@gmail.com");
                        msg.Subject = TextBox2.Text;
                        msg.Body = TextBox1.Text;
                        client.Send(msg);
                       // j++;
                        Label1.Text = "Success ";
                    }
                    
                }
                catch (Exception ex)
                {
                    Label1.Text = "Error= " + ex.Message;
                }



                break;
           
        }
        Label1.Visible = true;

    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(DropDownList2.SelectedValue.ToString()=="1" || DropDownList2.SelectedValue.ToString()=="3" )
        {
            Label5.Visible = TextBox2.Visible = true;
        }
        else
            Label5.Visible = TextBox2.Visible = false;
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        FormsAuthentication.SignOut();
        Response.Redirect("~/Webpages/Login.aspx");
    }
}