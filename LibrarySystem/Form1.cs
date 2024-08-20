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
    public partial class Form1 : Form
    {
        //string chuoiSql = "Data Source=NCPC\\SQLEXPRESS;Initial Catalog=lilbrary;Integrated Security=True;Trusted_Connection=Yes";
        SqlConnectionStringBuilder ChuoiSql = new SqlConnectionStringBuilder();
        public Form1()
        {
            InitializeComponent();
            ChuoiSql["Server"] = "NCPC\\SQLEXPRESS";
            ChuoiSql["Database"] = "lilbrary";
            ChuoiSql["Integrated Security"] = "True";
            ChuoiSql["Trusted_Connection"] = "Yes";
        }
        //SqlConnection con = new SqlConnection("Data Source=NCPC\\SQLEXPRESS;InitialCatalog=lilbrary;IntegratedSecurity=True;TrustServerCertificate=True");
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private SqlConnection GetConnection()
        {

            string sql = ChuoiSql.ToString();
            var sqlconnect = new SqlConnection(sql);
            try
            {
                if (sqlconnect.State == ConnectionState.Closed)
                {
                    sqlconnect.Open();
                    //MessageBox.Show("Kết Nối Thành Công");
                }
                //LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi : " + ex.Message);
            }
            finally
            {
                sqlconnect.Close();
            }
            return sqlconnect;
        }


        private void button1_Click(object seaonder, EventArgs e)
        {
            string username = txtuser.Text;
            string password = txtpass.Text;
            SqlConnection sqlconnect = GetConnection();
            sqlconnect.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlconnect;
            cmd.CommandText = "SELECT [Role] FROM [dbo].[Login] WHERE [username] = @username AND [password] = @password ";
            cmd.Parameters.AddWithValue("username", username);
            cmd.Parameters.AddWithValue("password", password);
            try
            {
                // Mở kết nối


                // Thực thi câu lệnh SQL và lấy vai trò của người dùng
                string role = (string)cmd.ExecuteScalar();

                if (!string.IsNullOrEmpty(role))
                {
                    // Nếu vai trò được xác định, mở form tương ứng
                    MessageBox.Show("Đăng nhập thành công!");

                    switch (role)
                    {
                        case "Student":
                            this.Hide();
                            Issuebooks formStudent = new Issuebooks();
                            formStudent.ShowDialog();
                            break;
                        case "Admin":
                            this.Hide();
                            Dashboard formAdmin = new Dashboard();
                            formAdmin.ShowDialog();
                            break;

                        default:
                            MessageBox.Show("Vai trò không xác định!");
                            break;
                    }

                    this.Close();

                }
                else
                {
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
            }
            finally
            {
                sqlconnect.Close();
            }

        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
        //SqlCommand cmd = new SqlCommand("sp_Login", con);
        //cmd.CommandType = CommandType.StoredProcedure;
        //cmd.Parameters.Add("@username", SqlDbType.VarChar).Value = txtuser.Text;
        //cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = txtpass.Text;
        //SqlDataReader dr = cmd.ExecuteReader();
        //    if (dr.Read())
        //    {
        //        Dashboard d = new Dashboard();
        //        d.Show();
        //        this.Hide();

        //    }
        //    else
        //    {
        //        MessageBox.Show("Login Failed");
        //    }
        //    con.Close();
    }

    //private void label2_Click(object sender, EventArgs e)
    //{

}
