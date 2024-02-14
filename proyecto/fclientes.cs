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
    public partial class fclientes : Form
    {
        private usuario _usuario;
        public fclientes(usuario oUsuario = null)
        {
            _usuario = oUsuario;
            InitializeComponent();
        }

        public fclientes()
        {

            InitializeComponent();
        }

        private void fclientes_Load(object sender, EventArgs e)
        {
            estado2.Items.Add(new opcionescombo() { valor = 1, texto = "Activo" });
            estado2.Items.Add(new opcionescombo() { valor = 0, texto = "No Activo" });
            estado2.DisplayMember = "Texto";
            estado2.ValueMember = "Valor";
            estado2.SelectedIndex = 0;

            List<rol> listaRol = new cn_rol().listar();



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

            //MOSTRAR TODOS LOS USUARIOS
            List<cliente> lista = new cn_cliente().listar();

            foreach (cliente item in lista)
            {
                string estadoTexto = item.Estado ? "Activo" : "No Activo";
                dgdata.Rows.Add(new object[] {"",item.IdCliente,item.Documento,item.NombreCompleto,item.Correo,item.Telefono, item.IdDireccion,
                item.Pais, item.Provincia, item.Ciudad, item.Sector, item.Calle, item.CodigoPostal, item.Direccion,
                estadoTexto // Asignamos directamente el texto "Activo" o "No Activo"
                });
            }

        }




        private void btnguardar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;

            cliente obj = new cliente()
            {
                IdCliente = Convert.ToInt32(txtid.Text),
                Documento = txtdocumento.Text,
                NombreCompleto = ncompleto.Text,
                Correo = correo2.Text,
                Telefono = txttelefono.Text,
                Pais = paistxt.Text,
                Provincia = provinciatxt.Text,
                Ciudad = ciudadtxt.Text,
                Sector = sectortxt.Text,
                Calle = calletxt.Text,
                CodigoPostal = codigopostaltxt.Text,
                Estado = Convert.ToInt32(((opcionescombo)estado2.SelectedItem).valor) == 1 ? true : false,
                IdDireccion = Convert.ToInt32(iddireciontxt.Text)

            };

            if (obj.IdCliente == 0)
            {
                int idgenerado = new cn_cliente().Registrar(obj, out mensaje);

                if (idgenerado != 0)
                {
                    string estadoTexto = obj.Estado ? "Activo" : "No Activo";
                    dgdata.Rows.Add(new object[] {"",idgenerado,txtdocumento.Text,ncompleto.Text,correo2.Text,txttelefono.Text, iddireciontxt.Text,
                        paistxt.Text, provinciatxt.Text,ciudadtxt.Text, sectortxt.Text, calletxt.Text, codigopostaltxt.Text,
                        estadoTexto
                    });

                    limpiar();
                    CargarUsuarios();
                }
                else
                {
                    MessageBox.Show(mensaje);
                }


            }
            else
            {
                bool resultado = new cn_cliente().Editar(obj, out mensaje);

                if (resultado)
                {
                    DataGridViewRow row = dgdata.Rows[Convert.ToInt32(txtindice.Text)];
                    row.Cells["Id"].Value = txtid.Text;
                    row.Cells["Documento"].Value = txtdocumento.Text;
                    row.Cells["NombreCompleto"].Value = ncompleto.Text;
                    row.Cells["Correo"].Value = correo2.Text;
                    row.Cells["Telefono"].Value = txttelefono.Text;
                    row.Cells["IdDireccion"].Value = iddireciontxt.Text;
                    row.Cells["Pais"].Value = paistxt.Text;
                    row.Cells["Provincia"].Value = provinciatxt.Text;
                    row.Cells["Ciudad"].Value = ciudadtxt.Text;
                    row.Cells["Sector"].Value = sectortxt.Text;
                    row.Cells["Calle"].Value = calletxt.Text;
                    row.Cells["CodigoPostal"].Value = codigopostaltxt.Text;
                    row.Cells["EstadoValor"].Value = ((opcionescombo)estado2.SelectedItem).valor.ToString();
                    row.Cells["Estado"].Value = ((opcionescombo)estado2.SelectedItem).texto.ToString();
                    limpiar();
                    CargarUsuarios();
                }

                else
                {
                    MessageBox.Show(mensaje);
                }
                limpiar();
                CargarUsuarios();
            }

        }

        private void limpiar()
        {
            txtid.Text = "0";
            txtdocumento.Text = "";
            ncompleto.Text = "";
            correo2.Text = "";
            txttelefono.Text = "";
            paistxt.Text = "";
            provinciatxt.Text = "";
            ciudadtxt.Text = "";
            sectortxt.Text = "";
            calletxt.Text = "";
            codigopostaltxt.Text = "";
            estado2.SelectedIndex = -1;  // Asegúrate de que este es el índice correcto para un estado no seleccionado
            iddireciontxt.Text = "0";
            txtindice.Text = "";
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
                    ncompleto.Text = dgdata.Rows[indice].Cells["NombreCompleto"].Value.ToString();
                    correo2.Text = dgdata.Rows[indice].Cells["Correo"].Value.ToString();
                    txttelefono.Text = dgdata.Rows[indice].Cells["Telefono"].Value.ToString();
                    iddireciontxt.Text = dgdata.Rows[indice].Cells["IdDireccion"].Value.ToString();
                    paistxt.Text = dgdata.Rows[indice].Cells["Pais"].Value.ToString();
                    provinciatxt.Text = dgdata.Rows[indice].Cells["Provincia"].Value.ToString();
                    ciudadtxt.Text = dgdata.Rows[indice].Cells["Ciudad"].Value.ToString();
                    sectortxt.Text = dgdata.Rows[indice].Cells["Sector"].Value.ToString();
                    calletxt.Text = dgdata.Rows[indice].Cells["Calle"].Value.ToString();
                    codigopostaltxt.Text = dgdata.Rows[indice].Cells["CodigoPostal"].Value.ToString();
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
                if (MessageBox.Show("¿Desea eliminar el cliente", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    string mensaje = string.Empty;
                    cliente obj = new cliente()
                    {
                        IdCliente = Convert.ToInt32(txtid.Text)
                    };

                    bool respuesta = new cn_cliente().Eliminar(obj, out mensaje);

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

        private void btnbusqueda_Click(object sender, EventArgs e)
        {
            string columnaFiltro = ((opcionescombo)busquedacombo.SelectedItem).valor.ToString();

            if (dgdata.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgdata.Rows)
                {

                    if (row.Cells[columnaFiltro].Value.ToString().Trim().ToUpper().Contains(busqueda.Text.Trim().ToUpper()))
                        row.Visible = true;
                    else
                        row.Visible = false;
                }
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
                            row.Cells[5].Value.ToString(),
                            row.Cells[13].Value.ToString(),
                            row.Cells[14].Value.ToString(),


                        });
                }

                SaveFileDialog savefile = new SaveFileDialog();
                savefile.FileName = string.Format("ReporteCliente_{0}.xlsx", DateTime.Now.ToString("ddMMyyyyHHmmss"));
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

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void txtdocumento_TextChanged(object sender, EventArgs e)
        {

        }

        private void ncompleto_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }

}
