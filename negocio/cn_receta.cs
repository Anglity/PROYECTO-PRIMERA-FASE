using datos;
using System.Collections.Generic;

namespace negocio
{
    public class cn_receta
    {
        private cd_receta cdReceta = new cd_receta();

        // Método para listar todas las recetas
        public List<receta> Listar()
        {
            return cdReceta.Listar();
        }

        // Método para registrar una nueva receta
        public int Registrar(receta receta, out string mensaje)
        {
            // Aquí puedes agregar lógica de negocio adicional si es necesario
            return cdReceta.Registrar(receta, out mensaje);
        }

        public bool EliminarPorNombre(string nombreReceta, out string mensaje)
        {
            return cdReceta.EliminarPorNombre(nombreReceta, out mensaje);
        }

    }
}
