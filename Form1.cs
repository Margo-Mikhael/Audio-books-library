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

namespace Audiobook
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnlogin_Click(object sender, EventArgs e)
        {


            SqlConnection sql = new SqlConnection("Data Source=DESKTOP-CRV1FVM;Initial Catalog=audiobooks;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("select username from users", sql);

            sql.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            bool us = false;
            while (rd.Read())
            {
                String user = "" + rd["username"];
                if (user.Equals(txtusername.Text))
                {
                    us = true;
                    break;
                }
            }

            if (us == false)
            {
                MessageBox.Show("Invalid Username");
            }
            else
            {
                rd.Close();

                SqlCommand cmd2 = new SqlCommand("select password from users where username=@uname", sql);
                cmd2.Parameters.AddWithValue("@uname", txtusername.Text);

                rd = cmd2.ExecuteReader();

                if (rd.Read())
                {
                    String password = "" + rd["password"];
                    if (password.Equals(txtpassword.Text))
                    {
                        this.Hide();
                        home t = new home();
                        t.Show();
                    }

                    else
                    {
                        MessageBox.Show("Incorrect Password");

                    }
                }
            }
            sql.Close();
        }

        private void btnsignup_Click(object sender, EventArgs e)
        {
            this.Hide();
            SignUp d = new SignUp();
            d.Show();
        }
    }

}    
