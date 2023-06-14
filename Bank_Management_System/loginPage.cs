using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.ComponentModel.Design;
using System.Security.Cryptography.X509Certificates;

namespace Bank_Management_System
{
    

    public partial class loginPage : Form
    {
        public static string emailtxt;
        public static string passwordtxt;
        SqlConnection con;
        SqlCommand com;
        SqlDataReader dr;
        DataTable dt;
        SqlDataAdapter sda;
        public string email;
        public loginPage()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            pictureBox2.Location = new Point(725, 158);

        }

        private void label13_Click(object sender, EventArgs e)
        {
            pictureBox2.Location = new Point(415, 158);
        }

        private void loginPage_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["myC_String"].ConnectionString);

        }
       
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (RFNametb.Text == "")
            {
                validFName.Visible = true;
                RFNametb.Focus();
                return;
            }


            if (RLNameTb.Text == "")
            {
                LNameValidMsg.Visible = true;
                LNameValidMsg.Focus();
                return;

            }
            System.Text.RegularExpressions.Regex Emailregex = new System.Text.RegularExpressions.Regex("^\\S+@\\S+\\.\\S+$");

            if (REMailTb.Text=="")
            {
                MessageBox.Show("required Email");

                if (Emailregex.IsMatch(REMailTb.Text))
                {

                }
                else
                {
                    invalilEmailmsg.Visible = true;
                }
                return;
            }
            if (createPTb.Text == "")
            {
                requiredPass.Visible= true;
                return;
            }
            if (confirmPTb.Text == "")
            {
                passmismatchvalid.Visible= true;
                return;
            }
            else
            {
                if (confirmPTb.Text == createPTb.Text)
                {

                }
                else
                {
                    passmismatchvalid.Visible = true;
                    return;
                }
            }
            con.Open();
            com = new SqlCommand("registerData", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@fName", RFNametb.Text);
            com.Parameters.AddWithValue("@lName", RLNameTb.Text);
            com.Parameters.AddWithValue("@EMAIL", REMailTb.Text);
            com.Parameters.AddWithValue("@CREATEPASS", createPTb.Text);
            com.Parameters.AddWithValue("@CONFIRMPASS", confirmPTb.Text);            
            com.ExecuteNonQuery();
            MessageBox.Show("Registration Sucessfully");
            con.Close();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {

            if (lMailTb.Text == "")
            {
                emailRequired.Visible = true;
                return;
            }
            if (lPassTb.Text == "")
            {
                passRequired.Visible = true;
                return;
            }
            
            if (adminCheckBox.Checked == true)
            {
                if (lMailTb.Text == "admin" && lPassTb.Text == "bankAdmin")
                {
                    adminPage objj = new adminPage();
                    objj.Show();
                }
                else
                {
                    MessageBox.Show("Invalid Admin ID or Password");
                }
            }
            else
            { 
                con.Open();
                string querry = "select * from registration_table where eMail = '" + lMailTb.Text + "' and confirmPassword = '" + lPassTb.Text + "' ";
                SqlDataAdapter sda = new SqlDataAdapter(querry,con);
                DataTable dataTable = new DataTable();
                sda.Fill(dataTable);
                if(dataTable.Rows.Count > 0)
                {
                    emailtxt = lMailTb.Text;
                    passwordtxt = lPassTb.Text;
                    MessageBox.Show("Login Successfully");
                    Home_Page1 hm = new Home_Page1();
                    hm.ShowDialog();
                    this.Hide();

                }
                else
                {
                    MessageBox.Show("Invalid E-Mail Address or Password");
                }
                con.Close();
            }                   
            
                                 
        }

        private void RFNametb_TextChanged(object sender, EventArgs e)
        {
            if (RFNametb.Text.Length>0)
            {
                validFName.Visible = false;
            }
        }

        private void validFName_Click(object sender, EventArgs e)
        {
            
        }

        private void RLNameTb_TextChanged(object sender, EventArgs e)
        {
            if (RLNameTb.Text.Length > 0)
            {
                LNameValidMsg.Visible= false;
            }
        }

        private void REMailTb_TextChanged(object sender, EventArgs e)
        {
            System.Text.RegularExpressions.Regex Emailregex = new System.Text.RegularExpressions.Regex("^\\S+@\\S+\\.\\S+$");

            if (Emailregex.IsMatch(REMailTb.Text))
            {
              
                invalilEmailmsg.Visible = false;

            }
            else
            {
                invalilEmailmsg.Visible = true;

            }
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void createPTb_TextChanged(object sender, EventArgs e)
        {
            if(createPTb.Text.Length>0)
            {
                requiredPass.Visible= false;
            }
        }

        private void confirmPTb_TextChanged(object sender, EventArgs e)
        {
            if(createPTb.Text!=confirmPTb.Text)
            {
                passmismatchvalid.Visible = true;
            }
            else
            {
                passmismatchvalid.Visible = false;
            }
        }

        private void label14_Click_1(object sender, EventArgs e)
        {
            
        }

        private void lMailTb_TextChanged(object sender, EventArgs e)
        {
            System.Text.RegularExpressions.Regex Emailregex = new System.Text.RegularExpressions.Regex("^\\S+@\\S+\\.\\S+$");
            if (lMailTb.Text.Length > 0)
            {
                emailRequired.Visible = false;
                
            }
            if (Emailregex.IsMatch(lMailTb.Text))
            {
               
                
                loginEMailValid.Visible = false;

            }
            else
            {
                loginEMailValid.Visible = true;

            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void lPassTb_TextChanged(object sender, EventArgs e)
        {
            if (lPassTb.Text.Length > 0)
            {
                passRequired.Visible= false;
            }
        }
    }
}
