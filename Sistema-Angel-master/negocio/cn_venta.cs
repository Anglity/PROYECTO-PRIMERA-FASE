using datos;
using entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace negocio
{
    public class cn_venta
    {
        private cd_venta objcd_venta = new cd_venta();

        public bool RestarStock(int idproducto, int cantidad)
        {
            return objcd_venta.RestarStock(idproducto, cantidad);
        }

        public bool SumarStock(int idproducto, int cantidad)
        {
            return objcd_venta.SumarStock(idproducto, cantidad);
        }

        public int ObtenerCorrelativo()
        {
            return objcd_venta.ObtenerCorrelativo();
        }

        public bool Registrar(venta obj, DataTable detalleventa, out string Mensaje)
        {
            return objcd_venta.Registrar(obj, detalleventa, out Mensaje);
        }

        public venta ObtenerVenta(string numero)
        {
            venta oVenta = objcd_venta.ObtenerVenta(numero);

            if (oVenta.IdVenta != 0)
            {
                List<detalle_venta> oDetalleVenta = objcd_venta.ObtenerDetalleVenta(oVenta.IdVenta);
                oVenta.odetalleventa = oDetalleVenta;
            }

            return oVenta;
        }


        public List<venta> ObtenerTodasLasVentas()
        {
            List<venta> ventas = new List<venta>();

            using (SqlConnection oconexion = new SqlConnection(conexion.cadena))
            {
                try
                {
                    oconexion.Open();
                    StringBuilder query = new StringBuilder();

                    query.AppendLine("SELECT v.IdVenta, u.NombreCompleto,");
                    query.AppendLine("v.DocumentoCliente, v.NombreCliente,");
                    query.AppendLine("v.TipoDocumento, v.NumeroDocumento,");
                    query.AppendLine("v.MontoPago, v.MontoCambio, v.MontoTotal,");
                    query.AppendLine("CONVERT(char(10), v.FechaRegistro, 103) AS FechaRegistro");
                    query.AppendLine("FROM VENTA v");
                    query.AppendLine("INNER JOIN USUARIO u ON u.IdUsuario = v.IdUsuario");

                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.CommandType = System.Data.CommandType.Text;

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            venta obj = new venta()
                            {
                                IdVenta = int.Parse(dr["IdVenta"].ToString()),
                                ousuario = new usuario() { NombreCompleto = dr["NombreCompleto"].ToString() },
                                DocumentoCliente = dr["DocumentoCliente"].ToString(),
                                NombreCliente = dr["NombreCliente"].ToString(),
                                TipoDocumento = dr["TipoDocumento"].ToString(),
                                NumeroDocumento = dr["NumeroDocumento"].ToString(),
                                MontoPago = Convert.ToDecimal(dr["MontoPago"].ToString()),
                                MontoCambio = Convert.ToDecimal(dr["MontoCambio"].ToString()),
                                MontoTotal = Convert.ToDecimal(dr["MontoTotal"].ToString()),
                                FechaRegistro = dr["FechaRegistro"].ToString(),
                            };
                            ventas.Add(obj);
                        }
                    }
                }
                catch
                {
                    ventas = new List<venta>();
                }
            }
            return ventas;
        }

    }
}
