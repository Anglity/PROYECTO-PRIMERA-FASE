using datos;
using entidad;
using System.Collections.Generic;

namespace negocio
{
    public class cn_rol
    {
        private cd_rol objcd_rol = new cd_rol();

        public List<rol> listar()
        {
            return objcd_rol.listar();
        }


    }
}
