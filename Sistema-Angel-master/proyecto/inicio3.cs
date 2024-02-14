using entidad;
using FontAwesome.Sharp;
using negocio;
using proyecto.modales;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace proyecto
{
    public partial class inicio3 : Form

    {
        private static usuario usuarioactual;
        private static IconMenuItem menuactivo = null;
        private static Form formularioactivo;
        public inicio3(usuario objusuario = null)
        {
            if (objusuario == null)
                usuarioactual = new usuario() { NombreCompleto = "Administrador", IdUsuario = 2 };

            else
                usuarioactual = objusuario;

            InitializeComponent();



            ServicioNotificaciones.OnNotificacionAdded += ActualizarContadorNotificaciones;
        }

        private void inicio3_Load(object sender, EventArgs e)
        {
            List<permiso> listapermiso = new cn_permiso().listar(usuarioactual.IdUsuario);

            foreach (IconMenuItem iconmenu in menu.Items)
            {
                bool encontrado = listapermiso.Any(m => m.NombreMenu == iconmenu.Name);
                if (encontrado == false)
                {
                    iconmenu.Visible = false;
                }
            }

            label3.Text = usuarioactual.NombreCompleto;


            Home formHome = new Home();
            formHome.TopLevel = false;
            formHome.FormBorderStyle = FormBorderStyle.None;
            formHome.Dock = DockStyle.Fill;

            panel1.Controls.Add(formHome);
            formHome.Show();

        }

        private void abrirformulario(IconMenuItem menu, Form formulario)
        {
            panel1.Controls.Clear();

            if (menuactivo != null)
            {
                menuactivo.BackColor = Color.White;
            }

            menu.BackColor = Color.Silver;
            menuactivo = menu;

            if (formularioactivo != null)
            {
                formularioactivo.Close();
            }

            formularioactivo = formulario;
            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;
            //formulario.BackColor = Color.SteelBlue;
            panel1.Controls.Add(formulario);
            formulario.Show();
        }







        private void iconMenuItem15_Click(object sender, EventArgs e)
        {
            abrirformulario((IconMenuItem)sender, new usuarios2());
        }



        private void menuinicio_Click(object sender, EventArgs e)
        {
            abrirformulario((IconMenuItem)sender, new Home());

        }

        private void categoríasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrirformulario((menuproducto), new categorias());
        }



        private void menucliente_Click(object sender, EventArgs e)
        {
            abrirformulario((menuproducto), new fempleados());

        }

        private void menuproveedores_Click(object sender, EventArgs e)
        {
            abrirformulario((IconMenuItem)sender, new proveedores());

        }



        private void menunegocio_Click(object sender, EventArgs e)
        {
            abrirformulario((mnegocio), new fnegocio());
        }



        private void detalleDeCompraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrirformulario((menucompra), new fcompras(usuarioactual));
        }

        private void detalleCompraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrirformulario((menucompra), new fdetalle_compra());
        }

        private void ventaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrirformulario((menuventa), new fventa(usuarioactual));
        }

        private void análisisDeVentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrirformulario((menuventa), new Analisis_venta(usuarioactual));
        }

        private void rendimientoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void menucliente_Click_1(object sender, EventArgs e)
        {
            abrirformulario((IconMenuItem)sender, new fclientes());
        }

        private void empleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrirformulario((menuproducto), new fempleados());

        }

        private void detalleDeVentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrirformulario((menuventa), new fdetalle_venta());

        }

        private void detalleVentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrirformulario((menureporte), new freporte_venta());
        }

        private void detalleCompraToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            abrirformulario((menureporte), new freporte_compra());
        }

        private void menusacercade_Click(object sender, EventArgs e)
        {
            md_acercade md = new md_acercade();
            md.ShowDialog();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea salir?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void inventario_Click(object sender, EventArgs e)
        {
            abrirformulario((IconMenuItem)sender, new fproductos());
        }

        private void reservaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void iconMenuItem1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea salir?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void notificacion_Click(object sender, EventArgs e)
        {

            fnotificaciones formNotificaciones = new fnotificaciones();
            var notificaciones = ServicioNotificaciones.ObtenerNotificaciones();
            formNotificaciones.CargarNotificaciones(notificaciones);
            formNotificaciones.ShowDialog();

            ServicioNotificaciones.LimpiarNotificaciones();
            ActualizarContadorNotificaciones(0);
            ActualizarIconoNotificaciones();
        }

        private void ActualizarContadorNotificaciones()
        {
            int cantidadNotificaciones = ServicioNotificaciones.ObtenerCantidadNotificaciones();
            labelContadorNotificaciones.Text = cantidadNotificaciones.ToString();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            abrirformulario((menuventa), new Analisis_venta(usuarioactual));
        }


        private void productoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrirformulario((menuproducto), new fproduccion());
        }

        private void produccionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrirformulario((menureporte), new freporte_produccion());
        }

        private void menugrafica_Click(object sender, EventArgs e)
        {
            abrirformulario((menuproducto), new Analisis_venta());
        }

        private void historialDeCambiosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void menuproducto_Click(object sender, EventArgs e)
        {

        }

        private void iconMenuItem1_Click_1(object sender, EventArgs e)
        {
            abrirformulario((menuproducto), new fproduccion());

        }

        private void menureporte_Click(object sender, EventArgs e)
        {

        }

        private void reporteProduccionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrirformulario((menureporte), new freporte_produccion());
        }

        private void menuinventario_Click(object sender, EventArgs e)
        {
            abrirformulario((menuinventario), new fproductos());

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void cREARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrirformulario((menuproduccion), new ffcrearreceta());
        }

        private void ActualizarContadorNotificaciones(int cantidadNotificaciones)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<int>(ActualizarContadorNotificaciones), cantidadNotificaciones);
            }
            else
            {
                labelContadorNotificaciones.Text = cantidadNotificaciones.ToString();

                ActualizarIconoNotificaciones();
            }
        }
        private void ActualizarIconoNotificaciones()
        {
            var cantidadNotificaciones = ServicioNotificaciones.ObtenerNotificaciones().Count;

            if (cantidadNotificaciones > 0)
            {
                notificacion.IconColor = Color.Blue; // Cambiar el color del ícono a azul
                notificacion.BackColor = Color.Transparent; // Fondo transparente
            }
            else
            {
                notificacion.IconColor = Color.Black; // Volver al color original del ícono
                notificacion.BackColor = Color.Transparent; // Fondo transparente
            }

            labelContadorNotificaciones.Text = cantidadNotificaciones.ToString();
        }

        private void dToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrirformulario((menuproduccion), new fplanificacion());
        }

        private void pedidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrirformulario((menuproduccion), new fpedido());
        }
    }
}
