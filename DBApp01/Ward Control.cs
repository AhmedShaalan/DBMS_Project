﻿using System;
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
    public partial class Form11 : Form
    {
        string connectStr;
        public Form11()
        {
            InitializeComponent();
            connectStr = @" Data Source = ..\..\Hospital.db";
        }

        private void Form11_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            const string sql = "select * from ward;";
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
            if (textBox1.Text == "")
            {
                MessageBox.Show("No thing to search!!");
            }
            else
            {
                string sql = "select * from ward where ward_ID=" + textBox1.Text + ";";
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
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                MessageBox.Show("No thing to Delete!!");
            }
            else
            {
                using (SQLiteConnection con = new SQLiteConnection(connectStr))
                {

                    try
                    {

                        SQLiteCommand cmd = new SQLiteCommand();
                        cmd.CommandText = @"delete from ward where ward_ID=" + textBox2.Text + ";";
                        cmd.Connection = con;


                        con.Open();

                        int i = cmd.ExecuteNonQuery();

                        if (i == 1)
                        {
                            MessageBox.Show("Deleted Successfuly ...");
                            RefreshButton.PerformClick();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
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
    }
}
