public class receta
{
    public int Id { get; set; }
    public string NombreReceta { get; set; }
    public string Productos { get; set; }
    public string Preparacion { get; set; }
    public string Tiempo { get; set; }
    public byte[] Imagen { get; set; }

    public int CantidadProduccion { get; set; }
    public receta()
    {
    }

    public receta(string nombrereceta, string productosYcantidades, string preparacion, string tiempo, byte[] imagen)
    {
        NombreReceta = nombrereceta;
        Productos = productosYcantidades;
        Preparacion = preparacion;
        Tiempo = tiempo;
        Imagen = imagen;
    }

    // Métodos adicionales para manejar la entidad pueden ser añadidos aquí,
    // como por ejemplo métodos para guardar, actualizar, borrar, etc.
}
