using datos;
using entidad;
using System.Collections.Generic;

namespace negocio
{
    public class cn_materiaprima
    {
        private cd_materiaprima objcd_materiaprima = new cd_materiaprima();

        public List<materiaprima> listar()
        {
            return objcd_materiaprima.listar();
        }

        public int Registrar(materiaprima obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.Codigo))
            {
                Mensaje += "Es necesario el código de la materia prima.\n";
            }

            if (string.IsNullOrEmpty(obj.Nombre))
            {
                Mensaje += "Es necesario el nombre de la materia prima.\n";
            }

            if (string.IsNullOrEmpty(obj.Proveedor))
            {
                Mensaje += "Es necesario el proveedor de la materia prima.\n";
            }

            if (string.IsNullOrEmpty(obj.UnidadDeMedida))
            {
                Mensaje += "Es necesario la unidad de medida de la materia prima.\n";
            }

            if (Mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return objcd_materiaprima.Registrar(obj, out Mensaje);
            }
        }

        public bool Editar(materiaprima obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.Codigo))
            {
                Mensaje += "Es necesario el código de la materia prima.\n";
            }

            if (string.IsNullOrEmpty(obj.Nombre))
            {
                Mensaje += "Es necesario el nombre de la materia prima.\n";
            }

            if (string.IsNullOrEmpty(obj.Proveedor))
            {
                Mensaje += "Es necesario el proveedor de la materia prima.\n";
            }

            if (string.IsNullOrEmpty(obj.UnidadDeMedida))
            {
                Mensaje += "Es necesario la unidad de medida de la materia prima.\n";
            }

            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objcd_materiaprima.Editar(obj, out Mensaje);
            }
        }

        public bool Eliminar(materiaprima obj, out string Mensaje)
        {
            return objcd_materiaprima.Eliminar(obj, out Mensaje);
        }
    }
}
