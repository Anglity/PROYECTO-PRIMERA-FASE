using System;
using System.Windows.Forms;

namespace proyecto
{
    public partial class fConfigurarFechaHora : Form
    {
        public DateTime FechaHoraSeleccionada { get; private set; }
        public fConfigurarFechaHora()
        {
            InitializeComponent();
            dateTimePicker.Format = DateTimePickerFormat.Custom;
            dateTimePicker.CustomFormat = "MM/dd/yyyy HH:mm"; // Formato día, mes, año, hora y minutos
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            FechaHoraSeleccionada = dateTimePicker.Value;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {

        }

        private void fConfigurarFechaHora_Load(object sender, EventArgs e)
        {

        }
    }
}
