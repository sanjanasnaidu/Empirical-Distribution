using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace empirical111
{
    public partial class Form3 : Form
    {
        String con = @"Data Source=HP\SQLEXPRESS;Initial Catalog=empirical;Integrated Security=True";
        public Form3()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 back = new Form2();
            back.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form4 reg = new Form4();
            reg.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection sqlcon = new SqlConnection(con);
            string userid = textBox1.Text;
            string password = textBox2.Text;
            SqlCommand cmd = new SqlCommand("select username,password from register1 where username='" + textBox1.Text + "'and password='" + textBox2.Text + "'", sqlcon);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Login sucess Welcome to Homepage");
                Form7 reg = new Form7();
                reg.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid Login please check username and password");
            }
            sqlcon.Close();

        }
    }
}
