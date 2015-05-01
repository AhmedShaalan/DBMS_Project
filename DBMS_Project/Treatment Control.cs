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

namespace DBMS_Project
{
    public partial class Treatment_Form : Form
    {
        string connectStr;
        public Treatment_Form()
        {
            InitializeComponent();
            connectStr = @" Data Source = ..\..\Hospital.db";
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
             const string sql = "select * from treatment;";
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
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            string sql = "select * from treatment where treat_id=" + textBox1.Text + ";";
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
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            using (SQLiteConnection con = new SQLiteConnection(connectStr))
            {

                try
                {

                    SQLiteCommand cmd = new SQLiteCommand();
                    cmd.CommandText = @"delete from treatment where treat_id=" + textBox2.Text + ";";
                    cmd.Connection = con;


                    con.Open();

                    int i = cmd.ExecuteNonQuery();

                    if (i == 1)
                    {
                        MessageBox.Show("Deleted Successfuly ...", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        RefreshButton.PerformClick();
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
                MessageBox.Show("ID is numbers only!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("ID is numbers only!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox2.Text = "";
                return;
            }
        }
    }
}
