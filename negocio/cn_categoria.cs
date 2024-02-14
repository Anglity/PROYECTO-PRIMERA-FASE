using datos;
using entidad;
using System.Collections.Generic;

namespace negocio
{
    public class cn_categoria
    {
        private cd_categoria objcd_categoria = new cd_categoria();

        public List<categoria> listar()
        {
            return objcd_categoria.listar();
        }
        public int Registrar(categoria obj, out string Mensaje)
        {
            Mensaje = string.Empty;



            if (obj.Descripcion == "")
            {
                Mensaje += "Es necesario la Decripcion de la categoria\n";
            }

            if (Mensaje != string.Empty)
            {
                return 0;
            }

            else
            {
                return objcd_categoria.Registrar(obj, out Mensaje);
            }
        }

        public bool Editar(categoria obj, out string Mensaje)
        {
            Mensaje = string.Empty;




            if (obj.Descripcion == "")
            {
                Mensaje = "Es necesario la Decripcion de la categoria\n";
            }

            if (Mensaje != string.Empty)
            {
                return false;
            }

            else
            {
                return objcd_categoria.Editar(obj, out Mensaje);
            }
        }
        public bool Eliminar(categoria obj, out string Mensaje)
        {
            return objcd_categoria.Eliminar(obj, out Mensaje);
        }
    }
}
