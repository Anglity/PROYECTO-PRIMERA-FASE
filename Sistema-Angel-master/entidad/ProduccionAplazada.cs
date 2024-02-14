using System;

namespace entidad
{
    public class ProduccionAplazada
    {
        public int Id { get; set; }
        public string NombreReceta { get; set; }
        public int Cantidad { get; set; }

        private DateTime fechaHoraProgramada;

        public bool FueManejada { get; set; }

        // Constructor vacío
        public ProduccionAplazada() { }

        // Método para obtener la fecha y hora programada
        public DateTime ObtenerFechaHoraProgramada()
        {
            return fechaHoraProgramada;
        }

        // Método para establecer la fecha y hora programada
        public void EstablecerFechaHoraProgramada(DateTime fechaHora)
        {
            fechaHoraProgramada = fechaHora;
        }

        // Constructor con todos los parámetros, excepto el Id que es autoincremental
        public ProduccionAplazada(string nombreReceta, int cantidad, DateTime fechaHora, bool fueManejada = false)
        {
            NombreReceta = nombreReceta;
            Cantidad = cantidad;
            EstablecerFechaHoraProgramada(fechaHora); // Usando el método para establecer la fecha y hora
            FueManejada = fueManejada;
        }
    }
}
