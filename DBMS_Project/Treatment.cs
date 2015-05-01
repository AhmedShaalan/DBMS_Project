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
    public partial class Treatment : Form
    {
        string connectStr;
        public Treatment()
        {
            InitializeComponent();
            connectStr = @" Data Source = ..\..\Hospital.db";
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
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox4.Text) || string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("You must fill all fields.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int checkID;
            if (!int.TryParse(textBox1.Text, out checkID) || !int.TryParse(textBox4.Text, out checkID))
            {
                MessageBox.Show("Invalid ID(s)!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

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
                        MessageBox.Show("Treatment Assigned...", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                AssignButton.Enabled = false;
                return;
            }
            AssignButton.Enabled = true;

            int checkNum;
            if (!int.TryParse(textBox2.Text, out checkNum))
            {
                MessageBox.Show("ID is numbers only!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox2.Text = "";
                return;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
