using entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace datos
{
    public class cd_proveedor
    {
        public List<proveedor> listar()
        {
            List<proveedor> lista = new List<proveedor>();

            using (SqlConnection oconexion = new SqlConnection(conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT p.IdProveedor, p.Documento, p.RazonSocial, p.Correo, p.Telefono, p.Estado, p.DiasEntrega, d.IdDireccion, d.Pais, d.Provincia, d.Ciudad, d.Sector, d.Calle, d.CodigoPostal, d.Pais + ', ' + d.Provincia + ', ' + d.Ciudad + ', ' + d.Sector + ', ' + d.Calle + ', ' + d.CodigoPostal AS Direccion FROM PROVEEDOR p INNER JOIN DIRECCION d ON d.IdDireccion = p.IdDireccion");

                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new proveedor()
                            {
                                IdProveedor = Convert.ToInt32(dr["IdProveedor"]),
                                Documento = dr["Documento"].ToString(),
                                RazonSocial = dr["RazonSocial"].ToString(),
                                Correo = dr["Correo"].ToString(),
                                Telefono = dr["Telefono"].ToString(),
                                Estado = Convert.ToBoolean(dr["Estado"]),
                                DiasEntrega = Convert.ToInt32(dr["DiasEntrega"]), // Agregado
                                IdDireccion = Convert.ToInt32(dr["IdDireccion"]),
                                Pais = dr["Pais"].ToString(),
                                Provincia = dr["Provincia"].ToString(),
                                Ciudad = dr["Ciudad"].ToString(),
                                Sector = dr["Sector"].ToString(),
                                Calle = dr["Calle"].ToString(),
                                CodigoPostal = dr["CodigoPostal"].ToString(),
                                Direccion = dr["Direccion"].ToString(),
                            });
                        }
                    }
                }
                catch (Exception)
                {
                    lista = new List<proveedor>();
                }
            }
            return lista;
        }





        public int Registrar(proveedor obj, out string Mensaje)
        {
            int idProveedorgenerado = 0;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("sp_RegistrarProveedor", oconexion);
                    cmd.Parameters.AddWithValue("Documento", obj.Documento);
                    cmd.Parameters.AddWithValue("RazonSocial", obj.RazonSocial);
                    cmd.Parameters.AddWithValue("Correo", obj.Correo);
                    cmd.Parameters.AddWithValue("Telefono", obj.Telefono);
                    cmd.Parameters.AddWithValue("Estado", obj.Estado);
                    cmd.Parameters.AddWithValue("DiasEntrega", obj.DiasEntrega); // Agregado
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

                    idProveedorgenerado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                idProveedorgenerado = 0;
                Mensaje = ex.Message;
            }
            return idProveedorgenerado;
        }




        public bool Editar(proveedor obj, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("sp_ModificarProveedor", oconexion);
                    cmd.Parameters.AddWithValue("IdProveedor", obj.IdProveedor);
                    cmd.Parameters.AddWithValue("Documento", obj.Documento);
                    cmd.Parameters.AddWithValue("RazonSocial", obj.RazonSocial);
                    cmd.Parameters.AddWithValue("Correo", obj.Correo);
                    cmd.Parameters.AddWithValue("Telefono", obj.Telefono);
                    cmd.Parameters.AddWithValue("Estado", obj.Estado);
                    cmd.Parameters.AddWithValue("DiasEntrega", obj.DiasEntrega); // Agregado
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



        public bool Eliminar(proveedor obj, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;


            try
            {

                using (SqlConnection oconexion = new SqlConnection(conexion.cadena))
                {


                    SqlCommand cmd = new SqlCommand("sp_EliminarProveedor", oconexion);
                    cmd.Parameters.AddWithValue("IdProveedor", obj.IdProveedor);
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
    }
}
