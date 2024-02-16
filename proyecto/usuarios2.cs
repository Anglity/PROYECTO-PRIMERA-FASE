using entidad;
using negocio;
using proyecto.utlidades;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyecto
{
    public partial class usuarios2 : Form
    {
        public usuario UsuarioSeleccionado { get; private set; }
        public usuarios2()
        {
            InitializeComponent();
        }


        private void usuarios2_Load(object sender, EventArgs e)
        {
            estado2.Items.Add(new opcionescombo() { valor = 1, texto = "Activo" });
            estado2.Items.Add(new opcionescombo() { valor = 0, texto = "No Activo" });
            estado2.DisplayMember = "Texto";
            estado2.ValueMember = "Valor";
            estado2.SelectedIndex = 0;

            List<rol> listaRol = new cn_rol().listar();

            foreach (rol item in listaRol)
            {
                rol2.Items.Add(new opcionescombo() { valor = item.IdRol, texto = item.Descripcion });
            }
            rol2.DisplayMember = "Texto";
            rol2.ValueMember = "Valor";
            rol2.SelectedIndex = 0;

            foreach (DataGridViewColumn columna in dgdata.Columns)
            {
                if (columna.Visible == true && columna.Name != "btnseleccionar")
                {
                    busquedacombo.Items.Add(new opcionescombo() { valor = columna.Name, texto = columna.HeaderText });
                }
            }
            busquedacombo.DisplayMember = "Texto";
            busquedacombo.ValueMember = "Valor";
            busquedacombo.SelectedIndex = 0;

            CargarUsuarios(); // Agregamos una llamada para cargar los usuarios en el DataGridView
        }

        private void CargarUsuarios()
        {
            dgdata.Rows.Clear(); // Limpiamos las filas existentes en el DataGridView

            //MOSTRAR TODOS LOS USUARIOS
            List<usuario> listaUsuario = new cn_usuario().listar();

            foreach (usuario item in listaUsuario)
            {
                string estadoTexto = item.Estado ? "Activo" : "No Activo";
                dgdata.Rows.Add(new object[] { string.Empty,item.IdUsuario,item.Documento,item.NombreCompleto,item.Correo,item.Clave,
                item.oRol.IdRol,
                item.oRol.Descripcion,
                estadoTexto // Asignamos directamente el texto "Activo" o "No Activo"
                });
            }
        }

        private async void btnguardar_Click_1(object sender, EventArgs e)
        {
            string Mensaje = string.Empty;

            // Generar contraseña aleatoria
            string contrasenaAleatoria = GenerarContrasenaAleatoria(10); // Puedes ajustar la longitud

            // Crear el objeto usuario con la nueva contraseña
            usuario objusuario = new usuario()
            {
                IdUsuario = Convert.ToInt32(txtid.Text),
                Documento = nombreusuario.Text,
                NombreCompleto = ncompleto.Text,
                Correo = correo2.Text,
                Clave = contrasenaAleatoria,
                oRol = new rol() { IdRol = Convert.ToInt32(((opcionescombo)rol2.SelectedItem).valor) },
                Estado = Convert.ToInt32(((opcionescombo)estado2.SelectedItem).valor) == 1 ? true : false,
                // Inicializar los campos según la lógica de negocio
                PrimerInicioSesion = true, // Suponiendo que siempre es true al crear un nuevo usuario
                ClaveCambiada = null // Puede ser null o un valor específico según la lógica de negocio

            };

            if (objusuario.IdUsuario == 0) // Registro de un nuevo usuario
            {
                int idusuariogenerado = new cn_usuario().Registrar(objusuario, out Mensaje);

                if (idusuariogenerado != 0)
                {
                    string estadoTexto = objusuario.Estado ? "Activo" : "No Activo";
                    dgdata.Rows.Add(new object[] { string.Empty, idusuariogenerado, nombreusuario.Text, ncompleto.Text, correo2.Text, contrasenaAleatoria,
        ((opcionescombo)rol2.SelectedItem).valor.ToString(),
        ((opcionescombo)rol2.SelectedItem).texto.ToString(),
        estadoTexto
    });

                    limpiar();

                    // Enviar correo electrónico solo cuando se registra un nuevo usuario
                    await EnviarCorreoBienvenida(objusuario.Correo, objusuario.NombreCompleto, contrasenaAleatoria);
                }
                else
                {
                    MessageBox.Show(Mensaje);
                }
            }
            else // Edición de un usuario existente
            {
                bool resultado = new cn_usuario().Editar(objusuario, out Mensaje);

                if (resultado)
                {
                    DataGridViewRow row = dgdata.Rows[Convert.ToInt32(txtindice.Text)];
                    row.Cells["Id"].Value = txtid.Text;
                    row.Cells["Documento"].Value = nombreusuario.Text;
                    row.Cells["NombreCompleto"].Value = ncompleto.Text;
                    row.Cells["Correo"].Value = correo2.Text;
                    row.Cells["Clave"].Value = contrasenaAleatoria;
                    row.Cells["IdRol"].Value = ((opcionescombo)rol2.SelectedItem).valor.ToString();
                    row.Cells["Rol"].Value = ((opcionescombo)rol2.SelectedItem).texto.ToString();
                    row.Cells["EstadoValor"].Value = ((opcionescombo)estado2.SelectedItem).valor.ToString();
                    row.Cells["Estado"].Value = ((opcionescombo)estado2.SelectedItem).texto.ToString();
                    limpiar();
                }
                else
                {
                    MessageBox.Show(Mensaje);
                }
            }


        }

        private async Task EnviarCorreoBienvenida(string correoDestinatario, string nombreCompleto, string clave)
        {
            var apiKey = "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"; // Reemplaza con tu clave API real
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("colang153@gmail.com", "Angel");
            var to = new EmailAddress(correoDestinatario, nombreCompleto);
            var msg = new SendGridMessage()
            {
                From = from,
                TemplateId = "d-b7af825a855841e396c336a2cc429f33" // Reemplaza con el ID de tu plantilla
            };

            var templateData = new
            {
                NombreCompleto = nombreCompleto,
                clave = clave
            };

            msg.SetTemplateData(templateData);
            msg.AddTo(to);

            var response = await client.SendEmailAsync(msg);
            // Considera manejar la respuesta (por ejemplo, registrar en un log)
        }




        private void limpiar()
        {
            txtindice.Text = "-1";
            txtid.Text = "0";
            nombreusuario.Text = string.Empty;
            ncompleto.Text = string.Empty;
            correo2.Text = string.Empty;
            clave2.Text = string.Empty;
            confirmar.Text = string.Empty;
            rol2.SelectedIndex = 0;
            estado2.SelectedIndex = 0;
            nombreusuario.Select();

        }




        private void dgdata_CellPainting_1(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (e.ColumnIndex == 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                var w = Properties.Resources.comprobado.Width;
                var h = Properties.Resources.comprobado.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;
                e.Graphics.DrawImage(Properties.Resources.comprobado, new Rectangle(x, y, w, h));
                e.Handled = true;
            }
        }

        private void btneditar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void dgdata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgdata.Columns[e.ColumnIndex].Name == "btnseleccionar")
            {
                int indice = e.RowIndex;

                if (indice >= 0)
                {
                    txtindice.Text = indice.ToString();
                    txtid.Text = dgdata.Rows[indice].Cells["Id"].Value?.ToString();
                    nombreusuario.Text = dgdata.Rows[indice].Cells["Documento"].Value?.ToString();
                    ncompleto.Text = dgdata.Rows[indice].Cells["NombreCompleto"].Value?.ToString();
                    correo2.Text = dgdata.Rows[indice].Cells["Correo"].Value?.ToString();
                    clave2.Text = dgdata.Rows[indice].Cells["Clave"].Value?.ToString();
                    confirmar.Text = dgdata.Rows[indice].Cells["Clave"].Value?.ToString();

                    foreach (opcionescombo oc in rol2.Items)
                    {
                        if (Convert.ToInt32(oc.valor) == Convert.ToInt32(dgdata.Rows[indice].Cells["IdRol"].Value))
                        {
                            int indice_combo = rol2.Items.IndexOf(oc);
                            rol2.SelectedIndex = indice_combo;
                            break;
                        }
                    }

                    string estadoTexto = dgdata.Rows[indice].Cells["Estado"].Value?.ToString();

                    foreach (opcionescombo oc in estado2.Items)
                    {
                        if (oc.texto == estadoTexto)
                        {
                            int indice_combo = estado2.Items.IndexOf(oc);
                            estado2.SelectedIndex = indice_combo;
                            break;
                        }
                    }
                }
            }
        }

        private void busqueda_TextChanged(object sender, EventArgs e)
        {

        }

        private void nombreusuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtid.Text) != 0)
            {
                if (MessageBox.Show("Desea eliminar a este usuario?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string Mensaje = string.Empty;
                    usuario objusuario = new usuario()
                    {
                        IdUsuario = Convert.ToInt32(txtid.Text),
                    };
                    bool respuesta = new cn_usuario().Eliminar(objusuario, out Mensaje);
                    if (respuesta)
                    {
                        dgdata.Rows.RemoveAt(Convert.ToInt32(txtindice.Text));
                        limpiar();
                    }
                    else
                    {
                        MessageBox.Show(Mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        limpiar();
                    }
                }
            }
        }
        // Variable auxiliar para controlar el filtrado en tiempo real
        private bool filtrandoEnTiempoReal = false;
        private void btnbusqueda_Click(object sender, EventArgs e)
        {
            // Verificar si ya se está realizando un filtrado en tiempo real
            if (!filtrandoEnTiempoReal)
            {
                filtrandoEnTiempoReal = true;

                string ColumnaFiltro = ((opcionescombo)busquedacombo.SelectedItem).valor.ToString();
                string textoBusqueda = busqueda.Text.Trim().ToUpper();

                if (dgdata.Rows.Count > 0)
                {
                    foreach (DataGridViewRow row in dgdata.Rows)
                    {
                        string valorCelda = row.Cells[ColumnaFiltro].Value.ToString().Trim().ToUpper();

                        // Mostrar la fila si el valor de la celda contiene el texto de búsqueda
                        row.Visible = valorCelda.Contains(textoBusqueda);
                    }
                }

                filtrandoEnTiempoReal = false;
            }

        }

        private void btnlimpiarbuscador_Click(object sender, EventArgs e)
        {
            busqueda.Text = string.Empty;
            foreach (DataGridViewRow row in dgdata.Rows)
            {
                row.Visible = true;
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void iconPictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void dgdata_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verificar si el clic fue en el botón de selección
            if (dgdata.Columns[e.ColumnIndex].Name == "btnseleccionar")
            {
                int indice = e.RowIndex;

                if (indice >= 0)
                {
                    // Crear y asignar el usuario seleccionado
                    UsuarioSeleccionado = new usuario
                    {
                        IdUsuario = Convert.ToInt32(dgdata.Rows[indice].Cells["Id"].Value),
                        Documento = dgdata.Rows[indice].Cells["Documento"].Value?.ToString(),
                        NombreCompleto = dgdata.Rows[indice].Cells["NombreCompleto"].Value?.ToString(),
                        Correo = dgdata.Rows[indice].Cells["Correo"].Value?.ToString(),
                        // Agrega los demás campos si son necesarios
                    };

                    // Cerrar el formulario con DialogResult.OK
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        private string GenerarContrasenaAleatoria(int longitud)
        {
            const string caracteresValidos = "abcXYZ12390";
            StringBuilder contrasena = new StringBuilder();
            Random rnd = new Random();

            while (0 < longitud--)
            {
                contrasena.Append(caracteresValidos[rnd.Next(caracteresValidos.Length)]);
            }

            return contrasena.ToString();
        }

        private void nombreusuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite solo dígitos numéricos, control de teclas de retroceso, y (opcionalmente) punto decimal.
            if (!char.IsDigit(e.KeyChar) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != '.'))
            {
                e.Handled = true; // Bloquea el evento de cualquier cosa que no sea número o tecla de retroceso.
            }

            // Opcional: Si quieres permitir solo un punto decimal
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true; // Bloquea la entrada de un segundo punto decimal.
            }

            // Opcional: Para permitir teclas como Enter, etc., puedes agregar más condiciones aquí.
        }

        private void ncompleto_KeyPress(object sender, KeyPressEventArgs e)
        {
            

            // Verifica si el caracter es un número (dígito).
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ignora el evento.
            }
            // Opcional: Permite el control de teclas de retroceso y suprimir
            else if (e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Delete)
            {
                e.Handled = false; // Permite el evento.
            }

        }
    }

}
