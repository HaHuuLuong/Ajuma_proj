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

namespace Ajuma.Forms
{
    public partial class Resetpassword : Form
    {
        public Resetpassword()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmLogin frmLogin = new FrmLogin();
            this.Hide();
            frmLogin.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql;
            //string txtTK = "admin";
            //string loaiTk = "QuanTri";
            string id = "1";

            string password = textBox2.Text;
            if(textBox1.Text == password)
            {
                SqlConnection conn = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = 'D:\Github\Ajuma_proj\Ajuma\DB\Ajuma_MỚI_Vux .mdf'; Integrated Security = True; Connect Timeout = 30");

                //sql = "UPDATE TaiKhoan SET taiKhoan = N'" + txtTK + "', matKhau = N'" + password + "', LoaiTK = N'" + loaiTk + "' WHERE IDTaiKhoan = N'" + id + "'";
                sql = "UPDATE TaiKhoan SET matKhau = N'" + password + "' WHERE IDTaiKhoan =  N'" + id + "'";
                //Class.Functions.RunSql(sql);
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Cập nhập mật khẩu thành công");
                FrmLogin frmLogin = new FrmLogin();
                this.Hide();
                frmLogin.Show();
            }
            else
            {
                MessageBox.Show("Lỗi thực hiện");
            }
        }

        private void Resetpassword_Load(object sender, EventArgs e)
        {

        }
    }
}
