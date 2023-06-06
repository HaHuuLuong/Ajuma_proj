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
    public partial class Resetpassword : Form
    {
        public Resetpassword()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmLogin frmLogin = new FrmLogin();
            this.Hide();
            frmLogin.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql;
            string password = textBox2.Text;
            if(textBox1.Text == password)
            {
                sql = "UPDATE TaiKhoan SET  matKhau = N'" + password + "' WHERE IDTaiKhoan = 1";
                Class.Functions.RunSql(sql);
            }
            else
            {
                MessageBox.Show("Lỗi thực hiện");
            }
        }
    }
}
