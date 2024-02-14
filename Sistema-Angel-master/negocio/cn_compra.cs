using datos;
using entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace negocio
{
    public class cn_compra
    {
        private cd_compra objcd_compra = new cd_compra();


        public int ObtenerCorrelativo()
        {
            return objcd_compra.ObtenerCorrelativo();
        }

        public bool Registrar(compra obj, DataTable DetalleCompra, out string Mensaje)
        {
            return objcd_compra.Registrar(obj, DetalleCompra, out Mensaje);
        }

        public compra ObtenerCompra(string numero)
        {

            compra oCompra = objcd_compra.ObtenerCompra(numero);

            if (oCompra.IdCompra != 0)
            {
                List<detalle_compra> oDetalleCompra = objcd_compra.ObtenerDetalleCompra(oCompra.IdCompra);

                oCompra.oDetalleCompra = oDetalleCompra;
            }
            return oCompra;
        }

        public List<compra> ObtenerTodasLasCompras()
        {
            List<compra> compras = new List<compra>();

            using (SqlConnection oconexion = new SqlConnection(conexion.cadena))
            {
                try
                {
                    oconexion.Open();
                    StringBuilder query = new StringBuilder();

                    query.AppendLine("SELECT c.IdCompra, u.NombreCompleto,");
                    query.AppendLine("pr.Documento, pr.RazonSocial,");
                    query.AppendLine("c.TipoDocumento, c.NumeroDocumento, c.MontoTotal,");
                    query.AppendLine("CONVERT(char(10), c.FechaRegistro, 103) AS FechaRegistro");
                    query.AppendLine("FROM COMPRA c");
                    query.AppendLine("INNER JOIN USUARIO u ON u.IdUsuario = c.IdUsuario");
                    query.AppendLine("INNER JOIN PROVEEDOR pr ON pr.IdProveedor = c.IdProveedor");

                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.CommandType = System.Data.CommandType.Text;

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            compra obj = new compra()
                            {
                                IdCompra = Convert.ToInt32(dr["IdCompra"]),
                                ousuario = new usuario() { NombreCompleto = dr["NombreCompleto"].ToString() },
                                oproveedor = new proveedor() { Documento = dr["Documento"].ToString(), RazonSocial = dr["RazonSocial"].ToString() },
                                TipoDocumento = dr["TipoDocumento"].ToString(),
                                NumeroDocumento = dr["NumeroDocumento"].ToString(),
                                MontoTotal = Convert.ToDecimal(dr["MontoTotal"].ToString()),
                                FechaRegistro = dr["FechaRegistro"].ToString()
                            };
                            compras.Add(obj);
                        }
                    }
                }
                catch
                {
                    compras = new List<compra>();
                }
            }
            return compras;
        }

    }
}


