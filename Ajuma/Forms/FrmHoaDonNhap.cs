using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Ajuma.Class;

namespace Ajuma.Forms
{
    public partial class FrmHoaDonNhap : Form
    {
        DataTable tblhdnhap;
        public FrmHoaDonNhap()
        {
            InitializeComponent();
        }

        private void FrmHoaDonNhap_Load(object sender, EventArgs e)
        {
            Functions.Connect();
            btnthemhd.Enabled = true;
            btnluuhd.Enabled = false;
            btnhuyhd.Enabled = true;
            //btnthem.Enabled = false;
            //btninhd.Enabled = false;
            txtmahdnhap.ReadOnly = true;
            txtmahdnhap1.ReadOnly = true;
            txtngaynhap.Text = "";
            txttennhanvien.ReadOnly = true;
            txttennhacungcap.ReadOnly = true;
            txttongtien.ReadOnly = true;
            txttensp.ReadOnly = true;
            txtsoluong.Text = "0";
            txtkhuyenmai.Text = "0";
            txtthanhtien.ReadOnly = true;
            grbthongtinphieu.Enabled = true;
            grbchitiethd.Enabled = true;
            Functions.FillCombo("SELECT MaNhanVien, TenNhanVien FROM tblNhanvien", cbomanhanvien, "MaNhanVien", "MaNhanVien");
            cbomanhanvien.SelectedIndex = -1;
            Functions.FillCombo("SELECT MaNhaCungCap, TenNhaCungCap FROM tblNhaCungCap", cbomanhacungcap, "MaNhaCungCap", "MaNhaCungCap");
            cbomanhacungcap.SelectedIndex = -1;
            Functions.FillCombo("SELECT MaSanPham, TenSanPham FROM tblSanPham", cbomasp, "MaSanPham", "MaSanPham");
            cbomasp.SelectedIndex = -1;
            Functions.FillCombo("SELECT MaHoaDonNhap FROM tblHoaDonNhap", cbomahdnhap, "MaHoaDonNhap", "MaHoaDonNhap");
            cbomahdnhap.SelectedIndex = -1;
            if (txtmahdnhap.Text != "")
            {
                Load_ThongtinHD();
                btnhuyhd.Enabled = true;
                //btninhd.Enabled = true;
            }
            Load_DataGridView();
        }

        private void ResetValues()
        {
            txtmahdnhap.Text = "";
            txtmahdnhap1.Text = "";
            txtngaynhap.Text = "";
            cbomanhanvien.Text = "";
            txttennhanvien.Text = "";
            cbomanhacungcap.Text = "";
            txttennhacungcap.Text = "";
            txttongtien.Text = "0";
            cbomasp.Text = "";
            txtsoluong.Text = "0";
            txtdongia.Text = "0";
            txtkhuyenmai.Text = "0";
            txtthanhtien.Text = "0";
        }

