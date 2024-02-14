using entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace datos
{
    public class cd_reporte
    {
        public List<reporte_compra> Compra(string fechainicio, string fechafin, int idproveedor)
        {
            List<reporte_compra> lista = new List<reporte_compra>();

            using (SqlConnection oconexion = new SqlConnection(conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    SqlCommand cmd = new SqlCommand("sp_ReporteCompras", oconexion);
                    cmd.Parameters.AddWithValue("fechainicio", fechainicio);
                    cmd.Parameters.AddWithValue("fechafin", fechafin);
                    cmd.Parameters.AddWithValue("idproveedor", idproveedor);
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {

                            lista.Add(new reporte_compra()
                            {
                                FechaRegistro = dr["FechaRegistro"].ToString(),
                                TipoDocumento = dr["TipoDocumento"].ToString(),
                                NumeroDocumento = dr["NumeroDocumento"].ToString(),
                                MontoTotal = dr["MontoTotal"].ToString(),
                                UsuarioRegistro = dr["UsuarioRegistro"].ToString(),
                                DocumentoProveedor = dr["DocumentoProveedor"].ToString(),
                                RazonSocial = dr["RazonSocial"].ToString(),
                                CodigoProducto = dr["CodigoProducto"].ToString(),
                                NombreProducto = dr["NombreProducto"].ToString(),
                                Categoria = dr["Categoria"].ToString(),
                                PrecioCompra = dr["PrecioCompra"].ToString(),
                                PrecioVenta = dr["PrecioVenta"].ToString(),
                                Cantidad = dr["Cantidad"].ToString(),
                                SubTotal = dr["SubTotal"].ToString(),
                                UnidadMedida = dr["UnidadMedida"].ToString()
                            });
                        }
                    }
                }
                catch (Exception)
                {

                    lista = new List<reporte_compra>();
                }
            }
            return lista;
        }

        public List<reporte_venta> Venta(string fechainicio, string fechafin)
        {
            List<reporte_venta> lista = new List<reporte_venta>();

            using (SqlConnection oconexion = new SqlConnection(conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    SqlCommand cmd = new SqlCommand("sp_ReporteVentas", oconexion);
                    cmd.Parameters.AddWithValue("fechainicio", fechainicio);
                    cmd.Parameters.AddWithValue("fechafin", fechafin);
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new reporte_venta()
                            {
                                FechaRegistro = dr["FechaRegistro"].ToString(),
                                TipoDocumento = dr["TipoDocumento"].ToString(),
                                NumeroDocumento = dr["NumeroDocumento"].ToString(),
                                MontoTotal = dr["MontoTotal"].ToString(),
                                UsuarioRegistro = dr["UsuarioRegistro"].ToString(),
                                DocumentoCliente = dr["DocumentoCliente"].ToString(),
                                NombreCliente = dr["NombreCliente"].ToString(),
                                CodigoProducto = dr["CodigoProducto"].ToString(),
                                NombreProducto = dr["NombreProducto"].ToString(),
                                Categoria = dr["Categoria"].ToString(),
                                PrecioVenta = dr["PrecioVenta"].ToString(),
                                Cantidad = dr["Cantidad"].ToString(),
                                SubTotal = dr["SubTotal"].ToString(),
                                itbis = dr["itbis"].ToString(),
                                Valortotal = dr["Valortotal"].ToString(),
                                UnidadesMedida = dr["UnidadesMedida"].ToString(),
                                Galones_a_Litro = dr["Galones_a_Litro"].ToString(),
                                Bloque_a_Libra = dr["Bloque_a_Libra"].ToString(),
                            });
                        }
                    }
                }
                catch (Exception)
                {
                    lista = new List<reporte_venta>();
                }
            }

            return lista;

        }

        public List<reporte_produccion> Produccion(string fechainicio, string fechafin)
        {
            List<reporte_produccion> lista = new List<reporte_produccion>();

            using (SqlConnection oconexion = new SqlConnection(conexion.cadena))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_ReporteProduccion", oconexion);
                    cmd.Parameters.AddWithValue("fechainicio", fechainicio);
                    cmd.Parameters.AddWithValue("fechafin", fechafin);
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new reporte_produccion()
                            {
                                FechaProduccion = dr["FechaProduccion"].ToString(),
                                Nombre = dr["Nombre"].ToString(),
                                Stock = dr["Stock"].ToString(),
                                CantidadCheddar = dr["CantidadCheddar"].ToString(),
                                CantidadDanes = dr["CantidadDanes"].ToString(),
                                UnidadMedidaGenerica = dr["UnidadMedidaGenerica"].ToString(),
                                CantidadTotal = dr["CantidadTotal"].ToString(),
                            });
                        }
                    }
                }
                catch (Exception)
                {
                    lista = new List<reporte_produccion>();
                }
            }
            return lista;
        }


    }
}
