using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace datos
{
    public class cd_receta
    {
        public List<receta> Listar()
        {
            List<receta> lista = new List<receta>();

            using (SqlConnection oconexion = new SqlConnection(conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    // Asegúrate de incluir la columna CantidadProduccion en tu consulta SQL
                    query.AppendLine("SELECT Id, NombreReceta, Productos, Preparacion, Tiempo, Imagen, CantidadProduccion FROM Recetas");

                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new receta()
                            {
                                Id = Convert.ToInt32(dr["Id"]),
                                NombreReceta = dr["NombreReceta"].ToString(),
                                Productos = dr["Productos"].ToString(),
                                Preparacion = dr["Preparacion"].ToString(),
                                Tiempo = dr["Tiempo"].ToString(),
                                Imagen = dr["Imagen"] as byte[], // Asumiendo que el campo Imagen es de tipo VARBINARY(MAX)
                                CantidadProduccion = Convert.ToInt32(dr["CantidadProduccion"]) // Añade esta línea
                            });
                        }
                    }
                }
                catch (Exception)
                {
                    // Manejo de excepciones y registro del error
                    // Considera registrar el error en un log
                    lista = new List<receta>();
                }
            }

            return lista;
        }


        // Método para registrar una nueva receta
        public int Registrar(receta obj, out string Mensaje)
        {
            int idRecetaGenerado = 0;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("GuardarReceta", oconexion);
                    cmd.Parameters.AddWithValue("NombreReceta", obj.NombreReceta);
                    cmd.Parameters.AddWithValue("Productos", obj.Productos);
                    cmd.Parameters.AddWithValue("Preparacion", obj.Preparacion);
                    cmd.Parameters.AddWithValue("Tiempo", obj.Tiempo);
                    cmd.Parameters.AddWithValue("Imagen", obj.Imagen);

                    // Añade el nuevo parámetro para la cantidad de producción
                    cmd.Parameters.AddWithValue("CantidadProduccion", obj.CantidadProduccion);

                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    idRecetaGenerado = Convert.ToInt32(cmd.ExecuteScalar());
                    Mensaje = "Receta registrada correctamente.";
                }
            }
            catch (Exception ex)
            {
                idRecetaGenerado = 0;
                Mensaje = ex.Message;
            }

            return idRecetaGenerado;
        }

        public bool EliminarPorNombre(string nombreReceta, out string mensaje)
        {
            bool resultado = false;
            mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("EliminarRecetaPorNombre", oconexion);
                    cmd.Parameters.AddWithValue("@NombreReceta", nombreReceta);
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();
                    resultado = cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
                resultado = false;
            }
            return resultado;
        }

        public List<ProductoReceta> ObtenerProductosReceta(string nombreReceta)
        {
            List<ProductoReceta> productos = new List<ProductoReceta>();

            using (SqlConnection oconexion = new SqlConnection(conexion.cadena))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("SELECT Productos FROM Recetas WHERE NombreReceta = @NombreReceta", oconexion);
                    cmd.Parameters.AddWithValue("@NombreReceta", nombreReceta);
                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            string productosString = dr["Productos"].ToString();
                            string[] productosArray = productosString.Split(',');
                            foreach (string producto in productosArray)
                            {
                                string[] detalles = producto.Split(':');
                                if (detalles.Length == 2)
                                {
                                    productos.Add(new ProductoReceta
                                    {
                                        Nombre = detalles[0].Trim(),
                                        Cantidad = int.Parse(detalles[1].Trim()) // Asegúrate de manejar posibles excepciones aquí
                                    });
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Manejo de la excepción
                    Console.WriteLine("Error al obtener productos de receta: " + ex.Message);
                }
            }

            return productos;
        }




        // ... el resto de tu clase ...
    }

    public class ProductoReceta
    {
        public string Nombre { get; set; }
        public int Cantidad { get; set; }
    }



}

