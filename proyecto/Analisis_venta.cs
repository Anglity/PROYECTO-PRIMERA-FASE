using entidad;
using datos;
using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using System.Globalization;




namespace proyecto
{
    public partial class Analisis_venta : Form
    {
        private usuario _usuario;
        public Analisis_venta(usuario oUsuario = null)
        {
            _usuario = oUsuario;
            InitializeComponent();
            comboBoxAnio.SelectedIndexChanged += new EventHandler(anioSeleccionado_SelectedIndexChanged);
            CargarAniosEnComboBox(); // Asegúrate de que esto se llame aquí para llenar el comboBox.


        }

        public Analisis_venta()
        {
            InitializeComponent();
        }

        private void CargarDatosEnChart()
        {


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


        private void Analisis_venta_Load(object sender, EventArgs e)

        {
            comboBoxAnio.SelectedIndexChanged += anioSeleccionado_SelectedIndexChanged;

            CargarMesesEnComboBox();

            CargarAniosEnComboBox();

            // Configurar gráfico de líneas primero
            ConfigurarGraficoDeLineas();

            // Configuración y carga de datos para el gráfico circular
            Func<ChartPoint, string> labelPoint = chartPoint => string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);
            List<ProductoData> productosData = new List<ProductoData>();

            using (SqlConnection oconexion = new SqlConnection(conexion.cadena))
            {
                oconexion.Open();
                using (SqlCommand command = new SqlCommand("ObtenerProductosMasVendidos", oconexion))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            productosData.Add(new ProductoData
                            {
                                Nombre = reader["Nombre"].ToString(),
                                CantidadVendida = Convert.ToInt32(reader["CantidadVendida"])
                            });
                        }
                    }
                }
            }

            SeriesCollection pieSeriesCollection = new SeriesCollection();
            foreach (var producto in productosData)
            {
                pieSeriesCollection.Add(new PieSeries
                {
                    Title = producto.Nombre,
                    Values = new ChartValues<double> { producto.CantidadVendida },
                    DataLabels = true,
                    LabelPoint = labelPoint
                });
            }

            pieChart1.Series = pieSeriesCollection;
            pieChart1.LegendLocation = LegendLocation.Bottom;


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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void iconPictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void cartesianChart1_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

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

            var chart = elementHost1.Child as CartesianChart;
            if (chart != null)
            {
                // Ahora puedes acceder a `chart.Series`
                chart.Series.Clear();
                // Continúa con la configuración de las series aquí
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

        private void anioSeleccionado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxAnio.SelectedItem != null && int.TryParse(comboBoxAnio.SelectedItem.ToString(), out int anioSeleccionado))
            {
                ConfigurarGraficoDeLineas(anioSeleccionado); // Asegúrate de que esta implementación esté correcta.
            }
            else
            {
                MessageBox.Show("Selección de año inválida.");
            }

        }

        private void ConfigurarGraficoDeLineas(int anioSeleccionado)
        {
            // Utiliza el parámetro anioSeleccionado en lugar de obtenerlo del comboBoxAnio
            var datosVentas = ObtenerDatosVentasPorAnio(anioSeleccionado);
            // Continúa con la configuración del gráfico como antes, usando datosVentas
        }

       

    }
}
