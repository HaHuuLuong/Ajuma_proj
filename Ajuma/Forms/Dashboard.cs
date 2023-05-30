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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'ajuma_MỚI_DataSet3.DonDatHang' table. You can move, or remove it, as needed.
            this.donDatHangTableAdapter.Fill(this.ajuma_MỚI_DataSet3.DonDatHang);
            // TODO: This line of code loads data into the 'ajuma_MỚI_DataSet2.NgheSi' table. You can move, or remove it, as needed.
            this.ngheSiTableAdapter.Fill(this.ajuma_MỚI_DataSet2.NgheSi);
            // TODO: This line of code loads data into the 'ajuma_MỚI_DataSet.SanPham' table. You can move, or remove it, as needed.
            this.sanPhamTableAdapter.Fill(this.ajuma_MỚI_DataSet.SanPham);

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
