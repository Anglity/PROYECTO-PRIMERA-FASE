using entidad;
using negocio;
using proyecto.modales;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace proyecto
{
    public partial class fproduccion : Form
    {

        private usuario _usuario;
        public fproduccion(usuario oUsuario = null)
        {
            _usuario = oUsuario;
            InitializeComponent();


        }

        private void fproduccion_Load(object sender, EventArgs e)
        {

            cbUnidadMedida.Items.Add("Cucharada");
            cbUnidadMedida.Items.Add("Litro");
            cbUnidadMedida.Items.Add("Pastilla");
            cbUnidadMedida.Items.Add("Mililitros");
            cbUnidadMedida.SelectedIndex = 0;



            Cargarproducto();



        }


        private void busquedaproducto_Click(object sender, EventArgs e)
        {
            using (var modal = new md_productos())
            {
                var result = modal.ShowDialog();

                if (result == DialogResult.OK)
                {
                    // Añade aquí la comprobación para descartar el producto "queso"
                    string productoFiltrado = modal._producto.Nombre.ToLower();
                    if (productoFiltrado == "Queso Danes" || productoFiltrado == "Queso Chedar")

                    {
                        MessageBox.Show("El producto 'Queso' no se puede seleccionar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return; // Sale del método sin hacer nada más
                    }

                    txtidproducto.Text = modal._producto.IdProducto.ToString();

                    txtidproducto.Text = modal._producto.IdProducto.ToString();
                    txtcodproducto.Text = modal._producto.Codigo;
                    txtproducto.Text = modal._producto.Nombre;
                    txtprecio.Text = modal._producto.PrecioVenta.ToString("0.00");
                    txtstock.Text = modal._producto.Stock.ToString();

                    string producto = txtproducto.Text.ToLower();

                    // Limpia las opciones del ComboBox
                    cbUnidadMedida.Items.Clear();

                    if (producto == "cuajo" || producto == "peroxido" || producto == "colorante")
                    {

                        cbUnidadMedida.Items.Add("Mililitros");
                        cbUnidadMedida.SelectedIndex = 0; // Selecciona la primera y única opción
                    }
                    else if (producto == "leche")
                    {

                        cbUnidadMedida.Items.Add("Litros");
                        cbUnidadMedida.SelectedIndex = 0; // Selecciona la primera y única opción
                    }
                    else if (producto == "cultivo" || producto == "calcio" || producto == "catalza" || producto == "catibar")
                    {

                        cbUnidadMedida.Items.Add("Pastilla");
                        cbUnidadMedida.SelectedIndex = 0; // Selecciona la primera y única opción
                    }
                    else if (producto == "sal")
                    {

                        cbUnidadMedida.Items.Add("Cucharada");
                        cbUnidadMedida.SelectedIndex = 0; // Selecciona la primera y única opción
                    }
                    else
                    {

                        cbUnidadMedida.Items.Add("Unidad");
                        cbUnidadMedida.SelectedIndex = 0; // Selecciona la primera y única opción
                    }
                }
                else
                {
                    txtcodproducto.Select();
                }
            }
        }

        private void txtproducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {

                producto oproducto = new cn_producto().listar().Where(p => p.Codigo == txtcodproducto.Text && p.Estado == true).FirstOrDefault();

                if (oproducto != null)
                {
                    txtcodproducto.BackColor = Color.Honeydew;
                    txtidproducto.Text = oproducto.IdProducto.ToString();
                    txtproducto.Text = oproducto.Nombre;

                }
                else
                {
                    txtcodproducto.BackColor = Color.MistyRose;
                    txtidproducto.Text = "0";
                    txtproducto.Text = "";
                }


            }
        }
        private void CalcularLibrasDeQueso()
        {
            int sumaProductosEspeciales = 0;
            int sumaLeche = 0;
            HashSet<string> productosEncontrados = new HashSet<string>();

            foreach (DataGridViewRow fila in dgdata.Rows)
            {
                string producto = fila.Cells["Producto"].Value.ToString().ToLower();
                int cantidad = int.Parse(fila.Cells["Cantidad"].Value.ToString());

                if (producto == "cuajo" || producto == "peroxido" || producto == "cultivo" || producto == "catalza" || producto == "catibar" || producto == "sal" || producto == "colorante" || producto == "calcio")
                {
                    sumaProductosEspeciales += cantidad;
                    productosEncontrados.Add(producto);
                }
                else if (producto == "leche")
                {
                    sumaLeche += cantidad;
                    productosEncontrados.Add(producto);
                }
            }

            if (productosEncontrados.Count == 9) // Ahora comprobamos si todos los productos necesarios están presentes
            {
                // Calcular cuántas "proporciones" de queso podemos generar con los productos y leche disponibles
                int proporcionQueso = Math.Min(sumaProductosEspeciales / 16, sumaLeche / 10);
                int quesoGenerado = proporcionQueso * 5;  // Cada proporción genera 5 libras de queso.


            }

        }

        private void limpiarProducto()
        {
            txtidproducto.Text = "0";
            txtcodproducto.Text = "";
            txtcodproducto.BackColor = Color.White;
            txtproducto.Text = "";
            txtprecio.Text = "";
            txtstock.Text = "";

        }

        private void dgdata_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (e.ColumnIndex == 4)
            {

                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                var w = Properties.Resources.borrar.Width;
                var h = Properties.Resources.borrar.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                e.Graphics.DrawImage(Properties.Resources.borrar, new Rectangle(x, y, w, h));
                e.Handled = true;
            }
        }

        private void dgdata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgdata.Columns[e.ColumnIndex].Name == "btneliminar")
            {
                int indice = e.RowIndex;

                if (indice >= 0)
                {
                    dgdata.Rows.RemoveAt(indice);

                }
            }
            CalcularLibrasDeQueso();
        }





        private void btnlimpiarbuscador_Click(object sender, EventArgs e)
        {
            dgdata.Rows.Clear();
        }



        private void Cargarproducto()
        {
            dgdata.Rows.Clear(); // Limpiamos las filas existentes en el DataGridView

            //MOSTRAR TODOS LOS USUARIOS
            List<producto> lista = new cn_producto().listar();

            foreach (producto item in lista)
            {
                // Solo agregar productos cuyo código comience con "P-"
                if (item.Codigo.StartsWith("p-"))
                {
                    string estadoTexto = item.Estado ? "Activo" : "No Activo";
                    dgdata.Rows.Add(new object[] { "",
                item.IdProducto,
                item.Codigo,
                item.Nombre,
                item.Descripcion,
                item.ocategoria.IdCategoria,
                item.ocategoria.Descripcion,
                item.Stock,
                item.PrecioCompra,
                item.PrecioVenta,
                estadoTexto,
                item.UnidadMedida
            });
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Cargarproducto();
        }



        private void iconButton2_Click(object sender, EventArgs e)
        {
            listareceta formRecetas = new listareceta();
            formRecetas.ShowDialog();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            fpedido formRecetas = new fpedido();
            formRecetas.ShowDialog();
        }
    }
}
