using datos;
using entidad;
using System;
using System.Collections.Generic;

namespace negocio
{
    public class cn_pedidoAplazado
    {
        private cd_pedidosAplazados cdPedidosAplazados = new cd_pedidosAplazados();

        // Método para insertar un nuevo pedido aplazado
        public void InsertarPedidoAplazado(PedidoAplazado pedido)
        {
            try
            {
                cdPedidosAplazados.InsertarPedidoAplazado(pedido);
            }
            catch (Exception ex)
            {
                // Aquí puedes manejar la excepción o re-lanzarla
                throw new Exception("Error al insertar pedido aplazado: " + ex.Message);
            }
        }

        // Método para actualizar un pedido aplazado
        public void ActualizarPedidoAplazado(PedidoAplazado pedido)
        {
            try
            {
                cdPedidosAplazados.ActualizarPedidoAplazado(pedido);
            }
            catch (Exception ex)
            {
                // Aquí puedes manejar la excepción o re-lanzarla
                throw new Exception("Error al actualizar pedido aplazado: " + ex.Message);
            }
        }

        // Método para listar todos los pedidos aplazados
        public List<PedidoAplazado> ListarPedidosAplazados()
        {
            try
            {
                return cdPedidosAplazados.ListarPedidosAplazados();
            }
            catch (Exception ex)
            {
                // Aquí puedes manejar la excepción o re-lanzarla
                throw new Exception("Error al listar pedidos aplazados: " + ex.Message);
            }
        }

        // Aquí puedes agregar otros métodos de negocio relacionados con los pedidos si es necesario
    }
}
