using System;

namespace entidad
{
    public class produccion
    {
        public int Id { get; set; }
        public DateTime FechaProduccion { get; set; }
        public int CantidadCheddar { get; set; }
        public int CantidadDanes { get; set; }
        public string UnidadMedidaGenerica { get; set; }
        public int CantidadTotal { get; set; }

    }
}
