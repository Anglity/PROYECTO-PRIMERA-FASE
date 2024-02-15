using datos;
using FontAwesome.Sharp;
using LiveCharts.Wpf;
using LiveCharts;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using System.Linq;

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
            CargarMesesEnComboBox();

            CargarAniosEnComboBox();

            // Configurar gráfico de líneas primero
            ConfigurarGraficoDeLineas();
        }

        private void CargarAniosEnComboBox()
        {
            // Suponiendo que quieres cargar años basados en datos existentes en la base de datos
            HashSet<int> anios = new HashSet<int>();

            try
            {
                using (SqlConnection oconexion = new SqlConnection(conexion.cadena))
                {
                    string query = "SELECT DISTINCT YEAR(FechaRegistro) AS Anio FROM DETALLE_VENTA ORDER BY Anio";

                    SqlCommand command = new SqlCommand(query, oconexion);
                    oconexion.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            anios.Add(reader.GetInt32(0));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar la excepción como consideres necesario
                MessageBox.Show($"Error al cargar años: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            comboBoxAnio.Items.Clear();
            foreach (var anio in anios)
            {
                comboBoxAnio.Items.Add(anio);
            }

            // Opcional: Selecciona el año actual si está disponible
            int anioActual = DateTime.Now.Year;
            if (comboBoxAnio.Items.Contains(anioActual))
            {
                comboBoxAnio.SelectedItem = anioActual;
            }
        }


        public class ProductoData
        {
            public string Nombre { get; set; }
            public double CantidadVendida { get; set; }
        }


        private void ConfigurarGraficoDeLineas()
        {

            if (comboBoxAnio.SelectedItem == null)
            {
                MessageBox.Show("Por favor, seleccione un año.");
                return;
            }

            if (!int.TryParse(comboBoxAnio.SelectedItem.ToString(), out int anioSeleccionado))
            {
                MessageBox.Show("Selección de año inválida.");
                return;
            }

            var datosVentas = ObtenerDatosVentasPorAnio(anioSeleccionado);
            var seriesCollection = new SeriesCollection();

            var coloresMeses = new List<System.Windows.Media.Color>
    {
        System.Windows.Media.Colors.Red,
        System.Windows.Media.Colors.Orange,
        System.Windows.Media.Colors.Yellow,
        System.Windows.Media.Colors.Green,
        System.Windows.Media.Colors.Blue,
        System.Windows.Media.Colors.Indigo,
        System.Windows.Media.Colors.Violet,
        System.Windows.Media.Colors.Gold,
        System.Windows.Media.Colors.Silver,
        System.Windows.Media.Colors.RosyBrown,
        System.Windows.Media.Colors.LightSkyBlue,
        System.Windows.Media.Colors.LightGreen
    };

            for (int i = 0; i < datosVentas.Count; i++)
            {
                var ventaMes = datosVentas[i];
                seriesCollection.Add(new ColumnSeries
                {
                    Title = $"{GetMonthName(ventaMes.Mes)}",
                    Values = new ChartValues<decimal> { ventaMes.TotalVentas },
                    Fill = new System.Windows.Media.SolidColorBrush(coloresMeses[i % coloresMeses.Count]),
                    DataLabels = true,
                    LabelPoint = point => $"${point.Y:N0}"
                });
            }

            // Ajustes adicionales del gráfico aquí
            var cartesianChart = new CartesianChart
            {
                Series = seriesCollection,
                AxisX = new AxesCollection
        {
            new Axis
            {
                Title = "Meses",
                Labels = new[] { "Ene", "Feb", "Mar", "Abr", "May", "Jun", "Jul", "Ago", "Sep", "Oct", "Nov", "Dic" },
                LabelsRotation = 45 // Rota las etiquetas para mejor lectura
            }
        },
                AxisY = new AxesCollection
        {
            new Axis
            {
                Title = "Ventas",
                LabelFormatter = value => value.ToString("C"),
                MinValue = 0 // Asegura que la escala inicie en 0
            }
        },
                LegendLocation = LegendLocation.Right,
                Hoverable = true, // Permite interacción al pasar el mouse
                TooltipTimeout = TimeSpan.FromSeconds(1) // Ajusta el tiempo de aparición de tooltips
            };

            lineChart.Child = cartesianChart;
        }

        private void Chart_OnDataClick(object sender, ChartPoint chartPoint)
        {
            MessageBox.Show($"Mes: {chartPoint.X}, Ventas: ${chartPoint.Y:N0}");
        }

        private string GetMonthName(int month)
        {
            // Retorna el nombre del mes basado en el número de mes
            return new DateTime(1, month, 1).ToString("MMM", CultureInfo.InvariantCulture);
        }

        private decimal ObtenerVentaMesAnterior(int anio, int mes)
        {
            // Ajusta esta consulta SQL a tu esquema de base de datos y necesidades
            var query = @"
        SELECT SUM(TotalVentas) AS VentaMesAnterior
        FROM DETALLE_VENTA
        WHERE YEAR(FechaRegistro) = @Anio AND MONTH(FechaRegistro) = @Mes - 1";

            using (var connection = new SqlConnection(conexion.cadena))
            {
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Anio", anio);
                command.Parameters.AddWithValue("@Mes", mes);

                connection.Open();
                var resultado = command.ExecuteScalar();

                return resultado != DBNull.Value ? Convert.ToDecimal(resultado) : 0m;
            }
        }


        public class Venta
        {
            public int Anio { get; set; }
            public int Mes { get; set; }
            public decimal TotalVentas { get; set; }
        }

        private List<Venta> ObtenerDatosVentasPorAnio(int anio)
        {
            List<Venta> ventasDelAnio = new List<Venta>();

            try
            {
                using (SqlConnection oconexion = new SqlConnection(conexion.cadena))
                {
                    // Asegúrate de ajustar la consulta según el esquema de tu base de datos
                    string query = @"
            SELECT 
                MONTH(FechaRegistro) AS Mes, 
                SUM(Valortotal) AS TotalVentas
            FROM DETALLE_VENTA
            WHERE YEAR(FechaRegistro) = @Anio
            GROUP BY MONTH(FechaRegistro)
            ORDER BY Mes";

                    SqlCommand command = new SqlCommand(query, oconexion);
                    command.Parameters.AddWithValue("@Anio", anio);

                    oconexion.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ventasDelAnio.Add(new Venta
                            {
                                Anio = anio, // Ya conocemos el año porque es un parámetro de entrada
                                Mes = Convert.ToInt32(reader["Mes"]),
                                TotalVentas = Convert.ToDecimal(reader["TotalVentas"])
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar la excepción como consideres necesario
                Console.WriteLine(ex.Message);
            }

            return ventasDelAnio;
        }





        public class DatosVenta
        {
            public int Anio { get; set; }
            public int Mes { get; set; }
            public decimal TotalVentas { get; set; }
        }

        public List<DatosVenta> ObtenerDatosVentas()
        {
            List<DatosVenta> listaDatosVentas = new List<DatosVenta>();

            try
            {
                using (SqlConnection oconexion = new SqlConnection(conexion.cadena))
                {
                    oconexion.Open();

                    string query = @"
                SELECT 
                    YEAR(FechaRegistro) AS Anio, 
                    MONTH(FechaRegistro) AS Mes, 
                    SUM(Valortotal) AS TotalVentas
                FROM DETALLE_VENTA
                GROUP BY YEAR(FechaRegistro), MONTH(FechaRegistro)
                ORDER BY Anio, Mes";

                    SqlCommand command = new SqlCommand(query, oconexion);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listaDatosVentas.Add(new DatosVenta
                            {
                                Anio = Convert.ToInt32(reader["Anio"]),
                                Mes = Convert.ToInt32(reader["Mes"]),
                                TotalVentas = Convert.ToDecimal(reader["TotalVentas"])
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar la excepción como consideres necesario
                Console.WriteLine(ex.Message);
            }

            return listaDatosVentas;
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

        private void CargarMesesEnComboBox()
        {
            comboBoxMeses.Items.Clear(); // Limpiar los ítems existentes

            var cultura = new System.Globalization.CultureInfo("es-ES");
            for (int mes = 1; mes <= 12; mes++)
            {
                string nombreMes = cultura.DateTimeFormat.GetMonthName(mes);
                comboBoxMeses.Items.Add(nombreMes);
            }

            // Opcional: Seleccionar el mes actual
            int mesActual = DateTime.Now.Month;
            comboBoxMeses.SelectedIndex = mesActual - 1;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
