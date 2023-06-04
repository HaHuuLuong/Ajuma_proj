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
    public partial class FrmMenu_NV : Form
    {
        bool isLogout = true;
        public FrmMenu_NV()
        {
            InitializeComponent();
        }

        private void quảnLýHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.FrmHoaDonBan f = new Forms.FrmHoaDonBan();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.FrmDanhMucKhachHang f = new FrmDanhMucKhachHang();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void tìmKiếmToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void sảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.FrmTimKiemSanPham f = new FrmTimKiemSanPham();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isLogout)
            {
                Class.Functions.Disconnect();
                Application.Exit();
            }

        }
        public void Logout()
        {
            isLogout = false;
            this.Close();
            FrmLogin f = new FrmLogin();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();


        }
        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Logout();
        }
    }
}
