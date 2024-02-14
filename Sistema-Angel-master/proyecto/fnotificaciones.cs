using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace proyecto
{


    public partial class fnotificaciones : Form
    {


        public fnotificaciones()
        {
            InitializeComponent();
            ConfigurarListView();
        }

        public void CargarNotificaciones(List<string> notificaciones)
        {
            listBoxNotificaciones.Items.Clear();
            foreach (var notificacion in notificaciones)
            {
                ListViewItem item = new ListViewItem(notificacion);
                listBoxNotificaciones.Items.Add(item);
            }

            // Ajustar el tamaño de la columna al contenido
            listBoxNotificaciones.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }

        private void ConfigurarListView()
        {
            // Configuración de dimensiones y vista
            listBoxNotificaciones.Bounds = new Rectangle(new Point(10, 10), new Size(500, 300));
            listBoxNotificaciones.View = View.Details;
            listBoxNotificaciones.FullRowSelect = true;
            listBoxNotificaciones.GridLines = true;

            // Configuración de estilo
            listBoxNotificaciones.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            listBoxNotificaciones.BackColor = Color.LightBlue;
            listBoxNotificaciones.ForeColor = Color.DarkBlue;


            listBoxNotificaciones.Columns.Add("Notificación", 300, HorizontalAlignment.Left);


        }




    }
}
