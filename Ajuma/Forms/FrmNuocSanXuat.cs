using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ajuma.Class;

namespace Ajuma.Forms
{
    public partial class FrmNuocSanXuat : Form
    {
        public FrmNuocSanXuat()
        {
            InitializeComponent();
        }
        DataTable tblNuocSanXuat;

        private void FrmNuocSanXuat_Load(object sender, EventArgs e)
        {
            txtmanuoc.Enabled = false;

            btnLuu.Enabled = false;
            btnBoqua.Enabled = false;
            Load_DataGridView();
        }
        private void Load_DataGridView()
        {
            string sql;
            sql = "SELECT MaNuoc, TenNuoc FROM tblNuocSanXuat";
            tblNuocSanXuat = Class.Functions.GetDataToTable(sql);
            DataGridView.DataSource = tblNuocSanXuat;
            DataGridView.Columns[0].HeaderText = "Mã nước sản xuất";
            DataGridView.Columns[1].HeaderText = "Tên nước sản xuất";
            DataGridView.Columns[0].Width = 300;
            DataGridView.Columns[1].Width = 300;
            // Không cho phép thêm mới dữ liệu trực tiếp trên lưới
            DataGridView.AllowUserToAddRows = false;
            // Không cho phép sửa dữ liệu trực tiếp trên lưới
            DataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void DataGridView_Click(object sender, EventArgs e)
        {
            txtmanuoc.Enabled = false;
            txttennuoc.Enabled = true;
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmanuoc.Focus();
                return;
            }
            if (tblNuocSanXuat.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtmanuoc.Text = DataGridView.CurrentRow.Cells["MaNuoc"].Value.ToString();
            txttennuoc.Text = DataGridView.CurrentRow.Cells["TenNuoc"].Value.ToString();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnBoqua.Enabled = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            groupBox3.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnBoqua.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            ResetValues();
            txtmanuoc.Focus();
        }
        private void ResetValues()
        {
            txttennuoc.Enabled = true;
            txtmanuoc.Enabled = true;
            txtmanuoc.Text = "";
            txttennuoc.Text = "";

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtmanuoc.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã nước", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtmanuoc.Focus();
                return;
            }
            if (txttennuoc.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên nước", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txttennuoc.Focus();
                return;
            }


            sql = "SELECT MaNuoc FROM tblNuocSanXuat WHERE manuoc=N'" + txtmanuoc.Text.Trim() + "'";
            if (Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã nước này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtmanuoc.Focus();
                txtmanuoc.Text = "";
                return;
            }

            sql = "INSERT INTO tblNuocSanXuat(MaNuoc,TenNuoc) VALUES(N'" + txtmanuoc.Text + "',N'" + txttennuoc.Text + "')";
            Functions.RunSql(sql);
            Load_DataGridView();
            ResetValues();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnBoqua.Enabled = false;
            btnLuu.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblNuocSanXuat.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtmanuoc.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE tblNuocSanXuat WHERE MaNuoc=N'" + txtmanuoc.Text + "'";
                Functions.RunSqlDel(sql);
                Load_DataGridView();
                ResetValues();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblNuocSanXuat.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtmanuoc.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txttennuoc.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên nước", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txttennuoc.Focus();
                return;
            }

            sql = "UPDATE tblNuocSanXuat SET TenNuoc=N'" + txttennuoc.Text.ToString() + "' WHERE MaNuoc=N'" + txtmanuoc.Text + "'";
            Functions.RunSql(sql);
            Load_DataGridView();
            ResetValues();
            btnBoqua.Enabled = false;
        }

        private void btnBoqua_Click(object sender, EventArgs e)
        {
            ResetValues();
            btnBoqua.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
