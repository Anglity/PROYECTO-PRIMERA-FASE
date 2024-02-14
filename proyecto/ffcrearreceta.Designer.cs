namespace proyecto
{
    partial class ffcrearreceta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ffcrearreceta));
            this.botonProductos = new FontAwesome.Sharp.IconButton();
            this.dgdata = new System.Windows.Forms.DataGridView();
            this.nombre_receta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Preparacion1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tiempo1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.imagen = new System.Windows.Forms.DataGridViewImageColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.btnsubir = new FontAwesome.Sharp.IconButton();
            this.piclogo = new System.Windows.Forms.PictureBox();
            this.iconButton2 = new FontAwesome.Sharp.IconButton();
            this.refresh = new FontAwesome.Sharp.IconButton();
            this.btneliminar = new FontAwesome.Sharp.IconButton();
            this.iconButton3 = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgdata)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.piclogo)).BeginInit();
            this.SuspendLayout();
            // 
            // botonProductos
            // 
            this.botonProductos.BackColor = System.Drawing.Color.FloralWhite;
            this.botonProductos.IconChar = FontAwesome.Sharp.IconChar.Book;
            this.botonProductos.IconColor = System.Drawing.Color.Red;
            this.botonProductos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.botonProductos.Location = new System.Drawing.Point(80, 597);
            this.botonProductos.Name = "botonProductos";
            this.botonProductos.Size = new System.Drawing.Size(117, 61);
            this.botonProductos.TabIndex = 0;
            this.botonProductos.UseVisualStyleBackColor = false;
            this.botonProductos.Click += new System.EventHandler(this.botonProductos_Click);
            // 
            // dgdata
            // 
            this.dgdata.AllowUserToAddRows = false;
            this.dgdata.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.dgdata.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgdata.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgdata.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgdata.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgdata.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgdata.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nombre_receta,
            this.producto,
            this.Preparacion1,
            this.tiempo1,
            this.imagen});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgdata.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgdata.Location = new System.Drawing.Point(13, 78);
            this.dgdata.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgdata.MultiSelect = false;
            this.dgdata.Name = "dgdata";
            this.dgdata.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgdata.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgdata.RowHeadersWidth = 102;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.SeaShell;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            this.dgdata.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgdata.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.dgdata.RowTemplate.Height = 28;
            this.dgdata.Size = new System.Drawing.Size(1201, 493);
            this.dgdata.TabIndex = 118;
            this.dgdata.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgdata_CellContentDoubleClick);
            // 
            // nombre_receta
            // 
            this.nombre_receta.Frozen = true;
            this.nombre_receta.HeaderText = "NOMBRE RECETA";
            this.nombre_receta.MinimumWidth = 6;
            this.nombre_receta.Name = "nombre_receta";
            this.nombre_receta.ReadOnly = true;
            this.nombre_receta.Width = 250;
            // 
            // producto
            // 
            this.producto.HeaderText = "PRODUCTO";
            this.producto.MinimumWidth = 6;
            this.producto.Name = "producto";
            this.producto.ReadOnly = true;
            this.producto.Visible = false;
            this.producto.Width = 350;
            // 
            // Preparacion1
            // 
            this.Preparacion1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Preparacion1.HeaderText = "PREPARACION";
            this.Preparacion1.MinimumWidth = 6;
            this.Preparacion1.Name = "Preparacion1";
            this.Preparacion1.ReadOnly = true;
            this.Preparacion1.Width = 189;
            // 
            // tiempo1
            // 
            this.tiempo1.HeaderText = "TIEMPO";
            this.tiempo1.MinimumWidth = 6;
            this.tiempo1.Name = "tiempo1";
            this.tiempo1.ReadOnly = true;
            this.tiempo1.Width = 250;
            // 
            // imagen
            // 
            this.imagen.HeaderText = "imagen";
            this.imagen.MinimumWidth = 6;
            this.imagen.Name = "imagen";
            this.imagen.ReadOnly = true;
            this.imagen.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.imagen.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.imagen.Visible = false;
            this.imagen.Width = 125;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Sienna;
            this.panel2.Controls.Add(this.label9);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1780, 70);
            this.panel2.TabIndex = 119;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Sienna;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(24, 16);
            this.label9.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(323, 39);
            this.label9.TabIndex = 62;
            this.label9.Text = "CREAR RECETA";
            // 
            // iconButton1
            // 
            this.iconButton1.BackColor = System.Drawing.Color.FloralWhite;
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.Pen;
            this.iconButton1.IconColor = System.Drawing.Color.Red;
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton1.Location = new System.Drawing.Point(80, 758);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Size = new System.Drawing.Size(117, 61);
            this.iconButton1.TabIndex = 120;
            this.iconButton1.UseVisualStyleBackColor = false;
            this.iconButton1.Click += new System.EventHandler(this.iconButton1_Click);
            // 
            // btnsubir
            // 
            this.btnsubir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(191)))), ((int)(((byte)(138)))));
            this.btnsubir.FlatAppearance.BorderSize = 0;
            this.btnsubir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnsubir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsubir.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.btnsubir.IconChar = FontAwesome.Sharp.IconChar.Upload;
            this.btnsubir.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(44)))), ((int)(((byte)(64)))));
            this.btnsubir.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnsubir.IconSize = 35;
            this.btnsubir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnsubir.Location = new System.Drawing.Point(1406, 564);
            this.btnsubir.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.btnsubir.Name = "btnsubir";
            this.btnsubir.Size = new System.Drawing.Size(133, 49);
            this.btnsubir.TabIndex = 123;
            this.btnsubir.Text = "Subir";
            this.btnsubir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnsubir.UseVisualStyleBackColor = false;
            this.btnsubir.Click += new System.EventHandler(this.btnsubir_Click);
            // 
            // piclogo
            // 
            this.piclogo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.piclogo.Location = new System.Drawing.Point(1262, 95);
            this.piclogo.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.piclogo.Name = "piclogo";
            this.piclogo.Size = new System.Drawing.Size(429, 454);
            this.piclogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.piclogo.TabIndex = 121;
            this.piclogo.TabStop = false;
            // 
            // iconButton2
            // 
            this.iconButton2.BackColor = System.Drawing.Color.FloralWhite;
            this.iconButton2.IconChar = FontAwesome.Sharp.IconChar.Print;
            this.iconButton2.IconColor = System.Drawing.Color.Red;
            this.iconButton2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton2.Location = new System.Drawing.Point(346, 597);
            this.iconButton2.Name = "iconButton2";
            this.iconButton2.Size = new System.Drawing.Size(122, 61);
            this.iconButton2.TabIndex = 124;
            this.iconButton2.UseVisualStyleBackColor = false;
            this.iconButton2.Click += new System.EventHandler(this.iconButton2_Click_1);
            // 
            // refresh
            // 
            this.refresh.BackColor = System.Drawing.Color.FloralWhite;
            this.refresh.IconChar = FontAwesome.Sharp.IconChar.Dashboard;
            this.refresh.IconColor = System.Drawing.Color.Red;
            this.refresh.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.refresh.Location = new System.Drawing.Point(664, 758);
            this.refresh.Name = "refresh";
            this.refresh.Size = new System.Drawing.Size(117, 61);
            this.refresh.TabIndex = 126;
            this.refresh.UseVisualStyleBackColor = false;
            this.refresh.Click += new System.EventHandler(this.refresh_Click);
            // 
            // btneliminar
            // 
            this.btneliminar.BackColor = System.Drawing.Color.FloralWhite;
            this.btneliminar.IconChar = FontAwesome.Sharp.IconChar.Dumpster;
            this.btneliminar.IconColor = System.Drawing.Color.Red;
            this.btneliminar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btneliminar.Location = new System.Drawing.Point(664, 597);
            this.btneliminar.Name = "btneliminar";
            this.btneliminar.Size = new System.Drawing.Size(117, 61);
            this.btneliminar.TabIndex = 127;
            this.btneliminar.UseVisualStyleBackColor = false;
            this.btneliminar.Click += new System.EventHandler(this.btneliminar_Click);
            // 
            // iconButton3
            // 
            this.iconButton3.BackColor = System.Drawing.Color.FloralWhite;
            this.iconButton3.IconChar = FontAwesome.Sharp.IconChar.MailBulk;
            this.iconButton3.IconColor = System.Drawing.Color.Red;
            this.iconButton3.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton3.Location = new System.Drawing.Point(346, 758);
            this.iconButton3.Name = "iconButton3";
            this.iconButton3.Size = new System.Drawing.Size(117, 61);
            this.iconButton3.TabIndex = 128;
            this.iconButton3.UseVisualStyleBackColor = false;
            this.iconButton3.Click += new System.EventHandler(this.iconButton3_Click);
            // 
            // ffcrearreceta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1780, 894);
            this.Controls.Add(this.iconButton3);
            this.Controls.Add(this.btneliminar);
            this.Controls.Add(this.refresh);
            this.Controls.Add(this.iconButton2);
            this.Controls.Add(this.btnsubir);
            this.Controls.Add(this.piclogo);
            this.Controls.Add(this.iconButton1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dgdata);
            this.Controls.Add(this.botonProductos);
            this.Name = "ffcrearreceta";
            this.Text = "ffcrearreceta";
            this.Load += new System.EventHandler(this.ffcrearreceta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgdata)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.piclogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private FontAwesome.Sharp.IconButton botonProductos;
        private System.Windows.Forms.DataGridView dgdata;
#pragma warning disable CS0169 // El campo 'ffcrearreceta.nombreReceta' nunca se usa
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreReceta;
#pragma warning restore CS0169 // El campo 'ffcrearreceta.nombreReceta' nunca se usa
        
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label9;
        private FontAwesome.Sharp.IconButton iconButton1;
        private FontAwesome.Sharp.IconButton btnsubir;
        private System.Windows.Forms.PictureBox piclogo;
        private FontAwesome.Sharp.IconButton iconButton2;
        private FontAwesome.Sharp.IconButton refresh;
        private FontAwesome.Sharp.IconButton btneliminar;
        private FontAwesome.Sharp.IconButton iconButton3;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre_receta;
        private System.Windows.Forms.DataGridViewTextBoxColumn producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Preparacion1;
        private System.Windows.Forms.DataGridViewTextBoxColumn tiempo1;
        private System.Windows.Forms.DataGridViewImageColumn imagen;
    }
}