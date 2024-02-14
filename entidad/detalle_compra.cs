namespace entidad
{
    public class detalle_compra
    {
        public int IdDetalleCompra { get; set; }
        public producto oproducto { get; set; }
        public decimal PrecioCompra { get; set; }
        public decimal PrecioVenta { get; set; }
        public int Cantidad { get; set; }
        public decimal MontoTotal { get; set; }
        public string FechaRegistro { get; set; }
        public string UnidadMedida { get; set; }
    }
}
