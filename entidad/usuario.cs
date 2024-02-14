namespace entidad
{
    public class usuario
    {

        public int IdUsuario { get; set; }
        public string Documento { get; set; }
        public string NombreCompleto { get; set; }
        public string Correo { get; set; }
        public string Clave { get; set; }
        public rol oRol { get; set; }
        public bool Estado { get; set; }
        public string FechaRegistro { get; set; }
        public bool PrimerInicioSesion { get; set; }
        public string ClaveCambiada { get; set; }



    }
}
