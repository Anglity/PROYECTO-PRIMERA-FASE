using entidad;
using negocio;
using proyecto.modales;
using proyecto.utlidades;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace proyecto
{

    public partial class fcompras : Form
    {

        private usuario _usuario;

        public fcompras(usuario oUsuario = null)
        {
            _usuario = oUsuario;
            InitializeComponent();
        }

        private void fcompras_Load(object sender, EventArgs e)
        {
            tipodocumento2.Items.Add(new opcionescombo() { valor = "Comprobante", texto = "Comprobante" });
            tipodocumento2.Items.Add(new opcionescombo() { valor = "Factura", texto = "Factura" });
            tipodocumento2.DisplayMember = "Texto";
            tipodocumento2.ValueMember = "Valor";
            tipodocumento2.SelectedIndex = 0;

            txtfecha.Text = DateTime.Now.ToString("dd/MM/yyyy");

            cbUnidadMedida.Items.Add("Galones");
            cbUnidadMedida.Items.Add("Litro");
            cbUnidadMedida.Items.Add("unidad");
            cbUnidadMedida.Items.Add("Saco");
            cbUnidadMedida.Items.Add("libra");

            cbUnidadMedida.SelectedIndex = 0;

            txtdocproveedor.Text = "0";
            txtdocproveedor.Text = "0";
        }

        private void btnbusqueda_Click(object sender, EventArgs e)
        {
            using (var modal = new md_proveedor())
            {
                var result = modal.ShowDialog();

                if (result == DialogResult.OK)
                {
                    txtidproveedor.Text = modal._proveedor.IdProveedor.ToString();
                    txtdocproveedor.Text = modal._proveedor.Documento;
                    txtnombreproveedor.Text = modal._proveedor.RazonSocial;
                }
                else
                {
                    txtdocproveedor.Select();
                }

            }
        }

        private void busquedaproducto_Click(object sender, EventArgs e)
        {
            using (var modal = new md_productos())
            {
                var result = modal.ShowDialog();

                if (result == DialogResult.OK)
                {
                    txtidproducto.Text = modal._producto.IdProducto.ToString();
                    txtcodproducto.Text = modal._producto.Codigo;
                    txtproducto.Text = modal._producto.Nombre;
                    txtpreciocompra.Select();
                }
                else
                {
                    txtcodproducto.Select();
                }

            }
        }

        private void txtcodproducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {

                producto oproducto = new cn_producto().listar().Where(p => p.Codigo == txtcodproducto.Text && p.Estado == true).FirstOrDefault();

                if (oproducto != null)
                {
                    txtcodproducto.BackColor = Color.Honeydew;
                    txtidproducto.Text = oproducto.IdProducto.ToString();
                    txtproducto.Text = oproducto.Nombre;
                    txtpreciocompra.Select();
                }
                else
                {
                    txtcodproducto.BackColor = Color.MistyRose;
                    txtidproducto.Text = "0";
                    txtproducto.Text = "";
                }


            }
        }

        private void btnagregarproductos_Click(object sender, EventArgs e)
        {
            decimal preciocompra = 0;
            decimal precioventa = 0;
            bool producto_existe = false;

            if (int.Parse(txtidproducto.Text) == 0)
            {
                MessageBox.Show("Debe seleccionar un producto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (!decimal.TryParse(txtpreciocompra.Text, out preciocompra))
            {
                MessageBox.Show("Precio Compra - Formato moneda incorrecto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtpreciocompra.Select();
                return;
            }

            if (!decimal.TryParse(txtprecioventa.Text, out precioventa))
            {
                MessageBox.Show("Precio Venta - Formato moneda incorrecto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtprecioventa.Select();
                return;
            }

            foreach (DataGridViewRow fila in dgdata.Rows)
            {
                if (fila.Cells["IdProducto"].Value.ToString() == txtidproducto.Text)
                {
                    producto_existe = true;
                    break;
                }
            }

            if (!producto_existe)
            {
                string unidadMedidaSeleccionada = cbUnidadMedida.SelectedItem.ToString();
                dgdata.Rows.Add(new object[] {
                    txtidproducto.Text,
            txtproducto.Text,
            txtcodproducto.Text,
            preciocompra.ToString("0.00"),
            precioventa.ToString("0.00"),
            txtcantidad.Value.ToString(),
            (txtcantidad.Value * preciocompra).ToString("0.00"),
            unidadMedidaSeleccionada

                });
                calcularTotal();
                limpiarProducto();
                txtcodproducto.Select();



            }
        }
        private void limpiarProducto()
        {
            txtidproducto.Text = "0";
            txtcodproducto.Text = "";
            txtcodproducto.BackColor = Color.White;
            txtproducto.Text = "";
            txtpreciocompra.Text = "";
            txtprecioventa.Text = "";
            txtcantidad.Value = 1;
        }

        private void calcularTotal()
        {
            decimal total = 0;
            if (dgdata.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgdata.Rows)
                    total += Convert.ToDecimal(row.Cells["SubTotal"].Value.ToString());
            }
            txttotalpagar.Text = total.ToString("0.00");
        }

        private void dgdata_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (e.ColumnIndex == 8)
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
                    calcularTotal();
                }
            }
        }

        private void txtpreciocompra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (txtpreciocompra.Text.Trim().Length == 0 && e.KeyChar.ToString() == ".")
                {
                    e.Handled = true;
                }
                else
                {
                    if (Char.IsControl(e.KeyChar) || e.KeyChar.ToString() == ".")
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        e.Handled = true;
                    }
                }
            }
        }

        private void txtprecioventa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (txtprecioventa.Text.Trim().Length == 0 && e.KeyChar.ToString() == ".")
                {
                    e.Handled = true;
                }
                else
                {
                    if (Char.IsControl(e.KeyChar) || e.KeyChar.ToString() == ".")
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        e.Handled = true;
                    }
                }
            }
        }

        private void btnregistrar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtidproveedor.Text) == 0)
            {
                MessageBox.Show("Debe seleccionar un proveedor", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (dgdata.Rows.Count < 1)
            {
                MessageBox.Show("Debe ingresar productos en la compra", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DataTable detalle_compra = new DataTable();

            detalle_compra.Columns.Add("IdProducto", typeof(int));
            detalle_compra.Columns.Add("PrecioCompra", typeof(decimal));
            detalle_compra.Columns.Add("PrecioVenta", typeof(decimal));
            detalle_compra.Columns.Add("Cantidad", typeof(int));
            detalle_compra.Columns.Add("MontoTotal", typeof(decimal));
            detalle_compra.Columns.Add("UnidadMedida", typeof(string));

            foreach (DataGridViewRow row in dgdata.Rows)
            {
                detalle_compra.Rows.Add(
                    new object[] {
                       Convert.ToInt32(row.Cells["IdProducto"].Value.ToString()),
                       row.Cells["PrecioCompra"].Value.ToString(),
                       row.Cells["PrecioVenta"].Value.ToString(),
                       row.Cells["Cantidad"].Value.ToString(),
                       row.Cells["SubTotal"].Value.ToString(),
                       row.Cells["UnidadMedida"].Value.ToString()
                    });

            }

            int idcorrelativo = new cn_compra().ObtenerCorrelativo();
            string numerodocumento = string.Format("{0:00000}", idcorrelativo);

            compra oCompra = new compra()
            {
                ousuario = new usuario() { IdUsuario = _usuario.IdUsuario },
                oproveedor = new proveedor() { IdProveedor = Convert.ToInt32(txtidproveedor.Text) },
                TipoDocumento = ((opcionescombo)tipodocumento2.SelectedItem).texto,
                NumeroDocumento = numerodocumento,
                MontoTotal = Convert.ToDecimal(txttotalpagar.Text)
            };

            string mensaje = string.Empty;
            bool respuesta = new cn_compra().Registrar(oCompra, detalle_compra, out mensaje);

            if (respuesta)
            {
                var result = MessageBox.Show("Numero de compra generada:\n" + numerodocumento + "\n\n¿Desea copiar al portapapeles?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (result == DialogResult.Yes)
                    Clipboard.SetText(numerodocumento);

                txtidproveedor.Text = "0";
                txtdocproveedor.Text = "";
                txtnombreproveedor.Text = "";
                dgdata.Rows.Clear();
                calcularTotal();

            }
            else
            {
                MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txtproducto_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgdata_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Verifica que se haya hecho clic en una fila válida
            {

                // Comentar o eliminar esta sección si solo quieres eliminar la fila sin cargar los datos
                DataGridViewRow row = dgdata.Rows[e.RowIndex];
                txtidproducto.Text = row.Cells["IdProducto"].Value.ToString();
                txtcodproducto.Text = row.Cells["Codigo"].Value.ToString();
                txtproducto.Text = row.Cells["Producto"].Value.ToString();
                txtpreciocompra.Text = Convert.ToDecimal(row.Cells["PrecioCompra"].Value).ToString("0.00");
                txtprecioventa.Text = row.Cells["PrecioVenta"].Value.ToString();
                txtcantidad.Value = Convert.ToDecimal(row.Cells["Cantidad"].Value);
                cbUnidadMedida.SelectedValue = row.Cells["UnidadMedida"].Value.ToString();
                txtcantidad.Select();

                // Eliminar la fila después de cargar los datos
                dgdata.Rows.RemoveAt(e.RowIndex);


            }
        }
    }
}
