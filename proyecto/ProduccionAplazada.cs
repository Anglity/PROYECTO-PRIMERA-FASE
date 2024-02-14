using System;

namespace proyecto
{
    public class ProduccionAplazada
    {
        public string NombreReceta { get; set; }
        public int Cantidad { get; set; }
        public DateTime HoraProgramada { get; set; }
        public bool FueManejada { get; set; } = false;


        public ProduccionAplazada(string nombreReceta, int cantidad, DateTime horaProgramada)
        {
            NombreReceta = nombreReceta;
            Cantidad = cantidad;
            HoraProgramada = horaProgramada;
        }
    }
}
