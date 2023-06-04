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
    public partial class FrmDanhMucKhachHang : Form
    {
        public FrmDanhMucKhachHang()
        {
            InitializeComponent();
        }

        DataTable tblK;
        private void FrmDanhMucKhachHang_Load(object sender, EventArgs e)
        {
            /*this.BackColor = Color.Red;
            this.TransparencyKey = Color.Red;*/
            txtMaKhach.Enabled = false;
            btnluu.Enabled = false;
            btnboqua.Enabled = false;
            Functions.FillCombo("SELECT matinhthanh, tentinhthanh FROM TinhThanh", cboTinhThanh, "matinhthanh", "tentinhthanh");
            Functions.FillCombo("SELECT maquanhuyen, tenquanhuyen FROM QuanHuyen", cboQuanHuyen, "maquanhuyen", "tenquanhuyen");
            Functions.FillCombo("SELECT maxaphuong, tenxaphuong FROM XaPhuong", cboXaPhuong, "maxaphuong", "tenxaphuong");
            cboQuanHuyen.SelectedIndex = -1;
            cboXaPhuong.Text = "";
            cboTinhThanh.SelectedIndex = -1;
            cboTinhThanh.Enabled = false;
            cboXaPhuong.Enabled = false;
            cboQuanHuyen.Enabled = false;
            Load_DataGridView();
            ResetValues();
        }
        private void ResetValues()
        {
            txtMaKhach.Text = "";
            txtTenKhach.Text = "";
            mskSDT.Clear();
            txtDiaChiChiTiet.Text = "";
            cboXaPhuong.Text = "";
            cboQuanHuyen.Text = "";
            cboTinhThanh.Text = "";
            mskNgaySinh.Clear();
            txtFacebook.Text = "";

        }
        private void Load_DataGridView()
        {
            string sql;
            sql = "SELECT makhach, tenkhach, sdt, diachichitiet, maxaphuong, ngaysinh, linkfacebook FROM KhachHang";
            tblK = Functions.GetDataToTable(sql);
            dataGridView.DataSource = tblK;
            dataGridView.Columns[0].HeaderText = "Mã khách hàng";
            dataGridView.Columns[1].HeaderText = "Tên Khách";
            dataGridView.Columns[2].HeaderText = "Số điện thoại";
            dataGridView.Columns[3].HeaderText = "Địa chỉ chi tiết";
            dataGridView.Columns[4].HeaderText = "Mã xã phường";
            dataGridView.Columns[5].HeaderText = "Ngày sinh";
            dataGridView.Columns[6].HeaderText = "Link Facebook";

        }


        private void btnthem_Click(object sender, EventArgs e)
        {

            btnsua.Enabled = false;
            btnxoa.Enabled = false;
            btnboqua.Enabled = true;
            btnluu.Enabled = true;
            btnthem.Enabled = false;
            ResetValues();
            txtMaKhach.Enabled = true;
            txtMaKhach.Focus();
            cboTinhThanh.Enabled = true;
            cboQuanHuyen.Enabled = true;
            cboXaPhuong.Enabled = true;
        }

        private void dataGridView_Click(object sender, EventArgs e)
        {

            if (btnthem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaKhach.Focus();
                return;
            }
            if (tblK.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtMaKhach.Text = dataGridView.CurrentRow.Cells["makhach"].Value.ToString();
            txtTenKhach.Text = dataGridView.CurrentRow.Cells["tenkhach"].Value.ToString();
            mskSDT.Text = dataGridView.CurrentRow.Cells["sdt"].Value.ToString();
            txtDiaChiChiTiet.Text = dataGridView.CurrentRow.Cells["diachichitiet"].Value.ToString();

            cboTinhThanh.Enabled = true;
            cboQuanHuyen.Enabled = true;
            cboXaPhuong.Enabled = true;
            string maxaphuong = dataGridView.CurrentRow.Cells["maxaphuong"].Value.ToString();
            string sql_convert = "SELECT tenxaphuong FROM XaPhuong WHERE maxaphuong = N'" + maxaphuong + "'";
            cboXaPhuong.Text = Functions.GetFieldValues(sql_convert);

            sql_convert = "SELECT a.tenquanhuyen FROM QuanHuyen AS a JOIN XaPhuong AS b ON a.maquanhuyen = b.maquanhuyen WHERE b.maxaphuong = '" + maxaphuong + "'";
            cboQuanHuyen.Text = Functions.GetFieldValues(sql_convert);

            sql_convert = "SELECT a.maquanhuyen FROM QuanHuyen AS a JOIN XaPhuong AS b ON a.maquanhuyen = b.maquanhuyen WHERE b.maxaphuong = '" + maxaphuong + "'";
            string maquanhuyen = Functions.GetFieldValues(sql_convert);

            sql_convert = "SELECT a.tentinhthanh FROM TinhThanh AS a JOIN QuanHuyen AS b ON a.matinhthanh = b.matinhthanh WHERE b.maquanhuyen = '" + maquanhuyen + "'";
            cboTinhThanh.Text = Functions.GetFieldValues(sql_convert);

            mskNgaySinh.Text = dataGridView.CurrentRow.Cells["ngaysinh"].Value.ToString();
            txtFacebook.Text = dataGridView.CurrentRow.Cells["linkfacebook"].Value.ToString();

            btnsua.Enabled = true;
            btnxoa.Enabled = true;
            btnboqua.Enabled = true;
        }

        private void btnluu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtMaKhach.Text == "")
            {
                MessageBox.Show("Bạn phải nhập mã khách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaKhach.Focus();
                return;
            }
            if (txtDiaChiChiTiet.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiaChiChiTiet.Focus();
                return;
            }
            if (txtTenKhach.Text == "")
            {

                MessageBox.Show("Bạn phải nhập tên khách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenKhach.Focus();
                return;
            }
            if (!mskSDT.MaskFull)
            {
                MessageBox.Show("Bạn phải nhập số điện thoại ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mskSDT.Focus();
                return;
            }
            if (cboXaPhuong.Text == "")
            {
                MessageBox.Show("Bạn phải chọn địa chỉ Xã/Phường, Quận/Huyện và Tỉnh/Thành", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!mskNgaySinh.MaskFull)
            {
                MessageBox.Show("Bạn phải nhập ngày sinh!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mskNgaySinh.Focus();
                return;
            }
            if (!Functions.IsDate(mskNgaySinh.Text))
            {
                MessageBox.Show("Bạn nhập ngày sinh chưa đúng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mskNgaySinh.Focus();
                return;
            }
            sql = "SELECT makhach FROM KhachHang WHERE makhach=N'" + txtMaKhach.Text.Trim() + "'";
            if (Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã khách hàng này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaKhach.Focus();
                txtMaKhach.Text = "";
                return;
            }
            string sql_convert = "SELECT c.maxaphuong FROM TinhThanh a JOIN QuanHuyen b ON a.matinhthanh = b.matinhthanh JOIN XaPhuong c ON b.maquanhuyen = c.maquanhuyen WHERE a.tentinhthanh = N'" + cboTinhThanh.Text + "' AND b.tenquanhuyen=N'" + cboQuanHuyen.Text + "' AND c.tenxaphuong = N'" + cboXaPhuong.Text + "'";
            sql = "INSERT INTO KhachHang VALUES(N'" + txtMaKhach.Text.Trim() + "',N'" + txtTenKhach.Text.Trim() + "', '"+mskSDT.Text+"', N'" + txtDiaChiChiTiet.Text.Trim() + "', N'"+Functions.GetFieldValues(sql_convert)+"', N'"+Functions.ConvertDateTime(mskNgaySinh.Text)+"',N'" + txtFacebook.Text+ "')";
            Functions.RunSql(sql);
            Load_DataGridView();
            ResetValues();
            btnxoa.Enabled = true;
            btnthem.Enabled = true;
            btnsua.Enabled = true;
            btnboqua.Enabled = false;
            btnluu.Enabled = false;
            txtMaKhach.Enabled = false;
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblK.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaKhach.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtDiaChiChiTiet.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiaChiChiTiet.Focus();
                return;
            }
            if (txtTenKhach.Text == "")
            {

                MessageBox.Show("Bạn phải nhập tên khách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenKhach.Focus();
                return;
            }
            if (!mskSDT.MaskFull)
            {
                MessageBox.Show("Bạn phải nhập số điện thoại ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mskSDT.Focus();
                return;
            }
            if (cboXaPhuong.Text == "")
            {
                MessageBox.Show("Bạn phải chọn địa chỉ Xã/Phường, Quận/Huyện và Tỉnh/Thành", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string sql_convert = "SELECT c.maxaphuong FROM TinhThanh a JOIN QuanHuyen b ON a.matinhthanh = b.matinhthanh JOIN XaPhuong c ON b.maquanhuyen = c.maquanhuyen WHERE a.tentinhthanh = N'" + cboTinhThanh.Text + "' AND b.tenquanhuyen=N'" + cboQuanHuyen.Text + "' AND c.tenxaphuong = N'" + cboXaPhuong.Text + "'";
            sql = "update KhachHang set tenkhach=N'" + txtTenKhach.Text.Trim().ToString() + "', sdt = N'"+mskSDT.Text+"',diachichitiet = N'" + txtDiaChiChiTiet.Text.Trim().ToString() + "', maxaphuong = N'"+Functions.GetFieldValues(sql_convert)+"', ngaysinh = N'"+mskNgaySinh.Text+"', linkfacebook = N'"+txtFacebook.Text+"' where makhach = N'" + txtMaKhach.Text + "'";
            Functions.RunSql(sql);
            Load_DataGridView();
            ResetValues();
            btnboqua.Enabled = false;
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblK.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaKhach.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE KhachHang WHERE makhach = N'" + txtMaKhach.Text + "'";
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
            txtMaKhach.Enabled = false;
        }

        private void btndong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txttenkhach_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void cboTinhThanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = "SELECT b.maquanhuyen, b.tenquanhuyen FROM TinhThanh AS a JOIN QuanHuyen AS b ON a.matinhthanh = b.matinhthanh WHERE a.tentinhthanh = N'"+cboTinhThanh.Text+"'";
            Functions.FillCombo(sql, cboQuanHuyen, "maquanhuyen", "tenquanhuyen");
        }

        private void cboXaPhuong_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void cboQuanHuyen_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = 
                "SELECT c.maxaphuong, c.tenxaphuong " +
                "FROM TinhThanh AS a JOIN QuanHuyen AS b " +
                "ON a.matinhthanh = b.matinhthanh " +
                "JOIN XaPhuong AS c " +
                "ON b.maquanhuyen = c.maquanhuyen " +
                "WHERE a.tentinhthanh = N'" + cboTinhThanh.Text + "'" +
                "AND b.tenquanhuyen = N'" + cboQuanHuyen.Text + "'";
            Functions.FillCombo(sql, cboXaPhuong, "maxaphuong", "tenxaphuong");
        }
    }
}
