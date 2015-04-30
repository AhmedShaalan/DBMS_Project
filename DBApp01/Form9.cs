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
    public partial class Form9 : Form
    {
        string connectStr;
        public Form9()
        {
            InitializeComponent();
            connectStr = @" Data Source = C:\Users\new\Desktop\DBApp01\DBApp01\Hospital.db";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SQLiteConnection con = new SQLiteConnection(connectStr))
            {

                try
                {

                    SQLiteCommand cmd = new SQLiteCommand();
                    cmd.CommandText = @"INSERT INTO drug (drug_name,drug_quantity,drug_attributes) VALUES (@Name,@Qua,@Attr)";
                    cmd.Connection = con;
                    cmd.Parameters.Add(new SQLiteParameter("@Attr", textBox1.Text));
                    cmd.Parameters.Add(new SQLiteParameter("@Qua", textBox2.Text));
                    cmd.Parameters.Add(new SQLiteParameter("@Name", textBox3.Text));

                    con.Open();

                    int i = cmd.ExecuteNonQuery();

                    if (i == 1)
                    {
                        MessageBox.Show("Added a New Drug Successfuly ...");
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
