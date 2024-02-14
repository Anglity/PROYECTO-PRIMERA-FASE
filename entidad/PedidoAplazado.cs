using System;

namespace entidad
{
    public class PedidoAplazado
    {
        public int Id { get; set; }
        public string NombreReceta { get; set; }
        public int Cantidad { get; set; }
        public DateTime FechaHoraProgramada { get; set; }
        public bool FueManejada { get; set; }

        public PedidoAplazado() { }

        public PedidoAplazado(string nombreReceta, int cantidad, DateTime fechaHoraProgramada, bool fueManejada = false)
        {
            NombreReceta = nombreReceta;
            Cantidad = cantidad;
            FechaHoraProgramada = fechaHoraProgramada;
            FueManejada = fueManejada;
        }
    }
}
