using entidad;
using negocio;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace proyecto
{
    public partial class fdetalle_venta : Form
    {
        public fdetalle_venta()
        {
            InitializeComponent();
        }

        private void fdetalle_venta_Load(object sender, EventArgs e)
        {
            cmbNumerosDocumento.Select();
            CargarNumerosDeDocumento();

        }

        private void btnbusqueda_Click(object sender, EventArgs e)
        {
            venta oVenta = new cn_venta().ObtenerVenta(cmbNumerosDocumento.Text);

            if (oVenta.IdVenta != 0)
            {

                txtnumerodocumento.Text = oVenta.NumeroDocumento;

                txtfecha.Text = oVenta.FechaRegistro;
                txttipodocumento.Text = oVenta.TipoDocumento;
                txtusuario.Text = oVenta.ousuario.NombreCompleto;


                txtdoccliente.Text = oVenta.DocumentoCliente;
                txtnombrecliente.Text = oVenta.NombreCliente;

                dgdata.Rows.Clear();
                foreach (detalle_venta dv in oVenta.odetalleventa)
                {
                    dgdata.Rows.Add(new object[] { dv.oproducto.Nombre, dv.PrecioVenta, dv.Cantidad, dv.UnidadesMedida, dv.SubTotal, dv.itbis, dv.Valortotal, dv.Galones_a_Litro, dv.Bloque_a_Libra });
                }

                txttotalpagar.Text = oVenta.MontoTotal.ToString("0.00");
                txtmontopago.Text = oVenta.MontoPago.ToString("0.00");
                txtmontocambio.Text = oVenta.MontoCambio.ToString("0.00");


            }


        }

        private void btnlimpiarbuscador_Click(object sender, EventArgs e)
        {
            txtfecha.Text = string.Empty;
            txttipodocumento.Text = string.Empty;
            txtusuario.Text = string.Empty;
            txttipodocumento.Text = string.Empty;
            txtusuario.Text = string.Empty;
            cmbNumerosDocumento.Text = "00001";
            dgdata.Rows.Clear();
            txttotalpagar.Text = "0.00";
            txtmontopago.Text = "0.00";
            txtmontocambio.Text = "0.00";
        }

        public void excel_Click(object sender, EventArgs e)
        {
            // Validación de datos necesarios para crear el PDF
            if (string.IsNullOrEmpty(txtdoccliente.Text))
            {
                MessageBox.Show("No se encontraron resultados", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


            // Obtener datos del negocio para el documento
            Negocio odatos = new cn_negocio().ObtenerDatos();

            // Construir la lista de filas con la información de cada producto
            var dataRows = new List<Dictionary<string, string>>();
            foreach (DataGridViewRow row in dgdata.Rows)
            {
                // Comprobar que la fila no está vacía
                if (row.Cells["Producto"].Value == null)
                    continue;

                var rowData = new Dictionary<string, string>
        {
            {"Producto", Convert.ToString(row.Cells["Producto"].Value)},
            {"Precio", Convert.ToString(row.Cells["Precio"].Value)},
            {"Cantidad", Convert.ToString(row.Cells["Cantidad"].Value)},
            {"UnidadesMedida", Convert.ToString(row.Cells["UnidadesMedida"].Value)},
            {"Galones_a_Litro", Convert.ToString(row.Cells["Galones_a_Litro"].Value)},
            {"Bloque_a_Libra", Convert.ToString(row.Cells["Bloque_a_Libra"].Value)},
            {"SubTotal", Convert.ToString(row.Cells["SubTotal"].Value)},
            {"itbis", Convert.ToString(row.Cells["itbis"].Value)},
            {"Valortotal", Convert.ToString(row.Cells["Valortotal"].Value)}
        };
                dataRows.Add(rowData);
            }

            // Instanciar PDFCreator y crear el PDF
            var pdfCreator = new PDFCreator();
            pdfCreator.CreatePDF(
                txttipodocumento.Text,
                txtnumerodocumento.Text,
                txtdoccliente.Text,
                txtnombrecliente.Text,
                txtfecha.Text,
                txtusuario.Text,
                dataRows,
                txttotalpagar.Text,
                txtmontopago.Text,
                txtmontocambio.Text,
                odatos.Nombre,
                odatos.RUC,
                odatos.Direccion,
                new cn_negocio().ObtenerLogo(out bool obtenido)
            );

        }

        private void CargarNumerosDeDocumento()
        {
            List<venta> ventas = new cn_venta().ObtenerTodasLasVentas();

            cmbNumerosDocumento.Items.Clear();
            foreach (venta venta in ventas)
            {
                cmbNumerosDocumento.Items.Add(venta.NumeroDocumento);
            }

            // Selecciona el primer elemento por defecto (puedes ajustarlo según tus necesidades)
            if (cmbNumerosDocumento.Items.Count > 0)
            {
                cmbNumerosDocumento.SelectedIndex = 0;
            }
        }
    }

}
