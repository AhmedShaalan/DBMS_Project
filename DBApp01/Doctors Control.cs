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
    public partial class Form4 : Form
    {
        string connectStr;

        public Form4()
        {
            InitializeComponent();
            connectStr = @" Data Source = ..\..\Hospital.db";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            const string sql = "select * from doctors;";
            var conn = new SQLiteConnection(connectStr);
            try
            {
                conn.Open();
                DataSet ds = new DataSet();
                var da = new SQLiteDataAdapter(sql, conn);
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0].DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
                string sql = "select * from doctors where doc_ID=" + textBox1.Text + ";";
                var conn = new SQLiteConnection(connectStr);
                try
                {
                    conn.Open();
                    DataSet ds = new DataSet();
                    var da = new SQLiteDataAdapter(sql, conn);
                    da.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0].DefaultView;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
        }

        private void button4_Click(object sender, EventArgs e)
        {
                using (SQLiteConnection con = new SQLiteConnection(connectStr))
                {

                    try
                    {

                        SQLiteCommand cmd = new SQLiteCommand();
                        cmd.CommandText = @"delete from doctors where doc_ID=" + textBox2.Text + ";";
                        cmd.Connection = con;


                        con.Open();

                        int i = cmd.ExecuteNonQuery();

                        if (i == 1)
                        {
                            MessageBox.Show("Deleted Successfuly ...");
                            button1.PerformClick();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            SearchButton.Enabled = true;
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                SearchButton.Enabled = false;
                return;
            }

            int checkNum;
            if (!int.TryParse(textBox1.Text, out checkNum))
            {
                MessageBox.Show("ID is numbers only!");
                textBox1.Text = "";
                return;
            }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
            DeleteButton.Enabled = true;
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                DeleteButton.Enabled = false;
                return;
            }

            int checkNum;
            if (!int.TryParse(textBox2.Text, out checkNum))
            {
                MessageBox.Show("ID is numbers only!");
                textBox2.Text = "";
                return;
            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }
    }
}
