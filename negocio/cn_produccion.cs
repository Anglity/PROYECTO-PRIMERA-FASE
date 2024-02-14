using entidad;
using System;

namespace negocio
{
    public class cn_produccion
    {
        private datos.cd_produccion cdProduccion = new datos.cd_produccion();

        public int ObtenerCorrelativo()
        {
            try
            {
                return cdProduccion.ObtenerCorrelativo();
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public bool Registrar(produccion obj, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;
            try
            {
                respuesta = cdProduccion.Registrar(obj, out mensaje);
                if (respuesta)
                {
                    mensaje = "Registro exitoso";
                }
                else
                {
                    mensaje = "Error en el registro";
                }
            }
            catch (Exception ex)
            {
                respuesta = false;
                mensaje = ex.Message;
            }
            return respuesta;
        }

        // Aquí podrías tener más métodos para recuperar detalles de producciones específicas, actualizar registros, etc.
        public int ObtenerStock(string nombreProducto)
        {
            try
            {
                return cdProduccion.ObtenerStock(nombreProducto);
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public int ObtenerIdProducto(string nombreProducto)
        {
            try
            {
                return cdProduccion.ObtenerIdProducto(nombreProducto);
            }
            catch (Exception)
            {
                return 0;
            }
        }

    }
}