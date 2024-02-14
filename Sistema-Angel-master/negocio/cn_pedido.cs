using datos;
using entidad;
using System;
using System.Collections.Generic;

namespace negocio
{
    public class cn_pedido
    {
        private cd_produccionesAplazadas cdProduccionesAplazadas = new cd_produccionesAplazadas();

        // Método para insertar una nueva producción aplazada
        public void InsertarProduccionAplazada(ProduccionAplazada produccion)
        {
            try
            {
                cdProduccionesAplazadas.InsertarProduccionAplazada(produccion);
            }
            catch (Exception ex)
            {
                // Aquí puedes manejar la excepción o re-lanzarla
                throw new Exception("Error al insertar producción aplazada: " + ex.Message);
            }
        }

        // Método para actualizar una producción aplazada
        public void ActualizarProduccionAplazada(ProduccionAplazada produccion)
        {
            try
            {
                cdProduccionesAplazadas.ActualizarProduccionAplazada(produccion);
            }
            catch (Exception ex)
            {
                // Aquí puedes manejar la excepción o re-lanzarla
                throw new Exception("Error al actualizar producción aplazada: " + ex.Message);
            }
        }

        // Método para listar todas las producciones aplazadas
        public List<ProduccionAplazada> ListarProduccionesAplazadas()
        {
            try
            {
                return cdProduccionesAplazadas.ListarProduccionesAplazadas();
            }
            catch (Exception ex)
            {
                // Aquí puedes manejar la excepción o re-lanzarla
                throw new Exception("Error al listar producciones aplazadas: " + ex.Message);
            }
        }

        // Aquí puedes agregar otros métodos de negocio relacionados con los pedidos si es necesario
    }
}
