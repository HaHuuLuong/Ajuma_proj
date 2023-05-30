using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ajuma.Forms;
using System.Data;

namespace Ajuma
{
    public partial class FrmMenu : Form
    {
        bool isLogout = true;
        public FrmMenu()
        {
            InitializeComponent();
        }

        private void FrmMenu_Load(object sender, EventArgs e)
        {
            Class.Functions.Connect();
        }

        private void mnuThoat_Click(object sender, EventArgs e)
        {
            if(isLogout)
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

        private void mnuLogout_Click(object sender, EventArgs e)
        {

            Logout();
            


        }

        private void mnuHoadonban_Click(object sender, EventArgs e)
        {
            Forms.FrmHoaDonBan f = new Forms.FrmHoaDonBan();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void mnuBCHoadonban_Click(object sender, EventArgs e)
        {
            Forms.FrmBaoCaoHoaDonBan f = new Forms.FrmBaoCaoHoaDonBan();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();

        }

        private void mnuFindHoadonnhap_Click(object sender, EventArgs e)
        {
            Forms.FrmTimKiemHoaDonNhap f = new Forms.FrmTimKiemHoaDonNhap();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void mnuNhanvien_Click(object sender, EventArgs e)
        {
            FrmDanhMucNhanVien f = new FrmDanhMucNhanVien();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();

        }

        private void mnuKhachhang_Click(object sender, EventArgs e)
        {
            Forms.FrmDanhMucKhachHang f = new FrmDanhMucKhachHang();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void mnuNhacungcap_Click(object sender, EventArgs e)
        {
            Forms.FrmDanhMucNhaCungCap f = new FrmDanhMucNhaCungCap();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();

        }

        private void mnuque_Click(object sender, EventArgs e)
        {
            FrmChucvu f = new FrmChucvu();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();

        }

        private void mnuBCHoadonnhap_Click(object sender, EventArgs e)
        {
            Forms.FrmBaoCaoHoaDonNhap f = new FrmBaoCaoHoaDonNhap();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();

        }

        private void mnuHoadonnhap_Click(object sender, EventArgs e)
        {
            Forms.FrmHoaDonNhap f = new FrmHoaDonNhap();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void mnuSanpham_Click(object sender, EventArgs e)
        {
            Forms.FrmSanPham f = new FrmSanPham();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void mnuFindSanpham_Click(object sender, EventArgs e)
        {
            Forms.FrmTimKiemSanPham f = new FrmTimKiemSanPham();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void mnuBCDoanhthu_Click(object sender, EventArgs e)
        {
            Forms.FrmBaoCaoDoanhThu f = new FrmBaoCaoDoanhThu();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();

        }

        private void mnutheloai_Click(object sender, EventArgs e)
        {
            Forms.FrmTheLoai f = new FrmTheLoai();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void mnumausac_Click(object sender, EventArgs e)
        {
            Forms.FrmMauSac f = new FrmMauSac();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }



        private void mnunuocsanxuat_Click(object sender, EventArgs e)
        {
            Forms.FrmNuocSanXuat f = new FrmNuocSanXuat();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void mnuBCSanpham_Click(object sender, EventArgs e)
        {
            Forms.FrmBaoCaoSanPhamDuocMua f = new FrmBaoCaoSanPhamDuocMua();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void picAnh_Click(object sender, EventArgs e)
        {

        }

        private void dashBoardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.Dashboard f = new Dashboard();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }
    }
}
