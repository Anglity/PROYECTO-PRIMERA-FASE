namespace entidad
{

    public class materiaprima
    {
        public int IdMateriaPrima { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Proveedor { get; set; }
        public string UnidadDeMedida { get; set; }

        public string CantidadEnStock { get; set; }

        public string CostoPorUnidad { get; set; }
        public string FechaRegistro { get; set; } // Fecha de registro de la materia prima
    }


}







