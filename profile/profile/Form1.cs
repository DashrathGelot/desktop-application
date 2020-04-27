using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace profile
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source =(localdb)\MSSQLLocalDB; Initial Catalog = PROFILE; Integrated Security = True;");
        SqlCommand cmd;
        SqlDataAdapter sda;
        int ID = 0;
        public Form1()
        {
            InitializeComponent();
            displaydata();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            cmd.CommandText = "insert into profile(FIRST_NAME,LAST_NAME,E_mail,mo) values(@fname,@lname,@email,@mo)";
            cmd.Parameters.AddWithValue("@fname", textBox1.Text);
            cmd.Parameters.AddWithValue("@lname", textBox2.Text);
            cmd.Parameters.AddWithValue("@email", textBox3.Text);
            cmd.Parameters.AddWithValue("@mo", textBox4.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Data Inserted Sucessfully", "Data Connection", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
            displaydata();
            cleardata();
        }
        private void displaydata()
        {
            con.Open();
            sda = new SqlDataAdapter("select * from profile", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
        private void cleardata()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }
    }
}
