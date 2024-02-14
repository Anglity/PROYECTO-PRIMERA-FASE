namespace proyecto
{
    partial class fpedido
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.checkedListBoxRecetas = new System.Windows.Forms.CheckedListBox();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.dgdata = new System.Windows.Forms.DataGridView();
            this.btnseleccionar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdCategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Categoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Stock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnidadMedida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EstadoValor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.listBoxProduccionesAplazadas = new System.Windows.Forms.ListBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.listabasededatos = new System.Windows.Forms.ListBox();
            this.btnEliminarYMarcarManejada = new FontAwesome.Sharp.IconButton();
            this.btnEnviarCorreoDetalles = new FontAwesome.Sharp.IconButton();
            this.checkedListBoxPedidosAplazados = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnEnviarCorreoPedidosAplazados = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgdata)).BeginInit();
            this.SuspendLayout();
            // 
            // checkedListBoxRecetas
            // 
            this.checkedListBoxRecetas.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.checkedListBoxRecetas.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.checkedListBoxRecetas.FormattingEnabled = true;
            this.checkedListBoxRecetas.Location = new System.Drawing.Point(9, 37);
            this.checkedListBoxRecetas.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.checkedListBoxRecetas.Name = "checkedListBoxRecetas";
            this.checkedListBoxRecetas.Size = new System.Drawing.Size(218, 292);
            this.checkedListBoxRecetas.TabIndex = 0;
            // 
            // iconButton1
            // 
            this.iconButton1.BackColor = System.Drawing.Color.MediumBlue;
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.Truck;
            this.iconButton1.IconColor = System.Drawing.Color.White;
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton1.Location = new System.Drawing.Point(52, 361);
            this.iconButton1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Size = new System.Drawing.Size(56, 59);
            this.iconButton1.TabIndex = 1;
            this.iconButton1.UseVisualStyleBackColor = false;
            this.iconButton1.Click += new System.EventHandler(this.iconButton1_Click);
            // 
            // dgdata
            // 
            this.dgdata.AllowUserToAddRows = false;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            this.dgdata.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dgdata.BackgroundColor = System.Drawing.SystemColors.ControlDark;
            this.dgdata.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            dataGridViewCellStyle8.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgdata.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgdata.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgdata.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.btnseleccionar,
            this.Id,
            this.Codigo,
            this.Nombre,
            this.Descripcion,
            this.IdCategoria,
            this.Categoria,
            this.Stock,
            this.PrecioCompra,
            this.PrecioVenta,
            this.Estado,
            this.UnidadMedida,
            this.EstadoValor});
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.Red;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgdata.DefaultCellStyle = dataGridViewCellStyle10;
            this.dgdata.Location = new System.Drawing.Point(10, 442);
            this.dgdata.MultiSelect = false;
            this.dgdata.Name = "dgdata";
            this.dgdata.ReadOnly = true;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgdata.RowHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dgdata.RowHeadersWidth = 102;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.Black;
            this.dgdata.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.dgdata.RowTemplate.Height = 28;
            this.dgdata.Size = new System.Drawing.Size(1202, 283);
            this.dgdata.TabIndex = 114;
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
            // Codigo
            // 
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Codigo.DefaultCellStyle = dataGridViewCellStyle9;
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
            // Descripcion
            // 
            this.Descripcion.HeaderText = "Descripcion";
            this.Descripcion.MinimumWidth = 12;
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.ReadOnly = true;
            this.Descripcion.Width = 150;
            // 
            // IdCategoria
            // 
            this.IdCategoria.HeaderText = "IdCategoria";
            this.IdCategoria.MinimumWidth = 12;
            this.IdCategoria.Name = "IdCategoria";
            this.IdCategoria.ReadOnly = true;
            this.IdCategoria.Visible = false;
            this.IdCategoria.Width = 150;
            // 
            // Categoria
            // 
            this.Categoria.HeaderText = "Categoria";
            this.Categoria.MinimumWidth = 12;
            this.Categoria.Name = "Categoria";
            this.Categoria.ReadOnly = true;
            this.Categoria.Width = 150;
            // 
            // Stock
            // 
            this.Stock.HeaderText = "Stock";
            this.Stock.MinimumWidth = 12;
            this.Stock.Name = "Stock";
            this.Stock.ReadOnly = true;
            this.Stock.Width = 125;
            // 
            // PrecioCompra
            // 
            this.PrecioCompra.HeaderText = "Precio Compra";
            this.PrecioCompra.MinimumWidth = 12;
            this.PrecioCompra.Name = "PrecioCompra";
            this.PrecioCompra.ReadOnly = true;
            this.PrecioCompra.Width = 200;
            // 
            // PrecioVenta
            // 
            this.PrecioVenta.HeaderText = "Precio Venta";
            this.PrecioVenta.MinimumWidth = 12;
            this.PrecioVenta.Name = "PrecioVenta";
            this.PrecioVenta.ReadOnly = true;
            this.PrecioVenta.Width = 200;
            // 
            // Estado
            // 
            this.Estado.HeaderText = "Estado";
            this.Estado.MinimumWidth = 12;
            this.Estado.Name = "Estado";
            this.Estado.ReadOnly = true;
            this.Estado.Width = 125;
            // 
            // UnidadMedida
            // 
            this.UnidadMedida.HeaderText = "UnidadMedida";
            this.UnidadMedida.MinimumWidth = 6;
            this.UnidadMedida.Name = "UnidadMedida";
            this.UnidadMedida.ReadOnly = true;
            this.UnidadMedida.Width = 200;
            // 
            // EstadoValor
            // 
            this.EstadoValor.HeaderText = "EstadoValor";
            this.EstadoValor.MinimumWidth = 12;
            this.EstadoValor.Name = "EstadoValor";
            this.EstadoValor.ReadOnly = true;
            this.EstadoValor.Visible = false;
            this.EstadoValor.Width = 200;
            // 
            // listBoxProduccionesAplazadas
            // 
            this.listBoxProduccionesAplazadas.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.listBoxProduccionesAplazadas.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.listBoxProduccionesAplazadas.FormattingEnabled = true;
            this.listBoxProduccionesAplazadas.ItemHeight = 17;
            this.listBoxProduccionesAplazadas.Location = new System.Drawing.Point(260, 31);
            this.listBoxProduccionesAplazadas.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.listBoxProduccionesAplazadas.Name = "listBoxProduccionesAplazadas";
            this.listBoxProduccionesAplazadas.Size = new System.Drawing.Size(382, 293);
            this.listBoxProduccionesAplazadas.TabIndex = 115;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // listabasededatos
            // 
            this.listabasededatos.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.listabasededatos.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.listabasededatos.FormattingEnabled = true;
            this.listabasededatos.ItemHeight = 17;
            this.listabasededatos.Location = new System.Drawing.Point(1154, 37);
            this.listabasededatos.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.listabasededatos.Name = "listabasededatos";
            this.listabasededatos.Size = new System.Drawing.Size(312, 293);
            this.listabasededatos.TabIndex = 117;
            // 
            // btnEliminarYMarcarManejada
            // 
            this.btnEliminarYMarcarManejada.BackColor = System.Drawing.Color.MediumBlue;
            this.btnEliminarYMarcarManejada.FlatAppearance.BorderSize = 10;
            this.btnEliminarYMarcarManejada.IconChar = FontAwesome.Sharp.IconChar.Trash;
            this.btnEliminarYMarcarManejada.IconColor = System.Drawing.Color.White;
            this.btnEliminarYMarcarManejada.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnEliminarYMarcarManejada.Location = new System.Drawing.Point(1286, 361);
            this.btnEliminarYMarcarManejada.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnEliminarYMarcarManejada.Name = "btnEliminarYMarcarManejada";
            this.btnEliminarYMarcarManejada.Size = new System.Drawing.Size(56, 59);
            this.btnEliminarYMarcarManejada.TabIndex = 118;
            this.btnEliminarYMarcarManejada.UseVisualStyleBackColor = false;
            this.btnEliminarYMarcarManejada.Click += new System.EventHandler(this.btnEliminarYMarcarManejada_Click);
            // 
            // btnEnviarCorreoDetalles
            // 
            this.btnEnviarCorreoDetalles.BackColor = System.Drawing.Color.MediumBlue;
            this.btnEnviarCorreoDetalles.IconChar = FontAwesome.Sharp.IconChar.MailBulk;
            this.btnEnviarCorreoDetalles.IconColor = System.Drawing.Color.White;
            this.btnEnviarCorreoDetalles.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnEnviarCorreoDetalles.Location = new System.Drawing.Point(411, 361);
            this.btnEnviarCorreoDetalles.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnEnviarCorreoDetalles.Name = "btnEnviarCorreoDetalles";
            this.btnEnviarCorreoDetalles.Size = new System.Drawing.Size(56, 59);
            this.btnEnviarCorreoDetalles.TabIndex = 119;
            this.btnEnviarCorreoDetalles.UseVisualStyleBackColor = false;
            this.btnEnviarCorreoDetalles.Click += new System.EventHandler(this.btnEnviarCorreoDetalles_Click);
            // 
            // checkedListBoxPedidosAplazados
            // 
            this.checkedListBoxPedidosAplazados.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.checkedListBoxPedidosAplazados.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkedListBoxPedidosAplazados.FormattingEnabled = true;
            this.checkedListBoxPedidosAplazados.Location = new System.Drawing.Point(665, 37);
            this.checkedListBoxPedidosAplazados.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.checkedListBoxPedidosAplazados.Name = "checkedListBoxPedidosAplazados";
            this.checkedListBoxPedidosAplazados.Size = new System.Drawing.Size(470, 292);
            this.checkedListBoxPedidosAplazados.TabIndex = 120;
            this.checkedListBoxPedidosAplazados.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBoxPedidosAplazados_ItemCheck);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(66, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 17);
            this.label1.TabIndex = 121;
            this.label1.Text = "Lista de Recetas";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(358, 7);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(249, 17);
            this.label2.TabIndex = 122;
            this.label2.Text = "Lista de Porducciones Aplazadas";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(854, 7);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(209, 17);
            this.label3.TabIndex = 123;
            this.label3.Text = "Lista de Pedidos Aplazados";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(1240, 7);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(169, 17);
            this.label4.TabIndex = 124;
            this.label4.Text = "Lista de Producciones";
            // 
            // btnEnviarCorreoPedidosAplazados
            // 
            this.btnEnviarCorreoPedidosAplazados.BackColor = System.Drawing.Color.MediumBlue;
            this.btnEnviarCorreoPedidosAplazados.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnEnviarCorreoPedidosAplazados.FlatAppearance.BorderSize = 10;
            this.btnEnviarCorreoPedidosAplazados.IconChar = FontAwesome.Sharp.IconChar.MailBulk;
            this.btnEnviarCorreoPedidosAplazados.IconColor = System.Drawing.Color.White;
            this.btnEnviarCorreoPedidosAplazados.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnEnviarCorreoPedidosAplazados.Location = new System.Drawing.Point(857, 361);
            this.btnEnviarCorreoPedidosAplazados.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnEnviarCorreoPedidosAplazados.Name = "btnEnviarCorreoPedidosAplazados";
            this.btnEnviarCorreoPedidosAplazados.Size = new System.Drawing.Size(56, 59);
            this.btnEnviarCorreoPedidosAplazados.TabIndex = 125;
            this.btnEnviarCorreoPedidosAplazados.UseVisualStyleBackColor = false;
            this.btnEnviarCorreoPedidosAplazados.Click += new System.EventHandler(this.btnEnviarCorreoPedidosAplazados_Click_1);
            // 
            // fpedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuBar;
            this.ClientSize = new System.Drawing.Size(1477, 500);
            this.Controls.Add(this.btnEnviarCorreoPedidosAplazados);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkedListBoxPedidosAplazados);
            this.Controls.Add(this.btnEnviarCorreoDetalles);
            this.Controls.Add(this.btnEliminarYMarcarManejada);
            this.Controls.Add(this.listabasededatos);
            this.Controls.Add(this.listBoxProduccionesAplazadas);
            this.Controls.Add(this.dgdata);
            this.Controls.Add(this.iconButton1);
            this.Controls.Add(this.checkedListBoxRecetas);
            this.ForeColor = System.Drawing.Color.Red;
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "fpedido";
            this.Text = " ";
            this.Load += new System.EventHandler(this.fpedido_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgdata)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox checkedListBoxRecetas;
        private FontAwesome.Sharp.IconButton iconButton1;
        private System.Windows.Forms.DataGridView dgdata;
        private System.Windows.Forms.ListBox listBoxProduccionesAplazadas;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ListBox listabasededatos;
        private FontAwesome.Sharp.IconButton btnEliminarYMarcarManejada;
        private FontAwesome.Sharp.IconButton btnEnviarCorreoDetalles;
        private System.Windows.Forms.CheckedListBox checkedListBoxPedidosAplazados;
        private System.Windows.Forms.DataGridViewButtonColumn btnseleccionar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn Categoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn Stock;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnidadMedida;
        private System.Windows.Forms.DataGridViewTextBoxColumn EstadoValor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private FontAwesome.Sharp.IconButton btnEnviarCorreoPedidosAplazados;
    }
}