        private void Load_DataGridView()
        {
            string sql;//?
            sql = "SELECT tblChiTietHoaDonNhap.MaHoaDonNhap, tblChiTietHoaDonNhap.MaSanPham, tblSanPham.TenSanPham, tblChiTietHoaDonNhap.SoLuong," +
                " tblChiTietHoaDonNhap.DonGia, tblChiTietHoaDonNhap.KhuyenMai, tblChiTietHoaDonNhap.ThanhTien " +
               "FROM tblChiTietHoaDonNhap JOIN tblSanPham " +
               "ON tblChiTietHoaDonNhap.MaSanPham=tblSanPham.MaSanPham ";//where tblChiTietHoaDonNhap.MaHoaDonNhap = N'" + txtmahdnhap.Text + "'

            tblhdnhap = Functions.GetDataToTable(sql);
            DataGridView.DataSource = tblhdnhap;
            DataGridView.Columns[0].HeaderText = "Mã hóa đơn nhập";
            DataGridView.Columns[1].HeaderText = "Mã sản phẩm";
            DataGridView.Columns[2].HeaderText = "Tên sản phẩm";
            DataGridView.Columns[3].HeaderText = "Số lượng";
            DataGridView.Columns[4].HeaderText = "Đơn giá";
            DataGridView.Columns[5].HeaderText = "Khuyến mãi %";
            DataGridView.Columns[6].HeaderText = "Thành tiền";
            DataGridView.Columns[0].Width = 120;
            DataGridView.Columns[1].Width = 120;
            DataGridView.Columns[2].Width = 100;
            DataGridView.Columns[3].Width = 100;
            DataGridView.Columns[4].Width = 100;
            DataGridView.Columns[5].Width = 100;
            DataGridView.Columns[6].Width = 100;
            DataGridView.AllowUserToAddRows = false;
            DataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void Load_ThongtinHD()
        {
            string str;
            str = "SELECT MaNhanVien FROM tblHoaDonNhap WHERE MaHoaDonNhap = N'" + txtmahdnhap.Text + "'";
            cbomanhanvien.Text = Functions.GetFieldValues(str);
            str = "SELECT MaNhaCungCap FROM tblHoaDonNhap WHERE MaHoaDonNhap = N'" + txtmahdnhap.Text + "'";
            cbomanhacungcap.Text = Functions.GetFieldValues(str);
            str = "SELECT tongtien FROM tblHoaDonNhap WHERE MaHoaDonNhap= N'" + txtmahdnhap.Text + "'";
            txttongtien.Text = Functions.GetFieldValues(str);
            str = "SELECT NgayNhap FROM tblHoaDonNhap WHERE MaHoaDonNhap= N'" + txtmahdnhap.Text + "'";
            txtngaynhap.Text = Functions.GetFieldValues(str);
            lblbangchu.Text = "Bằng chữ: " + Functions.ChuyenSoSangChu(txttongtien.Text);
        }

        private void btnluuhd_Click(object sender, EventArgs e)
        {
            string sql;
            double sl, slmoi, giamoi, giaban;
            sql = "SELECT MaHoaDonNhap FROM tblChiTietHoaDonNhap WHERE MaHoaDonNhap=N'" + txtmahdnhap.Text + "'";
            if (!Functions.CheckKey(sql))
            {
                // Mã hóa đơn chưa có, tiến hành lưu các thông tin chung
                // Mã HDBan được sinh tự động do đó không có trường hợp trùng khóa
                if (txtngaynhap.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập ngày ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtngaynhap.Focus();
                    return;
                }
                if (cbomanhanvien.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cbomanhanvien.Focus();
                    return;
                }
                if (cbomanhacungcap.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cbomanhacungcap.Focus();
                    return;
                }

                sql = "INSERT INTO tblHoaDonNhap(MaHoaDonNhap, NgayNhap, MaNhanVien, MaNhaCungCap, Tongtien) " +
                    "VALUES (N'" + txtmahdnhap.Text.Trim() + "','" +
                        Functions.ConvertDateTime(txtngaynhap.Text.Trim()) + "',N'" + cbomanhanvien.SelectedValue + "',N'" +
                        cbomanhacungcap.SelectedValue + "'," + txttongtien.Text + ")";
                Functions.RunSql(sql);
            }

            // Lưu thông tin của các mặt hàng
            if (cbomasp.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbomasp.Focus();
                return;
            }
            if ((txtsoluong.Text.Trim().Length == 0) || (txtsoluong.Text == "0"))
            {
                MessageBox.Show("Bạn phải nhập số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtsoluong.Focus();
                return;
            }
            if ((txtdongia.Text.Trim().Length == 0) || (txtdongia.Text == "0"))
            {
                MessageBox.Show(" ban phai nhap don gia", "thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtdongia.Focus();
                return;
            }
            if (txtkhuyenmai.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập giảm giá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtkhuyenmai.Focus();
                return;
            }
            sql = "SELECT MaSanPham FROM tblChiTietHoaDonNhap WHERE MaSanPham=N'" + cbomasp.SelectedValue + "' AND mahoadonnhap = N'" + txtmahdnhap.Text.Trim() + "'";
            if (Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã hàng này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ResetValuesHang();
                cbomasp.Focus();
                return;
            }
            sql = "INSERT INTO tblChiTietHoaDonNhap(MaHoaDonNhap, MaSanPham, SoLuong, DonGia, KhuyenMai, ThanhTien) " +
                "VALUES(N'" + txtmahdnhap.Text.Trim() + "', N'" + cbomasp.SelectedValue + "'," + txtsoluong.Text + "," + txtdongia.Text + "," + txtkhuyenmai.Text + "," + txtthanhtien.Text + ")";
            Functions.RunSql(sql);
            Load_DataGridView();
            // cap nhat lai so luong cho san pham
            sl = Convert.ToDouble(Functions.GetFieldValues(" SELECT SoLuong FROM tblSanPham WHERE MaSanPham = N'" + cbomasp.Text + "'"));
            slmoi = sl + Convert.ToDouble(txtsoluong.Text);
            // MessageBox.Show(slmoi.ToString());
            sql = "UPDATE tblSanPham SET SoLuong =" + slmoi + " WHERE MaSanPham = N'" + cbomasp.Text + "'";
            Functions.RunSql(sql);
            //cap nhat lai gia cho san pham
            giamoi = Convert.ToDouble(txtdongia.Text);
            sql = " UPDATE tblSanPham SET GiaNhap =" + giamoi + " WHERE MaSanPham = N'" + cbomasp.Text + "'";
            Functions.RunSql(sql);
            // Giá Bán = 110% giá nhập
            giaban = Convert.ToDouble(txtdongia.Text) * 1.1;
            sql = " UPDATE tblSanPham SET GiaBan =" + giaban + " WHERE MaSanPham = N'" + cbomasp.Text + "'";
            Functions.RunSql(sql);
            // Cập nhật lại tổng tiền cho hóa đơn nhap
            double tong, tongmoi;
            tong = Convert.ToDouble(Functions.GetFieldValues("SELECT TongTien FROM tblHoaDonNhap WHERE MaHoadonNhap = N'" + txtmahdnhap.Text + "'"));
            tongmoi = tong + Convert.ToDouble(txtthanhtien.Text);//?
            sql = "UPDATE tblHoaDonNhap SET TongTien =" + tongmoi + " WHERE MaHoaDonNhap = N'" + txtmahdnhap.Text + "'";
            Functions.RunSql(sql);
            txttongtien.Text = tongmoi.ToString();
            lblbangchu.Text = "Bằng chữ: " + Functions.ChuyenSoSangChu(txttongtien.Text);
            ResetValuesHang();
            btnhuyhd.Enabled = true;
            btnthemhd.Enabled = true;
            txttensp.Text = "";
        }
        private void ResetValuesHang()
        {
            cbomasp.Text = "";
            txttensp.Text = "";
            txtsoluong.Text = "0";
            txtdongia.Text = "0";
            txtkhuyenmai.Text = "0";
            txtthanhtien.Text = "0";

        }

        private void DataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string masp;
            Double thanhtien;
            if (tblhdnhap.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if ((MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                // cập nhật lại số lượng cho sp;
                masp = DataGridView.CurrentRow.Cells["MaSanPham"].Value.ToString();
                DelHang(txtmahdnhap.Text, masp);
                // Cập nhật lại tổng tiền cho hóa đơn bán;
                thanhtien = Convert.ToDouble(DataGridView.CurrentRow.Cells["ThanhTien"].Value.ToString());
                DelUpdategiamtongtien(txtmahdnhap.Text, thanhtien);
                ResetValuesHang();
                Load_DataGridView();
            }
        }
        private void DelHang(string Mahoadon, string masp)
        {
            Double s, sl, SLcon;
            string sql;
            sql = "SELECT soluong FROM tblchitiethoadonnhap WHERE mahoadonnhap = N'" + Mahoadon + "' AND masanpham = N'" + masp + "'";
            s = Convert.ToDouble(Functions.GetFieldValues(sql));
            sql = "DELETE tblchitiethoadonnhap WHERE mahoadonnhap=N'" + Mahoadon + "' AND masanpham = N'" + masp + "'";
            Functions.RunSqlDel(sql);
            // Cập nhật lại số lượng cho các mặt hàng
            sql = "SELECT soluong FROM tblsanpham WHERE masanpham = N'" + masp + "'";
            sl = Convert.ToDouble(Functions.GetFieldValues(sql));
            SLcon = sl - s;
            sql = "UPDATE tblsanpham SET soluong =" + SLcon + " WHERE masanpham= N'" + masp + "'";
            Functions.RunSql(sql);

        }
        private void DelUpdategiamtongtien(string Mahoadon, double Thanhtien)
        {
            Double Tong, Tongmoi;
            string sql;
            sql = "SELECT tongtien FROM tblhoadonnhap WHERE mahoadonnhap = N'" + Mahoadon + "'";
            Tong = Convert.ToDouble(Functions.GetFieldValues(sql));
            Tongmoi = Tong - Thanhtien;
            sql = "UPDATE tblhoadonnhap SET tongtien =" + Tongmoi + " WHERE mahoadonnhap = N'" + Mahoadon + "'";
            Functions.RunSql(sql);
            txttongtien.Text = Tongmoi.ToString();
            lblbangchu.Text = "Bằng chữ: " + Functions.ChuyenSoSangChu(txttongtien.Text);
        }

        private void btnthemhd_Click(object sender, EventArgs e)
        {
            txttongtien.Enabled = false;
            btnluuhd.Enabled = true;
            btnhuyhd.Enabled = false;
            //btnthem.Enabled = true;
            //btninhd.Enabled = false;
            grbthongtinphieu.Enabled = true;
            grbchitiethd.Enabled = true;
            DataGridView.DataSource = null;
            ResetValues();
            txtmahdnhap.Text = Functions.CreateKey("HDN");
            txtmahdnhap1.Text = txtmahdnhap.Text;
            Load_DataGridView();
        }

        private void btnhuyhd_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string[] masp = new string[20];
                string sql;
                int n = 0;
                sql = "SELECT MaSanPham FROM tblChiTietHoaDonNhap WHERE MaHoaDonNhap = N'" + txtmahdnhap.Text + "'";
                SqlCommand cmd = new SqlCommand(sql, Functions.Conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    masp[n] = reader.GetString(0).ToString();
                    n = n + 1;
                }
                reader.Close();

                //Xóa danh sách các mặt hàng của hóa đơn
                for (int i = 0; i <= n - 1; i++)
                    DelHang(txtmahdnhap.Text, masp[i]);
                //Xóa hóa đơn
                sql = "DELETE tblHoaDonNhap WHERE MaHoaDonNhap=N'" + txtmahdnhap.Text + "'";
                Functions.RunSqlDel(sql);
                Load_DataGridView();
                ResetValues();
                Load_DataGridView();
                btnhuyhd.Enabled = false;
                //btninhd.Enabled = false;

            }
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            if (tblhdnhap.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtmahdnhap.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bảng ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cbomanhanvien.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn mã nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            cbomasp.Enabled = false;
            string sql;
            sql = "UPDATE tblHoaDonNhap SET NgayNhap = N'" + Functions.ConvertDateTime(txtngaynhap.Text) + "', manhanvien = N'" + cbomanhanvien.SelectedValue.ToString() + "' WHERE mahoadonnhap = N'" + txtmahdnhap.Text + "'";
            Functions.RunSql(sql);
            double giamoi, giaban, soluong, khuyenmai, thanhtien, sl, slmoi;
            //cap nhat lai gia nhap cho san pham
            giamoi = Convert.ToDouble(txtdongia.Text);
            sql = " UPDATE tblSanPham SET GiaNhap =" + giamoi + " WHERE MaSanPham = N'" + cbomasp.Text + "'";
            Functions.RunSql(sql);
            sql = " UPDATE tblChiTietHoaDonNhap  SET DonGia =" + giamoi + " WHERE MaSanPham =N'" + cbomasp.SelectedValue + "' AND mahoadonnhap = N'" + txtmahdnhap.Text.Trim() + "'";
            Functions.RunSql(sql);
            //cap nhat lai gia ban cho san pham
            giaban = giamoi * 1.1;
            sql = " UPDATE tblSanPham SET GiaBan =" + giaban + " WHERE MaSanPham = N'" + cbomasp.Text + "'";
            Functions.RunSql(sql);
            // cap nhat lai so luong cho chi tiet,sanpham
            double soluongcu;
            sql = "SELECT SoLuong FROM tblChiTietHoaDonNhap  WHERE MaSanPham=N'" + cbomasp.SelectedValue + "' AND mahoadonnhap = N'" + txtmahdnhap.Text.Trim() + "'";
            soluongcu = Convert.ToDouble(Functions.GetFieldValues(sql));
            Functions.RunSql(sql);
            soluong = Convert.ToDouble(txtsoluong.Text);
            sql = " UPDATE tblChiTietHoaDonNhap  SET SoLuong =" + soluong + " WHERE MaSanPham=N'" + cbomasp.SelectedValue + "' AND mahoadonnhap = N'" + txtmahdnhap.Text.Trim() + "'";
            Functions.RunSql(sql);
            sl = Convert.ToDouble(Functions.GetFieldValues(" SELECT SoLuong FROM tblSanPham WHERE MaSanPham = N'" + cbomasp.Text + "'"));
            slmoi = sl + Convert.ToDouble(txtsoluong.Text) - soluongcu;
            sql = "UPDATE tblSanPham SET SoLuong =" + slmoi + " WHERE MaSanPham = N'" + cbomasp.Text + "'";
            Functions.RunSql(sql);
            //cap nhat lai khuyen mai chi chi tiet , san pham
            khuyenmai = Convert.ToDouble(txtkhuyenmai.Text);
            sql = " UPDATE tblChiTietHoaDonNhap SET KhuyenMai =" + khuyenmai + " WHERE MaSanPham=N'" + cbomasp.SelectedValue + "' AND mahoadonnhap = N'" + txtmahdnhap.Text.Trim() + "'";
            Functions.RunSql(sql);
            //cap nhat lai thanh tien
            thanhtien = Convert.ToDouble(txtthanhtien.Text);
            sql = " UPDATE tblChiTietHoaDonNhap SET ThanhTien =" + thanhtien + " WHERE MaSanPham=N'" + cbomasp.SelectedValue + "' AND mahoadonnhap = N'" + txtmahdnhap.Text.Trim() + "'";
            Functions.RunSql(sql);
            // Cập nhật lại tổng tiền cho hóa đơn nhap
            sql = "SELECT SUM(ThanhTien) FROM tblChiTietHoaDonNhap WHERE MaHoaDonNhap = N'" + txtmahdnhap.Text + "'";
            Functions.GetFieldValues(sql);
            double tongmoi;
            tongmoi = Convert.ToDouble(Functions.GetFieldValues(sql));
            sql = "UPDATE tblHoaDonNhap SET Tongtien =" + tongmoi + " WHERE MaHoaDonNhap = N'" + txtmahdnhap.Text + "'";
            Functions.RunSql(sql);
            txttongtien.Text = tongmoi.ToString();
            Load_DataGridView();
            lblbangchu.Text = "Bằng chữ: " + Functions.ChuyenSoSangChu(txttongtien.Text);
            ResetValuesHang();
            btnhuyhd.Enabled = true;
            btnthemhd.Enabled = true;
        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            if (cbomahdnhap.Text == "")
            {
                MessageBox.Show("Bạn phải chọn một mã hóa đơn để tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbomahdnhap.Focus();
                return;
            }
            txtmahdnhap.Text = cbomahdnhap.Text;
            Load_ThongtinHD();
            Load_DataGridView();
            btnsua.Enabled = true;
            btnluuhd.Enabled = true;
            btnhuyhd.Enabled = true;
            cbomahdnhap.SelectedIndex = -1;
        }

        private void btndong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DataGridView_Click(object sender, EventArgs e)
        {
            string masp;
            if (btnthemhd.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmahdnhap.Focus();
                return;
            }
            if (tblhdnhap.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtmahdnhap1.Text = DataGridView.CurrentRow.Cells["MaHoaDonNhap"].Value.ToString();
            masp = DataGridView.CurrentRow.Cells["MaSanPham"].Value.ToString();
            cbomasp.Text = Functions.GetFieldValues("SELECT MaSanPham FROM tblSanPham WHERE MaSanPham = N'" + masp + "'");
            txtsoluong.Text = DataGridView.CurrentRow.Cells["SoLuong"].Value.ToString();
            txtdongia.Text = DataGridView.CurrentRow.Cells["DonGia"].Value.ToString();
            txtkhuyenmai.Text = DataGridView.CurrentRow.Cells["KhuyenMai"].Value.ToString();
            txtthanhtien.Text = DataGridView.CurrentRow.Cells["ThanhTien"].Value.ToString();
            btnhuyhd.Enabled = true;
            btndong.Enabled = true;
        }

        private void txtsoluong_TextChanged(object sender, EventArgs e)
        {
            //Khi thay doi So luong, Giam gia thi Thanh tien tu dong cap nhat lai gia tri
            double tt, sl, dg, gg;
            if (txtsoluong.Text == "")
                sl = 0;
            else
                sl = Convert.ToDouble(txtsoluong.Text);
            if (txtkhuyenmai.Text == "")
                gg = 0;
            else
                gg = Convert.ToDouble(txtkhuyenmai.Text);
            if (txtdongia.Text == "")
                dg = 0;
            else
                dg = Convert.ToDouble(txtdongia.Text);
            tt = sl * dg - sl * dg * gg / 100;
            txtthanhtien.Text = tt.ToString();
        }

        private void txtdongia_TextChanged(object sender, EventArgs e)
        {
            //Khi thay doi So luong, Giam gia thi Thanh tien tu dong cap nhat lai gia tri
            double tt, sl, dg, gg;
            if (txtsoluong.Text == "")
                sl = 0;
            else
                sl = Convert.ToDouble(txtsoluong.Text);
            if (txtkhuyenmai.Text == "")
                gg = 0;
            else
                gg = Convert.ToDouble(txtkhuyenmai.Text);
            if (txtdongia.Text == "")
                dg = 0;
            else
                dg = Convert.ToDouble(txtdongia.Text);
            tt = sl * dg - sl * dg * gg / 100;
            txtthanhtien.Text = tt.ToString();
        }

        private void txtkhuyenmai_TextChanged(object sender, EventArgs e)
        {
            //Khi thay doi So luong, Giam gia thi Thanh tien tu dong cap nhat lai gia tri
            double tt, sl, dg, gg;
            if (txtsoluong.Text == "")
                sl = 0;
            else
                sl = Convert.ToDouble(txtsoluong.Text);
            if (txtkhuyenmai.Text == "")
                gg = 0;
            else
                gg = Convert.ToDouble(txtkhuyenmai.Text);
            if (txtdongia.Text == "")
                dg = 0;
            else
                dg = Convert.ToDouble(txtdongia.Text);
            tt = sl * dg - sl * dg * gg / 100;
            txtthanhtien.Text = tt.ToString();
        }

        private void cbomanhanvien_TextChanged(object sender, EventArgs e)
        {
            string str;
            if (cbomanhanvien.Text == "")
                txttennhanvien.Text = "";
            // Khi kich chon Ma nhan vien thi ten nhan vien se tu dong hien ra
            str = "Select tennhanvien from tblnhanvien where manhanvien =N'" + cbomanhanvien.SelectedValue + "'";
            txttennhanvien.Text = Functions.GetFieldValues(str);
        }

        private void cbomanhacungcap_TextChanged(object sender, EventArgs e)
        {
            string str;
            if (cbomanhacungcap.Text == "")
                txttennhacungcap.Text = "";
            // Khi kich chon Ma nhan vien thi ten nhan vien se tu dong hien ra
            str = "Select tennhacungcap from tblnhacungcap where manhacungcap =N'" + cbomanhacungcap.SelectedValue + "'";
            txttennhacungcap.Text = Functions.GetFieldValues(str);
        }

        private void cbomasp_TextChanged(object sender, EventArgs e)
        {
            string str;
            if (cbomasp.Text == "")
                txttensp.Text = "";
            // Khi kich chon Ma nhan vien thi ten nhan vien se tu dong hien ra
            str = "Select tensanpham from tblsanpham where masanpham =N'" + cbomasp.SelectedValue + "'";
            txttensp.Text = Functions.GetFieldValues(str);
        }

        private void txtsoluong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void txtdongia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void txtkhuyenmai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void cbomahdnhap_DropDown(object sender, EventArgs e)
        {
            Functions.FillCombo("SELECT MaHoaDonNhap FROM tblHoaDonNhap", cbomahdnhap, "MaHoaDonNhap", "MaHoaDonNhap");
            cbomahdnhap.SelectedIndex = -1;
        }
    }
}
