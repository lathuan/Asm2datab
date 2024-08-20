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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LibrarySystem
{
    public partial class Returnbooks : Form
    {
        public Returnbooks()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=NCPC\\SQLEXPRESS;Initial Catalog=lilbrary;Integrated Security=True;Trusted_Connection=Yes");
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("ViewIssueBook", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@EntrollmentNO", SqlDbType.NVarChar).Value = textBox6.Text;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();

        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells[0].Value.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Update_issueBook", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ID", SqlDbType.NVarChar).Value = textBox1.Text;
            cmd.Parameters.Add("@Return_Date", SqlDbType.NVarChar).Value = dateTimePicker1.Value.ToShortDateString();
            MessageBox.Show("Book Returned");
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void Returnbooks_Load(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
