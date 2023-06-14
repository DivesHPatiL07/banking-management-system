using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Xml.Linq;

namespace Bank_Management_System
{
    
    public partial class Home_Page1 : Form
    {
        public static string userLoginID = loginPage.emailtxt;
        public static string userPassword = loginPage.passwordtxt;

        public static string account_No; 

        SqlConnection con;
        SqlCommand com, fName;
        SqlDataReader dr;
        DataTable dt;
        public Home_Page1()
        {
            InitializeComponent();
        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        


        private void button1_Click(object sender, EventArgs e)
        {
            label32.Visible = false;
            label11.Visible = false;
            label35.Visible = true;
            label25.Visible = false;
            label24.Visible = false;
            label23.Visible = false;
            label22.Visible = false;
            label21.Visible = false;
            label20.Visible = false;
            label18.Visible = false;
            label17.Visible = false;
            label16.Visible = false;
            label15.Visible = false;
            label14.Visible = false;
            label13.Visible = false;
            //createAcForm obj = new createAcForm();
            //obj.Show();

            label10.Visible = true;
            label6.Visible = true;
            cNameTb.Visible = true;
            label3.Visible = true;
            textBox1.Visible = true;
            label4.Visible = true;
            AcTypeCB.Visible = true;
            label5.Visible = true;
            maleRB.Visible = true;
            femaleRB.Visible = true;
            otherRB.Visible = true;
            label7.Visible = true;
            addressTb.Visible = true;
            label8.Visible = true;
            emailAddressTb.Visible = true;
            label9.Visible = true;
            depositAM.Visible = true;
            button1.Visible = true;
        }

        private void logOutBtn_Click(object sender, EventArgs e)
        {
           
            
            loginPage  obj2 = new loginPage();
            this.Hide();
            obj2.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string gender;
            if (maleRB.Checked == true)
            {
                gender = "Male";
            }
            else if (femaleRB.Checked == true)
            {
                gender = "Female";
            }
            else
            {
                gender = "Other";
            }
            if (cNameTb.Text == "")
            {
                MessageBox.Show("customer Name is required");
                return;
            }
            if (textBox1.Text == "")
            {
                MessageBox.Show("choose your Account Number to press any key");
                return;
            }
            if(AcTypeCB.Text == "")
            {
                MessageBox.Show("Select your Account Type (Saving Account or Current Account)");
                return;
            }
            if (maleRB.Checked == false && femaleRB.Checked == false && otherRB.Checked == false)
            {
                MessageBox.Show("Choose Your Gender");
                return;
            }
            if (addressTb.Text == "")
            {
                MessageBox.Show("Address is required");
                return;
            }
            if (emailAddressTb.Text == "")
            {
                MessageBox.Show("Email Address is Required");
                return;
            }
            //int amd = Convert.ToInt32(depositAM.Text); 
            
            if(Convert.ToInt32(depositAM.Text) < 500 )
            {
                MessageBox.Show("Deposit Amount minimum 500");
                return;
            }
            try
            {
                con.Open();
                com = new SqlCommand("createAC_Data", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@CUSTOMMER_NAME", cNameTb.Text);
                com.Parameters.AddWithValue("@AC_NUMBER", textBox1.Text);
                com.Parameters.AddWithValue("@AC_TYPE", AcTypeCB.Text);
                com.Parameters.AddWithValue("@GENDER", gender);
                com.Parameters.AddWithValue("@CUSTO_ADDRESS", addressTb.Text);
                com.Parameters.AddWithValue("@EMAIL_ADDRESS", emailAddressTb.Text);
                com.Parameters.AddWithValue("@DEPOSIT_AMONUT", depositAM.Text);
                com.ExecuteNonQuery();
                MessageBox.Show("Account Created Successfully");
                label32.Visible = true;

                
            }
            catch(Exception ex)
            {
                
                MessageBox.Show("Account number is already exist");
            }
            finally
            {
                con.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label11.Visible = true;
            label32.Visible = false;
            label10.Visible = false;
            label6.Visible = false;
            cNameTb.Visible =false;
            label3.Visible = false;
            textBox1.Visible = false;
            label4.Visible = false;
            AcTypeCB.Visible = false;
            label5.Visible = false;
            maleRB.Visible = false;
            femaleRB.Visible = false;
            otherRB.Visible = false;
            label7.Visible = false;
            addressTb.Visible = false;
            label8.Visible = false;
            emailAddressTb.Visible = false;
            label9.Visible = false;
            depositAM.Visible = false;
            button1.Visible = false;
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void acNoTb_TextChanged(object sender, EventArgs e)
        {
            

        }

        private void acNumberInt_ValueChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int num = rnd.Next();
            textBox1.Text = num.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label11.Visible = false;
            textBox2.Visible= true;
            button4.Visible= true;
            label12.Visible= true;
            button5.Visible= true;
            label32.Visible = false;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox2.Visible = false;
            button4.Visible = false;
            label12.Visible = false;
            button5.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            try
            {
                con.Open();
                string querry = "select * from createAcTable where acNumber = " + textBox2.Text + "";

                SqlDataAdapter sda = new SqlDataAdapter(querry, con);
                DataTable dataTable = new DataTable();
                sda.Fill(dataTable);
                if (dataTable.Rows.Count > 0)
                {
                    MessageBox.Show("Account Added");
                    account_No = textBox2.Text;
                    button3.Text = "Account Added";
                    button3.Enabled = false;
                    button3.ForeColor = Color.Green;
                    textBox2.Visible = false;
                    button4.Visible = false;
                    label12.Visible = false;
                    button5.Visible = false;
                    button6.Enabled = true;
                    button7.Enabled = true;
                    button9.Enabled = true;
                    button12.Enabled = true;

                }
                else
                {
                    MessageBox.Show("please check your number");
                }

                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
           
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            textBox2.Visible = false;
            button4.Visible = false;
            label12.Visible = false;
            button5.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            account_No = textBox2.Text;
            label32.Visible= false;
            label10.Visible = false;
            label6.Visible = false;
            cNameTb.Visible = false;
            label3.Visible = false;
            textBox1.Visible = false;
            label4.Visible = false;
            AcTypeCB.Visible = false;
            label5.Visible = false;
            maleRB.Visible = false;
            femaleRB.Visible = false;
            otherRB.Visible = false;
            label7.Visible = false;
            addressTb.Visible = false;
            label8.Visible = false;
            emailAddressTb.Visible = false;
            label9.Visible = false;
            depositAM.Visible = false;
            button1.Visible = false;

            label25.Visible = true;
            label24.Visible= true;
            label23.Visible= true;
            label22.Visible= true;
            label21.Visible = true;
            label20.Visible = true;
            label18.Visible= true;
            label17.Visible= true;
            label16.Visible= true;
            label15.Visible= true;
            label14.Visible= true;
            label13.Visible= true;

            con.Open();
            com = new SqlCommand("select * from createAcTable where acNumber = " + account_No + "", con);
            dr = com.ExecuteReader();
            
            if (dr.Read())
            {
                label25.Text = dr[1].ToString();
                label24.Text = dr[2].ToString();
                label23.Text = dr[3].ToString();
                label22.Text = dr[4].ToString();
                label21.Text = dr[5].ToString();
                label20.Text = dr[6].ToString();
            }
                
                
            
            con.Close();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            label32.Visible = false;
            account_No = textBox2.Text;
            con.Open();
            com = new SqlCommand("select * from createAcTable where acNumber = " + account_No + "", con);
            dr = com.ExecuteReader();

            if (dr.Read())
            {
                label26.Visible= true;
                label27.Visible= true;
                button8.Visible= true;
                label27.Text = dr[7].ToString();
            }

                //MessageBox.Show("error");
          
                con.Close();
            
            


            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            label26.Visible= false;
            label27.Visible = false;
            button8.Visible = false;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            label32.Visible = false;
            label28.Visible = true;
            textBox3.Visible = true;
            button11.Visible = true;
            button10.Visible = true;
            
        }

        private void button10_Click(object sender, EventArgs e)
        {
                label28.Visible= false;
                textBox3.Visible= false;
                button11.Visible= false;
                button10.Visible= false;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            account_No = textBox2.Text;
            con.Open();
            com = new SqlCommand("updatedepositBalance", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@AC_NO", account_No);
            com.Parameters.AddWithValue("@DEPOSIT_AMOUNT", textBox3.Text);
            com.ExecuteNonQuery();
            MessageBox.Show("Cash has been added");
            con.Close();




        }

        private void button12_Click(object sender, EventArgs e)
        {
            label30.Visible = true;
            textBox5.Visible = true;
            //label29.Visible = true;
            //textBox4.Visible = true;
            button14.Visible = true;
            button13.Visible = true;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (textBox5.Text == "")
            {
                MessageBox.Show("Please Enter Account Number ");
                return;
            }

            try
            {
                con.Open();
                string querry = "select * from createAcTable where acNumber = " + textBox5.Text + "";
                SqlDataAdapter sda = new SqlDataAdapter(querry, con);
                DataTable dataTable = new DataTable();
                sda.Fill(dataTable);
                if (dataTable.Rows.Count > 0)
                {
                    com = new SqlCommand("select * from createAcTable where acNumber = " + textBox5.Text + "", con);
                    dr = com.ExecuteReader();
                    if (dr.Read())
                    {
                        groupBox1.Visible = true;
                        label36.Visible = true;
                        label33.Visible = true;
                        label34.Visible = true;
                        label31.Visible = true;
                        button15.Visible = true;
                        button16.Visible = true;
                        label29.Visible = true;
                        textBox4.Visible = true;
                        label33.Text = dr[1].ToString();
                        label34.Text = dr[3].ToString();
                    }


                }
                else
                {
                    groupBox1.Visible = false;
                    label36.Visible = false;
                    label33.Visible = false;
                    label34.Visible = false;
                    label31.Visible = false;
                    button15.Visible = false;
                    button16.Visible = false;
                    MessageBox.Show("Account Number is Invalid");

                }
            }
            catch
            {
                groupBox1.Visible = false;
                label36.Visible = false;
                label33.Visible = false;
                label34.Visible = false;
                label31.Visible = false;
                button15.Visible = false;
                button16.Visible = false;
                MessageBox.Show("Account Number is Invalid");
            }
            finally { con.Close(); }    
                
               

            //if (textBox5.Text.Length >0)
            //{
            //    try
            //    {
            //        con.Open();
            //        com = new SqlCommand("select * from createAcTable where acNumber = " + textBox5.Text + "", con);
            //        dr = com.ExecuteReader();

            //        if (dr.Read())
            //        {
            //            groupBox1.Visible = true;
            //            label36.Visible = true;
            //            label33.Visible = true;
            //            label34.Visible = true;
            //            label31.Visible = true;
            //            button15.Visible = true;
            //            button16.Visible = true;
            //            label29.Visible = true;
            //            textBox4.Visible = true;
            //            label33.Text = dr[1].ToString();

            //            label31.Text = dr[3].ToString();

            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show("Account Number is Invalid");
            //    }
            //    finally
            //    {
            //        con.Close();
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Please Enter valid Account Number");
            //}


           
           




        }

        private void button13_Click(object sender, EventArgs e)
        {
            label30.Visible = false;
            textBox5.Visible = false;
            label29.Visible = false;
            textBox4.Visible = false;
            button14.Visible = false;
            button13.Visible = false;
        }

        private void label31_Click(object sender, EventArgs e)
        {

        }

        private void label34_Click(object sender, EventArgs e)
        {

        }

        private void label32_Click(object sender, EventArgs e)
        {

        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                MessageBox.Show("Please Enter Amount");
                return;
            }
            con.Open();
            SqlCommand com2 = new SqlCommand("select * from createAcTable where acNumber = " + account_No + "", con);
            dr = com2.ExecuteReader();
            if (dr.Read())
            {
                string amt = dr[7].ToString();
                string amt2 = textBox4.Text;
                con.Close();

                if ( Convert.ToInt32(amt) >= Convert.ToInt32(amt2))
                {
                    account_No = textBox2.Text;
                    con.Open();
                    com = new SqlCommand("updatedepositBalance", con);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@AC_NO", textBox5.Text);
                    com.Parameters.AddWithValue("@DEPOSIT_AMOUNT", textBox4.Text);
                    com.ExecuteNonQuery();
                    com = new SqlCommand("updateNewBalance", con);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@AC_NO", account_No);
                    com.Parameters.AddWithValue("@DEPOSIT_AMOUNT", textBox4.Text);
                    com.ExecuteNonQuery();
                    MessageBox.Show("Transaction Completed Successfully");

                    con.Close();
                }
                else
                {
                    MessageBox.Show("Insufficient bank balance");
                }
            }
            
        }

        private void button16_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            label36.Visible = false;
            label33.Visible = false;
            label34.Visible = false;
            label31.Visible = false;
            button15.Visible = false;
            button16.Visible = false;
        }

        private void label33_Click(object sender, EventArgs e)
        {

        }

        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void Home_Page1_Load(object sender, EventArgs e)
        {
            button2.Focus();
            label11.Visible = true;
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["myC_String"].ConnectionString);
            con.Open();
            com = new SqlCommand("select * from registration_table where eMail = ('" + userLoginID + "') and confirmPassword = ('" + userPassword + "') ", con);
            dr = com.ExecuteReader();
            if(dr.Read())
            {
                string userFirstName = dr[1].ToString();
                //string userLastName = dr[2].ToString();
                label1.Text = "Hello,";
                label2.Text = userFirstName;
            }
           
            con.Close();
        }
    }
}
