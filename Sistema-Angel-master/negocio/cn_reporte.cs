using datos;
using entidad;
using System.Collections.Generic;

namespace negocio
{
    public class cn_reporte
    {
        private cd_reporte objcd_reporte = new cd_reporte();

        public List<reporte_compra> Compra(string fechainicio, string fechafin, int idproveedor)
        {
            return objcd_reporte.Compra(fechainicio, fechafin, idproveedor);
        }


        public List<reporte_venta> Venta(string fechainicio, string fechafin)
        {
            return objcd_reporte.Venta(fechainicio, fechafin);
        }

        // Añadir el método para reporte de producción aquí
        public List<reporte_produccion> Produccion(string fechainicio, string fechafin)
        {
            return objcd_reporte.Produccion(fechainicio, fechafin);
        }
    }
}
