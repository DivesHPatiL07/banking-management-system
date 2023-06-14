using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bank_Management_System
{
    public partial class createAcForm : Form
    {
        SqlConnection con;
        SqlCommand com;
        SqlDataReader dr;
        DataTable dt;
        SqlDataAdapter sda;
        public createAcForm()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void createAcForm_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["myC_String"].ConnectionString);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string gender;
            //if (maleRB.Checked == true)
            //{
            //    gender = "Male";
            //}
            //else if(femaleRB.Checked == true)
            //{
            //    gender = "Female";
            //}
            //else
            //{
            //    gender = "Other";
            //}
           
            //con.Open();
            //com = new SqlCommand("createAC_Data", con);
            //com.CommandType = CommandType.StoredProcedure;
            //com.Parameters.AddWithValue("@CUSTOMMER_NAME", cNameTb.Text);
            //com.Parameters.AddWithValue("@AC_NUMBER", acNoTb.Text);
            //com.Parameters.AddWithValue("@AC_TYPE", AcTypeCB.Text);
            //com.Parameters.AddWithValue("@GENDER", gender);
            //com.Parameters.AddWithValue("@CUSTO_ADDRESS", addressTb.Text);
            //com.Parameters.AddWithValue("@EMAIL_ADDRESS", emailAddressTb.Text);
            //com.Parameters.AddWithValue("@DEPOSIT_AMONUT", deAmountTb.Text);
            //com.ExecuteNonQuery();
            //MessageBox.Show("Account Created Successfully");
            
            //con.Close();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void deAmountTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void emailAddressTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void addressTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void otherRB_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void femaleRB_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void maleRB_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void AcTypeCB_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void cNameTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
