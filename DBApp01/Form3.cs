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
            connectStr = @" Data Source = C:\Users\new\Desktop\DBApp01\DBApp01\Hospital.db";
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
             using (SQLiteConnection con = new SQLiteConnection(connectStr))
            {

                try
                {
                    bool gender ;

                    if(radioButton1.Checked == true)
                    gender = true;
                    else
                    gender = false;

                    SQLiteCommand cmd = new SQLiteCommand();
                    cmd.CommandText = @"INSERT INTO patient (patient_name,address,phone,age,gender,ward_ID) VALUES (@Name,@Address,@Phone,@Age,@Gender,@Ward)";
                    cmd.Connection = con;
                    cmd.Parameters.Add(new SQLiteParameter("@Name", textBox2.Text));
                    cmd.Parameters.Add(new SQLiteParameter("@Phone", textBox3.Text));
                    cmd.Parameters.Add(new SQLiteParameter("@Age", textBox4.Text));
                    cmd.Parameters.Add(new SQLiteParameter("@Address", textBox1.Text));
                    cmd.Parameters.Add(new SQLiteParameter("@Ward", textBox5.Text));
                    cmd.Parameters.Add(new SQLiteParameter("@Gender", gender ));

                    con.Open();

                    int i = cmd.ExecuteNonQuery();

                    if (i == 1)
                    {
                        MessageBox.Show("Added a Patient Successfuly ...");
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
