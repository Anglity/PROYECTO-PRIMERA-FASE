using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

public class PDFCreator
{
    public void CreatePDF(
        string tipoDocumento,
        string numeroDocumento,
        string docCliente,
        string nombreCliente,
        string fechaRegistro,
        string usuarioRegistro,
        List<Dictionary<string, string>> dataRows,
        string montoTotal,
        string pagoCon,
        string cambio,
        string nombreNegocio, // Datos del negocio
        string docNegocio,
        string direccionNegocio,
        byte[] logoNegocio = null // Logo del negocio como array de bytes
    )
    {
        // Asegúrate de que el archivo HTML está en el directorio de salida, copiado como 'Contenido' y 'Copiar Siempre'
        string pathToHtmlTemplate = Path.Combine(Application.StartupPath, "PlantillaVenta.html");
        string textoHtml = File.ReadAllText(pathToHtmlTemplate);

        textoHtml = textoHtml.Replace("@nombrenegocio", nombreNegocio.ToUpper());
        textoHtml = textoHtml.Replace("@docnegocio", docNegocio);
        textoHtml = textoHtml.Replace("@direcnegocio", direccionNegocio);

        textoHtml = textoHtml.Replace("@tipodocumento", tipoDocumento.ToUpper());
        textoHtml = textoHtml.Replace("@numerodocumento", numeroDocumento);

        textoHtml = textoHtml.Replace("@doccliente", docCliente);
        textoHtml = textoHtml.Replace("@nombrecliente", nombreCliente);
        textoHtml = textoHtml.Replace("@fecharegistro", fechaRegistro);
        textoHtml = textoHtml.Replace("@usuarioregistro", usuarioRegistro);

        string filas = string.Empty;
        foreach (var row in dataRows)
        {
            filas += "<tr>";
            foreach (var cell in row)
            {
                filas += $"<td>{cell.Value}</td>";
            }
            filas += "</tr>";
        }
        textoHtml = textoHtml.Replace("@filas", filas);
        textoHtml = textoHtml.Replace("@montototal", montoTotal);
        textoHtml = textoHtml.Replace("@pagocon", pagoCon);
        textoHtml = textoHtml.Replace("@cambio", cambio);

        // Guardar el archivo PDF
        SaveFileDialog savefile = new SaveFileDialog
        {
            FileName = $"Venta_{numeroDocumento}.pdf",
            Filter = "Pdf Files|*.pdf"
        };

        if (savefile.ShowDialog() == DialogResult.OK)
        {
            using (FileStream stream = new FileStream(savefile.FileName, FileMode.Create))
            {
                Document pdfDoc = new Document(PageSize.A4, 25, 25, 25, 25);
                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();

                // Agregar el logo si está disponible
                if (logoNegocio != null)
                {
                    Image img = Image.GetInstance(logoNegocio);
                    img.ScaleToFit(60, 60);
                    img.Alignment = Image.UNDERLYING;
                    img.SetAbsolutePosition(pdfDoc.Left, pdfDoc.GetTop(51));
                    pdfDoc.Add(img);
                }

                // Convertir el HTML a PDF
                using (StringReader sr = new StringReader(textoHtml))
                {
                    XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                }

                pdfDoc.Close();
                stream.Close();
                MessageBox.Show("Documento Generado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
