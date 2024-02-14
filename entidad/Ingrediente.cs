namespace entidad
{
    public class Ingrediente
    {
        public string Nombre { get; set; }
        public int CantidadNueva { get; set; }
        public bool EsNuevo { get; set; }

        public Ingrediente() { }

        public Ingrediente(string nombre, int cantidadNueva)
        {
            Nombre = nombre;
            CantidadNueva = cantidadNueva;
        }
    }
}
