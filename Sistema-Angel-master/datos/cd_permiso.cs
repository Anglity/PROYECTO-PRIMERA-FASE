using entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace datos
{
    public class cd_permiso
    {



        public List<permiso> listar(int idusuario)
        {
            List<permiso> lista = new List<permiso>();

            using (SqlConnection oconexion = new SqlConnection(conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select p.IdRol,p.NombreMenu from PERMISO p");
                    query.AppendLine("inner join ROL r on r.IdRol = p.IdRol");
                    query.AppendLine("inner join USUARIO u on u.IdRol = r.IdRol");
                    query.AppendLine("where u.IdUsuario = @idusuario");

                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.Parameters.AddWithValue("@idusuario", idusuario);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new permiso()
                            {

                                oRol = new rol() { IdRol = Convert.ToInt32(dr["IdRol"]) },
                                NombreMenu = dr["NombreMenu"].ToString(),

                            });
                        }
                    }

                }
                catch (Exception)
                {
                    lista = new List<permiso>();

                }
            }

            return lista;
        }

    }
}