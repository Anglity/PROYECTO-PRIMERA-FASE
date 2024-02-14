using entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace datos
{
    public class cd_usuario
    {
        public List<usuario> listar()
        {
            List<usuario> lista = new List<usuario>();

            using (SqlConnection oconexion = new SqlConnection(conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select u.IdUsuario, u.Documento, u.NombreCompleto, u.Correo, u.Clave, u.Estado, u.PrimerInicioSesion, r.IdRol, r.Descripcion from usuario u"); // Agregado u.PrimerInicioSesion
                    query.AppendLine("inner join rol r on r.IdRol = u.IdRol");

                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new usuario()
                            {
                                IdUsuario = Convert.ToInt32(dr["IdUsuario"]),
                                Documento = dr["Documento"].ToString(),
                                NombreCompleto = dr["NombreCompleto"].ToString(),
                                Correo = dr["Correo"].ToString(),
                                Clave = dr["Clave"].ToString(),
                                Estado = Convert.ToBoolean(dr["Estado"]),
                                PrimerInicioSesion = Convert.ToBoolean(dr["PrimerInicioSesion"]), // Agregado
                                oRol = new rol() { IdRol = Convert.ToInt32(dr["IdRol"]), Descripcion = dr["Descripcion"].ToString() }
                            });
                        }
                    }
                }
                catch (Exception)
                {
                    lista = new List<usuario>();
                }
            }

            return lista;
        }



        public int Registrar(usuario obj, out string Mensaje)
        {
            int Idusuariogenerado = 0;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("SP_REGISTRARUSUARIO", oconexion);
                    cmd.Parameters.AddWithValue("Documento", obj.Documento);
                    cmd.Parameters.AddWithValue("NombreCompleto", obj.NombreCompleto);
                    cmd.Parameters.AddWithValue("Correo", obj.Correo);
                    cmd.Parameters.AddWithValue("Clave", obj.Clave);
                    cmd.Parameters.AddWithValue("IdRol", obj.oRol.IdRol);
                    cmd.Parameters.AddWithValue("Estado", obj.Estado);
                    cmd.Parameters.Add("IdusuarioResultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    cmd.CommandType = CommandType.StoredProcedure;
                    oconexion.Open();
                    cmd.ExecuteNonQuery();
                    Idusuariogenerado = Convert.ToInt32(cmd.Parameters["IdusuarioResultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }


            }
            catch (Exception ex)
            {
                Idusuariogenerado = 0;
                Mensaje = ex.Message;
            }

            return Idusuariogenerado;
        }


        //--------------------------------------------ESPACIO-----------------------------------------------------


        public Boolean Editar(usuario obj, out string Mensaje)
        {
            bool Respuesta = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("SP_EDITARUSUARIO", oconexion);
                    cmd.Parameters.AddWithValue("IdUsuario", obj.IdUsuario);
                    cmd.Parameters.AddWithValue("Documento", obj.Documento);
                    cmd.Parameters.AddWithValue("NombreCompleto", obj.NombreCompleto);
                    cmd.Parameters.AddWithValue("Correo", obj.Correo);
                    cmd.Parameters.AddWithValue("Clave", obj.Clave);
                    cmd.Parameters.AddWithValue("IdRol", obj.oRol.IdRol);
                    cmd.Parameters.AddWithValue("Estado", obj.Estado);
                    cmd.Parameters.Add("Respuesta", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    cmd.CommandType = CommandType.StoredProcedure;
                    oconexion.Open();
                    cmd.ExecuteNonQuery();
                    Respuesta = Convert.ToBoolean(cmd.Parameters["Respuesta"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }


            }
            catch (Exception ex)
            {
                Respuesta = false;
                Mensaje = ex.Message;
            }

            return Respuesta;
        }


        //--------------------------------------------ESPACIO-----------------------------------------------------



        public Boolean Eliminar(usuario obj, out string Mensaje)
        {
            bool Respuesta = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("SP_ELIMINARUSUARIO", oconexion);
                    cmd.Parameters.AddWithValue("IdUsuario", obj.IdUsuario);
                    cmd.Parameters.Add("Respuesta", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    cmd.CommandType = CommandType.StoredProcedure;
                    oconexion.Open();
                    cmd.ExecuteNonQuery();
                    Respuesta = Convert.ToBoolean(cmd.Parameters["Respuesta"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }


            }
            catch (Exception ex)
            {
                Respuesta = false;
                Mensaje = ex.Message;
            }

            return Respuesta;
        }

        public bool ActualizarClaveCambiada(int idUsuario, string nuevaContrasena, out string mensaje)
        {
            bool resultado = false;
            mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(conexion.cadena))
                {
                    oconexion.Open();
                    using (SqlCommand comando = new SqlCommand("UPDATE usuario SET ClaveCambiada = @ClaveCambiada, PrimerInicioSesion = 0 WHERE IdUsuario = @IdUsuario", oconexion))
                    {
                        comando.Parameters.AddWithValue("@ClaveCambiada", nuevaContrasena);
                        comando.Parameters.AddWithValue("@IdUsuario", idUsuario);

                        int filasAfectadas = comando.ExecuteNonQuery();
                        resultado = filasAfectadas > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                mensaje = "Error al actualizar la contraseña: " + ex.Message;
                resultado = false;
            }

            return resultado;
        }



    }
}
