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
    public partial class FrmMenu_QL : Form
    {
        bool isLogout = true;
        public FrmMenu_QL()
        {
            InitializeComponent();
        }
        private void mnuThoat_Click(object sender, EventArgs e)
        {
            if (isLogout)
            {
                Class.Functions.Disconnect();
                Application.Exit();
            }

        }
        private void mnuBCSanpham_Click(object sender, EventArgs e)
        {

        }

        private void mnuBCHoadonnhap_Click(object sender, EventArgs e)
        {

        }

        private void mnuBCDoanhthu_Click(object sender, EventArgs e)
        {

        }

        private void mnuBCHoadonban_Click(object sender, EventArgs e)
        {

        }

        private void dashBoardToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void báoCáoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void quảnLýCửaHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void FrmMenu_QL_Load(object sender, EventArgs e)
        {

        }
        public void Logout()
        {
            isLogout = false;
            this.Close();
            FrmLogin f = new FrmLogin();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();


        }
        private void đăngXuấtToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Logout();
        }

        private void sảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void mnuSanPham_Click(object sender, EventArgs e)
        {
            Forms.FrmSanPham f = new FrmSanPham();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void mnuTheLoai_Click(object sender, EventArgs e)
        {
            Forms.FrmTheLoai f = new FrmTheLoai();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void mnuNgheSi_Click(object sender, EventArgs e)
        {
            Forms.FrmNgheSi f = new FrmNgheSi();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void mnuAlbum_Click(object sender, EventArgs e)
        {
            Forms.FrmAlbum f = new FrmAlbum();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void mnuHDNhap_Click(object sender, EventArgs e)
        {
            Forms.FrmHoaDonNhap f = new FrmHoaDonNhap();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void mnuHDBan_Click(object sender, EventArgs e)
        {
            Forms.FrmHoaDonBan f = new Forms.FrmHoaDonBan();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void tìmKiếmToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void mnuTKSanPham_Click(object sender, EventArgs e)
        {
            Forms.FrmTimKiemSanPham f = new FrmTimKiemSanPham();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void mnuTKHDNhap_Click(object sender, EventArgs e)
        {
            Forms.FrmTimKiemHoaDonNhap f = new Forms.FrmTimKiemHoaDonNhap();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void mnuBCSanPham_Click_1(object sender, EventArgs e)
        {
            Forms.FrmBaoCaoSanPhamDuocMua f = new FrmBaoCaoSanPhamDuocMua();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void mnuBCHDNhap_Click(object sender, EventArgs e)
        {
            Forms.FrmBaoCaoHoaDonNhap f = new FrmBaoCaoHoaDonNhap();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void mnuBCHDBan_Click(object sender, EventArgs e)
        {
            Forms.FrmBaoCaoHoaDonBan f = new Forms.FrmBaoCaoHoaDonBan();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
