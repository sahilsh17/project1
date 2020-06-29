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
    public partial class updateForm : Form
    {
        string ID;

        public updateForm()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s1 = first.Text;
            string s2 = last.Text;
            string c1 = contact.Text;
            string ad = address.Text;
            string s3= sin.Text;

            try
            {
                int id = Convert.ToInt32(dataGridView3.SelectedRows[0].Cells[5].Value);

                string constring = "datasource=localhost;database=swiftdb;username=root;password=;SslMode=none;";
                MySqlDataAdapter adapt;
                DataTable dt;
                MySqlConnection con = new MySqlConnection(constring);
                adapt = new MySqlDataAdapter("update employee set firstName='" + first.Text + "',lastName='" + last.Text + "',Contact='"
                    + contact.Text + "',SIN='" + sin.Text + "',Address='" + address.Text + "'where employeeID='" + id + "'", con);
                dt = new DataTable();
                adapt.Fill(dt);
                dataGridView3.DataSource = dt;
                button3_Click(sender, e);
                con.Close();
            }
            catch
            {

                string constring = "datasource=localhost;database=swiftdb;username=root;password=;SslMode=none;";
                MySqlDataAdapter adapt;
                DataTable dt;
                MySqlConnection con = new MySqlConnection(constring);
                adapt = new MySqlDataAdapter("update employee set firstName='" + first.Text + "',lastName='" + last.Text + "',Contact='"
                    + contact.Text + "',SIN='" + sin.Text + "',Address='" + address.Text + "'where employeeID='" + ID + "'", con);
                dt = new DataTable();
                adapt.Fill(dt);
                dataGridView3.DataSource = dt;
                button3_Click(sender, e);
                con.Close();
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
            dataGridView3.DataSource = dt;
            con.Close();
        }
      
        public void values(string f,string l,string c,string a, string s,string id)
        {
            first.Text = f;
            last.Text = l;
            contact.Text = c;
            address.Text = a;
            sin.Text = s;
            ID = id;
        }

    private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {

            first.Text = dataGridView3.SelectedRows[0].Cells[0].Value.ToString();
            last.Text = dataGridView3.SelectedRows[0].Cells[1].Value.ToString();
            contact.Text = dataGridView3.SelectedRows[0].Cells[2].Value.ToString();
            sin.Text = dataGridView3.SelectedRows[0].Cells[3].Value.ToString();
            address.Text = dataGridView3.SelectedRows[0].Cells[4].Value.ToString();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string constring = "datasource=localhost;database=swiftdb;username=root;password=;SslMode=none;";
            int id = Convert.ToInt32(eid.Text);
            MySqlDataAdapter adapt;
            DataTable dt;

            MySqlConnection con = new MySqlConnection(constring);
            adapt = new MySqlDataAdapter("select * from employee where employeeID like '" + eid.Text + "'", con);
            first.Text = dataGridView3.CurrentRow.Cells[0].Value.ToString();
            last.Text = dataGridView3.CurrentRow.Cells[1].Value.ToString();
            contact.Text = dataGridView3.CurrentRow.Cells[2].Value.ToString();
            sin.Text = dataGridView3.CurrentRow.Cells[3].Value.ToString();
            address.Text = dataGridView3.CurrentRow.Cells[4].Value.ToString();
            dt = new DataTable();
            adapt.Fill(dt);
            dataGridView3.DataSource = dt;
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void sin_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
                MessageBox.Show("Please insert a numeric value for sin");
            }
            sin.MaxLength = 9;
            if (Char.IsNumber(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void contact_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
                MessageBox.Show("Please insert a numeric value for contact");
            }
            contact.MaxLength = 10;
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
