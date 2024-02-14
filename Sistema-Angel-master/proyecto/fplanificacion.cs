using datos;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace proyecto
{
    public partial class fplanificacion : Form
    {
        private ListBox listBoxTareas;
        private ListBox listBoxProgreso;
        private ListBox listBoxCompletado;

        private Label labelTareas;
        private Label labelProgreso;
        private Label labelCompletado;


        private Button btnMostrarRecetas;
        private Panel panelRecetas;
        private ListBox listBoxRecetas;

        private Panel panelUsuarios;
        private ListBox listBoxUsuarios;
        public fplanificacion()
        {
            InitializeComponent();

            // Configuración del formulario
            this.Size = new Size(800, 600);

            // Crear y configurar listBoxTareas
            listBoxTareas = new ListBox();
            listBoxTareas.Location = new Point(10, 40);
            listBoxTareas.Size = new Size(250, 500);

            // Crear y configurar listBoxProgreso
            listBoxProgreso = new ListBox();
            listBoxProgreso.Location = new Point(270, 40);
            listBoxProgreso.Size = new Size(250, 500);

            // Crear y configurar listBoxCompletado
            listBoxCompletado = new ListBox();
            listBoxCompletado.Location = new Point(530, 40);
            listBoxCompletado.Size = new Size(250, 500);

            // Crear y configurar labelTareas
            labelTareas = new Label();
            labelTareas.Location = new Point(10, 10);
            labelTareas.Size = new Size(100, 30);
            labelTareas.Text = "";

            // Crear y configurar labelProgreso
            labelProgreso = new Label();
            labelProgreso.Location = new Point(270, 10);
            labelProgreso.Size = new Size(100, 30);
            labelProgreso.Text = "Progreso";

            // Crear y configurar labelCompletado
            labelCompletado = new Label();
            labelCompletado.Location = new Point(530, 10);
            labelCompletado.Size = new Size(100, 30);
            labelCompletado.Text = "Completado";

            // Agregar controles al formulario
            this.Controls.Add(listBoxTareas);
            this.Controls.Add(listBoxProgreso);
            this.Controls.Add(listBoxCompletado);
            this.Controls.Add(labelTareas);
            this.Controls.Add(labelProgreso);
            this.Controls.Add(labelCompletado);


            // Configuración del panel de recetas como un panel normal
            panelRecetas = new Panel();
            panelRecetas.Size = new Size(200, 300); // Ajusta el tamaño según sea necesario
            panelRecetas.Location = new Point(10, 550); // Ajusta la posición para integrarlo en el diseño
            panelRecetas.Visible = true; // Hacerlo visible desde el inicio o controlar su visibilidad con el botón

            // Crear y configurar la lista de recetas dentro del panel
            listBoxRecetas = new ListBox();
            listBoxRecetas.Dock = DockStyle.Fill;
            listBoxRecetas.DoubleClick += new EventHandler(this.listBoxRecetas_DoubleClick);

            // Agregar la lista al panel y el panel al formulario
            panelRecetas.Controls.Add(listBoxRecetas);
            this.Controls.Add(panelRecetas);

            // Agregar el botón al formulario
            this.Controls.Add(btnMostrarRecetas);


            // Configurar eventos de arrastre para cada ListBox
            ConfigureDragAndDrop(listBoxTareas);
            ConfigureDragAndDrop(listBoxProgreso);
            ConfigureDragAndDrop(listBoxCompletado);


            listBoxTareas.AllowDrop = true;
            listBoxProgreso.AllowDrop = true;
            listBoxCompletado.AllowDrop = true;

            // Configuración del panel de usuarios
            panelUsuarios = new Panel();
            panelUsuarios.Size = new Size(200, 300); // Ajusta el tamaño según sea necesario
            panelUsuarios.Location = new Point(220, 550); // Ajusta la posición para integrarlo en el diseño
            panelUsuarios.Visible = false; // Inicialmente no visible

            // Crear y configurar la lista de usuarios dentro del panel
            listBoxUsuarios = new ListBox();
            listBoxUsuarios.Dock = DockStyle.Fill;

            // Agregar la lista al panel y el panel al formulario
            panelUsuarios.Controls.Add(listBoxUsuarios);
            this.Controls.Add(panelUsuarios);

            // Configurar la visibilidad inicial de los paneles
            panelRecetas.Visible = true; // Hacer visible desde el inicio
            panelUsuarios.Visible = true; // Hacer visible desde el inicio

            this.Size = new Size(1000, 700);
            this.BackColor = Color.LightGray; // Fondo del formulario

            // Configurar la fuente y el color de los labels
            Font labelFont = new Font("Arial", 10, FontStyle.Bold);
            Color labelColor = Color.DarkBlue;

            labelTareas = new Label();
            labelTareas.Font = labelFont;
            labelTareas.ForeColor = labelColor;
            // ... (configuraciones similares para otros labels)

            // Configurar ListBox
            listBoxTareas.BorderStyle = BorderStyle.FixedSingle;
            listBoxTareas.BackColor = Color.WhiteSmoke;
            // ... (configuraciones similares para otros listboxes)

            // Configurar botones
            btnMostrarRecetas = new Button();
            btnMostrarRecetas.BackColor = Color.LightBlue;
            btnMostrarRecetas.Font = new Font("Arial", 9);
            // ... (configuraciones similares para otros botones)

            // Configurar paneles
            panelRecetas.BackColor = Color.White;
            panelUsuarios.BackColor = Color.White;

            this.Size = new Size(1200, 800);
            this.BackColor = Color.LightGray; // Fondo del formulario

            // Ajustar tamaño y posición de los ListBox
            ConfigureListBox(listBoxTareas, labelTareas, "Lista de Tareas", 10, 10, Color.LightCoral, labelFont, 450, 300);
            ConfigureListBox(listBoxProgreso, labelProgreso, "Progreso", 470, 10, Color.LightGreen, labelFont, 450, 300);
            ConfigureListBox(listBoxCompletado, labelCompletado, "Completado", 930, 10, Color.LightSkyBlue, labelFont, 450, 300);

            // Configuración y estilización de los Paneles con Labels
            ConfigurePanelWithLabel(panelRecetas, "Recetas", 10, 320, Color.White, 580, 300);
            ConfigurePanelWithLabel(panelUsuarios, "Usuarios", 610, 320, Color.White, 580, 300);





            // Configuración de los ListBox y Labels
            ConfigureListBox(listBoxTareas, labelTareas, "Lista de Tareas", 10, 10, Color.LightCoral, labelFont);
            ConfigureListBox(listBoxProgreso, labelProgreso, "Progreso", 10, 310, Color.LightGreen, labelFont);
            ConfigureListBox(listBoxCompletado, labelCompletado, "Completado", 10, 610, Color.LightSkyBlue, labelFont);



            this.Size = new Size(1200, 900); // Tamaño del formulario aumentado
            this.BackColor = Color.LightGray;


            // Configuración y estilización de los ListBox y Labels
            ConfigureListBox(listBoxTareas, labelTareas, "Lista de Tareas", 10, 10, Color.LightCoral, labelFont, 400, 300);
            ConfigureListBox(listBoxProgreso, labelProgreso, "Progreso", 420, 10, Color.LightGreen, labelFont, 400, 300);
            ConfigureListBox(listBoxCompletado, labelCompletado, "Completado", 830, 10, Color.LightSkyBlue, labelFont, 400, 300);


            this.Size = new Size(1200, 900); // Tamaño del formulario aumentado
            this.BackColor = Color.LightGray;



            // Configuración de los ListBox y Labels
            ConfigureListBox(listBoxTareas, labelTareas, "Lista de Tareas", 10, 10, Color.LightCoral, labelFont, 400, 300);
            ConfigureListBox(listBoxProgreso, labelProgreso, "Progreso", 420, 10, Color.LightGreen, labelFont, 400, 300);
            ConfigureListBox(listBoxCompletado, labelCompletado, "Completado", 830, 10, Color.LightSkyBlue, labelFont, 400, 300);

            // Configuración y estilización de los Paneles
            ConfigurePanel(panelRecetas, 10, 620, Color.White, 580, 250);
            ConfigurePanel(panelUsuarios, 610, 620, Color.White, 580, 250);



        }


        private void StyledPanel_Paint(object sender, PaintEventArgs e)
        {
            Panel pnl = sender as Panel;
            GraphicsPath path = new GraphicsPath();
            int radius = 20;
            path.AddArc(pnl.Width - radius, pnl.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, pnl.Height - radius, radius, radius, 90, 90);
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(pnl.Width - radius, 0, radius, radius, 270, 90);
            path.CloseAllFigures();
            pnl.Region = new Region(path);

            // Agregar sombra al panel
            AddShadowToPanel(pnl, e.Graphics);
        }

        private void AddShadowToPanel(Panel pnl, Graphics g)
        {
            Rectangle rect = new Rectangle(pnl.ClientRectangle.X, pnl.ClientRectangle.Y, pnl.ClientRectangle.Width - 1, pnl.ClientRectangle.Height - 1);
            Pen pen = new Pen(Color.Gray, 2);
            g.DrawRectangle(pen, rect);
            pen.Dispose();
        }

        private void ConfigurePanelWithLabel(Panel panel, string labelTitle, int x, int y, Color bgColor, int width, int height)
        {
            // Configurar Panel
            panel.Location = new Point(x, y);
            panel.Size = new Size(width, height);
            panel.BackColor = bgColor;
            panel.Paint += new PaintEventHandler(StyledPanel_Paint);

            // Crear y configurar Label
            Label panelLabel = new Label();
            panelLabel.Text = labelTitle;
            panelLabel.Font = new Font("Arial", 12, FontStyle.Bold);
            panelLabel.Size = new Size(width, 30);
            panelLabel.TextAlign = ContentAlignment.MiddleCenter;
            panelLabel.BackColor = Color.LightGray;

            // Agregar Label al Panel
            panel.Controls.Add(panelLabel);

            // Agregar Panel al Formulario
            this.Controls.Add(panel);
        }



        private void ConfigureListBox(ListBox listBox, Label label, string labelText, int x, int y, Color bgColor, Font font, int width, int height)
        {
            listBox.Location = new Point(x, y + 50);
            listBox.Size = new Size(width, height);
            listBox.BackColor = bgColor;

            label.Location = new Point(x, y);
            label.Size = new Size(width, 50);
            label.Text = labelText;
            label.Font = font;
            label.BackColor = bgColor;
            label.TextAlign = ContentAlignment.MiddleCenter;
            label.BorderStyle = BorderStyle.FixedSingle;

            label.Paint += new PaintEventHandler(RoundBorderLabel_Paint);

            this.Controls.Add(listBox);
            this.Controls.Add(label);
        }



        private void ConfigureListBox(ListBox listBox, Label label, string labelText, int x, int y, Color bgColor, Font font)
        {
            // Configurar ListBox
            listBox.Location = new Point(x, y + 40);
            listBox.Size = new Size(350, 250);
            listBox.BackColor = bgColor;

            // Configurar Label
            label.Location = new Point(x, y);
            label.Size = new Size(350, 40);
            label.Text = labelText;
            label.Font = font;
            label.BackColor = bgColor;
            label.TextAlign = ContentAlignment.MiddleCenter;
            label.BorderStyle = BorderStyle.FixedSingle;

            // Redondear bordes del Label
            label.Paint += new PaintEventHandler(RoundBorderLabel_Paint);

            // Agregar al formulario
            this.Controls.Add(listBox);
            this.Controls.Add(label);
        }

        private void ConfigurePanel(Panel panel, int x, int y, Color bgColor, int width, int height)
        {
            panel.Location = new Point(x, y);
            panel.Size = new Size(width, height); // Usa los parámetros width y height
            panel.BackColor = bgColor;

            // Aplicar estilo con bordes redondeados
            panel.Paint += new PaintEventHandler(RoundBorderPanel_Paint);

            this.Controls.Add(panel);
        }

        private void RoundBorderLabel_Paint(object sender, PaintEventArgs e)
        {
            Label lbl = sender as Label;
            GraphicsPath path = new GraphicsPath();
            int radius = 10;
            path.AddArc(lbl.Width - radius, lbl.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, lbl.Height - radius, radius, radius, 90, 90);
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(lbl.Width - radius, 0, radius, radius, 270, 90);
            path.CloseAllFigures();
            lbl.Region = new Region(path);
        }

        private void RoundBorderPanel_Paint(object sender, PaintEventArgs e)
        {
            Panel pnl = sender as Panel;
            GraphicsPath path = new GraphicsPath();
            int radius = 20;
            path.AddArc(pnl.Width - radius, pnl.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, pnl.Height - radius, radius, radius, 90, 90);
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(pnl.Width - radius, 0, radius, radius, 270, 90);
            path.CloseAllFigures();
            pnl.Region = new Region(path);
        }

        private void ConfigureDragAndDrop(ListBox listBox)
        {
            listBox.MouseDown += new MouseEventHandler(ListBox_MouseDown);
            listBox.DragEnter += new DragEventHandler(ListBox_DragEnter);
            listBox.DragDrop += new DragEventHandler(ListBox_DragDrop);
        }

        private void ListBox_MouseDown(object sender, MouseEventArgs e)
        {
            ListBox listBox = sender as ListBox;
            if (listBox.SelectedItem == null) return;
            listBox.DoDragDrop(listBox.SelectedItem, DragDropEffects.Move);
        }

        private void ListBox_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.StringFormat))
            {
                e.Effect = DragDropEffects.Move;
            }
        }

        private void ListBox_DragDrop(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(DataFormats.StringFormat)) return;

            ListBox targetListBox = sender as ListBox;
            string item = (string)e.Data.GetData(DataFormats.StringFormat);

            targetListBox.Items.Add(item);

            // Eliminar el ítem del ListBox de origen
            foreach (var listBox in new[] { listBoxTareas, listBoxProgreso, listBoxCompletado })
            {
                if (listBox.Items.Contains(item))
                {
                    listBox.Items.Remove(item);
                    break;
                }
            }
        }



        private void BtnMostrarRecetas_Click_Click(object sender, EventArgs e)
        {
            // Cargar recetas y usuarios, mostrar los paneles
            CargarRecetas();
            CargarUsuarios();

        }

        private void listBoxRecetas_DoubleClick(object sender, EventArgs e)
        {
            if (listBoxRecetas.SelectedItem != null && listBoxUsuarios.SelectedItem != null)
            {
                string recetaSeleccionada = listBoxRecetas.SelectedItem.ToString();
                string usuarioSeleccionado = listBoxUsuarios.SelectedItem.ToString();
                string fechaActual = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"); // Formato de fecha y hora

                string tareaConFecha = $"{usuarioSeleccionado} - {recetaSeleccionada} - {fechaActual}";
                listBoxTareas.Items.Add(tareaConFecha);
            }
        }

        // Método para cargar las recetas desde la base de datos
        private void CargarRecetas()
        {
            listBoxRecetas.Items.Clear();

            // Crear una instancia de la clase que maneja las operaciones con recetas
            cd_receta manejadorRecetas = new cd_receta();

            // Obtener la lista de recetas
            List<receta> listaRecetas = manejadorRecetas.Listar();

            // Añadir los nombres de las recetas a la ListBox
            foreach (var receta in listaRecetas)
            {
                listBoxRecetas.Items.Add(receta.NombreReceta);
            }


        }

        // Método para cargar los usuarios desde la base de datos
        private void CargarUsuarios()
        {
            listBoxUsuarios.Items.Clear();

            // Crear una instancia de la clase que maneja las operaciones con usuarios
            cd_usuario manejadorUsuarios = new cd_usuario();

            // Obtener la lista de usuarios de tipo 'entidad.usuario'
            List<entidad.usuario> listaUsuariosEntidad = manejadorUsuarios.listar();

            // Convertir a tipo 'proyecto.fplanificacion.usuario'
            List<proyecto.fplanificacion.usuario> listaUsuariosForm = listaUsuariosEntidad
                .Select(u => new proyecto.fplanificacion.usuario { NombreUsuario = u.NombreCompleto })
                .ToList();

            // Añadir los nombres de los usuarios a la ListBox
            foreach (var usuario in listaUsuariosForm)
            {
                listBoxUsuarios.Items.Add(usuario.NombreUsuario);
            }
        }
        public class usuario
        {
            public string NombreUsuario { get; set; }
            // ... (otros atributos)
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            // Eliminar tarea seleccionada de listBoxTareas
            if (listBoxTareas.SelectedItem != null)
            {
                listBoxTareas.Items.Remove(listBoxTareas.SelectedItem);
            }
            // Eliminar tarea seleccionada de listBoxProgreso
            else if (listBoxProgreso.SelectedItem != null)
            {
                listBoxProgreso.Items.Remove(listBoxProgreso.SelectedItem);
            }
            // Puedes agregar un mensaje o una acción si no hay ninguna tarea seleccionada
            else
            {
                MessageBox.Show("No hay tarea seleccionada para eliminar.");
            }
        }
    }



}




