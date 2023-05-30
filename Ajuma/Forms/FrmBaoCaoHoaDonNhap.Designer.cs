namespace Ajuma.Forms
{
    partial class FrmBaoCaoHoaDonNhap
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txttongtien = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lbbangchu = new System.Windows.Forms.Label();
            this.dgbchdnhap = new System.Windows.Forms.DataGridView();
            this.cbonhacc = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btndong = new System.Windows.Forms.Button();
            this.btnin = new System.Windows.Forms.Button();
            this.btntimlai = new System.Windows.Forms.Button();
            this.btntimkiem = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblText = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgbchdnhap)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txttongtien
            // 
            this.txttongtien.Location = new System.Drawing.Point(668, 475);
            this.txttongtien.Name = "txttongtien";
            this.txttongtien.Size = new System.Drawing.Size(100, 26);
            this.txttongtien.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(562, 475);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 20);
            this.label2.TabIndex = 17;
            this.label2.Text = "Tổng Tiền";
            // 
            // lbbangchu
            // 
            this.lbbangchu.AutoSize = true;
            this.lbbangchu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbbangchu.Location = new System.Drawing.Point(197, 442);
            this.lbbangchu.Name = "lbbangchu";
            this.lbbangchu.Size = new System.Drawing.Size(93, 20);
            this.lbbangchu.TabIndex = 16;
            this.lbbangchu.Text = "Bằng Chữ:";
            // 
            // dgbchdnhap
            // 
            this.dgbchdnhap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgbchdnhap.Location = new System.Drawing.Point(184, 249);
            this.dgbchdnhap.Name = "dgbchdnhap";
            this.dgbchdnhap.RowHeadersWidth = 51;
            this.dgbchdnhap.Size = new System.Drawing.Size(615, 170);
            this.dgbchdnhap.TabIndex = 15;
            // 
            // cbonhacc
            // 
            this.cbonhacc.FormattingEnabled = true;
            this.cbonhacc.Location = new System.Drawing.Point(508, 171);
            this.cbonhacc.Name = "cbonhacc";
            this.cbonhacc.Size = new System.Drawing.Size(121, 28);
            this.cbonhacc.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(327, 174);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 25);
            this.label1.TabIndex = 13;
            this.label1.Text = "Nhà Cung Cấp";
            // 
            // btndong
            // 
            this.btndong.Image = global::Ajuma.Properties.Resources.Custom_Icon_Design_Flatastic_9_Login;
            this.btndong.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btndong.Location = new System.Drawing.Point(635, 542);
            this.btndong.Name = "btndong";
            this.btndong.Size = new System.Drawing.Size(124, 42);
            this.btndong.TabIndex = 26;
            this.btndong.Text = "Đóng";
            this.btndong.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btndong.UseVisualStyleBackColor = true;
            this.btndong.Click += new System.EventHandler(this.btndong_Click);
            // 
            // btnin
            // 
            this.btnin.Image = global::Ajuma.Properties.Resources.Aha_Soft_Universal_Shop_Print1;
            this.btnin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnin.Location = new System.Drawing.Point(447, 542);
            this.btnin.Name = "btnin";
            this.btnin.Size = new System.Drawing.Size(156, 42);
            this.btnin.TabIndex = 25;
            this.btnin.Text = "In Báo Cáo";
            this.btnin.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnin.UseVisualStyleBackColor = true;
            this.btnin.Click += new System.EventHandler(this.btnin_Click);
            // 
            // btntimlai
            // 
            this.btntimlai.Image = global::Ajuma.Properties.Resources.Ahmadhania_Spherical_Redo;
            this.btntimlai.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btntimlai.Location = new System.Drawing.Point(289, 542);
            this.btntimlai.Name = "btntimlai";
            this.btntimlai.Size = new System.Drawing.Size(125, 42);
            this.btntimlai.TabIndex = 24;
            this.btntimlai.Text = "Tìm Lại";
            this.btntimlai.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btntimlai.UseVisualStyleBackColor = true;
            this.btntimlai.Click += new System.EventHandler(this.btntimlai_Click);
            // 
            // btntimkiem
            // 
            this.btntimkiem.Image = global::Ajuma.Properties.Resources.Icojam_Blue_Bits_Application_search;
            this.btntimkiem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btntimkiem.Location = new System.Drawing.Point(132, 542);
            this.btntimkiem.Name = "btntimkiem";
            this.btntimkiem.Size = new System.Drawing.Size(129, 42);
            this.btntimkiem.TabIndex = 23;
            this.btntimkiem.Text = "Tìm Kiếm";
            this.btntimkiem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btntimkiem.UseVisualStyleBackColor = true;
            this.btntimkiem.Click += new System.EventHandler(this.btntimkiem_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel1.Controls.Add(this.lblText);
            this.panel1.Font = new System.Drawing.Font("Segoe UI Historic", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(201, 26);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(567, 82);
            this.panel1.TabIndex = 27;
            // 
            // lblText
            // 
            this.lblText.AutoSize = true;
            this.lblText.Font = new System.Drawing.Font("Mongolian Baiti", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblText.Location = new System.Drawing.Point(53, 0);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(470, 50);
            this.lblText.TabIndex = 28;
            this.lblText.Text = "Báo cáo hóa đơn nhập";
            this.lblText.Click += new System.EventHandler(this.label3_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 200;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FrmBaoCaoHoaDonNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Pink;
            this.ClientSize = new System.Drawing.Size(982, 643);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btndong);
            this.Controls.Add(this.btnin);
            this.Controls.Add(this.btntimlai);
            this.Controls.Add(this.btntimkiem);
            this.Controls.Add(this.txttongtien);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbbangchu);
            this.Controls.Add(this.dgbchdnhap);
            this.Controls.Add(this.cbonhacc);
            this.Controls.Add(this.label1);
            this.Name = "FrmBaoCaoHoaDonNhap";
            this.Text = "FrmBaoCaoHoaDonNhap";
            this.Load += new System.EventHandler(this.FrmBaoCaoHoaDonNhap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgbchdnhap)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txttongtien;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbbangchu;
        private System.Windows.Forms.DataGridView dgbchdnhap;
        private System.Windows.Forms.ComboBox cbonhacc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btndong;
        private System.Windows.Forms.Button btnin;
        private System.Windows.Forms.Button btntimlai;
        private System.Windows.Forms.Button btntimkiem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblText;
        private System.Windows.Forms.Timer timer1;
    }
}