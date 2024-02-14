namespace proyecto
{
    partial class fmateriaprima
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
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.excel = new FontAwesome.Sharp.IconButton();
            this.label12 = new System.Windows.Forms.Label();
            this.busquedacombo = new System.Windows.Forms.ComboBox();
            this.btnlimpiarbuscador = new FontAwesome.Sharp.IconButton();
            this.busqueda = new System.Windows.Forms.TextBox();
            this.btnbusqueda = new FontAwesome.Sharp.IconButton();
            this.unidadMedida2 = new System.Windows.Forms.ComboBox();
            this.dgdata = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Proveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CantidadEnStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnidadMedida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CostoPorUnidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaDeAdquisicion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtindice = new System.Windows.Forms.TextBox();
            this.txtid = new System.Windows.Forms.TextBox();
            this.btneliminar = new System.Windows.Forms.Button();
            this.btnlimpiar = new System.Windows.Forms.Button();
            this.btnguardar = new System.Windows.Forms.Button();
            this.estado2 = new System.Windows.Forms.ComboBox();
            this.categoria2 = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtdescripcion = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtcompleto = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtcodigo = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgdata)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(44)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(48, 553);
            this.label1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 31);
            this.label1.TabIndex = 136;
            this.label1.Text = "Unidades";
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(44)))), ((int)(((byte)(64)))));
            this.label9.Location = new System.Drawing.Point(24, 20);
            this.label9.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(489, 57);
            this.label9.TabIndex = 62;
            this.label9.Text = "Inventario";
            // 
            // excel
            // 
            this.excel.AutoSize = true;
            this.excel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(191)))), ((int)(((byte)(138)))));
            this.excel.FlatAppearance.BorderSize = 0;
            this.excel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.excel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.excel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.excel.IconChar = FontAwesome.Sharp.IconChar.Download;
            this.excel.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(44)))), ((int)(((byte)(64)))));
            this.excel.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.excel.IconSize = 35;
            this.excel.Location = new System.Drawing.Point(51, 724);
            this.excel.Margin = new System.Windows.Forms.Padding(1);
            this.excel.Name = "excel";
            this.excel.Size = new System.Drawing.Size(252, 50);
            this.excel.TabIndex = 116;
            this.excel.Text = "Descargar a Excel";
            this.excel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.excel.UseVisualStyleBackColor = false;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.White;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(44)))), ((int)(((byte)(64)))));
            this.label12.Location = new System.Drawing.Point(16, 47);
            this.label12.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(89, 31);
            this.label12.TabIndex = 67;
            this.label12.Text = "Buscar";
            // 
            // busquedacombo
            // 
            this.busquedacombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.busquedacombo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.busquedacombo.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.busquedacombo.FormattingEnabled = true;
            this.busquedacombo.Location = new System.Drawing.Point(105, 47);
            this.busquedacombo.Margin = new System.Windows.Forms.Padding(1);
            this.busquedacombo.Name = "busquedacombo";
            this.busquedacombo.Size = new System.Drawing.Size(277, 33);
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
            this.btnlimpiarbuscador.Location = new System.Drawing.Point(940, 23);
            this.btnlimpiarbuscador.Margin = new System.Windows.Forms.Padding(1);
            this.btnlimpiarbuscador.Name = "btnlimpiarbuscador";
            this.btnlimpiarbuscador.Size = new System.Drawing.Size(69, 68);
            this.btnlimpiarbuscador.TabIndex = 70;
            this.btnlimpiarbuscador.UseVisualStyleBackColor = false;
            // 
            // busqueda
            // 
            this.busqueda.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.busqueda.Location = new System.Drawing.Point(401, 47);
            this.busqueda.Margin = new System.Windows.Forms.Padding(1);
            this.busqueda.Name = "busqueda";
            this.busqueda.Size = new System.Drawing.Size(397, 30);
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
            this.btnbusqueda.Location = new System.Drawing.Point(840, 25);
            this.btnbusqueda.Margin = new System.Windows.Forms.Padding(1);
            this.btnbusqueda.Name = "btnbusqueda";
            this.btnbusqueda.Size = new System.Drawing.Size(72, 66);
            this.btnbusqueda.TabIndex = 69;
            this.btnbusqueda.UseVisualStyleBackColor = false;
            // 
            // unidadMedida2
            // 
            this.unidadMedida2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.unidadMedida2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unidadMedida2.FormattingEnabled = true;
            this.unidadMedida2.Location = new System.Drawing.Point(53, 594);
            this.unidadMedida2.Margin = new System.Windows.Forms.Padding(1);
            this.unidadMedida2.Name = "unidadMedida2";
            this.unidadMedida2.Size = new System.Drawing.Size(399, 33);
            this.unidadMedida2.TabIndex = 135;
            // 
            // dgdata
            // 
            this.dgdata.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.dgdata.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
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
            this.id,
            this.Codigo,
            this.Nombre,
            this.Proveedor,
            this.CantidadEnStock,
            this.UnidadMedida,
            this.CostoPorUnidad,
            this.FechaDeAdquisicion});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgdata.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgdata.Location = new System.Drawing.Point(536, 276);
            this.dgdata.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgdata.MultiSelect = false;
            this.dgdata.Name = "dgdata";
            this.dgdata.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgdata.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgdata.RowHeadersWidth = 102;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            this.dgdata.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgdata.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.dgdata.RowTemplate.Height = 28;
            this.dgdata.Size = new System.Drawing.Size(1029, 449);
            this.dgdata.TabIndex = 134;
            // 
            // id
            // 
            this.id.HeaderText = "id";
            this.id.MinimumWidth = 6;
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            this.id.Width = 125;
            // 
            // Codigo
            // 
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Codigo.DefaultCellStyle = dataGridViewCellStyle3;
            this.Codigo.FillWeight = 150F;
            this.Codigo.HeaderText = "Codigo";
            this.Codigo.MinimumWidth = 20;
            this.Codigo.Name = "Codigo";
            this.Codigo.ReadOnly = true;
            this.Codigo.Width = 125;
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.MinimumWidth = 12;
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.Nombre.Width = 125;
            // 
            // Proveedor
            // 
            this.Proveedor.HeaderText = "Proveedor";
            this.Proveedor.MinimumWidth = 12;
            this.Proveedor.Name = "Proveedor";
            this.Proveedor.ReadOnly = true;
            this.Proveedor.Width = 150;
            // 
            // CantidadEnStock
            // 
            this.CantidadEnStock.HeaderText = "Stock";
            this.CantidadEnStock.MinimumWidth = 12;
            this.CantidadEnStock.Name = "CantidadEnStock";
            this.CantidadEnStock.ReadOnly = true;
            this.CantidadEnStock.Width = 125;
            // 
            // UnidadMedida
            // 
            this.UnidadMedida.HeaderText = "UnidadMedida";
            this.UnidadMedida.MinimumWidth = 6;
            this.UnidadMedida.Name = "UnidadMedida";
            this.UnidadMedida.ReadOnly = true;
            this.UnidadMedida.Width = 125;
            // 
            // CostoPorUnidad
            // 
            this.CostoPorUnidad.HeaderText = "CostoPorUnidad";
            this.CostoPorUnidad.MinimumWidth = 12;
            this.CostoPorUnidad.Name = "CostoPorUnidad";
            this.CostoPorUnidad.ReadOnly = true;
            this.CostoPorUnidad.Width = 200;
            // 
            // FechaDeAdquisicion
            // 
            this.FechaDeAdquisicion.HeaderText = "FechaDeAdquisicion";
            this.FechaDeAdquisicion.MinimumWidth = 6;
            this.FechaDeAdquisicion.Name = "FechaDeAdquisicion";
            this.FechaDeAdquisicion.ReadOnly = true;
            this.FechaDeAdquisicion.Width = 125;
            // 
            // txtindice
            // 
            this.txtindice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtindice.Location = new System.Drawing.Point(343, 156);
            this.txtindice.Margin = new System.Windows.Forms.Padding(1);
            this.txtindice.Name = "txtindice";
            this.txtindice.Size = new System.Drawing.Size(31, 30);
            this.txtindice.TabIndex = 133;
            this.txtindice.Text = "-1";
            this.txtindice.Visible = false;
            // 
            // txtid
            // 
            this.txtid.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtid.Location = new System.Drawing.Point(380, 156);
            this.txtid.Margin = new System.Windows.Forms.Padding(1);
            this.txtid.Name = "txtid";
            this.txtid.Size = new System.Drawing.Size(29, 30);
            this.txtid.TabIndex = 132;
            this.txtid.Text = "0";
            this.txtid.Visible = false;
            // 
            // btneliminar
            // 
            this.btneliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(151)))), ((int)(((byte)(242)))));
            this.btneliminar.FlatAppearance.BorderSize = 0;
            this.btneliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btneliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btneliminar.ForeColor = System.Drawing.Color.Black;
            this.btneliminar.Location = new System.Drawing.Point(385, 655);
            this.btneliminar.Margin = new System.Windows.Forms.Padding(1);
            this.btneliminar.Name = "btneliminar";
            this.btneliminar.Size = new System.Drawing.Size(128, 42);
            this.btneliminar.TabIndex = 131;
            this.btneliminar.Text = "Eliminar";
            this.btneliminar.UseVisualStyleBackColor = false;
            // 
            // btnlimpiar
            // 
            this.btnlimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(151)))), ((int)(((byte)(242)))));
            this.btnlimpiar.FlatAppearance.BorderSize = 0;
            this.btnlimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnlimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnlimpiar.ForeColor = System.Drawing.Color.Black;
            this.btnlimpiar.Location = new System.Drawing.Point(220, 654);
            this.btnlimpiar.Margin = new System.Windows.Forms.Padding(1);
            this.btnlimpiar.Name = "btnlimpiar";
            this.btnlimpiar.Size = new System.Drawing.Size(129, 41);
            this.btnlimpiar.TabIndex = 130;
            this.btnlimpiar.Text = "Limpiar";
            this.btnlimpiar.UseVisualStyleBackColor = false;
            // 
            // btnguardar
            // 
            this.btnguardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(151)))), ((int)(((byte)(242)))));
            this.btnguardar.FlatAppearance.BorderSize = 0;
            this.btnguardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnguardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnguardar.ForeColor = System.Drawing.Color.Black;
            this.btnguardar.Location = new System.Drawing.Point(51, 655);
            this.btnguardar.Margin = new System.Windows.Forms.Padding(1);
            this.btnguardar.Name = "btnguardar";
            this.btnguardar.Size = new System.Drawing.Size(128, 39);
            this.btnguardar.TabIndex = 129;
            this.btnguardar.Text = "Guardar";
            this.btnguardar.UseVisualStyleBackColor = false;
            // 
            // estado2
            // 
            this.estado2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.estado2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.estado2.FormattingEnabled = true;
            this.estado2.Location = new System.Drawing.Point(51, 513);
            this.estado2.Margin = new System.Windows.Forms.Padding(1);
            this.estado2.Name = "estado2";
            this.estado2.Size = new System.Drawing.Size(399, 33);
            this.estado2.TabIndex = 128;
            // 
            // categoria2
            // 
            this.categoria2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.categoria2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.categoria2.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.categoria2.FormattingEnabled = true;
            this.categoria2.Location = new System.Drawing.Point(51, 432);
            this.categoria2.Margin = new System.Windows.Forms.Padding(1);
            this.categoria2.Name = "categoria2";
            this.categoria2.Size = new System.Drawing.Size(399, 33);
            this.categoria2.TabIndex = 126;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(44)))), ((int)(((byte)(64)))));
            this.label7.Location = new System.Drawing.Point(48, 400);
            this.label7.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(192, 31);
            this.label7.TabIndex = 125;
            this.label7.Text = "Categoria:";
            // 
            // txtdescripcion
            // 
            this.txtdescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdescripcion.Location = new System.Drawing.Point(51, 354);
            this.txtdescripcion.Margin = new System.Windows.Forms.Padding(1);
            this.txtdescripcion.Name = "txtdescripcion";
            this.txtdescripcion.Size = new System.Drawing.Size(399, 30);
            this.txtdescripcion.TabIndex = 124;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(44)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(48, 322);
            this.label4.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(192, 31);
            this.label4.TabIndex = 123;
            this.label4.Text = "Descripcion";
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.White;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(44)))), ((int)(((byte)(64)))));
            this.label8.Location = new System.Drawing.Point(48, 481);
            this.label8.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(192, 31);
            this.label8.TabIndex = 127;
            this.label8.Text = "Estado";
            // 
            // txtcompleto
            // 
            this.txtcompleto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcompleto.Location = new System.Drawing.Point(51, 276);
            this.txtcompleto.Margin = new System.Windows.Forms.Padding(1);
            this.txtcompleto.Name = "txtcompleto";
            this.txtcompleto.Size = new System.Drawing.Size(399, 30);
            this.txtcompleto.TabIndex = 122;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(44)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(47, 244);
            this.label3.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(203, 31);
            this.label3.TabIndex = 121;
            this.label3.Text = "Nombre ";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(44)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(47, 167);
            this.label2.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(151, 31);
            this.label2.TabIndex = 119;
            this.label2.Text = "Codigo:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.busquedacombo);
            this.panel1.Controls.Add(this.btnlimpiarbuscador);
            this.panel1.Controls.Add(this.busqueda);
            this.panel1.Controls.Add(this.btnbusqueda);
            this.panel1.Location = new System.Drawing.Point(521, 156);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1044, 111);
            this.panel1.TabIndex = 117;
            // 
            // txtcodigo
            // 
            this.txtcodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcodigo.Location = new System.Drawing.Point(51, 199);
            this.txtcodigo.Margin = new System.Windows.Forms.Padding(1);
            this.txtcodigo.Name = "txtcodigo";
            this.txtcodigo.Size = new System.Drawing.Size(399, 30);
            this.txtcodigo.TabIndex = 120;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.panel2.Controls.Add(this.label9);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1624, 82);
            this.panel2.TabIndex = 118;
            // 
            // fmateriaprima
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1624, 885);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.excel);
            this.Controls.Add(this.unidadMedida2);
            this.Controls.Add(this.dgdata);
            this.Controls.Add(this.txtindice);
            this.Controls.Add(this.txtid);
            this.Controls.Add(this.btneliminar);
            this.Controls.Add(this.btnlimpiar);
            this.Controls.Add(this.btnguardar);
            this.Controls.Add(this.estado2);
            this.Controls.Add(this.categoria2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtdescripcion);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtcompleto);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtcodigo);
            this.Controls.Add(this.panel2);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "fmateriaprima";
            this.Text = "fmateriaprima";
            this.Load += new System.EventHandler(this.fmateriaprima_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgdata)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label9;
        private FontAwesome.Sharp.IconButton excel;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox busquedacombo;
        private FontAwesome.Sharp.IconButton btnlimpiarbuscador;
        private System.Windows.Forms.TextBox busqueda;
        private FontAwesome.Sharp.IconButton btnbusqueda;
        private System.Windows.Forms.ComboBox unidadMedida2;
        private System.Windows.Forms.DataGridView dgdata;
        private System.Windows.Forms.TextBox txtindice;
        private System.Windows.Forms.TextBox txtid;
        private System.Windows.Forms.Button btneliminar;
        private System.Windows.Forms.Button btnlimpiar;
        private System.Windows.Forms.Button btnguardar;
        private System.Windows.Forms.ComboBox estado2;
        private System.Windows.Forms.ComboBox categoria2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtdescripcion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtcompleto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtcodigo;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Proveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn CantidadEnStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnidadMedida;
        private System.Windows.Forms.DataGridViewTextBoxColumn CostoPorUnidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaDeAdquisicion;
    }
}