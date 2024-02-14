using datos;
using entidad;
using System.Collections.Generic;

namespace negocio
{
    public class cn_proveedor
    {
        private cd_proveedor objcd_proveedor = new cd_proveedor();


        public List<proveedor> listar()
        {
            return objcd_proveedor.listar();
        }

        public int Registrar(proveedor obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.Documento == "")
            {
                Mensaje += "Es necesario el documento del Proveedor\n";
            }

            if (obj.RazonSocial == "")
            {
                Mensaje += "Es necesario la razon social del Proveedor\n";
            }

            if (obj.Correo == "")
            {
                Mensaje += "Es necesario la correo del Proveedor\n";
            }

            if (Mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return objcd_proveedor.Registrar(obj, out Mensaje);
            }
        }


        public bool Editar(proveedor obj, out string Mensaje)
        {

            Mensaje = string.Empty;

            if (obj.Documento == "")
            {
                Mensaje += "Es necesario el documento del Proveedor\n";
            }

            if (obj.RazonSocial == "")
            {
                Mensaje += "Es necesario la razon social del Proveedor\n";
            }

            if (obj.Correo == "")
            {
                Mensaje += "Es necesario la correo del Proveedor\n";
            }



            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objcd_proveedor.Editar(obj, out Mensaje);
            }
        }


        public bool Eliminar(proveedor obj, out string Mensaje)
        {
            return objcd_proveedor.Eliminar(obj, out Mensaje);
        }


    }
}
