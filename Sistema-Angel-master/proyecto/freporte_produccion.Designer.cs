namespace proyecto
{
    partial class freporte_produccion
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.excel = new FontAwesome.Sharp.IconButton();
            this.dgdata = new System.Windows.Forms.DataGridView();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Stock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CantidadCheddar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CantidadDanes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnidadMedidaGenerica = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CantidadTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.txtfechafin = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnbuscarresultado = new FontAwesome.Sharp.IconButton();
            this.txtfechainicio = new System.Windows.Forms.DateTimePicker();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label19 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgdata)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // excel
            // 
            this.excel.AutoSize = true;
            this.excel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(191)))), ((int)(((byte)(138)))));
            this.excel.FlatAppearance.BorderSize = 0;
            this.excel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.excel.Font = new System.Drawing.Font("Open Sans Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.excel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.excel.IconChar = FontAwesome.Sharp.IconChar.Download;
            this.excel.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(44)))), ((int)(((byte)(64)))));
            this.excel.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.excel.IconSize = 35;
            this.excel.Location = new System.Drawing.Point(62, 531);
            this.excel.Margin = new System.Windows.Forms.Padding(1);
            this.excel.Name = "excel";
            this.excel.Size = new System.Drawing.Size(184, 41);
            this.excel.TabIndex = 111;
            this.excel.Text = "Descargar EXCEL";
            this.excel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.excel.UseVisualStyleBackColor = false;
            this.excel.Click += new System.EventHandler(this.excel_Click);
            // 
            // dgdata
            // 
            this.dgdata.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Open Sans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.dgdata.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgdata.BackgroundColor = System.Drawing.Color.White;
            this.dgdata.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Open Sans Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgdata.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgdata.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgdata.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nombre,
            this.Stock,
            this.CantidadCheddar,
            this.CantidadDanes,
            this.UnidadMedidaGenerica,
            this.CantidadTotal});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Open Sans", 9.75F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgdata.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgdata.Location = new System.Drawing.Point(14, 179);
            this.dgdata.MultiSelect = false;
            this.dgdata.Name = "dgdata";
            this.dgdata.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Open Sans", 9.75F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgdata.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgdata.RowHeadersWidth = 102;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Open Sans", 9.75F);
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            this.dgdata.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgdata.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Open Sans", 9.75F);
            this.dgdata.RowTemplate.Height = 28;
            this.dgdata.Size = new System.Drawing.Size(1159, 335);
            this.dgdata.TabIndex = 106;
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.MinimumWidth = 6;
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.Nombre.Width = 125;
            // 
            // Stock
            // 
            this.Stock.HeaderText = "Stock";
            this.Stock.MinimumWidth = 6;
            this.Stock.Name = "Stock";
            this.Stock.ReadOnly = true;
            this.Stock.Width = 125;
            // 
            // CantidadCheddar
            // 
            this.CantidadCheddar.HeaderText = "CantidadCheddar";
            this.CantidadCheddar.MinimumWidth = 6;
            this.CantidadCheddar.Name = "CantidadCheddar";
            this.CantidadCheddar.ReadOnly = true;
            this.CantidadCheddar.Width = 200;
            // 
            // CantidadDanes
            // 
            this.CantidadDanes.HeaderText = "CantidadDanes";
            this.CantidadDanes.MinimumWidth = 6;
            this.CantidadDanes.Name = "CantidadDanes";
            this.CantidadDanes.ReadOnly = true;
            this.CantidadDanes.Width = 200;
            // 
            // UnidadMedidaGenerica
            // 
            this.UnidadMedidaGenerica.HeaderText = "UnidadMedidaGenerica";
            this.UnidadMedidaGenerica.MinimumWidth = 6;
            this.UnidadMedidaGenerica.Name = "UnidadMedidaGenerica";
            this.UnidadMedidaGenerica.ReadOnly = true;
            this.UnidadMedidaGenerica.Width = 250;
            // 
            // CantidadTotal
            // 
            this.CantidadTotal.HeaderText = "CantidadTotal";
            this.CantidadTotal.MinimumWidth = 6;
            this.CantidadTotal.Name = "CantidadTotal";
            this.CantidadTotal.ReadOnly = true;
            this.CantidadTotal.Width = 150;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Open Sans Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(44)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(221, 49);
            this.label2.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 25);
            this.label2.TabIndex = 100;
            this.label2.Text = "Fecha Fin";
            // 
            // txtfechafin
            // 
            this.txtfechafin.CustomFormat = "dd/mm/yyyy";
            this.txtfechafin.Font = new System.Drawing.Font("Open Sans Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtfechafin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtfechafin.Location = new System.Drawing.Point(317, 49);
            this.txtfechafin.Margin = new System.Windows.Forms.Padding(2);
            this.txtfechafin.Name = "txtfechafin";
            this.txtfechafin.Size = new System.Drawing.Size(91, 26);
            this.txtfechafin.TabIndex = 99;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.White;
            this.label12.Font = new System.Drawing.Font("Open Sans Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(44)))), ((int)(((byte)(64)))));
            this.label12.Location = new System.Drawing.Point(3, 49);
            this.label12.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(113, 25);
            this.label12.TabIndex = 67;
            this.label12.Text = "Fecha inicio";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btnbuscarresultado);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtfechafin);
            this.panel1.Controls.Add(this.txtfechainicio);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Location = new System.Drawing.Point(33, 76);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(666, 90);
            this.panel1.TabIndex = 105;
            // 
            // btnbuscarresultado
            // 
            this.btnbuscarresultado.AutoSize = true;
            this.btnbuscarresultado.BackColor = System.Drawing.Color.White;
            this.btnbuscarresultado.FlatAppearance.BorderSize = 0;
            this.btnbuscarresultado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnbuscarresultado.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
            this.btnbuscarresultado.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(44)))), ((int)(((byte)(64)))));
            this.btnbuscarresultado.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnbuscarresultado.IconSize = 35;
            this.btnbuscarresultado.Location = new System.Drawing.Point(492, 33);
            this.btnbuscarresultado.Margin = new System.Windows.Forms.Padding(1);
            this.btnbuscarresultado.Name = "btnbuscarresultado";
            this.btnbuscarresultado.Size = new System.Drawing.Size(41, 41);
            this.btnbuscarresultado.TabIndex = 102;
            this.btnbuscarresultado.UseVisualStyleBackColor = false;
            this.btnbuscarresultado.Click += new System.EventHandler(this.btnbuscarresultado_Click);
            // 
            // txtfechainicio
            // 
            this.txtfechainicio.CustomFormat = "dd/mm/yyyy";
            this.txtfechainicio.Font = new System.Drawing.Font("Open Sans Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtfechainicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtfechainicio.Location = new System.Drawing.Point(110, 49);
            this.txtfechainicio.Margin = new System.Windows.Forms.Padding(2);
            this.txtfechainicio.Name = "txtfechainicio";
            this.txtfechainicio.Size = new System.Drawing.Size(93, 26);
            this.txtfechainicio.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.panel2.Controls.Add(this.label19);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1225, 67);
            this.panel2.TabIndex = 117;
            // 
            // label19
            // 
            this.label19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.label19.Font = new System.Drawing.Font("Open Sans Semibold", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(44)))), ((int)(((byte)(64)))));
            this.label19.Location = new System.Drawing.Point(19, 11);
            this.label19.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(345, 45);
            this.label19.TabIndex = 62;
            this.label19.Text = "Reporte Producción";
            // 
            // freporte_produccion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1225, 592);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.excel);
            this.Controls.Add(this.dgdata);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "freporte_produccion";
            this.Text = "freporte_produccion";
            this.Load += new System.EventHandler(this.freporte_produccion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgdata)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private FontAwesome.Sharp.IconButton excel;
        private System.Windows.Forms.DataGridView dgdata;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker txtfechafin;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker txtfechainicio;
        private FontAwesome.Sharp.IconButton btnbuscarresultado;
#pragma warning disable CS0169 // El campo 'freporte_produccion.FechaProduccion' nunca se usa
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaProduccion;
#pragma warning restore CS0169 // El campo 'freporte_produccion.FechaProduccion' nunca se usa
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Stock;
        private System.Windows.Forms.DataGridViewTextBoxColumn CantidadCheddar;
        private System.Windows.Forms.DataGridViewTextBoxColumn CantidadDanes;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnidadMedidaGenerica;
        private System.Windows.Forms.DataGridViewTextBoxColumn CantidadTotal;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label19;
    }
}