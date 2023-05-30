namespace Ajuma.Forms
{
    partial class FrmHoaDonNhap
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
            this.cbomahdnhap = new System.Windows.Forms.ComboBox();
            this.btntimkiem = new System.Windows.Forms.Button();
            this.btnsua = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.grbchitiethd = new System.Windows.Forms.GroupBox();
            this.txtmahdnhap1 = new System.Windows.Forms.TextBox();
            this.txtdongia = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.DataGridView = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cbomasp = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txttensp = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtsoluong = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtthanhtien = new System.Windows.Forms.TextBox();
            this.txtkhuyenmai = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.grbthongtinphieu = new System.Windows.Forms.GroupBox();
            this.txtmahdnhap = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbomanhanvien = new System.Windows.Forms.ComboBox();
            this.txttennhanvien = new System.Windows.Forms.TextBox();
            this.txtngaynhap = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbomanhacungcap = new System.Windows.Forms.ComboBox();
            this.txttennhacungcap = new System.Windows.Forms.TextBox();
            this.txttongtien = new System.Windows.Forms.TextBox();
            this.lblbangchu = new System.Windows.Forms.Label();
            this.btndong = new System.Windows.Forms.Button();
            this.btnhuyhd = new System.Windows.Forms.Button();
            this.btnluuhd = new System.Windows.Forms.Button();
            this.btnthemhd = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.grbchitiethd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView)).BeginInit();
            this.grbthongtinphieu.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbomahdnhap
            // 
            this.cbomahdnhap.FormattingEnabled = true;
            this.cbomahdnhap.Location = new System.Drawing.Point(758, 595);
            this.cbomahdnhap.Name = "cbomahdnhap";
            this.cbomahdnhap.Size = new System.Drawing.Size(167, 28);
            this.cbomahdnhap.TabIndex = 56;
            this.cbomahdnhap.DropDown += new System.EventHandler(this.cbomahdnhap_DropDown);
            // 
            // btntimkiem
            // 
            this.btntimkiem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btntimkiem.Location = new System.Drawing.Point(956, 583);
            this.btntimkiem.Name = "btntimkiem";
            this.btntimkiem.Size = new System.Drawing.Size(128, 46);
            this.btntimkiem.TabIndex = 55;
            this.btntimkiem.Text = "Tìm Kiếm";
            this.btntimkiem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btntimkiem.UseVisualStyleBackColor = true;
            this.btntimkiem.Click += new System.EventHandler(this.btntimkiem_Click);
            // 
            // btnsua
            // 
            this.btnsua.BackColor = System.Drawing.SystemColors.Control;
            this.btnsua.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnsua.Location = new System.Drawing.Point(599, 657);
            this.btnsua.Name = "btnsua";
            this.btnsua.Size = new System.Drawing.Size(107, 50);
            this.btnsua.TabIndex = 54;
            this.btnsua.Text = "SỬA";
            this.btnsua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnsua.UseVisualStyleBackColor = false;
            this.btnsua.Click += new System.EventHandler(this.btnsua_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.FloralWhite;
            this.label16.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Red;
            this.label16.Location = new System.Drawing.Point(449, 29);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(397, 40);
            this.label16.TabIndex = 53;
            this.label16.Text = "HÓA ĐƠN NHẬP HÀNG";
            // 
            // grbchitiethd
            // 
            this.grbchitiethd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.grbchitiethd.Controls.Add(this.txtmahdnhap1);
            this.grbchitiethd.Controls.Add(this.txtdongia);
            this.grbchitiethd.Controls.Add(this.label15);
            this.grbchitiethd.Controls.Add(this.DataGridView);
            this.grbchitiethd.Controls.Add(this.label1);
            this.grbchitiethd.Controls.Add(this.label9);
            this.grbchitiethd.Controls.Add(this.cbomasp);
            this.grbchitiethd.Controls.Add(this.label10);
            this.grbchitiethd.Controls.Add(this.txttensp);
            this.grbchitiethd.Controls.Add(this.label11);
            this.grbchitiethd.Controls.Add(this.txtsoluong);
            this.grbchitiethd.Controls.Add(this.label13);
            this.grbchitiethd.Controls.Add(this.txtthanhtien);
            this.grbchitiethd.Controls.Add(this.txtkhuyenmai);
            this.grbchitiethd.Controls.Add(this.label14);
            this.grbchitiethd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbchitiethd.Location = new System.Drawing.Point(120, 265);
            this.grbchitiethd.Name = "grbchitiethd";
            this.grbchitiethd.Size = new System.Drawing.Size(1037, 303);
            this.grbchitiethd.TabIndex = 52;
            this.grbchitiethd.TabStop = false;
            this.grbchitiethd.Text = "CHI TIẾT HÓA ĐƠN";
            // 
            // txtmahdnhap1
            // 
            this.txtmahdnhap1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtmahdnhap1.Location = new System.Drawing.Point(9, 57);
            this.txtmahdnhap1.Name = "txtmahdnhap1";
            this.txtmahdnhap1.Size = new System.Drawing.Size(132, 28);
            this.txtmahdnhap1.TabIndex = 42;
            // 
            // txtdongia
            // 
            this.txtdongia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdongia.Location = new System.Drawing.Point(570, 57);
            this.txtdongia.Name = "txtdongia";
            this.txtdongia.Size = new System.Drawing.Size(118, 28);
            this.txtdongia.TabIndex = 41;
            this.txtdongia.TextChanged += new System.EventHandler(this.txtdongia_TextChanged);
            this.txtdongia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtdongia_KeyPress);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(588, 32);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(85, 22);
            this.label15.TabIndex = 40;
            this.label15.Text = "ĐƠN GIÁ";
            // 
            // DataGridView
            // 
            this.DataGridView.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView.Location = new System.Drawing.Point(111, 111);
            this.DataGridView.Name = "DataGridView";
            this.DataGridView.RowHeadersWidth = 51;
            this.DataGridView.RowTemplate.Height = 24;
            this.DataGridView.Size = new System.Drawing.Size(782, 172);
            this.DataGridView.TabIndex = 35;
            this.DataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_CellDoubleClick);
            this.DataGridView.Click += new System.EventHandler(this.DataGridView_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(-6, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 22);
            this.label1.TabIndex = 2;
            this.label1.Text = "MÃ HÓA ĐƠNNHẬP";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(175, 30);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(134, 22);
            this.label9.TabIndex = 17;
            this.label9.Text = "MÃ SẢN PHẨM";
            // 
            // cbomasp
            // 
            this.cbomasp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbomasp.FormattingEnabled = true;
            this.cbomasp.Location = new System.Drawing.Point(169, 55);
            this.cbomasp.Name = "cbomasp";
            this.cbomasp.Size = new System.Drawing.Size(121, 30);
            this.cbomasp.TabIndex = 29;
            this.cbomasp.TextChanged += new System.EventHandler(this.cbomasp_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(303, 30);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(145, 22);
            this.label10.TabIndex = 18;
            this.label10.Text = "TÊN SẢN PHẨM";
            // 
            // txttensp
            // 
            this.txttensp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttensp.Location = new System.Drawing.Point(314, 57);
            this.txttensp.Name = "txttensp";
            this.txttensp.Size = new System.Drawing.Size(108, 28);
            this.txttensp.TabIndex = 25;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(454, 32);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(105, 22);
            this.label11.TabIndex = 19;
            this.label11.Text = "SỐ LƯỢNG";
            // 
            // txtsoluong
            // 
            this.txtsoluong.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsoluong.Location = new System.Drawing.Point(458, 57);
            this.txtsoluong.Name = "txtsoluong";
            this.txtsoluong.Size = new System.Drawing.Size(100, 28);
            this.txtsoluong.TabIndex = 24;
            this.txtsoluong.TextChanged += new System.EventHandler(this.txtsoluong_TextChanged);
            this.txtsoluong.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtsoluong_KeyPress);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(714, 30);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(120, 22);
            this.label13.TabIndex = 21;
            this.label13.Text = "KHUYẾN MÃI";
            // 
            // txtthanhtien
            // 
            this.txtthanhtien.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtthanhtien.Location = new System.Drawing.Point(850, 57);
            this.txtthanhtien.Name = "txtthanhtien";
            this.txtthanhtien.Size = new System.Drawing.Size(124, 28);
            this.txtthanhtien.TabIndex = 28;
            // 
            // txtkhuyenmai
            // 
            this.txtkhuyenmai.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtkhuyenmai.Location = new System.Drawing.Point(717, 57);
            this.txtkhuyenmai.Name = "txtkhuyenmai";
            this.txtkhuyenmai.Size = new System.Drawing.Size(110, 28);
            this.txtkhuyenmai.TabIndex = 27;
            this.txtkhuyenmai.TextChanged += new System.EventHandler(this.txtkhuyenmai_TextChanged);
            this.txtkhuyenmai.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtkhuyenmai_KeyPress);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(857, 30);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(119, 22);
            this.label14.TabIndex = 22;
            this.label14.Text = "THÀNH TIỀN";
            // 
            // grbthongtinphieu
            // 
            this.grbthongtinphieu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.grbthongtinphieu.Controls.Add(this.txtmahdnhap);
            this.grbthongtinphieu.Controls.Add(this.label8);
            this.grbthongtinphieu.Controls.Add(this.label3);
            this.grbthongtinphieu.Controls.Add(this.label2);
            this.grbthongtinphieu.Controls.Add(this.cbomanhanvien);
            this.grbthongtinphieu.Controls.Add(this.txttennhanvien);
            this.grbthongtinphieu.Controls.Add(this.txtngaynhap);
            this.grbthongtinphieu.Controls.Add(this.label4);
            this.grbthongtinphieu.Controls.Add(this.label7);
            this.grbthongtinphieu.Controls.Add(this.label6);
            this.grbthongtinphieu.Controls.Add(this.label5);
            this.grbthongtinphieu.Controls.Add(this.cbomanhacungcap);
            this.grbthongtinphieu.Controls.Add(this.txttennhacungcap);
            this.grbthongtinphieu.Controls.Add(this.txttongtien);
            this.grbthongtinphieu.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbthongtinphieu.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.grbthongtinphieu.Location = new System.Drawing.Point(120, 84);
            this.grbthongtinphieu.Name = "grbthongtinphieu";
            this.grbthongtinphieu.Size = new System.Drawing.Size(1007, 164);
            this.grbthongtinphieu.TabIndex = 51;
            this.grbthongtinphieu.TabStop = false;
            this.grbthongtinphieu.Text = "THÔNG TIN HÓA ĐƠN";
            // 
            // txtmahdnhap
            // 
            this.txtmahdnhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtmahdnhap.Location = new System.Drawing.Point(179, 37);
            this.txtmahdnhap.Name = "txtmahdnhap";
            this.txtmahdnhap.Size = new System.Drawing.Size(144, 25);
            this.txtmahdnhap.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(14, 42);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(159, 20);
            this.label8.TabIndex = 16;
            this.label8.Text = "MÃ HÓA ĐƠN NHẬP";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(360, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "MÃ NHÂN VIÊN";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(360, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "TÊN NHÂN VIÊN";
            // 
            // cbomanhanvien
            // 
            this.cbomanhanvien.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbomanhanvien.FormattingEnabled = true;
            this.cbomanhanvien.Location = new System.Drawing.Point(496, 41);
            this.cbomanhanvien.Name = "cbomanhanvien";
            this.cbomanhanvien.Size = new System.Drawing.Size(119, 28);
            this.cbomanhanvien.TabIndex = 14;
            this.cbomanhanvien.TextChanged += new System.EventHandler(this.cbomanhanvien_TextChanged);
            // 
            // txttennhanvien
            // 
            this.txttennhanvien.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttennhanvien.Location = new System.Drawing.Point(496, 81);
            this.txttennhanvien.Name = "txttennhanvien";
            this.txttennhanvien.Size = new System.Drawing.Size(119, 25);
            this.txttennhanvien.TabIndex = 11;
            // 
            // txtngaynhap
            // 
            this.txtngaynhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtngaynhap.Location = new System.Drawing.Point(179, 75);
            this.txtngaynhap.Name = "txtngaynhap";
            this.txtngaynhap.Size = new System.Drawing.Size(144, 25);
            this.txtngaynhap.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(43, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "NGÀY NHẬP";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(649, 42);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(158, 20);
            this.label7.TabIndex = 8;
            this.label7.Text = "MÃ NHÀ CUNG CẤP";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(649, 83);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(165, 20);
            this.label6.TabIndex = 7;
            this.label6.Text = "TÊN NHÀ CUNG CẤP";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(649, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 20);
            this.label5.TabIndex = 6;
            this.label5.Text = "TỔNG TIỀN";
            // 
            // cbomanhacungcap
            // 
            this.cbomanhacungcap.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbomanhacungcap.FormattingEnabled = true;
            this.cbomanhacungcap.Location = new System.Drawing.Point(836, 35);
            this.cbomanhacungcap.Name = "cbomanhacungcap";
            this.cbomanhacungcap.Size = new System.Drawing.Size(116, 28);
            this.cbomanhacungcap.TabIndex = 15;
            this.cbomanhacungcap.TextChanged += new System.EventHandler(this.cbomanhacungcap_TextChanged);
            // 
            // txttennhacungcap
            // 
            this.txttennhacungcap.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttennhacungcap.Location = new System.Drawing.Point(836, 78);
            this.txttennhacungcap.Name = "txttennhacungcap";
            this.txttennhacungcap.Size = new System.Drawing.Size(116, 25);
            this.txttennhacungcap.TabIndex = 12;
            // 
            // txttongtien
            // 
            this.txttongtien.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttongtien.Location = new System.Drawing.Point(836, 121);
            this.txttongtien.Name = "txttongtien";
            this.txttongtien.Size = new System.Drawing.Size(116, 25);
            this.txttongtien.TabIndex = 13;
            // 
            // lblbangchu
            // 
            this.lblbangchu.AutoSize = true;
            this.lblbangchu.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblbangchu.Location = new System.Drawing.Point(126, 598);
            this.lblbangchu.Name = "lblbangchu";
            this.lblbangchu.Size = new System.Drawing.Size(107, 20);
            this.lblbangchu.TabIndex = 50;
            this.lblbangchu.Text = "BẰNG CHỮ:";
            // 
            // btndong
            // 
            this.btndong.BackColor = System.Drawing.SystemColors.Control;
            this.btndong.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndong.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btndong.Location = new System.Drawing.Point(996, 657);
            this.btndong.Name = "btndong";
            this.btndong.Size = new System.Drawing.Size(120, 52);
            this.btndong.TabIndex = 49;
            this.btndong.Text = "ĐÓNG";
            this.btndong.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btndong.UseVisualStyleBackColor = false;
            this.btndong.Click += new System.EventHandler(this.btndong_Click);
            // 
            // btnhuyhd
            // 
            this.btnhuyhd.BackColor = System.Drawing.SystemColors.Control;
            this.btnhuyhd.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnhuyhd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnhuyhd.Location = new System.Drawing.Point(758, 651);
            this.btnhuyhd.Name = "btnhuyhd";
            this.btnhuyhd.Size = new System.Drawing.Size(178, 57);
            this.btnhuyhd.TabIndex = 48;
            this.btnhuyhd.Text = "HỦY HÓA ĐƠN";
            this.btnhuyhd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnhuyhd.UseVisualStyleBackColor = false;
            this.btnhuyhd.Click += new System.EventHandler(this.btnhuyhd_Click);
            // 
            // btnluuhd
            // 
            this.btnluuhd.BackColor = System.Drawing.SystemColors.Control;
            this.btnluuhd.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnluuhd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnluuhd.Location = new System.Drawing.Point(360, 657);
            this.btnluuhd.Name = "btnluuhd";
            this.btnluuhd.Size = new System.Drawing.Size(182, 50);
            this.btnluuhd.TabIndex = 47;
            this.btnluuhd.Text = "LƯU HÓA ĐƠN";
            this.btnluuhd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnluuhd.UseVisualStyleBackColor = false;
            this.btnluuhd.Click += new System.EventHandler(this.btnluuhd_Click);
            // 
            // btnthemhd
            // 
            this.btnthemhd.BackColor = System.Drawing.SystemColors.Control;
            this.btnthemhd.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnthemhd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnthemhd.Location = new System.Drawing.Point(126, 651);
            this.btnthemhd.Name = "btnthemhd";
            this.btnthemhd.Size = new System.Drawing.Size(192, 56);
            this.btnthemhd.TabIndex = 46;
            this.btnthemhd.Text = "THÊM HÓA ĐƠN";
            this.btnthemhd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnthemhd.UseVisualStyleBackColor = false;
            this.btnthemhd.Click += new System.EventHandler(this.btnthemhd_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(665, 332);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(0, 20);
            this.label12.TabIndex = 45;
            // 
            // FrmHoaDonNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1247, 740);
            this.Controls.Add(this.cbomahdnhap);
            this.Controls.Add(this.btntimkiem);
            this.Controls.Add(this.btnsua);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.grbchitiethd);
            this.Controls.Add(this.grbthongtinphieu);
            this.Controls.Add(this.lblbangchu);
            this.Controls.Add(this.btndong);
            this.Controls.Add(this.btnhuyhd);
            this.Controls.Add(this.btnluuhd);
            this.Controls.Add(this.btnthemhd);
            this.Controls.Add(this.label12);
            this.Name = "FrmHoaDonNhap";
            this.Text = "FrmHoaDonNhap";
            this.Load += new System.EventHandler(this.FrmHoaDonNhap_Load);
            this.grbchitiethd.ResumeLayout(false);
            this.grbchitiethd.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView)).EndInit();
            this.grbthongtinphieu.ResumeLayout(false);
            this.grbthongtinphieu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbomahdnhap;
        private System.Windows.Forms.Button btntimkiem;
        private System.Windows.Forms.Button btnsua;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.GroupBox grbchitiethd;
        private System.Windows.Forms.TextBox txtmahdnhap1;
        private System.Windows.Forms.TextBox txtdongia;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DataGridView DataGridView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbomasp;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txttensp;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtsoluong;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtthanhtien;
        private System.Windows.Forms.TextBox txtkhuyenmai;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.GroupBox grbthongtinphieu;
        public System.Windows.Forms.TextBox txtmahdnhap;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbomanhanvien;
        private System.Windows.Forms.TextBox txttennhanvien;
        private System.Windows.Forms.TextBox txtngaynhap;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbomanhacungcap;
        private System.Windows.Forms.TextBox txttennhacungcap;
        private System.Windows.Forms.TextBox txttongtien;
        private System.Windows.Forms.Label lblbangchu;
        private System.Windows.Forms.Button btndong;
        private System.Windows.Forms.Button btnhuyhd;
        private System.Windows.Forms.Button btnluuhd;
        private System.Windows.Forms.Button btnthemhd;
        private System.Windows.Forms.Label label12;
    }
}