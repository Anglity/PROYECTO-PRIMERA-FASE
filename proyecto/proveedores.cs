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
    public partial class proveedores : Form
    {
        public proveedores()
        {
            InitializeComponent();
        }

        private void proveedores_Load(object sender, System.EventArgs e)
        {
            estado2.Items.Add(new opcionescombo() { valor = 1, texto = "Activo" });
            estado2.Items.Add(new opcionescombo() { valor = 0, texto = "No Activo" });
            estado2.DisplayMember = "Texto";
            estado2.ValueMember = "Valor";
            estado2.SelectedIndex = 0;


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

            CargarUsuarios(); // Agregamos una llamada para cargar los usuarios en el DataGridView
        }

        private void CargarUsuarios()
        {
            dgdata.Rows.Clear(); // Limpiamos las filas existentes en el DataGridView

            // MOSTRAR TODOS LOS USUARIOS
            List<proveedor> lista = new cn_proveedor().listar();

            foreach (proveedor item in lista)
            {
                string estadoTexto = item.Estado ? "Activo" : "No Activo";
                dgdata.Rows.Add(new object[] {
            "", // Suponiendo que esta es una columna para un propósito específico (como un checkbox o ícono)
            item.IdProveedor,
            item.Documento,
            item.RazonSocial,
            item.Correo,
            item.Telefono,
            item.IdDireccion,
            item.Pais,
            item.Provincia,
            item.Ciudad,
            item.Sector,
            item.Calle,
            item.CodigoPostal,
            item.Direccion,
            estadoTexto, // Asignamos directamente el texto "Activo" o "No Activo"
            item.DiasEntrega // Agregado
        });
            }
        }

        private void btnguardar_Click(object sender, System.EventArgs e)
        {
            string mensaje = string.Empty;

            proveedor obj = new proveedor()
            {
                IdProveedor = Convert.ToInt32(txtid.Text),
                Documento = txtdocumento.Text,
                RazonSocial = txtrazonsocial.Text,
                Correo = correo2.Text,
                Telefono = txttelefono.Text,
                Pais = paistxt.Text,
                Provincia = provinciatxt.Text,
                Ciudad = ciudadtxt.Text,
                Sector = sectortxt.Text,
                Calle = calletxt.Text,
                CodigoPostal = codigopostaltxt.Text,
                Estado = Convert.ToInt32(((opcionescombo)estado2.SelectedItem).valor) == 1 ? true : false,
                IdDireccion = Convert.ToInt32(iddireciontxt.Text),
                DiasEntrega = string.IsNullOrEmpty(diaentrega.Text) ? 0 : Convert.ToInt32(diaentrega.Text) // Agregado
            };

            if (obj.IdProveedor == 0) // Registro
            {
                int idgenerado = new cn_proveedor().Registrar(obj, out mensaje);

                if (idgenerado != 0)
                {
                    string estadoTexto = obj.Estado ? "Activo" : "No Activo";

                    dgdata.Rows.Add(new object[] {
                "", // Suponiendo que esta es una columna para un propósito específico (como un checkbox o ícono)
                idgenerado,
                obj.Documento,
                obj.RazonSocial,
                obj.Correo,
                obj.Telefono,
                obj.IdDireccion,
                obj.Pais,
                obj.Provincia,
                obj.Ciudad,
                obj.Sector,
                obj.Calle,
                obj.CodigoPostal,
                obj.Direccion, // Asegúrate de que esta propiedad esté definida en tu clase proveedor
                estadoTexto,
                obj.DiasEntrega // Agregado
            });

                    limpiar();
                    CargarUsuarios();
                }
                else
                {
                    MessageBox.Show(mensaje);
                }
            }
            else // Edición
            {
                bool resultado = new cn_proveedor().Editar(obj, out mensaje);

                if (resultado)
                {
                    DataGridViewRow row = dgdata.Rows[Convert.ToInt32(txtindice.Text)];
                    row.Cells["Id"].Value = obj.IdProveedor;
                    row.Cells["Documento"].Value = obj.Documento;
                    row.Cells["RazonSocial"].Value = obj.RazonSocial;
                    row.Cells["Correo"].Value = obj.Correo;
                    row.Cells["Telefono"].Value = obj.Telefono;
                    row.Cells["IdDireccion"].Value = obj.IdDireccion;
                    row.Cells["Pais"].Value = obj.Pais;
                    row.Cells["Provincia"].Value = obj.Provincia;
                    row.Cells["Ciudad"].Value = obj.Ciudad;
                    row.Cells["Sector"].Value = obj.Sector;
                    row.Cells["Calle"].Value = obj.Calle;
                    row.Cells["CodigoPostal"].Value = obj.CodigoPostal;
                    row.Cells["Estado"].Value = estado2.SelectedItem.ToString();
                    row.Cells["DiasEntrega"].Value = obj.DiasEntrega; // Agregado

                    limpiar();
                    CargarUsuarios();
                }
                else
                {
                    MessageBox.Show(mensaje);
                }
            }
        }

        private void limpiar()
        {
            txtindice.Text = "0";
            txtid.Text = "0";
            txtdocumento.Text = "";
            txtrazonsocial.Text = "";
            correo2.Text = "";
            txttelefono.Text = "";
            iddireciontxt.Text = "0";
            paistxt.Text = "";
            provinciatxt.Text = "";
            ciudadtxt.Text = "";
            sectortxt.Text = "";
            calletxt.Text = "";
            codigopostaltxt.Text = "";
            estado2.SelectedIndex = -1;
            diaentrega.Text = ""; // Limpia el campo de DiasEntrega
            txtdocumento.Select();
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
                    txtdocumento.Text = dgdata.Rows[indice].Cells["Documento"].Value.ToString();
                    txtrazonsocial.Text = dgdata.Rows[indice].Cells["RazonSocial"].Value.ToString();
                    correo2.Text = dgdata.Rows[indice].Cells["Correo"].Value.ToString();
                    txttelefono.Text = dgdata.Rows[indice].Cells["Telefono"].Value.ToString();
                    iddireciontxt.Text = dgdata.Rows[indice].Cells["IdDireccion"].Value.ToString();
                    paistxt.Text = dgdata.Rows[indice].Cells["Pais"].Value.ToString();
                    provinciatxt.Text = dgdata.Rows[indice].Cells["Provincia"].Value.ToString();
                    ciudadtxt.Text = dgdata.Rows[indice].Cells["Ciudad"].Value.ToString();
                    sectortxt.Text = dgdata.Rows[indice].Cells["Sector"].Value.ToString();
                    calletxt.Text = dgdata.Rows[indice].Cells["Calle"].Value.ToString();
                    codigopostaltxt.Text = dgdata.Rows[indice].Cells["CodigoPostal"].Value.ToString();
                    diaentrega.Text = dgdata.Rows[indice].Cells["DiasEntrega"].Value.ToString(); // Agregado para DiasEntrega

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
                }
            }
        }


        private void btneliminar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtid.Text) != 0)
            {
                if (MessageBox.Show("¿Desea eliminar el proveedor", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    string mensaje = string.Empty;
                    proveedor obj = new proveedor()
                    {
                        IdProveedor = Convert.ToInt32(txtid.Text)
                    };

                    bool respuesta = new cn_proveedor().Eliminar(obj, out mensaje);

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

        private void btnlimpiar_Click(object sender, EventArgs e)
        {
            limpiar();

        }



        private void extraer_Click(object sender, EventArgs e)
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
                            row.Cells[5].Value.ToString(),
                            row.Cells[13].Value.ToString(),
                            row.Cells[14].Value.ToString(),


                        });
                }

                SaveFileDialog savefile = new SaveFileDialog();
                savefile.FileName = string.Format("ReporteProveedores_{0}.xlsx", DateTime.Now.ToString("ddMMyyyyHHmmss"));
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

        private void txtdocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite solo dígitos numéricos, control de teclas de retroceso, y (opcionalmente) punto decimal.
            if (!char.IsDigit(e.KeyChar) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != '.'))
            {
                e.Handled = true; // Bloquea el evento de cualquier cosa que no sea número o tecla de retroceso.
            }

            // Opcional: Si quieres permitir solo un punto decimal
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true; // Bloquea la entrada de un segundo punto decimal.
            }

            // Opcional: Para permitir teclas como Enter, etc., puedes agregar más condiciones aquí.
        }

        private void txttelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite solo dígitos numéricos, control de teclas de retroceso, y (opcionalmente) punto decimal.
            if (!char.IsDigit(e.KeyChar) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != '.'))
            {
                e.Handled = true; // Bloquea el evento de cualquier cosa que no sea número o tecla de retroceso.
            }

            // Opcional: Si quieres permitir solo un punto decimal
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true; // Bloquea la entrada de un segundo punto decimal.
            }

            // Opcional: Para permitir teclas como Enter, etc., puedes agregar más condiciones aquí.
        }

        private void paistxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verifica si el caracter es un número (dígito).
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ignora el evento.
            }
            // Opcional: Permite el control de teclas de retroceso y suprimir
            else if (e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Delete)
            {
                e.Handled = false; // Permite el evento.
            }
        }

        private void provinciatxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verifica si el caracter es un número (dígito).
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ignora el evento.
            }
            // Opcional: Permite el control de teclas de retroceso y suprimir
            else if (e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Delete)
            {
                e.Handled = false; // Permite el evento.
            }
        }

        private void ciudadtxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verifica si el caracter es un número (dígito).
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ignora el evento.
            }
            // Opcional: Permite el control de teclas de retroceso y suprimir
            else if (e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Delete)
            {
                e.Handled = false; // Permite el evento.
            }
        }

        private void sectortxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verifica si el caracter es un número (dígito).
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ignora el evento.
            }
            // Opcional: Permite el control de teclas de retroceso y suprimir
            else if (e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Delete)
            {
                e.Handled = false; // Permite el evento.
            }
        }

        private void codigopostaltxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite solo dígitos numéricos, control de teclas de retroceso, y (opcionalmente) punto decimal.
            if (!char.IsDigit(e.KeyChar) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != '.'))
            {
                e.Handled = true; // Bloquea el evento de cualquier cosa que no sea número o tecla de retroceso.
            }

            // Opcional: Si quieres permitir solo un punto decimal
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true; // Bloquea la entrada de un segundo punto decimal.
            }

            // Opcional: Para permitir teclas como Enter, etc., puedes agregar más condiciones aquí.
        }

        private void diaentrega_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite solo dígitos numéricos, control de teclas de retroceso, y (opcionalmente) punto decimal.
            if (!char.IsDigit(e.KeyChar) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != '.'))
            {
                e.Handled = true; // Bloquea el evento de cualquier cosa que no sea número o tecla de retroceso.
            }

            // Opcional: Si quieres permitir solo un punto decimal
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true; // Bloquea la entrada de un segundo punto decimal.
            }

            // Opcional: Para permitir teclas como Enter, etc., puedes agregar más condiciones aquí.
        }
    }
}
