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
    public partial class Main : Form
    {
        
        public Main()
        {
            InitializeComponent();
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 insert = new Form2();
            insert.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 insert = new Form3();
            insert.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form5 insert = new Form5();
            insert.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form4 insert = new Form4();
            insert.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Treatment insert = new Treatment();
            insert.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form9 insert = new Form9();
            insert.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form8 insert = new Form8();
            insert.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form7 insert = new Form7();
            insert.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Form11 insert = new Form11();
            insert.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Form10 insert = new Form10();
            insert.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Form12 insert = new Form12();
            insert.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

     
    }
}
