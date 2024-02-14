using System.Collections.Generic;

namespace entidad
{
    public class compra
    {


        public int IdCompra { get; set; }
        public usuario ousuario { get; set; }
        public proveedor oproveedor { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public decimal MontoTotal { get; set; }
        public List<detalle_compra> oDetalleCompra { get; set; }
        public string FechaRegistro { get; set; }
    }
}
