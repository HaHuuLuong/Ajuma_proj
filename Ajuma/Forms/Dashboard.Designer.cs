namespace Ajuma.Forms
{
    partial class Dashboard
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
            this.ajuma_MỚI_DataSet = new Ajuma.Ajuma_MỚI_DataSet();
            this.sanPhamBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sanPhamTableAdapter = new Ajuma.Ajuma_MỚI_DataSetTableAdapters.SanPhamTableAdapter();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.ajuma_MỚI_DataSet2 = new Ajuma.Ajuma_MỚI_DataSet2();
            this.ngheSiBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ngheSiTableAdapter = new Ajuma.Ajuma_MỚI_DataSet2TableAdapters.NgheSiTableAdapter();
            this.ajuma_MỚI_DataSet3 = new Ajuma.Ajuma_MỚI_DataSet3();
            this.donDatHangBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.donDatHangTableAdapter = new Ajuma.Ajuma_MỚI_DataSet3TableAdapters.DonDatHangTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ajuma_MỚI_DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sanPhamBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ajuma_MỚI_DataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ngheSiBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ajuma_MỚI_DataSet3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.donDatHangBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.DataSource = this.sanPhamBindingSource;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(65, 21);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;
            series1.Legend = "Legend1";
            series1.Name = "Sản phẩm";
            series1.XValueMember = "tensanpham";
            series1.YValueMembers = "soluongkho";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(541, 406);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title1.ForeColor = System.Drawing.Color.RoyalBlue;
            title1.Name = "Title1";
            title1.ShadowColor = System.Drawing.Color.Blue;
            title1.Text = "Thống kê số lượng kho của các sản phẩm";
            this.chart1.Titles.Add(title1);
            this.chart1.Click += new System.EventHandler(this.chart1_Click);
            // 
            // ajuma_MỚI_DataSet
            // 
            this.ajuma_MỚI_DataSet.DataSetName = "Ajuma_MỚI_DataSet";
            this.ajuma_MỚI_DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sanPhamBindingSource
            // 
            this.sanPhamBindingSource.DataMember = "SanPham";
            this.sanPhamBindingSource.DataSource = this.ajuma_MỚI_DataSet;
            // 
            // sanPhamTableAdapter
            // 
            this.sanPhamTableAdapter.ClearBeforeFill = true;
            // 
            // chart2
            // 
            chartArea2.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea2);
            this.chart2.DataSource = this.donDatHangBindingSource;
            legend2.Name = "Legend1";
            this.chart2.Legends.Add(legend2);
            this.chart2.Location = new System.Drawing.Point(612, 21);
            this.chart2.Name = "chart2";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Range;
            series2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            series2.LabelBackColor = System.Drawing.Color.Lime;
            series2.Legend = "Legend1";
            series2.Name = "Đơn đặt hàng";
            series2.XValueMember = "makhach";
            series2.YValueMembers = "tongtien";
            series2.YValuesPerPoint = 4;
            this.chart2.Series.Add(series2);
            this.chart2.Size = new System.Drawing.Size(496, 406);
            this.chart2.TabIndex = 1;
            this.chart2.Text = "chart2";
            title2.BackColor = System.Drawing.Color.White;
            title2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title2.ForeColor = System.Drawing.Color.Tomato;
            title2.Name = "Title1";
            title2.Text = "Thống kê đơn đặt hàng";
            title2.TextOrientation = System.Windows.Forms.DataVisualization.Charting.TextOrientation.Horizontal;
            this.chart2.Titles.Add(title2);
            // 
            // ajuma_MỚI_DataSet2
            // 
            this.ajuma_MỚI_DataSet2.DataSetName = "Ajuma_MỚI_DataSet2";
            this.ajuma_MỚI_DataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ngheSiBindingSource
            // 
            this.ngheSiBindingSource.DataMember = "NgheSi";
            this.ngheSiBindingSource.DataSource = this.ajuma_MỚI_DataSet2;
            // 
            // ngheSiTableAdapter
            // 
            this.ngheSiTableAdapter.ClearBeforeFill = true;
            // 
            // ajuma_MỚI_DataSet3
            // 
            this.ajuma_MỚI_DataSet3.DataSetName = "Ajuma_MỚI_DataSet3";
            this.ajuma_MỚI_DataSet3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // donDatHangBindingSource
            // 
            this.donDatHangBindingSource.DataMember = "DonDatHang";
            this.donDatHangBindingSource.DataSource = this.ajuma_MỚI_DataSet3;
            // 
            // donDatHangTableAdapter
            // 
            this.donDatHangTableAdapter.ClearBeforeFill = true;
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1111, 491);
            this.Controls.Add(this.chart2);
            this.Controls.Add(this.chart1);
            this.Name = "Dashboard";
            this.Text = "Dashboard";
            this.Load += new System.EventHandler(this.Dashboard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ajuma_MỚI_DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sanPhamBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ajuma_MỚI_DataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ngheSiBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ajuma_MỚI_DataSet3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.donDatHangBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private Ajuma_MỚI_DataSet ajuma_MỚI_DataSet;
        private System.Windows.Forms.BindingSource sanPhamBindingSource;
        private Ajuma_MỚI_DataSetTableAdapters.SanPhamTableAdapter sanPhamTableAdapter;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private Ajuma_MỚI_DataSet2 ajuma_MỚI_DataSet2;
        private System.Windows.Forms.BindingSource ngheSiBindingSource;
        private Ajuma_MỚI_DataSet2TableAdapters.NgheSiTableAdapter ngheSiTableAdapter;
        private Ajuma_MỚI_DataSet3 ajuma_MỚI_DataSet3;
        private System.Windows.Forms.BindingSource donDatHangBindingSource;
        private Ajuma_MỚI_DataSet3TableAdapters.DonDatHangTableAdapter donDatHangTableAdapter;
    }
}