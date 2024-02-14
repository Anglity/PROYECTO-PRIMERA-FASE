using entidad;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace datos
{
    public class cd_produccion
    {
        public int ObtenerCorrelativo()
        {
            int idcorrelativo = 0;

            using (SqlConnection oconexion = new SqlConnection(conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select count(*) + 1 from ProduccionQueso");
                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    idcorrelativo = Convert.ToInt32(cmd.ExecuteScalar());
                }
                catch (Exception)
                {
                    idcorrelativo = 0;
                }
            }
            return idcorrelativo;
        }

        public bool Registrar(produccion obj, out string Mensaje)
        {
            bool Respuesta = false;
            Mensaje = string.Empty;

            using (SqlConnection oconexion = new SqlConnection(conexion.cadena))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_RegistrarProduccion", oconexion);

                    cmd.Parameters.AddWithValue("FechaProduccion", obj.FechaProduccion);
                    cmd.Parameters.AddWithValue("CantidadCheddar", obj.CantidadCheddar);
                    cmd.Parameters.AddWithValue("CantidadDanes", obj.CantidadDanes);
                    cmd.Parameters.AddWithValue("UnidadMedidaGenerica", obj.UnidadMedidaGenerica);
                    cmd.Parameters.AddWithValue("CantidadTotal", obj.CantidadTotal);

                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    cmd.ExecuteNonQuery();

                    Respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
                catch (Exception ex)
                {
                    Respuesta = false;
                    Mensaje = ex.Message;
                }
            }
            return Respuesta;
        }

        // Aquí podrías tener más métodos para recuperar detalles de producciones específicas, actualizar registros, etc.
        public int ObtenerStock(string nombreProducto)
        {
            int stock = 0;

            using (SqlConnection oconexion = new SqlConnection(conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT Stock FROM PRODUCTO WHERE Nombre = @producto");
                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.Parameters.AddWithValue("@producto", nombreProducto);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    object result = cmd.ExecuteScalar();
                    if (result != null && int.TryParse(result.ToString(), out stock))
                    {
                        return stock;
                    }
                }
                catch (Exception)
                {
                    stock = 0;
                }
            }
            return stock;
        }

        public int ObtenerIdProducto(string nombreProducto)
        {
            int idProducto = 0;

            using (SqlConnection oconexion = new SqlConnection(conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT IdProducto FROM PRODUCTO WHERE Nombre = @nombreProducto");
                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.Parameters.AddWithValue("@nombreProducto", nombreProducto);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    idProducto = Convert.ToInt32(cmd.ExecuteScalar());
                }
                catch (Exception)
                {
                    idProducto = 0;
                }
            }
            return idProducto;
        }
    }
}