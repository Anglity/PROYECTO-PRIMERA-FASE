using datos;
using entidad;
using System.Collections.Generic;

namespace negocio
{
    public class cn_permiso
    {

        private cd_permiso objcd_permiso = new cd_permiso();

        public List<permiso> listar(int IdUsuario)
        {
            return objcd_permiso.listar(IdUsuario);
        }
    }
}
