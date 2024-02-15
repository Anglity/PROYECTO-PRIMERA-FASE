namespace proyecto
{
    partial class Analisis_venta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Analisis_venta));
            this.panel2 = new System.Windows.Forms.Panel();
            this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            this.pieChart1 = new LiveCharts.Wpf.PieChart();
            this.label7 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.obtenerProduccionMensualBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboBoxMeses = new System.Windows.Forms.ComboBox();
            this.comboBoxAnio = new System.Windows.Forms.ComboBox();
            this.lineChart = new System.Windows.Forms.Integration.ElementHost();
            this.cartesianChart1 = new LiveCharts.Wpf.CartesianChart();
            this.label1 = new System.Windows.Forms.Label();
            this.elementHost3 = new System.Windows.Forms.Integration.ElementHost();
            this.cartesianChart2 = new LiveCharts.Wpf.CartesianChart();
            this.checkBoxCompararMesAnterior = new System.Windows.Forms.CheckBox();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.obtenerProduccionMensualBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.panel2.Controls.Add(this.elementHost1);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Location = new System.Drawing.Point(12, 45);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(505, 401);
            this.panel2.TabIndex = 2;
            // 
            // elementHost1
            // 
            this.elementHost1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.elementHost1.Location = new System.Drawing.Point(47, 51);
            this.elementHost1.Name = "elementHost1";
            this.elementHost1.Size = new System.Drawing.Size(421, 316);
            this.elementHost1.TabIndex = 76;
            this.elementHost1.Text = "elementHost1";
            this.elementHost1.Child = this.pieChart1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(85, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(367, 29);
            this.label7.TabIndex = 1;
            this.label7.Text = "Los 5 productos más vendidos";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(69, 28);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(0, 36);
            this.label14.TabIndex = 3;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.panel4.Controls.Add(this.label9);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1604, 17);
            this.panel4.TabIndex = 75;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(44)))), ((int)(((byte)(64)))));
            this.label9.Location = new System.Drawing.Point(18, 14);
            this.label9.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(546, 39);
            this.label9.TabIndex = 62;
            this.label9.Text = "Análisis de ventas";
            // 
            // obtenerProduccionMensualBindingSource
            // 
            this.obtenerProduccionMensualBindingSource.DataMember = "ObtenerProduccionMensual";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.panel1.Controls.Add(this.checkBoxCompararMesAnterior);
            this.panel1.Controls.Add(this.comboBoxMeses);
            this.panel1.Controls.Add(this.comboBoxAnio);
            this.panel1.Controls.Add(this.lineChart);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(557, 45);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(749, 619);
            this.panel1.TabIndex = 76;
            // 
            // comboBoxMeses
            // 
            this.comboBoxMeses.FormattingEnabled = true;
            this.comboBoxMeses.Location = new System.Drawing.Point(75, 63);
            this.comboBoxMeses.Name = "comboBoxMeses";
            this.comboBoxMeses.Size = new System.Drawing.Size(121, 28);
            this.comboBoxMeses.TabIndex = 6;
            // 
            // comboBoxAnio
            // 
            this.comboBoxAnio.FormattingEnabled = true;
            this.comboBoxAnio.Location = new System.Drawing.Point(386, 63);
            this.comboBoxAnio.Name = "comboBoxAnio";
            this.comboBoxAnio.Size = new System.Drawing.Size(121, 28);
            this.comboBoxAnio.TabIndex = 5;
            this.comboBoxAnio.SelectedIndexChanged += new System.EventHandler(this.anioSeleccionado_SelectedIndexChanged);
            // 
            // lineChart
            // 
            this.lineChart.Location = new System.Drawing.Point(3, 97);
            this.lineChart.Name = "lineChart";
            this.lineChart.Size = new System.Drawing.Size(743, 519);
            this.lineChart.TabIndex = 3;
            this.lineChart.Text = "elementHost2";
            this.lineChart.Child = this.cartesianChart1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(70, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(367, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Los 5 productos más vendidos";
            // 
            // elementHost3
            // 
            this.elementHost3.Location = new System.Drawing.Point(0, 0);
            this.elementHost3.Name = "elementHost3";
            this.elementHost3.Size = new System.Drawing.Size(200, 100);
            this.elementHost3.TabIndex = 0;
            this.elementHost3.Text = "elementHost3";
            this.elementHost3.Child = this.cartesianChart2;
            // 
            // checkBoxCompararMesAnterior
            // 
            this.checkBoxCompararMesAnterior.AutoSize = true;
            this.checkBoxCompararMesAnterior.Location = new System.Drawing.Point(232, 65);
            this.checkBoxCompararMesAnterior.Name = "checkBoxCompararMesAnterior";
            this.checkBoxCompararMesAnterior.Size = new System.Drawing.Size(122, 24);
            this.checkBoxCompararMesAnterior.TabIndex = 7;
            this.checkBoxCompararMesAnterior.Text = "checkBox1";
            this.checkBoxCompararMesAnterior.UseVisualStyleBackColor = true;
            // 
            // Analisis_venta
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1604, 881);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Analisis_venta";
            this.Text = "Analisis_venta";
            this.Load += new System.EventHandler(this.Analisis_venta_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.obtenerProduccionMensualBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Integration.ElementHost elementHost1;
        private System.Windows.Forms.BindingSource obtenerProduccionMensualBindingSource;
        private LiveCharts.Wpf.PieChart pieChart1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Integration.ElementHost lineChart;
        private System.Windows.Forms.Integration.ElementHost elementHost3;
        private LiveCharts.Wpf.CartesianChart cartesianChart2;
        private System.Windows.Forms.ComboBox comboBoxAnio;
        private System.Windows.Forms.ComboBox comboBoxMeses;
        private System.Windows.Forms.CheckBox checkBoxCompararMesAnterior;
        private LiveCharts.Wpf.CartesianChart cartesianChart1;
    }
}