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
                string[] format = new string[] { "yyyy-MM-dd HH:mm:ss" };
                DateTime datetime;

                if (!DateTime.TryParseExact(textBox2.Text, format, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.NoCurrentDateDefault, out datetime))
                {
                    MessageBox.Show("Please enter a vaild Time", "", MessageBoxButtons.OK, MessageBoxIcon.Error); 
                    return;
                }

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
                return;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(textBox1.Text, "^[a-zA-Z]+$"))
            {
                MessageBox.Show("Please enter a valid type", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Text = "";
                return;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
