using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Audiobook
{
    public partial class Pay : Form
    {

        int counter;
        public Pay()
        {
            counter = 0;
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                counter += 1;
                System.Data.SqlClient.SqlConnection sql = new SqlConnection("Data Source=DESKTOP-CRV1FVM;Initial Catalog=audiobooks; Integrated Security=True");
                SqlCommand cmd = new SqlCommand("insert into paymentmethod (paymenttype,cardnumber,cardholdername,securitycode) values(@paymenttype,@cardnumber,@cardholdername,@securitycode)", sql);
                cmd.Parameters.AddWithValue("@paymenttype", checkBox1.Text);
                cmd.Parameters.AddWithValue("@cardnumber", textBox1.Text);
                cmd.Parameters.AddWithValue("@cardholdername", textBox2.Text);
                cmd.Parameters.AddWithValue("@securitycode", textBox3.Text);




                sql.Open();
                cmd.ExecuteNonQuery();
                sql.Close();
                MessageBox.Show("Successful Payment");


            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message);
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Books l = new Books();
            l.Show();

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
    

