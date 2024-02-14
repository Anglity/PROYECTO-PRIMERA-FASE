using entidad;
using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace proyecto
{
    public partial class Analisis_venta : Form
    {
        private usuario _usuario;
        public Analisis_venta(usuario oUsuario = null)
        {
            _usuario = oUsuario;
            InitializeComponent();
        }

        public Analisis_venta()
        {
            InitializeComponent();
        }

        private void CargarDatosEnChart()
        {


        }


        private void Analisis_venta_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'proyectoDataSet.ObtenerProduccionMensual' Puede moverla o quitarla según sea necesario.
            Func<ChartPoint, string> labelPoint = chartPoint => string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);

            // Define una lista para almacenar los datos de productos desde la base de datos
            List<ProductoData> productosData = new List<ProductoData>();

            // Establece la cadena de conexión a tu base de datos
            string connectionString = "Data Source=DESKTOP-9IPMQJR\\ANGEL10;Initial Catalog=proyecto;Integrated Security=True";

            // Realiza la conexión a la base de datos y obtén los datos de productos más vendidos
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("ObtenerProductosMasVendidos", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ProductoData producto = new ProductoData
                            {
                                Nombre = reader["Nombre"].ToString(),
                                CantidadVendida = Convert.ToInt32(reader["CantidadVendida"])
                            };
                            productosData.Add(producto);
                        }
                    }
                }

            }
            // Configura el gráfico circular utilizando los datos obtenidos
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
    }
}
