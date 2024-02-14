using entidad;
using negocio;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace proyecto
{
    public partial class fnegocio : Form
    {
        public fnegocio()
        {
            InitializeComponent();
        }
        public Image ByteToImage(byte[] imageBytes)
        {
            MemoryStream ms = new MemoryStream();
            ms.Write(imageBytes, 0, imageBytes.Length);
            Image image = new Bitmap(ms);

            return image;
        }


        private void fnegocio_Load(object sender, EventArgs e)
        {
            bool obtenido = true;
            byte[] byteimage = new cn_negocio().ObtenerLogo(out obtenido);

            if (obtenido)
                piclogo.Image = ByteToImage(byteimage);

            Negocio datos = new cn_negocio().ObtenerDatos();

            txtnombre.Text = datos.Nombre;
            txtruc.Text = datos.RUC;
            txtdireccion.Text = datos.Direccion;
        }

        private void btnsubir_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;

            OpenFileDialog oOpenFileDialog = new OpenFileDialog();
            oOpenFileDialog.FileName = "Files|*.jpg;*.jpeg;*.png";

            if (oOpenFileDialog.ShowDialog() == DialogResult.OK)
            {

                byte[] byteimage = File.ReadAllBytes(oOpenFileDialog.FileName);
                bool respuesta = new cn_negocio().ActualizarLogo(byteimage, out mensaje);

                if (respuesta)
                    piclogo.Image = ByteToImage(byteimage);
                else
                    MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;

            Negocio obj = new Negocio()
            {
                Nombre = txtnombre.Text,
                RUC = txtruc.Text,
                Direccion = txtdireccion.Text
            };

            bool respuesta = new cn_negocio().GuardarDatos(obj, out mensaje);

            if (respuesta)
                MessageBox.Show("Los cambios fueron guardados", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No se pudo guardar los cambios", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }
    }

}
