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
    public partial class FrmBaoCaoDoanhThu : Form
    {
        public FrmBaoCaoDoanhThu()
        {
            InitializeComponent();
        }

        DataTable tblbcdt;
        private void ResetValues()
        {
            comboBoxmanhanvien.Text = "";
            textBoxthang.Text = "";
            textBoxdoanhthu.Text = "";
            labelbangchu.Text = "";
            comboBoxmanhanvien.Focus();
        }
        private void FrmBaoCaoDoanhThu_Load(object sender, EventArgs e)
        {
            comboBoxmanhanvien.Enabled = false;
            textBoxthang.Enabled = false;
            buttlinbaocao.Enabled = false;
            buttonhienthij.Enabled = false;
            buttontimlai.Enabled = false;
            textBoxdoanhthu.Enabled = false;
            ResetValues();
            dtgvbcdt.DataSource = null;
        }

        private void textBoxthang_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void buttonbatdau_Click(object sender, EventArgs e)
        {
            Class.Functions.FillCombo("SELECT MaNhanVien FROM tblNhanVien", comboBoxmanhanvien, "MaNhanVien", "MaNhanVien");
            comboBoxmanhanvien.SelectedIndex = -1;
            comboBoxmanhanvien.Enabled = true;
            textBoxthang.Enabled = true;
            buttlinbaocao.Enabled = false;
            buttonhienthij.Enabled = true;
            buttonbatdau.Enabled = false;
        }
        private void Load_DataGridView()
        {
            dtgvbcdt.Columns[0].HeaderText = "Mã nhân viên";
            dtgvbcdt.Columns[1].HeaderText = "Tên nhân viên";
            dtgvbcdt.Columns[2].HeaderText = "Mã hoá đơn bán";
            dtgvbcdt.Columns[3].HeaderText = "Ngày bán";
            dtgvbcdt.Columns[4].HeaderText = "Tổng tiền";
            dtgvbcdt.Columns[0].Width = 150;
            dtgvbcdt.Columns[1].Width = 150;
            dtgvbcdt.Columns[2].Width = 100;
            dtgvbcdt.Columns[3].Width = 100;
            dtgvbcdt.Columns[4].Width = 100;
            dtgvbcdt.AllowUserToAddRows = false;
            dtgvbcdt.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void buttonhienthij_Click(object sender, EventArgs e)
        {
            string sql;
            sql = "SELECT a.MaNhanVien, a.TenNhanVien, b.MaHoaDonBan, b.NgayBan, b.TongTien FROM tblNhanVien AS a JOIN tblHoaDonBan AS b ON a.MaNhanVien = b.MaNhanVien WHERE a.MaNhanVien = N'" + comboBoxmanhanvien.Text + "' AND month(b.NgayBan) = N'" + textBoxthang.Text + "'";
            tblbcdt = Class.Functions.GetDataToTable(sql);
            dtgvbcdt.DataSource = tblbcdt;
            if (comboBoxmanhanvien.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn mã nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                comboBoxmanhanvien.Focus();
                return;
            }
            else if (textBoxthang.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn tháng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBoxthang.Focus();
                return;
            }
            else if (Convert.ToInt32(textBoxthang.Text) > 12 || Convert.ToInt32(textBoxthang.Text) < 1)
            {
                MessageBox.Show("Tháng không hợp lệ, vui lòng nhập lại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBoxthang.Focus();
                return;
            }
            else if (tblbcdt.Rows.Count == 0)
            {
                MessageBox.Show("Không có bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Có " + tblbcdt.Rows.Count + " bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Load_DataGridView();
                sql = "SELECT sum(TongTien) FROM tblHoaDonBan WHERE MaNhanVien = N'" + comboBoxmanhanvien.Text + "' AND month(NgayBan) = N'" + textBoxthang.Text + "'";
                string s = Class.Functions.GetFieldValues(sql);
                textBoxdoanhthu.Text = s;
                labelbangchu.Text = "Bằng chữ: " + Class.Functions.ChuyenSoSangChu(s);
            }
            buttonhienthij.Enabled = false;
            buttontimlai.Enabled = true;
            buttlinbaocao.Enabled = true;
            groupBox1.Enabled = false;
        }

        private void buttlinbaocao_Click(object sender, EventArgs e)
        {
            MessageBox.Show("\tVui lòng chờ...\n Đang cập nhật dữ liệu");
            // Khởi động chương trình Excel
            COMExcel.Application exApp = new COMExcel.Application();
            COMExcel.Workbook exBook; //Trong 1 chương trình Excel có nhiều Workbook
            COMExcel.Worksheet exSheet; //Trong 1 Workbook có nhiều Worksheet
            COMExcel.Range exRange;
            string sql;
            int hang = 0, cot = 0;
            DataTable tblInbcdt;
            exBook = exApp.Workbooks.Add(COMExcel.XlWBATemplate.xlWBATWorksheet);
            exSheet = exBook.Worksheets[1];
            // Định dạng chung
            exRange = exSheet.Cells[1, 1];
            exRange.Range["A1:B3"].Font.Size = 15;
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

            exRange.Range["C6:F6"].Font.Size = 18;
            exRange.Range["C6:F6"].Font.Name = "Times new roman";
            exRange.Range["C6:F6"].Font.Bold = true;
            exRange.Range["C6:F6"].Font.ColorIndex = 3; //Màu đỏ
            exRange.Range["C6:F6"].MergeCells = true;
            exRange.Range["C6:F6"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C6:F6"].Value = "Bảng báo cáo doanh thu";

            sql = "SELECT a.MaNhanVien, a.TenNhanVien, b.MaHoaDonBan, b.NgayBan, b.TongTien FROM tblNhanVien a JOIN tblHoaDonBan b ON a.MaNhanVien = b.MaNhanVien WHERE a.MaNhanVien = N'" + comboBoxmanhanvien.Text + "' and month(b.NgayBan) = '" + textBoxthang.Text + "'";

            tblInbcdt = Class.Functions.GetDataToTable(sql);
            //Tạo dòng tiêu đề bảng
            exRange.Range["A11:F11"].Font.Bold = true;
            exRange.Range["A11:F11"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C11:F11"].ColumnWidth = 12;
            exRange.Range["C8:C8"].Value = "Mã nhân viên";
            exRange.Range["D8:D8"].Value = "Tên nhân viên";
            exRange.Range["E8:E8"].Value = "Mã hoá đơn bán";
            exRange.Range["F8:F8"].Value = "Ngày bán";
            exRange.Range["G8:G8"].Value = "Tổng tiền";
            for (hang = 0; hang <= tblInbcdt.Rows.Count - 1; hang++)
            {
                for (cot = 0; cot <= tblInbcdt.Columns.Count - 1; cot++)
                    //Điền thông tin hàng từ cột thứ 3, dòng 9
                    exSheet.Cells[cot + 3][hang + 9] = tblInbcdt.Rows[hang][cot].ToString();
            }
            exRange = exSheet.Cells[cot + 2][hang + 10];
            exRange.Font.Bold = true;
            exRange.Value2 = "Doanh thu: " + textBoxdoanhthu.Text;
            exRange = exSheet.Cells[3][hang + 11];
            exRange.Range["A1:F1"].MergeCells = true;
            exRange.Range["A1:F1"].Font.Bold = true;
            exRange.Range["A1:F1"].Font.Italic = true;
            exRange.Range["A1:F1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignRight;
            exRange.Range["A1:F1"].Value = "Bằng chữ: " + Class.Functions.ChuyenSoSangChu(textBoxdoanhthu.Text);
            exRange = exSheet.Cells[6][hang + 14];
            exRange.Range["A1:C1"].MergeCells = true;
            exRange.Range["A1:C1"].Font.Italic = true;
            exRange.Range["A1:C1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            DateTime d = Convert.ToDateTime(tblbcdt.Rows[0][3]);
            exRange.Range["A1:C1"].Value = "Hà Nội, ngày " + d.Day + " tháng " + d.Month + " năm " + d.Year;
            exRange.Range["A2:C2"].MergeCells = true;
            exRange.Range["A2:C2"].Font.Italic = true;
            exRange.Range["A2:C2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:C2"].Value = "Nhân viên bán hàng";
            exRange = exSheet.Cells[cot + 2][hang + 16];
            exRange.Font.Bold = true;
            exRange.Value2 = tblInbcdt.Rows[0][1].ToString();
            exSheet.Name = "Báo cáo doanh thu";
            exApp.Visible = true;
        }

        private void buttontimlai_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            buttontimlai.Enabled = false;
            buttonhienthij.Enabled = true;
            buttlinbaocao.Enabled = false;
            ResetValues();
            dtgvbcdt.DataSource = null;
        }

        private void buttondong_Click(object sender, EventArgs e)
        {
            DialogResult a = MessageBox.Show("Bạn có muốn thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (a == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void dtgvbcdt_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string mahd;
            if (MessageBox.Show("Bạn có muốn hiển thị thông tin chi tiết?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                mahd = dtgvbcdt.CurrentRow.Cells["MaHoaDonBan"].Value.ToString();
                FrmHoaDonBan frm = new FrmHoaDonBan();
                frm.txtmahoadonban.Text = mahd;
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowDialog();
            }
        }
    }
}
