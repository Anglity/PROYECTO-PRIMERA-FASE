using FontAwesome;

namespace proyecto
{
    partial class inicio3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(inicio3));
            this.panel1 = new System.Windows.Forms.Panel();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.menuinicio = new FontAwesome.Sharp.IconMenuItem();
            this.menusuario = new FontAwesome.Sharp.IconMenuItem();
            this.menuproducto = new FontAwesome.Sharp.IconMenuItem();
            this.categoríasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuproduccion = new FontAwesome.Sharp.IconMenuItem();
            this.cREARToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pedidoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuventa = new FontAwesome.Sharp.IconMenuItem();
            this.detalleDeVentaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ventaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menucompra = new FontAwesome.Sharp.IconMenuItem();
            this.CompraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detalleCompraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menucliente = new FontAwesome.Sharp.IconMenuItem();
            this.menuempleado = new FontAwesome.Sharp.IconMenuItem();
            this.menuinventario = new FontAwesome.Sharp.IconMenuItem();
            this.menuproveedores = new FontAwesome.Sharp.IconMenuItem();
            this.menureporte = new FontAwesome.Sharp.IconMenuItem();
            this.detalleVentaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detalleCompraToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.reporteProduccionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menugrafica = new FontAwesome.Sharp.IconMenuItem();
            this.mnegocio = new FontAwesome.Sharp.IconMenuItem();
            this.menunegocio = new System.Windows.Forms.ToolStripMenuItem();
            this.menusacercade = new FontAwesome.Sharp.IconMenuItem();
            this.menusalir = new FontAwesome.Sharp.IconMenuItem();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelContadorNotificaciones = new System.Windows.Forms.Label();
            this.notificacion = new FontAwesome.Sharp.IconButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.iconMenuItem2 = new FontAwesome.Sharp.IconMenuItem();
            this.produccionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menu.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(201, 93);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1364, 620);
            this.panel1.TabIndex = 45;
            // 
            // menu
            // 
            this.menu.AutoSize = false;
            this.menu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(44)))), ((int)(((byte)(64)))));
            this.menu.Dock = System.Windows.Forms.DockStyle.Left;
            this.menu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menu.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuinicio,
            this.menusuario,
            this.menuproducto,
            this.menuproduccion,
            this.menuventa,
            this.menucompra,
            this.menucliente,
            this.menuempleado,
            this.menuinventario,
            this.menuproveedores,
            this.menureporte,
            this.menugrafica,
            this.mnegocio,
            this.menusacercade,
            this.menusalir});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Padding = new System.Windows.Forms.Padding(27, 123, 0, 0);
            this.menu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menu.Size = new System.Drawing.Size(201, 713);
            this.menu.TabIndex = 46;
            this.menu.Text = "menuStrip1";
            // 
            // menuinicio
            // 
            this.menuinicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuinicio.ForeColor = System.Drawing.Color.Silver;
            this.menuinicio.IconChar = FontAwesome.Sharp.IconChar.HomeUser;
            this.menuinicio.IconColor = System.Drawing.Color.Red;
            this.menuinicio.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuinicio.IconSize = 30;
            this.menuinicio.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.menuinicio.Name = "menuinicio";
            this.menuinicio.Size = new System.Drawing.Size(173, 44);
            this.menuinicio.Text = "Inicio";
            this.menuinicio.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.menuinicio.Click += new System.EventHandler(this.menuinicio_Click);
            // 
            // menusuario
            // 
            this.menusuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menusuario.ForeColor = System.Drawing.Color.Silver;
            this.menusuario.IconChar = FontAwesome.Sharp.IconChar.UserGear;
            this.menusuario.IconColor = System.Drawing.Color.Red;
            this.menusuario.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menusuario.IconSize = 30;
            this.menusuario.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.menusuario.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menusuario.Name = "menusuario";
            this.menusuario.Size = new System.Drawing.Size(173, 34);
            this.menusuario.Text = "Usuario";
            this.menusuario.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.menusuario.Click += new System.EventHandler(this.iconMenuItem15_Click);
            // 
            // menuproducto
            // 
            this.menuproducto.BackColor = System.Drawing.Color.Silver;
            this.menuproducto.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.categoríasToolStripMenuItem});
            this.menuproducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuproducto.ForeColor = System.Drawing.Color.Silver;
            this.menuproducto.IconChar = FontAwesome.Sharp.IconChar.BoxOpen;
            this.menuproducto.IconColor = System.Drawing.Color.Red;
            this.menuproducto.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuproducto.IconSize = 30;
            this.menuproducto.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.menuproducto.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuproducto.Name = "menuproducto";
            this.menuproducto.Size = new System.Drawing.Size(173, 34);
            this.menuproducto.Text = "Productos";
            this.menuproducto.Click += new System.EventHandler(this.menuproducto_Click);
            // 
            // categoríasToolStripMenuItem
            // 
            this.categoríasToolStripMenuItem.Name = "categoríasToolStripMenuItem";
            this.categoríasToolStripMenuItem.Size = new System.Drawing.Size(227, 34);
            this.categoríasToolStripMenuItem.Text = "Categorías";
            this.categoríasToolStripMenuItem.Click += new System.EventHandler(this.categoríasToolStripMenuItem_Click);
            // 
            // menuproduccion
            // 
            this.menuproduccion.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cREARToolStripMenuItem,
            this.pedidoToolStripMenuItem});
            this.menuproduccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuproduccion.ForeColor = System.Drawing.Color.Silver;
            this.menuproduccion.IconChar = FontAwesome.Sharp.IconChar.Tractor;
            this.menuproduccion.IconColor = System.Drawing.Color.Red;
            this.menuproduccion.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuproduccion.IconSize = 30;
            this.menuproduccion.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.menuproduccion.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuproduccion.Name = "menuproduccion";
            this.menuproduccion.Size = new System.Drawing.Size(173, 34);
            this.menuproduccion.Text = "Producción";
            this.menuproduccion.Click += new System.EventHandler(this.iconMenuItem1_Click_1);
            // 
            // cREARToolStripMenuItem
            // 
            this.cREARToolStripMenuItem.Name = "cREARToolStripMenuItem";
            this.cREARToolStripMenuItem.Size = new System.Drawing.Size(254, 34);
            this.cREARToolStripMenuItem.Text = "Crear Receta";
            this.cREARToolStripMenuItem.Click += new System.EventHandler(this.cREARToolStripMenuItem_Click);
            // 
            // pedidoToolStripMenuItem
            // 
            this.pedidoToolStripMenuItem.Name = "pedidoToolStripMenuItem";
            this.pedidoToolStripMenuItem.Size = new System.Drawing.Size(254, 34);
            this.pedidoToolStripMenuItem.Text = "Pedido";
            this.pedidoToolStripMenuItem.Click += new System.EventHandler(this.pedidoToolStripMenuItem_Click);
            // 
            // menuventa
            // 
            this.menuventa.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.detalleDeVentaToolStripMenuItem,
            this.ventaToolStripMenuItem});
            this.menuventa.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuventa.ForeColor = System.Drawing.Color.Silver;
            this.menuventa.IconChar = FontAwesome.Sharp.IconChar.Tag;
            this.menuventa.IconColor = System.Drawing.Color.Red;
            this.menuventa.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuventa.IconSize = 30;
            this.menuventa.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.menuventa.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuventa.Name = "menuventa";
            this.menuventa.Size = new System.Drawing.Size(173, 34);
            this.menuventa.Text = "Venta";
            this.menuventa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // detalleDeVentaToolStripMenuItem
            // 
            this.detalleDeVentaToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.detalleDeVentaToolStripMenuItem.Name = "detalleDeVentaToolStripMenuItem";
            this.detalleDeVentaToolStripMenuItem.Size = new System.Drawing.Size(255, 30);
            this.detalleDeVentaToolStripMenuItem.Text = "Detalle de venta";
            this.detalleDeVentaToolStripMenuItem.Click += new System.EventHandler(this.detalleDeVentaToolStripMenuItem_Click);
            // 
            // ventaToolStripMenuItem
            // 
            this.ventaToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ventaToolStripMenuItem.Name = "ventaToolStripMenuItem";
            this.ventaToolStripMenuItem.Size = new System.Drawing.Size(255, 30);
            this.ventaToolStripMenuItem.Text = "Venta";
            this.ventaToolStripMenuItem.Click += new System.EventHandler(this.ventaToolStripMenuItem_Click);
            // 
            // menucompra
            // 
            this.menucompra.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CompraToolStripMenuItem,
            this.detalleCompraToolStripMenuItem});
            this.menucompra.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menucompra.ForeColor = System.Drawing.Color.Silver;
            this.menucompra.IconChar = FontAwesome.Sharp.IconChar.DollyFlatbed;
            this.menucompra.IconColor = System.Drawing.Color.Red;
            this.menucompra.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menucompra.IconSize = 30;
            this.menucompra.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.menucompra.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menucompra.Name = "menucompra";
            this.menucompra.Size = new System.Drawing.Size(173, 34);
            this.menucompra.Text = "Compras";
            this.menucompra.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CompraToolStripMenuItem
            // 
            this.CompraToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CompraToolStripMenuItem.Name = "CompraToolStripMenuItem";
            this.CompraToolStripMenuItem.Size = new System.Drawing.Size(248, 30);
            this.CompraToolStripMenuItem.Text = "Compra";
            this.CompraToolStripMenuItem.Click += new System.EventHandler(this.detalleDeCompraToolStripMenuItem_Click);
            // 
            // detalleCompraToolStripMenuItem
            // 
            this.detalleCompraToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.detalleCompraToolStripMenuItem.Name = "detalleCompraToolStripMenuItem";
            this.detalleCompraToolStripMenuItem.Size = new System.Drawing.Size(248, 30);
            this.detalleCompraToolStripMenuItem.Text = "Detalle Compra";
            this.detalleCompraToolStripMenuItem.Click += new System.EventHandler(this.detalleCompraToolStripMenuItem_Click);
            // 
            // menucliente
            // 
            this.menucliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menucliente.ForeColor = System.Drawing.Color.Silver;
            this.menucliente.IconChar = FontAwesome.Sharp.IconChar.Users;
            this.menucliente.IconColor = System.Drawing.Color.Red;
            this.menucliente.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menucliente.IconSize = 30;
            this.menucliente.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.menucliente.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menucliente.Name = "menucliente";
            this.menucliente.Size = new System.Drawing.Size(173, 34);
            this.menucliente.Text = "Clientes";
            this.menucliente.Click += new System.EventHandler(this.menucliente_Click_1);
            // 
            // menuempleado
            // 
            this.menuempleado.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuempleado.ForeColor = System.Drawing.Color.Silver;
            this.menuempleado.IconChar = FontAwesome.Sharp.IconChar.UserTie;
            this.menuempleado.IconColor = System.Drawing.Color.Red;
            this.menuempleado.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuempleado.IconSize = 30;
            this.menuempleado.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.menuempleado.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuempleado.Name = "menuempleado";
            this.menuempleado.Size = new System.Drawing.Size(173, 34);
            this.menuempleado.Text = "Empleados";
            this.menuempleado.Click += new System.EventHandler(this.menucliente_Click);
            // 
            // menuinventario
            // 
            this.menuinventario.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuinventario.ForeColor = System.Drawing.Color.Silver;
            this.menuinventario.IconChar = FontAwesome.Sharp.IconChar.Store;
            this.menuinventario.IconColor = System.Drawing.Color.Red;
            this.menuinventario.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuinventario.IconSize = 30;
            this.menuinventario.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.menuinventario.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuinventario.Name = "menuinventario";
            this.menuinventario.Size = new System.Drawing.Size(173, 34);
            this.menuinventario.Text = "Inventario";
            this.menuinventario.Click += new System.EventHandler(this.menuinventario_Click);
            // 
            // menuproveedores
            // 
            this.menuproveedores.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuproveedores.ForeColor = System.Drawing.Color.Silver;
            this.menuproveedores.IconChar = FontAwesome.Sharp.IconChar.IdCard;
            this.menuproveedores.IconColor = System.Drawing.Color.Red;
            this.menuproveedores.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuproveedores.IconSize = 30;
            this.menuproveedores.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.menuproveedores.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuproveedores.Name = "menuproveedores";
            this.menuproveedores.Size = new System.Drawing.Size(173, 34);
            this.menuproveedores.Text = "Proveedor";
            this.menuproveedores.Click += new System.EventHandler(this.menuproveedores_Click);
            // 
            // menureporte
            // 
            this.menureporte.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.detalleVentaToolStripMenuItem,
            this.detalleCompraToolStripMenuItem1,
            this.reporteProduccionToolStripMenuItem});
            this.menureporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menureporte.ForeColor = System.Drawing.Color.Silver;
            this.menureporte.IconChar = FontAwesome.Sharp.IconChar.BarChart;
            this.menureporte.IconColor = System.Drawing.Color.Red;
            this.menureporte.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menureporte.IconSize = 30;
            this.menureporte.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.menureporte.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menureporte.Name = "menureporte";
            this.menureporte.Size = new System.Drawing.Size(173, 34);
            this.menureporte.Text = "Reportes";
            this.menureporte.Click += new System.EventHandler(this.menureporte_Click);
            // 
            // detalleVentaToolStripMenuItem
            // 
            this.detalleVentaToolStripMenuItem.Name = "detalleVentaToolStripMenuItem";
            this.detalleVentaToolStripMenuItem.Size = new System.Drawing.Size(340, 34);
            this.detalleVentaToolStripMenuItem.Text = "Reporte Venta";
            this.detalleVentaToolStripMenuItem.Click += new System.EventHandler(this.detalleVentaToolStripMenuItem_Click);
            // 
            // detalleCompraToolStripMenuItem1
            // 
            this.detalleCompraToolStripMenuItem1.Name = "detalleCompraToolStripMenuItem1";
            this.detalleCompraToolStripMenuItem1.Size = new System.Drawing.Size(340, 34);
            this.detalleCompraToolStripMenuItem1.Text = "Reporte Compra";
            this.detalleCompraToolStripMenuItem1.Click += new System.EventHandler(this.detalleCompraToolStripMenuItem1_Click);
            // 
            // reporteProduccionToolStripMenuItem
            // 
            this.reporteProduccionToolStripMenuItem.Name = "reporteProduccionToolStripMenuItem";
            this.reporteProduccionToolStripMenuItem.Size = new System.Drawing.Size(340, 34);
            this.reporteProduccionToolStripMenuItem.Text = "Reporte Produccion ";
            this.reporteProduccionToolStripMenuItem.Click += new System.EventHandler(this.reporteProduccionToolStripMenuItem_Click);
            // 
            // menugrafica
            // 
            this.menugrafica.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menugrafica.ForeColor = System.Drawing.Color.Silver;
            this.menugrafica.IconChar = FontAwesome.Sharp.IconChar.ChartPie;
            this.menugrafica.IconColor = System.Drawing.Color.Red;
            this.menugrafica.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menugrafica.IconSize = 30;
            this.menugrafica.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.menugrafica.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menugrafica.Name = "menugrafica";
            this.menugrafica.Size = new System.Drawing.Size(173, 34);
            this.menugrafica.Text = "Gráficas";
            this.menugrafica.Click += new System.EventHandler(this.menugrafica_Click);
            // 
            // mnegocio
            // 
            this.mnegocio.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menunegocio});
            this.mnegocio.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnegocio.ForeColor = System.Drawing.Color.Silver;
            this.mnegocio.IconChar = FontAwesome.Sharp.IconChar.Gear;
            this.mnegocio.IconColor = System.Drawing.Color.Red;
            this.mnegocio.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.mnegocio.IconSize = 30;
            this.mnegocio.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.mnegocio.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnegocio.Name = "mnegocio";
            this.mnegocio.Size = new System.Drawing.Size(173, 34);
            this.mnegocio.Text = "Negocio";
            // 
            // menunegocio
            // 
            this.menunegocio.Name = "menunegocio";
            this.menunegocio.Size = new System.Drawing.Size(199, 34);
            this.menunegocio.Text = "Negocio";
            this.menunegocio.Click += new System.EventHandler(this.menunegocio_Click);
            // 
            // menusacercade
            // 
            this.menusacercade.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menusacercade.ForeColor = System.Drawing.Color.Silver;
            this.menusacercade.IconChar = FontAwesome.Sharp.IconChar.CircleInfo;
            this.menusacercade.IconColor = System.Drawing.Color.Red;
            this.menusacercade.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menusacercade.IconSize = 30;
            this.menusacercade.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.menusacercade.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menusacercade.Name = "menusacercade";
            this.menusacercade.Size = new System.Drawing.Size(173, 34);
            this.menusacercade.Text = "Acerca de";
            this.menusacercade.Click += new System.EventHandler(this.menusacercade_Click);
            // 
            // menusalir
            // 
            this.menusalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menusalir.ForeColor = System.Drawing.Color.Silver;
            this.menusalir.IconChar = FontAwesome.Sharp.IconChar.ArrowRightFromBracket;
            this.menusalir.IconColor = System.Drawing.Color.Red;
            this.menusalir.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menusalir.IconSize = 30;
            this.menusalir.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.menusalir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menusalir.Name = "menusalir";
            this.menusalir.Size = new System.Drawing.Size(173, 36);
            this.menusalir.Text = "Salir";
            this.menusalir.Click += new System.EventHandler(this.iconMenuItem1_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(1105, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 25);
            this.label3.TabIndex = 44;
            this.label3.Text = "lblusuario";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.labelContadorNotificaciones);
            this.panel2.Controls.Add(this.notificacion);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(201, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1364, 93);
            this.panel2.TabIndex = 47;
            // 
            // labelContadorNotificaciones
            // 
            this.labelContadorNotificaciones.AutoSize = true;
            this.labelContadorNotificaciones.BackColor = System.Drawing.Color.Snow;
            this.labelContadorNotificaciones.ForeColor = System.Drawing.Color.SaddleBrown;
            this.labelContadorNotificaciones.Location = new System.Drawing.Point(1080, 15);
            this.labelContadorNotificaciones.Name = "labelContadorNotificaciones";
            this.labelContadorNotificaciones.Size = new System.Drawing.Size(14, 16);
            this.labelContadorNotificaciones.TabIndex = 0;
            this.labelContadorNotificaciones.Text = "0";
            // 
            // notificacion
            // 
            this.notificacion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.notificacion.AutoSize = true;
            this.notificacion.FlatAppearance.BorderSize = 0;
            this.notificacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.notificacion.IconChar = FontAwesome.Sharp.IconChar.Bell;
            this.notificacion.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(44)))), ((int)(((byte)(64)))));
            this.notificacion.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.notificacion.IconSize = 27;
            this.notificacion.Location = new System.Drawing.Point(683, 15);
            this.notificacion.Margin = new System.Windows.Forms.Padding(4);
            this.notificacion.Name = "notificacion";
            this.notificacion.Size = new System.Drawing.Size(53, 50);
            this.notificacion.TabIndex = 48;
            this.notificacion.UseVisualStyleBackColor = true;
            this.notificacion.Click += new System.EventHandler(this.notificacion_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(1278, 7);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(50, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 45;
            this.pictureBox1.TabStop = false;
            // 
            // iconMenuItem2
            // 
            this.iconMenuItem2.IconChar = FontAwesome.Sharp.IconChar.None;
            this.iconMenuItem2.IconColor = System.Drawing.Color.Black;
            this.iconMenuItem2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconMenuItem2.Name = "iconMenuItem2";
            this.iconMenuItem2.Size = new System.Drawing.Size(32, 19);
            this.iconMenuItem2.Text = "iconMenuItem2";
            // 
            // produccionToolStripMenuItem
            // 
            this.produccionToolStripMenuItem.Name = "produccionToolStripMenuItem";
            this.produccionToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.produccionToolStripMenuItem.Text = "Produccion ";
            this.produccionToolStripMenuItem.Click += new System.EventHandler(this.produccionToolStripMenuItem_Click);
            // 
            // inicio3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1565, 713);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.menu);
            this.MainMenuStrip = this.menu;
            this.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.Name = "inicio3";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.inicio3_Load);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private FontAwesome.Sharp.IconMenuItem iconMenuItem2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MenuStrip menu;
        private FontAwesome.Sharp.IconMenuItem menusacercade;
        private FontAwesome.Sharp.IconMenuItem menusuario;
        private FontAwesome.Sharp.IconMenuItem menuventa;
        private FontAwesome.Sharp.IconMenuItem menucompra;
        private FontAwesome.Sharp.IconMenuItem menuempleado;
        private FontAwesome.Sharp.IconMenuItem menuproveedores;
        private FontAwesome.Sharp.IconMenuItem menureporte;
        private FontAwesome.Sharp.IconMenuItem menuproducto;
        private FontAwesome.Sharp.IconMenuItem menugrafica;
        private System.Windows.Forms.ToolStripMenuItem detalleDeVentaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CompraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem categoríasToolStripMenuItem;
        private FontAwesome.Sharp.IconMenuItem menuinicio;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private FontAwesome.Sharp.IconMenuItem mnegocio;
        private System.Windows.Forms.ToolStripMenuItem menunegocio;
        private System.Windows.Forms.ToolStripMenuItem detalleCompraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ventaToolStripMenuItem;
        private FontAwesome.Sharp.IconMenuItem menucliente;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem detalleVentaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem detalleCompraToolStripMenuItem1;
        private FontAwesome.Sharp.IconMenuItem menusalir;
        private FontAwesome.Sharp.IconButton notificacion;
        private System.Windows.Forms.ToolStripMenuItem produccionToolStripMenuItem;
        private FontAwesome.Sharp.IconMenuItem menuproduccion;
        private System.Windows.Forms.ToolStripMenuItem reporteProduccionToolStripMenuItem;
        private FontAwesome.Sharp.IconMenuItem menuinventario;
        private System.Windows.Forms.ToolStripMenuItem cREARToolStripMenuItem;
        private System.Windows.Forms.Label labelContadorNotificaciones;
        private System.Windows.Forms.ToolStripMenuItem pedidoToolStripMenuItem;
    }
}