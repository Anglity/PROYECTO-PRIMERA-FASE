namespace proyecto.modales
{
    partial class md_cliente
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label12 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.busquedacombo = new System.Windows.Forms.ComboBox();
            this.btnlimpiarbuscador = new FontAwesome.Sharp.IconButton();
            this.busqueda = new System.Windows.Forms.TextBox();
            this.btnbusqueda = new FontAwesome.Sharp.IconButton();
            this.dgdata = new System.Windows.Forms.DataGridView();
            this.Documento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreCompleto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgdata)).BeginInit();
            this.SuspendLayout();
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.White;
            this.label12.Font = new System.Drawing.Font("Open Sans Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(44)))), ((int)(((byte)(64)))));
            this.label12.Location = new System.Drawing.Point(6, 15);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(68, 25);
            this.label12.TabIndex = 67;
            this.label12.Text = "Buscar";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.busquedacombo);
            this.panel1.Controls.Add(this.btnlimpiarbuscador);
            this.panel1.Controls.Add(this.busqueda);
            this.panel1.Controls.Add(this.btnbusqueda);
            this.panel1.Location = new System.Drawing.Point(27, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(783, 90);
            this.panel1.TabIndex = 118;
            // 
            // busquedacombo
            // 
            this.busquedacombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.busquedacombo.Font = new System.Drawing.Font("Open Sans Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.busquedacombo.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.busquedacombo.FormattingEnabled = true;
            this.busquedacombo.Location = new System.Drawing.Point(81, 19);
            this.busquedacombo.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.busquedacombo.Name = "busquedacombo";
            this.busquedacombo.Size = new System.Drawing.Size(210, 26);
            this.busquedacombo.TabIndex = 66;
            // 
            // btnlimpiarbuscador
            // 
            this.btnlimpiarbuscador.BackColor = System.Drawing.Color.White;
            this.btnlimpiarbuscador.FlatAppearance.BorderSize = 0;
            this.btnlimpiarbuscador.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnlimpiarbuscador.IconChar = FontAwesome.Sharp.IconChar.Broom;
            this.btnlimpiarbuscador.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(44)))), ((int)(((byte)(64)))));
            this.btnlimpiarbuscador.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnlimpiarbuscador.IconSize = 35;
            this.btnlimpiarbuscador.Location = new System.Drawing.Point(712, 6);
            this.btnlimpiarbuscador.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.btnlimpiarbuscador.Name = "btnlimpiarbuscador";
            this.btnlimpiarbuscador.Size = new System.Drawing.Size(52, 55);
            this.btnlimpiarbuscador.TabIndex = 70;
            this.btnlimpiarbuscador.UseVisualStyleBackColor = false;
            this.btnlimpiarbuscador.Click += new System.EventHandler(this.btnlimpiarbuscador_Click);
            // 
            // busqueda
            // 
            this.busqueda.Font = new System.Drawing.Font("Open Sans Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.busqueda.Location = new System.Drawing.Point(309, 20);
            this.busqueda.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.busqueda.Name = "busqueda";
            this.busqueda.Size = new System.Drawing.Size(300, 26);
            this.busqueda.TabIndex = 68;
            // 
            // btnbusqueda
            // 
            this.btnbusqueda.AutoSize = true;
            this.btnbusqueda.BackColor = System.Drawing.Color.White;
            this.btnbusqueda.FlatAppearance.BorderSize = 0;
            this.btnbusqueda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnbusqueda.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
            this.btnbusqueda.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(44)))), ((int)(((byte)(64)))));
            this.btnbusqueda.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnbusqueda.IconSize = 35;
            this.btnbusqueda.Location = new System.Drawing.Point(637, 4);
            this.btnbusqueda.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.btnbusqueda.Name = "btnbusqueda";
            this.btnbusqueda.Size = new System.Drawing.Size(54, 54);
            this.btnbusqueda.TabIndex = 69;
            this.btnbusqueda.UseVisualStyleBackColor = false;
            this.btnbusqueda.Click += new System.EventHandler(this.btnbusqueda_Click);
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
            this.Documento,
            this.NombreCompleto});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgdata.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgdata.Location = new System.Drawing.Point(27, 144);
            this.dgdata.MultiSelect = false;
            this.dgdata.Name = "dgdata";
            this.dgdata.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Open Sans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgdata.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgdata.RowHeadersWidth = 102;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            this.dgdata.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgdata.RowTemplate.Height = 28;
            this.dgdata.Size = new System.Drawing.Size(778, 301);
            this.dgdata.TabIndex = 119;
            this.dgdata.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgdata_CellContentDoubleClick);
            // 
            // Documento
            // 
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Documento.DefaultCellStyle = dataGridViewCellStyle3;
            this.Documento.FillWeight = 150F;
            this.Documento.HeaderText = "No Documento";
            this.Documento.MinimumWidth = 20;
            this.Documento.Name = "Documento";
            this.Documento.ReadOnly = true;
            this.Documento.Width = 350;
            // 
            // NombreCompleto
            // 
            this.NombreCompleto.HeaderText = "Nombre Completo";
            this.NombreCompleto.MinimumWidth = 12;
            this.NombreCompleto.Name = "NombreCompleto";
            this.NombreCompleto.ReadOnly = true;
            this.NombreCompleto.Width = 400;
            // 
            // md_cliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(843, 443);
            this.Controls.Add(this.dgdata);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "md_cliente";
            this.Text = "md_cliente";
            this.Load += new System.EventHandler(this.md_cliente_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgdata)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox busquedacombo;
        private FontAwesome.Sharp.IconButton btnlimpiarbuscador;
        private System.Windows.Forms.TextBox busqueda;
        private FontAwesome.Sharp.IconButton btnbusqueda;
        private System.Windows.Forms.DataGridView dgdata;
        private System.Windows.Forms.DataGridViewTextBoxColumn Documento;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreCompleto;
    }
}