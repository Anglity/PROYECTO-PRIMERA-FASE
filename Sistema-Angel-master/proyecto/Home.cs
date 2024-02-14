using FontAwesome.Sharp;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace proyecto
{
    public partial class Home : Form
    {
        private readonly int[] ventas = { 150, 250, 200, 180, 300 };
        private readonly string[] productos = { "Producto A", "Producto B", "Producto C", "Producto D", "Producto E" };

        public Home()
        {
            InitializeComponent();
            RedondearBotón(iconButton1, 30);
            RedondearPanel(panel2, 60);
            RedondearPanel(panel3, 60);
            panel4.Paint += panel4_Paint;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private Color GetRandomColor()
        {
            Random random = new Random();
            return Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));
        }

        private void RedondearPanel(Panel panel, int radio)
        {
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddArc(0, 0, radio, radio, 180, 90);
            path.AddArc(panel.Width - radio, 0, radio, radio, 270, 90);
            path.AddArc(panel.Width - radio, panel.Height - radio, radio, radio, 0, 90);
            path.AddArc(0, panel.Height - radio, radio, radio, 90, 90);
            panel.Region = new System.Drawing.Region(path);
        }
        private void RedondearBotón(IconButton IconButton, int radio)
        {
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddArc(0, 0, radio, radio, 180, 90);
            path.AddArc(IconButton.Width - radio, 0, radio, radio, 270, 90);
            path.AddArc(IconButton.Width - radio, IconButton.Height - radio, radio, radio, 0, 90);
            path.AddArc(0, IconButton.Height - radio, radio, radio, 90, 90);
            IconButton.Region = new System.Drawing.Region(path);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            RedondearPanel(panel2, 60);
            RedondearPanel(panel3, 60);

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {


        }

        private void Home_Load(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            int totalVentas = 0;
            foreach (int venta in ventas)
            {
                totalVentas += venta;
            }

            int startAngle = 0;
            for (int i = 0; i < ventas.Length; i++)
            {
                int sweepAngle = (int)(((double)ventas[i] / totalVentas) * 360);
                Color color = GetRandomColor();

                using (Brush brush = new SolidBrush(color))
                {
                    g.FillPie(brush, 100, 100, 200, 200, startAngle, sweepAngle);
                }

                startAngle += sweepAngle;
            }

            // Dibujar leyenda
            int x = 350;
            int y = 100;
            int legendWidth = 20;
            int legendHeight = 20;

            for (int i = 0; i < ventas.Length; i++)
            {
                Color color = GetRandomColor();
                using (Brush brush = new SolidBrush(color))
                {
                    g.FillRectangle(brush, x, y, legendWidth, legendHeight);
                }

                string label = $"{productos[i]}: {ventas[i]}";
                g.DrawString(label, Font, Brushes.Black, x + legendWidth + 5, y);

                y += legendHeight + 5;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
