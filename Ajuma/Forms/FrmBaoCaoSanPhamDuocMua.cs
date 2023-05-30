using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using COMExcel = Microsoft.Office.Interop.Excel;
using Ajuma.Class;

namespace Ajuma.Forms
{
    public partial class FrmBaoCaoSanPhamDuocMua : Form
    {
        public FrmBaoCaoSanPhamDuocMua()
        {
            InitializeComponent();
        }
        DataTable tblds;
        private void FrmBaoCaoSanPhamDuocMua_Load(object sender, EventArgs e)
        {
            Functions.FillCombo("SELECT MaKhachHang FROM tblKhachHang", cbomakhachhang, "MaKhachHang", "MaKhachHang");
            cbomakhachhang.SelectedIndex = -1;
            Functions.FillCombo("SELECT MaNhanVien FROM tblNhanVien", cbomanhanvien, "MaNhanVien", "MaNhanVien");
            cbomanhanvien.SelectedIndex = -1;
            btntimlai.Enabled = false;
            btninbaocao.Enabled = false;
            txttongtienbaocao.Enabled = false;
            ResetValues();
            DataGridView.DataSource = null;
        }
        private void ResetValues()
        {
            cbomakhachhang.Text = "";
            cbomanhanvien.Text = "";
            txttongtienbaocao.Text = "0";
            cbomakhachhang.Focus();
        }

