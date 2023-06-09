﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using Ajuma.Class;
using COMExcel = Microsoft.Office.Interop.Excel;
namespace Ajuma.Forms
{
    public partial class FrmHoaDonBan : Form
    {
        public FrmHoaDonBan()
        {
            InitializeComponent();
        }
        DataTable tblHDB;



        private void ResetValues()
        {
            txtmadondathang.Text = "";
            txtngaydathang.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtsoluong.Text = "";
            txtkhuyenmai.Text = "0";
            txtthanhtien.Text = "0";
            txttennhanvien.Text = "";
            txttensanpham.Text = "";
            txtgiaban.Text = "";
            cbomanhanvien.Text = "";
            cbomakhach.Text = "";
            txttongtien.Text = "0";
            lblbangchu.Text = "Bằng chữ: ";
            cbomasanpham.Text = "";
            txtdiachikhachhang.Text = "";
        }


        private void ResetValuesHang()
        {
            cbomasanpham.Text = "";
            txtsoluong.Text = "";
            txtkhuyenmai.Text = "0";
            txtthanhtien.Text = "0";
        }


        private void DelHang(string Mahoadon, string Mahang)
        {
            Double s, sl, SLcon;
            string sql;
            sql = "SELECT soluong FROM ChiTietDonDatHang WHERE madondathang = N'" + Mahoadon + "' AND masanpham = N'" + Mahang + "'";
            s = Convert.ToDouble(Functions.GetFieldValues(sql));
            sql = "DELETE ChiTietDonDatHang WHERE madondathang =N'" + Mahoadon + "' AND masanpham = N'" + Mahang + "'";
            Functions.RunSqlDel(sql);
            // Cập nhật lại số lượng cho các mặt hàng
            sql = "SELECT soluongkho FROM SanPham WHERE masanpham = N'" + Mahang + "'";
            sl = Convert.ToDouble(Functions.GetFieldValues(sql));
            SLcon = sl + s;
            sql = "UPDATE SanPham SET soluongkho =" + SLcon + " WHERE masanpham= N'" + Mahang + "'";
            Functions.RunSql(sql);
        }
        private void DelUpdateTongtien(string Mahoadon, double Thanhtien)
        {
            Double Tong, Tongmoi;
            string sql;
            sql = "SELECT tongtien FROM DonDatHang WHERE madondathang = N'" + Mahoadon + "'";
            Tong = Convert.ToDouble(Functions.GetFieldValues(sql));
            Tongmoi = Tong - Thanhtien;
            sql = "UPDATE DonDatHang SET tongtien =" + Tongmoi + " WHERE madondathang = N'" + Mahoadon + "'";
            Functions.RunSql(sql);
            txttongtien.Text = Tongmoi.ToString();
            lblbangchu.Text = "Bằng chữ: " + Functions.ChuyenSoSangChu(Tongmoi.ToString());
        }


        private void groupSp_Enter(object sender, EventArgs e)
        {

        }

