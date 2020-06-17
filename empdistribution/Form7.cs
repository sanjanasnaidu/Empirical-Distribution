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
    public partial class Form7 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=HP\SQLEXPRESS;Initial Catalog=empirical;Integrated Security=True");
        private ListBox lb = new ListBox();
        private TextBox t = new TextBox();
        public Form7()
        {
            InitializeComponent();
            
            t.Location = new Point(366, 117);
            t.Size= new Size(190, 34);
            t.TabIndex = 9;
            this.Controls.Add(t);
            lb.Location = new Point(630, 117);
            this.Controls.Add(lb);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.t.Text != "")
            {
                int i = 1;

                Int32.TryParse(t.Text, out i);

                Random rnd = new Random();

                for (int count = 1; count <= i; count++)
                {
                    //set maxValue of random number to i
                    //change this, if you like
                    lb.Items.Add(rnd.Next(i + 1).ToString());
                }
                foreach (var item in lb.Items)
                {
                    int idx = dataGridView1.Rows.Add();

                    dataGridView1.Rows[idx].Cells["Column2"].Value = item;

                }
                int sum = 0;
                for (i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    sum += Convert.ToInt32(dataGridView1.Rows[i].Cells["Column2"].Value);
                }
                label3.Text = sum.ToString();
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    row.Cells["Column3"].Value = (System.Convert.ToDecimal(row.Cells["Column2"].Value) / System.Convert.ToDecimal(label3.Text.ToString()));
                }
                double cf = 0;
                double currentValue = 0;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    currentValue = Convert.ToDouble(row.Cells["Column3"].Value);
                    cf += currentValue;
                    row.Cells["Column4"].Value = cf.ToString();
                }
            }
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            this.dataGridView1.Rows[e.RowIndex].Cells["Column1"].Value = (e.RowIndex + 1).ToString();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("DO YOU REALLY WANT TO EXIT???","CLOSING...",MessageBoxButtons.YesNo,MessageBoxIcon.Exclamation);
            if(dialog==DialogResult.Yes)
            {
                Application.Exit();
            }
           
        }
    }
}
