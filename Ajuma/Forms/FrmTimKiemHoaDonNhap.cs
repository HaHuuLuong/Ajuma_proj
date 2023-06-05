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
    public partial class FrmTimKiemHoaDonNhap : Form
    {
        public FrmTimKiemHoaDonNhap()
        {
            InitializeComponent();
        }
        DataTable tblTimkiemHDN;

        private void FrmTimKiemHoaDonNhap_Load(object sender, EventArgs e)
        {
            /*this.BackColor = Color.Red;
            this.TransparencyKey = Color.Red;*/
            Functions.FillCombo("SELECT masanpham, tensanpham FROM SanPham", cbomasanpham, "masanpham", "masanpham");
            cbomasanpham.SelectedIndex = -1;
            Functions.FillCombo("SELECT manhacungcap, tennhacungcap FROM NhaCungCap", cbomanhacungcap, "manhacungcap", "manhacungcap");
            cbomanhacungcap.SelectedIndex = -1;
            btntimlai.Enabled = false;
            txtsoluong.ReadOnly = true;
            txtdongia.ReadOnly = true;
            txtkhuyenmai.ReadOnly = true;
            ResetValues();
            DataGridView.DataSource = null;
        }
        private void ResetValues()
        {
            foreach (Control Ctl in this.Controls)
            {
                if (Ctl is TextBox)
                    Ctl.Text = "";

            }
            txtngaynhap.Text = "";
            cbomasanpham.Text = "";
            cbomanhacungcap.Text = "";
            cbomasanpham.Focus();
        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            string sql;
            if ((cbomasanpham.Text == "") && (txtngaynhap.Text == "") && (cbomanhacungcap.Text == ""))
            {
                MessageBox.Show("Hãy nhập một điều kiện tìm kiếm!!!", "Yeu cau ...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = "SELECT a.madonnhaphang, a.masanpham, b.manhacungcap," +
                " b.ngaydat, a.soluongdat, a.dongia ,a.soluongnhan, a.thanhtien, a.trangthai " +
                "FROM ChiTietDonNhapHang AS a JOIN DonNhapHang AS b ON a.madonnhaphang = b.madonnhaphang " +
                "WHERE 1=1";

            
            if (cbomasanpham.Text != "")
                sql = sql + "AND masanpham Like N'%" + cbomasanpham.Text + "%'";
            if (cbomanhacungcap.Text != "")
                sql = sql + "AND manhacungcap Like N'%" + cbomanhacungcap.Text + "%'";
            if (txtngaynhap.Text != "")
            {
                sql = sql + "AND ngaydat = N'" + Functions.ConvertDateTime(txtngaynhap.Text) + "'";
            }

            tblTimkiemHDN = Functions.GetDataToTable(sql);
            if (tblTimkiemHDN.Rows.Count == 0)
            {
                MessageBox.Show("Không có bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ResetValues();
            }
            else
                MessageBox.Show("Có " + tblTimkiemHDN.Rows.Count + " bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            DataGridView.DataSource = tblTimkiemHDN;
            Load_DataGridView();
            txttongtien.Text = tongtien().ToString();
            groupBox1.Enabled = false;
            btntimlai.Enabled = true;
        }

        public double tongtien()
        {
            double T = 0;
            for (int i = 0; i <= DataGridView.Rows.Count - 1; i++)
            {
                T = T + Convert.ToDouble(DataGridView.Rows[i].Cells["thanhtien"].Value.ToString());
            }
            return T;
        }

        private void Load_DataGridView()
        {
            DataGridView.Columns[0].HeaderText = "Mã hóa đơn nhập";
            DataGridView.Columns[1].HeaderText = "Mã sản phẩm";
            DataGridView.Columns[2].HeaderText = "Mã nhà cung cấp";
            DataGridView.Columns[3].HeaderText = "Ngày nhập";
            DataGridView.Columns[4].HeaderText = "Số lượng";
            DataGridView.Columns[5].HeaderText = "Đơn giá";
            DataGridView.Columns[6].HeaderText = "Số lượnng nhận";
            DataGridView.Columns[7].HeaderText = "Thành tiền";
            DataGridView.Columns[8].HeaderText = "Trạng thái";
            DataGridView.Columns[0].Width = 100;
            DataGridView.Columns[1].Width = 100;
            DataGridView.Columns[2].Width = 80;
            DataGridView.Columns[3].Width = 80;
            DataGridView.Columns[4].Width = 80;
            DataGridView.Columns[5].Width = 80;
            DataGridView.Columns[6].Width = 80;
            DataGridView.Columns[7].Width = 80;
            DataGridView.Columns[8].Width = 80;
            DataGridView.AllowUserToAddRows = false;
            DataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void DataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            /*string mahd;
            if (MessageBox.Show("Bạn có muốn hiển thị thông tin chi tiết?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                mahd = DataGridView.CurrentRow.Cells["madonnhaphang"].Value.ToString();
                //Forms.FrmHoaDonNhap frm = new frmhdnhap();
                frm.txtmahdnhap.Text = mahd;
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowDialog();
            }*/ // Chưa có form hóa đơn nhập
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void DataGridView_Click(object sender, EventArgs e)
        {
            if (tblTimkiemHDN.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtdongia.Text = DataGridView.CurrentRow.Cells["dongia"].Value.ToString();
            txtTrangthai.Text = DataGridView.CurrentRow.Cells["trangthai"].Value.ToString();
            txtkhuyenmai.Text = DataGridView.CurrentRow.Cells["soluongnhan"].Value.ToString();
            txtsoluong.Text = DataGridView.CurrentRow.Cells["soluongdat"].Value.ToString();
            txttongtien.Text = tongtien().ToString();
            txtngaynhap.Text = DataGridView.CurrentRow.Cells["ngaydat"].Value.ToString();
            cbomasanpham.Text = DataGridView.CurrentRow.Cells["masanpham"].Value.ToString();
            cbomanhacungcap.Text = DataGridView.CurrentRow.Cells["manhacungcap"].Value.ToString();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btntimlai_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            ResetValues();
            DataGridView.DataSource = null;
        }
    }
}
