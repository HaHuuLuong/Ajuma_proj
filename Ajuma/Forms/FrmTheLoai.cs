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
    public partial class FrmTheLoai : Form
    {
        public FrmTheLoai()
        {
            InitializeComponent();
        }
        DataTable tbldd;
        private void FrmTheLoai_Load(object sender, EventArgs e)
        {
            txtmaloai.Enabled = false;
            btnLuu.Enabled = false;
            btnBoqua.Enabled = false;
            Load_Dgrid();

            // Chạy animation Slogan
            text = lblText.Text;
            lblText.Text = "";
            timer1.Start();
        }
        private string text;
        private int len = 0;
        private void Load_Dgrid()
        {
            string sql;
            sql = "SELECT MaLoai, TenLoai FROM tblTheLoai";
            tbldd = Class.Functions.GetDataToTable(sql);
            DataGridView.DataSource = tbldd;
            DataGridView.Columns[0].HeaderText = "Mã loại";
            DataGridView.Columns[1].HeaderText = "Tên loại";
            DataGridView.Columns[0].Width = 90;
            DataGridView.Columns[1].Width = 90;
            // Không cho phép thêm mới dữ liệu trực tiếp trên lưới
            DataGridView.AllowUserToAddRows = false;
            // Không cho phép sửa dữ liệu trực tiếp trên lưới
            DataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void DataGridView_Click(object sender, EventArgs e)
        {
            txtmaloai.Enabled = false;
            txttenloai.Enabled = true;
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmaloai.Focus();
                return;
            }
            if (tbldd.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtmaloai.Text = DataGridView.CurrentRow.Cells["maloai"].Value.ToString();
            txttenloai.Text = DataGridView.CurrentRow.Cells["tenloai"].Value.ToString();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnBoqua.Enabled = true;
        }
        private void ResetValues()
        {

            txttenloai.Enabled = true;
            txtmaloai.Enabled = true;
            txtmaloai.Text = "";
            txttenloai.Text = "";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnBoqua.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            ResetValues();
            txtmaloai.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;

            if (txtmaloai.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã loại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtmaloai.Focus();
                return;
            }
            if (txttenloai.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên loại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txttenloai.Focus();
                return;
            }

            sql = "SELECT MaLoai FROM tblTheLoai WHERE MaLoai=N'" + txtmaloai.Text.Trim() + "'";
            if (Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã loại này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtmaloai.Focus();
                txtmaloai.Text = "";
                return;
            }

            sql = "INSERT INTO tblTheLoai(MaLoai,TenLoai) VALUES(N'" + txtmaloai.Text + "',N'" + txttenloai.Text + "')";
            Functions.RunSql(sql);
            Load_Dgrid();
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

            if (txttenloai.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên loại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txttenloai.Focus();
                return;
            }

            sql = "UPDATE tblTheLoai SET TenLoai=N'" + txttenloai.Text.ToString() + "' WHERE MaLoai=N'" + txtmaloai.Text + "'";
            Functions.RunSql(sql);

            Load_Dgrid();
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
            if (txtmaloai.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {

                sql = "DELETE tblTheLoai WHERE MaLoai=N'" + txtmaloai.Text + "'";
                Functions.RunSqlDel(sql);
                Load_Dgrid();
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
