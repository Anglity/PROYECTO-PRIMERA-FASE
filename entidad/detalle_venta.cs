namespace entidad
{
    public class detalle_venta
    {
        public int IdDetalleVenta { get; set; }
        public producto oproducto { get; set; }
        public decimal PrecioVenta { get; set; }
        public int Cantidad { get; set; }
        public decimal SubTotal { get; set; }


        public decimal itbis { get; set; }
        public decimal Valortotal { get; set; }
        public string FechaRegistro { get; set; }
        public string UnidadesMedida { get; set; }

        public decimal Galones_a_Litro { get; set; }
        public decimal Bloque_a_Libra { get; set; }

    }
}

