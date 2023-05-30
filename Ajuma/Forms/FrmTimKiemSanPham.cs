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
    public partial class FrmTimKiemSanPham : Form
    {
        public FrmTimKiemSanPham()
        {
            InitializeComponent();
        }
        DataTable tblTSP;
        private void ResetValues()
        {
            foreach (Control Ctl in this.Controls)
            {
                if (Ctl is TextBox)
                    Ctl.Text = "";

            }
            textBoxsoluong.Text = "";
            comboBoxmaloai.Text = "";
            comboBoxmachatlieu.Text = "";
            comboBoxmaloai.Focus();
        }


        private void Load_DataGridView()
        {
            dtgvTimsp.Columns[0].HeaderText = "Mã sản phẩm";
            dtgvTimsp.Columns[1].HeaderText = "Tên sản phẩm";
            dtgvTimsp.Columns[2].HeaderText = "Giá Nhập";
            dtgvTimsp.Columns[3].HeaderText = "Giá bán";
            dtgvTimsp.Columns[4].HeaderText = "Số lượng";
            dtgvTimsp.Columns[5].HeaderText = "Hình ảnh";
            dtgvTimsp.Columns[6].HeaderText = "Mã loại";
            dtgvTimsp.Columns[7].HeaderText = "Mã nước";
            dtgvTimsp.Columns[8].HeaderText = "Mã chất liệu";
            dtgvTimsp.Columns[9].HeaderText = "Mã màu";
            dtgvTimsp.Columns[0].Width = 150;
            dtgvTimsp.Columns[1].Width = 100;
            dtgvTimsp.Columns[2].Width = 80;
            dtgvTimsp.Columns[3].Width = 80;
            dtgvTimsp.Columns[4].Width = 100;
            dtgvTimsp.Columns[5].Width = 100;
            dtgvTimsp.Columns[6].Width = 100;
            dtgvTimsp.Columns[7].Width = 100;
            dtgvTimsp.Columns[8].Width = 100;
            dtgvTimsp.Columns[9].Width = 100;
            dtgvTimsp.AllowUserToAddRows = false;
            dtgvTimsp.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void FrmTimKiemSanPham_Load(object sender, EventArgs e)
        {
            Class.Functions.FillCombo("SELECT MaLoai, TenLoai FROM tblTheLoai", comboBoxmaloai, "MaLoai", "MaLoai");
            comboBoxmaloai.SelectedIndex = -1;
            Class.Functions.FillCombo("SELECT MaChatLieu, TenChatLieu FROM tblChatLieu", comboBoxmachatlieu, "MaChatLieu", "MaChatLieu");
            comboBoxmachatlieu.SelectedIndex = -1;
            ResetValues();
            dtgvTimsp.DataSource = null;
            buttltimlai.Enabled = false;
        }

        private void buttontimkie_Click(object sender, EventArgs e)
        {
            string sql;
            if ((comboBoxmaloai.Text == "") && (comboBoxmachatlieu.Text == "") && (textBoxsoluong.Text == ""))
            {
                MessageBox.Show("Hãy nhập một điều kiện tìm kiếm!!!", "Yeu cau ...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = "select * from tblSanPham where 1=1";
            if (comboBoxmaloai.Text != "")
                sql = sql + " and MaLoai like N'%" + comboBoxmaloai.Text + "%'";
            if (comboBoxmachatlieu.Text != "")
                sql = sql + " and MaChatLieu like N'%" + comboBoxmachatlieu.Text + "%'";
            if (textBoxsoluong.Text != "")
                sql = sql + " and SoLuong = " + textBoxsoluong.Text + "";
            tblTSP = Class.Functions.GetDataToTable(sql);
            if (tblTSP.Rows.Count == 0)
            {
                MessageBox.Show("Không có bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ResetValues();
            }
            else
                MessageBox.Show("Có " + tblTSP.Rows.Count + " bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            dtgvTimsp.DataSource = tblTSP;
            Load_DataGridView();
            groupBox1.Enabled = false;
            buttontimkie.Enabled = false;
            buttltimlai.Enabled = true;
        }

        private void textBoxsoluong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void dtgvTimsp_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string MaSp;
            if (MessageBox.Show("Bạn có muốn hiển thị thông tin chi tiết?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                MaSp = dtgvTimsp.CurrentRow.Cells["MaSanPham"].Value.ToString();
               // string 
                FrmSanPham frm = new FrmSanPham();
                frm.txtMasanpham.Text = MaSp;
                string a;
                a = "SELECT MaSanPham, TenSanPham, GiaNhap, GiaBan, SoLuong, HinhAnh, MaLoai, MaNuoc, MaChatLieu, MaMau FROM tblSanPham where MaSanPham=N'" + frm.txtMasanpham.Text + "' ";
                frm.sql = a;
                
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowDialog();
            }
        }

        private void buttltimlai_Click(object sender, EventArgs e)
        {
            ResetValues();
            groupBox1.Enabled = true;
            buttltimlai.Enabled = false;
            buttontimkie.Enabled = true;
            dtgvTimsp.DataSource = null;
        }

        private void buttdong_Click(object sender, EventArgs e)
        {
            DialogResult a = MessageBox.Show("Bạn có muốn thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (a == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
