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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string constring = "datasource=localhost;database=swiftdb;username=root;password=;SslMode=none;";
                MySqlConnection con = new MySqlConnection(constring);
                // con.Open();
                //      MessageBox.Show("Connection open");
                string fname = firstText.Text;
                
                    MySqlCommand cmd = new MySqlCommand("INSERT INTO swiftdb.employee (firstName,lastName,SIN,Contact,Address)"
                        + "VALUES(@firstName,@lastName,@SIN,@Contact,@Address);", con);

                    int sin = Convert.ToInt32(sinText.Text);
                    long contact = Convert.ToInt64(contactText.Text);

                    // create your parameters
                    cmd.Parameters.AddWithValue("@firstName", fname);
                    cmd.Parameters.AddWithValue("@lastName", lastText.Text);
                    cmd.Parameters.AddWithValue("@SIN", sin);
                    cmd.Parameters.AddWithValue("@Contact", contact);
                    cmd.Parameters.AddWithValue("@Address", addressText.Text);


                    //   cmd.Parameters["@RegistrationDate"].Value = DateTime.Now;
                    //     con.Close();

                    // open sql connection
                    con.Open();

                    // execute the query and return number of rows affected, should be one
                    int RowsAffected = cmd.ExecuteNonQuery();
                MessageBox.Show("Information saved successfully");
                    // close connection when done
                    con.Close();
                
               
            }
            catch
            {
                  MessageBox.Show("There was an error");
                
            }



        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            srchForm s = new srchForm();
            s.ShowDialog();
            
           
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string constring = "datasource=localhost;database=swiftdb;username=root;password=;SslMode=none;";
            MySqlDataAdapter adapt;
            DataTable dt;
            MySqlConnection con = new MySqlConnection(constring);
            adapt = new MySqlDataAdapter("select * from employee", con);
            dt = new DataTable();
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void contactText_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if(!Char.IsDigit(ch)&&ch!=8)
            {
                e.Handled = true;
                MessageBox.Show("Please insert a numeric value for contact");
            }
            contactText.MaxLength = 10;
            if (Char.IsNumber(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void sinText_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
                MessageBox.Show("Please insert a numeric value for sin");
            }
            sinText.MaxLength = 9;
            if (Char.IsNumber(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            string constring = "datasource=localhost;database=swiftdb;username=root;password=;SslMode=none;";
            MySqlDataAdapter adapt;
            DataTable dt;
            try
            {
                string eid = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();


                MySqlConnection con = new MySqlConnection(constring);
                adapt = new MySqlDataAdapter("delete from employee where employeeID like '" + eid + "'", con);

                dt = new DataTable();

                adapt.Fill(dt);
                dataGridView1.DataSource = dt;
                MessageBox.Show("deleted successfully");
                con.Close();
            }
            catch
            {
                MessageBox.Show("Please selected from below");
            }
        }
    }
}
