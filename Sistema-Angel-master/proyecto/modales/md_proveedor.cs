using entidad;
using negocio;
using proyecto.utlidades;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace proyecto.modales
{
    public partial class md_proveedor : Form
    {
        public proveedor _proveedor { get; set; }
        public md_proveedor()
        {
            InitializeComponent();
        }

        private void md_proveedor_Load(object sender, EventArgs e)
        {
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

            Cargarproveedor(); // Agregamos una llamada para cargar los usuarios en el DataGridView
        }

        private void Cargarproveedor()
        {
            dgdata.Rows.Clear(); // Limpiamos las filas existentes en el DataGridView

            //MOSTRAR TODOS LOS USUARIOS
            List<proveedor> lista = new cn_proveedor().listar();

            foreach (proveedor item in lista)
            {

                dgdata.Rows.Add(new object[] {item.IdProveedor,item.Documento,item.RazonSocial
                });
            }

        }

        private void dgdata_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int iRow = e.RowIndex;
            int iColum = e.ColumnIndex;

            if (iRow >= 0 && iColum > 0)
            {

                _proveedor = new proveedor()
                {
                    IdProveedor = Convert.ToInt32(dgdata.Rows[iRow].Cells["Id"].Value.ToString()),
                    Documento = dgdata.Rows[iRow].Cells["Documento"].Value.ToString(),
                    RazonSocial = dgdata.Rows[iRow].Cells["RazonSocial"].Value.ToString()
                };

                this.DialogResult = DialogResult.OK;
                this.Close();
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
    }
}
