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
    public partial class Form6 : Form
    {
        string connectStr;
        public Form6()
        {
            InitializeComponent();
            connectStr = @" Data Source = C:\Users\new\Desktop\DBApp01\DBApp01\Hospital.db";
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            //Paients List
            string sql = "select patient_ID, patient_name from patient;";
            var conn = new SQLiteConnection(connectStr);
            conn.Open();
            try
            {
                
                DataSet ds = new DataSet();
                var da = new SQLiteDataAdapter(sql, conn);
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0].DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            // Doctors list
            sql = "select doc_ID,doc_name from doctors;";
            try
            {
                
                DataSet ds = new DataSet();
                var da = new SQLiteDataAdapter(sql, conn);
                da.Fill(ds);
                dataGridView2.DataSource = ds.Tables[0].DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SQLiteConnection con = new SQLiteConnection(connectStr))
            {
                try
                {

                    SQLiteCommand cmd = new SQLiteCommand();
                    cmd.CommandText = @"INSERT INTO treatment (doc_ID,patient_ID,description,drug_ID) VALUES (@Dc_id,@Pa_id,@Des,@Drug)";
                    cmd.Connection = con;
                    cmd.Parameters.Add(new SQLiteParameter("@Dc_id", textBox1.Text));
                    cmd.Parameters.Add(new SQLiteParameter("@Pa_id", textBox2.Text));
                    cmd.Parameters.Add(new SQLiteParameter("@Des", textBox3.Text));
                    cmd.Parameters.Add(new SQLiteParameter("@Drug", textBox4.Text));
                    con.Open();
                    int i = cmd.ExecuteNonQuery();

                    if (i == 1)
                    {
                        MessageBox.Show("Treatment is Being Given ...");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
