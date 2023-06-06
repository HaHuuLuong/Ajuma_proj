using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ajuma.Forms
{
    public partial class Sendcode : Form
    {
        string randomcode;
        public static string to;
        public Sendcode()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string from, pass, mesagebody;
            Random rand = new Random();
            randomcode = rand.Next(999999).ToString();
            MailMessage message = new MailMessage();
            to = textBox1.Text.ToString();
            from = "23a4040079@bav.edu.vn";
            pass = "gelqfbxqmkrsezym";
            mesagebody = $"Mã code của bạn là: {randomcode} ";
            message.To.Add(to);
            message.From = new MailAddress(from);
            message.Body = mesagebody;
            message.Subject = "Mã khôi phục tài khoản Ajuma";
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(from,pass);
            try
            {
                smtp.Send(message);
                MessageBox.Show("Code Successfull");

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (randomcode == textBox2.Text.ToString())
            {
                to = textBox1.Text;
                Resetpassword rs = new Resetpassword();
                this.Hide();
                rs.Show();
            }
            else
            {
                MessageBox.Show("Error");
            }    
        }
    }
}
