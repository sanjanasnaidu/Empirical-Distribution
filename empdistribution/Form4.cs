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
    public partial class Form4 : Form
    {
        String con = @"Data Source=HP\SQLEXPRESS;Initial Catalog=empirical;Integrated Security=True";
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 back = new Form2();
            back.Show();
            back.Close();
        }
       
        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlcon = new SqlConnection(con))
            {
                sqlcon.Open();
                SqlCommand sqlcmd = new SqlCommand("register2",sqlcon);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@empid", textBox1.Text.Trim());
                sqlcmd.Parameters.AddWithValue("@empname",textBox2.Text.Trim());
                sqlcmd.Parameters.AddWithValue("@username", textBox3.Text.Trim());
                sqlcmd.Parameters.AddWithValue("@password", textBox4.Text.Trim());
                sqlcmd.Parameters.AddWithValue("@email", textBox5.Text.Trim());
                sqlcmd.ExecuteNonQuery();
                MessageBox.Show("REGISTERED SUCCESFULLY!!!");
                clear();
                Form3 log = new Form3();
                log.Show();
                this.Hide();
            }

        }
        void clear()
        {
            textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = "";
        }
    }
}
