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
    public partial class FrmTaiKhoan : Form
    {
        public FrmTaiKhoan()
        {
            InitializeComponent();
        }
        DataTable tbl;
        private void FrmTaiKhoan_Load(object sender, EventArgs e)
        {
            btnLuu.Enabled = false;
            btnBoQua.Enabled = false;
            btnVHH.Enabled = false;
            btnKH.Enabled = false;
            LoadDataGridView();
        }
        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT IDTaiKhoan, taiKhoan, matKhau, LoaiTK, trangThai FROM TaiKhoan";
            tbl = Class.Functions.GetDataToTable(sql);
            gridView.DataSource = tbl;
            gridView.Columns[0].HeaderText = "Mã tài khoản";
            gridView.Columns[1].HeaderText = "Username";
            gridView.Columns[2].HeaderText = "Password";
            gridView.Columns[3].HeaderText = "Loại";
            gridView.Columns[4].HeaderText = "Trạng thái";
            // Không cho phép thêm mới dữ liệu trực tiếp trên lưới
            gridView.AllowUserToAddRows = false;
            // Không cho phép sửa dữ liệu trực tiếp trên lưới
            gridView.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void gridView_Click(object sender, EventArgs e)
        {
            txtMaTK.Enabled = false;
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaTK.Focus();
                txtMaTK.Enabled = true;
                return;
            }
            if (tbl.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtMaTK.Text = gridView.CurrentRow.Cells["IDTaiKhoan"].Value.ToString();
            txtTK.Text = gridView.CurrentRow.Cells["taiKhoan"].Value.ToString();
            txtMK.Text = gridView.CurrentRow.Cells["matKhau"].Value.ToString();
            cboLoaiTK.Text = gridView.CurrentRow.Cells["LoaiTK"].Value.ToString();

            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnBoQua.Enabled = true;
            btnVHH.Enabled = true;
            btnKH.Enabled = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void txtTK_TextChanged(object sender, EventArgs e)
        {

        }
        private void ResetValue()
        {
            txtMaTK.Text = "";
            txtTK.Text = "";
            txtMK.Text = "";
            cboLoaiTK.SelectedIndex = -1;
            txtMaTK.Enabled = true;
            txtTK.Enabled = true;
            txtMK.Enabled = true;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnBoQua.Enabled = true;
            btnThem.Enabled = false;
            ResetValue();
            txtTK.Focus();
            btnVHH.Enabled = false;
            btnKH.Enabled = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtMaTK.Text.Trim() == "")
            {
                MessageBox.Show("Bạn phải nhập mã tài khoản", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaTK.Focus();
                return;
            }
            if (txtTK.Text.Trim() == "")
            {
                MessageBox.Show("Bạn phải nhập tài khoản", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTK.Focus();
                return;
            }
            if (txtMK.Text.Trim() == "")
            {
                MessageBox.Show("Bạn phải nhập mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMK.Focus();
                return;
            }
            if (cboLoaiTK.SelectedIndex == -1)
            {
                MessageBox.Show("Bạn phải chọn loại tài khoản", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = "SELECT * FROM TaiKhoan WHERE IDTaiKhoan = N'" + txtMaTK.Text.Trim() + "'";
            if (Class.Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã tài khoản này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaTK.Focus();
                txtMaTK.Text = "";
                return;
            }

            sql = "INSERT INTO TaiKhoan(IDTaiKhoan, taiKhoan, matKhau, LoaiTK) VALUES(N'"+txtMaTK.Text+ "', N'"+txtTK.Text+ "', N'"+txtMK.Text+ "', N'"+cboLoaiTK.Text+"')";
            Class.Functions.RunSql(sql);

            LoadDataGridView();
            ResetValue();

            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnBoQua.Enabled = false;
            btnLuu.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tbl.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaTK.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTK.Text.Trim() == "")
            {
                MessageBox.Show("Bạn phải nhập tài khoản", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTK.Focus();
                return;
            }
            if (txtMK.Text.Trim() == "")
            {
                MessageBox.Show("Bạn phải nhập mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTK.Focus();
                return;
            }

            sql = "UPDATE TaiKhoan SET taiKhoan = N'" + txtTK.Text.Trim() + "', matKhau = N'" + txtMK.Text.Trim() + "', LoaiTK = N'" + cboLoaiTK.Text + "' WHERE IDTaiKhoan = N'"+txtMaTK.Text+"'";
            Class.Functions.RunSql(sql);
            LoadDataGridView();
            ResetValue();
            btnBoQua.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tbl.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaTK.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {

                sql = "DELETE TaiKhoan WHERE IDTaiKhoan=N'" + txtMaTK.Text + "'";
                Class.Functions.RunSqlDel(sql);
                LoadDataGridView();
                ResetValue();
            }
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            ResetValue();
            btnBoQua.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            btnVHH.Enabled = false;
            btnKH.Enabled = false;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnVHH_Click(object sender, EventArgs e)
        {
            string sql;
            sql = "SELECT TrangThai FROM TaiKhoan WHERE IDTaiKhoan = N'" + txtMaTK.Text.Trim() + "'";
            string flag = Class.Functions.GetFieldValues(sql);
            switch(flag)
            {
                case "0":
                    if (MessageBox.Show("Bạn có muốn vô hiệu hóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {

                        sql = "UPDATE TaiKhoan SET TrangThai = 1 WHERE IDTaiKhoan = N'" + txtMaTK.Text + "'";
                        Class.Functions.RunSql(sql);
                        LoadDataGridView();
                        ResetValue();
                        btnVHH.Enabled = false;
                        btnKH.Enabled = false;
                    }
                    break;

                case "1":
                    MessageBox.Show("Tài khoản này đã bị vô hiệu hóa", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    break;
                case "9":
                    MessageBox.Show("Không thể vô hiệu hóa tài khoản quản trị!!!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    break;
            }
        }

        private void btnKH_Click(object sender, EventArgs e)
        {
            string sql;
            sql = "SELECT TrangThai FROM TaiKhoan WHERE IDTaiKhoan = N'" + txtMaTK.Text.Trim() + "'";
            string flag = Class.Functions.GetFieldValues(sql);
            switch(flag)
            {
                case "1":
                    if (MessageBox.Show("Bạn có muốn kích hoạt không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {

                        sql = "UPDATE TaiKhoan SET TrangThai = 0 WHERE IDTaiKhoan = N'" + txtMaTK.Text + "'";
                        Class.Functions.RunSql(sql);
                        LoadDataGridView();
                        ResetValue();
                        btnVHH.Enabled = false;
                        btnKH.Enabled = false;
                    }
                    break;

                case "0":
                    MessageBox.Show("Tài khoản này đã được kích hoạt", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    break;
            }
        }
    }
}
