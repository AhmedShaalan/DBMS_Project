using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace DBApp01
{
    public partial class Form7 : Form
    {
        string connectStr;
        public Form7()
        {
            InitializeComponent();
            connectStr = @" Data Source = ..\..\Hospital.db";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int checkText;
            if (int.TryParse(textBox3.Text, out checkText))
            {
                MessageBox.Show("Please enter a valid name", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (!(string.IsNullOrWhiteSpace(textBox1.Text)))
            {
                int checkNum;
                if (!int.TryParse(textBox1.Text, out checkNum))
                {
                    MessageBox.Show("Please enter a valid Phone number", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (!(string.IsNullOrWhiteSpace(textBox1.Text)))
            {
                int checkNum;
                if (!int.TryParse(textBox1.Text, out checkNum))
                {
                    MessageBox.Show("Please enter a valid Phone number", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            using (SQLiteConnection con = new SQLiteConnection(connectStr))
            {

                try
                {

                    SQLiteCommand cmd = new SQLiteCommand();
                    cmd.CommandText = @"INSERT INTO nurse (nurse_name,phone,address,ward_ID) VALUES (@Name,@Phone,@Address,@Ward)";
                    cmd.Connection = con;
                    cmd.Parameters.Add(new SQLiteParameter("@Name", textBox3.Text));
                    cmd.Parameters.Add(new SQLiteParameter("@Phone", textBox1.Text));
                    cmd.Parameters.Add(new SQLiteParameter("@Address", textBox2.Text));
                    cmd.Parameters.Add(new SQLiteParameter("@Ward", textBox4.Text));
                    

                    con.Open();

                    int i = cmd.ExecuteNonQuery();

                    if (i == 1)
                    {
                        MessageBox.Show("Added a Nurse Successfuly ...", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            
            if (string.IsNullOrWhiteSpace(textBox3.Text))
            {
                SubmitButton.Enabled = false;
            }
            SubmitButton.Enabled = true;

            int checkNum;
            if (int.TryParse(textBox3.Text, out checkNum))
            {
                MessageBox.Show("Name must be text only!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox3.Text = "";
                return;
            }
        }

        private void Form7_Load(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
