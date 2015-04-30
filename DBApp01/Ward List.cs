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
                        MessageBox.Show("Added a New Ward Successfuly ...");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }

        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
