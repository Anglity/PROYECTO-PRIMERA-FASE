using datos;
using entidad;
using System;

using System.Linq;
using System.Windows.Forms;

namespace proyecto
{
    public partial class listareceta : Form
    {
        public listareceta()
        {
            InitializeComponent();
            CargarRecetas();


        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            foreach (object itemChecked in checkedListBoxRecetas.CheckedItems)
            {
                string nombreReceta = itemChecked.ToString();
                VerificarYActualizarProducto(nombreReceta);
            }
        }

        private void CargarRecetas()
        {
            // Suponiendo que tienes una clase cd_recetas con un método Listar()
            cd_receta datosRecetas = new cd_receta();
            var listaRecetas = datosRecetas.Listar();

            foreach (receta receta in listaRecetas)
            {
                checkedListBoxRecetas.Items.Add(receta.NombreReceta);
            }
        }


        private int PedirCantidadProduccion()
        {
            // Puedes reemplazar esto con tu propio método de diálogo
            string input = Microsoft.VisualBasic.Interaction.InputBox("Ingrese la cantidad a producir", "Cantidad de Producción", "1");
            int cantidad;
            if (int.TryParse(input, out cantidad))
            {
                return cantidad;
            }
            return 0; // Devuelve 0 si la entrada no es válida
        }

        private void VerificarYActualizarProducto(string nombreReceta)
        {

            cd_producto datosProducto = new cd_producto();
            cd_receta datosReceta = new cd_receta();

            var receta = datosReceta.Listar().FirstOrDefault(r => r.NombreReceta == nombreReceta);
            if (receta != null)
            {
                int cantidadDeseada = PedirCantidadProduccion();
                if (cantidadDeseada > 0)
                {
                    int cantidadProduccionReceta = receta.CantidadProduccion;
                    double factor = (double)cantidadDeseada / cantidadProduccionReceta;

                    var productos = datosReceta.ObtenerProductosReceta(nombreReceta);

                    // Verificar si hay suficiente stock para todos los productos
                    foreach (var producto in productos)
                    {
                        int cantidadAjustada = (int)Math.Ceiling(producto.Cantidad * factor);
                        if (!datosProducto.VerificarStockProducto(producto.Nombre, cantidadAjustada))
                        {
                            MessageBox.Show("No hay suficiente stock para el producto: " + producto.Nombre);
                            return; // Sale del método si no hay suficiente stock
                        }
                    }

                    // Disminuir el stock de los productos de la receta
                    foreach (var producto in productos)
                    {
                        int cantidadAjustada = (int)Math.Ceiling(producto.Cantidad * factor);
                        datosProducto.DisminuirStockProducto(producto.Nombre, cantidadAjustada);
                    }

                    // Actualizar el stock del producto que tiene el nombre de la receta
                    if (!datosProducto.ExisteProducto(nombreReceta))
                    {
                        // Crear un nuevo producto si no existe
                        CrearProducto(nombreReceta, cantidadDeseada);
                    }
                    else
                    {
                        // Incrementar el stock del producto existente
                        datosProducto.ActualizarCantidad(nombreReceta, cantidadDeseada);
                    }
                }
            }
            else
            {
                MessageBox.Show("La receta seleccionada no existe.");
            }
        }

        private void CrearProducto(string nombreProducto, int stockInicial)
        {
            cd_producto datosProducto = new cd_producto();
            string mensaje;

            // Generar un código único para el producto
            string codigoProducto = "4555" + DateTime.Now.Ticks.ToString();

            producto nuevoProducto = new producto
            {
                Codigo = codigoProducto,
                Nombre = nombreProducto,
                Descripcion = "Producto generado automáticamente para la receta: " + nombreProducto,
                Stock = 0, // El stock inicial será 0 ya que lo actualizaremos después de crear el producto
                Estado = true,
                FechaRegistro = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                UnidadMedida = "unidades",
                ocategoria = new categoria { IdCategoria = 1 }, // Asumiendo que 1 es la categoría 'Lácteos'
                PrecioCompra = 0, // Ejemplo
                PrecioVenta = 0, // Ejemplo
            };

            // Registrar el producto
            int idProductoNuevo = datosProducto.Registrar(nuevoProducto, out mensaje);

            // Si se creó correctamente, actualizar el stock
            if (idProductoNuevo > 0)
            {
                bool actualizacionCorrecta = datosProducto.ActualizarCantidad(nombreProducto, stockInicial);

                if (!actualizacionCorrecta)
                {
                    mensaje = "Producto creado, pero hubo un error al actualizar el stock.";
                }
            }

            MessageBox.Show(mensaje);
        }


        private void listareceta_Load(object sender, EventArgs e)
        {

        }
    }
}
