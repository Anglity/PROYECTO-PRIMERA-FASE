using entidad;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyecto
{
    
    public partial class cambio_contraseña : Form
    {
        private usuario UsuarioParaCambiarContraseña;
        public cambio_contraseña(usuario usuario)
        {
            InitializeComponent();
            UsuarioParaCambiarContraseña = usuario;
        }

        private void cambio_contraseña_Load(object sender, EventArgs e)
        {

        }
    }
}
