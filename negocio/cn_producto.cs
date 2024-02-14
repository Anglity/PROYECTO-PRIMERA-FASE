using datos;
using entidad;
using System;
using System.Collections.Generic;
using System.Linq;

namespace negocio
{
    public class cn_producto
    {
        private cd_producto objcd_producto = new cd_producto();

        public List<producto> listar()
        {
            return objcd_producto.listar();
        }
        public int Registrar(producto obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.Codigo == string.Empty)
            {
                Mensaje = "Es necesario el codigo del producto\n";
            }

            if (obj.Nombre == string.Empty)
            {
                Mensaje = "Es necesario el nombre del producto\n";
            }

            if (obj.Descripcion == string.Empty)
            {
                Mensaje = "Es necesario la clave del producto\n";
            }

            if (Mensaje != string.Empty)
            {
                return 0;
            }

            else
            {
                return objcd_producto.Registrar(obj, out Mensaje);
            }
        }

        public bool Editar(producto obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.Codigo == string.Empty)
            {
                Mensaje = "Es necesario el codigo del producto\n";
            }

            if (obj.Nombre == string.Empty)
            {
                Mensaje = "Es necesario el nombre del producto\n";
            }

            if (obj.Descripcion == string.Empty)
            {
                Mensaje = "Es necesario la clave del producto\n";
            }

            if (Mensaje != string.Empty)
            {
                return false;
            }

            else
            {
                return objcd_producto.Editar(obj, out Mensaje);
            }
        }
        public bool Eliminar(producto obj, out string Mensaje)
        {
            return objcd_producto.Eliminar(obj, out Mensaje);
        }

        public bool VerificarYCrearProducto(string nombreProducto, out string mensaje)
        {

            mensaje = string.Empty;
            try
            {
                // Primero, verifica si el producto ya existe
                List<producto> listaProductos = listar();
                if (listaProductos.Any(p => p.Nombre.Equals(nombreProducto, StringComparison.OrdinalIgnoreCase)))
                {
                    // El producto ya existe
                    mensaje = "Producto ya existe.";
                    return true;
                }
                else
                {
                    string codigoAleatorio;
                    do
                    {
                        codigoAleatorio = GenerarCodigoAleatorio(8);
                    }
                    while (listaProductos.Any(p => p.Codigo == codigoAleatorio)); // Verifica si el código ya existe

                    producto nuevoProducto = new producto
                    {
                        Nombre = nombreProducto,
                        Codigo = codigoAleatorio, // Usa el código aleatorio generado
                        Descripcion = "Producto generado automáticamente",
                        ocategoria = new categoria { IdCategoria = 1 }, // Ejemplo: categoría por defecto
                        Estado = true,
                        UnidadMedida = "Unidades" // Ejemplo: unidad de medida
                    };

                    // Registrar el nuevo producto
                    int idGenerado = Registrar(nuevoProducto, out mensaje);
                    return idGenerado > 0;
                }
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
                return false;
            }
        }

        private string GenerarCodigoAleatorio(int longitud)
        {
            var caracteres = "p-01244";
            var random = new Random();
            var codigo = new char[longitud];

            for (int i = 0; i < longitud - 4; i++) // Reserva 4 caracteres para el componente de tiempo
            {
                codigo[i] = caracteres[random.Next(caracteres.Length)];
            }

            // Agrega un componente de tiempo (milisegundos) para aumentar la unicidad
            var timeComponent = DateTime.Now.Millisecond.ToString("D4"); // Asegura 4 dígitos
            for (int i = 0; i < 4; i++)
            {
                codigo[longitud - 4 + i] = timeComponent[i];
            }

            return new string(codigo);
        }
    }
}
