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
    public partial class FrmAlbum : Form
    {
        public FrmAlbum()
        {
            InitializeComponent();
        }
        DataTable tblNuocSanXuat;

        private void FrmAlbum_Load(object sender, EventArgs e)
        {
            txtMaAlbum.Enabled = false;
            Functions.FillCombo("SELECT manghesi, tennghesi FROM NgheSi", cboNgheSi, "manghesi", "tennghesi");
            cboNgheSi.SelectedIndex = -1;
            btnLuu.Enabled = false;
            btnBoqua.Enabled = false;
            Load_DataGridView();
        }
        private void Load_DataGridView()
        {
            string sql;
            sql = "SELECT a.maalbum, a.tenalbum, a.mota, a.anh, a.manghesi FROM Album AS a JOIN NgheSi AS b ON a.manghesi=b.manghesi";
            tblNuocSanXuat = Class.Functions.GetDataToTable(sql);
            DataGridView.DataSource = tblNuocSanXuat;
            DataGridView.Columns[0].HeaderText = "Mã Album";
            DataGridView.Columns[1].HeaderText = "Tên Album";
            DataGridView.Columns[2].HeaderText = "Mô tả";
            DataGridView.Columns[3].HeaderText = "Ảnh";
            DataGridView.Columns[4].HeaderText = "Mã Nghệ sĩ";
            DataGridView.Columns[0].Width = 300;
            DataGridView.Columns[1].Width = 300;
            DataGridView.Columns[2].Width = 300;
            DataGridView.Columns[3].Width = 300;
            DataGridView.Columns[4].Width = 300;
            // Không cho phép thêm mới dữ liệu trực tiếp trên lưới
            DataGridView.AllowUserToAddRows = false;
            // Không cho phép sửa dữ liệu trực tiếp trên lưới
            DataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void DataGridView_Click(object sender, EventArgs e)
        {
            txtMaAlbum.Enabled = false;
            txtTenAlbum.Enabled = true;
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaAlbum.Focus();
                return;
            }
            if (tblNuocSanXuat.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtMaAlbum.Text = DataGridView.CurrentRow.Cells["maalbum"].Value.ToString();
            txtTenAlbum.Text = DataGridView.CurrentRow.Cells["tenalbum"].Value.ToString();
            txtMoTa.Text = DataGridView.CurrentRow.Cells["mota"].Value.ToString();
            txtAnh.Text = DataGridView.CurrentRow.Cells["anh"].Value.ToString();
            if (txtAnh.Text.Trim() == "")
            {
                picAnh.Image = Image.FromFile("D:/Github/Ajuma_proj/Ajuma/Images/no_image.png");
            }
            else
            {
                picAnh.Image = Image.FromFile(txtAnh.Text.ToString());
            }
            string manghesi = DataGridView.CurrentRow.Cells["manghesi"].Value.ToString();
            string sql = "SELECT tennghesi FROM NgheSi WHERE manghesi = N'"+manghesi+"'";
            cboNgheSi.Text = Functions.GetFieldValues(sql);
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
            txtMaAlbum.Focus();
        }
        private void ResetValues()
        {
            txtTenAlbum.Enabled = true;
            txtMaAlbum.Enabled = true;
            cboNgheSi.SelectedIndex = -1;
            txtMoTa.Text = "";
            txtAnh.Text = "";
            picAnh.Image = null;
            txtMaAlbum.Text = "";
            txtTenAlbum.Text = "";

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtMaAlbum.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã Album", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaAlbum.Focus();
                return;
            }
            if (txtTenAlbum.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên Album", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenAlbum.Focus();
                return;
            }
            if (cboNgheSi.SelectedIndex == -1)
            {
                MessageBox.Show("Bạn phải chọn Nghệ sĩ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenAlbum.Focus();
                return;
            }

            sql = "SELECT maalbum FROM Album WHERE maalbum=N'" + txtMaAlbum.Text.Trim() + "'";
            if (Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã Album này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaAlbum.Focus();
                txtMaAlbum.Text = "";
                return;
            }
            string sql_convert = "SELECT manghesi FROM NgheSi WHERE tennghesi = '"+cboNgheSi.Text+"'";
            sql = "INSERT INTO Album(maalbum, tenalbum, mota, anh, manghesi) VALUES(N'" + txtMaAlbum.Text + "',N'" + txtTenAlbum.Text + "',N'" + txtMoTa.Text + "',N'" + txtAnh.Text + "',N'" + Functions.GetFieldValues(sql_convert) + "')";
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
            if (txtMaAlbum.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE Album WHERE maalbum=N'" + txtMaAlbum.Text + "'";
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
            if (txtMaAlbum.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTenAlbum.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên album", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenAlbum.Focus();
                return;
            }
            string sql_convert = "SELECT manghesi FROM NgheSi WHERE tennghesi = '" + cboNgheSi.Text + "'";
            sql = "UPDATE Album SET tenalbum=N'" + txtTenAlbum.Text.ToString() + "', mota=N'"+txtMoTa.Text+"', anh=N'"+txtAnh.Text+"', manghesi=N'"+Functions.GetFieldValues(sql_convert)+"' WHERE maalbum=N'" + txtMaAlbum.Text + "'";
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

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
