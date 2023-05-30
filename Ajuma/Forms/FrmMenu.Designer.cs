namespace Ajuma
{
    partial class FrmMenu
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuDanhmuc = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSanpham = new System.Windows.Forms.ToolStripMenuItem();
            this.mnutheloai = new System.Windows.Forms.ToolStripMenuItem();
            this.mnumausac = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuchatlieu = new System.Windows.Forms.ToolStripMenuItem();
            this.mnunuocsanxuat = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNhanvien = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuque = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuKhachhang = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNhacungcap = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHoadonban = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHoadonnhap = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTimkiem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFindSanpham = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFindHoadonnhap = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBaocao = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBCSanpham = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBCHoadonnhap = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBCDoanhthu = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBCHoadonban = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuThoat = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLogout = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.picAnh = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAnh)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDanhmuc,
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.mnuTimkiem,
            this.mnuBaocao,
            this.mnuThoat,
            this.mnuLogout});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1001, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip2";
            // 
            // mnuDanhmuc
            // 
            this.mnuDanhmuc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.mnuDanhmuc.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSanpham,
            this.mnutheloai,
            this.mnumausac,
            this.mnuchatlieu,
            this.mnunuocsanxuat});
            this.mnuDanhmuc.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuDanhmuc.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.mnuDanhmuc.Name = "mnuDanhmuc";
            this.mnuDanhmuc.Size = new System.Drawing.Size(144, 24);
            this.mnuDanhmuc.Text = "Quản lý cửa hàng";
            // 
            // mnuSanpham
            // 
            this.mnuSanpham.Name = "mnuSanpham";
            this.mnuSanpham.Size = new System.Drawing.Size(224, 26);
            this.mnuSanpham.Text = "Sản phẩm";
            this.mnuSanpham.Click += new System.EventHandler(this.mnuSanpham_Click);
            // 
            // mnutheloai
            // 
            this.mnutheloai.Name = "mnutheloai";
            this.mnutheloai.Size = new System.Drawing.Size(224, 26);
            this.mnutheloai.Text = "Thể loại";
            this.mnutheloai.Click += new System.EventHandler(this.mnutheloai_Click);
            // 
            // mnumausac
            // 
            this.mnumausac.Name = "mnumausac";
            this.mnumausac.Size = new System.Drawing.Size(224, 26);
            this.mnumausac.Text = "Nghệ sĩ";
            this.mnumausac.Click += new System.EventHandler(this.mnumausac_Click);
            // 
            // mnuchatlieu
            // 
            this.mnuchatlieu.DoubleClickEnabled = true;
            this.mnuchatlieu.Name = "mnuchatlieu";
            this.mnuchatlieu.Size = new System.Drawing.Size(224, 26);
            this.mnuchatlieu.Text = "Chất liệu";
            this.mnuchatlieu.Click += new System.EventHandler(this.mnuchatlieu_Click);
            // 
            // mnunuocsanxuat
            // 
            this.mnunuocsanxuat.Name = "mnunuocsanxuat";
            this.mnunuocsanxuat.Size = new System.Drawing.Size(224, 26);
            this.mnunuocsanxuat.Text = "Album";
            this.mnunuocsanxuat.Click += new System.EventHandler(this.mnunuocsanxuat_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.BackColor = System.Drawing.SystemColors.Info;
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuNhanvien,
            this.mnuKhachhang,
            this.mnuNhacungcap});
            this.toolStripMenuItem1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(161, 24);
            this.toolStripMenuItem1.Text = "Quản lý người dùng";
            // 
            // mnuNhanvien
            // 
            this.mnuNhanvien.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuque});
            this.mnuNhanvien.Name = "mnuNhanvien";
            this.mnuNhanvien.Size = new System.Drawing.Size(187, 26);
            this.mnuNhanvien.Text = "Nhân viên";
            this.mnuNhanvien.Click += new System.EventHandler(this.mnuNhanvien_Click);
            // 
            // mnuque
            // 
            this.mnuque.Name = "mnuque";
            this.mnuque.Size = new System.Drawing.Size(148, 26);
            this.mnuque.Text = "Chức vụ";
            this.mnuque.Click += new System.EventHandler(this.mnuque_Click);
            // 
            // mnuKhachhang
            // 
            this.mnuKhachhang.Name = "mnuKhachhang";
            this.mnuKhachhang.Size = new System.Drawing.Size(187, 26);
            this.mnuKhachhang.Text = "Khách hàng";
            this.mnuKhachhang.Click += new System.EventHandler(this.mnuKhachhang_Click);
            // 
            // mnuNhacungcap
            // 
            this.mnuNhacungcap.Name = "mnuNhacungcap";
            this.mnuNhacungcap.Size = new System.Drawing.Size(187, 26);
            this.mnuNhacungcap.Text = "Nhà cung cấp";
            this.mnuNhacungcap.Click += new System.EventHandler(this.mnuNhacungcap_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.BackColor = System.Drawing.Color.Lime;
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuHoadonban,
            this.mnuHoadonnhap});
            this.toolStripMenuItem2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(137, 24);
            this.toolStripMenuItem2.Text = "Quản lý hoá đơn";
            // 
            // mnuHoadonban
            // 
            this.mnuHoadonban.Name = "mnuHoadonban";
            this.mnuHoadonban.Size = new System.Drawing.Size(190, 26);
            this.mnuHoadonban.Text = "Hoá đơn bán";
            this.mnuHoadonban.Click += new System.EventHandler(this.mnuHoadonban_Click);
            // 
            // mnuHoadonnhap
            // 
            this.mnuHoadonnhap.Name = "mnuHoadonnhap";
            this.mnuHoadonnhap.Size = new System.Drawing.Size(190, 26);
            this.mnuHoadonnhap.Text = "Hoá đơn nhập";
            this.mnuHoadonnhap.Click += new System.EventHandler(this.mnuHoadonnhap_Click);
            // 
            // mnuTimkiem
            // 
            this.mnuTimkiem.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.mnuTimkiem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFindSanpham,
            this.mnuFindHoadonnhap});
            this.mnuTimkiem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuTimkiem.Name = "mnuTimkiem";
            this.mnuTimkiem.Size = new System.Drawing.Size(88, 24);
            this.mnuTimkiem.Text = "Tìm kiếm";
            // 
            // mnuFindSanpham
            // 
            this.mnuFindSanpham.Name = "mnuFindSanpham";
            this.mnuFindSanpham.Size = new System.Drawing.Size(190, 26);
            this.mnuFindSanpham.Text = "Sản phẩm";
            this.mnuFindSanpham.Click += new System.EventHandler(this.mnuFindSanpham_Click);
            // 
            // mnuFindHoadonnhap
            // 
            this.mnuFindHoadonnhap.Name = "mnuFindHoadonnhap";
            this.mnuFindHoadonnhap.Size = new System.Drawing.Size(190, 26);
            this.mnuFindHoadonnhap.Text = "Hoá đơn nhập";
            this.mnuFindHoadonnhap.Click += new System.EventHandler(this.mnuFindHoadonnhap_Click);
            // 
            // mnuBaocao
            // 
            this.mnuBaocao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.mnuBaocao.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuBCSanpham,
            this.mnuBCHoadonnhap,
            this.mnuBCDoanhthu,
            this.mnuBCHoadonban});
            this.mnuBaocao.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuBaocao.Name = "mnuBaocao";
            this.mnuBaocao.Size = new System.Drawing.Size(78, 24);
            this.mnuBaocao.Text = "Báo cáo";
            // 
            // mnuBCSanpham
            // 
            this.mnuBCSanpham.Name = "mnuBCSanpham";
            this.mnuBCSanpham.Size = new System.Drawing.Size(190, 26);
            this.mnuBCSanpham.Text = "Sản phẩm";
            this.mnuBCSanpham.Click += new System.EventHandler(this.mnuBCSanpham_Click);
            // 
            // mnuBCHoadonnhap
            // 
            this.mnuBCHoadonnhap.Name = "mnuBCHoadonnhap";
            this.mnuBCHoadonnhap.Size = new System.Drawing.Size(190, 26);
            this.mnuBCHoadonnhap.Text = "Hoá đơn nhập";
            this.mnuBCHoadonnhap.Click += new System.EventHandler(this.mnuBCHoadonnhap_Click);
            // 
            // mnuBCDoanhthu
            // 
            this.mnuBCDoanhthu.Name = "mnuBCDoanhthu";
            this.mnuBCDoanhthu.Size = new System.Drawing.Size(190, 26);
            this.mnuBCDoanhthu.Text = "Doanh thu";
            this.mnuBCDoanhthu.Click += new System.EventHandler(this.mnuBCDoanhthu_Click);
            // 
            // mnuBCHoadonban
            // 
            this.mnuBCHoadonban.Name = "mnuBCHoadonban";
            this.mnuBCHoadonban.Size = new System.Drawing.Size(190, 26);
            this.mnuBCHoadonban.Text = "Hoá đơn bán";
            this.mnuBCHoadonban.Click += new System.EventHandler(this.mnuBCHoadonban_Click);
            // 
            // mnuThoat
            // 
            this.mnuThoat.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuThoat.Name = "mnuThoat";
            this.mnuThoat.Size = new System.Drawing.Size(64, 24);
            this.mnuThoat.Text = "Thoát";
            this.mnuThoat.Click += new System.EventHandler(this.mnuThoat_Click);
            // 
            // mnuLogout
            // 
            this.mnuLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.mnuLogout.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuLogout.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.mnuLogout.Name = "mnuLogout";
            this.mnuLogout.Size = new System.Drawing.Size(97, 24);
            this.mnuLogout.Text = "Đăng Xuất";
            this.mnuLogout.Click += new System.EventHandler(this.mnuLogout_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.picAnh);
            this.panel1.Location = new System.Drawing.Point(0, 29);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1001, 500);
            this.panel1.TabIndex = 2;
            // 
            // picAnh
            // 
            this.picAnh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picAnh.Image = global::Ajuma.Properties.Resources.Thêm_tiêu_đề_phụ__1_;
            this.picAnh.Location = new System.Drawing.Point(0, 0);
            this.picAnh.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picAnh.Name = "picAnh";
            this.picAnh.Size = new System.Drawing.Size(1001, 500);
            this.picAnh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picAnh.TabIndex = 0;
            this.picAnh.TabStop = false;
            this.picAnh.Click += new System.EventHandler(this.picAnh_Click);
            // 
            // FrmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1001, 529);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmMenu";
            this.Text = "Ajuma";
            this.Load += new System.EventHandler(this.FrmMenu_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picAnh)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuDanhmuc;
        private System.Windows.Forms.ToolStripMenuItem mnuSanpham;
        private System.Windows.Forms.ToolStripMenuItem mnutheloai;
        private System.Windows.Forms.ToolStripMenuItem mnumausac;
        private System.Windows.Forms.ToolStripMenuItem mnuchatlieu;
        private System.Windows.Forms.ToolStripMenuItem mnunuocsanxuat;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuNhanvien;
        private System.Windows.Forms.ToolStripMenuItem mnuque;
        private System.Windows.Forms.ToolStripMenuItem mnuKhachhang;
        private System.Windows.Forms.ToolStripMenuItem mnuNhacungcap;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem mnuHoadonban;
        private System.Windows.Forms.ToolStripMenuItem mnuHoadonnhap;
        private System.Windows.Forms.ToolStripMenuItem mnuTimkiem;
        private System.Windows.Forms.ToolStripMenuItem mnuFindSanpham;
        private System.Windows.Forms.ToolStripMenuItem mnuFindHoadonnhap;
        private System.Windows.Forms.ToolStripMenuItem mnuBaocao;
        private System.Windows.Forms.ToolStripMenuItem mnuBCSanpham;
        private System.Windows.Forms.ToolStripMenuItem mnuBCHoadonnhap;
        private System.Windows.Forms.ToolStripMenuItem mnuBCDoanhthu;
        private System.Windows.Forms.ToolStripMenuItem mnuBCHoadonban;
        private System.Windows.Forms.ToolStripMenuItem mnuThoat;
        private System.Windows.Forms.ToolStripMenuItem mnuLogout;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox picAnh;
    }
}

