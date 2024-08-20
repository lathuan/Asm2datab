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
    public partial class Viewbooks : Form
    {
        public Viewbooks()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=NCPC\\SQLEXPRESS;Initial Catalog=lilbrary;Integrated Security=True;Trusted_Connection=Yes");
        private void Viewbooks_Load(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("ViewBooks", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@BookName", SqlDbType.NVarChar).Value = "";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("ViewBooks", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@BookName", SqlDbType.NVarChar).Value = textBox1.Text;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Lấy giá trị ID của sách từ dòng được chọn
                int bookID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["BookID"].Value);

                // Xác nhận trước khi xóa
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa sách này không?",
                                                      "Xác nhận xóa",
                                                      MessageBoxButtons.YesNo,
                                                      MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    // Mở kết nối SQL
                    con.Open();

                    // Sử dụng tên bảng đúng [dbo].[tbl_books]
                    SqlCommand cmd = new SqlCommand("DELETE FROM [dbo].[tbl_books] WHERE BookID = @BookID", con);
                    cmd.Parameters.AddWithValue("@BookID", bookID);

                    // Thực thi command
                    cmd.ExecuteNonQuery();

                    // Đóng kết nối
                    con.Close();

                    // Xóa dòng khỏi DataGridView
                    dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);

                    MessageBox.Show("Đã xóa sách thành công.");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng để xóa.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Sắp xếp DataGridView theo BookID (hoặc theo cột khác tùy ý)
            dataGridView1.Sort(dataGridView1.Columns["BookID"], ListSortDirection.Ascending);

            // Mở kết nối SQL
            con.Open();

            // Duyệt qua từng dòng trong DataGridView để cập nhật STT
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                // Cập nhật STT trong DataGridView
                dataGridView1.Rows[i].Cells["STT"].Value = i + 1;

                // Lấy BookID của dòng hiện tại
                int bookID = Convert.ToInt32(dataGridView1.Rows[i].Cells["BookID"].Value);

                // Cập nhật STT trong cơ sở dữ liệu
                SqlCommand cmd = new SqlCommand("UPDATE [dbo].[tbl_books] SET STT = @STT WHERE BookID = @BookID", con);
                cmd.Parameters.AddWithValue("@STT", i + 1);
                cmd.Parameters.AddWithValue("@BookID", bookID);
                cmd.ExecuteNonQuery();
            }

            // Đóng kết nối SQL
            con.Close();

            MessageBox.Show("Đã sắp xếp và cập nhật STT thành công.");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
