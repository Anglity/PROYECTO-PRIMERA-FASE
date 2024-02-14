using datos;
using entidad;
using System.Collections.Generic;

namespace negocio
{
    public class cn_empleado
    {
        private cd_empleado objcd_empleado = new cd_empleado();


        public List<empleado> listar()
        {
            return objcd_empleado.listar();
        }

        public int Registrar(empleado obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.Documento == "")
            {
                Mensaje += "Es necesario el documento del Cliente\n";
            }

            if (obj.Nombre == "")
            {
                Mensaje += "Es necesario el nombre completo del Cliente\n";
            }

            if (obj.Correo == "")
            {
                Mensaje += "Es necesario el correo del Cliente\n";
            }

            if (Mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return objcd_empleado.Registrar(obj, out Mensaje);
            }
        }


        public bool Editar(empleado obj, out string Mensaje)
        {

            Mensaje = string.Empty;

            if (obj.Documento == "")
            {
                Mensaje += "Es necesario el documento del Cliente\n";
            }

            if (obj.Nombre == "")
            {
                Mensaje += "Es necesario el nombre completo del Cliente\n";
            }

            if (obj.Correo == "")
            {
                Mensaje += "Es necesario el correo del Cliente\n";
            }
            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objcd_empleado.Editar(obj, out Mensaje);
            }
        }


        public bool Eliminar(empleado obj, out string Mensaje)
        {
            return objcd_empleado.Eliminar(obj, out Mensaje);
        }
    }
}
