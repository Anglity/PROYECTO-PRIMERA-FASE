using ClosedXML.Excel;
using entidad;
using negocio;
using proyecto.utlidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace proyecto
{
    public partial class freporte_compra : Form
    {
        public freporte_compra()
        {
            InitializeComponent();
        }

        private void freporte_compra_Load(object sender, EventArgs e)
        {
            List<proveedor> lista = new cn_proveedor().listar();

            cboproveedor2.Items.Add(new opcionescombo() { valor = 0, texto = "TODOS" });
            foreach (proveedor item in lista)
            {
                cboproveedor2.Items.Add(new opcionescombo() { valor = item.IdProveedor, texto = item.RazonSocial });
            }
            cboproveedor2.DisplayMember = "Texto";
            cboproveedor2.ValueMember = "Valor";
            cboproveedor2.SelectedIndex = 0;


            foreach (DataGridViewColumn columna in dgdata.Columns)
            {
                cbobusqueda.Items.Add(new opcionescombo() { valor = columna.Name, texto = columna.HeaderText });
            }
            cbobusqueda.DisplayMember = "Texto";
            cbobusqueda.ValueMember = "Valor";
            cbobusqueda.SelectedIndex = 0;

        }

        private void btnbuscarresultado_Click(object sender, EventArgs e)
        {

            int idproveedor = Convert.ToInt32(((opcionescombo)cboproveedor2.SelectedItem).valor.ToString());

            List<reporte_compra> lista = new List<reporte_compra>();

            lista = new cn_reporte().Compra(txtfechainicio.Value.ToString("dd/MM/yyyy"), txtfechafin.Value.ToString("dd/MM/yyyy"),
                idproveedor
                );


            dgdata.Rows.Clear();

            foreach (reporte_compra rc in lista)
            {
                dgdata.Rows.Add(new object[] {
                    rc.FechaRegistro,
                    rc.TipoDocumento,
                    rc.NumeroDocumento,
                    rc.MontoTotal,
                    rc.UsuarioRegistro,
                    rc.DocumentoProveedor,
                    rc.RazonSocial,
                    rc.CodigoProducto,
                    rc.NombreProducto,
                    rc.Categoria,
                    rc.PrecioCompra,
                    rc.PrecioVenta,
                    rc.Cantidad,
                    rc.SubTotal,
                    rc.UnidadMedida
                });

            }

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }



        private void excel_Click(object sender, EventArgs e)
        {
            if (dgdata.Rows.Count < 1)
            {

                MessageBox.Show("No hay registros para exportar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            else
            {

                DataTable dt = new DataTable();

                foreach (DataGridViewColumn columna in dgdata.Columns)
                {
                    dt.Columns.Add(columna.HeaderText, typeof(string));
                }

                foreach (DataGridViewRow row in dgdata.Rows)
                {
                    if (row.Visible)
                        dt.Rows.Add(new object[] {
                            row.Cells[0].Value.ToString(),
                            row.Cells[1].Value.ToString(),
                            row.Cells[2].Value.ToString(),
                            row.Cells[3].Value.ToString(),
                            row.Cells[4].Value.ToString(),
                            row.Cells[5].Value.ToString(),
                            row.Cells[6].Value.ToString(),
                            row.Cells[7].Value.ToString(),
                            row.Cells[8].Value.ToString(),
                            row.Cells[9].Value.ToString(),
                            row.Cells[10].Value.ToString(),
                            row.Cells[11].Value.ToString(),
                            row.Cells[12].Value.ToString(),
                            row.Cells[13].Value.ToString(),
                            row.Cells[14].Value.ToString()
                        });
                }

                SaveFileDialog savefile = new SaveFileDialog();
                savefile.FileName = string.Format("ReporteCompras_{0}.xlsx", DateTime.Now.ToString("ddMMyyyyHHmmss"));
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

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            string columnaFiltro = ((opcionescombo)cbobusqueda.SelectedItem).valor.ToString();

            if (dgdata.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgdata.Rows)
                {

                    if (row.Cells[columnaFiltro].Value.ToString().Trim().ToUpper().Contains(txtbusqueda.Text.Trim().ToUpper()))
                        row.Visible = true;
                    else
                        row.Visible = false;
                }
            }
        }

        private void btnbuscar_Click_1(object sender, EventArgs e)
        {
            string columnaFiltro = ((opcionescombo)cbobusqueda.SelectedItem).valor.ToString();

            if (dgdata.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgdata.Rows)
                {

                    if (row.Cells[columnaFiltro].Value.ToString().Trim().ToUpper().Contains(txtbusqueda.Text.Trim().ToUpper()))
                        row.Visible = true;
                    else
                        row.Visible = false;
                }
            }
        }

        private void btnlimpiarbuscador_Click(object sender, EventArgs e)
        {
            txtbusqueda.Text = "";
            foreach (DataGridViewRow row in dgdata.Rows)
            {
                row.Visible = true;
            }
        }


    }
}
