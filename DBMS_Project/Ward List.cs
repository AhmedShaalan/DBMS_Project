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
    public partial class Form8 : Form
    {
        string connectStr;
        public Form8()
        {
            InitializeComponent();
            connectStr = @" Data Source = ..\..\Hospital.db";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SQLiteConnection con = new SQLiteConnection(connectStr))
            {

                try
                {

                    SQLiteCommand cmd = new SQLiteCommand();
                    cmd.CommandText = @"INSERT INTO ward (ward_type,period) VALUES (@Type,@Time)";
                    cmd.Connection = con;
                    cmd.Parameters.Add(new SQLiteParameter("@Type", textBox1.Text));
                    cmd.Parameters.Add(new SQLiteParameter("@Time", Convert.ToDateTime(textBox2.Text)));
                    

                    con.Open();

                    int i = cmd.ExecuteNonQuery();

                    if (i == 1)
                    {
                        MessageBox.Show("Added a New Ward Successfuly ...", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            button2.Enabled = true;
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                button2.Enabled = false;
            }

            int checkText;
            if (int.TryParse(textBox1.Text, out checkText))
            {
                MessageBox.Show("Please enter a valid type", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
