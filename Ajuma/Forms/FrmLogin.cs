using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ajuma.Forms
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            txtTenDangNhap.Text = Properties.Settings.Default.TenDangNhap;
            txtMatKhau.Text = Properties.Settings.Default.MatKhau;
            // Chạy animation Slogan
            text = lblText.Text;
            lblText.Text = "";
            timer1.Start();
        }
        private string text;
        private int len = 0;
        
        public void DangNhap()
        {
            string user = "Ajuma";
            string pass = "123";
            
            //Kiểm tra ràng buộc

            if (txtTenDangNhap.Text.Length == 0 && txtMatKhau.Text.Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập tên đăng nhập và mật khẩu");
                txtTenDangNhap.Focus();
            }
            else if (txtTenDangNhap.Text.Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập tên đăng nhập, bạn vui lòng nhập lại: ");
                txtTenDangNhap.Focus();
            }
            else if (txtMatKhau.Text.Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập mật khẩu");
                txtMatKhau.Focus();
            }
            else if (user == txtTenDangNhap.Text && pass == txtMatKhau.Text)
            {
                if (btnSave.Checked)
                {
                    Properties.Settings.Default.TenDangNhap = txtTenDangNhap.Text;
                    Properties.Settings.Default.MatKhau = txtMatKhau.Text;
                    Properties.Settings.Default.Save();
                }
                else
                {
                    Properties.Settings.Default.TenDangNhap = "";
                    Properties.Settings.Default.MatKhau = "";
                    Properties.Settings.Default.Save();
                }
                this.Hide();              
                FrmMenu f = new FrmMenu(); // Hiện chương trình chính
                f.StartPosition = FormStartPosition.CenterScreen;
                f.Show();
            }
            else
            {
                MessageBox.Show("Đăng nhập thất bại", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                txtTenDangNhap.Text = "";
                txtMatKhau.Text = "";
                txtTenDangNhap.Focus();
            }
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            DangNhap();
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked==true)
                txtMatKhau.PasswordChar = '\0';
            else
                txtMatKhau.PasswordChar = '*';
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (len < text.Length)
            {
                lblText.Text = lblText.Text + text.ElementAt(len);
                len++;
            }    
           else
                timer1.Stop();
        }
    }
}
