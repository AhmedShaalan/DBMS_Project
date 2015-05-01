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
    public partial class Form3 : Form
    {
        string connectStr;
        public Form3()
        {
            InitializeComponent();
            connectStr = @" Data Source = ..\..\Hospital.db";
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Please enter a name!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int checkText;
            if (int.TryParse(textBox2.Text, out checkText))
            {
                MessageBox.Show("Please enter a valid name", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (!(string.IsNullOrWhiteSpace(textBox3.Text)))
            {
                int checkNum;
                if (!int.TryParse(textBox3.Text, out checkNum))
                {
                    MessageBox.Show("Please enter a valid Phone number", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }


            if (string.IsNullOrWhiteSpace(textBox4.Text))
            {
                MessageBox.Show("Please enter an age!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int checkAge;
            if (!int.TryParse(textBox4.Text, out checkAge))
            {
                MessageBox.Show("Please enter a valid age!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!(MaleRB.Checked == true || FemaleRB.Checked == true))
            {
                MessageBox.Show("Please Select gender!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            


            using (SQLiteConnection con = new SQLiteConnection(connectStr))
            {

                string gender;

                if (MaleRB.Checked == true)
                    gender = "M";
                else
                    gender = "F";

                try
                {

                    SQLiteCommand cmd = new SQLiteCommand();
                    cmd.CommandText = @"INSERT INTO patient (patient_name,address,phone,age,gender,ward_ID) VALUES (@Name,@Address,@Phone,@Age,@Gender,@Ward)";
                    cmd.Connection = con;
                    cmd.Parameters.Add(new SQLiteParameter("@Name", textBox2.Text));
                    cmd.Parameters.Add(new SQLiteParameter("@Phone", textBox3.Text));
                    cmd.Parameters.Add(new SQLiteParameter("@Age", textBox4.Text));
                    cmd.Parameters.Add(new SQLiteParameter("@Address", textBox1.Text));
                    cmd.Parameters.Add(new SQLiteParameter("@Ward", textBox5.Text));
                    cmd.Parameters.Add(new SQLiteParameter("@Gender", gender));

                    con.Open();

                    int i = cmd.ExecuteNonQuery();

                    if (i == 1)
                    {
                        MessageBox.Show("Added a Patient Successfuly ...", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            SubmitButton.Enabled = true;
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                SubmitButton.Enabled = false;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                SubmitButton.Enabled = false;
            }
            SubmitButton.Enabled = true;

            int checkNum;
            if (int.TryParse(textBox2.Text, out checkNum))
            {
                MessageBox.Show("Name must be text only!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox2.Text = "";
                return;
            }
        }

    }
}
