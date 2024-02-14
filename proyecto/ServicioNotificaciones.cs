using System;
using System.Collections.Generic;


public class Notificacion
{
    public string Mensaje { get; set; }
    public DateTime FechaHora { get; set; }

    public Notificacion(string mensaje)
    {
        Mensaje = mensaje;
        FechaHora = DateTime.Now; // Asignar la fecha y hora actual
    }
}
public static class ServicioNotificaciones
{
    private static List<string> listaNotificaciones = new List<string>();


    public static event Action<int> OnNotificacionAdded;

    // Método para agregar una notificación
    public static void AgregarNotificacion(string notificacion)
    {
        listaNotificaciones.Add(notificacion);
        OnNotificacionAdded?.Invoke(listaNotificaciones.Count);
    }


    // Método para obtener todas las notificaciones
    public static List<string> ObtenerNotificaciones()
    {
        return listaNotificaciones;
    }

    // Método para limpiar las notificaciones
    public static void LimpiarNotificaciones()
    {
        listaNotificaciones.Clear();
    }

    public static int ObtenerCantidadNotificaciones()
    {
        return listaNotificaciones.Count;
    }
}
