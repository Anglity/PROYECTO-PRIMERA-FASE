using negocio;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyecto
{

    public partial class ffcrearreceta : Form

    {
        private string nombrereceta;

        private string tiempo;
        private string preparacion; // Declaración a nivel de clase

        // Lista para almacenar las notificaciones
        private List<string> notificaciones = new List<string>();

        public string ultimoCorreoEnviado;

        private string cantidadProduccion;


        public ffcrearreceta()
        {
            InitializeComponent();
            CargarImagenLogo();
            CargarRecetas();
            this.refresh.Click += new System.EventHandler(this.refresh_Click);


            if (File.Exists("ultimoCorreo.txt"))
            {
                ultimoCorreoEnviado = File.ReadAllText("ultimoCorreo.txt");
            }

        }

        private void botonProductos_Click(object sender, EventArgs e)
        {
            nombrereceta = Microsoft.VisualBasic.Interaction.InputBox("Introduce el nombre de la receta", "Nombre de Receta", string.Empty);

            // Verificar si el usuario presionó "Cancelar" o cerró la InputBox
            if (string.IsNullOrEmpty(nombrereceta))
            {
                // Salir del método sin hacer nada más
                return;
            }

            // Validar que el nombre de la receta no esté vacío
            while (string.IsNullOrWhiteSpace(nombrereceta))
            {
                MessageBox.Show("Por favor, introduce un nombre válido para la receta.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nombrereceta = Microsoft.VisualBasic.Interaction.InputBox("Introduce el nombre de la receta", "Nombre de Receta", string.Empty);

                // Nuevamente, verificar si el usuario presionó "Cancelar" o cerró la InputBox
                if (string.IsNullOrEmpty(nombrereceta))
                {
                    // Salir del método si se presionó "Cancelar"
                    return;
                }
            }

            var respuesta = MessageBox.Show("¿Quieres usar los productos predeterminados?", "Seleccionar Productos", MessageBoxButtons.YesNo);

            if (respuesta == DialogResult.Yes)
            {
                MostrarProductos();
            }
            else
            {
                AgregarProductosManualmente();
            }
        }
        private List<string> productosSeleccionados = new List<string>();

        private Dictionary<string, decimal> productosConPorciones = new Dictionary<string, decimal>();
        private void MostrarProductos()
        {

            productosSeleccionados.Clear();
            productosConPorciones.Clear();

            Form productosForm = new Form
            {
                Text = "Selecciona los productos",
                StartPosition = FormStartPosition.CenterScreen,
                Size = new Size(400, 400)
            };

            string[] productos = { "cuajo", "peroxido", "colorante", "cultivo", "calcio", "catalza", "catibar", "sal", "leche" };
            int yPos = 20;

            foreach (string producto in productos)
            {
                CheckBox cb = new CheckBox
                {
                    Text = producto,
                    Location = new Point(20, yPos),
                    Font = new Font("Arial", 10, FontStyle.Regular)
                };
                yPos += 30;
                productosForm.Controls.Add(cb);
            }

            Button btnFinalizar = new Button
            {
                Text = "Finalizar",
                Location = new Point(100, yPos),
                Size = new Size(100, 40),
                Font = new Font("Arial", 10, FontStyle.Bold)
            };

            btnFinalizar.Click += (sender, e) =>
            {
                bool algunProductoSeleccionado = false;
                foreach (CheckBox cb in productosForm.Controls.OfType<CheckBox>())
                {
                    if (cb.Checked)
                    {
                        productosSeleccionados.Add(cb.Text);
                        algunProductoSeleccionado = true;
                    }
                }


                if (!algunProductoSeleccionado)
                {
                    MessageBox.Show("Por favor, selecciona al menos un producto.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                productosForm.Close();

                var respuesta = MessageBox.Show("¿Quieres agregar más productos?", "Agregar Productos", MessageBoxButtons.YesNo);
                if (respuesta == DialogResult.Yes)
                {
                    AgregarProductosManualmente();
                }
                else
                {


                    MostrarFormularioPorciones();
                    SolicitarInformacionReceta();
                    SolicitarYGuardarImagenReceta();
                    ActualizarDataGridView();

                }
            };

            productosForm.Controls.Add(btnFinalizar);
            productosForm.ShowDialog();

        }

        private void SolicitarInformacionReceta()
        {
            preparacion = Microsoft.VisualBasic.Interaction.InputBox("Describe la preparación de la receta", "Preparación de la Receta", string.Empty);
            tiempo = Microsoft.VisualBasic.Interaction.InputBox("¿Cuánto tiempo toma preparar la receta?", "Tiempo de Preparación", string.Empty);

            // Nuevo paso para preguntar la cantidad de unidades a producir
            cantidadProduccion = Microsoft.VisualBasic.Interaction.InputBox("¿Cuántas unidades deseas producir con esta receta?", "Cantidad de Producción", "1");

            // Validación para asegurarse de que se ingrese un número válido
            while (!int.TryParse(cantidadProduccion, out _) || int.Parse(cantidadProduccion) <= 0)
            {
                MessageBox.Show("Por favor, introduce un número válido para la cantidad de producción.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cantidadProduccion = Microsoft.VisualBasic.Interaction.InputBox("¿Cuántas unidades deseas producir con esta receta?", "Cantidad de Producción", "1");
            }

        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            var respuesta = MessageBox.Show("¿Quieres agregar más productos?",
                                    "Agregar Productos",
                                    MessageBoxButtons.YesNo);

            Form formularioMostrarProductos = ((Button)sender).FindForm();

            if (respuesta == DialogResult.Yes)
            {

                formularioMostrarProductos.Close();
                AgregarProductosManualmente();
            }
            else
            {
                formularioMostrarProductos.Close();
            }

        }

        private void AgregarProductosManualmente()
        {
            Form formAgregarProductos = new Form
            {
                Text = "Agregar Productos Manualmente",
                Size = new Size(400, 300),
                StartPosition = FormStartPosition.CenterScreen // Centra el formulario en la pantalla
            };

            Label lblNombreProducto = new Label
            {
                Text = "Nombre del Producto:",
                Location = new Point(10, 10),
                Size = new Size(180, 20)
            };
            formAgregarProductos.Controls.Add(lblNombreProducto);

            TextBox txtNuevoProducto = new TextBox
            {
                Location = new Point(10, 40),
                Width = 300
            };
            formAgregarProductos.Controls.Add(txtNuevoProducto);

            Button btnAgregar = new Button
            {
                Text = "Agregar",
                Location = new Point(30, 100),
                Size = new Size(100, 40),
                Font = new Font("Arial", 10, FontStyle.Bold)
            };
            btnAgregar.Click += (sender, e) =>
            {
                string producto = txtNuevoProducto.Text.Trim();
                if (string.IsNullOrEmpty(producto))
                {
                    MessageBox.Show("Por favor, introduce un nombre para el producto.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                productosSeleccionados.Add(producto);
                txtNuevoProducto.Clear();
            };
            formAgregarProductos.Controls.Add(btnAgregar);

            Button btnTerminar = new Button
            {
                Text = "Terminar",
                Location = new Point(200, 100),
                Size = new Size(100, 40),
                Font = new Font("Arial", 10, FontStyle.Bold)
            };

            btnTerminar.Click += (sender, e) =>
            {
                formAgregarProductos.Close();

                FinalizarSeleccionDeProductos();

                MostrarFormularioPorciones();

                preparacion = Microsoft.VisualBasic.Interaction.InputBox("Describe la preparación de la receta", "Preparación de la Receta", string.Empty);
                tiempo = Microsoft.VisualBasic.Interaction.InputBox("¿Cuánto tiempo toma preparar la receta?", "Tiempo de Preparación", string.Empty);


                SolicitarYGuardarImagenReceta();
                MostrarResumenReceta(nombrereceta, productosConPorciones, preparacion, tiempo, null);
                ActualizarDataGridView();
            };
            formAgregarProductos.Controls.Add(btnTerminar);

            formAgregarProductos.ShowDialog();
        }

        private void MostrarFormularioPorciones()
        {
            Form formularioPorciones = new Form
            {
                Text = "Asignar Porciones a Productos",
                Size = new Size(400, 400),
                StartPosition = FormStartPosition.CenterScreen // Centra el formulario en la pantalla
            };

            int yPos = 20;
            Dictionary<string, NumericUpDown> controlesPorciones = new Dictionary<string, NumericUpDown>();

            foreach (string producto in productosSeleccionados)
            {
                Label lblProducto = new Label
                {
                    Text = producto,
                    Location = new Point(10, yPos),
                    Size = new Size(120, 30),
                    Font = new Font("Arial", 10, FontStyle.Bold) // Estilo de letra
                };
                formularioPorciones.Controls.Add(lblProducto);

                NumericUpDown numPorcion = new NumericUpDown
                {
                    Location = new Point(140, yPos),
                    Size = new Size(70, 30),
                    Font = new Font("Arial", 10, FontStyle.Regular), // Estilo de letra
                    Minimum = 0,
                    Maximum = 1000,
                    Increment = 1
                };
                formularioPorciones.Controls.Add(numPorcion);
                controlesPorciones.Add(producto, numPorcion);

                yPos += 40;
            }

            Button btnAceptar = new Button
            {
                Text = "Aceptar",
                Location = new Point(150, yPos),
                Size = new Size(100, 40),
                Font = new Font("Arial", 10, FontStyle.Bold) // Estilo de letra
            };
            btnAceptar.Click += (sender, e) =>
            {
                bool todosMayorCero = true;
                foreach (var control in controlesPorciones)
                {
                    if (control.Value.Value <= 0)
                    {
                        todosMayorCero = false;
                        MessageBox.Show($"Por favor, asigna una cantidad mayor a 0 para el producto '{control.Key}'.", "Cantidad Inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    }
                }

                if (todosMayorCero)
                {
                    productosConPorciones.Clear();
                    foreach (var kvp in controlesPorciones)
                    {
                        productosConPorciones[kvp.Key] = kvp.Value.Value;
                    }
                    formularioPorciones.Close();
                }
            };
            formularioPorciones.Controls.Add(btnAceptar);

            formularioPorciones.ShowDialog();
        }

        private void FinalizarSeleccionDeProductos()
        {
            // Suponiendo que 'productosSeleccionados' es tu lista de productos
            foreach (var producto in productosSeleccionados)
            {
                string mensaje;
                bool resultado = new cn_producto().VerificarYCrearProducto(producto, out mensaje);

                // Puedes optar por manejar el mensaje de alguna manera, por ejemplo, mostrándolo en un MessageBox o en un log.
                if (!resultado)
                {
                    MessageBox.Show("Error al verificar/crear el producto: " + mensaje);
                }
            }

        }

        private void ActualizarDataGridView()
        {
            // Crear una cadena para todos los productos y sus cantidades
            string productosYcantidades = string.Join(", ", productosConPorciones.Select(p => p.Key + ":" + p.Value));

            DataGridViewRow row = new DataGridViewRow();
            row.CreateCells(dgdata);

            row.Cells[0].Value = nombrereceta; // Nombre de la receta
            row.Cells[1].Value = productosYcantidades; // Todos los productos y cantidades
            row.Cells[2].Value = preparacion; // Preparación
            row.Cells[3].Value = tiempo; // Tiempo


            // Convertir la imagen a un arreglo de bytes si no es null
            byte[] imagenEnBytes = null;
            if (imagenReceta != null)
            {
                imagenEnBytes = ImageToByteArray(imagenReceta);
            }


            else
            {
                row.Cells[4].Value = null; // O asignar un valor predeterminado o null
            }

            // Agregar la fila al DataGridView
            dgdata.Rows.Add(row);

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            if (dgdata.SelectedRows.Count == 1)
            {
                DataGridViewRow row = dgdata.SelectedRows[0];

                // Cargar los datos existentes de la receta
                string nombreReceta = row.Cells["nombre_receta"].Value.ToString();
                string productos = row.Cells["producto"].Value.ToString();
                string preparacion = row.Cells["Preparacion1"].Value.ToString();
                string tiempo = row.Cells["tiempo1"].Value.ToString();

                // Solicitar edición de los datos
                nombreReceta = Microsoft.VisualBasic.Interaction.InputBox("Modificar nombre de la receta:", "Nombre de Receta", nombreReceta);
                productos = Microsoft.VisualBasic.Interaction.InputBox("Modificar lista de productos (separados por comas):", "Productos", productos);
                preparacion = Microsoft.VisualBasic.Interaction.InputBox("Modificar preparación de la receta:", "Preparación", preparacion);
                tiempo = Microsoft.VisualBasic.Interaction.InputBox("Modificar tiempo de preparación:", "Tiempo", tiempo);

                // Actualizar la fila seleccionada con los nuevos datos
                row.Cells["nombre_receta"].Value = nombreReceta;
                row.Cells["producto"].Value = productos;
                row.Cells["Preparacion1"].Value = preparacion;
                row.Cells["tiempo1"].Value = tiempo;



            }
            else
            {
                MessageBox.Show("Por favor, selecciona una receta para modificar.");
            }
        }
        private void MostrarResumenReceta(string nombreReceta, Dictionary<string, decimal> productosConPorciones, string preparacion, string tiempo, Image imagenReceta)
        {
            Form resumenForm = new Form
            {
                Text = "Resumen de la Receta",
                StartPosition = FormStartPosition.CenterScreen,
                Size = new Size(650, 700), // Ajusta el tamaño del formulario para acomodar tanto el texto como la imagen
                BackColor = Color.White
            };

            StringBuilder resumen = new StringBuilder();
            resumen.AppendLine($"Nombre de la Receta: {nombreReceta}");
            resumen.AppendLine("\nProductos y Porciones:");
            foreach (var item in productosConPorciones)
            {
                resumen.AppendLine($"- {item.Key}: {item.Value} unidades");
            }
            resumen.AppendLine($"\nPreparación: {preparacion}");
            resumen.AppendLine($"\nTiempo Estimado: {tiempo}");

            TextBox txtResumen = new TextBox
            {
                Location = new Point(10, 10),
                Size = new Size(380, 550), // Ajusta el ancho para dejar espacio a la imagen
                Multiline = true,
                ReadOnly = true,
                Text = resumen.ToString(),
                ScrollBars = ScrollBars.Vertical,
                Font = new Font("Consolas", 12, FontStyle.Regular),
                BackColor = Color.White
            };
            resumenForm.Controls.Add(txtResumen);

            PictureBox pictureBox = new PictureBox
            {
                Location = new Point(400, 10),
                Size = new Size(200, 200),
                SizeMode = PictureBoxSizeMode.StretchImage,
                BorderStyle = BorderStyle.FixedSingle
            };

            if (imagenReceta != null)
            {
                pictureBox.Image = imagenReceta;
            }
            resumenForm.Controls.Add(pictureBox);

            Button btnAceptar = new Button
            {
                Text = "Aceptar",
                Location = new Point(350, 570), // Cambia la coordenada Y según necesites
                Size = new Size(100, 50),
                Font = new Font("Arial", 12, FontStyle.Bold),
                BackColor = Color.LightGreen,
                ForeColor = Color.Black
            };
            btnAceptar.Click += (sender, e) => resumenForm.Close();
            resumenForm.Controls.Add(btnAceptar);

            resumenForm.ShowDialog();
        }

        private void btnsubir_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;

            OpenFileDialog oOpenFileDialog = new OpenFileDialog();
            oOpenFileDialog.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png";

            if (oOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Guardar la imagen en el sistema de archivos
                    string filePath = Path.Combine(Application.StartupPath, "logo.jpg");
                    File.Copy(oOpenFileDialog.FileName, filePath, true);

                    // Cargar la imagen en el PictureBox
                    piclogo.Image = Image.FromFile(filePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar la imagen: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void CargarImagenLogo()
        {
            string imagePath = Path.Combine(Application.StartupPath, "logo.jpg");
            if (File.Exists(imagePath))
            {
                try
                {
                    piclogo.Image = Image.FromFile(imagePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar la imagen: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public Image ByteToImage(byte[] imageBytes)
        {
            using (MemoryStream ms = new MemoryStream(imageBytes))
            {
                return Image.FromStream(ms);
            }
        }


        private Image imagenReceta; // Para almacenar la imagen de la receta

        private void SolicitarYGuardarImagenReceta()
        {
            var respuesta = MessageBox.Show("¿Deseas agregar una imagen a la receta?", "Agregar Imagen", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (respuesta == DialogResult.Yes)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog
                {
                    Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png",
                    Title = "Seleccionar imagen de la receta"
                };

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    imagenReceta = Image.FromFile(openFileDialog.FileName);
                }
                else
                {
                    imagenReceta = null;
                }
            }
        }

        private void dgdata_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0) // Verifica que el índice de la fila sea válido
            {
                DataGridViewRow row = dgdata.Rows[e.RowIndex];

                // Obtener los datos de la receta de la fila seleccionada
                string nombreReceta = row.Cells["nombre_receta"].Value?.ToString() ?? string.Empty;
                string productos = row.Cells["producto"].Value?.ToString() ?? string.Empty;
                string preparacion = row.Cells["Preparacion1"].Value?.ToString() ?? string.Empty;
                string tiempo = row.Cells["tiempo1"].Value?.ToString() ?? string.Empty;

                // Convertir la cadena de productos en un diccionario si es necesario
                var productosConPorciones = ConvertirCadenaAProductos(productos);

                // Obtener la imagen de la receta
                Image imagenReceta = null;
                if (row.Cells["Imagen"].Value is Image)
                {
                    imagenReceta = (Image)row.Cells["Imagen"].Value;
                }

                // Mostrar el resumen de la receta junto con la imagen
                MostrarResumenReceta(nombreReceta, productosConPorciones, preparacion, tiempo, imagenReceta);
            }
        }
        // Método para convertir la cadena de productos en un diccionario
        private Dictionary<string, decimal> ConvertirCadenaAProductos(string cadenaProductos)
        {
            var diccionario = new Dictionary<string, decimal>();

            // Suponiendo que la cadena de productos está en el formato "producto1: cantidad1, producto2: cantidad2, ..."
            var pares = cadenaProductos.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var par in pares)
            {
                var partes = par.Split(':');
                if (partes.Length == 2)
                {
                    string producto = partes[0].Trim();
                    decimal cantidad = decimal.Parse(partes[1].Trim());
                    diccionario[producto] = cantidad;
                }
            }

            return diccionario;
        }

        public byte[] ImageToByteArray(Image image)
        {
            using (var ms = new MemoryStream())
            {
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                return ms.ToArray();
            }
        }
        private void iconButton2_Click_1(object sender, EventArgs e)
        {
            // Verificar si hay productos seleccionados y una receta para guardar
            if (productosConPorciones.Count == 0 || string.IsNullOrEmpty(nombrereceta) || string.IsNullOrEmpty(preparacion) || string.IsNullOrEmpty(tiempo))
            {
                MessageBox.Show("No hay datos suficientes para crear una nueva receta. Por favor, completa todos los campos.", "Datos insuficientes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Crear una cadena para todos los productos y sus cantidades
            string productosYcantidades = string.Join(", ", productosConPorciones.Select(p => p.Key + ":" + p.Value));
            string mensajeError = string.Empty;
            cn_receta cnReceta = new cn_receta();

            // Convertir la imagen a un arreglo de bytes si no es null
            byte[] imagenEnBytes = null;
            if (imagenReceta != null)
            {
                imagenEnBytes = ImageToByteArray(imagenReceta);
            }

            // Crear un objeto receta con la imagen convertida a bytes
            receta nuevaReceta = new receta
            {
                NombreReceta = nombrereceta,
                Productos = productosYcantidades,
                Preparacion = preparacion,
                Tiempo = tiempo,
                Imagen = imagenEnBytes, // Usar la imagen convertida

                // Asignar la cantidad de producción
                CantidadProduccion = int.Parse(cantidadProduccion)
            };

            // Intentar registrar la receta y manejar el resultado
            int idReceta = cnReceta.Registrar(nuevaReceta, out mensajeError);
            if (idReceta > 0)
            {
                MessageBox.Show("Receta guardada con éxito!");


            }
            else
            {
                MessageBox.Show("Error al guardar la receta: " + mensajeError);

                // Pregunta si quiere enviar el correo inmediatamente
                string ultimoCorreo = LeerUltimoCorreo();
                string correoAUtilizar = null;

                if (!string.IsNullOrEmpty(ultimoCorreo))
                {
                    if (MessageBox.Show("¿Quieres usar el último correo enviado (" + ultimoCorreo + ")?", "Reutilizar Correo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        correoAUtilizar = ultimoCorreo;
                    }
                }

                if (string.IsNullOrEmpty(correoAUtilizar))
                {
                    usuarios2 formUsuarios = new usuarios2();
                    if (formUsuarios.ShowDialog() == DialogResult.OK)
                    {
                        var usuarioSeleccionado = formUsuarios.UsuarioSeleccionado;
                        if (usuarioSeleccionado != null)
                        {
                            correoAUtilizar = usuarioSeleccionado.Correo;
                            GuardarUltimoCorreo(correoAUtilizar);
                        }
                    }
                }

                if (!string.IsNullOrEmpty(correoAUtilizar))
                {
                    // Enviar correo electrónico en segundo plano
                    Task.Run(async () =>
                    {
                        await EnviarCorreoRecetaAsync(nuevaReceta.NombreReceta, nuevaReceta.Productos, nuevaReceta.Preparacion, nuevaReceta.Tiempo, correoAUtilizar);
                    });
                }
            }

            // Agregar una notificación
            string notificacion = $"Receta '{nuevaReceta.NombreReceta}' creada con éxito.";
            ServicioNotificaciones.AgregarNotificacion(notificacion);

            CargarRecetas(); // Actualizar el DataGridView   
        }

        private void CargarRecetas()
        {
            try
            {
                dgdata.Rows.Clear();

                List<receta> listaRecetas = new cn_receta().Listar();
                foreach (receta receta in listaRecetas)
                {
                    Image imagen = null;
                    if (receta.Imagen != null && receta.Imagen.Length > 0)
                    {
                        imagen = ByteToImage(receta.Imagen); // Convertir byte[] a Image
                    }

                    dgdata.Rows.Add(receta.NombreReceta, receta.Productos, receta.Preparacion, receta.Tiempo, imagen);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar recetas: " + ex.Message);
            }
        }

        private void refresh_Click(object sender, EventArgs e)
        {
            CargarRecetas();
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            if (dgdata.SelectedRows.Count > 0)
            {
                var confirmResult = MessageBox.Show("¿Estás seguro de querer eliminar esta receta?",
                                                    "Confirmar Eliminación",
                                                    MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    string nombreReceta = dgdata.SelectedRows[0].Cells["nombre_receta"].Value.ToString(); // Cambiar por el nombre real de la columna
                    string mensaje;
                    cn_receta cnReceta = new cn_receta();
                    bool resultado = cnReceta.EliminarPorNombre(nombreReceta, out mensaje);

                    if (resultado)
                    {
                        MessageBox.Show("Receta eliminada con éxito.");
                        CargarRecetas(); // Actualizar la lista de recetas
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar: " + mensaje);
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona una receta para eliminar.");
            }


        }

        private async Task EnviarCorreoRecetaAsync(string nombreReceta, string productos, string preparacion, string tiempo, string correoDestinatario)
        {

            var apiKey = "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"; // Reemplaza con tu clave API real
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("colang153@gmail.com", "Angel");
            var to = new EmailAddress(correoDestinatario, "Delicate");

            var msg = new SendGridMessage()
            {
                From = from,
                TemplateId = "d-99b9744ab52442ff800048c77f5f54e8" // Reemplaza con el ID de tu plantilla
            };

            // Configurar los datos que se enviarán a la plantilla
            var templateData = new
            {
                nombreReceta = nombreReceta,
                productos = productos,
                preparacion = preparacion,
                tiempo = tiempo
            };

            msg.SetTemplateData(templateData);

            // Agregar destinatario
            msg.AddTo(to);

            // Si deseas adjuntar una imagen, debes agregarla aquí

            var response = await client.SendEmailAsync(msg);

            // Manejar la respuesta
            MessageBox.Show($"Correo enviado. Respuesta del servidor: {response.StatusCode}");

            ultimoCorreoEnviado = correoDestinatario;
        }
        private void iconButton3_Click(object sender, EventArgs e)
        {
            if (dgdata.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgdata.SelectedRows[0];
                string nombreReceta = row.Cells["nombre_receta"].Value?.ToString() ?? string.Empty;
                string productos = row.Cells["producto"].Value?.ToString() ?? string.Empty;
                string preparacion = row.Cells["Preparacion1"].Value?.ToString() ?? string.Empty;
                string tiempo = row.Cells["tiempo1"].Value?.ToString() ?? string.Empty;

                string ultimoCorreo = LeerUltimoCorreo();
                string correoAUtilizar = null;

                if (!string.IsNullOrEmpty(ultimoCorreo))
                {
                    if (MessageBox.Show("¿Quieres usar el último correo enviado (" + ultimoCorreo + ")?", "Reutilizar Correo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        correoAUtilizar = ultimoCorreo;
                    }
                }

                if (string.IsNullOrEmpty(correoAUtilizar))
                {
                    usuarios2 formUsuarios = new usuarios2();
                    if (formUsuarios.ShowDialog() == DialogResult.OK)
                    {
                        var usuarioSeleccionado = formUsuarios.UsuarioSeleccionado;
                        if (usuarioSeleccionado != null)
                        {
                            correoAUtilizar = usuarioSeleccionado.Correo;
                            GuardarUltimoCorreo(correoAUtilizar);
                        }
                    }
                }

                if (!string.IsNullOrEmpty(correoAUtilizar))
                {
                    // Enviar correo electrónico en segundo plano
                    Task.Run(async () =>
                    {
                        await EnviarCorreoRecetaAsync(nombreReceta, productos, preparacion, tiempo, correoAUtilizar);
                    });
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona una receta para enviar.");
            }
        }

        private async Task MostrarFormularioUsuariosYEnviarCorreo(receta recetaGuardada)
        {
            usuarios2 formUsuarios = new usuarios2();
            if (formUsuarios.ShowDialog() == DialogResult.OK)
            {
                var usuarioSeleccionado = formUsuarios.UsuarioSeleccionado;
                if (usuarioSeleccionado != null)
                {
                    // Envía el correo de forma asincrónica
                    await EnviarCorreoRecetaAsync(recetaGuardada.NombreReceta, recetaGuardada.Productos, recetaGuardada.Preparacion, recetaGuardada.Tiempo, usuarioSeleccionado.Correo);
                }
            }
        }
        private void GuardarUltimoCorreo(string correo)
        {
            try
            {
                File.WriteAllText(Path.Combine(Application.StartupPath, "ultimoCorreo.txt"), correo);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el último correo: " + ex.Message);
            }
        }
        private string LeerUltimoCorreo()
        {
            try
            {
                string filePath = Path.Combine(Application.StartupPath, "ultimoCorreo.txt");
                if (File.Exists(filePath))
                {
                    return File.ReadAllText(filePath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al leer el último correo: " + ex.Message);
            }

            return null;
        }

        private void ffcrearreceta_Load(object sender, EventArgs e)
        {

        }
    }
}
