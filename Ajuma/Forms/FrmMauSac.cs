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
    public partial class FrmMauSac : Form
    {
        public FrmMauSac()
        {
            InitializeComponent();
        }
        DataTable tbldd;
        private void FrmMauSac_Load(object sender, EventArgs e)
        {
            txtmamau.Enabled = false;
            btnLuu.Enabled = false;
            btnBoqua.Enabled = false;
            Load_DataGridView();
        }
        private void Load_DataGridView()
        {
            string sql;
            sql = "SELECT mamau,tenmau FROM tblmausac";
            tbldd = Class.Functions.GetDataToTable(sql);
            DataGridView.DataSource = tbldd;
            DataGridView.Columns[0].HeaderText = "Mã màu";
            DataGridView.Columns[1].HeaderText = "Tên màu";
            DataGridView.Columns[0].Width = 200;
            DataGridView.Columns[1].Width = 200;
            // Không cho phép thêm mới dữ liệu trực tiếp trên lưới
            DataGridView.AllowUserToAddRows = false;
            // Không cho phép sửa dữ liệu trực tiếp trên lưới
            DataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void DataGridView_Click(object sender, EventArgs e)
        {
            txtmamau.Enabled = false;
            txttenmau.Enabled = true;
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmamau.Focus();
                return;
            }
            if (tbldd.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtmamau.Text = DataGridView.CurrentRow.Cells["MaMau"].Value.ToString();
            txttenmau.Text = DataGridView.CurrentRow.Cells["TenMau"].Value.ToString();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnBoqua.Enabled = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            groupBox2.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnBoqua.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            ResetValues();
            txtmamau.Focus();
        }

        private void ResetValues()
        {

            txttenmau.Enabled = true;
            txtmamau.Enabled = true;
            txtmamau.Text = "";
            txttenmau.Text = "";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;


            if (txtmamau.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã màu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtmamau.Focus();
                return;
            }
            if (txttenmau.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên màu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txttenmau.Focus();
                return;
            }

            sql = "SELECT MaMau FROM tblMauSac WHERE MaMau=N'" + txtmamau.Text.Trim() + "'";
            if (Class.Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã màu này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtmamau.Focus();
                txtmamau.Text = "";
                return;
            }



            sql = "INSERT INTO tblMauSac(MaMau,TenMau) VALUES(N'" + txtmamau.Text + "',N'" + txttenmau.Text + "')";
            Class.Functions.RunSql(sql);


            Load_DataGridView();
            ResetValues();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnBoqua.Enabled = false;
            btnLuu.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tbldd.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtmamau.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (txttenmau.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên mau", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txttenmau.Focus();
                return;
            }

            sql = "UPDATE tblMauSac SET TenMau=N'" + txttenmau.Text.ToString() + "' WHERE MaMau=N'" + txtmamau.Text + "'";
            Class.Functions.RunSql(sql);
            Load_DataGridView();
            ResetValues();
            btnBoqua.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tbldd.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtmamau.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {

                sql = "DELETE tblMauSac WHERE MaMau=N'" + txtmamau.Text + "'";
                Class.Functions.RunSqlDel(sql);
                Load_DataGridView();
                ResetValues();
            }
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
