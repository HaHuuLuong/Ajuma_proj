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
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            
            txtTK.Text = Properties.Settings.Default.TenDangNhap;
            txtMK.Text = Properties.Settings.Default.MatKhau;
            // Chạy animation Slogan
            text = lblText.Text;
            lblText.Text = "";
            timer1.Start();
            timer2.Start();
        }


        private string text;
        private int len = 0;
        
/*         public void DangNhap()
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
        } */

        public void DangNhap()
        {
            string userName, userPassword;

            if (txtTK.Text.Trim().Length == 0 || txtMK.Text.Trim().Length == 0)
            {
                lblLoi.Text = "**Chưa nhập đầy đủ thông tin!**";
                lblLoi.Visible = true;
                return;
            }

            userName = txtTK.Text;
            userPassword = txtMK.Text;

            if (Class.Functions.Login(userName, userPassword))
            {
                string sql = "SELECT LoaiTK FROM TaiKhoan WHERE taiKhoan = N'" + userName + "'";
                string sql1 = "SELECT TrangThai FROM TaiKhoan WHERE taiKhoan = N'" + userName + "'";
                string flag = Class.Functions.GetFieldValues(sql);
                string flag1 = Class.Functions.GetFieldValues(sql1);
                switch (flag)
                {
                    case "QuanTri":
                        {
                            if (flag1 != "1")
                            {
                                MessageBox.Show("Chào Admin, chúc bạn một ngày làm việc hiệu quả!");
                                FrmMenu f = new FrmMenu();
                                f.StartPosition = FormStartPosition.CenterScreen;
                                this.Hide();
                                f.ShowDialog();
                            }
                            else
                            {
                                MessageBox.Show("Tài khoản này đã bị vô hiệu hóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                txtTK.Text = "";
                                txtMK.Text = "";
                            }
                            break;
                        }
                    case "QuanLy":
                        {
                            if (flag1 != "1")
                            {
                                MessageBox.Show("Chào Quản lý, chúc bạn một ngày làm việc hiệu quả!");
                                FrmMenu_QL f = new FrmMenu_QL();
                                f.StartPosition = FormStartPosition.CenterScreen;
                                this.Hide();
                                f.ShowDialog();
                            }
                            else
                            {
                                MessageBox.Show("Tài khoản này đã bị vô hiệu hóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                txtTK.Text = "";
                                txtMK.Text = "";
                            }
                            break;
                        }
                    case "NhanVien":
                        {
                            if (flag1 != "1")
                            {
                                MessageBox.Show("Chào Nhân viên, chúc bạn một ngày làm việc hiệu quả!");
                                FrmMenu_NV f = new FrmMenu_NV();
                                f.StartPosition = FormStartPosition.CenterScreen;
                                this.Hide();
                                f.ShowDialog();
                            }
                            else
                            {
                                MessageBox.Show("Tài khoản này đã bị vô hiệu hóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                txtTK.Text = "";
                                txtMK.Text = "";
                            }
                            break;
                        }
                }
            }
            else
            {
                MessageBox.Show("Tài khoản/ Mật khẩu sai rồi, mời bạn nhập lại!");
                txtTK.Clear();
                txtMK.Clear();
                lblLoi.Text = "";
                txtTK.Focus();
                return;
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
                txtMK.PasswordChar = '\0';
            else
                txtMK.PasswordChar = '*';
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


        private void lblText_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtTenDangNhap_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSave_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.facebook.com/luhoangve24/");
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString();
        }
    }
}
