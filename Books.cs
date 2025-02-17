using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Media;
using System.Threading;
using System.Media;

namespace Audiobook
{
    public partial class Books : Form
    {
     
        int counter;
        public Books()
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
                SqlCommand cmd = new SqlCommand("insert into book (BookName,Edition,Mp3,date) values(@BookName,@Edition,@Mp3,@date)", sql);
                cmd.Parameters.AddWithValue("@BookName", txt1.Text);
                cmd.Parameters.AddWithValue("@Edition", txt2.Text);
                cmd.Parameters.AddWithValue("@Mp3", com1.Text);
                cmd.Parameters.AddWithValue("@date", dateTimePicker1.Text);




                sql.Open();
                cmd.ExecuteNonQuery();
                sql.Close();
                MessageBox.Show("Confirmed");
                this.Hide();
                Pay h = new Pay();
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
            home p = new home();
            p.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {

                System.Media.SoundPlayer player = new System.Media.SoundPlayer();
                player.SoundLocation = com1.Text;
                player.Load();
                player.PlaySync();

            }
            catch (Win32Exception)
            {
                MessageBox.Show("ex.Message");
            }
        }

        private void Play3_Click(object sender, EventArgs e)
        {

        }

      


        SoundPlayer sound1 = new SoundPlayer("1.wav");
        SoundPlayer sound2 = new SoundPlayer("2.wav");
        SoundPlayer sound3 = new SoundPlayer("3.wav");
        SoundPlayer sound4 = new SoundPlayer("4.wav");
        SoundPlayer sound5 = new SoundPlayer("5.wav");
        SoundPlayer sound6 = new SoundPlayer("6.wav");

        private void PLAY1_Click(object sender, EventArgs e)
        {
            sound1.Play();
        }

        private void STOP1_Click(object sender, EventArgs e)
        {
            sound1.Stop();
        }

        private void PLAY2_Click(object sender, EventArgs e)
        {
            sound2.Play();
        }

        private void STOP2_Click(object sender, EventArgs e)
        {
            sound2.Stop();
        }

        private void PLAY3_Click_1(object sender, EventArgs e)
        {
            sound3.Play();
        }

        private void STOP3_Click(object sender, EventArgs e)
        {
            sound3.Stop();
        }

        private void PLAY4_Click(object sender, EventArgs e)
        {
            sound4.Play();
        }

        private void STOP4_Click(object sender, EventArgs e)
        {
            sound4.Stop();
        }

        private void PLAY5_Click(object sender, EventArgs e)
        {
            sound5.Play();
        }

        private void STOP5_Click(object sender, EventArgs e)
        {
            sound5.Stop();
        }

        private void PLAY6_Click(object sender, EventArgs e)
        {
            sound6.Play();
        }

        private void STOP6_Click(object sender, EventArgs e)
        {
            sound6.Stop();
        }
    }
}

