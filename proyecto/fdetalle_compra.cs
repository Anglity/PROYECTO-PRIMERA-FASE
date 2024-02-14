
using entidad;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using negocio;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace proyecto
{
    public partial class fdetalle_compra : Form
    {
        public fdetalle_compra()
        {
            InitializeComponent();
            CargarNumerosDeDocumento();
        }

        private void fdetalle_compra_Load(object sender, System.EventArgs e)
        {

        }

        private void btnbusqueda_Click(object sender, System.EventArgs e)
        {
            compra oCompra = new cn_compra().ObtenerCompra(cmbNumerosDocumento.Text);

            if (oCompra.IdCompra != 0)
            {

                txtnumerodocumento.Text = oCompra.NumeroDocumento;

                txtfecha.Text = oCompra.FechaRegistro;
                txttipodocumento.Text = oCompra.TipoDocumento;
                txtusuario.Text = oCompra.ousuario.NombreCompleto;
                txtdocproveedor.Text = oCompra.oproveedor.Documento;
                txtnombreproveedor.Text = oCompra.oproveedor.RazonSocial;

                dgdata.Rows.Clear();
                foreach (detalle_compra dc in oCompra.oDetalleCompra)
                {
                    dgdata.Rows.Add(new object[] { dc.oproducto.Nombre, dc.PrecioCompra, dc.Cantidad, dc.MontoTotal, dc.UnidadMedida });
                }

                txttotalpagar.Text = oCompra.MontoTotal.ToString("0.00");

            }
        }

        private void btnlimpiarbuscador_Click(object sender, System.EventArgs e)
        {
            txtfecha.Text = "";
            txttipodocumento.Text = "";
            txtusuario.Text = "";
            txtdocproveedor.Text = "";
            txtnombreproveedor.Text = "";
            cmbNumerosDocumento.Text = "00001";

            dgdata.Rows.Clear();
            txttotalpagar.Text = "0.00";
        }

        private void excel_Click(object sender, System.EventArgs e)
        {
            if (txttipodocumento.Text == "")
            {
                MessageBox.Show("No se encontraron resultados", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            string Texto_Html = Properties.Resources.PlantillaCompra.ToString();
            Negocio odatos = new cn_negocio().ObtenerDatos();

            Texto_Html = Texto_Html.Replace("@nombrenegocio", odatos.Nombre.ToUpper());
            Texto_Html = Texto_Html.Replace("@docnegocio", odatos.RUC);
            Texto_Html = Texto_Html.Replace("@direcnegocio", odatos.Direccion);

            Texto_Html = Texto_Html.Replace("@tipodocumento", txttipodocumento.Text.ToUpper());
            Texto_Html = Texto_Html.Replace("@numerodocumento", txtnumerodocumento.Text);


            Texto_Html = Texto_Html.Replace("@docproveedor", txtdocproveedor.Text);
            Texto_Html = Texto_Html.Replace("@nombreproveedor", txtnombreproveedor.Text);
            Texto_Html = Texto_Html.Replace("@fecharegistro", txtfecha.Text);
            Texto_Html = Texto_Html.Replace("@usuarioregistro", txtusuario.Text);

            string filas = string.Empty;
            foreach (DataGridViewRow row in dgdata.Rows)
            {
                filas += "<tr>";
                filas += "<td>" + row.Cells["Producto"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["PrecioCompra"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["Cantidad"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["SubTotal"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["UnidadMedida"].Value.ToString() + "</td>";
                filas += "</tr>";
            }
            Texto_Html = Texto_Html.Replace("@filas", filas);
            Texto_Html = Texto_Html.Replace("@montototal", txttotalpagar.Text);

            SaveFileDialog savefile = new SaveFileDialog();
            savefile.FileName = string.Format("Compra_{0}.pdf", txtnumerodocumento.Text);
            savefile.Filter = "Pdf Files|*.pdf";

            if (savefile.ShowDialog() == DialogResult.OK)
            {
                using (FileStream stream = new FileStream(savefile.FileName, FileMode.Create))
                {

                    Document pdfDoc = new Document(PageSize.A4, 25, 25, 25, 25);

                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                    pdfDoc.Open();

                    bool obtenido = true;
                    byte[] byteImage = new cn_negocio().ObtenerLogo(out obtenido);

                    if (obtenido)
                    {
                        iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(byteImage);
                        img.ScaleToFit(60, 60);
                        img.Alignment = iTextSharp.text.Image.UNDERLYING;
                        img.SetAbsolutePosition(pdfDoc.Left, pdfDoc.GetTop(51));
                        pdfDoc.Add(img);
                    }

                    using (StringReader sr = new StringReader(Texto_Html))
                    {
                        XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                    }

                    pdfDoc.Close();
                    stream.Close();
                    MessageBox.Show("Documento Generado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void label4_Click(object sender, System.EventArgs e)
        {

        }

        private void CargarNumerosDeDocumento()
        {
            List<compra> compras = new cn_compra().ObtenerTodasLasCompras();

            cmbNumerosDocumento.Items.Clear();
            foreach (compra compra in compras)
            {
                cmbNumerosDocumento.Items.Add(compra.NumeroDocumento);
            }

            // Selecciona el primer elemento por defecto (puedes ajustarlo según tus necesidades)
            if (cmbNumerosDocumento.Items.Count > 0)
            {
                cmbNumerosDocumento.SelectedIndex = 0;
            }
        }
    }
}