        private void btnhienthi_Click(object sender, EventArgs e)
        {
            string sql;
            sql = "SELECT a.MaHoaDonBan, a.MaSanPham, b.MaKhachHang, b.MaNhanVien, b.NgayBan, a.SoLuong, c.GiaBan, a.KhuyenMai, a.ThanhTien FROM tblChiTietHoaDonBan AS a JOIN tblHoaDonBan AS b ON a.MaHoaDonBan = b.MaHoaDonBan JOIN tblSanPham AS c ON a.MaSanPham = c.MaSanPham WHERE b.MaKhachHang =N'" + cbomakhachhang.Text + "' AND b.MaNhanVien = N'" + cbomanhanvien.Text + "'";
            //MessageBox.Show(sql);
            tblds = Functions.GetDataToTable(sql);
            if (cbomakhachhang.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn mã khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbomakhachhang.Focus();
                return;
            }
            else if (cbomanhanvien.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn mã nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbomanhanvien.Focus();
                return;
            }
            else if (tblds.Rows.Count == 0)
            {
                MessageBox.Show("Không có bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                MessageBox.Show("Có " + tblds.Rows.Count + " bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            Load_DataGridView();
            btninbaocao.Enabled = true;
            btntimlai.Enabled = true;
            btnhienthi.Enabled = false;
        }
        private void Load_DataGridView()
        {
            DataGridView.DataSource = tblds;
            DataGridView.Columns[0].HeaderText = "Mã hóa đơn bán";
            DataGridView.Columns[1].HeaderText = "Mã sản phẩm";
            DataGridView.Columns[2].HeaderText = "Mã khách hàng";
            DataGridView.Columns[3].HeaderText = "Mã nhân viên";
            DataGridView.Columns[4].HeaderText = "Ngày bán";
            DataGridView.Columns[5].HeaderText = "Số lượng";
            DataGridView.Columns[6].HeaderText = "Giá bán";
            DataGridView.Columns[7].HeaderText = "Khuyến mãi";
            DataGridView.Columns[8].HeaderText = "Thành tiền";
            DataGridView.Columns[0].Width = 150;
            DataGridView.Columns[1].Width = 150;
            DataGridView.Columns[2].Width = 150;
            DataGridView.Columns[3].Width = 150;
            DataGridView.Columns[4].Width = 100;
            DataGridView.Columns[5].Width = 100;
            DataGridView.Columns[6].Width = 100;
            DataGridView.Columns[7].Width = 100;
            DataGridView.Columns[8].Width = 100;
            DataGridView.AllowUserToAddRows = false;
            DataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
            txttongtienbaocao.Text = tongtienbc().ToString();
        }
        public double tongtienbc()
        {
            double T = 0;
            for (int i = 0; i <= DataGridView.Rows.Count - 1; i++)
            {
                T = T + Convert.ToDouble(DataGridView.Rows[i].Cells["thanhtien"].Value.ToString());
            }
            return T;
        }

        private void btntimlai_Click(object sender, EventArgs e)
        {
            btnhienthi.Enabled = true;
            ResetValues();
            DataGridView.DataSource = null;
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btninbaocao_Click(object sender, EventArgs e)
        {
            // Khởi động chương trình Excel
            COMExcel.Application exApp = new COMExcel.Application();
            COMExcel.Workbook exBook; //Trong 1 chương trình Excel có nhiều Workbook
            COMExcel.Worksheet exSheet; //Trong 1 Workbook có nhiều Worksheet
            COMExcel.Range exRange;
            string sql;
            int hang = 0, cot = 0;
            DataTable tblThongtinHD, tblThongtinHang;
            exBook = exApp.Workbooks.Add(COMExcel.XlWBATemplate.xlWBATWorksheet);
            exSheet = exBook.Worksheets[1];
            // Định dạng chung
            /*
                Cửa hàng bán đồ da MIS
                   Đống Đa - Hà Nội
               Điện thoại: (08)9999-9999
             */
            exRange = exSheet.Cells[1, 1];
            exRange.Range["A1:B3"].Font.Size = 10;       //từ A1->B3 font chữ = 10
            exRange.Range["A1:B3"].Font.Name = "Times new roman";
            exRange.Range["A1:B3"].Font.Bold = true;
            exRange.Range["A1:B3"].Font.ColorIndex = 5; //Màu xanh da trời
            exRange.Range["A1:A1"].ColumnWidth = 7;
            exRange.Range["B1:B1"].ColumnWidth = 30;
            exRange.Range["A1:B1"].MergeCells = true;
            exRange.Range["A1:B1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A1:B1"].Value = "Cửa hàng bán đồ da MIS";
            exRange.Range["A2:B2"].MergeCells = true;
            exRange.Range["A2:B2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:B2"].Value = "Đống Đa - Hà Nội";
            exRange.Range["A3:B3"].MergeCells = true;
            exRange.Range["A3:B3"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A3:B3"].Value = "Điện thoại: (08)9999-9999";
            //Bảng báo cáo các sản phẩm được mua
            exRange.Range["C2:F2"].Font.Size = 16;
            exRange.Range["C2:F2"].Font.Name = "Times new roman";
            exRange.Range["C2:F2"].Font.Bold = true;
            exRange.Range["C2:F2"].Font.ColorIndex = 3; //Màu đỏ
            exRange.Range["C2:F2"].MergeCells = true;
            exRange.Range["C2:F2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C2:F2"].Value = "Bảng báo cáo các sản phẩm được mua";

            // Biểu diễn thông tin chung của hóa đơn bán nên rows[0][...]
            sql = "SELECT b.MaHoaDonBan, c.MaKhachHang, c.DiaChi, b.TongTien, b.NgayBan, a.TenNhanVien, a.MaNhanVien FROM  tblHoaDonBan AS b JOIN tblKhachHang AS c ON b.MaKhachHang = c.MaKhachHang JOIN tblNhanvien AS a ON b.MaNhanVien = a.MaNhanVien WHERE b.MaKhachHang =N'" + cbomakhachhang.Text + "' AND b.MaNhanVien = N'" + cbomanhanvien.Text + "'";
            //              Rows[0][0]     Rows[0][1]  Rows[0][2] Rows[0][3]  Rows[0][4]  Rows[0][5]     Rows[0][6]
            tblThongtinHD = Functions.GetDataToTable(sql);
            exRange.Range["B6:C9"].Font.Size = 12;
            exRange.Range["B6:C9"].Font.Name = "Times new roman";

            exRange.Range["B6:B6"].Value = "Mã nhân viên:";
            exRange.Range["C6:E6"].MergeCells = true;
            exRange.Range["C6:E6"].Value = tblThongtinHD.Rows[0][6].ToString(); //manhanvien


            exRange.Range["B7:B7"].Value = "Mã khách hàng:";
            exRange.Range["C7:E7"].MergeCells = true;
            exRange.Range["C7:E7"].Value = tblThongtinHD.Rows[0][1].ToString(); //makhachhang

            exRange.Range["B8:B8"].Value = "Địa chỉ:";
            exRange.Range["C8:E8"].MergeCells = true;
            exRange.Range["C8:E8"].Value = tblThongtinHD.Rows[0][2].ToString(); //diachikhachhang
            //thông tin chi tiết hóa đơn bán
            sql = "SELECT a. MaHoaDonBan, a.MaSanPham, a.SoLuong, b.GiaBan, a.KhuyenMai, a.ThanhTien FROM tblChiTietHoaDonBan AS a  JOIN tblSanPham AS b ON a.MaSanPham = b.MaSanPham JOIN tblHoaDonBan AS c ON a.MaHoaDonBan = c.MaHoaDonBan WHERE c.MaKhachHang = N'" + cbomakhachhang.Text + "' AND c.MaNhanVien = N'" + cbomanhanvien.Text + "'";
            //             Rows[0][0]  Rows[0][1] Rows[0][2] Rows[0][3]   Rows[0][4] Rows[0][5] ~~ na ná trong dòng đầu của datagridview
            //             Rows[1][0]  Rows[1][1] Rows[1][2] Rows[1][3]   Rows[1][4] Rows[0][5] ~~ na ná trong dòng t2 của datagridview
            //             Rows[...][...]  Rows[...][...] Rows[...][...] Rows[...][...]   Rows[...][...]
            tblThongtinHang = Functions.GetDataToTable(sql);
            //Tạo dòng tiêu đề bảng
            exRange.Range["A11:G11"].Font.Bold = true;
            exRange.Range["A11:G11"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C11:G11"].ColumnWidth = 12;
            exRange.Range["A11:A11"].Value = "STT";
            exRange.Range["B11:B11"].Value = "Mã hóa đơn bán";
            exRange.Range["C11:C11"].Value = "Mã sản phẩm";
            exRange.Range["D11:D11"].Value = "Số lượng";
            exRange.Range["E11:E11"].Value = "Giá bán";
            exRange.Range["F11:F11"].Value = "Khuyến mại";
            exRange.Range["G11:G11"].Value = "Thành tiền";
            for (hang = 0; hang <= tblThongtinHang.Rows.Count - 1; hang++)
            {
                //Điền số thứ tự vào cột 1 từ dòng 12
                exSheet.Cells[1][hang + 12] = hang + 1;
                for (cot = 0; cot <= tblThongtinHang.Columns.Count - 1; cot++)
                    //Điền thông tin hàng từ cột thứ 2, dòng 12
                    exSheet.Cells[cot + 2][hang + 12] = tblThongtinHang.Rows[hang][cot].ToString();
            }
            exRange = exSheet.Cells[cot][hang + 14];
            exRange.Font.Bold = true;
            exRange.Value2 = "Tổng tiền:";
            exRange = exSheet.Cells[cot + 1][hang + 14];
            exRange.Font.Bold = true;
            exRange.Value2 = txttongtienbaocao.Text; //tổng tiền của cả báo cáo hóa đơn
            exRange = exSheet.Cells[1][hang + 15]; //Ô A1 
            exRange.Range["A1:F1"].MergeCells = true;
            exRange.Range["A1:F1"].Font.Bold = true;
            exRange.Range["A1:F1"].Font.Italic = true;
            exRange.Range["A1:F1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignRight;
            exRange.Range["A1:F1"].Value = "Bằng chữ: " + Functions.ChuyenSoSangChu(txttongtienbaocao.Text);
            exRange = exSheet.Cells[4][hang + 17]; //Ô A1 
            exRange.Range["A1:C1"].MergeCells = true;
            exRange.Range["A1:C1"].Font.Italic = true;
            exRange.Range["A1:C1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            DateTime d = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            exRange.Range["A1:C1"].Value = "Hà Nội, ngày " + d.Day + " tháng " + d.Month + " năm " + d.Year;
            exRange.Range["A2:C2"].MergeCells = true;
            exRange.Range["A2:C2"].Font.Italic = true;
            exRange.Range["A2:C2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:C2"].Value = "Nhân viên bán hàng";
            exRange.Range["A6:C6"].MergeCells = true;
            exRange.Range["A6:C6"].Font.Italic = true;
            exRange.Range["A6:C6"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A6:C6"].Value = tblThongtinHD.Rows[0][5];
            exSheet.Name = "Báo cáo sản phẩm được bán";
            exApp.Visible = true;
        }

        private void DataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string mahd;
            if (MessageBox.Show("Bạn có muốn hiển thị thông tin chi tiết?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                mahd = DataGridView.CurrentRow.Cells["MaHoaDonBan"].Value.ToString();
                FrmHoaDonBan frm = new FrmHoaDonBan();
                frm.txtmahoadonban.Text = mahd;
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowDialog();
            }
        }
    }
}
