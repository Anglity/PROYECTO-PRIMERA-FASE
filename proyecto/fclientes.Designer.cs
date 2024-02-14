namespace proyecto
{
    partial class fclientes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fclientes));
            this.dgdata = new System.Windows.Forms.DataGridView();
            this.btnseleccionar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Documento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreCompleto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Correo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Telefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdDireccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pais = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Provincia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ciudad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sector = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Calle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoPostal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Direccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EstadoValor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtindice = new System.Windows.Forms.TextBox();
            this.txtid = new System.Windows.Forms.TextBox();
            this.btneliminar = new System.Windows.Forms.Button();
            this.btnlimpiar = new System.Windows.Forms.Button();
            this.btnguardar = new System.Windows.Forms.Button();
            this.estado2 = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.busquedacombo = new System.Windows.Forms.ComboBox();
            this.btnlimpiarbuscador = new FontAwesome.Sharp.IconButton();
            this.busqueda = new System.Windows.Forms.TextBox();
            this.btnbusqueda = new FontAwesome.Sharp.IconButton();
            this.excel = new FontAwesome.Sharp.IconButton();
            this.label5 = new System.Windows.Forms.Label();
            this.txttelefono = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ncompleto = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtdocumento = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.correo2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.calletxt = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.paistxt = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.ciudadtxt = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.codigopostaltxt = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.provinciatxt = new System.Windows.Forms.TextBox();
            this.sectortxt = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.iddireciontxt = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgdata)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgdata
            // 
            this.dgdata.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.dgdata.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgdata.BackgroundColor = System.Drawing.SystemColors.Control;
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
            this.btnseleccionar,
            this.Id,
            this.Documento,
            this.NombreCompleto,
            this.Correo,
            this.Telefono,
            this.IdDireccion,
            this.Pais,
            this.Provincia,
            this.Ciudad,
            this.Sector,
            this.Calle,
            this.CodigoPostal,
            this.Direccion,
            this.Estado,
            this.EstadoValor});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgdata.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgdata.Location = new System.Drawing.Point(501, 272);
            this.dgdata.Margin = new System.Windows.Forms.Padding(4);
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
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            this.dgdata.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgdata.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.dgdata.RowTemplate.Height = 28;
            this.dgdata.Size = new System.Drawing.Size(1203, 402);
            this.dgdata.TabIndex = 117;
            this.dgdata.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgdata_CellContentClick);
            this.dgdata.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgdata_CellPainting);
            // 
            // btnseleccionar
            // 
            this.btnseleccionar.HeaderText = "";
            this.btnseleccionar.MinimumWidth = 12;
            this.btnseleccionar.Name = "btnseleccionar";
            this.btnseleccionar.ReadOnly = true;
            this.btnseleccionar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.btnseleccionar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.btnseleccionar.Width = 50;
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.MinimumWidth = 12;
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            this.Id.Width = 50;
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
            this.Documento.Width = 170;
            // 
            // NombreCompleto
            // 
            this.NombreCompleto.HeaderText = "Nombre Completo";
            this.NombreCompleto.MinimumWidth = 12;
            this.NombreCompleto.Name = "NombreCompleto";
            this.NombreCompleto.ReadOnly = true;
            this.NombreCompleto.Width = 200;
            // 
            // Correo
            // 
            this.Correo.HeaderText = "Correo";
            this.Correo.MinimumWidth = 12;
            this.Correo.Name = "Correo";
            this.Correo.ReadOnly = true;
            this.Correo.Width = 125;
            // 
            // Telefono
            // 
            this.Telefono.HeaderText = "Telefono";
            this.Telefono.MinimumWidth = 12;
            this.Telefono.Name = "Telefono";
            this.Telefono.ReadOnly = true;
            this.Telefono.Width = 125;
            // 
            // IdDireccion
            // 
            this.IdDireccion.HeaderText = "IdDireccion";
            this.IdDireccion.MinimumWidth = 6;
            this.IdDireccion.Name = "IdDireccion";
            this.IdDireccion.ReadOnly = true;
            this.IdDireccion.Visible = false;
            this.IdDireccion.Width = 125;
            // 
            // Pais
            // 
            this.Pais.HeaderText = "Pais";
            this.Pais.MinimumWidth = 6;
            this.Pais.Name = "Pais";
            this.Pais.ReadOnly = true;
            this.Pais.Visible = false;
            this.Pais.Width = 125;
            // 
            // Provincia
            // 
            this.Provincia.HeaderText = "Provincia";
            this.Provincia.MinimumWidth = 6;
            this.Provincia.Name = "Provincia";
            this.Provincia.ReadOnly = true;
            this.Provincia.Visible = false;
            this.Provincia.Width = 125;
            // 
            // Ciudad
            // 
            this.Ciudad.HeaderText = "Ciudad";
            this.Ciudad.MinimumWidth = 6;
            this.Ciudad.Name = "Ciudad";
            this.Ciudad.ReadOnly = true;
            this.Ciudad.Visible = false;
            this.Ciudad.Width = 125;
            // 
            // Sector
            // 
            this.Sector.HeaderText = "Sector";
            this.Sector.MinimumWidth = 6;
            this.Sector.Name = "Sector";
            this.Sector.ReadOnly = true;
            this.Sector.Visible = false;
            this.Sector.Width = 125;
            // 
            // Calle
            // 
            this.Calle.HeaderText = "Calle";
            this.Calle.MinimumWidth = 6;
            this.Calle.Name = "Calle";
            this.Calle.ReadOnly = true;
            this.Calle.Visible = false;
            this.Calle.Width = 125;
            // 
            // CodigoPostal
            // 
            this.CodigoPostal.HeaderText = "CodigoPostal";
            this.CodigoPostal.MinimumWidth = 6;
            this.CodigoPostal.Name = "CodigoPostal";
            this.CodigoPostal.ReadOnly = true;
            this.CodigoPostal.Visible = false;
            this.CodigoPostal.Width = 125;
            // 
            // Direccion
            // 
            this.Direccion.HeaderText = "Direccion";
            this.Direccion.MinimumWidth = 6;
            this.Direccion.Name = "Direccion";
            this.Direccion.ReadOnly = true;
            this.Direccion.Width = 300;
            // 
            // Estado
            // 
            this.Estado.HeaderText = "Estado";
            this.Estado.MinimumWidth = 12;
            this.Estado.Name = "Estado";
            this.Estado.ReadOnly = true;
            this.Estado.Width = 125;
            // 
            // EstadoValor
            // 
            this.EstadoValor.HeaderText = "EstadoValor";
            this.EstadoValor.MinimumWidth = 12;
            this.EstadoValor.Name = "EstadoValor";
            this.EstadoValor.ReadOnly = true;
            this.EstadoValor.Visible = false;
            this.EstadoValor.Width = 150;
            // 
            // txtindice
            // 
            this.txtindice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtindice.Location = new System.Drawing.Point(335, 129);
            this.txtindice.Margin = new System.Windows.Forms.Padding(1);
            this.txtindice.Name = "txtindice";
            this.txtindice.Size = new System.Drawing.Size(31, 30);
            this.txtindice.TabIndex = 116;
            this.txtindice.Text = "-1";
            this.txtindice.Visible = false;
            // 
            // txtid
            // 
            this.txtid.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtid.Location = new System.Drawing.Point(391, 129);
            this.txtid.Margin = new System.Windows.Forms.Padding(1);
            this.txtid.Name = "txtid";
            this.txtid.Size = new System.Drawing.Size(31, 30);
            this.txtid.TabIndex = 115;
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
            this.btneliminar.Location = new System.Drawing.Point(816, 706);
            this.btneliminar.Margin = new System.Windows.Forms.Padding(1);
            this.btneliminar.Name = "btneliminar";
            this.btneliminar.Size = new System.Drawing.Size(128, 42);
            this.btneliminar.TabIndex = 114;
            this.btneliminar.Text = "Eliminar";
            this.btneliminar.UseVisualStyleBackColor = false;
            this.btneliminar.Click += new System.EventHandler(this.btneliminar_Click);
            // 
            // btnlimpiar
            // 
            this.btnlimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(151)))), ((int)(((byte)(242)))));
            this.btnlimpiar.FlatAppearance.BorderSize = 0;
            this.btnlimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnlimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnlimpiar.ForeColor = System.Drawing.Color.Black;
            this.btnlimpiar.Location = new System.Drawing.Point(657, 708);
            this.btnlimpiar.Margin = new System.Windows.Forms.Padding(1);
            this.btnlimpiar.Name = "btnlimpiar";
            this.btnlimpiar.Size = new System.Drawing.Size(129, 41);
            this.btnlimpiar.TabIndex = 113;
            this.btnlimpiar.Text = "Limpiar";
            this.btnlimpiar.UseVisualStyleBackColor = false;
            this.btnlimpiar.Click += new System.EventHandler(this.btnlimpiar_Click);
            // 
            // btnguardar
            // 
            this.btnguardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(151)))), ((int)(((byte)(242)))));
            this.btnguardar.FlatAppearance.BorderSize = 0;
            this.btnguardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnguardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnguardar.ForeColor = System.Drawing.Color.Black;
            this.btnguardar.Location = new System.Drawing.Point(501, 709);
            this.btnguardar.Margin = new System.Windows.Forms.Padding(1);
            this.btnguardar.Name = "btnguardar";
            this.btnguardar.Size = new System.Drawing.Size(128, 39);
            this.btnguardar.TabIndex = 112;
            this.btnguardar.Text = "Guardar";
            this.btnguardar.UseVisualStyleBackColor = false;
            this.btnguardar.Click += new System.EventHandler(this.btnguardar_Click);
            // 
            // estado2
            // 
            this.estado2.BackColor = System.Drawing.SystemColors.Info;
            this.estado2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.estado2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.estado2.FormattingEnabled = true;
            this.estado2.Location = new System.Drawing.Point(23, 475);
            this.estado2.Margin = new System.Windows.Forms.Padding(1);
            this.estado2.Name = "estado2";
            this.estado2.Size = new System.Drawing.Size(399, 28);
            this.estado2.TabIndex = 111;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(44)))), ((int)(((byte)(64)))));
            this.label8.Location = new System.Drawing.Point(20, 443);
            this.label8.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(192, 31);
            this.label8.TabIndex = 110;
            this.label8.Text = "Estado";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.panel2.Controls.Add(this.label9);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1753, 82);
            this.panel2.TabIndex = 97;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(44)))), ((int)(((byte)(64)))));
            this.label9.Location = new System.Drawing.Point(24, 16);
            this.label9.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(323, 39);
            this.label9.TabIndex = 62;
            this.label9.Text = "Detalle Cliente";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.busquedacombo);
            this.panel1.Controls.Add(this.btnlimpiarbuscador);
            this.panel1.Controls.Add(this.busqueda);
            this.panel1.Controls.Add(this.btnbusqueda);
            this.panel1.Location = new System.Drawing.Point(587, 129);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1028, 91);
            this.panel1.TabIndex = 96;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(44)))), ((int)(((byte)(64)))));
            this.label12.Location = new System.Drawing.Point(8, 32);
            this.label12.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(89, 31);
            this.label12.TabIndex = 67;
            this.label12.Text = "Buscar";
            // 
            // busquedacombo
            // 
            this.busquedacombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.busquedacombo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.busquedacombo.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.busquedacombo.FormattingEnabled = true;
            this.busquedacombo.Location = new System.Drawing.Point(99, 32);
            this.busquedacombo.Margin = new System.Windows.Forms.Padding(1);
            this.busquedacombo.Name = "busquedacombo";
            this.busquedacombo.Size = new System.Drawing.Size(277, 28);
            this.busquedacombo.TabIndex = 66;
            // 
            // btnlimpiarbuscador
            // 
            this.btnlimpiarbuscador.BackColor = System.Drawing.Color.Blue;
            this.btnlimpiarbuscador.FlatAppearance.BorderSize = 0;
            this.btnlimpiarbuscador.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnlimpiarbuscador.IconChar = FontAwesome.Sharp.IconChar.Broom;
            this.btnlimpiarbuscador.IconColor = System.Drawing.Color.White;
            this.btnlimpiarbuscador.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnlimpiarbuscador.IconSize = 35;
            this.btnlimpiarbuscador.Location = new System.Drawing.Point(940, 12);
            this.btnlimpiarbuscador.Margin = new System.Windows.Forms.Padding(1);
            this.btnlimpiarbuscador.Name = "btnlimpiarbuscador";
            this.btnlimpiarbuscador.Size = new System.Drawing.Size(69, 68);
            this.btnlimpiarbuscador.TabIndex = 70;
            this.btnlimpiarbuscador.UseVisualStyleBackColor = false;
            this.btnlimpiarbuscador.Click += new System.EventHandler(this.btnlimpiarbuscador_Click);
            // 
            // busqueda
            // 
            this.busqueda.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.busqueda.Location = new System.Drawing.Point(414, 32);
            this.busqueda.Margin = new System.Windows.Forms.Padding(1);
            this.busqueda.Name = "busqueda";
            this.busqueda.Size = new System.Drawing.Size(397, 26);
            this.busqueda.TabIndex = 68;
            // 
            // btnbusqueda
            // 
            this.btnbusqueda.AutoSize = true;
            this.btnbusqueda.BackColor = System.Drawing.Color.Blue;
            this.btnbusqueda.FlatAppearance.BorderSize = 0;
            this.btnbusqueda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnbusqueda.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
            this.btnbusqueda.IconColor = System.Drawing.Color.White;
            this.btnbusqueda.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnbusqueda.IconSize = 35;
            this.btnbusqueda.Location = new System.Drawing.Point(840, 12);
            this.btnbusqueda.Margin = new System.Windows.Forms.Padding(1);
            this.btnbusqueda.Name = "btnbusqueda";
            this.btnbusqueda.Size = new System.Drawing.Size(72, 66);
            this.btnbusqueda.TabIndex = 69;
            this.btnbusqueda.UseVisualStyleBackColor = false;
            this.btnbusqueda.Click += new System.EventHandler(this.btnbusqueda_Click);
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
            this.excel.Location = new System.Drawing.Point(1012, 704);
            this.excel.Margin = new System.Windows.Forms.Padding(1);
            this.excel.Name = "excel";
            this.excel.Size = new System.Drawing.Size(265, 50);
            this.excel.TabIndex = 72;
            this.excel.Text = "Descargar en excel";
            this.excel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.excel.UseVisualStyleBackColor = false;
            this.excel.Click += new System.EventHandler(this.excel_Click);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(44)))), ((int)(((byte)(64)))));
            this.label5.Location = new System.Drawing.Point(21, 368);
            this.label5.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(192, 31);
            this.label5.TabIndex = 104;
            this.label5.Text = "Telefono";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // txttelefono
            // 
            this.txttelefono.BackColor = System.Drawing.SystemColors.Info;
            this.txttelefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttelefono.Location = new System.Drawing.Point(25, 400);
            this.txttelefono.Margin = new System.Windows.Forms.Padding(1);
            this.txttelefono.Name = "txttelefono";
            this.txttelefono.Size = new System.Drawing.Size(399, 26);
            this.txttelefono.TabIndex = 105;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(44)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(23, 290);
            this.label4.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(192, 31);
            this.label4.TabIndex = 102;
            this.label4.Text = "Correo";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // ncompleto
            // 
            this.ncompleto.BackColor = System.Drawing.SystemColors.Info;
            this.ncompleto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ncompleto.Location = new System.Drawing.Point(25, 249);
            this.ncompleto.Margin = new System.Windows.Forms.Padding(1);
            this.ncompleto.Name = "ncompleto";
            this.ncompleto.Size = new System.Drawing.Size(399, 26);
            this.ncompleto.TabIndex = 101;
            this.ncompleto.TextChanged += new System.EventHandler(this.ncompleto_TextChanged);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(44)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(21, 217);
            this.label3.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(203, 31);
            this.label3.TabIndex = 100;
            this.label3.Text = "Nombre Completo";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // txtdocumento
            // 
            this.txtdocumento.BackColor = System.Drawing.SystemColors.Info;
            this.txtdocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdocumento.Location = new System.Drawing.Point(25, 181);
            this.txtdocumento.Margin = new System.Windows.Forms.Padding(1);
            this.txtdocumento.Name = "txtdocumento";
            this.txtdocumento.Size = new System.Drawing.Size(399, 26);
            this.txtdocumento.TabIndex = 99;
            this.txtdocumento.TextChanged += new System.EventHandler(this.txtdocumento_TextChanged);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(44)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(23, 144);
            this.label2.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(244, 31);
            this.label2.TabIndex = 98;
            this.label2.Text = "No. Documento";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // correo2
            // 
            this.correo2.BackColor = System.Drawing.SystemColors.Info;
            this.correo2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.correo2.Location = new System.Drawing.Point(25, 322);
            this.correo2.Margin = new System.Windows.Forms.Padding(1);
            this.correo2.Name = "correo2";
            this.correo2.Size = new System.Drawing.Size(399, 26);
            this.correo2.TabIndex = 103;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(44)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(23, 672);
            this.label1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 31);
            this.label1.TabIndex = 122;
            this.label1.Text = "Calle";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // calletxt
            // 
            this.calletxt.BackColor = System.Drawing.SystemColors.Info;
            this.calletxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.calletxt.Location = new System.Drawing.Point(27, 704);
            this.calletxt.Margin = new System.Windows.Forms.Padding(1);
            this.calletxt.Name = "calletxt";
            this.calletxt.Size = new System.Drawing.Size(184, 26);
            this.calletxt.TabIndex = 123;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(44)))), ((int)(((byte)(64)))));
            this.label6.Location = new System.Drawing.Point(24, 594);
            this.label6.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(192, 31);
            this.label6.TabIndex = 120;
            this.label6.Text = "Ciudad";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // paistxt
            // 
            this.paistxt.BackColor = System.Drawing.SystemColors.Info;
            this.paistxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paistxt.Location = new System.Drawing.Point(27, 553);
            this.paistxt.Margin = new System.Windows.Forms.Padding(1);
            this.paistxt.Name = "paistxt";
            this.paistxt.Size = new System.Drawing.Size(184, 26);
            this.paistxt.TabIndex = 119;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(44)))), ((int)(((byte)(64)))));
            this.label7.Location = new System.Drawing.Point(23, 521);
            this.label7.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(203, 31);
            this.label7.TabIndex = 118;
            this.label7.Text = "País";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // ciudadtxt
            // 
            this.ciudadtxt.BackColor = System.Drawing.SystemColors.Info;
            this.ciudadtxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ciudadtxt.Location = new System.Drawing.Point(27, 626);
            this.ciudadtxt.Margin = new System.Windows.Forms.Padding(1);
            this.ciudadtxt.Name = "ciudadtxt";
            this.ciudadtxt.Size = new System.Drawing.Size(184, 26);
            this.ciudadtxt.TabIndex = 121;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(44)))), ((int)(((byte)(64)))));
            this.label10.Location = new System.Drawing.Point(236, 672);
            this.label10.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(192, 31);
            this.label10.TabIndex = 127;
            this.label10.Text = "Código Postal";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // codigopostaltxt
            // 
            this.codigopostaltxt.BackColor = System.Drawing.SystemColors.Info;
            this.codigopostaltxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codigopostaltxt.Location = new System.Drawing.Point(240, 704);
            this.codigopostaltxt.Margin = new System.Windows.Forms.Padding(1);
            this.codigopostaltxt.Name = "codigopostaltxt";
            this.codigopostaltxt.Size = new System.Drawing.Size(184, 26);
            this.codigopostaltxt.TabIndex = 128;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(44)))), ((int)(((byte)(64)))));
            this.label11.Location = new System.Drawing.Point(237, 594);
            this.label11.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(192, 31);
            this.label11.TabIndex = 125;
            this.label11.Text = "Sector";
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // provinciatxt
            // 
            this.provinciatxt.BackColor = System.Drawing.SystemColors.Info;
            this.provinciatxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.provinciatxt.Location = new System.Drawing.Point(240, 553);
            this.provinciatxt.Margin = new System.Windows.Forms.Padding(1);
            this.provinciatxt.Name = "provinciatxt";
            this.provinciatxt.Size = new System.Drawing.Size(184, 26);
            this.provinciatxt.TabIndex = 124;
            // 
            // sectortxt
            // 
            this.sectortxt.BackColor = System.Drawing.SystemColors.Info;
            this.sectortxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sectortxt.Location = new System.Drawing.Point(240, 626);
            this.sectortxt.Margin = new System.Windows.Forms.Padding(1);
            this.sectortxt.Name = "sectortxt";
            this.sectortxt.Size = new System.Drawing.Size(184, 26);
            this.sectortxt.TabIndex = 126;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(44)))), ((int)(((byte)(64)))));
            this.label13.Location = new System.Drawing.Point(237, 521);
            this.label13.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(203, 31);
            this.label13.TabIndex = 129;
            this.label13.Text = "Provincia";
            this.label13.Click += new System.EventHandler(this.label13_Click);
            // 
            // iddireciontxt
            // 
            this.iddireciontxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iddireciontxt.Location = new System.Drawing.Point(437, 129);
            this.iddireciontxt.Margin = new System.Windows.Forms.Padding(1);
            this.iddireciontxt.Name = "iddireciontxt";
            this.iddireciontxt.Size = new System.Drawing.Size(31, 30);
            this.iddireciontxt.TabIndex = 130;
            this.iddireciontxt.Text = "0";
            this.iddireciontxt.Visible = false;
            // 
            // fclientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1753, 785);
            this.Controls.Add(this.iddireciontxt);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.codigopostaltxt);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.provinciatxt);
            this.Controls.Add(this.sectortxt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.calletxt);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.paistxt);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.ciudadtxt);
            this.Controls.Add(this.excel);
            this.Controls.Add(this.dgdata);
            this.Controls.Add(this.txtindice);
            this.Controls.Add(this.txtid);
            this.Controls.Add(this.btneliminar);
            this.Controls.Add(this.btnlimpiar);
            this.Controls.Add(this.btnguardar);
            this.Controls.Add(this.estado2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txttelefono);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ncompleto);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtdocumento);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.correo2);
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "fclientes";
            this.Load += new System.EventHandler(this.fclientes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgdata)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgdata;
        private System.Windows.Forms.TextBox txtindice;
        private System.Windows.Forms.TextBox txtid;
        private System.Windows.Forms.Button btneliminar;
        private System.Windows.Forms.Button btnlimpiar;
        private System.Windows.Forms.Button btnguardar;
        private System.Windows.Forms.ComboBox estado2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox busquedacombo;
        private FontAwesome.Sharp.IconButton btnlimpiarbuscador;
        private System.Windows.Forms.TextBox busqueda;
        private FontAwesome.Sharp.IconButton btnbusqueda;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txttelefono;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox ncompleto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtdocumento;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox correo2;
        private FontAwesome.Sharp.IconButton excel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox calletxt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox paistxt;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox ciudadtxt;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox codigopostaltxt;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox provinciatxt;
        private System.Windows.Forms.TextBox sectortxt;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox iddireciontxt;
        private System.Windows.Forms.DataGridViewButtonColumn btnseleccionar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Documento;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreCompleto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Correo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Telefono;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdDireccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pais;
        private System.Windows.Forms.DataGridViewTextBoxColumn Provincia;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ciudad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sector;
        private System.Windows.Forms.DataGridViewTextBoxColumn Calle;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoPostal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Direccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
        private System.Windows.Forms.DataGridViewTextBoxColumn EstadoValor;
    }
}