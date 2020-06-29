using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;


namespace swiftdb
{

    public partial class srchForm : Form
    {

        
        public srchForm()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string constring = "datasource=localhost;database=swiftdb;username=root;password=;SslMode=none;";

            MySqlDataAdapter adapt;
            DataTable dt;

            MySqlConnection con = new MySqlConnection(constring);
            if (firstname.Text == "")
            {
                adapt = new MySqlDataAdapter("select * from employee where Contact='" + empContact.Text + "'", con);
            }
            else if (empContact.Text == "")
            {
                adapt = new MySqlDataAdapter("select * from employee where firstName like '" + firstname.Text + "%'", con);

            }
            else
            {
                adapt = new MySqlDataAdapter("select * from employee where firstName like '" + firstname.Text + "%' And " +
                    "Contact like'" + empContact.Text + "'", con);
            }
            dt = new DataTable();

            adapt.Fill(dt);
            dataGridView2.DataSource = dt;
            con.Close();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            updateForm f1 = new updateForm();
            string f, l, c, a, s, id;

            
            try
            {
                string data = dataGridView2.SelectedCells[5].Value.ToString();
                f = dataGridView2.CurrentRow.Cells[0].Value.ToString();
                l = dataGridView2.CurrentRow.Cells[1].Value.ToString();
                c = dataGridView2.CurrentRow.Cells[2].Value.ToString();
                s = dataGridView2.CurrentRow.Cells[3].Value.ToString();
                a = dataGridView2.CurrentRow.Cells[4].Value.ToString();
                id = dataGridView2.CurrentRow.Cells[5].Value.ToString();

                int emp = Convert.ToInt32(data);
                if (emp >= 1)
                {
                    f1.values(f, l, c, a, s,id);

                    f1.ShowDialog();
                }
        
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }


        private void button3_Click(object sender, EventArgs e)
        {
            string constring = "datasource=localhost;database=swiftdb;username=root;password=;SslMode=none;";
            MySqlDataAdapter adapt;
            DataTable dt;
            MySqlConnection con = new MySqlConnection(constring);
            adapt = new MySqlDataAdapter("select * from employee", con);
            dt = new DataTable();
            adapt.Fill(dt);
            dataGridView2.DataSource = dt;
            con.Close();
        }

        private void empContact_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
                MessageBox.Show("Please insert a numeric value for contact");
            }
            empContact.MaxLength = 10;
            if (Char.IsNumber(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
    }
}
