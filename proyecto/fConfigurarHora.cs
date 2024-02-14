using System;
using System.Windows.Forms;

namespace proyecto
{
    public partial class fConfigurarHora : Form
    {
        private string _nombreReceta;
        private int _cantidad;
        private fpedido _formPedido;
        public DateTime FechaHoraSeleccionada { get; private set; }
        // Propiedad pública para acceder a la fecha seleccionada
        public DateTime NuevaFecha { get; private set; }



        public fConfigurarHora(string nombreReceta, int cantidad, fpedido formPedido)
        {

            InitializeComponent();
            _nombreReceta = nombreReceta;
            _cantidad = cantidad;
            _formPedido = formPedido;
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "MM/dd/yyyy HH:mm"; // Formato día, mes, año, hora y minutos
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            DateTime horaSeleccionada = dateTimePicker1.Value;
            _formPedido.AgregarProduccionAplazada(_nombreReceta, _cantidad, horaSeleccionada);
            this.Close();

        }

        public DateTime FechaMinima
        {
            set { dateTimePicker1.MinDate = value; }
        }

        private void fConfigurarHora_Load(object sender, EventArgs e)
        {

        }
    }
}
