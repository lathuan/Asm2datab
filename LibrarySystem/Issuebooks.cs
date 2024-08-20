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

namespace LibrarySystem
{
    public partial class Issuebooks : Form
    {
        public Issuebooks()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=NCPC\\SQLEXPRESS;Initial Catalog=lilbrary;Integrated Security=True;Trusted_Connection=Yes");
        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_addissuebook", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Student_Name", SqlDbType.NVarChar).Value = textBox1.Text;
            cmd.Parameters.Add("@Entrollment_NO", SqlDbType.NVarChar).Value = textBox2.Text;
            cmd.Parameters.Add("@Deparment", SqlDbType.NVarChar).Value = textBox5.Text;
            cmd.Parameters.Add("@Contact", SqlDbType.NVarChar).Value = textBox4.Text;
            cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = textBox3.Text;
            cmd.Parameters.Add("@BookName", SqlDbType.NVarChar).Value = comboBox1.Text;
            cmd.Parameters.Add("@Issue_Date", SqlDbType.NVarChar).Value = dateTimePicker1.Value.ToShortDateString();
            cmd.Parameters.Add("@Return_Date", SqlDbType.NVarChar).Value = "";
            cmd.ExecuteNonQuery();
            MessageBox.Show("Issue Book Added");
            con.Close();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox5.Text = "";
            textBox4.Text = "";
            textBox3.Text = "";
            textBox6.Text = "";
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void Issuebooks_Load(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_getbooks", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr[0].ToString());
            }
            dr.Close();
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("ViewStudents", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@EntrollmentNO", SqlDbType.NVarChar).Value = textBox6.Text;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox1.Text = dr[0].ToString();
                textBox2.Text = dr[1].ToString();
                textBox5.Text = dr[2].ToString();
                textBox4.Text = dr[3].ToString();
                textBox3.Text = dr[4].ToString();
            }
            dr.Close();
            con.Close();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Returnbooks d = new Returnbooks();
            d.Show();
        }
    }
}
