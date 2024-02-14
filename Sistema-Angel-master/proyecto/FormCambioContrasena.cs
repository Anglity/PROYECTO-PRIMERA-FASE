using datos;
using entidad;
using System;
using System.Windows.Forms;

namespace proyecto
{
    public partial class FormCambioContrasena : Form
    {
        private usuario Usuario;

        public Form ReferencedUserForm { get; set; }

        public delegate void PasswordChangedHandler(string nuevaClave);
        public event PasswordChangedHandler OnPasswordChanged;

        public FormCambioContrasena(usuario ousuario)
        {
            InitializeComponent();
            Usuario = ousuario;
        }
        private void iconButton1_Click(object sender, EventArgs e)
        {
            // Verifica que los campos de contraseña no estén vacíos
            if (string.IsNullOrWhiteSpace(txtNuevaContrasena.Text) || string.IsNullOrWhiteSpace(txtConfirmarContrasena.Text))
            {
                MessageBox.Show("Por favor, ingresa y confirma la nueva contraseña.");
                return;
            }

            if (txtNuevaContrasena.Text != txtConfirmarContrasena.Text)
            {
                MessageBox.Show("Las contraseñas no coinciden.");
                return;
            }

            // Actualiza el campo ClaveCambiada con la nueva contraseña
            cd_usuario datosUsuario = new cd_usuario();
            string mensaje;
            bool resultado = datosUsuario.ActualizarClaveCambiada(Usuario.IdUsuario, txtNuevaContrasena.Text, out mensaje);

            if (resultado)
            {
                MessageBox.Show("Contraseña actualizada con éxito.");

                // Notifica al formulario User sobre el cambio de contraseña
                OnPasswordChanged?.Invoke(txtNuevaContrasena.Text);

                // Oculta el formulario User si está presente
                ReferencedUserForm?.Hide();

                // Cierra este formulario (FormCambioContrasena)
                this.Close();

                // Abre el formulario inicio3
                inicio3 formInicio3 = new inicio3(Usuario);
                formInicio3.Show();

                // Asegúrate de que el formulario User se muestre nuevamente y se limpien sus campos cuando inicio3 se cierre
                formInicio3.FormClosed += (s, args) =>
                {
                    if (ReferencedUserForm is User userForm)
                    {
                        userForm.ClearFields();
                        userForm.Show();
                    }
                };
            }
            else
            {
                MessageBox.Show(mensaje);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void FormCambioContrasena_Load(object sender, EventArgs e)
        {

        }
    }


}