        private void FrmHoaDonBan_Load(object sender, EventArgs e)
        {
            btnthemmoi.Enabled = true;
            btnluu.Enabled = false;
            btnhuy.Enabled = false;
            txtmadondathang.ReadOnly = true;
            txttennhanvien.ReadOnly = true;
            txtdiachikhachhang.ReadOnly = true;
            txttensanpham.ReadOnly = true;
            txtgiaban.ReadOnly = true;
            txtthanhtien.ReadOnly = true;
            txttongtien.ReadOnly = true;
            txtkhuyenmai.Text = "0";
            txttongtien.Text = "0";
            Functions.FillCombo("SELECT makhach FROM KhachHang", cbomakhach, "makhach", "makhach");
            cbomakhach.SelectedIndex = -1;
            Functions.FillCombo("SELECT manhanvien FROM NhanVien", cbomanhanvien, "manhanvien", "manhanvien");
            cbomanhanvien.SelectedIndex = -1;
            Functions.FillCombo("SELECT masanpham FROM SanPham", cbomasanpham, "masanpham", "masanpham");
            cbomasanpham.SelectedIndex = -1;
            Functions.FillCombo("SELECT madondathang FROM DonDatHang", cbomadondathang, "madondathang", "madondathang");
            cbomadondathang.SelectedIndex = -1;
            if (txtmadondathang.Text != "")
            {
                ThongtinHD();
                btnhuy.Enabled = true;
            }
            Load_DataGridViewChitiet();
            // Chạy animation Slogan
            text = lblText.Text;
            lblText.Text = "";
            timer1.Start();
        }
        private string text;
        private int len = 0;
        private void Load_DataGridViewChitiet()
        {
            string sql;
            sql = "SELECT a.masanpham, b.tensanpham, a.soluong, b.dongiaban, a.giamgia, a.thanhtien FROM ChiTietDonDatHang AS a JOIN SanPham AS b ON a.masanpham=b.masanpham WHERE a.madondathang = N'" + txtmadondathang.Text + "'";
            tblHDB = Functions.GetDataToTable(sql);
            DataGridView.DataSource = tblHDB;
            DataGridView.Columns[0].HeaderText = "Mã sản phẩm";
            DataGridView.Columns[1].HeaderText = "Tên sản phẩm";
            DataGridView.Columns[2].HeaderText = "Số lượng";
            DataGridView.Columns[3].HeaderText = "Giá bán";
            DataGridView.Columns[4].HeaderText = "Khuyến mại";
            DataGridView.Columns[5].HeaderText = "Thành tiền";
            DataGridView.Columns[0].Width = 200;
            DataGridView.Columns[1].Width = 200;
            DataGridView.Columns[2].Width = 200;
            DataGridView.Columns[3].Width = 200;
            DataGridView.Columns[4].Width = 200;
            DataGridView.Columns[5].Width = 200;
            DataGridView.AllowUserToAddRows = false;
            DataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void ThongtinHD()
        {
            string str;
            str = "SELECT ngaydathang FROM DonDatHang WHERE madondathang = N'" + txtmadondathang.Text + "'";
            txtngaydathang.Text = Functions.GetFieldValues(str);
            str = "SELECT manhanvien FROM DonDatHang WHERE madondathang = N'" + txtmadondathang.Text + "'";
            cbomanhanvien.Text = Functions.GetFieldValues(str);

            str = "SELECT makhach FROM DonDatHang WHERE madondathang = N'" + txtmadondathang.Text + "'";
            cbomakhach.Text = Functions.GetFieldValues(str);

            str = "SELECT tongtien FROM DonDatHang WHERE madondathang = N'" + txtmadondathang.Text + "'";
            txttongtien.Text = Functions.GetFieldValues(str);


            lblbangchu.Text = "Bằng chữ: " + Functions.ChuyenSoSangChu(txttongtien.Text);
        }

        private void btnthemmoi_Click(object sender, EventArgs e)
        {
            //groupThongtinchung.Enabled = true;
            btnboqua.Enabled = true;
            btnhuy.Enabled = false;
            btnluu.Enabled = true;
            btnthemmoi.Enabled = false;
            cbomasanpham.Enabled = true;
            cbomakhach.Enabled = true;
            ResetValues();
            txtmadondathang.Text = Functions.CreateKey("HDB");
            Load_DataGridViewChitiet();
        }

        private void btnluu_Click(object sender, EventArgs e)
        {
            string sql;
            double sl, SLcon, tong, Tongmoi;
            sql = "SELECT madondathang FROM DonDatHang WHERE madondathang=N'" + txtmadondathang.Text + "'";
            if (!Functions.CheckKey(sql))
            {
                // Mã hóa đơn chưa có, tiến hành lưu các thông tin chung
                // Mã HDBan được sinh tự động do đó không có trường hợp trùng khóa
                if (txtngaydathang.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập ngày bán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtngaydathang.Focus();
                    return;
                }
                if (cbomanhanvien.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cbomanhanvien.Focus();
                    return;
                }
                if (cbomakhach.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cbomakhach.Focus();
                    return;
                }
                sql = "INSERT INTO DonDatHang(madondathang, ngaydathang, manhanvien, makhach, tongtien) " +
                    "VALUES(N'" + txtmadondathang.Text.Trim() + "', '" +
                        Functions.ConvertDateTime(txtngaydathang.Text.Trim()) + "',N'" + cbomanhanvien.SelectedValue + "',N'" +
                        cbomakhach.SelectedValue + "'," + txttongtien.Text + ")";
                Functions.RunSql(sql);
            }

            // Kiểm tra ràng buộc để lưu thông tin của các mặt hàng
            if (cbomasanpham.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbomasanpham.Focus();
                return;
            }
            if ((txtsoluong.Text.Trim().Length == 0) || (txtsoluong.Text == "0"))
            {
                MessageBox.Show("Bạn phải nhập số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtsoluong.Text = "";
                txtsoluong.Focus();
                return;
            }
            if (txtkhuyenmai.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập khuyến mãi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtkhuyenmai.Focus();
                return;
            }
            sql = "SELECT masanpham FROM ChiTietDonDatHang WHERE masanpham=N'" + cbomasanpham.SelectedValue + "' AND madondathang = N'" + txtmadondathang.Text.Trim() + "'";
            if (Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã hàng này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ResetValuesHang();
                cbomasanpham.Focus();
                return;
            }
            // Kiểm tra xem số lượng hàng trong kho còn đủ để cung cấp không?
            sl = Convert.ToDouble(Functions.GetFieldValues("SELECT soluongkho FROM SanPham WHERE masanpham = N'" + cbomasanpham.SelectedValue + "'"));
            if (Convert.ToDouble(txtsoluong.Text) > sl)
            {
                MessageBox.Show("Số lượng mặt hàng này chỉ còn " + sl, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtsoluong.Text = "";
                txtsoluong.Focus();
                return;
            }
            sql = "INSERT INTO ChiTietDonDatHang(madondathang,masanpham, soluong, giamgia, thanhtien) VALUES(N'" + txtmadondathang.Text.Trim() + "', N'" + cbomasanpham.SelectedValue + "'," + txtsoluong.Text + "," + txtkhuyenmai.Text + "," + txtthanhtien.Text + ")";

            Functions.RunSql(sql);
            Load_DataGridViewChitiet();
            // Cập nhật lại số lượng của mặt hàng vào bảng SanPham
            SLcon = sl - Convert.ToDouble(txtsoluong.Text);
            sql = "UPDATE SanPham SET soluongkho =" + SLcon + " WHERE masanpham= N'" + cbomasanpham.SelectedValue + "'";
            Functions.RunSql(sql);
            // Cập nhật lại tổng tiền cho hóa đơn bán
            /*decimal oldAmount;
            bool succes = Decimal.TryParse(txtthanhtien.Text, NumberStyles.Any, info, out oldAmount);*/
            tong = Convert.ToDouble(Functions.GetFieldValues("SELECT tongtien FROM DonDatHang WHERE madondathang = N'" + txtmadondathang.Text + "'"));
            Tongmoi = tong + Convert.ToDouble(txtthanhtien.Text);
            sql = "UPDATE DonDatHang SET tongtien =" + Tongmoi + " WHERE madondathang = N'" + txtmadondathang.Text + "'";
            Functions.RunSql(sql);
            txttongtien.Text = Tongmoi.ToString();
            lblbangchu.Text = "Bằng chữ: " + Functions.ChuyenSoSangChu(Tongmoi.ToString());
            ResetValuesHang();
            btnhuy.Enabled = true;
            btnthemmoi.Enabled = true;
            groupThongtinchung.Enabled = false;
        }

        private void btnboqua_Click(object sender, EventArgs e)
        {
            ResetValues();
            btnboqua.Enabled = false;
            btnthemmoi.Enabled = true;
            btnhuy.Enabled = true;
            btnsua.Enabled = true;
            btnluu.Enabled = true;
            txtmadondathang.Enabled = false;
            txtngaydathang.Text = "";
            DataGridView.DataSource = null;
        }

        private void btnhuy_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string[] Mahang = new string[20];
                string sql;
                int n = 0;
                int i;
                sql = "SELECT masanpham FROM ChiTietDonDatHang WHERE madondathang = N'" + txtmadondathang.Text + "'";
                SqlCommand cmd = new SqlCommand(sql, Functions.Conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Mahang[n] = reader.GetString(0).ToString();
                    n = n + 1;
                }
                reader.Close();
                //Xóa danh sách các mặt hàng của hóa đơn
                for (i = 0; i <= n - 1; i++)
                    DelHang(txtmadondathang.Text, Mahang[i]);
                //Xóa hóa đơn
                sql = "DELETE DonDatHang WHERE madondathang =N'" + txtmadondathang.Text + "'";
                Functions.RunSqlDel(sql);
                ResetValues();
                Load_DataGridViewChitiet();
                btnhuy.Enabled = false;
                txttensanpham.Text = "";
                txttennhanvien.Text = "";
                txtngaydathang.Text = "";
                txtgiaban.Text = "";
                txtdiachikhachhang.Text = "";

            }
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            if (tblHDB.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtmadondathang.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bảng ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cbomanhanvien.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn mã nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cbomasanpham.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn mã sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string sql;
            sql = "UPDATE DonDatHang SET ngaydathang = N'" + Functions.ConvertDateTime(txtngaydathang.Text) + "', manhanvien = N'" + cbomanhanvien.SelectedValue.ToString() + "' WHERE madondathang = N'" + txtmadondathang.Text + "'";
            Functions.RunSql(sql);
            double sl;
            sl = Convert.ToDouble(Functions.GetFieldValues("SELECT soluongkho FROM SanPham WHERE masanpham = N'" + cbomasanpham.Text + "'"));
            // MessageBox.Show(Functions.GetFieldValues("SELECT soluong FROM SanPham WHERE masanpham = N'" + cbomasanpham.Text + "'"));
            //xử lý lại tổng số sản phẩm (tính cả hàng có trong SanPham vs ChiTietDonDatHang) vì sửa nên phải cộng số lượng lại để ra số lượng ban đầu
            double sl1, sl2;
            sl1 = Convert.ToDouble(Functions.GetFieldValues("SELECT soluong FROM ChiTietDonDatHang WHERE masanpham = N'" + cbomasanpham.Text + "'AND madondathang = N'" + txtmadondathang.Text + "'"));
            //  MessageBox.Show(Functions.GetFieldValues("SELECT soluong FROM ChiTietDonDatHang WHERE masanpham = N'" + cbomasanpham.Text + "'AND madondathang = N'" + txtmadondathang.Text + "'"));

            sl2 = sl1 + sl;

            if (Convert.ToDouble(txtsoluong.Text) > sl2)
            {
                MessageBox.Show("Số lượng mặt hàng này chỉ còn " + sl2, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtsoluong.Text = "";
                txtsoluong.Focus();
                return;
            }

            double SLcon;
            double slmoi;
            slmoi = Convert.ToDouble(txtsoluong.Text);
            SLcon = sl2 - slmoi;

            sql = "UPDATE ChiTietDonDatHang SET masanpham = N'" + cbomasanpham.Text + "', soluong = " + Convert.ToSingle(txtsoluong.Text) + ", giamgia = " + Convert.ToSingle(txtkhuyenmai.Text) + ", thanhtien = " + Convert.ToSingle(txtthanhtien.Text) + " WHERE masanpham = N'" + cbomasanpham.Text + "'AND madondathang = N'" + txtmadondathang.Text + "'";
            Functions.RunSql(sql);


            // Cập nhật lại số lượng của mặt hàng vào bảng SanPham
            sql = "UPDATE SanPham SET soluongkho =" + SLcon + " WHERE masanpham= N'" + cbomasanpham.Text + "'";
            //MessageBox.Show(SLcon.ToString());
            Functions.RunSql(sql);
            // Cập nhật lại tổng tiền cho hóa đơn bán            
            string thanhtien;
            thanhtien = "SELECT SUM(thanhtien) FROM ChiTietDonDatHang WHERE madondathang = N'" + txtmadondathang.Text + "'  GROUP BY madondathang";
            string tt;
            tt = Functions.GetFieldValues(thanhtien);
            sql = "UPDATE DonDatHang SET tongtien =" + Convert.ToSingle(tt) + " WHERE madondathang = N'" + txtmadondathang.Text + "'";
            Functions.RunSql(sql);
            txttongtien.Text = tt.ToString();
            //tt = Convert.ToDouble(txttongtien.Text);
            lblbangchu.Text = "Bằng chữ: " + Functions.ChuyenSoSangChu(tt);
            ResetValuesHang();
            btnhuy.Enabled = true;
            btnthemmoi.Enabled = true;
            Load_DataGridViewChitiet();
            btnboqua.Enabled = true;
        }


        private void DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string mahang;
            Double Thanhtien;
            if (tblHDB.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if ((MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                //Xóa hàng và cập nhật lại số lượng hàng 
                mahang = DataGridView.CurrentRow.Cells["masanpham"].Value.ToString();
                DelHang(txtmadondathang.Text, mahang);
                // Cập nhật lại tổng tiền cho hóa đơn bán
                Thanhtien = Convert.ToDouble(DataGridView.CurrentRow.Cells["ThanhTien"].Value.ToString());
                DelUpdateTongtien(txtmadondathang.Text, Thanhtien);
                Load_DataGridViewChitiet();
            }
        }

        private void btndong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            if (cbomadondathang.Text == "")
            {
                MessageBox.Show("Bạn phải chọn một mã hóa đơn để tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbomadondathang.Focus();
                return;
            }
            txtmadondathang.Text = cbomadondathang.Text;
            ThongtinHD();
            Load_DataGridViewChitiet();
            btnhuy.Enabled = true;
            btnluu.Enabled = true;
            cbomadondathang.SelectedIndex = -1;
        }

        private void DataGridView_Click(object sender, EventArgs e)
        {
            cbomakhach.Enabled = false;
            groupThongtinchung.Enabled = false;
            cbomasanpham.Enabled = false;
            if (btnthemmoi.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmadondathang.Focus();
                return;
            }
            if (tblHDB.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string ma;
            ma = DataGridView.CurrentRow.Cells["masanpham"].Value.ToString();
            cbomasanpham.Text = Functions.GetFieldValues("SELECT masanpham FROM ChiTietDonDatHang WHERE masanpham = N'" + ma + "'");
            txtsoluong.Text = DataGridView.CurrentRow.Cells["soluong"].Value.ToString();
            txtkhuyenmai.Text = DataGridView.CurrentRow.Cells["giamgia"].Value.ToString();
            string s = "SELECT tennhanvien FROM NhanVien WHERE manhanvien = N'" + cbomanhanvien.Text + "'";
            txttennhanvien.Text = Functions.GetFieldValues(s);
            btnboqua.Enabled = true;
        }

        private void cbomanhanvien_TextChanged(object sender, EventArgs e)
        {
            string str;
            if (cbomanhanvien.Text == "")
                txttennhanvien.Text = "";
            // Khi kich chon Ma nhan vien thi ten nhan vien se tu dong hien ra
            str = "Select tennhanvien from NhanVien where manhanvien =N'" + cbomanhanvien.SelectedValue + "'";
            txttennhanvien.Text = Functions.GetFieldValues(str);
        }

        private void cbomakhach_TextChanged(object sender, EventArgs e)
        {
            string str;
            if (cbomakhach.Text == "")
            {
                txtdiachikhachhang.Text = "";
            }
            //Khi kich chon Ma khach thi  dia chi se tu dong hien ra

            str = "Select diachichitiet from KhachHang where makhach = N'" + cbomakhach.SelectedValue + "'";
            txtdiachikhachhang.Text = Functions.GetFieldValues(str);
        }

        private void cbomasanpham_TextChanged(object sender, EventArgs e)
        {
            string str;
            if (cbomasanpham.Text == "")
            {
                txttensanpham.Text = "";
                txtgiaban.Text = "";
            }
            // Khi kich chon Ma hang thi ten hang va gia ban se tu dong hien ra
            str = "SELECT tensanpham FROM SanPham WHERE masanpham =N'" + cbomasanpham.SelectedValue + "'";
            txttensanpham.Text = Functions.GetFieldValues(str);
            str = "SELECT dongiaban FROM SanPham WHERE masanpham =N'" + cbomasanpham.SelectedValue + "'";
            txtgiaban.Text = Functions.GetFieldValues(str);
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
            if (txtgiaban.Text == "")
                dg = 0;
            else
                dg = Convert.ToDouble(txtgiaban.Text);
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
            if (txtgiaban.Text == "")
                dg = 0;
            else
                dg = Convert.ToDouble(txtgiaban.Text);
            tt = sl * dg - sl * dg * gg / 100;
            txtthanhtien.Text = tt.ToString();
        }

        private void cbomadondathang_DropDown(object sender, EventArgs e)
        {
            Functions.FillCombo("SELECT madondathang FROM DonDatHang", cbomadondathang, "madondathang", "madondathang");
            cbomadondathang.SelectedIndex = -1;
        }

        private void txtsoluong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void groupThongtinchung_Enter(object sender, EventArgs e)
        {

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

        private void btnin_Click(object sender, EventArgs e)
        {
            // Khởi động chương trình Excel
            COMExcel.Application exApp = new COMExcel.Application();
            COMExcel.Workbook exBook; //Trong 1 chương trình Excel có nhiều Workbook
            COMExcel.Worksheet exSheet; //Trong 1 Workbook có nhiều Worksheet
            COMExcel.Range exRange;
            string sql;
            int hang = 0, cot = 0;
            DataTable tblThongtinHD, tblThongtinHang;
            exBook = exApp.Workbooks.Add(COMExcel.XlWBATemplate.xlWBATWorksheet);
            exSheet = exBook.Worksheets[1]; // Lưu ý
            // Định dạng chung
            exRange = exSheet.Cells[1, 1];
            exRange.Range["A1:B3"].Font.Size = 10;
            exRange.Range["A1:B3"].Font.Name = "Times new roman";
            exRange.Range["A1:B3"].Font.Bold = true;
            exRange.Range["A1:B3"].Font.ColorIndex = 5; //Màu xanh da trời
            exRange.Range["A1:A1"].ColumnWidth = 7;
            exRange.Range["B1:B1"].ColumnWidth = 15;
            exRange.Range["A1:B1"].MergeCells = true;
            exRange.Range["A1:B1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A1:B1"].Value = "Shop AJUMA";

            exRange.Range["A2:B2"].MergeCells = true;
            exRange.Range["A2:B2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:B2"].Value = "Đống Đa - Hà Nội";

            exRange.Range["A3:B3"].MergeCells = true;
            exRange.Range["A3:B3"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A3:B3"].Value = "Điện thoại: (03)47562222";


            exRange.Range["C2:E2"].Font.Size = 16;
            exRange.Range["C2:E2"].Font.Name = "Times new roman";
            exRange.Range["C2:E2"].Font.Bold = true;
            exRange.Range["C2:E2"].Font.ColorIndex = 3; //Màu đỏ
            exRange.Range["C2:E2"].MergeCells = true;
            exRange.Range["C2:E2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C2:E2"].Value = "HÓA ĐƠN BÁN";
            // Biểu diễn thông tin chung của hóa đơn bán
            sql = "SELECT a.madondathang, a.ngaydathang, a.tongtien, b.tenkhach, b.diachichitiet, b.sdt, c.tennhanvien FROM DonDatHang AS a, KhachHang AS b, NhanVien AS c WHERE a.madondathang = N'" + txtmadondathang.Text + "' AND a.makhach = b.makhach AND a.manhanvien = c.manhanvien";
            tblThongtinHD = Functions.GetDataToTable(sql);
            exRange.Range["B6:C9"].Font.Size = 12;
            exRange.Range["B6:C9"].Font.Name = "Times new roman";
            exRange.Range["B6:B6"].Value = "Mã hóa đơn:";
            exRange.Range["C6:E6"].MergeCells = true;
            exRange.Range["C6:E6"].Value = tblThongtinHD.Rows[0][0].ToString();
            exRange.Range["B7:B7"].Value = "Khách hàng:";
            exRange.Range["C7:E7"].MergeCells = true;
            exRange.Range["C7:E7"].Value = tblThongtinHD.Rows[0][3].ToString();
            exRange.Range["B8:B8"].Value = "Địa chỉ:";
            exRange.Range["C8:E8"].MergeCells = true;
            exRange.Range["C8:E8"].Value = tblThongtinHD.Rows[0][4].ToString();
            exRange.Range["B9:B9"].Value = "Điện thoại:";
            exRange.Range["C9:E9"].MergeCells = true;
            exRange.Range["C9:E9"].Value = tblThongtinHD.Rows[0][5].ToString();
            //Lấy thông tin các mặt hàng
            sql = "SELECT b.tensanpham, a.soluong, b.dongiaban, a.giamgia, a.thanhtien " +
                  "FROM ChiTietDonDatHang AS a , SanPham AS b WHERE a.madondathang = N'" +
                  txtmadondathang.Text + "' AND a.masanpham = b.masanpham";
            tblThongtinHang = Functions.GetDataToTable(sql);
            //Tạo dòng tiêu đề bảng
            exRange.Range["A11:F11"].Font.Bold = true;
            exRange.Range["A11:F11"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C11:F11"].ColumnWidth = 12;
            exRange.Range["A11:A11"].Value = "STT";
            exRange.Range["B11:B11"].Value = "Tên Sản Phẩm";
            exRange.Range["C11:C11"].Value = "Số lượng";
            exRange.Range["D11:D11"].Value = "Đơn giá";
            exRange.Range["E11:E11"].Value = "Khuyến mãi";
            exRange.Range["F11:F11"].Value = "Thành tiền";
            for (hang = 0; hang <= tblThongtinHang.Rows.Count - 1; hang++)
            {
                //Điền số thứ tự vào cột 1 từ dòng 12
                exSheet.Cells[1][hang + 12] = hang + 1;
                for (cot = 0; cot <= tblThongtinHang.Columns.Count - 1; cot++)
                    //Điền thông tin hàng từ cột thứ 2, dòng 12
                    exSheet.Cells[cot + 2][hang + 12] = tblThongtinHang.Rows[hang][cot].ToString();
            }
            exRange = exSheet.Cells[cot][hang + 14];
            exRange.Font.Bold = true;
            exRange.Value2 = "Tổng tiền:";
            exRange = exSheet.Cells[cot + 1][hang + 14];
            exRange.Font.Bold = true;
            exRange.Value2 = tblThongtinHD.Rows[0][2].ToString();
            exRange = exSheet.Cells[1][hang + 15]; //Ô A1 
            exRange.Range["A1:F1"].MergeCells = true;
            exRange.Range["A1:F1"].Font.Bold = true;
            exRange.Range["A1:F1"].Font.Italic = true;
            exRange.Range["A1:F1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignRight;
            exRange.Range["A1:F1"].Value = "Bằng chữ: " + Functions.ChuyenSoSangChu
 (tblThongtinHD.Rows[0][2].ToString());
            exRange = exSheet.Cells[4][hang + 17]; //Ô A1 
            exRange.Range["A1:C1"].MergeCells = true;
            exRange.Range["A1:C1"].Font.Italic = true;
            exRange.Range["A1:C1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            DateTime d = Convert.ToDateTime(tblThongtinHD.Rows[0][1]);
            exRange.Range["A1:C1"].Value = "Hà Nội, ngày " + d.Day + " tháng " + d.Month + " năm " + d.Year;
            exRange.Range["A2:C2"].MergeCells = true;
            exRange.Range["A2:C2"].Font.Italic = true;
            exRange.Range["A2:C2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:C2"].Value = "Nhân viên bán hàng";
            exRange.Range["A6:C6"].MergeCells = true;
            exRange.Range["A6:C6"].Font.Italic = true;
            exRange.Range["A6:C6"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A6:C6"].Value = tblThongtinHD.Rows[0][6];
            exSheet.Name = "Hóa đơn nhập";
            exApp.Visible = true;

        }

        private void txtngaydathang_TextChanged(object sender, EventArgs e)
        {

        }
    }
    
}
