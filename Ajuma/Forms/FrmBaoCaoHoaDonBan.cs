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

namespace Ajuma.Forms
{
    public partial class FrmBaoCaoHoaDonBan : Form
    {
        public FrmBaoCaoHoaDonBan()
        {
            InitializeComponent();
        }
        DataTable tblBCHDB;
        private void FrmBaoCaoHoaDonBan_Load(object sender, EventArgs e)
        {
            ResetValues();
            dgnhaphang.DataSource = null;
            txttongtien.Text = "0";
            txttongtien.Enabled = false;
            btntimlai.Enabled = false;
            btnin.Enabled = false;

            Class.Functions.FillCombo("SELECT MaSanPham, TenSanPham FROM tblSanPham", cbomsanpham, "MaSanPham", "TenSanPham");
            cbomsanpham.SelectedIndex = -1;
        }

        private void Load_dghoadonnhap()
        {

            dgnhaphang.Columns[0].HeaderText = "MÃ HÓA ĐƠN";
            dgnhaphang.Columns[1].HeaderText = "MÃ SẢN PHẨM ";
            dgnhaphang.Columns[2].HeaderText = "SỐ LƯỢNG";
            dgnhaphang.Columns[3].HeaderText = "THÀNH TIỀN";
            dgnhaphang.Columns[4].HeaderText = "KHUYẾN MÃI";
            dgnhaphang.Columns[5].HeaderText = "NGÀY BÁN";
            dgnhaphang.Columns[6].HeaderText = "MÃ NHÂN VIÊN BAN";
            dgnhaphang.Columns[7].HeaderText = "MÃ KHÁCH HÀNG";
            dgnhaphang.Columns[0].Width = 200;
            dgnhaphang.Columns[1].Width = 200;
            dgnhaphang.Columns[2].Width = 200;
            dgnhaphang.Columns[3].Width = 200;
            dgnhaphang.Columns[4].Width = 200;
            dgnhaphang.Columns[5].Width = 200;
            dgnhaphang.Columns[6].Width = 200;
            dgnhaphang.Columns[7].Width = 200;
            

            dgnhaphang.AllowUserToAddRows = false;
            dgnhaphang.EditMode = DataGridViewEditMode.EditProgrammatically;


        }

