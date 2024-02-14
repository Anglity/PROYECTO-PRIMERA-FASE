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
    public partial class freporte_venta : Form
    {
        public freporte_venta()
        {
            InitializeComponent();
        }

        private void freporte_venta_Load(object sender, EventArgs e)
        {
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
            List<reporte_venta> lista = new List<reporte_venta>();
            lista = new cn_reporte().Venta(txtfechainicio.Value.ToString("dd/MM/yyyy"), txtfechafin.Value.ToString("dd/MM/yyyy"));
            dgdata.Rows.Clear();

            decimal sumaTotal = 0M;  // Inicializamos la variable para la suma

            foreach (reporte_venta rv in lista)
            {
                dgdata.Rows.Add(new object[] {
            rv.FechaRegistro,
            rv.TipoDocumento,
            rv.NumeroDocumento,
            rv.MontoTotal,
            rv.UsuarioRegistro,
            rv.DocumentoCliente,
            rv.NombreCliente,
            rv.CodigoProducto,
            rv.NombreProducto,
            rv.Categoria,
            rv.PrecioVenta,
            rv.Cantidad,
            rv.SubTotal,
            rv.itbis,
            rv.Valortotal,
            rv.UnidadesMedida,
            rv.Galones_a_Litro,
            rv.Bloque_a_Libra
        });

                decimal monto;
                if (decimal.TryParse(rv.Valortotal, out monto))
                {
                    sumaTotal += monto;  // Sumamos el monto total de cada registro si la conversión es exitosa
                }

            }

            textBoxSumaTotal.Text = sumaTotal.ToString("N2");  // Mostramos la suma en el TextBox

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

        private void btnlimpiarbuscador_Click(object sender, EventArgs e)
        {
            txtbusqueda.Text = "";
            foreach (DataGridViewRow row in dgdata.Rows)
            {
                row.Visible = true;
            }
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
                              row.Cells[14].Value.ToString(),
                                row.Cells[15].Value.ToString(),
                                  row.Cells[16].Value.ToString(),
                                    row.Cells[17].Value.ToString()
                        });
                }

                SaveFileDialog savefile = new SaveFileDialog();
                savefile.FileName = string.Format("ReporteVentas_{0}.xlsx", DateTime.Now.ToString("ddMMyyyyHHmmss"));
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

        private void txtfechafin_ValueChanged(object sender, EventArgs e)
        {

        }
    }

}
