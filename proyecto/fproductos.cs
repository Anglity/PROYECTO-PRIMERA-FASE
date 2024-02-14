using ClosedXML.Excel;
using entidad;
using negocio;
using proyecto.utlidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace proyecto
{
    public partial class fproductos : Form
    {
        public fproductos()
        {
            InitializeComponent();
        }

        private void fproductos_Load(object sender, EventArgs e)
        {
            estado2.Items.Add(new opcionescombo() { valor = 1, texto = "Disponible" });
            estado2.Items.Add(new opcionescombo() { valor = 0, texto = "No disponible" });
            estado2.DisplayMember = "Texto";
            estado2.ValueMember = "Valor";
            estado2.SelectedIndex = 0;

            unidadMedida2.Items.Add(new opcionescombo() { valor = "Libra", texto = "Libra" });
            unidadMedida2.Items.Add(new opcionescombo() { valor = "Litro", texto = "Litro" });
            unidadMedida2.Items.Add(new opcionescombo() { valor = "Saco", texto = "Saco" });
            unidadMedida2.Items.Add(new opcionescombo() { valor = "Cubeta", texto = "Cubeta" });
            unidadMedida2.DisplayMember = "Texto";
            unidadMedida2.ValueMember = "Valor";
            unidadMedida2.SelectedIndex = 0;



            List<categoria> listacategoria = new cn_categoria().listar();

            foreach (categoria item in listacategoria)
            {
                categoria2.Items.Add(new opcionescombo() { valor = item.IdCategoria, texto = item.Descripcion });
            }
            categoria2.DisplayMember = "Texto";
            categoria2.ValueMember = "Valor";
            categoria2.SelectedIndex = 0;

            foreach (DataGridViewColumn columna in dgdata.Columns)
            {
                if (columna.Visible == true && columna.Name != "btnseleccionar")
                {
                    busquedacombo.Items.Add(new opcionescombo() { valor = columna.Name, texto = columna.HeaderText });
                }
            }
            busquedacombo.DisplayMember = "Texto";
            busquedacombo.ValueMember = "Valor";
            busquedacombo.SelectedIndex = 0;

            Cargarproducto(); // Agregamos una llamada para cargar los usuarios en el DataGridView
        }


        private void Cargarproducto()
        {
            dgdata.Rows.Clear(); // Limpiamos las filas existentes en el DataGridView

            //MOSTRAR TODOS LOS USUARIOS
            List<producto> lista = new cn_producto().listar();

            foreach (producto item in lista)
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
                    estadoTexto, // Asignamos directamente el texto "Activo" o "No Activo"
                    item.UnidadMedida
                });
            }

        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            string Mensaje = string.Empty;
            producto obj = new producto()
            {
                IdProducto = Convert.ToInt32(txtid.Text),
                Codigo = txtcodigo.Text,
                Nombre = txtcompleto.Text,
                Descripcion = txtdescripcion.Text,
                ocategoria = new categoria() { IdCategoria = Convert.ToInt32(((opcionescombo)categoria2.SelectedItem).valor) },
                Estado = Convert.ToInt32(((opcionescombo)estado2.SelectedItem).valor) == 1 ? true : false,
                UnidadMedida = ((opcionescombo)unidadMedida2.SelectedItem).valor.ToString()
            };

            if (obj.IdProducto == 0)
            {
                int idgenerado = new cn_producto().Registrar(obj, out Mensaje);

                if (idgenerado != 0)
                {
                    string estadoTexto = obj.Estado ? "Activo" : "No Activo";
                    dgdata.Rows.Add(new object[] {
                         "",
                       idgenerado,
                       txtcodigo.Text,
                       txtcompleto.Text,
                       txtdescripcion.Text,
                       ((opcionescombo) categoria2.SelectedItem).valor.ToString(),
                       ((opcionescombo)categoria2.SelectedItem).texto.ToString(),
                       "0",
                       "0.00",
                       "0.00",
                       unidadMedida2.Text,
                estadoTexto
                });
                    Cargarproducto();

                    limpiar();
                }
                else
                {
                    MessageBox.Show(Mensaje);
                }
            }
            else
            {
                bool resultado = new cn_producto().Editar(obj, out Mensaje);

                if (resultado)
                {
                    DataGridViewRow row = dgdata.Rows[Convert.ToInt32(txtindice.Text)];
                    row.Cells["Id"].Value = txtid.Text;
                    row.Cells["Codigo"].Value = txtcodigo.Text;
                    row.Cells["Nombre"].Value = txtcompleto.Text;
                    row.Cells["Descripcion"].Value = txtdescripcion.Text;
                    row.Cells["IdCategoria"].Value = ((opcionescombo)categoria2.SelectedItem).valor.ToString();
                    row.Cells["Categoria"].Value = ((opcionescombo)estado2.SelectedItem).texto.ToString();
                    row.Cells["EstadoValor"].Value = ((opcionescombo)estado2.SelectedItem).valor.ToString();
                    row.Cells["Estado"].Value = ((opcionescombo)estado2.SelectedItem).texto.ToString();
                    row.Cells["UnidadMedida"].Value = ((opcionescombo)unidadMedida2.SelectedItem).texto.ToString();
                    Cargarproducto();
                    limpiar();
                }
                else
                {
                    MessageBox.Show(Mensaje);
                }

            }

        }
        private void limpiar()
        {
            txtindice.Text = "-1";
            txtid.Text = "0";
            txtcodigo.Text = "";
            txtcompleto.Text = "";
            txtdescripcion.Text = "";
            categoria2.SelectedIndex = 0;
            estado2.SelectedIndex = 0;

            txtcodigo.Select();


        }



        private void dgdata_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {

            if (e.RowIndex < 0) return;

            if (e.ColumnIndex == 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                var w = Properties.Resources.comprobado.Width;
                var h = Properties.Resources.comprobado.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;
                e.Graphics.DrawImage(Properties.Resources.comprobado, new Rectangle(x, y, w, h));
                e.Handled = true;
            }
        }

        private void dgdata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgdata.Columns[e.ColumnIndex].Name == "btnseleccionar")
            {
                int indice = e.RowIndex;

                if (indice >= 0)
                {
                    txtindice.Text = indice.ToString();
                    txtid.Text = dgdata.Rows[indice].Cells["Id"].Value.ToString();

                    txtcodigo.Text = dgdata.Rows[indice].Cells["Codigo"].Value.ToString();
                    txtcompleto.Text = dgdata.Rows[indice].Cells["Nombre"].Value.ToString();
                    txtdescripcion.Text = dgdata.Rows[indice].Cells["Descripcion"].Value.ToString();

                    foreach (opcionescombo oc in categoria2.Items)
                    {
                        if (Convert.ToInt32(oc.valor) == Convert.ToInt32(dgdata.Rows[indice].Cells["IdCategoria"].Value))
                        {
                            int indice_combo = categoria2.Items.IndexOf(oc);
                            categoria2.SelectedIndex = indice_combo;
                            break;
                        }
                    }

                    string estadoTexto = dgdata.Rows[indice].Cells["Estado"].Value?.ToString();

                    foreach (opcionescombo oc in estado2.Items)
                    {
                        if (oc.texto == estadoTexto)
                        {
                            int indice_combo = estado2.Items.IndexOf(oc);
                            estado2.SelectedIndex = indice_combo;
                            break;
                        }
                    }

                    string unidadMedidaTexto = dgdata.Rows[indice].Cells["UnidadMedida"].Value?.ToString();

                    foreach (opcionescombo oc in unidadMedida2.Items)
                    {
                        if (oc.texto == unidadMedidaTexto)
                        {
                            int indice_combo = unidadMedida2.Items.IndexOf(oc);
                            unidadMedida2.SelectedIndex = indice_combo;
                            break;
                        }
                    }

                }
            }
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtid.Text) != 0)
            {
                if (MessageBox.Show("¿Desea eliminar el producto", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    string mensaje = string.Empty;
                    producto obj = new producto()
                    {
                        IdProducto = Convert.ToInt32(txtid.Text)
                    };

                    bool respuesta = new cn_producto().Eliminar(obj, out mensaje);

                    if (respuesta)
                    {
                        dgdata.Rows.RemoveAt(Convert.ToInt32(txtindice.Text));
                        limpiar();
                    }
                    else
                    {
                        MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                }
            }
        }

        private void btnlimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }
        // Variable auxiliar para controlar el filtrado en tiempo real
        private bool filtrandoEnTiempoReal = false;
        private void btnbusqueda_Click(object sender, EventArgs e)
        {
            // Verificar si ya se está realizando un filtrado en tiempo real
            if (!filtrandoEnTiempoReal)
            {
                filtrandoEnTiempoReal = true;

                string ColumnaFiltro = ((opcionescombo)busquedacombo.SelectedItem).valor.ToString();
                string textoBusqueda = busqueda.Text.Trim().ToUpper();

                if (dgdata.Rows.Count > 0)
                {
                    foreach (DataGridViewRow row in dgdata.Rows)
                    {
                        string valorCelda = row.Cells[ColumnaFiltro].Value.ToString().Trim().ToUpper();

                        // Mostrar la fila si el valor de la celda contiene el texto de búsqueda
                        row.Visible = valorCelda.Contains(textoBusqueda);
                    }
                }

                filtrandoEnTiempoReal = false;
            }
        }

        private void btnlimpiarbuscador_Click(object sender, EventArgs e)
        {
            busqueda.Text = "";
            foreach (DataGridViewRow row in dgdata.Rows)
            {
                row.Visible = true;
            }
        }

        private void excel_Click(object sender, EventArgs e)
        {
            if (dgdata.Rows.Count < 1)
            {
                MessageBox.Show("No hay datos para exportar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                DataTable dt = new DataTable();

                foreach (DataGridViewColumn columna in dgdata.Columns)
                {
                    if (columna.HeaderText != "" && columna.Visible)
                        if (columna.HeaderText != "" && columna.Visible)
                            dt.Columns.Add(columna.HeaderText, typeof(string));
                }

                foreach (DataGridViewRow row in dgdata.Rows)
                {
                    if (row.Visible)
                        dt.Rows.Add(new object[] {
                            row.Cells[2].Value.ToString(),
                            row.Cells[3].Value.ToString(),
                            row.Cells[4].Value.ToString(),
                            row.Cells[6].Value.ToString(),
                            row.Cells[7].Value.ToString(),
                            row.Cells[8].Value.ToString(),
                            row.Cells[9].Value.ToString(),
                            row.Cells[10].Value.ToString(),

                        });
                }

                SaveFileDialog savefile = new SaveFileDialog();
                savefile.FileName = string.Format("ReporteProducto_{0}.xlsx", DateTime.Now.ToString("ddMMyyyyHHmmss"));
                savefile.Filter = "Excel Files | *.xlsx";

                if (savefile.ShowDialog() == DialogResult.OK)
                {

                    try
                    {
                        XLWorkbook wb = new XLWorkbook();
                        var hoja = wb.Worksheets.Add(dt, "Informe");
                        hoja.ColumnsUsed().AdjustToContents();
                        wb.SaveAs(savefile.FileName);
                        MessageBox.Show("Reporte Generado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    catch
                    {
                        MessageBox.Show("Error al generar reporte", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                }

            }
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void categoria2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

}

