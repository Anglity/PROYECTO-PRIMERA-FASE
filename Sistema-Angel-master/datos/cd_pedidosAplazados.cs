using entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace datos
{
    public class cd_pedidosAplazados
    {
        // Método para insertar un nuevo pedido aplazado
        public void InsertarPedidoAplazado(PedidoAplazado pedido)
        {
            try
            {
                using (SqlConnection oconexion = new SqlConnection(conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("spAgregarPedidoAplazado", oconexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@NombreReceta", pedido.NombreReceta);
                    cmd.Parameters.AddWithValue("@Cantidad", pedido.Cantidad);
                    cmd.Parameters.AddWithValue("@FechaHoraProgramada", pedido.FechaHoraProgramada);
                    cmd.Parameters.AddWithValue("@FueManejada", pedido.FueManejada);

                    oconexion.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                Console.WriteLine("Error al insertar pedido aplazado: " + ex.Message);
            }
        }

        // Método para actualizar un pedido aplazado
        public void ActualizarPedidoAplazado(PedidoAplazado pedido)
        {
            try
            {
                using (SqlConnection oconexion = new SqlConnection(conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("spActualizarPedidoAplazado", oconexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IdPedidoAplazado", pedido.Id);
                    cmd.Parameters.AddWithValue("@NombreReceta", pedido.NombreReceta);
                    cmd.Parameters.AddWithValue("@Cantidad", pedido.Cantidad);
                    cmd.Parameters.AddWithValue("@FechaHoraProgramada", pedido.FechaHoraProgramada);
                    cmd.Parameters.AddWithValue("@FueManejada", pedido.FueManejada);

                    oconexion.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                Console.WriteLine("Error al actualizar pedido aplazado: " + ex.Message);
            }
        }

        // Método para obtener la lista de pedidos aplazados
        public List<PedidoAplazado> ListarPedidosAplazados()
        {
            List<PedidoAplazado> lista = new List<PedidoAplazado>();

            try
            {
                using (SqlConnection oconexion = new SqlConnection(conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("spListarPedidosAplazados", oconexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            bool fueManejada = Convert.ToBoolean(dr["FueManejada"]);
                            if (!fueManejada) // Agregar solo si FueManejada es false
                            {
                                lista.Add(new PedidoAplazado()
                                {
                                    Id = Convert.ToInt32(dr["IdPedidoAplazado"]),
                                    NombreReceta = dr["NombreReceta"].ToString(),
                                    Cantidad = Convert.ToInt32(dr["Cantidad"]),
                                    FechaHoraProgramada = Convert.ToDateTime(dr["FechaHoraProgramada"]),
                                    FueManejada = fueManejada
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                Console.WriteLine("Error al listar pedidos aplazados: " + ex.Message);
                lista = new List<PedidoAplazado>();
            }

            return lista;
        }

        public PedidoAplazado ObtenerPedido(string nombreReceta, int cantidad)
        {
            PedidoAplazado pedidoEncontrado = null;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(conexion.cadena))
                {
                    oconexion.Open();
                    string consulta = "SELECT * FROM PedidosAplazados WHERE NombreReceta = @NombreReceta AND Cantidad = @Cantidad AND FueManejada = 0";
                    SqlCommand comando = new SqlCommand(consulta, oconexion);
                    comando.Parameters.AddWithValue("@NombreReceta", nombreReceta);
                    comando.Parameters.AddWithValue("@Cantidad", cantidad);

                    using (SqlDataReader lector = comando.ExecuteReader())
                    {
                        if (lector.Read())
                        {
                            pedidoEncontrado = new PedidoAplazado()
                            {
                                Id = Convert.ToInt32(lector["IdPedidoAplazado"]),
                                NombreReceta = lector["NombreReceta"].ToString(),
                                Cantidad = Convert.ToInt32(lector["Cantidad"]),
                                FechaHoraProgramada = Convert.ToDateTime(lector["FechaHoraProgramada"]),
                                FueManejada = Convert.ToBoolean(lector["FueManejada"])
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener pedido: " + ex.Message);
            }

            return pedidoEncontrado;
        }

        public List<PedidoAplazado> ObtenerPedidosPorNombreReceta(string nombreReceta)
        {
            List<PedidoAplazado> pedidosEncontrados = new List<PedidoAplazado>();

            try
            {
                using (SqlConnection oconexion = new SqlConnection(conexion.cadena))
                {
                    oconexion.Open();
                    string consulta = "SELECT * FROM PedidosAplazados WHERE NombreReceta = @NombreReceta AND FueManejada = 0";
                    SqlCommand comando = new SqlCommand(consulta, oconexion);
                    comando.Parameters.AddWithValue("@NombreReceta", nombreReceta);

                    using (SqlDataReader lector = comando.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            PedidoAplazado pedido = new PedidoAplazado()
                            {
                                Id = Convert.ToInt32(lector["IdPedidoAplazado"]),
                                NombreReceta = lector["NombreReceta"].ToString(),
                                Cantidad = Convert.ToInt32(lector["Cantidad"]),
                                FechaHoraProgramada = Convert.ToDateTime(lector["FechaHoraProgramada"]),
                                FueManejada = Convert.ToBoolean(lector["FueManejada"])
                            };
                            pedidosEncontrados.Add(pedido);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener pedidos: " + ex.Message);
            }

            return pedidosEncontrados;
        }

    }
}
