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
    public partial class Addstudent : Form
    {
        public Addstudent()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=NCPC\\SQLEXPRESS;Initial Catalog=lilbrary;Integrated Security=True;Trusted_Connection=Yes");
        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_addstudents", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Student_Name", SqlDbType.NVarChar).Value = textBox1.Text;
            cmd.Parameters.Add("@Entrollment_Number", SqlDbType.NVarChar).Value = textBox2.Text;
            cmd.Parameters.Add("@Department", SqlDbType.NVarChar).Value = textBox5.Text;
            cmd.Parameters.Add("@contact", SqlDbType.NVarChar).Value = dateTimePicker1.Value;
            cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = textBox4.Text;
            cmd.Parameters.Add("@Semester", SqlDbType.NVarChar).Value = textBox3.Text;
            cmd.ExecuteNonQuery();
            MessageBox.Show("Student Details Added");
            con.Close();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox5.Text = "";
            textBox4.Text = "";
            textBox3.Text = "";
        }

        private void Addstudent_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
