namespace Ajuma.Forms
{
    partial class FrmDashboard
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.sanPhamBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ajuma_MỚI_DataSet1 = new Ajuma.Ajuma_MỚI_DataSet1();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.donDatHangBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ajuma_MỚI_DataSet2 = new Ajuma.Ajuma_MỚI_DataSet2();
            this.sanPhamTableAdapter = new Ajuma.Ajuma_MỚI_DataSet1TableAdapters.SanPhamTableAdapter();
            this.donDatHangTableAdapter = new Ajuma.Ajuma_MỚI_DataSet2TableAdapters.DonDatHangTableAdapter();
            this.ajuma_MỚI_DataSet3 = new Ajuma.Ajuma_MỚI_DataSet3();
            this.khachHangBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.khachHangTableAdapter = new Ajuma.Ajuma_MỚI_DataSet3TableAdapters.KhachHangTableAdapter();
            this.ajuma_MỚI_DataSet4 = new Ajuma.Ajuma_MỚI_DataSet4();
            this.donDatHangBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.donDatHangTableAdapter1 = new Ajuma.Ajuma_MỚI_DataSet4TableAdapters.DonDatHangTableAdapter();
            this.ajuma_MỚI_DataSet5 = new Ajuma.Ajuma_MỚI_DataSet5();
            this.sanPhamBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.sanPhamTableAdapter1 = new Ajuma.Ajuma_MỚI_DataSet5TableAdapters.SanPhamTableAdapter();
            this.ajuma_MỚI_Vux_DataSet = new Ajuma.Ajuma_MỚI_Vux_DataSet();
            this.donDatHangBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.donDatHangTableAdapter2 = new Ajuma.Ajuma_MỚI_Vux_DataSetTableAdapters.DonDatHangTableAdapter();
            this.ajuma_MỚI_Vux_DataSet1 = new Ajuma.Ajuma_MỚI_Vux_DataSet1();
            this.sanPhamBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.sanPhamTableAdapter2 = new Ajuma.Ajuma_MỚI_Vux_DataSet1TableAdapters.SanPhamTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sanPhamBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ajuma_MỚI_DataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.donDatHangBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ajuma_MỚI_DataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ajuma_MỚI_DataSet3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.khachHangBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ajuma_MỚI_DataSet4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.donDatHangBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ajuma_MỚI_DataSet5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sanPhamBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ajuma_MỚI_Vux_DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.donDatHangBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ajuma_MỚI_Vux_DataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sanPhamBindingSource2)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.DataSource = this.sanPhamBindingSource2;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(12, 30);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;
            series1.Legend = "Legend1";
            series1.Name = "Tên sản phẩm";
            series1.XValueMember = "tensanpham";
            series1.YValueMembers = "soluongkho";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(489, 492);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            title1.BackColor = System.Drawing.Color.Transparent;
            title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title1.ForeColor = System.Drawing.Color.Blue;
            title1.Name = "Title1";
            title1.Text = "Thống kê số lượng sản phẩm trong kho";
            this.chart1.Titles.Add(title1);
            // 
            // sanPhamBindingSource
            // 
            this.sanPhamBindingSource.DataMember = "SanPham";
            this.sanPhamBindingSource.DataSource = this.ajuma_MỚI_DataSet1;
            // 
            // ajuma_MỚI_DataSet1
            // 
            this.ajuma_MỚI_DataSet1.DataSetName = "Ajuma_MỚI_DataSet1";
            this.ajuma_MỚI_DataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // chart2
            // 
            chartArea2.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea2);
            this.chart2.DataSource = this.donDatHangBindingSource2;
            legend2.Name = "Legend1";
            this.chart2.Legends.Add(legend2);
            this.chart2.Location = new System.Drawing.Point(545, 30);
            this.chart2.Name = "chart2";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.SplineArea;
            series2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            series2.LabelForeColor = System.Drawing.Color.Tomato;
            series2.Legend = "Legend1";
            series2.Name = "Khách hàng";
            series2.XValueMember = "makhach";
            series2.YValueMembers = "tongtien";
            this.chart2.Series.Add(series2);
            this.chart2.Size = new System.Drawing.Size(462, 481);
            this.chart2.TabIndex = 1;
            this.chart2.Text = "chart2";
            title2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title2.ForeColor = System.Drawing.Color.OrangeRed;
            title2.Name = "Title1";
            title2.Text = "Thống kê tổng tiền khách hàng mua";
            this.chart2.Titles.Add(title2);
            // 
            // donDatHangBindingSource
            // 
            this.donDatHangBindingSource.DataMember = "DonDatHang";
            this.donDatHangBindingSource.DataSource = this.ajuma_MỚI_DataSet2;
            // 
            // ajuma_MỚI_DataSet2
            // 
            this.ajuma_MỚI_DataSet2.DataSetName = "Ajuma_MỚI_DataSet2";
            this.ajuma_MỚI_DataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sanPhamTableAdapter
            // 
            this.sanPhamTableAdapter.ClearBeforeFill = true;
            // 
            // donDatHangTableAdapter
            // 
            this.donDatHangTableAdapter.ClearBeforeFill = true;
            // 
            // ajuma_MỚI_DataSet3
            // 
            this.ajuma_MỚI_DataSet3.DataSetName = "Ajuma_MỚI_DataSet3";
            this.ajuma_MỚI_DataSet3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // khachHangBindingSource
            // 
            this.khachHangBindingSource.DataMember = "KhachHang";
            this.khachHangBindingSource.DataSource = this.ajuma_MỚI_DataSet3;
            // 
            // khachHangTableAdapter
            // 
            this.khachHangTableAdapter.ClearBeforeFill = true;
            // 
            // ajuma_MỚI_DataSet4
            // 
            this.ajuma_MỚI_DataSet4.DataSetName = "Ajuma_MỚI_DataSet4";
            this.ajuma_MỚI_DataSet4.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // donDatHangBindingSource1
            // 
            this.donDatHangBindingSource1.DataMember = "DonDatHang";
            this.donDatHangBindingSource1.DataSource = this.ajuma_MỚI_DataSet4;
            // 
            // donDatHangTableAdapter1
            // 
            this.donDatHangTableAdapter1.ClearBeforeFill = true;
            // 
            // ajuma_MỚI_DataSet5
            // 
            this.ajuma_MỚI_DataSet5.DataSetName = "Ajuma_MỚI_DataSet5";
            this.ajuma_MỚI_DataSet5.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sanPhamBindingSource1
            // 
            this.sanPhamBindingSource1.DataMember = "SanPham";
            this.sanPhamBindingSource1.DataSource = this.ajuma_MỚI_DataSet5;
            // 
            // sanPhamTableAdapter1
            // 
            this.sanPhamTableAdapter1.ClearBeforeFill = true;
            // 
            // ajuma_MỚI_Vux_DataSet
            // 
            this.ajuma_MỚI_Vux_DataSet.DataSetName = "Ajuma_MỚI_Vux_DataSet";
            this.ajuma_MỚI_Vux_DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // donDatHangBindingSource2
            // 
            this.donDatHangBindingSource2.DataMember = "DonDatHang";
            this.donDatHangBindingSource2.DataSource = this.ajuma_MỚI_Vux_DataSet;
            // 
            // donDatHangTableAdapter2
            // 
            this.donDatHangTableAdapter2.ClearBeforeFill = true;
            // 
            // ajuma_MỚI_Vux_DataSet1
            // 
            this.ajuma_MỚI_Vux_DataSet1.DataSetName = "Ajuma_MỚI_Vux_DataSet1";
            this.ajuma_MỚI_Vux_DataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sanPhamBindingSource2
            // 
            this.sanPhamBindingSource2.DataMember = "SanPham";
            this.sanPhamBindingSource2.DataSource = this.ajuma_MỚI_Vux_DataSet1;
            // 
            // sanPhamTableAdapter2
            // 
            this.sanPhamTableAdapter2.ClearBeforeFill = true;
            // 
            // FrmDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1019, 589);
            this.Controls.Add(this.chart2);
            this.Controls.Add(this.chart1);
            this.Name = "FrmDashboard";
            this.Text = "FrmDashboard";
            this.Load += new System.EventHandler(this.FrmDashboard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sanPhamBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ajuma_MỚI_DataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.donDatHangBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ajuma_MỚI_DataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ajuma_MỚI_DataSet3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.khachHangBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ajuma_MỚI_DataSet4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.donDatHangBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ajuma_MỚI_DataSet5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sanPhamBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ajuma_MỚI_Vux_DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.donDatHangBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ajuma_MỚI_Vux_DataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sanPhamBindingSource2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private Ajuma_MỚI_DataSet1 ajuma_MỚI_DataSet1;
        private System.Windows.Forms.BindingSource sanPhamBindingSource;
        private Ajuma_MỚI_DataSet1TableAdapters.SanPhamTableAdapter sanPhamTableAdapter;
        private Ajuma_MỚI_DataSet2 ajuma_MỚI_DataSet2;
        private System.Windows.Forms.BindingSource donDatHangBindingSource;
        private Ajuma_MỚI_DataSet2TableAdapters.DonDatHangTableAdapter donDatHangTableAdapter;
        private Ajuma_MỚI_DataSet3 ajuma_MỚI_DataSet3;
        private System.Windows.Forms.BindingSource khachHangBindingSource;
        private Ajuma_MỚI_DataSet3TableAdapters.KhachHangTableAdapter khachHangTableAdapter;
        private Ajuma_MỚI_DataSet4 ajuma_MỚI_DataSet4;
        private System.Windows.Forms.BindingSource donDatHangBindingSource1;
        private Ajuma_MỚI_DataSet4TableAdapters.DonDatHangTableAdapter donDatHangTableAdapter1;
        private Ajuma_MỚI_DataSet5 ajuma_MỚI_DataSet5;
        private System.Windows.Forms.BindingSource sanPhamBindingSource1;
        private Ajuma_MỚI_DataSet5TableAdapters.SanPhamTableAdapter sanPhamTableAdapter1;
        private Ajuma_MỚI_Vux_DataSet ajuma_MỚI_Vux_DataSet;
        private System.Windows.Forms.BindingSource donDatHangBindingSource2;
        private Ajuma_MỚI_Vux_DataSetTableAdapters.DonDatHangTableAdapter donDatHangTableAdapter2;
        private Ajuma_MỚI_Vux_DataSet1 ajuma_MỚI_Vux_DataSet1;
        private System.Windows.Forms.BindingSource sanPhamBindingSource2;
        private Ajuma_MỚI_Vux_DataSet1TableAdapters.SanPhamTableAdapter sanPhamTableAdapter2;
    }
}