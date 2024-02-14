using System.Configuration;

namespace datos
{
    public class conexion
    {
        public static string cadena = ConfigurationManager.ConnectionStrings["cadena_conexion"].ToString();
    }
}
