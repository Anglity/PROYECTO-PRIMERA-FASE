using datos;
using entidad;
using System.Collections.Generic;


namespace negocio
{
    public class cn_usuario
    {
        private cd_usuario objcd_usuario = new cd_usuario();

        public List<usuario> listar()
        {
            return objcd_usuario.listar();
        }
        public int Registrar(usuario obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.Documento == "")
            {
                Mensaje = "Es necesario el documento del usuario\n";
            }

            if (obj.NombreCompleto == "")
            {
                Mensaje = "Es necesario el nombre del usuario\n";
            }

            if (obj.Clave == "")
            {
                Mensaje = "Es necesario la clave del usuario\n";
            }

            if (Mensaje != string.Empty)
            {
                return 0;
            }

            else
            {
                return objcd_usuario.Registrar(obj, out Mensaje);
            }
        }

        public bool Editar(usuario obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.Documento == "")
            {
                Mensaje = "Es necesario el documento del usuario\n";
            }

            if (obj.NombreCompleto == "")
            {
                Mensaje = "Es necesario el nombre del usuario\n";
            }

            if (obj.Clave == "")
            {
                Mensaje = "Es necesario la clave del usuario\n";
            }

            if (Mensaje != string.Empty)
            {
                return false;
            }

            else
            {
                return objcd_usuario.Editar(obj, out Mensaje);
            }
        }
        public bool Eliminar(usuario obj, out string Mensaje)
        {
            return objcd_usuario.Eliminar(obj, out Mensaje);
        }

        public bool ActualizarPrimerInicioSesion(usuario obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            obj.PrimerInicioSesion = false; // Actualizar el campo
            return objcd_usuario.Editar(obj, out Mensaje); // Llama al método Editar de cd_usuario
        }
    }
}
