using entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace datos
{
    public class cd_produccionesAplazadas
    {
        // Método para insertar una nueva producción aplazada
        public void InsertarProduccionAplazada(ProduccionAplazada produccion)
        {
            try
            {
                using (SqlConnection oconexion = new SqlConnection(conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("sp_InsertarProduccionAplazada", oconexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@NombreReceta", produccion.NombreReceta);
                    cmd.Parameters.AddWithValue("@Cantidad", produccion.Cantidad);
                    // Utilizar el método ObtenerFechaHoraProgramada para acceder a la fecha y hora
                    cmd.Parameters.AddWithValue("@FechaHoraProgramada", produccion.ObtenerFechaHoraProgramada());

                    oconexion.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                Console.WriteLine("Error al insertar producción aplazada: " + ex.Message);
            }
        }

        // Método para actualizar una producción aplazada
        public void ActualizarProduccionAplazada(ProduccionAplazada produccion)
        {
            try
            {
                using (SqlConnection oconexion = new SqlConnection(conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("sp_ActualizarProduccionAplazada", oconexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Id", produccion.Id);
                    cmd.Parameters.AddWithValue("@Cantidad", produccion.Cantidad);
                    // Utilizar el método ObtenerFechaHoraProgramada para acceder a la fecha y hora
                    cmd.Parameters.AddWithValue("@FechaHoraProgramada", produccion.ObtenerFechaHoraProgramada());
                    cmd.Parameters.AddWithValue("@FueManejada", produccion.FueManejada);

                    oconexion.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                Console.WriteLine("Error al actualizar producción aplazada: " + ex.Message);
            }
        }

        // Método para obtener la lista de producciones aplazadas
        public List<ProduccionAplazada> ListarProduccionesAplazadas()
        {
            List<ProduccionAplazada> lista = new List<ProduccionAplazada>();

            try
            {
                using (SqlConnection oconexion = new SqlConnection(conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("sp_ListarProduccionesAplazadas", oconexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            // Utiliza el constructor para establecer los valores
                            ProduccionAplazada produccionAplazada = new ProduccionAplazada(
                                dr["NombreReceta"].ToString(),
                                Convert.ToInt32(dr["Cantidad"]),
                                Convert.ToDateTime(dr["FechaHoraProgramada"]),
                                Convert.ToBoolean(dr["FueManejada"])
                            )
                            {
                                Id = Convert.ToInt32(dr["Id"]) // Id se establece por separado ya que es autoincremental
                            };

                            lista.Add(produccionAplazada);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                Console.WriteLine("Error al listar producciones aplazadas: " + ex.Message);
                lista = new List<ProduccionAplazada>();
            }

            return lista;
        }

        public void InsertarActualizarProduccionAplazada(ProduccionAplazada produccion)
        {
            if (!produccion.FueManejada) // Si FueManejada es false, se asume que es una nueva producción
            {
                InsertarProduccionAplazada(produccion);
            }
            else // Si FueManejada es true, se actualiza la producción existente
            {
                ActualizarProduccionAplazada(produccion);
            }
        }

        // ... otros métodos que puedas necesitar ...
    }
}
