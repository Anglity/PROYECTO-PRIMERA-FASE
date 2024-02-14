using System.Collections.Generic;

namespace entidad
{
    public class venta
    {
        public int IdVenta { get; set; }
        public usuario ousuario { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string DocumentoCliente { get; set; }
        public string NombreCliente { get; set; }
        public decimal MontoPago { get; set; }
        public decimal MontoCambio { get; set; }
        public decimal MontoTotal { get; set; }
        public List<detalle_venta> odetalleventa { get; set; }
        public string FechaRegistro { get; set; }


    }
}
