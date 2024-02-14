using entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace datos
{
    public class cd_compra
    {
        public int ObtenerCorrelativo()
        {
            int idcorrelativo = 0;

            using (SqlConnection oconexion = new SqlConnection(conexion.cadena))
            {

                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select count(*) + 1 from COMPRA");
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


        public bool Registrar(compra obj, DataTable DetalleCompra, out string Mensaje)
        {
            bool Respuesta = false;
            Mensaje = string.Empty;


            using (SqlConnection oconexion = new SqlConnection(conexion.cadena))
            {

                try
                {
                    SqlCommand cmd = new SqlCommand("sp_RegistrarCompra", oconexion);
                    cmd.Parameters.AddWithValue("IdUsuario", obj.ousuario.IdUsuario);
                    cmd.Parameters.AddWithValue("IdProveedor", obj.oproveedor.IdProveedor);
                    cmd.Parameters.AddWithValue("TipoDocumento", obj.TipoDocumento);
                    cmd.Parameters.AddWithValue("NumeroDocumento", obj.NumeroDocumento);
                    cmd.Parameters.AddWithValue("MontoTotal", obj.MontoTotal);
                    cmd.Parameters.AddWithValue("DetalleCompra", DetalleCompra);
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

        public compra ObtenerCompra(string numero)
        {
            compra obj = new compra();
            using (SqlConnection oconexion = new SqlConnection(conexion.cadena))
            {

                try
                {

                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select c.IdCompra,");
                    query.AppendLine("u.NombreCompleto,");
                    query.AppendLine("pr.Documento,pr.RazonSocial,");
                    query.AppendLine("c.TipoDocumento,c.NumeroDocumento,c.MontoTotal,convert(char(10), c.FechaRegistro, 103)[FechaRegistro]");
                    query.AppendLine("from COMPRA c");
                    query.AppendLine("inner join USUARIO u on u.IdUsuario = c.IdUsuario");
                    query.AppendLine("inner join PROVEEDOR pr on pr.IdProveedor = c.IdProveedor");
                    query.AppendLine("where c.NumeroDocumento = @numero");


                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.Parameters.AddWithValue("@numero", numero);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            obj = new compra()
                            {
                                IdCompra = Convert.ToInt32(dr["IdCompra"]),
                                ousuario = new usuario() { NombreCompleto = dr["NombreCompleto"].ToString() },
                                oproveedor = new proveedor() { Documento = dr["Documento"].ToString(), RazonSocial = dr["RazonSocial"].ToString() },
                                TipoDocumento = dr["TipoDocumento"].ToString(),
                                NumeroDocumento = dr["NumeroDocumento"].ToString(),
                                MontoTotal = Convert.ToDecimal(dr["MontoTotal"].ToString()),
                                FechaRegistro = dr["FechaRegistro"].ToString()
                            };
                        }

                    }


                }
                catch (Exception)
                {
                    obj = new compra();
                }
            }
            return obj;
        }

        public List<detalle_compra> ObtenerDetalleCompra(int idcompra)
        {
            List<detalle_compra> oLista = new List<detalle_compra>();
            try
            {
                using (SqlConnection oconexion = new SqlConnection(conexion.cadena))
                {
                    oconexion.Open();
                    StringBuilder query = new StringBuilder();

                    query.AppendLine("select p.Nombre,dc.PrecioCompra,dc.Cantidad,dc.MontoTotal,dc.UnidadMedida from DETALLE_COMPRA dc");
                    query.AppendLine("inner join PRODUCTO p on p.IdProducto = dc.IdProducto");
                    query.AppendLine("where dc.IdCompra =  @idcompra");

                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.Parameters.AddWithValue("@idcompra", idcompra);
                    cmd.CommandType = System.Data.CommandType.Text;

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oLista.Add(new detalle_compra()
                            {
                                oproducto = new producto() { Nombre = dr["Nombre"].ToString() },
                                PrecioCompra = Convert.ToDecimal(dr["PrecioCompra"].ToString()),
                                Cantidad = Convert.ToInt32(dr["Cantidad"].ToString()),
                                MontoTotal = Convert.ToDecimal(dr["MontoTotal"].ToString()),
                                UnidadMedida = dr["UnidadMedida"].ToString(),
                            });
                        }
                    }
                }
            }
            catch (Exception)
            {
                oLista = new List<detalle_compra>();
            }
            return oLista;
        }


    }
}
