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
    public partial class Form6 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=HP\SQLEXPRESS;Initial Catalog=empirical;Integrated Security=True");
        private ListBox lb = new ListBox();
        private TextBox t = new TextBox();
        public Form6()
        {
            InitializeComponent();
           
        }
    }

}
