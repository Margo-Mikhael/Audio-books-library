using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Audiobook
{
    public partial class SignUp : Form
    {
        int counter;
        public SignUp()
        {
            counter = 0;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                counter += 1;
                SqlConnection sql = new SqlConnection("Data Source=DESKTOP-CRV1FVM;Initial Catalog=audiobooks;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("insert into users (fname,mname,lname,phoneno,username,password,gender,birthdate) values(@fname,@mname,@lname,@phoneno,@username,@password,@gender,@birthdate)", sql);
                cmd.Parameters.AddWithValue("@fname", txtfirstname.Text);
                cmd.Parameters.AddWithValue("@mname", txtmiddlename.Text);
                cmd.Parameters.AddWithValue("@lname", txtlastname.Text);
                cmd.Parameters.AddWithValue("@phoneno", txtphoneno.Text);
                cmd.Parameters.AddWithValue("@username", txtusername.Text);
                cmd.Parameters.AddWithValue("@password", txtpassword.Text);
                cmd.Parameters.AddWithValue("@gender", txtgender.Text);
                cmd.Parameters.AddWithValue("@birthdate", txtbirthdate.Text);

                sql.Open();
                cmd.ExecuteNonQuery();
                sql.Close();
                MessageBox.Show("User Registered");
                this.Hide();
                Form1 h = new Form1();
                h.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 b = new Form1();
            b.Show();
        }
    }


}

