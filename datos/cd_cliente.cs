using entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace datos
{
    public class cd_cliente
    {
        public List<cliente> listar()
        {
            List<cliente> lista = new List<cliente>();

            using (SqlConnection oconexion = new SqlConnection(conexion.cadena))
            {

                try
                {

                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT c.IdCliente, c.Documento, c.NombreCompleto, c.Correo, c.Telefono, d.IdDireccion, d.Pais,d.Provincia,d.Ciudad, d.Sector, d.Calle, d.CodigoPostal, d.Pais+ ', '+ d.Provincia+ ', ' + d.Ciudad + ', ' + d.Sector + ', ' + d.Calle + ', ' + d.CodigoPostal AS Direccion, c.Estado FROM CLIENTE c INNER JOIN DIRECCION d ON d.IdDireccion = c.IdDireccion;");
                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new cliente()
                            {
                                IdCliente = Convert.ToInt32(dr["IdCliente"]),
                                Documento = dr["Documento"].ToString(),
                                NombreCompleto = dr["NombreCompleto"].ToString(),
                                Correo = dr["Correo"].ToString(),
                                Telefono = dr["Telefono"].ToString(),
                                IdDireccion = Convert.ToInt32(dr["IdDireccion"]),
                                Pais = dr["Pais"].ToString(),
                                Provincia = dr["Provincia"].ToString(),
                                Ciudad = dr["Ciudad"].ToString(),
                                Sector = dr["Sector"].ToString(),
                                Calle = dr["Calle"].ToString(),
                                CodigoPostal = dr["CodigoPostal"].ToString(),
                                Direccion = dr["Direccion"].ToString(),
                                Estado = Convert.ToBoolean(dr["Estado"]),

                            });

                        }

                    }


                }
                catch (Exception)
                {

                    lista = new List<cliente>();
                }
            }
            return lista;
        }




        public int Registrar(cliente obj, out string Mensaje)
        {
            int idClientegenerado = 0;
            Mensaje = string.Empty;
            try
            {

                using (SqlConnection oconexion = new SqlConnection(conexion.cadena))
                {

                    SqlCommand cmd = new SqlCommand("sp_RegistrarCliente", oconexion);
                    cmd.Parameters.AddWithValue("Documento", obj.Documento);
                    cmd.Parameters.AddWithValue("NombreCompleto", obj.NombreCompleto);
                    cmd.Parameters.AddWithValue("Correo", obj.Correo);
                    cmd.Parameters.AddWithValue("Telefono", obj.Telefono);
                    cmd.Parameters.AddWithValue("Estado", obj.Estado);
                    cmd.Parameters.AddWithValue("Pais", obj.Pais);
                    cmd.Parameters.AddWithValue("Provincia", obj.Provincia);
                    cmd.Parameters.AddWithValue("Ciudad", obj.Ciudad);
                    cmd.Parameters.AddWithValue("Sector", obj.Sector);
                    cmd.Parameters.AddWithValue("Calle", obj.Calle);
                    cmd.Parameters.AddWithValue("CodigoPostal", obj.CodigoPostal);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    cmd.ExecuteNonQuery();

                    idClientegenerado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();

                }

            }
            catch (Exception ex)
            {
                idClientegenerado = 0;
                Mensaje = ex.Message;
            }
            return idClientegenerado;
        }



        public bool Editar(cliente obj, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;


            try
            {

                using (SqlConnection oconexion = new SqlConnection(conexion.cadena))
                {

                    SqlCommand cmd = new SqlCommand("sp_ModificarCliente", oconexion);
                    cmd.Parameters.AddWithValue("IdCliente", obj.IdCliente);
                    cmd.Parameters.AddWithValue("Documento", obj.Documento);
                    cmd.Parameters.AddWithValue("NombreCompleto", obj.NombreCompleto);
                    cmd.Parameters.AddWithValue("Correo", obj.Correo);
                    cmd.Parameters.AddWithValue("Telefono", obj.Telefono);
                    cmd.Parameters.AddWithValue("Estado", obj.Estado);
                    cmd.Parameters.AddWithValue("IdDireccion", obj.IdDireccion);
                    cmd.Parameters.AddWithValue("Pais", obj.Pais);
                    cmd.Parameters.AddWithValue("Provincia", obj.Provincia);
                    cmd.Parameters.AddWithValue("Ciudad", obj.Ciudad);
                    cmd.Parameters.AddWithValue("Sector", obj.Sector);
                    cmd.Parameters.AddWithValue("Calle", obj.Calle);
                    cmd.Parameters.AddWithValue("CodigoPostal", obj.CodigoPostal);
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


        public Boolean Eliminar(cliente obj, out string Mensaje)
        {
            bool Respuesta = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("sp_EliminarCliente", oconexion);
                    cmd.Parameters.AddWithValue("IdCliente", obj.IdCliente);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    cmd.CommandType = CommandType.StoredProcedure;
                    oconexion.Open();
                    cmd.ExecuteNonQuery();
                    Respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
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


    }
}
