using entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace datos
{
    public class cd_empleado
    {
        public List<empleado> listar()
        {
            List<empleado> lista = new List<empleado>();

            using (SqlConnection oconexion = new SqlConnection(conexion.cadena))
            {

                try
                {

                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT e.Id, e.Documento, e.Nombre, e.Correo, e.Telefono,e.Cargo, e.Salario, d.IdDireccion, d.Pais,d.Provincia,d.Ciudad, d.Sector, d.Calle, d.CodigoPostal, d.Pais+ ', '+ d.Provincia+ ', ' + d.Ciudad + ', ' + d.Sector + ', ' + d.Calle + ', ' + d.CodigoPostal AS Direccion, e.Estado FROM Empleados e INNER JOIN DIRECCION d ON d.IdDireccion = e.IdDireccion;");
                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new empleado()
                            {
                                IdEmpleado = Convert.ToInt32(dr["Id"]),
                                Documento = dr["Documento"].ToString(),
                                Nombre = dr["Nombre"].ToString(),
                                Correo = dr["Correo"].ToString(),
                                Telefono = dr["Telefono"].ToString(),
                                Cargo = dr["Cargo"].ToString(),
                                Salario = Convert.ToInt32(dr["Salario"]),
                                Estado = Convert.ToBoolean(dr["Estado"]),
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

                    lista = new List<empleado>();
                }
            }
            return lista;
        }




        public int Registrar(empleado obj, out string Mensaje)
        {
            int idClientegenerado = 0;
            Mensaje = string.Empty;
            try
            {

                using (SqlConnection oconexion = new SqlConnection(conexion.cadena))
                {

                    SqlCommand cmd = new SqlCommand("sp_RegistrarEmpleado", oconexion);
                    cmd.Parameters.AddWithValue("Documento", obj.Documento);
                    cmd.Parameters.AddWithValue("Nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("Correo", obj.Correo);
                    cmd.Parameters.AddWithValue("Telefono", obj.Telefono);
                    cmd.Parameters.AddWithValue("Cargo", obj.Cargo);
                    cmd.Parameters.AddWithValue("Salario", obj.Salario);
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



        public bool Editar(empleado obj, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;


            try
            {

                using (SqlConnection oconexion = new SqlConnection(conexion.cadena))
                {

                    SqlCommand cmd = new SqlCommand("sp_ModificarEmpleado", oconexion);
                    cmd.Parameters.AddWithValue("IdEmpleado", obj.IdEmpleado);
                    cmd.Parameters.AddWithValue("Documento", obj.Documento);
                    cmd.Parameters.AddWithValue("Nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("Correo", obj.Correo);
                    cmd.Parameters.AddWithValue("Telefono", obj.Telefono);
                    cmd.Parameters.AddWithValue("Cargo", obj.Cargo);
                    cmd.Parameters.AddWithValue("Salario", obj.Salario);
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


        public Boolean Eliminar(empleado obj, out string Mensaje)
        {
            bool Respuesta = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("sp_EliminarEmpleado", oconexion);
                    cmd.Parameters.AddWithValue("IdEmpleado", obj.IdEmpleado);
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