        private void ResetValues()
        {

            txttongtien.Text = "";
            cbomsanpham.Text = "";
            cbomsanpham.Focus();
        }
        public double tongtienbaocao()
        {
            double T = 0;
            for (int i = 0; i <= dgnhaphang.Rows.Count - 1; i++)
            {
                T = T + Convert.ToDouble(dgnhaphang.Rows[i].Cells["thanhtien"].Value.ToString());
            }
            return T;
        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            string sql;
            if ((cbomsanpham.Text.Trim().Length == 0) || (cbomsanpham.Text == "0"))
            {
                MessageBox.Show("Bạn chưa chọn sản phẩm để tìm ! Mời bạn chọn: ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbomsanpham.Text = "";

                return;
            }
            if (rdobtn1.Checked == false && rdobtn2.Checked == false && rdobtn3.Checked == false && rdobtn4.Checked == false)
            {
                MessageBox.Show("Bạn chưa chọn quý bán hàng! Mời bạn chọn: ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }


            if (rdobtn1.Checked == true)
            {

                sql = " SELECT tblHoaDonBan.MaHoaDonBan,tblChiTietHoaDonBan.MaSanPham, SoLuong, ThanhTien,KhuyenMai,NgayBan,MaNhanVien,MaKhachHang" +
                     " FROM  tblHoaDonBan  join tblChiTietHoaDonBan on tblHoaDonBan.MaHoaDonBan = tblChiTietHoaDonBan.MaHoaDonBan WHERE 1 = 1 AND ( (MONTH(tblHoaDonBan.NgayBan)=1 ) OR (MONTH(tblHoaDonBan.NgayBan)=2) OR (MONTH(tblHoaDonBan.NgayBan)=3 ) )  ";
                if (cbomsanpham.Text != "")
                    sql = sql + " AND tblChiTietHoaDonBan.MaSanPham = N'" + cbomsanpham.SelectedValue + "'";


                tblBCHDB = Class.Functions.GetDataToTable(sql);


                if (tblBCHDB.Rows.Count == 0)
                {
                    MessageBox.Show("Không có bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ResetValues();
                    return;
                }
                else
                {
                    MessageBox.Show("Có " + tblBCHDB.Rows.Count + " bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dgnhaphang.DataSource = tblBCHDB;
                    Load_dghoadonnhap();
                    txttongtien.Text = tongtienbaocao().ToString();
                    lblbangchu.Text = "Bằng chữ: " + Class.Functions.ChuyenSoSangChu(txttongtien.Text);


                }
                btntimlai.Enabled = true;
                btnin.Enabled = true;
                return;

            }
            if (rdobtn2.Checked == true)
            {
                sql = "SELECT tblHoaDonBan.MaHoaDonBan,tblChiTietHoaDonBan.MaSanPham, SoLuong, ThanhTien,KhuyenMai,NgayBan,MaNhanVien,MaKhachHang" +
                     " FROM  tblHoaDonBan  join tblChiTietHoaDonBan on tblHoaDonBan.MaHoaDonBan = tblChiTietHoaDonBan.MaHoaDonBan WHERE 1 = 1 AND ( (MONTH(tblHoaDonBan.NgayBan)=4 )OR (MONTH(tblHoaDonBan.NgayBan)=5) OR (MONTH(tblHoaDonBan.NgayBan)=6 ) )";
                if (cbomsanpham.Text != "")
                    sql = sql + "AND tblChiTietHoaDonBan.MaSanPham = N'" + cbomsanpham.SelectedValue + "'";

                tblBCHDB = Class.Functions.GetDataToTable(sql);


                if (tblBCHDB.Rows.Count == 0)
                {
                    MessageBox.Show("Không có bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ResetValues();
                    return;
                }
                else
                {
                    MessageBox.Show("Có " + tblBCHDB.Rows.Count + " bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dgnhaphang.DataSource = tblBCHDB;
                    Load_dghoadonnhap();
                    txttongtien.Text = tongtienbaocao().ToString();


                }
                btntimlai.Enabled = true;
                btnin.Enabled = true;
                return;

            }
            if (rdobtn3.Checked == true)
            {

                sql = "SELECT tblHoaDonBan.MaHoaDonBan,tblChiTietHoaDonBan.MaSanPham, SoLuong, ThanhTien,KhuyenMai,NgayBan,MaNhanVien,MaKhachHang" +
                     " FROM  tblHoaDonBan  join tblChiTietHoaDonBan on tblHoaDonBan.MaHoaDonBan = tblChiTietHoaDonBan.MaHoaDonBan WHERE 1 = 1 AND( (MONTH(tblHoaDonBan.NgayBan)=7 )OR (MONTH(tblHoaDonBan.NgayBan)=8) OR (MONTH(tblHoaDonBan.NgayBan)=9 ) ) ";
                if (cbomsanpham.Text != "")
                    sql = sql + "AND tblChiTietHoaDonBan.MaSanPham = N'" + cbomsanpham.SelectedValue + "'";

                tblBCHDB = Class.Functions.GetDataToTable(sql);


                if (tblBCHDB.Rows.Count == 0)
                {
                    MessageBox.Show("Không có bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ResetValues();
                    return;
                }
                else
                {
                    MessageBox.Show("Có " + tblBCHDB.Rows.Count + " bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dgnhaphang.DataSource = tblBCHDB;
                    Load_dghoadonnhap();
                    txttongtien.Text = tongtienbaocao().ToString(); ;


                }
                btntimlai.Enabled = true;
                btnin.Enabled = true;
                return;


            }
            if (rdobtn4.Checked == true)
            {

                sql = "SELECT tblHoaDonBan.MaHoaDonBan,tblChiTietHoaDonBan.MaSanPham, SoLuong, ThanhTien,KhuyenMai,NgayBan,MaNhanVien,MaKhachHang" +
                     " FROM  tblHoaDonBan  join tblChiTietHoaDonBan on tblHoaDonBan.MaHoaDonBan = tblChiTietHoaDonBan.MaHoaDonBan WHERE 1 = 1 AND ( (MONTH(tblHoaDonBan.Ngayban)=10 )OR (MONTH(tblHoaDonBan.Ngayban)=11) OR (MONTH(tblHoaDonBan.Ngayban)=12 ) ) ";
                if (cbomsanpham.Text != "")
                    sql = sql + "AND tblChiTietHoaDonBan.MaSanPham = N'" + cbomsanpham.SelectedValue + "'";

                tblBCHDB = Class.Functions.GetDataToTable(sql);


                if (tblBCHDB.Rows.Count == 0)
                {
                    MessageBox.Show("Không có bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ResetValues();
                    return;
                }
                else
                {
                    MessageBox.Show("Có " + tblBCHDB.Rows.Count + " bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dgnhaphang.DataSource = tblBCHDB;
                    Load_dghoadonnhap();
                    txttongtien.Text = tongtienbaocao().ToString();

                }
                btntimlai.Enabled = true;
                btnin.Enabled = true;
                return;

            }
        }

        private void btntimlai_Click(object sender, EventArgs e)
        {

            ResetValues();
            btnin.Enabled = false;
            dgnhaphang.DataSource = null;
        }

        private void btndong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnin_Click(object sender, EventArgs e)
        {

            // Khởi động chương trình Excel
            COMExcel.Application exApp = new COMExcel.Application();
            COMExcel.Workbook exBook; //Trong 1 chương trình Excel có nhiều Workbook
            COMExcel.Worksheet exSheet; //Trong 1 Workbook có nhiều Worksheet
            COMExcel.Range exRange;
            string sql;
            int hang = 0, cot = 0;
            DataTable tblThongtinHD;
            exBook = exApp.Workbooks.Add(COMExcel.XlWBATemplate.xlWBATWorksheet);
            exSheet = exBook.Worksheets[1];
            // Định dạng chung
            exRange = exSheet.Cells[1, 1];
            exRange.Range["A1:B3"].Font.Size = 10;
            exRange.Range["A1:B3"].Font.Name = "Times new roman";
            exRange.Range["A1:B3"].Font.Bold = true;
            exRange.Range["A1:B3"].Font.ColorIndex = 5; //Màu xanh da trời
            exRange.Range["A1:A1"].ColumnWidth = 7;
            exRange.Range["B1:B1"].ColumnWidth = 15;
            exRange.Range["A1:B1"].MergeCells = true;
            exRange.Range["A1:B1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A1:B1"].Value = "Cửa hàng giày thể thao We Run";

            exRange.Range["A2:B2"].MergeCells = true;
            exRange.Range["A2:B2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:B2"].Value = "Đống Đa - Hà Nội";

            exRange.Range["A3:B3"].MergeCells = true;
            exRange.Range["A3:B3"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A3:B3"].Value = "Điện thoại: 0349230428";


            exRange.Range["C2:E2"].Font.Size = 16;
            exRange.Range["C2:E2"].Font.Name = "Times new roman";
            exRange.Range["C2:E2"].Font.Bold = true;
            exRange.Range["C2:E2"].Font.ColorIndex = 33; //Xanh lục
            exRange.Range["C2:E2"].MergeCells = true;
            exRange.Range["C2:E2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C2:E2"].Value = "BÁO CÁO BÁN HÀNG";

            exRange.Range["B6:C7"].Font.Size = 12;
            exRange.Range["B6:C7"].Font.Name = "Times new roman";
            exRange.Range["B6:B6"].Value = "Sản Phẩm: ";
            exRange.Range["C6:D6"].MergeCells = true;
            exRange.Range["C6:D6"].Font.Italic = true;
            exRange.Range["C6:D6"].Value = "" + cbomsanpham.Text + " ";

            exRange.Range["B7:B7"].Value = "Thời Gian Bán: ";
            exRange.Range["C7:D7"].MergeCells = true;
            exRange.Range["C7:D7"].Font.Italic = true;


            if (rdobtn1.Checked == true)
            {

                exRange.Range["C7:D7"].Value = " Quý 1";

                sql = "SELECT tblHoaDonBan.MaHoaDonBan,tblChiTietHoaDonBan.MaSanPham, " +
                    "SoLuong, ThanhTien,KhuyenMai,NgayBan,MaNhanVien,MaKhachHang" +
                    " FROM  tblHoaDonBan  join tblChiTietHoaDonBan on tblHoaDonBan.MaHoaDonBan = tblChiTietHoaDonBan.MaHoaDonBan WHERE 1 = 1 AND ((MONTH(tblHoaDonBan.NgayBan)=1 )OR (MONTH(tblHoaDonBan.NgayBan)=2) OR (MONTH(tblHoaDonBan.NgayBan)=3 ) )";
                if (cbomsanpham.Text != "")
                    sql = sql + "AND tblChiTietHoaDonBan.MaSanPham = N'" + cbomsanpham.SelectedValue + "'";
                tblThongtinHD = Class.Functions.GetDataToTable(sql);
                exRange.Range["A11:J11"].Font.Bold = true;
                exRange.Range["A11:J11"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                exRange.Range["C11:F11"].ColumnWidth = 12;
                exRange.Range["A11:A11"].Value = "STT";
                exRange.Range["B11:B11"].Value = "MÃ HÓA ĐƠN";
                exRange.Range["C11:C11"].Value = "MÃ SẢN PHẨM";
                exRange.Range["D11:D11"].Value = "SỐ LƯỢNG";
                exRange.Range["E11:E11"].Value = "THÀNH TIỀN";
                exRange.Range["F11:F11"].Value = "kHUYỄN MÃI";
                exRange.Range["G11:G11"].Value = "NGÀY BÁN";
                exRange.Range["H11:H11"].Value = "MÃ NHÂN VIÊN";
                exRange.Range["I11:I11"].Value = "MÃ KHÁCH HÀNG";

                for (hang = 0; hang <= tblThongtinHD.Rows.Count - 1; hang++)
                {
                    //Điền số thứ tự vào cột 1 từ dòng 12
                    exSheet.Cells[1][hang + 12] = hang + 1;
                    for (cot = 0; cot <= tblThongtinHD.Columns.Count - 1; cot++)
                        //Điền thông tin hàng từ cột thứ 2, dòng 12
                        exSheet.Cells[cot + 2][hang + 12] = tblThongtinHD.Rows[hang][cot].ToString();
                }
                exRange = exSheet.Cells[cot][hang + 14];
                exRange.Font.Bold = true;
                exRange.Value2 = "Tổng tiền:";
                exRange = exSheet.Cells[cot + 1][hang + 14];
                exRange.Font.Bold = true;
                exRange.Value2 = txttongtien.Text + " Đồng";
                // exRange.Range["H17:H17"].Value = lblbangchu.Text + " Đồng";
                exRange = exSheet.Cells[cot+1][hang + 15];
                exRange.Font.Bold = true;
                exRange.Value2 = "Bằng chữ:";
                exRange = exSheet.Cells[cot + 2][hang + 12];
                exRange.Font.Bold = true;
                exRange.Value2 = lblbangchu.Text + " Đồng";


            }
            if (rdobtn2.Checked == true)
            {
                exRange.Range["C7:D7"].Value = " Quý 2  ";
                sql = "SELECT tblHoaDonBan.MaHoaDonBan,tblChiTietHoaDonBan.MaSanPham, " +
                    "SoLuong, ThanhTien,KhuyenMai,NgayBan,MaNhanVien,MaKhachHang" +
                    " FROM  tblHoaDonBan  join tblChiTietHoaDonBan on tblHoaDonBan.MaHoaDonBan = tblChiTietHoaDonBan.MaHoaDonBan WHERE 1 = 1 AND ((MONTH(tblHoaDonBan.NgayBan)=4 )OR (MONTH(tblHoaDonBan.NgayBan)=5) OR (MONTH(tblHoaDonBan.NgayBan)=6) )";
                if (cbomsanpham.Text != "")
                    sql = sql + "AND tblChiTietHoaDonBan.MaSanPham = N'" + cbomsanpham.SelectedValue + "'";
                tblThongtinHD = Class.Functions.GetDataToTable(sql);
                exRange.Range["A11:J11"].Font.Bold = true;
                exRange.Range["A11:J11"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                exRange.Range["C11:F11"].ColumnWidth = 12;
                exRange.Range["A11:A11"].Value = "STT";
                exRange.Range["B11:B11"].Value = "MÃ HÓA ĐƠN";
                exRange.Range["C11:C11"].Value = "MÃ SẢN PHẨM";
                exRange.Range["D11:D11"].Value = "SỐ LƯỢNG";
                exRange.Range["E11:E11"].Value = "THÀNH TIỀN";
                exRange.Range["F11:F11"].Value = "KHUYỄN MÃI";
                exRange.Range["G11:G11"].Value = "NGÀY BÁN";
                exRange.Range["H11:H11"].Value = "MÃ NHÂN VIÊN";
                exRange.Range["I11:I11"].Value = "MÃ KHÁCH HÀNG";

                for (hang = 0; hang <= tblThongtinHD.Rows.Count - 1; hang++)
                {
                    //Điền số thứ tự vào cột 1 từ dòng 12
                    exSheet.Cells[1][hang + 12] = hang + 1;
                    for (cot = 0; cot <= tblThongtinHD.Columns.Count - 1; cot++)
                        //Điền thông tin hàng từ cột thứ 2, dòng 12
                        exSheet.Cells[cot + 2][hang + 12] = tblThongtinHD.Rows[hang][cot].ToString();
                }
                exRange = exSheet.Cells[cot][hang + 14];
                exRange.Font.Bold = true;
                exRange.Value2 = "Tổng tiền:";
                exRange = exSheet.Cells[cot + 1][hang + 14];
                exRange.Font.Bold = true;
                exRange.Value2 = txttongtien.Text + " Đồng";

                exRange = exSheet.Cells[cot + 1][hang + 15];
                exRange.Font.Bold = true;
                exRange.Value2 = "Bằng chữ:";
                exRange = exSheet.Cells[cot + 2][hang + 12];
                exRange.Font.Bold = true;
                exRange.Value2 = lblbangchu.Text + " Đồng";
            }
            if (rdobtn3.Checked == true)
            {
                exRange.Range["C7:D7"].Value = " Quý 3 ";
                sql = "SELECT tblHoaDonBan.MaHoaDonBan,tblChiTietHoaDonBan.MaSanPham, " +
                    "SoLuong, ThanhTien,KhuyenMai,NgayBan,MaNhanVien,MaKhachHang" +
                    " FROM  tblHoaDonBan  join tblChiTietHoaDonBan on tblHoaDonBan.MaHoaDonBan = tblChiTietHoaDonBan.MaHoaDonBan WHERE 1 = 1 AND ((MONTH(tblHoaDonBan.NgayBan)=7 )OR (MONTH(tblHoaDonBan.NgayBan)=8 ) OR (MONTH(tblHoaDonBan.NgayBan)=9 ) )";
                if (cbomsanpham.Text != "")
                    sql = sql + "AND tblChiTietHoaDonBan.MaSanPham = N'" + cbomsanpham.SelectedValue + "'";
                tblThongtinHD = Class.Functions.GetDataToTable(sql);
                exRange.Range["A11:J11"].Font.Bold = true;
                exRange.Range["A11:J11"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                exRange.Range["C11:F11"].ColumnWidth = 12;
                exRange.Range["A11:A11"].Value = "STT";
                exRange.Range["B11:B11"].Value = "MÃ HÓA ĐƠN";
                exRange.Range["C11:C11"].Value = "MÃ SẢN PHẨM";
                exRange.Range["D11:D11"].Value = "SỐ LƯỢNG";
                exRange.Range["E11:E11"].Value = "THÀNH TIỀN";
                exRange.Range["F11:F11"].Value = "kHUYỄN MÃI";
                exRange.Range["G11:G11"].Value = "NGÀY BÁN";
                exRange.Range["H11:H11"].Value = "MÃ NHÂN VIÊN";
                exRange.Range["I11:I11"].Value = "MÃ KHÁCH HÀNG";

                for (hang = 0; hang <= tblThongtinHD.Rows.Count - 1; hang++)
                {
                    //Điền số thứ tự vào cột 1 từ dòng 12
                    exSheet.Cells[1][hang + 12] = hang + 1;
                    for (cot = 0; cot <= tblThongtinHD.Columns.Count - 1; cot++)
                        //Điền thông tin hàng từ cột thứ 2, dòng 12
                        exSheet.Cells[cot + 2][hang + 12] = tblThongtinHD.Rows[hang][cot].ToString();
                }
                exRange = exSheet.Cells[cot][hang + 14];
                exRange.Font.Bold = true;
                exRange.Value2 = "Tổng tiền:";
                exRange = exSheet.Cells[cot + 1][hang + 14];
                exRange.Font.Bold = true;
                exRange.Value2 = txttongtien.Text + " Đồng";

                exRange = exSheet.Cells[cot + 1][hang + 15];
                exRange.Font.Bold = true;
                exRange.Value2 = "Bằng chữ:";
                exRange = exSheet.Cells[cot + 2][hang + 12];
                exRange.Font.Bold = true;
                exRange.Value2 = lblbangchu.Text + " Đồng";
            }
            if (rdobtn4.Checked == true)
            {
                exRange.Range["C7:D7"].Value = " Quý 4 Năm ";
                sql = "SELECT tblHoaDonBan.MaHoaDonBan,tblChiTietHoaDonBan.MaSanPham, " +
                    "SoLuong, ThanhTien,KhuyenMai,NgayBan,MaNhanVien,MaKhachHang" +
                    " FROM  tblHoaDonBan  join tblChiTietHoaDonBan on tblHoaDonBan.MaHoaDonBan = tblChiTietHoaDonBan.MaHoaDonBan WHERE 1 = 1 AND ((MONTH(tblHoaDonBan.NgayBan)=10 )OR (MONTH(tblHoaDonBan.NgayBan)=11 ) OR (MONTH(tblHoaDonBan.NgayBan)=12 ) )";
                if (cbomsanpham.Text != "")
                    sql = sql + "AND tblChiTietHoaDonBan.MaSanPham = N'" + cbomsanpham.SelectedValue + "'";

                tblThongtinHD = Class.Functions.GetDataToTable(sql);
                exRange.Range["A11:J11"].Font.Bold = true;
                exRange.Range["A11:J11"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                exRange.Range["C11:F11"].ColumnWidth = 12;
                exRange.Range["A11:A11"].Value = "STT";
                exRange.Range["B11:B11"].Value = "MÃ HÓA ĐƠN";
                exRange.Range["C11:C11"].Value = "MÃ SẢN PHẨM";
                exRange.Range["D11:D11"].Value = "SỐ LƯỢNG";
                exRange.Range["E11:E11"].Value = "THÀNH TIỀN";
                exRange.Range["F11:F11"].Value = "kHUYỄN MÃI";
                exRange.Range["G11:G11"].Value = "NGÀY BÁN";
                exRange.Range["H11:H11"].Value = "MÃ NHÂN VIÊN";
                exRange.Range["I11:I11"].Value = "MÃ KHÁCH HÀNG";

                for (hang = 0; hang <= tblThongtinHD.Rows.Count - 1; hang++)
                {
                    //Điền số thứ tự vào cột 1 từ dòng 12
                    exSheet.Cells[1][hang + 12] = hang + 1;
                    for (cot = 0; cot <= tblThongtinHD.Columns.Count - 1; cot++)
                        //Điền thông tin hàng từ cột thứ 2, dòng 12
                        exSheet.Cells[cot + 2][hang + 12] = tblThongtinHD.Rows[hang][cot].ToString();
                }
                exRange = exSheet.Cells[cot][hang + 14];
                exRange.Font.Bold = true;
                exRange.Value2 = "Tổng tiền:";
                exRange = exSheet.Cells[cot + 1][hang + 14];
                exRange.Font.Bold = true;
                exRange.Value2 = txttongtien.Text + " Đồng";

                exRange = exSheet.Cells[cot + 1][hang + 15];
                exRange.Font.Bold = true;
                exRange.Value2 = "Bằng chữ:";
                exRange = exSheet.Cells[cot + 2][hang + 12];
                exRange.Font.Bold = true;
                exRange.Value2 = lblbangchu.Text + " Đồng";
            }

            exApp.Visible = true;
        }

        private void lblbangchu_Click(object sender, EventArgs e)
        {

        }
    }
}
