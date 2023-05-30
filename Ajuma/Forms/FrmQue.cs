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
    
    public partial class FrmQue : Form
    {
        public FrmQue()
        {
            InitializeComponent();
        }
        DataTable tblQ;
        private void FrmQue_Load(object sender, EventArgs e)
        {


            btnluu.Enabled = false;
            btnboqua.Enabled = false;
            txtmaque.Enabled = false;
            Load_DataGridView();
            ResetValues();
        }
        private void Load_DataGridView()
        {
            string sql;
            sql = "SELECT MaQue, TenQue FROM tblQue";
            tblQ = Functions.GetDataToTable(sql);
            dataGridView.DataSource = tblQ;
            dataGridView.Columns[0].HeaderText = "Mã quê";
            dataGridView.Columns[1].HeaderText = "Tên quê";

        }
        private void ResetValues()
        {
            txtmaque.Text = "";
            txttenque.Text = "";
        }

        private void dataGridView_Click(object sender, EventArgs e)
        {
            if (btnthem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmaque.Focus();
                return;
            }
            if (tblQ.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtmaque.Text = dataGridView.CurrentRow.Cells["MaQue"].Value.ToString();
            txttenque.Text = dataGridView.CurrentRow.Cells["TenQue"].Value.ToString();
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
            txtmaque.Enabled = true;
            txtmaque.Focus();
        }

        private void btnluu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtmaque.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã quê", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtmaque.Focus();
                return;
            }
            if (txttenque.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên quê", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txttenque.Focus();
                return;
            }

            sql = "SELECT MaQue FROM tblQue WHERE MaQue=N'" + txtmaque.Text.Trim() + "'";
            if (Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã quê này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtmaque.Focus();
                txtmaque.Text = "";
                return;
            }

            sql = "INSERT INTO tblque(MaQue,TenQue) VALUES(N'" + txtmaque.Text + "',N'" + txttenque.Text + "')";
            Functions.RunSql(sql);

            Load_DataGridView();
            ResetValues();
            btnxoa.Enabled = true;
            btnthem.Enabled = true;
            btnsua.Enabled = true;
            btnboqua.Enabled = false;
            btnluu.Enabled = false;
            txtmaque.Enabled = false;
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblQ.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtmaque.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txttenque.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên quê", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txttenque.Focus();
                return;
            }

            sql = "UPDATE tblQue SET TenQue=N'" + txttenque.Text.ToString() + "' WHERE MaQue=N'" + txtmaque.Text + "'";
            Functions.RunSql(sql);


            Load_DataGridView();
            ResetValues();
            btnboqua.Enabled = false;
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblQ.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtmaque.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE tblQue WHERE MaQue=N'" + txtmaque.Text + "'";

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
        }

        private void btndong_Click(object sender, EventArgs e)
        {

            this.Close();
        }
    }
}
