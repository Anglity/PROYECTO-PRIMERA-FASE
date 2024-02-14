using entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace datos
{
    public class cd_producto
    {

        public List<producto> listar()
        {
            List<producto> lista = new List<producto>();

            using (SqlConnection oconexion = new SqlConnection(conexion.cadena))
            {
                try
                {

                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select IdProducto, Codigo, Nombre, p.Descripcion,c.IdCategoria,c.Descripcion[DescripcionCategoria],Stock,PrecioCompra,PrecioVenta,p.Estado, p.UnidadMedida  from PRODUCTO p");
                    query.AppendLine("inner join CATEGORIA c on c.IdCategoria = p.IdCategoria");

                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new producto()
                            {

                                IdProducto = Convert.ToInt32(dr["IdProducto"]),
                                Codigo = dr["Codigo"].ToString(),
                                Nombre = dr["Nombre"].ToString(),
                                Descripcion = dr["Descripcion"].ToString(),
                                ocategoria = new categoria() { IdCategoria = Convert.ToInt32(dr["IdCategoria"]), Descripcion = dr["DescripcionCategoria"].ToString() },
                                Stock = Convert.ToInt32(dr["Stock"].ToString()),
                                PrecioCompra = Convert.ToDecimal(dr["PrecioCompra"].ToString()),
                                PrecioVenta = Convert.ToDecimal(dr["PrecioVenta"].ToString()),
                                Estado = Convert.ToBoolean(dr["Estado"]),
                                UnidadMedida = dr["UnidadMedida"].ToString(),
                            });
                        }
                    }
                }
                catch (Exception)
                {
                    lista = new List<producto>();

                }
            }

            return lista;
        }


        public int Registrar(producto obj, out string Mensaje)
        {
            int idProductogenerado = 0;
            Mensaje = string.Empty;


            try
            {

                using (SqlConnection oconexion = new SqlConnection(conexion.cadena))
                {

                    SqlCommand cmd = new SqlCommand("sp_RegistrarProducto", oconexion);
                    cmd.Parameters.AddWithValue("Codigo", obj.Codigo);
                    cmd.Parameters.AddWithValue("Nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("Descripcion", obj.Descripcion);
                    cmd.Parameters.AddWithValue("IdCategoria", obj.ocategoria.IdCategoria);
                    cmd.Parameters.AddWithValue("Estado", obj.Estado);
                    cmd.Parameters.AddWithValue("UnidadMedida", obj.UnidadMedida);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    cmd.ExecuteNonQuery();

                    idProductogenerado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();

                }

            }
            catch (Exception ex)
            {
                idProductogenerado = 0;
                Mensaje = ex.Message;
            }



            return idProductogenerado;
        }


        //--------------------------------------------ESPACIO-----------------------------------------------------


        public Boolean Editar(producto obj, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;


            try
            {

                using (SqlConnection oconexion = new SqlConnection(conexion.cadena))
                {

                    SqlCommand cmd = new SqlCommand("sp_ModificarProducto", oconexion);
                    cmd.Parameters.AddWithValue("IdProducto", obj.IdProducto);
                    cmd.Parameters.AddWithValue("Codigo", obj.Codigo);
                    cmd.Parameters.AddWithValue("Nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("Descripcion", obj.Descripcion);
                    cmd.Parameters.AddWithValue("IdCategoria", obj.ocategoria.IdCategoria);
                    cmd.Parameters.AddWithValue("Estado", obj.Estado);
                    cmd.Parameters.AddWithValue("UnidadMedida", obj.UnidadMedida);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();

                }

            }
            catch (Exception ex)
            {
                respuesta = false;
                Mensaje = ex.Message;
            }



            return respuesta;
        }


        //--------------------------------------------ESPACIO-----------------------------------------------------



        public Boolean Eliminar(producto obj, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;

            try
            {

                using (SqlConnection oconexion = new SqlConnection(conexion.cadena))
                {

                    SqlCommand cmd = new SqlCommand("SP_EliminarProducto", oconexion);
                    cmd.Parameters.AddWithValue("IdProducto", obj.IdProducto);
                    cmd.Parameters.Add("Respuesta", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToBoolean(cmd.Parameters["Respuesta"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();

                }

            }
            catch (Exception ex)
            {
                respuesta = false;
                Mensaje = ex.Message;
            }

            return respuesta;
        }


        public bool ExisteProducto(string nombreReceta)
        {
            bool existe = false;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("select count(1) from PRODUCTO where Nombre = @Nombre", oconexion);
                    cmd.Parameters.AddWithValue("@Nombre", nombreReceta);
                    cmd.CommandType = System.Data.CommandType.Text;

                    oconexion.Open();
                    existe = Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                }
            }
            catch (Exception ex)
            {
                // Manejo de la excepción
                // Puedes manejar la excepción según tus necesidades, por ejemplo, mostrando un mensaje
                Console.WriteLine("Error al verificar producto: " + ex.Message);
            }

            return existe;
        }

        public bool ActualizarCantidad(string nombreReceta, int cantidad)
        {
            bool actualizado = false;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("update PRODUCTO set Stock = Stock + @Cantidad where Nombre = @Nombre", oconexion);
                    cmd.Parameters.AddWithValue("@Cantidad", cantidad);
                    cmd.Parameters.AddWithValue("@Nombre", nombreReceta);
                    cmd.CommandType = System.Data.CommandType.Text;

                    oconexion.Open();
                    int filasAfectadas = cmd.ExecuteNonQuery();
                    actualizado = filasAfectadas > 0;
                }
            }
            catch (Exception ex)
            {
                // Manejo de la excepción
                Console.WriteLine("Error al actualizar cantidad del producto: " + ex.Message);
            }

            return actualizado;
        }

        public bool DisminuirStockProducto(string nombreProducto, int cantidad)
        {
            bool actualizado = false;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(conexion.cadena))
                {
                    // Verificamos primero si hay suficiente stock
                    SqlCommand cmdVerificar = new SqlCommand("SELECT Stock FROM PRODUCTO WHERE Nombre = @Nombre", oconexion);
                    cmdVerificar.Parameters.AddWithValue("@Nombre", nombreProducto);
                    oconexion.Open();
                    int stockActual = Convert.ToInt32(cmdVerificar.ExecuteScalar());

                    if (stockActual >= cantidad)
                    {
                        // Si hay suficiente stock, procedemos a actualizar
                        SqlCommand cmdActualizar = new SqlCommand("UPDATE PRODUCTO SET Stock = Stock - @Cantidad WHERE Nombre = @Nombre AND Stock >= @Cantidad", oconexion);
                        cmdActualizar.Parameters.AddWithValue("@Cantidad", cantidad);
                        cmdActualizar.Parameters.AddWithValue("@Nombre", nombreProducto);

                        int filasAfectadas = cmdActualizar.ExecuteNonQuery();
                        actualizado = filasAfectadas > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de la excepción
                Console.WriteLine("Error al disminuir stock del producto: " + ex.Message);
            }

            return actualizado;
        }

        public bool VerificarStockProducto(string nombreProducto, int cantidadRequerida)
        {
            bool tieneSuficienteStock = false;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("SELECT Stock FROM PRODUCTO WHERE Nombre = @Nombre", oconexion);
                    cmd.Parameters.AddWithValue("@Nombre", nombreProducto);
                    oconexion.Open();
                    int stockActual = Convert.ToInt32(cmd.ExecuteScalar());

                    tieneSuficienteStock = stockActual >= cantidadRequerida;
                }
            }
            catch (Exception ex)
            {
                // Manejo de la excepción
                Console.WriteLine("Error al verificar stock del producto: " + ex.Message);
                tieneSuficienteStock = false;
            }

            return tieneSuficienteStock;
        }

        public int ObtenerStockActual(string nombreProducto)
        {
            int stockActual = 0;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("SELECT Stock FROM PRODUCTO WHERE Nombre = @Nombre", oconexion);
                    cmd.Parameters.AddWithValue("@Nombre", nombreProducto);
                    oconexion.Open();
                    stockActual = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener stock actual del producto: " + ex.Message);
                stockActual = -1; // O manejar la excepción de una manera que tenga sentido para tu aplicación
            }

            return stockActual;
        }
    }
}
