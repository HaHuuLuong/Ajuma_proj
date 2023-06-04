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
    public partial class FrmNgheSi : Form
    {
        public FrmNgheSi()
        {
            InitializeComponent();
        }
        DataTable tbldd;
        private void FrmNgheSi_Load(object sender, EventArgs e)
        {
            btnLuu.Enabled = false;
            btnBoqua.Enabled = false;
            Load_DataGridView();
        }
        private void Load_DataGridView()
        {
            string sql;
            sql = "SELECT manghesi, tennghesi, gioithieu, anh FROM NgheSi";
            tbldd = Class.Functions.GetDataToTable(sql);
            DataGridView.DataSource = tbldd;
            DataGridView.Columns[0].HeaderText = "Mã nghệ sĩ";
            DataGridView.Columns[1].HeaderText = "Tên nghệ sĩ";
            DataGridView.Columns[2].HeaderText = "Giới thiệu";
            DataGridView.Columns[3].HeaderText = "Ảnh minh họa";
            DataGridView.Columns[0].Width = 200;
            DataGridView.Columns[1].Width = 200;
            DataGridView.Columns[2].Width = 200;
            DataGridView.Columns[3].Width = 200;
            // Không cho phép thêm mới dữ liệu trực tiếp trên lưới
            DataGridView.AllowUserToAddRows = false;
            // Không cho phép sửa dữ liệu trực tiếp trên lưới
            DataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void DataGridView_Click(object sender, EventArgs e)
        {
            txtMaNgheSi.Enabled = false;
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaNgheSi.Focus();
                return;
            }
            if (tbldd.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtMaNgheSi.Text = DataGridView.CurrentRow.Cells["manghesi"].Value.ToString();
            txtNgheSi.Text = DataGridView.CurrentRow.Cells["tennghesi"].Value.ToString();
            txtGioiThieu.Text = DataGridView.CurrentRow.Cells["gioithieu"].Value.ToString();
            txtAnh.Text = DataGridView.CurrentRow.Cells["anh"].Value.ToString();
            if (txtAnh.Text.Trim() == "")
            {
                picAnh.Image = Ajuma.Properties.Resources.no_image;
   
            }
            else
            {
                picAnh.Image = Image.FromFile(txtAnh.Text.ToString());
            }    
            
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
            txtMaNgheSi.Focus();
        }

        private void ResetValues()
        {

            txtNgheSi.Enabled = true;
            txtMaNgheSi.Enabled = true;
            txtGioiThieu.Enabled = true;
            txtAnh.Enabled = true;
            txtMaNgheSi.Text = "";
            txtNgheSi.Text = "";
            txtGioiThieu.Text = "";
            txtAnh.Text = "";
            picAnh.Image = null;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;


            if (txtMaNgheSi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã nghệ sĩ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaNgheSi.Focus();
                return;
            }
            if (txtNgheSi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên nghệ sĩ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNgheSi.Focus();
                return;
            }

            sql = "SELECT manghesi FROM NgheSi WHERE manghesi=N'" + txtMaNgheSi.Text.Trim() + "'";
            if (Class.Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã nghệ sĩ này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaNgheSi.Focus();
                txtMaNgheSi.Text = "";
                return;
            }



            sql = "INSERT INTO NgheSi(manghesi, tennghesi, gioithieu, anh) VALUES(N'" + txtMaNgheSi.Text + "',N'" + txtNgheSi.Text + "',N'" + txtGioiThieu.Text + "',N'" + txtAnh.Text + "')";
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
            if (txtMaNgheSi.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (txtNgheSi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên mau", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNgheSi.Focus();
                return;
            }

            sql = "UPDATE NgheSi SET tennghesi=N'" + txtNgheSi.Text.ToString() + "', gioithieu=N'"+txtGioiThieu.Text.ToString()+"', anh=N'"+txtAnh.Text.ToString()+"' WHERE manghesi=N'" + txtMaNgheSi.Text + "'";
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
            if (txtMaNgheSi.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {

                sql = "DELETE NgheSi WHERE manghesi=N'" + txtMaNgheSi.Text + "'";
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
