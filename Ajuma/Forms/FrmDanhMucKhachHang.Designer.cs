namespace Ajuma.Forms
{
    partial class FrmDanhMucKhachHang
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
            this.mskSDT = new System.Windows.Forms.MaskedTextBox();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.txtDiaChiChiTiet = new System.Windows.Forms.TextBox();
            this.txtTenKhach = new System.Windows.Forms.TextBox();
            this.txtMaKhach = new System.Windows.Forms.TextBox();
            this.btndong = new System.Windows.Forms.Button();
            this.btnboqua = new System.Windows.Forms.Button();
            this.btnluu = new System.Windows.Forms.Button();
            this.btnxoa = new System.Windows.Forms.Button();
            this.btnsua = new System.Windows.Forms.Button();
            this.btnthem = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.mskNgaySinh = new System.Windows.Forms.MaskedTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtFacebook = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cboXaPhuong = new System.Windows.Forms.ComboBox();
            this.cboQuanHuyen = new System.Windows.Forms.ComboBox();
            this.cboTinhThanh = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // mskSDT
            // 
            this.mskSDT.Location = new System.Drawing.Point(130, 158);
            this.mskSDT.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.mskSDT.Mask = "(999) 000-0000";
            this.mskSDT.Name = "mskSDT";
            this.mskSDT.Size = new System.Drawing.Size(148, 22);
            this.mskSDT.TabIndex = 32;
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(12, 283);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.RowTemplate.Height = 24;
            this.dataGridView.Size = new System.Drawing.Size(804, 144);
            this.dataGridView.TabIndex = 31;
            this.dataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellContentClick);
            this.dataGridView.Click += new System.EventHandler(this.dataGridView_Click);
            // 
            // txtDiaChiChiTiet
            // 
            this.txtDiaChiChiTiet.Location = new System.Drawing.Point(130, 201);
            this.txtDiaChiChiTiet.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDiaChiChiTiet.Multiline = true;
            this.txtDiaChiChiTiet.Name = "txtDiaChiChiTiet";
            this.txtDiaChiChiTiet.Size = new System.Drawing.Size(148, 55);
            this.txtDiaChiChiTiet.TabIndex = 30;
            // 
            // txtTenKhach
            // 
            this.txtTenKhach.Location = new System.Drawing.Point(130, 117);
            this.txtTenKhach.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTenKhach.Name = "txtTenKhach";
            this.txtTenKhach.Size = new System.Drawing.Size(148, 22);
            this.txtTenKhach.TabIndex = 29;
            this.txtTenKhach.TextChanged += new System.EventHandler(this.txttenkhach_TextChanged);
            // 
            // txtMaKhach
            // 
            this.txtMaKhach.Location = new System.Drawing.Point(130, 74);
            this.txtMaKhach.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMaKhach.Name = "txtMaKhach";
            this.txtMaKhach.Size = new System.Drawing.Size(148, 22);
            this.txtMaKhach.TabIndex = 28;
            // 
            // btndong
            // 
            this.btndong.Image = global::Ajuma.Properties.Resources.Custom_Icon_Design_Flatastic_9_Login;
            this.btndong.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btndong.Location = new System.Drawing.Point(629, 440);
            this.btndong.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btndong.Name = "btndong";
            this.btndong.Size = new System.Drawing.Size(92, 36);
            this.btndong.TabIndex = 27;
            this.btndong.Text = "Đóng";
            this.btndong.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btndong.UseVisualStyleBackColor = true;
            this.btndong.Click += new System.EventHandler(this.btndong_Click);
            // 
            // btnboqua
            // 
            this.btnboqua.Image = global::Ajuma.Properties.Resources.Custom_Icon_Design_Pretty_Office_8_Skip_forward;
            this.btnboqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnboqua.Location = new System.Drawing.Point(507, 440);
            this.btnboqua.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnboqua.Name = "btnboqua";
            this.btnboqua.Size = new System.Drawing.Size(101, 36);
            this.btnboqua.TabIndex = 26;
            this.btnboqua.Text = "Bỏ qua";
            this.btnboqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnboqua.UseVisualStyleBackColor = true;
            this.btnboqua.Click += new System.EventHandler(this.btnboqua_Click);
            // 
            // btnluu
            // 
            this.btnluu.Image = global::Ajuma.Properties.Resources.Custom_Icon_Design_Pretty_Office_7_Save;
            this.btnluu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnluu.Location = new System.Drawing.Point(404, 440);
            this.btnluu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnluu.Name = "btnluu";
            this.btnluu.Size = new System.Drawing.Size(80, 36);
            this.btnluu.TabIndex = 25;
            this.btnluu.Text = "Lưu";
            this.btnluu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnluu.UseVisualStyleBackColor = true;
            this.btnluu.Click += new System.EventHandler(this.btnluu_Click);
            // 
            // btnxoa
            // 
            this.btnxoa.Image = global::Ajuma.Properties.Resources.Hopstarter_Soft_Scraps_File_Delete;
            this.btnxoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnxoa.Location = new System.Drawing.Point(300, 440);
            this.btnxoa.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnxoa.Name = "btnxoa";
            this.btnxoa.Size = new System.Drawing.Size(89, 36);
            this.btnxoa.TabIndex = 24;
            this.btnxoa.Text = "Xoá";
            this.btnxoa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnxoa.UseVisualStyleBackColor = true;
            this.btnxoa.Click += new System.EventHandler(this.btnxoa_Click);
            // 
            // btnsua
            // 
            this.btnsua.Image = global::Ajuma.Properties.Resources.Bokehlicia_Captiva_Edit_tomboy1;
            this.btnsua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnsua.Location = new System.Drawing.Point(195, 440);
            this.btnsua.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnsua.Name = "btnsua";
            this.btnsua.Size = new System.Drawing.Size(83, 36);
            this.btnsua.TabIndex = 23;
            this.btnsua.Text = "Sửa";
            this.btnsua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnsua.UseVisualStyleBackColor = true;
            this.btnsua.Click += new System.EventHandler(this.btnsua_Click);
            // 
            // btnthem
            // 
            this.btnthem.Image = global::Ajuma.Properties.Resources.Hopstarter_Soft_Scraps_Folder_Add;
            this.btnthem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnthem.Location = new System.Drawing.Point(88, 440);
            this.btnthem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnthem.Name = "btnthem";
            this.btnthem.Size = new System.Drawing.Size(88, 36);
            this.btnthem.TabIndex = 22;
            this.btnthem.Text = "Thêm";
            this.btnthem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnthem.UseVisualStyleBackColor = true;
            this.btnthem.Click += new System.EventHandler(this.btnthem_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 216);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 17);
            this.label5.TabIndex = 21;
            this.label5.Text = "Địa chỉ chi tiết";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 163);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 17);
            this.label4.TabIndex = 20;
            this.label4.Text = "Số điện thoại";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 17);
            this.label3.TabIndex = 19;
            this.label3.Text = "Tên khách";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 17);
            this.label2.TabIndex = 18;
            this.label2.Text = "Mã khách";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.label1.Font = new System.Drawing.Font("Century", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(203, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(408, 33);
            this.label1.TabIndex = 17;
            this.label1.Text = "DANH MỤC KHÁCH HÀNG";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(320, 163);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 17);
            this.label6.TabIndex = 33;
            this.label6.Text = "Xã/Phường";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(320, 204);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 17);
            this.label7.TabIndex = 35;
            this.label7.Text = "Quận/Huyện";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(320, 239);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 17);
            this.label8.TabIndex = 37;
            this.label8.Text = "Tỉnh/Thành";
            // 
            // mskNgaySinh
            // 
            this.mskNgaySinh.Location = new System.Drawing.Point(418, 74);
            this.mskNgaySinh.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.mskNgaySinh.Mask = "00/00/0000";
            this.mskNgaySinh.Name = "mskNgaySinh";
            this.mskNgaySinh.Size = new System.Drawing.Size(120, 22);
            this.mskNgaySinh.TabIndex = 45;
            this.mskNgaySinh.ValidatingType = typeof(System.DateTime);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(320, 77);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 17);
            this.label9.TabIndex = 46;
            this.label9.Text = "Ngày sinh";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // txtFacebook
            // 
            this.txtFacebook.Location = new System.Drawing.Point(418, 122);
            this.txtFacebook.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtFacebook.Name = "txtFacebook";
            this.txtFacebook.Size = new System.Drawing.Size(120, 22);
            this.txtFacebook.TabIndex = 47;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(320, 122);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(70, 17);
            this.label10.TabIndex = 48;
            this.label10.Text = "Facebook";
            // 
            // cboXaPhuong
            // 
            this.cboXaPhuong.FormattingEnabled = true;
            this.cboXaPhuong.Location = new System.Drawing.Point(418, 163);
            this.cboXaPhuong.Name = "cboXaPhuong";
            this.cboXaPhuong.Size = new System.Drawing.Size(206, 24);
            this.cboXaPhuong.TabIndex = 49;
            this.cboXaPhuong.SelectedIndexChanged += new System.EventHandler(this.cboXaPhuong_SelectedIndexChanged);
            // 
            // cboQuanHuyen
            // 
            this.cboQuanHuyen.FormattingEnabled = true;
            this.cboQuanHuyen.Location = new System.Drawing.Point(418, 201);
            this.cboQuanHuyen.Name = "cboQuanHuyen";
            this.cboQuanHuyen.Size = new System.Drawing.Size(206, 24);
            this.cboQuanHuyen.TabIndex = 50;
            this.cboQuanHuyen.SelectedIndexChanged += new System.EventHandler(this.cboQuanHuyen_SelectedIndexChanged);
            // 
            // cboTinhThanh
            // 
            this.cboTinhThanh.FormattingEnabled = true;
            this.cboTinhThanh.Location = new System.Drawing.Point(418, 239);
            this.cboTinhThanh.Name = "cboTinhThanh";
            this.cboTinhThanh.Size = new System.Drawing.Size(206, 24);
            this.cboTinhThanh.TabIndex = 51;
            this.cboTinhThanh.SelectedIndexChanged += new System.EventHandler(this.cboTinhThanh_SelectedIndexChanged);
            // 
            // FrmDanhMucKhachHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(828, 487);
            this.Controls.Add(this.cboTinhThanh);
            this.Controls.Add(this.cboQuanHuyen);
            this.Controls.Add(this.cboXaPhuong);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtFacebook);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.mskNgaySinh);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.mskSDT);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.txtDiaChiChiTiet);
            this.Controls.Add(this.txtTenKhach);
            this.Controls.Add(this.txtMaKhach);
            this.Controls.Add(this.btndong);
            this.Controls.Add(this.btnboqua);
            this.Controls.Add(this.btnluu);
            this.Controls.Add(this.btnxoa);
            this.Controls.Add(this.btnsua);
            this.Controls.Add(this.btnthem);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmDanhMucKhachHang";
            this.Text = "FrmDanhMucKhachHang";
            this.Load += new System.EventHandler(this.FrmDanhMucKhachHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox mskSDT;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.TextBox txtDiaChiChiTiet;
        private System.Windows.Forms.TextBox txtTenKhach;
        private System.Windows.Forms.TextBox txtMaKhach;
        private System.Windows.Forms.Button btndong;
        private System.Windows.Forms.Button btnboqua;
        private System.Windows.Forms.Button btnluu;
        private System.Windows.Forms.Button btnxoa;
        private System.Windows.Forms.Button btnsua;
        private System.Windows.Forms.Button btnthem;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.MaskedTextBox mskNgaySinh;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtFacebook;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cboXaPhuong;
        private System.Windows.Forms.ComboBox cboQuanHuyen;
        private System.Windows.Forms.ComboBox cboTinhThanh;
    }
}