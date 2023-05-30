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
    public partial class FrmDanhMucNhanVien : Form
    {
        public FrmDanhMucNhanVien()
        {
            InitializeComponent();
        }

        private void FrmDanhMucNhanVien_Load(object sender, EventArgs e)
        {
            txtmanhanvien.Enabled = false;
            btnluu.Enabled = false;
            btnboqua.Enabled = false;
            Functions.FillCombo("SELECT MaQue FROM tblQue", cbomaque, "Maque", "Tenque");
            cbomaque.SelectedIndex = -1;
            Load_DataGridView();
            ResetValues();
        }
        private void ResetValues()
        {
            txtmanhanvien.Text = "";
            txttennhanvien.Text = "";
            cbomaque.Text = "";
            txtdiachi.Text = "";
            ckhgioitinh.Checked = false;
            mskngaysinh.Text = "";
            msksđt.Text = "";
        }
        DataTable tblNV;
        private void Load_DataGridView()
        {
            string sql;
            sql = "SELECT a.MaNhanVien, a.TenNhanVien, a.DiaChi, a.GioiTinh, a.NgaySinh, a.MaQue, a.SoDienThoai FROM tblNhanVien AS a JOIN tblQue AS b ON a.Maque = b.Maque";
            tblNV = Functions.GetDataToTable(sql);
            dataGridView.DataSource = tblNV;
            dataGridView.Columns[0].HeaderText = "Mã nhân viên";
            dataGridView.Columns[1].HeaderText = "Tên nhân viên";
            dataGridView.Columns[2].HeaderText = "Địa chỉ";
            dataGridView.Columns[3].HeaderText = "Giới tính";
            dataGridView.Columns[4].HeaderText = "Ngày sinh";
            dataGridView.Columns[5].HeaderText = "Mã quê";
            dataGridView.Columns[6].HeaderText = "Số điện thoại";
        }

        private void dataGridView_Click(object sender, EventArgs e)
        {
            if (btnthem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmanhanvien.Focus();
                return;
            }
            if (tblNV.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtmanhanvien.Text = dataGridView.CurrentRow.Cells["MaNhanvien"].Value.ToString();
            txttennhanvien.Text = dataGridView.CurrentRow.Cells["TenNhanVien"].Value.ToString();
            txtdiachi.Text = dataGridView.CurrentRow.Cells["DiaChi"].Value.ToString();
            string ma;
            ma = dataGridView.CurrentRow.Cells["MaQue"].Value.ToString();
            cbomaque.Text = Functions.GetFieldValues("SELECT MaQue FROM tblQue WHERE MaQue = N'" + ma + "'");

            //txttenque.Text = dataGridView.CurrentRow.Cells["tenque"].Value.ToString();

            if (dataGridView.CurrentRow.Cells["GioiTinh"].Value.ToString() == "Nam")
                ckhgioitinh.Checked = true;
            else
                ckhgioitinh.Checked = false;
            mskngaysinh.Text = dataGridView.CurrentRow.Cells["NgaySinh"].Value.ToString();
            msksđt.Text = dataGridView.CurrentRow.Cells["SoDienThoai"].Value.ToString();
            btnsua.Enabled = true;
            btnxoa.Enabled = true;
            btnboqua.Enabled = true;
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            btnsua.Enabled = false;
            btnxoa.Enabled = false;
            btnboqua.Enabled = true;
            btnluu.Enabled = true;
            btnthem.Enabled = false;
            ResetValues();
            txtmanhanvien.Enabled = true;
            txtmanhanvien.Focus();
        }

        private void btnluu_Click(object sender, EventArgs e)
        {
            string sql, gt;
            if (txtmanhanvien.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtmanhanvien.Focus();
                return;
            }
            if (txttennhanvien.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txttennhanvien.Focus();
                return;
            }
            if (txtdiachi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtdiachi.Focus();
                return;
            }
            if (ckhgioitinh.Checked == true)
                gt = "Nam";
            else
                gt = "Nữ";
            if (mskngaysinh.Text == "  /  /")
            {
                MessageBox.Show("Bạn phải nhập ngày sinh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mskngaysinh.Focus();
                return;
            }
            if (!Functions.IsDate(mskngaysinh.Text))
            {
                MessageBox.Show("Bạn phải nhập lại ngày sinh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mskngaysinh.Text = "";
                mskngaysinh.Focus();
                return;
            }
            if (cbomaque.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã quê", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbomaque.Focus();
                return;
            }

            if (msksđt.Text == "(   )   ")
            {
                MessageBox.Show("Bạn phải nhập số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                msksđt.Focus();
                return;
            }

            sql = "SELECT manhanvien FROM tblnhanvien WHERE manhanvien=N'" + txtmanhanvien.Text.Trim() + "'";
            if (Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã nhân viên này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtmanhanvien.Focus();
                txtmanhanvien.Text = "";
                return;
            }
            sql = "INSERT INTO tblnhanvien VALUES(N'" + txtmanhanvien.Text.Trim() + "', N'" + txttennhanvien.Text.Trim() + "', N'" + txtdiachi.Text.Trim() + "', N'" + gt + "', '" + Functions.ConvertDateTime(mskngaysinh.Text.Trim()) + "', N'" + cbomaque.Text + "', N'" + msksđt.Text + "')";
            Functions.RunSql(sql);
            Load_DataGridView();
            ResetValues();
            btnxoa.Enabled = true;
            btnthem.Enabled = true;
            btnsua.Enabled = true;
            btnboqua.Enabled = false;
            btnluu.Enabled = false;
            txtmanhanvien.Enabled = false;
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            string sql, gt;
            if (tblNV.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtmanhanvien.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txttennhanvien.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txttennhanvien.Focus();
                return;
            }
            if (txtdiachi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtdiachi.Focus();
                return;
            }
            if (ckhgioitinh.Checked == true)
                gt = "Nam";
            else
                gt = "Nữ";
            if (mskngaysinh.Text == "  /   /")
            {
                MessageBox.Show("Bạn phải nhập ngày sinh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mskngaysinh.Focus();
                return;
            }


            if (!Functions.IsDate(mskngaysinh.Text))
            {
                MessageBox.Show("Bạn phải nhập lại ngày sinh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mskngaysinh.Text = "";
                mskngaysinh.Focus();
                return;
            }
            if (cbomaque.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã quê", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbomaque.Focus();
                return;
            }
            if (msksđt.Text == "(   )   ")
            {
                MessageBox.Show("Bạn phải nhập số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                msksđt.Focus();
                return;
            }
            sql = "UPDATE tblNhanvien SET tennhanvien=N'" + txttennhanvien.Text.Trim().ToString() + "', diachi=N'" + txtdiachi.Text.Trim().ToString() + "', gioitinh=N'" + gt + "', ngaysinh=N'" + Functions.ConvertDateTime(mskngaysinh.Text) + "', maque = N'" + cbomaque.Text + "', sodienthoai =  N'" + msksđt.Text + "' WHERE manhanvien=N'" + txtmanhanvien.Text + "'";
            //MessageBox.Show(sql);
            Functions.RunSql(sql);
            Load_DataGridView();
            ResetValues();
            btnboqua.Enabled = false;
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblNV.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtmanhanvien.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE tblnhanvien WHERE manhanvien=N'" + txtmanhanvien.Text + "'";
                Functions.RunSqlDel(sql);
                Load_DataGridView();
                ResetValues();
            }
        }

        private void btnboqua_Click(object sender, EventArgs e)
        {
            ResetValues();
            btnboqua.Enabled = false;
            btnthem.Enabled = true;
            btnxoa.Enabled = true;
            btnsua.Enabled = true;
            btnluu.Enabled = false;
            txtmanhanvien.Enabled = false;
        }

        private void btndong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mskngaysinh_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
