using ClosedXML.Excel;
using entidad;
using negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace proyecto
{
    public partial class freporte_produccion : Form
    {
        public freporte_produccion()
        {
            InitializeComponent();
            // Cargar productores o proveedores
            List<reporte_produccion> lista = new List<reporte_produccion>();

        }

        private void freporte_produccion_Load(object sender, EventArgs e)
        {

        }

        private void btnbuscarresultado_Click(object sender, EventArgs e)
        {


            // Obtener la lista de reportes de producción (ajusta los nombres de las clases y métodos según tu implementación)
            List<reporte_produccion> lista = new cn_reporte().Produccion(txtfechainicio.Value.ToString("dd/MM/yyyy"), txtfechafin.Value.ToString("dd/MM/yyyy"));

            // Limpiar las filas existentes
            dgdata.Rows.Clear();

            // Añadir nuevas filas desde la lista de reportes de producción
            foreach (reporte_produccion rp in lista)
            {
                dgdata.Rows.Add(new object[] {
        rp.FechaProduccion,
        rp.Nombre,
        rp.Stock,
        rp.CantidadCheddar,
        rp.CantidadDanes,
        rp.UnidadMedidaGenerica,
        rp.CantidadTotal
    });
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
    }
}
