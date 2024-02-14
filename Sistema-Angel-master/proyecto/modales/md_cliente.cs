using entidad;
using negocio;
using proyecto.utlidades;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace proyecto.modales
{
    public partial class md_cliente : Form
    {
        public cliente _cliente { get; set; }
        public md_cliente()
        {
            InitializeComponent();
        }

        private void md_cliente_Load(object sender, EventArgs e)
        {
            foreach (DataGridViewColumn columna in dgdata.Columns)
            {
                busquedacombo.Items.Add(new opcionescombo() { valor = columna.Name, texto = columna.HeaderText });
            }

            busquedacombo.DisplayMember = "Texto";
            busquedacombo.ValueMember = "Valor";
            busquedacombo.SelectedIndex = 0;
            List<cliente> lista = new cn_cliente().listar();

            foreach (cliente item in lista)
            {
                if (item.Estado)
                    dgdata.Rows.Add(new object[] { item.Documento, item.NombreCompleto });
            }
            CargarUsuarios();

        }

        private void CargarUsuarios()
        {
            dgdata.Rows.Clear(); // Limpiamos las filas existentes en el DataGridView

            //MOSTRAR TODOS LOS USUARIOS
            List<cliente> lista = new cn_cliente().listar();

            foreach (cliente item in lista)
            {

                dgdata.Rows.Add(new object[] {
                    item.Documento, item.NombreCompleto
                });
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

        private void dgdata_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            int iRow = e.RowIndex;
            int iColum = e.ColumnIndex;
            if (iRow >= 0 && iColum > 0)
            {
                _cliente = new cliente()
                {
                    Documento = dgdata.Rows[iRow].Cells["Documento"].Value.ToString(),
                    NombreCompleto = dgdata.Rows[iRow].Cells["NombreCompleto"].Value.ToString()
                };
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
