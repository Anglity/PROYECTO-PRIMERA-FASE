using entidad;
using negocio;
using proyecto.utlidades;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace proyecto.modales
{
    public partial class md_productos : Form
    {
        public producto _producto { get; set; }
        public md_productos()
        {
            InitializeComponent();
        }

        private void md_productos_Load(object sender, EventArgs e)
        {
            foreach (DataGridViewColumn columna in dgdata.Columns)
            {

                if (columna.Visible == true)
                {
                    busquedacombo.Items.Add(new opcionescombo() { valor = columna.Name, texto = columna.HeaderText });
                }
            }
            busquedacombo.DisplayMember = "Texto";
            busquedacombo.ValueMember = "Valor";
            busquedacombo.SelectedIndex = 0;


            CargarUsuarios();

        }

        private void CargarUsuarios()
        {
            dgdata.Rows.Clear(); // Limpiamos las filas existentes en el DataGridView

            //MOSTRAR TODOS LOS USUARIOS
            List<producto> lista = new cn_producto().listar();

            foreach (producto item in lista)
            {

                dgdata.Rows.Add(new object[] {
                    item.IdProducto,
                    item.Codigo,
                    item.Nombre,
                    item.ocategoria.Descripcion,
                    item.Stock,
                    item.PrecioCompra,
                    item.PrecioVenta
                });
            }
        }

        private void dgdata_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int iRow = e.RowIndex;
            int iColum = e.ColumnIndex;
            if (iRow >= 0 && iColum > 0)
            {
                _producto = new producto()
                {
                    IdProducto = Convert.ToInt32(dgdata.Rows[iRow].Cells["Id"].Value.ToString()),
                    Codigo = dgdata.Rows[iRow].Cells["Codigo"].Value.ToString(),
                    Nombre = dgdata.Rows[iRow].Cells["Nombre"].Value.ToString(),
                    Stock = Convert.ToInt32(dgdata.Rows[iRow].Cells["Stock"].Value.ToString()),
                    PrecioCompra = Convert.ToDecimal(dgdata.Rows[iRow].Cells["PrecioCompra"].Value.ToString()),
                    PrecioVenta = Convert.ToDecimal(dgdata.Rows[iRow].Cells["PrecioVenta"].Value.ToString()),
                };
                this.DialogResult = DialogResult.OK;
                this.Close();
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
    }
}
