using entidad;
using negocio;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;


namespace proyecto
{
    public partial class User : Form
    {

        // Propiedad para almacenar la nueva clave cambiada
        public string NuevaClaveCambiada { get; set; }


        public User()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            usuario ousuario;

            if (esPrimerInicio(txtuser.Text))
            {
                // Autenticación con la clave original
                ousuario = new cn_usuario().listar()
                               .Where(u => u.Documento == txtuser.Text && u.Clave == txtclave.Text)
                               .FirstOrDefault();
            }
            else
            {
                // Autenticación con la clave cambiada
                ousuario = new cn_usuario().listar()
                               .Where(u => u.Documento == txtuser.Text && u.ClaveCambiada == NuevaClaveCambiada)
                               .FirstOrDefault();
            }

            if (ousuario != null)
            {
                if (!ousuario.Estado)
                {
                    MessageBox.Show("Este usuario está inactivo y no puede iniciar sesión.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (ousuario.PrimerInicioSesion)
                {
                    MostrarPanelCambioContrasena(ousuario);
                }
                else
                {
                    inicio3 form = new inicio3(ousuario);
                    form.Show();
                    this.Hide();
                    form.FormClosing += frm_closing;
                }
            }
            else
            {
                MessageBox.Show("No se encontró el usuario", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public void ClearFields()
        {
            txtuser.Text = string.Empty;
            txtclave.Text = string.Empty;
            // Limpia otros campos si es necesario
        }

        private bool esPrimerInicio(string documento)
        {
            // Aquí se supone que tienes una forma de obtener el usuario de la base de datos
            // basado en su documento. Podría ser una consulta a tu base de datos.
            // Utilizo 'new cn_usuario().listar()' como ejemplo basado en tu código existente.

            var usuario = new cn_usuario().listar()
                                          .FirstOrDefault(u => u.Documento == documento);

            // Verifica si el usuario existe y si está en su primer inicio de sesión
            return usuario != null && usuario.PrimerInicioSesion;
        }



        private void MostrarPanelCambioContrasena(usuario ousuario)
        {
            FormCambioContrasena formCambioContrasena = new FormCambioContrasena(ousuario);
            formCambioContrasena.ReferencedUserForm = this;
            formCambioContrasena.ShowDialog();
        }

        private void FormCambioContrasena_OnPasswordChanged(string nuevaClave)
        {
            // Guarda la nueva clave para usarla más tarde
            // Puedes guardarla como una propiedad en el formulario User
            this.NuevaClaveCambiada = nuevaClave;
        }

        private void frm_closing(object sender, FormClosingEventArgs e)
        {
            txtuser.Text = string.Empty;
            txtclave.Text = string.Empty;
            this.Show();
        }

        private void User_Load(object sender, EventArgs e)
        {


            if (!string.IsNullOrEmpty(Properties.Settings.Default.UserName))
            {

                txtuser.Text = Properties.Settings.Default.UserName;
                checkBox1.Checked = true;
            }
        }

        private void txtuser_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {

                Properties.Settings.Default.UserName = txtuser.Text;
                Properties.Settings.Default.Save();
            }
            else
            {

                Properties.Settings.Default.UserName = string.Empty;
                Properties.Settings.Default.Save();
            }
        }
        private void InitializeTimer()
        {
            Timer timer = new Timer();
            timer.Interval = 600000; // 600000 milisegundos = 10 minutos
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Lógica para eliminar la información del usuario
            Properties.Settings.Default.UserName = string.Empty;
            Properties.Settings.Default.Save();
        }
    }
}
