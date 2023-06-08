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
    public partial class FrmDashboard : Form
    {
        public FrmDashboard()
        {
            InitializeComponent();
        }

        private void FrmDashboard_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'ajuma_MỚI_Vux_DataSet81.SanPham' table. You can move, or remove it, as needed.
            this.sanPhamTableAdapter6.Fill(this.ajuma_MỚI_Vux_DataSet81.SanPham);
            // TODO: This line of code loads data into the 'ajuma_MỚI_Vux_DataSet7.SanPham' table. You can move, or remove it, as needed.
            //this.sanPhamTableAdapter5.Fill(this.ajuma_MỚI_Vux_DataSet7.SanPham);
            // TODO: This line of code loads data into the 'ajuma_MỚI_Vux_DataSet5.DonDatHang' table. You can move, or remove it, as needed.
            this.donDatHangTableAdapter4.Fill(this.ajuma_MỚI_Vux_DataSet5.DonDatHang);
            // TODO: This line of code loads data into the 'ajuma_MỚI_Vux_DataSet4.SanPham' table. You can move, or remove it, as needed.
            //this.sanPhamTableAdapter4.Fill(this.ajuma_MỚI_Vux_DataSet6.SanPham);
            // TODO: This line of code loads data into the 'ajuma_MỚI_Vux_DataSet3.DonDatHang' table. You can move, or remove it, as needed.
            //this.donDatHangTableAdapter3.Fill(this.ajuma_MỚI_Vux_DataSet3.DonDatHang);
            // TODO: This line of code loads data into the 'ajuma_MỚI_Vux_DataSet2.SanPham' table. You can move, or remove it, as needed.
            //this.sanPhamTableAdapter3.Fill(this.ajuma_MỚI_Vux_DataSet2.SanPham);
            // TODO: This line of code loads data into the 'ajuma_MỚI_Vux_DataSet1.SanPham' table. You can move, or remove it, as needed.
            //this.sanPhamTableAdapter2.Fill(this.ajuma_MỚI_Vux_DataSet1.SanPham);
            // TODO: This line of code loads data into the 'ajuma_MỚI_Vux_DataSet.DonDatHang' table. You can move, or remove it, as needed.
            //this.donDatHangTableAdapter2.Fill(this.ajuma_MỚI_Vux_DataSet.DonDatHang);
            /*  // TODO: This line of code loads data into the 'ajuma_MỚI_DataSet5.SanPham' table. You can move, or remove it, as needed.
              this.sanPhamTableAdapter1.Fill(this.ajuma_MỚI_DataSet5.SanPham);
              // TODO: This line of code loads data into the 'ajuma_MỚI_DataSet4.DonDatHang' table. You can move, or remove it, as needed.
              this.donDatHangTableAdapter1.Fill(this.ajuma_MỚI_DataSet4.DonDatHang);
              // TODO: This line of code loads data into the 'ajuma_MỚI_DataSet3.KhachHang' table. You can move, or remove it, as needed.
              this.khachHangTableAdapter.Fill(this.ajuma_MỚI_DataSet3.KhachHang);
              // TODO: This line of code loads data into the 'ajuma_MỚI_DataSet2.DonDatHang' table. You can move, or remove it, as needed.
              this.donDatHangTableAdapter.Fill(this.ajuma_MỚI_DataSet2.DonDatHang);
              // TODO: This line of code loads data into the 'ajuma_MỚI_DataSet1.SanPham' table. You can move, or remove it, as needed.
              this.sanPhamTableAdapter.Fill(this.ajuma_MỚI_DataSet1.SanPham);*/

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
