using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using COMExel = Microsoft.Office.Interop.Excel;

namespace Ajuma.Forms
{
    public partial class FrmBaoCaoHoaDonNhap : Form
    {

        DataTable tblhdn;
        public FrmBaoCaoHoaDonNhap()
        {
            InitializeComponent();
        }

        private void FrmBaoCaoHoaDonNhap_Load(object sender, EventArgs e)
        {
            txttongtien.Enabled = false;
            btntimlai.Enabled = false;
            btnin.Enabled = false;
            txttongtien.Text = "0";
            resetvalues();
            dgbchdnhap.DataSource = null;
            Class.Functions.FillCombo("select MaNhaCungCap,TenNhaCungCap from tblNhaCungCap", cbonhacc, "MaNhaCungCap", "TenNhaCungCap");
            cbonhacc.SelectedIndex = -1;
            Load_dghoadonnhap();
            //
            // Chạy animation Slogan
            text = lblText.Text;
            lblText.Text = "";
            timer1.Start();
        }
        private string text;
        private int len = 0;
        private void resetvalues()
        {
            txttongtien.Text = "";
            cbonhacc.Text = "";
            Load_dghoadonnhap();
            lbbangchu.Text = "Bằng Chữ : ";
        }

        private void Load_dghoadonnhap()
        {
            string sql;
            sql = "SELECT MaHoaDonNhap, NgayNhap, MaNhanVien, MaNhaCungCap, TongTien FROM tblHoaDonNhap";
            tblhdn = Class.Functions.GetDataToTable(sql);
            dgbchdnhap.DataSource = tblhdn;
            dgbchdnhap.Columns[0].HeaderText = "Mã Hóa Đơn";
            dgbchdnhap.Columns[1].HeaderText = "Ngày Nhập";
            dgbchdnhap.Columns[2].HeaderText = "Mã Nhân Viên";
            dgbchdnhap.Columns[3].HeaderText = "Mã Nhà Cung Cấp";
            dgbchdnhap.Columns[4].HeaderText = "Thành Tiền";
            dgbchdnhap.Columns[0].Width = 150;
            dgbchdnhap.Columns[1].Width = 100;
            dgbchdnhap.Columns[2].Width = 100;
            dgbchdnhap.Columns[3].Width = 150;
            dgbchdnhap.Columns[4].Width = 100;
            dgbchdnhap.AllowUserToAddRows = false;
            dgbchdnhap.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            string sql;
            double tongtien;
            if (cbonhacc.Text == "")
            {
                MessageBox.Show("Hãy Chọn Nhà Cung Cấp", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbonhacc.Focus();
                return;
            }
            sql = " Select * from  tblHoaDonNhap WHERE 1=1";

            //sql = "SELECT ngayban FROM tblhoadonnhap WHERE manhacungcap = SELECT manhacungcap FROM tblnhacungcap WHERE tennhacungcap= N'" + cbonhacc.Text + "' ";
            if (cbonhacc.Text != "")

                sql = sql + "AND MaNhaCungCap = '" + cbonhacc.SelectedValue + "'";

            tblhdn = Class.Functions.GetDataToTable(sql);
            if (tblhdn.Rows.Count == 0)
            {
                MessageBox.Show("Không có bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                resetvalues();
            }
            else
            {
                MessageBox.Show("Có " + tblhdn.Rows.Count + " bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dgbchdnhap.DataSource = tblhdn;

                tongtien = Convert.ToDouble(Class.Functions.GetFieldValues("SELECT SUM(TongTien) FROM tblHoaDonNhap WHERE MaNhaCungCap= '" + cbonhacc.SelectedValue + "'"));
                txttongtien.Text = tongtien.ToString();
                btndong.Enabled = true;
                btnin.Enabled = true;
                lbbangchu.Text = "Bằng chữ: " + Class.Functions.ChuyenSoSangChu(txttongtien.Text);
            }
            //Load_dghoadonnhap();

            btnin.Enabled = true;
            btntimlai.Enabled = true;
        }

        private void btnin_Click(object sender, EventArgs e)
        {
            // Khởi động chương trình Excel
            COMExel.Application exApp = new COMExel.Application();
            COMExel.Workbook exBook; //Trong 1 chương trình Excel có nhiều Workbook
            COMExel.Worksheet exSheet; //Trong 1 Workbook có nhiều Worksheet
            COMExel.Range exRange;
            string sql;
            int hang = 0, cot = 0;
            DataTable tblThongtinHD, tblThongtinNCC;
            exBook = exApp.Workbooks.Add(COMExel.XlWBATemplate.xlWBATWorksheet);
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
            exRange.Range["A1:B1"].HorizontalAlignment = COMExel.XlHAlign.xlHAlignCenter;
            exRange.Range["A1:B1"].Value = "We Run Shoes";

            exRange.Range["A2:B2"].MergeCells = true;
            exRange.Range["A2:B2"].HorizontalAlignment = COMExel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:B2"].Value = "Đống Đa - Hà Nội";

            exRange.Range["A3:B3"].MergeCells = true;
            exRange.Range["A3:B3"].HorizontalAlignment = COMExel.XlHAlign.xlHAlignCenter;
            exRange.Range["A3:B3"].Value = "Điện thoại: (08)9999-9999";


            exRange.Range["C2:E2"].Font.Size = 16;
            exRange.Range["C2:E2"].Font.Name = "Times new roman";
            exRange.Range["C2:E2"].Font.Bold = true;
            exRange.Range["C2:E2"].Font.ColorIndex = 3; //Màu đỏ
            exRange.Range["C2:E2"].MergeCells = true;

            exRange.Range["C2:E2"].HorizontalAlignment = COMExel.XlHAlign.xlHAlignCenter;
            exRange.Range["C2:E2"].Value = "HÓA ĐƠN NHẬP";
            // Biểu diễn thông tin chung của hóa đơn bán

            sql = "SELECT MaNhaCungCap, TenNhaCungCap, DiaChi, SoDienThoai FROM tblNhaCungCap  WHERE MaNhaCungCap =N'" + cbonhacc.SelectedValue + "'";
            tblThongtinNCC = Class.Functions.GetDataToTable(sql);
            exRange.Range["B6:C9"].Font.Size = 12;
            exRange.Range["B6:C9"].Font.Name = "Times new roman";
            exRange.Range["B6:B6"].Value = "MÃ NHÀ CUNG CÂP:";
            exRange.Range["C6:E6"].MergeCells = true;
            exRange.Range["C6:E6"].Value = tblThongtinNCC.Rows[0][0].ToString();
            exRange.Range["B7:B7"].Value = "TÊN NHÀ CUNG CÂP:";
            exRange.Range["C7:E7"].MergeCells = true;
            exRange.Range["C7:E7"].Value = tblThongtinNCC.Rows[0][1].ToString();
            exRange.Range["B8:B8"].Value = "ĐỊA CHỈ:";
            exRange.Range["C8:E8"].MergeCells = true;
            exRange.Range["C8:E8"].Value = tblThongtinNCC.Rows[0][2].ToString();
            exRange.Range["B9:B9"].Value = "ĐIỆN THOẠI:";
            exRange.Range["C9:E9"].MergeCells = true;
            exRange.Range["C9:E9"].Value = tblThongtinNCC.Rows[0][3].ToString();

            //Lấy thông tin hóa đơn
            sql = "SELECT  MaHoaDonNhap,NgayNhap,MaNhanVien,MaNhaCungCap,TongTien FROM tblHoaDonNhap  WHERE MaNhaCungCap =N'" + cbonhacc.SelectedValue + "'";
            tblThongtinHD = Class.Functions.GetDataToTable(sql);
            exRange.Range["A11:F11"].Font.Bold = true;
            exRange.Range["A11:F11"].HorizontalAlignment = COMExel.XlHAlign.xlHAlignCenter;
            exRange.Range["C11:F11"].ColumnWidth = 12;
            exRange.Range["A11:A11"].Value = "STT";
            exRange.Range["B11:B11"].Value = "MÃ HÓA ĐƠN";
            exRange.Range["C11:C11"].Value = "NGÀY NHẬP";
            exRange.Range["D11:D11"].Value = "MÃ NHÂN VIÊN";
            exRange.Range["E11:E11"].Value = "MÃ NHÀ CUNG CÂP";
            exRange.Range["F11:F11"].Value = "THÀNH TIỀN"; for (hang = 0; hang <= tblThongtinHD.Rows.Count - 1; hang++)
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
            exRange.Value2 = txttongtien.Text; //.value, .Text
            exRange = exSheet.Cells[1][hang + 15]; //Ô A1 


            exRange.Range["A1:F1"].MergeCells = true;
            exRange.Range["A1:F1"].Font.Bold = true;
            exRange.Range["A1:F1"].Font.Italic = true;
            exRange.Range["A1:F1"].HorizontalAlignment = COMExel.XlHAlign.xlHAlignRight;
            // COMExcel.XlHAlign.xlHAlignRight;
            exRange.Range["A1:F1"].Value = "Bằng chữ: " + Class.Functions.ChuyenSoSangChu(txttongtien.Text);


            exRange = exSheet.Cells[4][hang + 19]; //Ô A1 
            exRange.Range["A1:C1"].MergeCells = true;
            exRange.Range["A1:C1"].Font.Italic = true;
            exRange.Range["A1:C1"].HorizontalAlignment = COMExel.XlHAlign.xlHAlignCenter;
            DateTime d = Convert.ToDateTime(tblThongtinHD.Rows[0][1]);//
            
            exRange.Range["A1:C1"].Value = "Hà Nội, ngày " + d.Day + " tháng " + d.Month + " năm " + d.Year;
            exRange.Range["A2:C2"].MergeCells = true;
            exRange.Range["A2:C2"].Font.Italic = true;
            exRange.Range["A2:C2"].HorizontalAlignment = COMExel.XlHAlign.xlHAlignCenter;
            exRange.Range["A6:C6"].HorizontalAlignment = COMExel.XlHAlign.xlHAlignCenter;

            exSheet.Name = "Hóa đơn nhập";

            exApp.Visible = true;
        }

        private void btntimlai_Click(object sender, EventArgs e)
        {
            resetvalues();
        }

        private void btndong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

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
