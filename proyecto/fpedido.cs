using datos;
using entidad;
using negocio;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyecto
{

    public partial class fpedido : Form
    {
        private StringBuilder productosFaltantes = new StringBuilder();
        private List<entidad.ProduccionAplazada> produccionesAplazadas = new List<entidad.ProduccionAplazada>(); // Usa el tipo de entidad aquí
        private bool esReprogramacion = false; // Declaración aquí
        public string ultimoCorreoEnviado;

        private DateTime fechaMinimaProduccion;
        public fpedido()
        {
            InitializeComponent();
            CargarRecetas();
            timer1.Start(); // Iniciar el Timer
            CargarListaProduccionesAplazadas();
            CargarProduccionesAplazadasDesdeBD();
            CargarPedidosAplazados();
            checkedListBoxPedidosAplazados.ItemCheck += new ItemCheckEventHandler(checkedListBoxPedidosAplazados_ItemCheck);


        }
        private void CargarPedidosAplazados()
        {
            cd_pedidosAplazados datosPedidosAplazados = new cd_pedidosAplazados();
            var listaPedidos = datosPedidosAplazados.ListarPedidosAplazados();

            checkedListBoxPedidosAplazados.Items.Clear(); // Limpia los elementos existentes

            foreach (var pedido in listaPedidos)
            {
                if (!pedido.FueManejada)
                {
                    checkedListBoxPedidosAplazados.Items.Add($"{pedido.NombreReceta} - Cantidad necesaria: {pedido.Cantidad} - Llegada: {pedido.FechaHoraProgramada.ToString("g")}");
                }
            }
        }


        private void fpedido_FormClosing(object sender, FormClosingEventArgs e)
        {
            cd_produccionesAplazadas datosProduccionesAplazadas = new cd_produccionesAplazadas();
            foreach (var produccion in produccionesAplazadas)
            {
                datosProduccionesAplazadas.InsertarActualizarProduccionAplazada(produccion);
            }
        }

        private void CargarProduccionesAplazadasDesdeBD()
        {
            cd_produccionesAplazadas datosProduccionesAplazadas = new cd_produccionesAplazadas();
            produccionesAplazadas = datosProduccionesAplazadas.ListarProduccionesAplazadas();
            ActualizarListBoxProduccionesAplazadas();
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
            string input = Microsoft.VisualBasic.Interaction.InputBox("ingrese la cantidad del pedido", "1");
            int cantidad;
            if (int.TryParse(input, out cantidad))
            {
                return cantidad;
            }
            return 0; // Devuelve 0 si la entrada no es válida
        }
        private void fpedido_Load(object sender, EventArgs e)
        {
            Cargarproducto();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            foreach (object itemChecked in checkedListBoxRecetas.CheckedItems)
            {
                string nombreReceta = itemChecked.ToString();
                VerificarYActualizarProducto(nombreReceta);
            }
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
                    bool stockSuficiente = true;
                    productosFaltantes.Clear();
                    StringBuilder ingredientesFaltantes = new StringBuilder();

                    foreach (var producto in productos)
                    {
                        int cantidadAjustada = (int)Math.Ceiling(producto.Cantidad * factor);
                        if (!datosProducto.VerificarStockProducto(producto.Nombre, cantidadAjustada))
                        {
                            ingredientesFaltantes.AppendLine($"{producto.Nombre} - Cantidad necesaria: {cantidadAjustada}");
                            stockSuficiente = false;
                        }
                    }

                    // Mostrar lista de ingredientes faltantes (si los hay)
                    if (ingredientesFaltantes.Length > 0)
                    {
                        MessageBox.Show("Ingredientes faltantes para la receta:\n" + ingredientesFaltantes.ToString(), "Ingredientes Faltantes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    int stockProductoFinal = datosProducto.ObtenerStockActual(nombreReceta);
                    int cantidadFaltante = cantidadDeseada - stockProductoFinal;

                    if (stockProductoFinal < cantidadDeseada)
                    {
                        productosFaltantes.AppendLine($"{nombreReceta} - Cantidad faltante: {cantidadFaltante}");
                        stockSuficiente = false;
                    }

                    bool esFechaExistente = checkedListBoxPedidosAplazados.Items.Cast<string>().Any(item => productos.Any(p => item.StartsWith(p.Nombre)));
                    if (!esFechaExistente && ingredientesFaltantes.Length > 0)
                    {
                        DateTime fechaAleatoria = FechaAleatoria.GenerarFechaAleatoria();
                        fechaMinimaProduccion = fechaAleatoria;
                    }
                    else if (esFechaExistente)
                    {
                        var fechaExistenteMasProxima = checkedListBoxPedidosAplazados.Items.Cast<string>()
                            .Where(item => productos.Any(p => item.StartsWith(p.Nombre)))
                            .Select(item => ExtraerFechaDeItem(item))
                            .OrderBy(fecha => fecha)
                            .FirstOrDefault(fecha => fecha >= DateTime.Now);

                        if (fechaExistenteMasProxima != default)
                        {
                            AgregarOActualizarProduccionEnFechaExistente(nombreReceta, cantidadDeseada, fechaExistenteMasProxima);
                            fechaMinimaProduccion = fechaExistenteMasProxima;
                        }
                    }
                    else
                    {
                        var fechasExistentes = checkedListBoxPedidosAplazados.Items.Cast<string>()
                            .Where(item => productos.Any(p => item.StartsWith(p.Nombre)))
                            .Select(item => ExtraerFechaDeItem(item))
                            .ToList();

                        if (fechasExistentes.Any())
                        {
                            fechaMinimaProduccion = fechasExistentes.Max();
                        }
                    }

                    if (!stockSuficiente && productosFaltantes.Length > 0)
                    {
                        DateTime fechaBase = fechaMinimaProduccion != DateTime.MinValue ? fechaMinimaProduccion : DateTime.Now;

                        if (stockProductoFinal > 0)
                        {
                            string mensaje = $"Actualmente hay {stockProductoFinal} unidades en stock, pero faltan {cantidadFaltante} unidades para completar su pedido de {cantidadDeseada} unidades.\n" +
                                              "¿Quieres llevarte la cantidad disponible en Stock (Sí) o esperar el pedido completo (No)?";
                            DialogResult respuestaUsuario = MessageBox.Show(mensaje, "Confirmación de Producción", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                            if (respuestaUsuario == DialogResult.Yes)
                            {
                                // El usuario elige llevarse lo que está disponible en stock
                                // Reducir el stock actual por la cantidad disponible
                                datosProducto.DisminuirStockProducto(nombreReceta, stockProductoFinal);

                                // Planificar la producción de la cantidad faltante
                                DateTime fechaEstimadaParaCantidadFaltante = CalcularFechaEstimadaProduccion(nombreReceta, cantidadFaltante, fechaBase);
                                AgregarProduccionAplazada(nombreReceta, cantidadFaltante, fechaEstimadaParaCantidadFaltante);
                            }
                            else
                            {
                                // El usuario elige esperar el pedido completo
                                // Planificar la producción del pedido completo sin modificar el stock actual
                                DateTime fechaEstimadaParaPedidoCompleto = CalcularFechaEstimadaProduccion(nombreReceta, cantidadDeseada, fechaBase);
                                AgregarProduccionAplazada(nombreReceta, cantidadDeseada, fechaEstimadaParaPedidoCompleto);
                            }
                        }
                        else
                        {
                            string mensaje = $"No hay stock para el producto final. Faltan {cantidadFaltante} unidades.\n" +
                                              "Se procederá a planificar la producción de la cantidad faltante.";
                            MessageBox.Show(mensaje, "Producción Necesaria", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            DateTime fechaEstimadaParaCantidadFaltante = CalcularFechaEstimadaProduccion(nombreReceta, cantidadFaltante, fechaBase);
                            AgregarProduccionAplazada(nombreReceta, cantidadFaltante, fechaEstimadaParaCantidadFaltante);
                        }
                    }
                }
            }
        }
        // Métodos auxiliares como FechaAleatoria.GenerarFechaAleatoria, AgregarOActualizarProduccionEnFechaExistente, ExtraerFechaDeItem, etc., deben estar definidos.



        public class FechaAleatoria
        {
            public static DateTime GenerarFechaAleatoria()
            {
                Random rnd = new Random();
                DateTime fechaActual = DateTime.Now;

                // Limitar el rango de días a 6 días a partir de hoy
                DateTime fechaMaxima = fechaActual.AddDays(6);

                DateTime fechaAleatoria;
                do
                {
                    // Generar una fecha aleatoria dentro del rango de 6 días
                    fechaAleatoria = fechaActual.AddDays(rnd.Next(0, 7)); // 7 es exclusivo, generará hasta el 6to día

                    // Si es fin de semana, ajustar al siguiente día hábil
                    while (fechaAleatoria.DayOfWeek == DayOfWeek.Saturday || fechaAleatoria.DayOfWeek == DayOfWeek.Sunday)
                    {
                        fechaAleatoria = fechaAleatoria.AddDays(1);
                    }
                }
                while (fechaAleatoria > fechaMaxima); // Verificar que no se exceda el rango de 6 días

                // Generar una hora aleatoria entre las 8 de la mañana y las 6 de la tarde
                int horas = rnd.Next(8, 18);
                fechaAleatoria = fechaAleatoria.Date.AddHours(horas);

                return fechaAleatoria;
            }
        }


        private void Cargarproducto()
        {
            dgdata.Rows.Clear(); // Limpiamos las filas existentes en el DataGridView

            //MOSTRAR TODOS LOS USUARIOS
            List<producto> lista = new cn_producto().listar();

            foreach (producto item in lista)
            {
                // Solo agregar productos cuyo código comience con "P-"
                if (item.Codigo.StartsWith("p-"))
                {
                    string estadoTexto = item.Estado ? "Activo" : "No Activo";
                    dgdata.Rows.Add(new object[] { string.Empty,
                item.IdProducto,
                item.Codigo,
                item.Nombre,
                item.Descripcion,
                item.ocategoria.IdCategoria,
                item.ocategoria.Descripcion,
                item.Stock,
                item.PrecioCompra,
                item.PrecioVenta,
                estadoTexto,
                item.UnidadMedida
            });
                }
            }
        }

        public void AgregarProduccionAplazada(string nombreReceta, int cantidad, DateTime nuevaHoraProgramada)
        {

            // Buscar si ya existe una producción aplazada para la misma receta
            var produccionExistente = produccionesAplazadas.FirstOrDefault(p => p.NombreReceta == nombreReceta);

            if (produccionExistente != null)
            {
                // Si estamos reprogramando, no cambiar la cantidad
                if (!esReprogramacion)
                {
                    produccionExistente.Cantidad += cantidad; // Sumar solo si no es reprogramación
                }

                // Utilizar el método para establecer la fecha y hora programada
                produccionExistente.EstablecerFechaHoraProgramada(nuevaHoraProgramada);

                produccionExistente.FueManejada = false;

                // Actualizar en la base de datos
                cd_produccionesAplazadas datosProduccionesAplazadas = new cd_produccionesAplazadas();
                datosProduccionesAplazadas.ActualizarProduccionAplazada(produccionExistente);
            }
            else
            {
                // Crear una nueva producción aplazada si no existe
                entidad.ProduccionAplazada nuevaProduccionAplazada = new entidad.ProduccionAplazada
                {
                    NombreReceta = nombreReceta,
                    Cantidad = cantidad,
                    FueManejada = false
                };

                // Utilizar el método para establecer la fecha y hora programada
                nuevaProduccionAplazada.EstablecerFechaHoraProgramada(nuevaHoraProgramada);

                // Agregar a la lista
                produccionesAplazadas.Add(nuevaProduccionAplazada);

                // Guardar en la base de datos
                cd_produccionesAplazadas datosProduccionesAplazadas = new cd_produccionesAplazadas();
                datosProduccionesAplazadas.InsertarProduccionAplazada(nuevaProduccionAplazada);
            }

            // Actualizar el ListBox
            ActualizarListBoxProduccionesAplazadas();
        }


        private void ActualizarListBoxProduccionesAplazadas()
        {
            listBoxProduccionesAplazadas.Items.Clear();
            foreach (var produccion in produccionesAplazadas)
            {
                // Usar el método ObtenerFechaHoraProgramada para acceder a la fecha y hora
                string displayText = $"{produccion.NombreReceta} - {produccion.Cantidad} unidades - {produccion.ObtenerFechaHoraProgramada().ToString("g")}";
                listBoxProduccionesAplazadas.Items.Add(displayText);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop(); // Detener el Timer para manejar las tareas

            List<entidad.ProduccionAplazada> tareasParaManejar = produccionesAplazadas
        .Where(p => DateTime.Now >= p.ObtenerFechaHoraProgramada() && !p.FueManejada)
        .ToList();

            foreach (var produccion in tareasParaManejar)
            {
                if (!VerificarDisponibilidadProductos(produccion.NombreReceta, produccion.Cantidad))
                {
                    MessageBox.Show("No tienes suficientes productos para la receta: " + produccion.NombreReceta, "Falta de Productos", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    // Agregar lógica para obtener los productos faltantes
                    productosFaltantes.Clear();
                    ObtenerProductosFaltantes(produccion.NombreReceta, produccion.Cantidad); // Asumiendo que este método rellena el StringBuilder productosFaltantes

                    if (productosFaltantes.Length > 0)
                    {
                        MessageBox.Show("Productos faltantes:\n" + productosFaltantes.ToString(), "Productos Faltantes", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Mostrar formulario para configurar nueva fecha
                        fConfigurarFechaHora formFechaHora = new fConfigurarFechaHora();
                        if (formFechaHora.ShowDialog() == DialogResult.OK)
                        {
                            DateTime nuevaFechaLlegada = formFechaHora.FechaHoraSeleccionada;
                            ActualizarOAgregarProductoFaltante(productosFaltantes, nuevaFechaLlegada);
                        }
                    }

                    ReprogramarProduccion(produccion.NombreReceta);
                }
                else
                {
                    var respuesta = MessageBox.Show($"Hay suficientes productos para la receta: {produccion.NombreReceta}. ¿Desea producir ahora?", "Confirmación de Producción", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (respuesta == DialogResult.Yes)
                    {
                        ProduccionDeReceta(produccion.NombreReceta, produccion.Cantidad);
                        produccion.FueManejada = true; // Marcar como manejada
                        cd_produccionesAplazadas datosProduccionesAplazadas = new cd_produccionesAplazadas();
                        datosProduccionesAplazadas.ActualizarProduccionAplazada(produccion); // Actualizar en la base de datos
                    }
                    else
                    {
                        ReprogramarProduccion(produccion.NombreReceta);
                    }
                }
            }

            produccionesAplazadas.RemoveAll(p => p.FueManejada); // Eliminar tareas manejadas de la lista principal
            ActualizarListBoxProduccionesAplazadas();


            // Manejo de pedidos aplazados
            for (int i = checkedListBoxPedidosAplazados.Items.Count - 1; i >= 0; i--)
            {
                var item = checkedListBoxPedidosAplazados.Items[i].ToString();
                DateTime horaLlegada = ExtraerFechaDeItem(item);

                if (DateTime.Now >= horaLlegada)
                {
                    var respuesta = MessageBox.Show($"¿Han llegado los productos para la receta: {ExtraerNombreRecetaDeItem(item)}?", "Confirmación de Llegada", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (respuesta == DialogResult.Yes)
                    {
                        AumentarStock(ExtraerNombreRecetaDeItem(item), ExtraerCantidadDeItem(item));
                        checkedListBoxPedidosAplazados.Items.RemoveAt(i);

                        // Marcar el pedido como manejado en la base de datos
                        MarcarPedidoComoManejado(ExtraerNombreRecetaDeItem(item), ExtraerCantidadDeItem(item));
                    }
                    else
                    {
                        // Mostrar diálogo para reprogramar la entrega
                        fConfigurarFechaHora formFechaHora = new fConfigurarFechaHora();
                        if (formFechaHora.ShowDialog() == DialogResult.OK)
                        {
                            DateTime nuevaFechaLlegada = formFechaHora.FechaHoraSeleccionada;
                            ActualizarFechaLlegadaProductoFaltante(i, nuevaFechaLlegada);
                            ReprogramarProduccionAplazada(ExtraerNombreRecetaDeItem(item), nuevaFechaLlegada);
                        }
                    }
                }
            }


            timer1.Start(); // Reiniciar el Timer
        }

        private void MarcarPedidoComoManejado(string nombreReceta, int cantidad)
        {
            cd_pedidosAplazados datosPedidosAplazados = new cd_pedidosAplazados();
            // Obtén el pedido de la base de datos
            PedidoAplazado pedido = datosPedidosAplazados.ObtenerPedido(nombreReceta, cantidad);

            if (pedido != null)
            {
                pedido.FueManejada = true;
                // Actualiza el estado del pedido en la base de datos
                datosPedidosAplazados.ActualizarPedidoAplazado(pedido);
            }
        }

        private void ObtenerProductosFaltantes(string nombreReceta, int cantidadDeseada)
        {
            cd_receta datosReceta = new cd_receta();
            var receta = datosReceta.Listar().FirstOrDefault(r => r.NombreReceta == nombreReceta);
            if (receta != null)
            {
                double factor = (double)cantidadDeseada / receta.CantidadProduccion;
                var productosReceta = datosReceta.ObtenerProductosReceta(nombreReceta);
                cd_producto datosProducto = new cd_producto();

                foreach (var producto in productosReceta)
                {
                    int cantidadAjustada = (int)Math.Ceiling(producto.Cantidad * factor);
                    if (!datosProducto.VerificarStockProducto(producto.Nombre, cantidadAjustada))
                    {
                        // Agregar el producto faltante y la cantidad necesaria al StringBuilder
                        int cantidadFaltante = cantidadAjustada - datosProducto.ObtenerStockActual(producto.Nombre);
                        if (cantidadFaltante > 0)
                        {
                            productosFaltantes.AppendLine($"{producto.Nombre} - Cantidad necesaria: {cantidadFaltante}");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("La receta seleccionada no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool VerificarDisponibilidadProductos(string nombreReceta, int cantidadDeseada)
        {
            cd_receta datosReceta = new cd_receta();
            var receta = datosReceta.Listar().FirstOrDefault(r => r.NombreReceta == nombreReceta);
            if (receta != null)
            {
                double factor = (double)cantidadDeseada / receta.CantidadProduccion;
                var productos = datosReceta.ObtenerProductosReceta(nombreReceta);
                cd_producto datosProducto = new cd_producto();

                foreach (var producto in productos)
                {
                    int cantidadAjustada = (int)Math.Ceiling(producto.Cantidad * factor);
                    if (!datosProducto.VerificarStockProducto(producto.Nombre, cantidadAjustada))
                    {
                        return false; // Retorna false si no hay suficiente cantidad de alguno de los productos
                    }
                }
                return true; // Retorna true si todas las cantidades están disponibles
            }
            return false; // Retorna false si la receta no se encuentra
        }



        private void ReprogramarProduccion(string nombreReceta)
        {
            esReprogramacion = true;  // Indicar que estamos en proceso de reprogramación

            var produccionExistente = produccionesAplazadas.FirstOrDefault(p => p.NombreReceta == nombreReceta);

            if (produccionExistente != null)
            {
                fConfigurarHora formReprogramar = new fConfigurarHora(nombreReceta, produccionExistente.Cantidad, this);
                if (formReprogramar.ShowDialog() == DialogResult.OK)
                {
                    DateTime nuevaFecha = formReprogramar.NuevaFecha;

                    // Usar el método para establecer la nueva fecha y hora programada
                    produccionExistente.EstablecerFechaHoraProgramada(nuevaFecha);
                    produccionExistente.FueManejada = false; // Marcar como no manejada para reevaluación

                    // Actualizar en la base de datos
                    cd_produccionesAplazadas datosProduccionesAplazadas = new cd_produccionesAplazadas();
                    datosProduccionesAplazadas.ActualizarProduccionAplazada(produccionExistente);

                    // Actualizar el ListBox
                    ActualizarListBoxProduccionesAplazadas();
                }
            }
            else
            {
                MessageBox.Show("La producción no se encuentra en la lista.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            esReprogramacion = false;
        }

        // Método para actualizar la fecha de llegada de un producto faltante
        private void ActualizarFechaLlegadaProductoFaltante(int index, DateTime nuevaFecha)
        {
            string itemActual = checkedListBoxPedidosAplazados.Items[index].ToString();
            string[] partes = itemActual.Split(new[] { " - Llegada: " }, StringSplitOptions.None);
            string nombreProducto = ExtraerNombreRecetaDeItem(partes[0]);
            int cantidadNecesaria = ExtraerCantidadDeItem(partes[0]);

            // Actualizar la cantidad y la fecha en la interfaz de usuario
            checkedListBoxPedidosAplazados.Items[index] = $"{nombreProducto} - Cantidad necesaria: {cantidadNecesaria} - Llegada: {nuevaFecha.ToString("g")}";

            // Llamada al método para actualizar el pedido en la base de datos
            ActualizarPedidoEnBaseDatos(nombreProducto, cantidadNecesaria, nuevaFecha);
        }


        private void ActualizarPedidoEnBaseDatos(string nombreProducto, int cantidadNecesaria, DateTime nuevaFechaLlegada)
        {
            datos.cd_pedidosAplazados datosPedidosAplazados = new datos.cd_pedidosAplazados();
            entidad.PedidoAplazado pedidoExistente = datosPedidosAplazados.ObtenerPedido(nombreProducto, cantidadNecesaria);

            if (pedidoExistente != null)
            {
                pedidoExistente.FechaHoraProgramada = nuevaFechaLlegada;
                pedidoExistente.Cantidad = cantidadNecesaria; // Actualizar la cantidad
                datosPedidosAplazados.ActualizarPedidoAplazado(pedidoExistente);
            }
            else
            {
                // Manejo de errores o creación de un nuevo pedido
            }

        }

        // Método para reprogramar una producción aplazada
        private void ReprogramarProduccionAplazada(string nombreReceta, DateTime nuevaFechaLlegada)
        {
            esReprogramacion = true;  // Indicar que estamos en proceso de reprogramación

            var produccionExistente = produccionesAplazadas.FirstOrDefault(p => p.NombreReceta == nombreReceta);

            if (produccionExistente != null)
            {
                fConfigurarHora formReprogramar = new fConfigurarHora(nombreReceta, produccionExistente.Cantidad, this);
                if (formReprogramar.ShowDialog() == DialogResult.OK)
                {
                    DateTime nuevaFecha = formReprogramar.NuevaFecha;

                    // Usar el método para establecer la nueva fecha y hora programada
                    produccionExistente.EstablecerFechaHoraProgramada(nuevaFecha);
                    produccionExistente.FueManejada = false; // Marcar como no manejada para reevaluación

                    // Actualizar en la base de datos
                    cd_produccionesAplazadas datosProduccionesAplazadas = new cd_produccionesAplazadas();
                    datosProduccionesAplazadas.ActualizarProduccionAplazada(produccionExistente);

                    // Actualizar el ListBox
                    ActualizarListBoxProduccionesAplazadas();
                }
            }
            else
            {
                MessageBox.Show("La producción no se encuentra en la lista.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            esReprogramacion = false;
        }

        private DateTime ExtraerFechaDeItem(string item)
        {
            // Asumiendo que el formato es "NombreProducto - Cantidad necesaria: X - Llegada: fecha/hora"
            var partes = item.Split(new[] { " - Llegada: " }, StringSplitOptions.None);
            if (partes.Length > 1 && DateTime.TryParse(partes[1], out DateTime fecha))
            {
                return fecha;
            }
            return DateTime.MinValue; // Retorna una fecha mínima en caso de error
        }

        private string ExtraerNombreRecetaDeItem(string item)
        {
            // Asumiendo que el formato es "NombreProducto - Cantidad necesaria: X - Llegada: fecha/hora"
            var partes = item.Split('-');
            return partes[0].Trim();
        }

        private int ExtraerCantidadDeItem(string item)
        {
            // Asumiendo que el formato es "NombreProducto - Cantidad necesaria: X - Llegada: fecha/hora"
            var partes = item.Split(new[] { "Cantidad necesaria: " }, StringSplitOptions.None);
            if (partes.Length > 1)
            {
                var cantidadPartes = partes[1].Split('-');
                if (int.TryParse(cantidadPartes[0].Trim(), out int cantidad))
                {
                    return cantidad;
                }
            }
            return 0; // Retorna 0 en caso de error
        }

        private void AumentarStock(string nombreProducto, int cantidad)
        {
            // Crear una instancia de cd_producto para interactuar con la base de datos
            cd_producto datosProducto = new cd_producto();

            // Verificar si el producto existe
            if (datosProducto.ExisteProducto(nombreProducto))
            {
                // Si existe, actualizar la cantidad del producto
                datosProducto.ActualizarCantidad(nombreProducto, cantidad);
            }
            else
            {
                // Si no existe, podrías optar por crear un nuevo producto o manejar de otra manera
                // Por ejemplo, mostrar un mensaje de error o crear un nuevo producto
                // CrearProducto(nombreProducto, cantidad);
            }
        }

        private void ProduccionDeReceta(string nombreReceta, int cantidad)
        {
            cd_producto datosProducto = new cd_producto();
            cd_receta datosReceta = new cd_receta();

            var receta = datosReceta.Listar().FirstOrDefault(r => r.NombreReceta == nombreReceta);
            if (receta != null)
            {
                int cantidadProduccionReceta = receta.CantidadProduccion;
                double factor = (double)cantidad / cantidadProduccionReceta;

                var productos = datosReceta.ObtenerProductosReceta(nombreReceta);
                bool stockSuficiente = true;

                foreach (var producto in productos)
                {
                    int cantidadAjustada = (int)Math.Ceiling(producto.Cantidad * factor);
                    if (!datosProducto.VerificarStockProducto(producto.Nombre, cantidadAjustada))
                    {
                        MessageBox.Show($"No hay suficiente stock para el producto: {producto.Nombre}. No se puede proceder con la producción.", "Stock Insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        stockSuficiente = false;
                        break; // Salir del bucle si falta algún producto
                    }
                }

                if (stockSuficiente)
                {
                    // Proceder con la disminución del stock y la producción
                    foreach (var producto in productos)
                    {
                        int cantidadAjustada = (int)Math.Ceiling(producto.Cantidad * factor);
                        datosProducto.DisminuirStockProducto(producto.Nombre, cantidadAjustada);
                    }

                    // Actualizar el stock del producto que tiene el nombre de la receta
                    if (!datosProducto.ExisteProducto(nombreReceta))
                    {
                        // Crear un nuevo producto si no existe
                        // CrearProducto(nombreReceta, cantidad);
                    }
                    else
                    {
                        // Incrementar el stock del producto existente
                        datosProducto.ActualizarCantidad(nombreReceta, cantidad);
                    }
                    MessageBox.Show("La receta ha sido producida exitosamente.", "Producción Completada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("La receta seleccionada no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActualizarOAgregarProductoFaltante(StringBuilder productos, DateTime fechaLlegadaEstimada)
        {
            List<Ingrediente> ingredientesActualizados = new List<Ingrediente>();

            foreach (string linea in productos.ToString().Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries))
            {
                string nombreProducto = linea.Split('-')[0].Trim();
                int cantidadAdicionalNecesaria = int.Parse(linea.Split(':')[1].Trim());

                bool productoEncontrado = false;
                for (int i = 0; i < checkedListBoxPedidosAplazados.Items.Count; i++)
                {
                    string itemActual = checkedListBoxPedidosAplazados.Items[i].ToString();
                    if (itemActual.StartsWith(nombreProducto))
                    {
                        productoEncontrado = true;

                        // Actualizar el checkedListBoxPedidosAplazados con la cantidad adicional
                        string[] partes = itemActual.Split(new[] { " - Llegada: " }, StringSplitOptions.None);
                        string[] cantidadPartes = partes[0].Split(new[] { "Cantidad necesaria: " }, StringSplitOptions.None);
                        int cantidadExistente = int.Parse(cantidadPartes[1].Trim());
                        int cantidadTotal = cantidadExistente + cantidadAdicionalNecesaria;
                        checkedListBoxPedidosAplazados.Items[i] = $"{nombreProducto} - Cantidad necesaria: {cantidadTotal} - Llegada: {fechaLlegadaEstimada.ToString("g")}";
                        break;
                    }
                }

                // Agregar a la lista de ingredientes actualizados
                ingredientesActualizados.Add(new Ingrediente(nombreProducto, cantidadAdicionalNecesaria) { EsNuevo = !productoEncontrado });

                if (!productoEncontrado)
                {
                    // Agregar el producto al checkedListBoxPedidosAplazados
                    string nuevoItem = $"{nombreProducto} - Cantidad necesaria: {cantidadAdicionalNecesaria} - Llegada: {fechaLlegadaEstimada.ToString("g")}";
                    checkedListBoxPedidosAplazados.Items.Add(nuevoItem);

                    // Guardar el nuevo producto directamente en la base de datos
                    GuardarProductoEnBaseDatos(nombreProducto, cantidadAdicionalNecesaria, fechaLlegadaEstimada);
                }
            }

            // Actualizar la base de datos con los ingredientes actualizados
            ActualizarBaseDatosConNuevosIngredientes(ingredientesActualizados);
        }

        private void GuardarProductoEnBaseDatos(string nombreProducto, int cantidadNecesaria, DateTime fechaLlegadaEstimada)
        {
            // Crear una nueva entidad de pedido aplazado
            entidad.PedidoAplazado nuevoPedido = new entidad.PedidoAplazado
            {
                NombreReceta = nombreProducto,
                Cantidad = cantidadNecesaria,
                FechaHoraProgramada = fechaLlegadaEstimada,
                FueManejada = false
            };

            // Utilizar la clase cd_pedidosAplazados para insertar en la base de datos
            datos.cd_pedidosAplazados datosPedidosAplazados = new datos.cd_pedidosAplazados();
            datosPedidosAplazados.InsertarPedidoAplazado(nuevoPedido);
        }
        private int ExtraerCantidad(string linea)
        {
            string[] partes = linea.Split(new[] { "Cantidad necesaria: " }, StringSplitOptions.None);
            if (partes.Length > 1)
            {
                string[] cantidadYResto = partes[1].Split('-');
                if (int.TryParse(cantidadYResto[0].Trim(), out int cantidad))
                {
                    return cantidad;
                }
            }
            return 0;
        }

        private void CargarListaProduccionesAplazadas()
        {
            cd_produccionesAplazadas datosProduccionesAplazadas = new cd_produccionesAplazadas();
            var listaProducciones = datosProduccionesAplazadas.ListarProduccionesAplazadas(); // Usando el método ListarProduccionesAplazadas

            listabasededatos.Items.Clear(); // Limpia los elementos existentes en el ListBox

            foreach (var produccion in listaProducciones)
            {
                // Formatea los datos como prefieras para mostrarlos en el ListBox
                listabasededatos.Items.Add($"{produccion.NombreReceta} - Cantidad: {produccion.Cantidad} - Fecha Programada: {produccion.ObtenerFechaHoraProgramada().ToString("dd/MM/yyyy HH:mm")}");
            }
        }
        private void btnEliminarYMarcarManejada_Click(object sender, EventArgs e)
        {
            if (listabasededatos.SelectedItem != null)
            {
                // Obtener el nombre de la receta del ítem seleccionado
                string nombreRecetaSeleccionada = ExtraerNombreRecetaDeItemBaseDatos(listabasededatos.SelectedItem.ToString());

                // Encontrar la producción aplazada correspondiente
                var produccionAEncontrar = produccionesAplazadas.FirstOrDefault(p => p.NombreReceta == nombreRecetaSeleccionada);

                if (produccionAEncontrar != null)
                {
                    // Marcar la producción como manejada
                    produccionAEncontrar.FueManejada = true;

                    // Actualizar la producción en la base de datos
                    cd_produccionesAplazadas datosProduccionesAplazadas = new cd_produccionesAplazadas();
                    datosProduccionesAplazadas.ActualizarProduccionAplazada(produccionAEncontrar);

                    // Eliminar el ítem del ListBox y actualizar la lista
                    listabasededatos.Items.Remove(listabasededatos.SelectedItem);
                    produccionesAplazadas.Remove(produccionAEncontrar);
                }
                else
                {
                    MessageBox.Show("La producción seleccionada no se encuentra en la lista.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una producción de la lista.", "Selección Requerida", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private string ExtraerNombreRecetaDeItemBaseDatos(string item)
        {
            // Asumiendo que el formato es "NombreReceta - Cantidad: X - Fecha Programada: DD/MM/YYYY HH:MM"
            var partes = item.Split('-');
            return partes[0].Trim();
        }

        private async Task EnviarCorreoConTodasLasProduccionesAplazadasAsync(List<string> displayTexts, string correoDestinatario)
        {
            try
            {
                var apiKey = "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"; // Clave API real
                var client = new SendGridClient(apiKey);
                var from = new EmailAddress("colang153@gmail.com", "Angel");
                var to = new EmailAddress(correoDestinatario, "Delicate");

                var msg = new SendGridMessage()
                {
                    From = from,
                    TemplateId = "d-021f649f2d1941bcb665a3a52734a6db" // ID de tu plantilla
                };

                var producciones = new List<object>();

                foreach (string displayText in displayTexts)
                {
                    var partes = displayText.Split(new[] { " - " }, StringSplitOptions.RemoveEmptyEntries);
                    if (partes.Length < 3) continue; // Verificar que la cadena tiene todos los componentes necesarios

                    string nombreReceta = partes[0];
                    string cantidad = partes[1].Split(' ')[1]; // Obtener solo el número de la cantidad
                    string fechaHoraProgramada = partes[2];

                    producciones.Add(new { nombreReceta, cantidad, fechaHoraProgramada });
                }

                var templateData = new { producciones };

                msg.SetTemplateData(templateData);
                msg.AddTo(to);

                var response = await client.SendEmailAsync(msg);
                MessageBox.Show($"Correo enviado. Respuesta del servidor: {response.StatusCode}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al enviar correo: {ex.Message}");
            }
        }


        private void GuardarUltimoCorreo(string correo)
        {
            try
            {
                File.WriteAllText(Path.Combine(Application.StartupPath, "ultimoCorreo.txt"), correo);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el último correo: " + ex.Message);
            }
        }

        private string LeerUltimoCorreo()
        {
            try
            {
                string filePath = Path.Combine(Application.StartupPath, "ultimoCorreo.txt");
                if (File.Exists(filePath))
                {
                    return File.ReadAllText(filePath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al leer el último correo: " + ex.Message);
            }

            return null;
        }

        private void btnEnviarCorreoDetalles_Click(object sender, EventArgs e)
        {
            if (listabasededatos.Items.Count > 0)
            {
                List<string> displayTexts = listabasededatos.Items.Cast<string>().ToList();
                string correoAUtilizar = LeerUltimoCorreoOSeleccionarNuevo();

                if (!string.IsNullOrEmpty(correoAUtilizar))
                {
                    Task.Run(async () =>
                    {
                        await EnviarCorreoConTodasLasProduccionesAplazadasAsync(displayTexts, correoAUtilizar);
                    });
                }
            }
            else
            {
                MessageBox.Show("No hay producciones aplazadas para enviar.");
            }
        }

        private string LeerUltimoCorreoOSeleccionarNuevo()
        {
            string ultimoCorreo = LeerUltimoCorreo();
            string correoAUtilizar = null;

            if (!string.IsNullOrEmpty(ultimoCorreo))
            {
                if (MessageBox.Show("¿Quieres usar el último correo enviado (" + ultimoCorreo + ")?", "Reutilizar Correo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    correoAUtilizar = ultimoCorreo;
                }
            }

            if (string.IsNullOrEmpty(correoAUtilizar))
            {
                usuarios2 formUsuarios = new usuarios2();
                if (formUsuarios.ShowDialog() == DialogResult.OK)
                {
                    var usuarioSeleccionado = formUsuarios.UsuarioSeleccionado;
                    if (usuarioSeleccionado != null)
                    {
                        correoAUtilizar = usuarioSeleccionado.Correo;
                        GuardarUltimoCorreo(correoAUtilizar);
                    }
                }
            }

            return correoAUtilizar;
        }

        // Modificado para sumar solo la cantidad adicional a los pedidos existentes
        private void ActualizarBaseDatosConNuevosIngredientes(List<Ingrediente> ingredientesActualizados)
        {
            cd_pedidosAplazados datosPedidosAplazados = new cd_pedidosAplazados();

            foreach (var ingrediente in ingredientesActualizados)
            {
                var pedidoExistente = datosPedidosAplazados.ObtenerPedidosPorNombreReceta(ingrediente.Nombre).FirstOrDefault();

                if (pedidoExistente != null && !pedidoExistente.FueManejada)
                {
                    if (!ingrediente.EsNuevo)
                    {
                        pedidoExistente.Cantidad += ingrediente.CantidadNueva;
                    }
                    datosPedidosAplazados.ActualizarPedidoAplazado(pedidoExistente);
                }
                else if (pedidoExistente == null)
                {
                    PedidoAplazado nuevoPedido = new PedidoAplazado
                    {
                        NombreReceta = ingrediente.Nombre,
                        Cantidad = ingrediente.CantidadNueva,
                        // Inicializar otros campos necesarios aquí
                    };
                    datosPedidosAplazados.InsertarPedidoAplazado(nuevoPedido);
                }
            }
        }

        private bool manejoEnProgreso = false;

        private void checkedListBoxPedidosAplazados_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked && !manejoEnProgreso)
            {
                manejoEnProgreso = true; // Establecer la bandera para evitar ejecuciones múltiples

                string itemSeleccionado = checkedListBoxPedidosAplazados.Items[e.Index].ToString();

                // Procesar de forma asincrónica
                this.BeginInvoke((MethodInvoker)delegate
                {
                    ProcesarYEliminarItem(itemSeleccionado, e.Index);
                    manejoEnProgreso = false; // Restablecer la bandera después de manejar el ítem
                });
            }
        }

        private void ProcesarYEliminarItem(string item, int index)
        {
            string nombreReceta = ExtraerNombreRecetaDeItem(item);
            int cantidad = ExtraerCantidadDeItem(item);

            try
            {
                MarcarPedidoComoManejado(nombreReceta, cantidad);
                AumentarStock(nombreReceta, cantidad);

                // Eliminar el ítem manejado
                if (checkedListBoxPedidosAplazados.Items.Count > index)
                {
                    checkedListBoxPedidosAplazados.Items.RemoveAt(index);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al procesar el pedido: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task EnviarCorreoConTodosLosPedidosAplazadosAsync(List<string> detallesPedidos, string correoDestinatario)
        {
            try
            {
                var apiKey = "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"; // Clave API real
                var client = new SendGridClient(apiKey);
                var from = new EmailAddress("colang153@gmail.com", "Angel");
                var to = new EmailAddress(correoDestinatario, "Delicate");

                var msg = new SendGridMessage()
                {
                    From = from,
                    TemplateId = "d-346a2dcbf259464694024fe537b1c29d" // Reemplaza con el ID de tu plantilla de SendGrid
                };

                var pedidos = new List<object>();

                foreach (string detallePedido in detallesPedidos)
                {
                    var partes = detallePedido.Split(new[] { " - " }, StringSplitOptions.RemoveEmptyEntries);
                    if (partes.Length < 3) continue;

                    string nombreReceta = partes[0];
                    string cantidad = partes[1].Split(' ')[1];
                    string fechaHoraProgramada = partes[2];

                    pedidos.Add(new { nombreReceta, cantidad, fechaHoraProgramada });
                }

                var templateData = new { pedidos };

                msg.SetTemplateData(templateData);
                msg.AddTo(to);

                var response = await client.SendEmailAsync(msg);
                MessageBox.Show($"Correo enviado. Respuesta del servidor: {response.StatusCode}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al enviar correo: {ex.Message}");
            }
        }
        private void btnEnviarCorreoPedidosAplazados_Click_1(object sender, EventArgs e)
        {
            var datosPedidosAplazados = new cd_pedidosAplazados();
            var listaPedidos = datosPedidosAplazados.ListarPedidosAplazados();
            var detallesPedidos = listaPedidos.Select(pedido => $"{pedido.NombreReceta} - Cantidad: {pedido.Cantidad} - Fecha Programada: {pedido.FechaHoraProgramada.ToString("g")}").ToList();

            if (detallesPedidos.Count > 0)
            {
                string correoDestinatario = LeerUltimoCorreoOSeleccionarNuevo();
                if (!string.IsNullOrEmpty(correoDestinatario))
                {
                    Task.Run(async () =>
                    {
                        await EnviarCorreoConTodosLosPedidosAplazadosAsync(detallesPedidos, correoDestinatario);
                    });
                }
            }
            else
            {
                MessageBox.Show("No hay pedidos aplazados para enviar.");
            }



        }
        private double ConvertirTextoATiempo(string textoTiempo)
        {
            // Definir una expresión regular que identifique números y unidades de tiempo (horas, minutos)
            var regex = new Regex(@"(\d+)\s*(hora|horas|minuto|minutos)", RegexOptions.IgnoreCase);
            var match = regex.Match(textoTiempo);

            if (match.Success)
            {
                // Extraer el número y la unidad de tiempo
                int cantidad = int.Parse(match.Groups[1].Value);
                string unidad = match.Groups[2].Value.ToLower();

                // Convertir a horas dependiendo de la unidad
                switch (unidad)
                {
                    case "hora":
                    case "horas":
                        return cantidad; // Si es hora, devolver el número tal cual
                    case "minuto":
                    case "minutos":
                        return cantidad / 60.0; // Convertir minutos a horas
                    default:
                        break;
                }
            }

            return 0;
        }

        public DateTime CalcularFechaEstimadaProduccion(string nombreReceta, int cantidadDeseada, DateTime fechaBase)
        {
            cd_receta datosRecetas = new cd_receta();
            var receta = datosRecetas.Listar().FirstOrDefault(r => r.NombreReceta == nombreReceta);

            if (receta != null)
            {
                double tiempoTotal = (double)cantidadDeseada / receta.CantidadProduccion * ConvertirTextoATiempo(receta.Tiempo);
                DateTime fechaEstimadaFin = fechaBase;

                while (tiempoTotal > 0)
                {
                    // Verificar si la fecha actual es un día hábil y dentro del horario laboral
                    if (fechaEstimadaFin.Hour >= 8 && fechaEstimadaFin.Hour < 18 &&
                        fechaEstimadaFin.DayOfWeek != DayOfWeek.Saturday &&
                        fechaEstimadaFin.DayOfWeek != DayOfWeek.Sunday)
                    {
                        double horasDisponibles = 18 - fechaEstimadaFin.Hour; // Horas restantes en el día de trabajo
                        double horasAUsar = Math.Min(horasDisponibles, tiempoTotal);
                        fechaEstimadaFin = fechaEstimadaFin.AddHours(horasAUsar);
                        tiempoTotal -= horasAUsar;
                    }

                    // Si se alcanza el final del día de trabajo o es fin de semana, avanzar al siguiente día hábil
                    if (fechaEstimadaFin.Hour >= 18 || fechaEstimadaFin.DayOfWeek == DayOfWeek.Saturday || fechaEstimadaFin.DayOfWeek == DayOfWeek.Sunday)
                    {
                        fechaEstimadaFin = fechaEstimadaFin.AddHours(24 - fechaEstimadaFin.Hour + 8); // Avanzar al próximo día a las 8 AM
                        if (fechaEstimadaFin.DayOfWeek == DayOfWeek.Saturday)
                        {
                            fechaEstimadaFin = fechaEstimadaFin.AddDays(2); // Saltar el fin de semana
                        }
                    }
                }

                return fechaEstimadaFin;
            }

            return DateTime.MinValue; // En caso de que no se encuentre la receta
        }


        private void AgregarOActualizarProduccionEnFechaExistente(string nombreReceta, int cantidadAdicional, DateTime fechaExistente)
        {
            bool fechaEncontrada = false;

            for (int i = 0; i < checkedListBoxPedidosAplazados.Items.Count; i++)
            {
                var item = checkedListBoxPedidosAplazados.Items[i].ToString();
                if (item.StartsWith(nombreReceta))
                {
                    DateTime fechaDeItem = ExtraerFechaDeItem(item);
                    if (fechaDeItem == fechaExistente)
                    {
                        int cantidadExistente = ExtraerCantidadDeItem(item);
                        int nuevaCantidad = cantidadExistente + cantidadAdicional;
                        checkedListBoxPedidosAplazados.Items[i] = $"{nombreReceta} - Cantidad necesaria: {nuevaCantidad} - Llegada: {fechaExistente.ToString("g")}";
                        fechaEncontrada = true;
                        break;
                    }
                }
            }

            if (!fechaEncontrada)
            {
                checkedListBoxPedidosAplazados.Items.Add($"{nombreReceta} - Cantidad necesaria: {cantidadAdicional} - Llegada: {fechaExistente.ToString("g")}");
            }

        }


    }
}
